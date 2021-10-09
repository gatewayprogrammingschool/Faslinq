function ViewModel(report) {
    const self = this;

    self.report = report;

    self.selectedMethods = ko.observableArray([]);
    self.selectedApis = ko.observableArray([]);
    self.selectedPlatforms = ko.observableArray([]);

    self.count = ko.observableArray([]);
    self.counts = ko.observableArray([
        { display: '1', regex: "1" },
        { display: '250', regex: "250" },
        { display: '5000', regex: "5000" },
        { display: '100,000', regex: "100000" },
    ]);

    self.method = ko.observableArray([]);
    self.methods = ko.observableArray([
        { display: 'Select', regex: /^(Where)?Select(Take|TakeLast)?/im },
        { display: 'Where', regex: /^Where(Select)?(Take|TakeLast)?/im },
        { display: 'Take', regex: /^(Where|WhereSelect|Select)?Take?/im },
        { display: 'TakeLast', regex: /^(Where|WhereSelect|Select)?TakeLast/im },
        { display: 'First', regex: /^First/im },
        { display: 'FirstWhere', regex: /^FirstWhere/im },
        { display: 'Last', regex: /^Last/im },
        { display: 'LastWhere', regex: /^LastWhere/im },
    ]);

    self.api = ko.observableArray([]);
    self.apis = ko.observableArray([
        { display: 'Faslinq List', regex: "List" },
        { display: 'Faslinq Array', regex: "Array" },
        { display: 'Linq', regex: "Linq" }
    ]);

    self.platform = ko.observableArray([]);
    self.platforms = ko.observableArray([
        { display: '.Net 6.x', regex: /^.*\s6\.\d/im },
        { display: '.Net 5.x', regex: /^.*\s5\.\d/im },
        { display: '.Net 4.8', regex: /^.*\s4\.8/im },
        { display: '.Net 4.7.2', regex: /^.*\s4\.7\.2/im }
    ]);

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
        self.method.removeAll();
    }

    self.resetApi = function () {
        self.api.removeAll();
    }

    self.resetPlatform = function () {
        self.platform.removeAll();
    }

    self.resetCount = function () {
        self.count.removeAll();
    }

    // self.benchmarks = ko.observable(self.report.Benchmarks);
    self.benchmarks = ko.computed(function () {
        let result = self.report.map((item)=>item.Value);

        const methodFilter = self.method() ?? new Array();
        const apiFilter = self.api() ?? new Array();
        const platformFilter = self.platform() ?? new Array();
        const countFilter = self.count() ?? new Array();

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
    }, this);
}

class Report {
    async getReport() {
        if (!this.report) {
            const result = await fetch("/benchmarks/faslinq-report.json");

            if (!result.ok) throw new Error(result.statusText);

            const json = await result.json();

            return this.report = json;
        }

        return this.report;
    }

    //self.report = toReport('{//% include_relative full-report.json %//}');

    toString() { JSON.stringify(this.report); }

    toReport(obj) {
        return this.cast(obj, this.r("Benchmarks"));
    }

    reportToJson(value) {
        return JSON.stringify(uncast(value, this.r("Benchmarks")), null, 2);
    }

    invalidValue(typ, val, key = '') {
        if (key) {
            throw Error(`Invalid value for key "${key}". Expected type ${JSON.stringify(typ)} but got ${JSON.stringify(val)}`);
        }
        throw Error(`Invalid value ${JSON.stringify(val)} for type ${JSON.stringify(typ)}`,);
    }

    jsonToJSProps(typ) {
        if (typ.jsonToJS === undefined) {
            const map = {};
            typ.props.forEach((p) => map[p.json] = { key: p.js, typ: p.typ });
            typ.jsonToJS = map;
        }
        return typ.jsonToJS;
    }

    jsToJSONProps(typ) {
        if (typ.jsToJSON === undefined) {
            const map = {};
            typ.props.forEach((p) => map[p.js] = { key: p.json, typ: p.typ });
            typ.jsToJSON = map;
        }
        return typ.jsToJSON;
    }

