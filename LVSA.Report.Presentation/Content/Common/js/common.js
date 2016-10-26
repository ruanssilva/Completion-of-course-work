/*----------------------------------------------------------------------------
 * Váriaveis globais
 *---------------------------------------------------------------------------*/
var devicewidth = (window.innerWidth > 0) ? window.innerWidth : screen.width;
var hiddenxs = 767;


/*-----------------------------------------------------------------------------
 * Funções genericas para exibição de notification
 *----------------------------------------------------------------------------*/
function Notification(Title, Message, Class) {
    $.gritter.add({
        title: Title,
        text: Message,
        class_name: Class
    });

    return false;
}

function ShowNotificationError(Title, Message, Position) {
    var pclass = Position == "center" ? "gritter-center" : "";

    Notification(Title, Message, "gritter-error " + pclass);
}
function ShowNotificationInfo(Title, Message, Position) {
    var pclass = Position == "center" ? "gritter-center" : "";

    Notification(Title, Message, "gritter-info " + pclass);
}
function ShowNotificationWarning(Title, Message, Position) {
    var pclass = Position == "center" ? "gritter-center" : "";

    Notification(Title, Message, "gritter-warning " + pclass);
}
function ShowGrittersuccess(Title, Message, Position) {
    var pclass = Position == "center" ? "gritter-center" : "";

    Notification(Title, Message, "gritter-success " + pclass);
}

function ShowLoading(Message) {
    Message = Message != null ? Message : "Aguardando resposta do servidor...";

    $('#Loading').find('span').html(Message);

    $('#Loading').fadeIn();
}

function HideLoading() {
    $('#Loading').fadeOut();
}

