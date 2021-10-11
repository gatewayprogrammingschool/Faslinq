---
# Page settings
layout: page
keywords: Linq Dotnet
---
<div class="content_row">
    <div class="flex_container">
        <div class="flex_card">
            <label for="methods">Methods</label>
            <select name='methods' id='methods' title='Methods' class="form-control"
                                     size="8" multiple="true" onclick="document.vm.selectClicked(this)"></select>
            <button class="btn--dark" onclick="document.vm.resetMethod()">Reset</button>
        </div>

        <div class="flex_card">
            <label for="platforms">Platform</label>
            <select name='platforms' id='platforms' title='Platforms'
                                     size="4" multiple="true" onclick="vm.selectClicked(this)"></select>
            <button class="btn--dark" onclick="vm.resetPlatform()">Reset</button>
        </div>

        <div class="flex_card">
            <label for="apis">API</label>
            <select name='apis' id='apis' title='APIs'
                                     size="3" multiple="true" onclick="document.vm.selectClicked(this)"></select>
            <button class="btn--dark" onclick="document.vm.resetApi()">Reset</button>
        </div>

        <div class="flex_card">
            <label for="counts">Batch Size</label>
            <select name='counts' id='counts' title='Counts'
                                     size="4" multiple="true" onclick="document.vm.selectClicked(this)"></select>
            <button class="btn--dark" onclick="document.vm.resetCount()">Reset</button>
        </div>
    </div>
    <div class="table_container">
        <table class="table-responsive col-lg-10">
            <tbody id='tbody'>
                <tr class="header_row" id="header_row">
                    <th>Benchmark</th>
                    <th>Count</th>
                    <th>Api</th>
                    <th>Platform</th>
                    <th>Ratio</th>
                    <th>Mean</th>
                    <th>Median</th>
                    <th>Std.Dev.</th>
                    <th>Min</th>
                    <th>Max</th>
                </tr>
            </tbody>
        </table>
    </div>
</div>
<script type="module" src="/benchmarks/benchmarks.js"></script>
<script type="module" src="/Faslinq/benchmarks/benchmarks.js"></script>
<script type="module">
    try{
        import { VM } from '/benchmarks/benchmarks.js';
        VM.buildTable("tbody");
        VM.populateSelect("methods", VM.methods);
        VM.populateSelect("platforms", VM.platforms);
        VM.populateSelect("apis", VM.apis);
        VM.populateSelect("counts", VM.counts);

        document.vm = VM;
    } catch {
        import { VM } from '/Faslinq/benchmarks/benchmarks.js';
        VM.buildTable("tbody");
        VM.populateSelect("methods", VM.methods);
        VM.populateSelect("platforms", VM.platforms);
        VM.populateSelect("apis", VM.apis);
        VM.populateSelect("counts", VM.counts);

        document.vm = VM;
    }
</script>