    transform(val, typ, getProps, key = '') {
        this.transformPrimitive = (typ, val) => {
            if (typeof typ === typeof val) return val;
            return this.invalidValue(typ, val, key);
        };

        this.transformUnion = (typs, val) => {
            // val must validate against one typ in typs
            const l = typs.length;
            for (let i = 0; i < l; i++) {
                const typ = typs[i];
                try {
                    return this.transform(val, typ, getProps);
                } catch (_) { }
            }
            return this.invalidValue(typs, val);
        };

        this.transformEnum = (cases, val) => {
            if (cases.indexOf(val) !== -1) return val;
            return this.invalidValue(cases, val);
        };

        this.transformArray = (typ, val) => {
            // val must be an array with no invalid elements
            if (!Array.isArray(val)) return this.invalidValue("array", val);
            return val.map(el => this.transform(el, typ, getProps));
        };

        this.transformDate = (val) => {
            if (val === null) {
                return null;
            }
            const d = new Date(val);
            if (isNaN(d.valueOf())) {
                return this.invalidValue("Date", val);
            }
            return d;
        };

        this.transformObject = (props, additional, val) => {
            if (val === null || typeof val !== "object" || Array.isArray(val)) {
                return this.invalidValue("object", val);
            }
            const result = {};
            Object.getOwnPropertyNames(props).forEach(key => {
                const prop = props[key];
                const v = Object.prototype.hasOwnProperty.call(val, key) ? val[key] : undefined;
                result[prop.key] = this.transform(v, prop.typ, getProps, prop.key);
            });
            Object.getOwnPropertyNames(val).forEach(key => {
                if (!Object.prototype.hasOwnProperty.call(props, key)) {
                    result[key] = this.transform(val[key], additional, getProps, key);
                }
            });
            return result;
        };

        if (typ === "any") return val;
        if (typ === null) {
            if (val === null) return val;
            return this.invalidValue(typ, val);
        }
        if (typ === false) return this.invalidValue(typ, val);
        while (typeof typ === "object" && typ.ref !== undefined) {
            typ =[typ.ref];
        }
        if (Array.isArray(typ)) return this.transformEnum(typ, val);
        if (typeof typ === "object") {
            return typ.hasOwnProperty("unionMembers") ? this.transformUnion(typ.unionMembers, val)
                : typ.hasOwnProperty("arrayItems") ? this.transformArray(typ.arrayItems, val)
                    : typ.hasOwnProperty("props") ? this.transformObject(getProps(typ), typ.additional, val)
                        : this.invalidValue(typ, val);
        }
        // Numbers can be parsed by Date but shouldn't be.
        if (typ === Date && typeof val !== "number") return this.transformDate(val);
        return this.transformPrimitive(typ, val);
    }

    cast = (val, typ) => {
        return this.transform(val, typ, this.jsonToJSProps);
    }

    uncast = (val, typ) => {
        return this.transform(val, typ, this.jsToJSONProps);
    }

    a = (typ) => {
        return { arrayItems: typ };
    }

    u = (...typs) => {
        return { unionMembers: typs };
    }

    o = (props, additional) => {
        return { props, additional };
    }

    m = (additional) => {
        return { props: [], additional };
    }

    r = (name) => {
        return { ref: name };
    }

