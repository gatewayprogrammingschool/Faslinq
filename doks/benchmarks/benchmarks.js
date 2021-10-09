function ViewModel(report) {
    const self = this;

    self.report = report;

    self.selectedMethods = [];
    self.selectedApis = [];
    self.selectedPlatforms = [];

    self.count = [];
    self.counts = [
        { display: '1', regex: "1" },
        { display: '250', regex: "250" },
        { display: '5000', regex: "5000" },
        { display: '100,000', regex: "100000" },
    ];

    self.method = [];
    self.methods = [
        { display: 'Select', regex: /^\bSelect\b/im },
        { display: 'Where', regex: /^\bWhere\b/im },
        { display: 'WhereSelect', regex: /^\bWhereSelect\b/im },
        { display: 'Take', regex: /^\bTake\b/im },
        { display: 'TakeLast', regex: /^\bTakeLast\b/im },
        { display: 'SelectTake', regex: /^\bSelectTake\b/im },
        { display: 'SelectTakeLast', regex: /^\bSelectTakeLast\b/im },
        { display: 'WhereTake', regex: /^\bWhereTake\b/im },
        { display: 'WhereTakeLast', regex: /^\bWhereTakeLast\b/im },
        { display: 'WhereSelectTake', regex: /^\bWhereSelectTake\b/im },
        { display: 'WhereSelectTakeLast', regex: /^\bWhereSelectTakeLast\b/im },
        { display: 'First', regex: /^\bFirst\b/im },
        { display: 'FirstWhere', regex: /^\bFirstWhere\b/im },
        { display: 'Last', regex: /^\bLast\b/im },
        { display: 'LastWhere', regex: /^\bLastWhere\b/im },
    ];

    self.api = [];
    self.apis = [
        { display: 'Faslinq List', regex: "List" },
        { display: 'Faslinq Array', regex: "Array" },
        { display: 'Linq', regex: "Linq" }
    ];

    self.platform = [];
    self.platforms = [
        { display: '.Net 6.x', regex: /^.*\s6\.\d/im },
        { display: '.Net 5.x', regex: /^.*\s5\.\d/im },
        { display: '.Net 4.8', regex: /^.*\s4\.8/im },
        { display: '.Net 4.7.2', regex: /^.*\s4\.7\.2/im }
    ];

    self.selectClicked = (select) => {
        var id = select.id;

        const selected = Array
            .from(select.options)
            .filter((option, index) => {
                return option.selected
                    ? option
                    : null;
            });

        switch (id)
        {
            case "methods":
                self.method = selected.map((option) => {
                    if (option.index > -1) {
                        return self.methods[option.index];
                    }
                });
                break;

            case "apis":
                self.api = selected.map((option) => {
                    if (option.index > -1) {
                        return self.apis[option.index];
                    }
                });
                break;

            case "platforms":
                self.platform = selected.map((option) => {
                    if (option.index > -1) {
                        return self.platforms[option.index];
                    }
                });
                break;

            case "counts":
                self.count = selected.map((option) => {
                    if (option.index > -1) {
                        return self.counts[option.index];
                    }
                });
                break;
        }

        self.buildTable("tbody");
    }

    self.populateSelect = (id, values) => {
        var select = document.getElementById(id);

        if (values.length == 0) return;

        for (let i = 0; i < values.length; ++i) {
            var option = document.createElement("option");

            option.innerText = values[i].display;

            select.appendChild(option);
        }
    }

    self.buildTable = (id) => {
        var tbody = document.getElementById(id);

        if (tbody) {
            const rows = tbody.getElementsByClassName("body_row");

            if (Array.isArray(rows)) {
                rows.forEach((tr) => {
                    tbody.removeChild(tr);
                });
            } else if (rows.__proto__.toString() === "[object HTMLCollection]") {
                for (let i = rows.length-1; i >= 0 ; --i) {
                    tbody.removeChild(rows[i]);
                }
            }

            const bms = self.benchmarks();

            bms.sort((a, b) => (a.Method + `${a.Ratio}`) - (b.Method + `${b.Ratio}`));

            for (let i = 0; i < bms.length; ++i) {
                const bm = bms[i];
                var tr = document.createElement("tr");
                tr.classList.add("body_row");

                // <td data-bind="text: Method" ></td>
                tr.appendChild(self.createCell([], bm.Method));
                // <td class="stat" data-bind="text: $root.Format($data.Size, 0, '')" ></td>
                tr.appendChild(self.createCell(["stat"], self.Format(bm.Size, 0, '')));
                // <td data-bind="text: Api" ></td>
                tr.appendChild(self.createCell([], bm.Api));
                // <td data-bind="text: Platform"></td>
                tr.appendChild(self.createCell([], bm.Platform));
                // <td class="stat" data-bind="text: $root.Format($data.Ratio, 3, '')" ></td>
                tr.appendChild(self.createCell(["stat"], self.Format(bm.Ratio, 3, '')));
                // <td class="stat" data-bind="text: $root.Format($data.Mean)" ></td>
                tr.appendChild(self.createCell(["stat"], self.Format(bm.Mean)));
                // <td class="stat" data-bind="text: $root.Format($data.Median)" ></td>
                tr.appendChild(self.createCell(["stat"], self.Format(bm.Median)));
                // <td class="stat" data-bind="text: $root.Format($data.StandardDeviation)" ></td>
                tr.appendChild(self.createCell(["stat"], self.Format(bm.StandardDeviation)));
                // <td class="stat" data-bind="text: $root.Format($data.Min)" ></td>
                tr.appendChild(self.createCell(["stat"], self.Format(bm.Min)));
                // <td class="stat" data-bind="text: $root.Format($data.Max)" ></td>
                tr.appendChild(self.createCell(["stat"], self.Format(bm.Max)));

                tbody.appendChild(tr);
            }
        }
    }

    self.createCell = (classes, value) =>
    {
        var td = document.createElement("td");

        if (classes.length > 0) {
            td.classList.add(classes);
        }

        td.innerText = value;

        return td;
    }

    self.Format = function (n, d, trailing) {
        if (typeof(d) === "undefined") { d = 2; }
        if (typeof(trailing) === "undefined") { trailing = " ns"; }

        var value = n.toLocaleString(
            undefined, // leave undefined to use the visitor's browser
            // locale or a string like 'en-US' to override it.
            { minimumFractionDigits: d }
        );

        return `${value}${trailing}`
    }

    self.resetMethod = function () {
        self.method = [];
        Array.from(document.getElementById("methods").options)
            .forEach((option) => option.selected = false);

        self.buildTable("tbody");
    };

    self.resetApi = function () {
        self.api = [];
        Array.from(document.getElementById("apis").options)
            .forEach((option) => option.selected = false);

        self.buildTable("tbody");
    };

    self.resetPlatform = function () {
        self.platform = [];
        Array.from(document.getElementById("platforms").options)
            .forEach((option) => option.selected = false);

        self.buildTable("tbody");
    };

    self.resetCount = function () {
        self.count = [];
        Array.from(document.getElementById("counts").options)
            .forEach((option) => option.selected = false);

        self.buildTable("tbody");
    }

    // self.benchmarks = ko.observable(self.report.Benchmarks);
    self.benchmarks =function () {
        let result = self.report.map((item)=>item.Value);

        const methodFilter = self.method;
        const apiFilter = self.api;
        const platformFilter = self.platform;
        const countFilter = self.count;

        if (methodFilter.length > 0) {
            result = result.filter(bm => {
                const mfFound = methodFilter.find(m => {
                    const found = m.regex?.test(bm.Method);
                    return found;
                });

                return mfFound ?? false;;
            });
        }

        if (apiFilter.length > 0) {
            result = result.filter(bm => {
                const apiFound = apiFilter.find(m => {
                    const found = m.regex===bm.Api;
                    return found;
                });

                return apiFound ?? false;
            });
        }

        if (platformFilter.length > 0) {
            result = result.filter(bm => {
                const platform = bm.Platform;

                const platformFound = platformFilter.find(m => {
                    const found = m.regex?.test(platform);
                    return found;
                });

                return platformFound ?? false;
            });
        }

        if (countFilter.length > 0) {
            result = result.filter(bm => {
                const countFound = countFilter.find(m => {
                    const found = m.regex===bm.Size;
                    return found;
                });

                return countFound ?? false;
            });
        }

        return result;
    }
}

class Report {
    async getReport() {
        if (!this.report) {
            let result = await fetch("/benchmarks/faslinq-report.json");

            if (!result.ok) {
                result = await fetch("/Faslinq/benchmarks/faslinq-report.json");

                if (!result.ok) {
                    throw new Error(result.statusText);
                }
            }

            const json = await result.json();

            return this.report = json;
        }

        return this.report;
    }

    toString() { JSON.stringify(this.report); }
}

const report = new Report();
const obj = await report.getReport();
const vm = new ViewModel(obj);
export const VM = vm;
