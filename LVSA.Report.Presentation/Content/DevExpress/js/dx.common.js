var dataGrid;
var dataGridHeader;
var dataGridSource;

var dataGraph;
var dataGraphHeader;
var dataGraphSource;

$(function () {

    if ($('table#report-grid').length > 0) {

        dataGridHeader = $('table#report-grid th').map(function () {
            return $(this).text();
        }).get();

        dataGridSource = $('table#report-grid tbody tr').map(function (idx, el) {
            var td = $(el).find('td');
            var obj = {};

            for (var i = 0; i < dataGridHeader.length; i++) {
                obj[dataGridHeader[i]] = td.eq(i).text();
            }

            return obj;
        }).get();

        

        dataGrid = $("#gridContainer").dxDataGrid({
            noDataText: "A pesquisa não obteve resultados",
            dataSource: dataGridSource,
            allowColumnReordering: true,
            allowColumnResizing: true,
            columnAutoWidth: true,
            columnChooser: {
                enabled: true,
                title: "Ocultar uma coluna",
                emptyPanelText: "Arraste uma coluna aqui para oculta-la"
            },
            selection: {
                mode: 'single'
            },
            filterRow: {
                visible: true
            },
            //selection: {
            //	mode: 'multiple'
            //},
            //editing: {
            //    editMode: 'row',
            //    editEnabled: false,
            //    removeEnabled: true,
            //    insertEnabled: false
            //},
            //editing: {
            //    editMode: 'batch',
            //    editEnabled: true
            //},
            hoverStateEnabled: true,
            searchPanel: {
                visible: true,
                width: 240,
                placeholder: 'Buscar...'
            },
            paging: {
                pageSize: 25
            },
            pager: {
                showPageSizeSelector: true,
                allowedPageSizes: [10, 25, 50]
            },
            //scrolling: {
            //    mode: 'virtual'
            //},
            groupPanel: {
                visible: true,
                emptyPanelText: "Arraste um cabeçalho de coluna aqui para agrupar por essa coluna"
            },
            //summary: {
            //	totalItems: [{
            //		column: 'Id',
            //		summaryType: 'count'
            //	}]
            //},
            //onEditingStart: function (e) {
            //	logEvent('EditingStart');
            //},
            //onInitNewRow: function (e) {
            //	logEvent('InitNewRow');
            //},
            //onRowInserting: function (e) {
            //	logEvent('RowInserting');
            //},
            //onRowInserted: function (e) {
            //	logEvent('RowInserted');
            //},
            //onRowUpdating: function (e) {
            //	logEvent('RowUpdating');
            //},
            //onRowUpdated: function (e) {
            //	logEvent('RowUpdated');
            //},
            //onRowRemoving: function (e) {
            //	logEvent('RowRemoving');
            //},
            //onRowRemoved: function (e) {
            //	logEvent('RowRemoved');
            //}

        }).dxDataGrid('instance');
    }

    if ($('table#report-graph').length > 0) {

        var cont = 0;

        dataGraphHeader = $('table#report-graph th').map(function () {
            cont++;
            if (cont == 1)
                return { valueField: "$property", name: null };

            return { valueField: $(this).text(), name: $(this).text() };
        }).get();

        dataGraphSource = $('table#report-graph tbody tr').map(function (idx, el) {

            var td = $(el).find('td');
            var obj = {};

            for (var i = 0; i < dataGraphHeader.length; i++) {
                if (!isNaN(parseFloat(td.eq(i).text())))
                    obj[dataGraphHeader[i].valueField] = parseFloat(td.eq(i).text().replace(',','.'));
                else
                    obj[dataGraphHeader[i].valueField] = td.eq(i).text();
            }

            return obj;

        }).get();

        dataGraph = $("#graphContainer").dxChart({
            equalBarWidth: false,
            dataSource: dataGraphSource,
            commonSeriesSettings: {
                argumentField: "$property",
                hoverMode: "allArgumentPoints",
                selectionMode: "allArgumentPoints",
                type: "bar",
                label: {
                    visible: true,
                    format: "fixedPoint",
                    precision: 2
                }
            },
            series: dataGraphHeader.splice(1, dataGraphHeader.length),
            legend: {
                verticalAlignment: "bottom",
                horizontalAlignment: "center"
            },
            title: $('#report-graph').attr('data-title')
        });

    }
});