    typeMap = {
        "Report": this.o([
            { json: "Title", js: "Title", typ: "" },
            { json: "HostEnvironmentInfo", js: "HostEnvironmentInfo", typ: this.r("HostEnvironmentInfo") },
            { json: "Benchmarks", js: "Benchmarks", typ: this.a(this.r("Benchmark")) },
        ], false),
        "Benchmark": this.o([
            { json: "DisplayInfo", js: "DisplayInfo", typ: "" },
            { json: "Namespace", js: "Namespace", typ: this.r("Namespace") },
            { json: "Type", js: "Type", typ: "" },
            { json: "Method", js: "Method", typ: "" },
            { json: "MethodTitle", js: "MethodTitle", typ: "" },
            { json: "Parameters", js: "Parameters", typ: this.r("Parameters") },
            { json: "FullName", js: "FullName", typ: "" },
            { json: "Statistics", js: "Statistics", typ: this.r("Statistics") },
            { json: "Memory", js: "Memory", typ: this.r("Memory") },
            { json: "Measurements", js: "Measurements", typ: this.a(this.r("Measurement")) },
            { json: "Metrics", js: "Metrics", typ: this.a(this.r("Metric")) },
        ], false),
        "Measurement": this.o([
            { json: "IterationMode", js: "IterationMode", typ: this.r("IterationMode") },
            { json: "IterationStage", js: "IterationStage", typ: this.r("IterationStage") },
            { json: "LaunchIndex", js: "LaunchIndex", typ: 0 },
            { json: "IterationIndex", js: "IterationIndex", typ: 0 },
            { json: "Operations", js: "Operations", typ: 0 },
            { json: "Nanoseconds", js: "Nanoseconds", typ: 0 },
        ], false),
        "Memory": this.o([
            { json: "Gen0Collections", js: "Gen0Collections", typ: 0 },
            { json: "Gen1Collections", js: "Gen1Collections", typ: 0 },
            { json: "Gen2Collections", js: "Gen2Collections", typ: 0 },
            { json: "TotalOperations", js: "TotalOperations", typ: 0 },
        ], false),
        "Metric": this.o([
            { json: "Value", js: "Value", typ: 0 },
            { json: "Descriptor", js: "Descriptor", typ: this.r("Descriptor") },
        ], false),
        "Descriptor": this.o([
            { json: "Id", js: "Id", typ: this.r("ID") },
            { json: "DisplayName", js: "DisplayName", typ: this.r("DisplayName") },
            { json: "Legend", js: "Legend", typ: "" },
            { json: "NumberFormat", js: "NumberFormat", typ: this.r("NumberFormat") },
            { json: "UnitType", js: "UnitType", typ: 0 },
            { json: "Unit", js: "Unit", typ: this.r("Unit") },
            { json: "TheGreaterTheBetter", js: "TheGreaterTheBetter", typ: true },
            { json: "PriorityInCategory", js: "PriorityInCategory", typ: 0 },
        ], false),
        "Statistics": this.o([
            { json: "OriginalValues", js: "OriginalValues", typ: this.a(0) },
            { json: "N", js: "N", typ: 0 },
            { json: "Min", js: "Min", typ: 0 },
            { json: "LowerFence", js: "LowerFence", typ: 0 },
            { json: "Q1", js: "Q1", typ: 0 },
            { json: "Median", js: "Median", typ: 0 },
            { json: "Mean", js: "Mean", typ: 0 },
            { json: "Q3", js: "Q3", typ: 0 },
            { json: "UpperFence", js: "UpperFence", typ: 0 },
            { json: "Max", js: "Max", typ: 0 },
            { json: "InterquartileRange", js: "InterquartileRange", typ: 0 },
            { json: "LowerOutliers", js: "LowerOutliers", typ: this.a("any") },
            { json: "UpperOutliers", js: "UpperOutliers", typ: this.a("any") },
            { json: "AllOutliers", js: "AllOutliers", typ: this.a("any") },
            { json: "StandardError", js: "StandardError", typ: 0 },
            { json: "Variance", js: "Variance", typ: 0 },
            { json: "StandardDeviation", js: "StandardDeviation", typ: 0 },
            { json: "Skewness", js: "Skewness", typ: "" },
            { json: "Kurtosis", js: "Kurtosis", typ: "" },
            { json: "ConfidenceInterval", js: "ConfidenceInterval", typ: this.r("ConfidenceInterval") },
            { json: "Percentiles", js: "Percentiles", typ: this.m(0) },
        ], false),
        "ConfidenceInterval": this.o([
            { json: "N", js: "N", typ: 0 },
            { json: "Mean", js: "Mean", typ: 0 },
            { json: "StandardError", js: "StandardError", typ: 0 },
            { json: "Level", js: "Level", typ: 0 },
            { json: "Margin", js: "Margin", typ: "" },
            { json: "Lower", js: "Lower", typ: "" },
            { json: "Upper", js: "Upper", typ: "" },
        ], false),
        "HostEnvironmentInfo": this.o([
            { json: "BenchmarkDotNetCaption", js: "BenchmarkDotNetCaption", typ: "" },
            { json: "BenchmarkDotNetVersion", js: "BenchmarkDotNetVersion", typ: "" },
            { json: "OsVersion", js: "OsVersion", typ: "" },
            { json: "ProcessorName", js: "ProcessorName", typ: "" },
            { json: "PhysicalProcessorCount", js: "PhysicalProcessorCount", typ: 0 },
            { json: "PhysicalCoreCount", js: "PhysicalCoreCount", typ: 0 },
            { json: "LogicalCoreCount", js: "LogicalCoreCount", typ: 0 },
            { json: "RuntimeVersion", js: "RuntimeVersion", typ: "" },
            { json: "Architecture", js: "Architecture", typ: "" },
            { json: "HasAttachedDebugger", js: "HasAttachedDebugger", typ: true },
            { json: "HasRyuJit", js: "HasRyuJit", typ: true },
            { json: "Configuration", js: "Configuration", typ: "" },
            { json: "DotNetCliVersion", js: "DotNetCliVersion", typ: "" },
            { json: "ChronometerFrequency", js: "ChronometerFrequency", typ: this.r("ChronometerFrequency") },
            { json: "HardwareTimerKind", js: "HardwareTimerKind", typ: "" },
        ], false),
        "ChronometerFrequency": this.o([
            { json: "Hertz", js: "Hertz", typ: 0 },
        ], false),
        "IterationMode": [
            "Workload",
        ],
        "IterationStage": [
            "Actual",
            "Result",
        ],
        "DisplayName": [
            "Allocated",
        ],
        "ID": [
            "Allocated Memory",
        ],
        "NumberFormat": [
            "N0",
        ],
        "Unit": [
            "B",
        ],
        "Namespace": [
            "Faslinq.Benchmarks.Collections",
        ],
        "Parameters": [
            "item=Object[1]",
        ],
    };

}

const report = new Report();
const obj = await report.getReport();
const vm = new ViewModel(obj);
export const VM = vm;
