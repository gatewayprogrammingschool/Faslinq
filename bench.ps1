param(
    [string]$Configuration = 'Release',
    [string[]]$Filter = @('*.Select_*'),
    [switch]$All = $false,
    [switch]$Select = $false,
    [switch]$Where = $false,
    [switch]$Take = $false,
    [switch]$TakeLast = $false,
    [switch]$Once = $false,
    [switch]$Join = $false,
    [switch]$NoFaslinq = $false,
    [string[]]$Runtimes = @("net6.0")
)


function Clean-Folder {
    param(
        [String[]]$P = @('obj', 'bin'),
        [switch]$R = $false,
        [switch]$F = $false,
        [switch]$V = $false
    )
    if ($V) {
        Write-Host "`$P: $P"
        Write-Host "`$R: $R"
        Write-Host "`$F: $F"
        Write-Host "`$V: $V"
    }

    #gci bin,obj -r

    Get-ChildItem $P -Recurse:$R -Verbose:$V `
    | Remove-Item -Recurse:$R -Force:$F -Verbose:$V

}

[System.Collections.Generic.List[string[]]]$Names = @()
if ($All) {
    [string[]]$Filter = @('*')
}
else {
    $f = @()

    if ($Select) {
        $f += '-Select'
    }
    if ($Where) {
        $f += '-Where'
    }
    if ($Take) {
        $f += '-Take'
    }
    if ($TakeLast) {
        $f += '-TakeLast'
    }
}

$FF = [System.String]::Join(' ', $f)

if ($Once) {
    $OneIteration = '--runOncePerIteration'
}

if ($Join) {
    $joinParameter = '--join'
}

if ($NoFaslinq) {
    $NoFaslinqOption = '/p:DefineConstants=NO_FASLINQ'
}
else {
    $NoFaslinqOption = ''
}

Push-Location

$root = Get-Location

Clean-Folder -p @('bin', 'obj', '*.artifacts') -r -f

& dotnet restore

Set-Location "$root\Faslinq.Benchmarks\"

$Runtime = [System.DateTimeOffset]::Now.ToString('G')
$md = @("# Benchmark Run at ${Runtime}", '')

$Title = 'Faslinq'

if ($NoFaslinq) {
    $Title = 'Linq'
}

$md += ''
$md += "``````powershell"
$md += "dotnet publish -c $Configuration $NoFaslinqOption -f net6.0 -a x64 --self-contained"
$md += "``````"
$md += ''
& dotnet publish -c $Configuration $NoFaslinqOption -f net6.0 -a x64 --self-contained

Set-Location "$root\Faslinq.Benchmarks\bin\$Configuration\net6.0\win-x64\publish\"

Write-Verbose "`$Configuration: $Configuration"
Write-Verbose "`$OneIteration: $OneIteration"
Write-Verbose "`$Filter: $Filter"

$md += ''
$md += "``````powershell"
$md += "& .\Faslinq.Benchmarks.exe $OneIteration $joinParameter ${FF} --platform X64"
$md += "``````"
$md += ''
& .\Faslinq.Benchmarks.exe $OneIteration $joinParameter ${FF} --platform X64

Set-Location "$root\Faslinq.Benchmarks\bin\$Configuration\net6.0\win-x64\publish\BenchmarkDotNet.Artifacts\results"

$mds = Get-ChildItem '*github.md' -ErrorAction Stop

$md += '', "## ${Title}", ''
$md += $mds | Get-Content

if ($NoFaslinq) {
    Remove-Item *github.md

    Set-Location "$root\Faslinq.Benchmarks\"

    $md += ''
    $md += "``````powershell"
    $md += "dotnet publish -c $Configuration -f net6.0 -a x64 --self-contained"
    $md += "``````"
    $md += ''
    & dotnet publish -c $Configuration -f net6.0 -a x64 --self-contained

    Set-Location "$root\Faslinq.Benchmarks\bin\$Configuration\net6.0\win-x64\publish\"

    $md += ''
    $md += "``````powershell"
    $md += "& .\Faslinq.Benchmarks.exe $OneIteration $joinParameter ${FF} --platform X64"
    $md += "``````"
    $md += ''
    & .\Faslinq.Benchmarks.exe $OneIteration $joinParameter ${FF} --platform X64

    Set-Location "$root\Faslinq.Benchmarks\bin\$Configuration\net6.0\win-x64\publish\BenchmarkDotNet.Artifacts\results"

    $md += '', '## Faslinq', ''

    $mds = Get-ChildItem '*github.md' -ErrorAction Stop
    $md += $mds | Get-Content
}

foreach ($name in $Names) {
    $Key = $name[0] + '|'
    $Value = $name[1] + '|'
    $md = $md.Replace($Key, $Value)
}

Write-Host $md

$resultsFile = "$root\results.md"

$md | Out-File $resultsFile -Force

$edge = Get-Command *edge.exe

& $edge $resultsFile

Pop-Location