$(function () {

    $('input[data-mask*="$"]').each(function () {
        $(this).mask($(this).attr('data-mask').substring(1, $(this).attr('data-mask').length));
    });

    $('select.select2').each(function () {

        $(this).select2({
            placeholder: 'Selecione',
            allowClear: true
        });
        $('.select2').css("width", "280px");

    });

    $('img').error(function () {
        $(this).addClass("without");
        $(this).attr("alt", "");
    });

    if ($("table.datatable").length > 0) {

        var typepagination = devicewidth > hiddenxs ? "simple_numbers" : "listbox";

        var filter = $("table.datatable").attr("data-filter") != "false";
        var info = $("table.datatable").attr("data-info") != "false";
        var pagination = $('table.datatable').attr('data-pagination') != 'false';
        var sort = $('table.datatable').attr('data-sort') != 'false';
        var pdf = $('table.datatable').attr('data-export-pdf') != 'false';
        var excel = $('table.datatable').attr('data-export-excel') != 'false';
        var print = $('table.datatable').attr('data-export-print') != 'false';
        var copy = $('table.datatable').attr('data-export-copy') != 'false';

        var _datatable = $('table.datatable').dataTable({
            "sPaginationType": typepagination,
            "bSort": sort,
            "bFilter": filter,
            "bInfo" : info,
            "bPaginate": pagination,
            "oLanguage": {
                "sProcessing": "Processando...",
                "sLengthMenu": "Mostrar _MENU_ registros",
                "sZeroRecords": "Não foram encontrados resultados",
                "sInfo": "Mostrando de _START_ até _END_ de _TOTAL_ registros",
                "sInfoEmpty": "Mostrando de 0 até 0 de 0 registros",
                "sInfoFiltered": "(filtrado de _MAX_ registros no total)",
                "sInfoPostFix": "",
                "sSearch": "Filtrar:",
                "sUrl": "",
                "oPaginate": {
                    "sFirst": "<<",
                    "sPrevious": "<",
                    "sNext": ">",
                    "sLast": ">>"
                }
            },

        });

        //TableTools settings
        TableTools.classes.container = "btn-group btn-overlap";
        TableTools.classes.print = {
            "body": "DTTT_Print",
            "info": "tableTools-alert gritter-item-wrapper gritter-info gritter-center white",
            "message": "tableTools-print-navbar"
        }

        var aButtons = [];

        if (copy)
            aButtons.push({
                "sExtends": copy ? "copy" : "",
                "sToolTip": "Copiar para área de transferência",
                "sButtonClass": "btn btn-default",
                "sButtonText": "<i class='fa fa-copy'></i> <small class='hidden-xs hidden-sm'>Copiar</small>",
                "fnComplete": function () {
                    this.fnInfo('<div class="gritter-item"><span class="gritter-title">Tabela copiada</span><p>Copiada ' + (_datatable.fnSettings().fnRecordsTotal()) + ' linha(s) para a área de transferência.</p></div>',
                        1500
                    );
                }
            });

        if (excel)
            aButtons.push({
                "sExtends": excel ? "xls" : "",
                "sToolTip": "Exportar para excel",
                "sButtonClass": "btn btn-default",
                "sButtonText": "<i class='fa fa-file-excel-o'></i> <small class='hidden-xs hidden-sm'>Excel</small>"
            });

        if (pdf)
            aButtons.push({
                "sExtends": pdf ? "pdf" : "",
                "sToolTip": "Exportar para PDF",
                "sButtonClass": "btn btn-default",
                "sButtonText": "<i class='fa fa-file-pdf-o'></i> <small class='hidden-xs hidden-sm'>PDF</small>"
            });

        if (print)
            aButtons.push({
                "sExtends": print ? "print" : "",
                "sToolTip": "Visualizar impressão",
                "sButtonClass": "btn btn-default",
                "sButtonText": "<i class='fa fa-print'></i> <small class='hidden-xs hidden-sm'>Visualizar impressão</small>",

                "sMessage": "",

                "sInfo": '<div class="gritter-item"><span class="gritter-title">Visualização de impressão</span><p>Por favor use a função de impressão do seu navegador para imprimir. Pressione <b>ESC</b> para sair.</p></div>',
            });

        //initiate TableTools extension
        var tableTools_obj = new $.fn.dataTable.TableTools(_datatable, {
            "sSwfPath": "http://localhost/Report/Content/Common/swf/copy_csv_xls_pdf.swf", //in Ace demo ../assets will be replaced by correct assets path

            "sRowSelector": "td:not(:last-child)",
            "sRowSelect": "multi",
            "fnRowSelected": function (row) {
                //check checkbox when row is selected
                //try { $(row).find('input[type=checkbox]').get(0).checked = true }
                //catch (e) { }
            },
            "fnRowDeselected": function (row) {
                //uncheck checkbox
                //try { $(row).find('input[type=checkbox]').get(0).checked = false }
                //catch (e) { }
            },

            "sSelectedClass": "",
            "aButtons": aButtons
        });
        //we put a container before our table and append TableTools element to it
        $(tableTools_obj.fnContainer()).appendTo($('.tableTools-container'));

        //also add tooltips to table tools buttons
        //addding tooltips directly to "A" buttons results in buttons disappearing (weired! don't know why!)
        //so we add tooltips to the "DIV" child after it becomes inserted
        //flash objects inside table tools buttons are inserted with some delay (100ms) (for some reason)
        setTimeout(function () {
            $(tableTools_obj.fnContainer()).find('a.DTTT_button').each(function () {
                var div = $(this).find('> div');
                if (div.length > 0) div.tooltip({ container: 'body' });
                else $(this).tooltip({ container: 'body' });
            });
        }, 200);

    }

    $('a').click(function () {
        var target = $(this).attr("target");
        var href = $(this).attr("href");

        var loading = href != null && href.indexOf("#") == -1 && href.indexOf("javascript:void(0)") == -1 && target != "_blank" && href.indexOf("mailto") == -1;

        if (loading)
            ShowLoading();
    });

    $('form').submit(function () {
        ShowLoading();
    });

    HideLoading();
});