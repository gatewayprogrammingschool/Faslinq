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
                                    data-bind="options: $root.methods, optionsText: 'display', selectedOptions: $root.method" size="8" multiple="true"></select>
            <button class="btn--dark" data-bind="click: $root.resetMethod.bind()">Reset</button>
        </div>

        <div class="flex_card">
            <label for="platforms">Platform</label>
            <select name='platforms' id='platforms' title='Platforms'
                                    data-bind="options: $root.platforms, optionsText: 'display', selectedOptions: $root.platform" size="4" multiple="true"></select>
            <button class="btn--dark" data-bind="click: $root.resetPlatform.bind()">Reset</button>
        </div>

        <div class="flex_card">
            <label for="apis">API</label>
            <select name='apis' id='apis' title='APIs'
                                    data-bind="options: $root.apis, optionsText: 'display', selectedOptions: $root.api" size="3" multiple="true"></select>
            <button class="btn--dark" data-bind="click: $root.resetApi.bind()">Reset</button>
        </div>

        <div class="flex_card">
            <label for="counts">Batch Size</label>
            <select name='counts' id='counts' title='Counts'
                                    data-bind="options: $root.counts, optionsText: 'display', selectedOptions: $root.count" size="4" multiple="true"></select>
            <button class="btn--dark" data-bind="click: $root.resetCount.bind()">Reset</button>
        </div>
    </div>
    <div class="table_container">
        <table class="table-responsive col-lg-10">
            <tbody>
                <tr class="header_row">
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
                <!--  ko foreach: $root.benchmarks -->
                <tr class="body_row">
                    <td data-bind="text: Method" ></td>
                    <td class="stat" data-bind="text: $root.Format($data.Size, 0, '')" ></td>
                    <td data-bind="text: Api" ></td>
                    <td data-bind="text: Platform"></td>
                    <td class="stat" data-bind="text: $root.Format($data.Ratio, 3, '')" ></td>
                    <td class="stat" data-bind="text: $root.Format($data.Mean)" ></td>
                    <td class="stat" data-bind="text: $root.Format($data.Median)" ></td>
                    <td class="stat" data-bind="text: $root.Format($data.StandardDeviation)" ></td>
                    <td class="stat" data-bind="text: $root.Format($data.Min)" ></td>
                    <td class="stat" data-bind="text: $root.Format($data.Max)" ></td>
                </tr>
                <!-- /ko  -->
            </tbody>
        </table>
    </div>
</div>
<script type="module" src="/benchmarks/benchmarks.js"></script>
<script type="text/javascript" src="https://ajax.aspnetcdn.com/ajax/knockout/knockout-2.2.1.js"></script>
<script type="module">
    import { VM } from '/benchmarks/benchmarks.js';
    ko.applyBindings(VM);
</script>
