

var LVSA = {

    ///~public
    ///description: 
    Utility: {
        ///~public
        ///description: 
        ///data: { key : 'string', value : 'abcdefg', hours : 24 }
        setCookie: function (data) {
        },
        ///~public
        ///data: 'string'
        ///return: 'abcdegf'
        getCookie: function (key) {
        },

        Loading: function (show, message) {

            if (message != null)
                $('#Loading span').html(message)
            else
                $('#Loading span').html('Renderizando a página...');

            if (show)
                $('#Loading').fadeIn();
            else
                $('#Loading').fadeOut();
        }
    },

    ///~public
    ///description: 
    Ajax: {
        ///~public		
        ///description: 
        StatusCode: {
            100: function () { console.log('Continue'); },
            101: function () { console.log('Switching'); },
            103: function () { console.log('Checkpoint'); },
            200: function () { console.log('OK'); },
            201: function () { console.log('Created'); },
            202: function () { console.log('Accepted'); },
            203: function () { console.log('Non-Authoritative Information'); },
            204: function () { console.log('No Content'); },
            205: function () { console.log('Reset Content'); },
            206: function () { console.log('Partial Content'); },
            300: function () { console.log('Multiple Choices'); },
            301: function () { console.log('Moved Permanently'); },
            302: function () { console.log('Found'); },
            303: function () { console.log('See Other'); },
            304: function () { console.log('Not Modified'); },
            306: function () { console.log('Switch Proxy') },
            307: function () { console.log('Temporary Redirect') },
            308: function () { console.log('Resume Incomplete'); },
            400: function () { console.log('Bad Request'); },
            401: function () { console.log('Anauthorized'); },
            402: function () { console.log('Payment Required'); },
            403: function () { console.log('Forbidden'); },
            404: function () { console.log('Not Found'); },
            405: function () { console.log('Method Not Allowed'); },
            406: function () { console.log('Not Acceptable'); },
            407: function () { console.log('Proxy Authentication Required'); },
            408: function () { console.log('Request Timeout'); },
            409: function () { console.log('Conflict'); },
            410: function () { console.log('Gone'); },
            411: function () { console.log('Lenght Required'); },
            412: function () { console.log('Precondition Failed'); },
            413: function () { console.log('Request Entity Too large'); },
            414: function () { console.log('Request-URI Too Long'); },
            415: function () { console.log('Unsupported Media Type'); },
            416: function () { console.log('Requested Range Not Satisfiable'); },
            417: function () { console.log('Expectation Failed'); },
            500: function () { console.log('Internal Server Error'); },
            501: function () { console.log('Not Implemented'); },
            502: function () { console.log('Bad Gateway'); },
            503: function () { console.log('Service Unavailable'); },
            504: function () { console.log('Gateway Timeout'); },
            505: function () { console.log('HTTP Version Not Supported'); },
            511: function () { console.log('Network Authentication Required'); },


            Codes: {
                Continue: 100,
                Switching: 101,
                Checkpoint: 103,
                OK: 200,
                Created: 201,
                Accepted: 202,
                NonAuthoritativeInformation: 203,
                NoContent: 204,
                ResetContent: 205,
                PartialContext: 206
            }
        },
        ///~public
        ///description:
        ///data optional: { Content-Type : 'application/json', Authorization : 'abcdefg' }
        ///return: { Content-Type : 'application/json', Authorization: abcdefg ... }			
        Headers: function (data) {


            ///~private
            ///description:
            var _authorization = data['Authorization'];
            ///~private
            ///description:
            var _contenttype = data['Content-Type'];


            ///~public
            ///description:
            ///return: { Authorization : 'abcdefg', Content-Type : 'application/json' }
            var value = function () {
                var h = {};

                if (_authorization)
                    h['Authorization'] = _authorization;
                if (_contenttype)
                    h['Content-Type'] = _contenttype;

                return h;
            }

            ///return
            return {
                value: value()
            };
        },
        ///~public
        ///description: 
        ///data optional: { type: 'POST', url: 'www.api.com/recurso', data: { #informations }, headers: {  } }
        Request: function (data) {

            var _type = data['type'];
            var _url = data['url'];
            var _data = data['data'];
            var _headers = data['headers'];
            var _statuscode = data['statuscode'];
            var _async = data['async'];
            var _timeout = data['timeout'];
            var _error = data['error'];
            var _success = data['success'];


            var value = function () {

                if (!_statuscode)
                    _statuscode = LVSA.Ajax.StatusCode;

                return $.ajax({
                    type: _type,
                    url: _url,
                    data: _data,
                    headers: _headers,
                    timeout: _timeout,
                    async: _async,
                    error: _error,
                    success: _success,
                    statusCode: _statuscode,
                }).done(function (data) {
                    //_return = data;
                }).fail(function (error) {
                    //_error = error;
                    console.log(error);
                });
            }

            var Post = function () {
                _type = 'POST';

                return value();
            }
            var Get = function () {
                _type = 'GET';

                return value();
            }
            var Delete = function () {
                _type = 'DELETE';

                return value();
            }
            var Put = function () {
                _type = 'PUT';

                return value();
            }

            return {
                Post: Post,
                Get: Get,
                Delete: Delete,
                Put: Put,
            };
        },
    },


    CDN: {

        Configuration: {
            Server: "http://localhost/LVSA.CDN.Presentation/"
        },

        Plugins: {

            Inicialize: function () {

                if ($(".dd").length) {
                    LVSA.CDN.Plugins.Nestable();
                }

                if ($('select.chosen-select').length) {
                    LVSA.CDN.Plugins.Chosen();
                }

                if ($('.field-tags').length) {
                    LVSA.CDN.Plugins.Tag();
                }

                if ($('table.datatable').length) {
                    LVSA.CDN.Plugins.DataTable();
                }

                if ($('input[data-mask*="$"]').length || $('input[type="text"].maskmoney').length) {
                    LVSA.CDN.Plugins.Mask();
                }

                if ($('.textarea-editor').length) {
                    LVSA.CDN.Plugins.Wysiwyg();
                }

                if ($('.datepicker-date').length) {
                    LVSA.CDN.Plugins.Datepicker();
                }

                if ($(".datepicker-datetime").length) {
                    LVSA.CDN.Plugins.Datetimepicker();
                }

                if ($('input[type="file"]').length) {
                    LVSA.CDN.Plugins.File();
                }

                if ($('.ace-thumbnails').length) {
                    LVSA.CDN.Plugins.Colorbox();
                }

                $(':input[required], :input.required').parents('.form-group').find('label.control-label').append('<span class="red">*</span>');

                $('a:not(".not-show-loading")').click(function () {
                    var target = $(this).attr("target");
                    var href = $(this).attr("href");

                    var loading = href != null && href.trim() != '#' && href.trim() != '#' && href != "javascript:void(0);" && target != "_blank" && href.indexOf("mailto") == -1;

                    if (loading) {
                        LVSA.Utility.Loading(true, "Aguarde! Buscando dados...");
                    }
                });

                $('form:not(".not-show-loading")').submit(function () {


                    if ($(this).valid()) {
                        LVSA.Utility.Loading(true, "Aguarde! Processando...");
                    }
                    else {

                    }


                });

                LVSA.Utility.Loading(false);
            },



            File: function () {
                $('input[type="file"]').each(function () {

                    $(this).ace_file_input({
                        no_file: 'Selecione arquivo...',
                        btn_choose: 'Procurar',
                        btn_change: 'Alterar',
                        droppable: false,
                        onchange: null,
                        thumbnail: false, //| true | large
                        //whitelist: 'gif|png|jpg|jpeg',
                        //blacklist: 'exe|php'
                        //onchange:''
                        //
                    });
                });
            },

            Nestable: function () {
                $.getScript(LVSA.CDN.Configuration.Server + "Content/Templates/Ace/assets/js/jquery.nestable.js", function () {
                    $('.dd').nestable();
                });
            },

            Datepicker: function () {
                $.getScript(LVSA.CDN.Configuration.Server + "Content/Templates/Ace/assets/js/date-time/bootstrap-datepicker.js", function () {
                    $.getScript(LVSA.CDN.Configuration.Server + "Content/Templates/Ace/assets/js/date-time/bootstrap-datepicker.pt-BR.js", function () {
                        $('.datepicker-date').datepicker({
                            format: 'dd/mm/yyyy',
                            language: 'pt-BR'
                        });
                    });
                });
            },

            Datetimepicker: function () {
                $.getScript(LVSA.CDN.Configuration.Server + "Content/Templates/Ace/assets/js/date-time/moment.js", function () {
                    $.getScript(LVSA.CDN.Configuration.Server + "Content/Templates/Ace/assets/js/date-time/bootstrap-datetimepicker.js", function () {
                        $.getScript(LVSA.CDN.Configuration.Server + "Content/Templates/Ace/assets/js/date-time/pt-br.js", function () {
                            $(".datepicker-datetime").datetimepicker({
                                isRTL: false,
                                format: 'DD/MM/YYYY HH:mm',
                                autoclose: true,
                                language: 'pt-br'
                            });
                        });
                    });
                });
            },

            Colorbox: function () {
                $.getScript(LVSA.CDN.Configuration.Server + "Content/Templates/Ace/assets/js/jquery.colorbox.js", function () {
                    var $overflow = '';
                    var colorbox_params = {
                        rel: 'colorbox',
                        reposition: true,
                        scalePhotos: true,
                        scrolling: false,
                        previous: '<i class="ace-icon fa fa-arrow-left"></i>',
                        next: '<i class="ace-icon fa fa-arrow-right"></i>',
                        close: '&times;',
                        current: '{current} de {total}',
                        maxWidth: '100%',
                        maxHeight: '100%',
                        onOpen: function () {
                            $overflow = document.body.style.overflow;
                            document.body.style.overflow = 'hidden';
                        },
                        onClosed: function () {
                            document.body.style.overflow = $overflow;
                        },
                        onComplete: function () {
                            $.colorbox.resize();
                        }
                    };

                    $('.ace-thumbnails [data-rel="colorbox"]').colorbox(colorbox_params);
                    $("#cboxLoadingGraphic").html("<i class='ace-icon fa fa-spinner orange fa-spin'></i>");//let's add a custom loading icon


                    $(document).one('ajaxloadstart.page', function (e) {
                        $('#colorbox, #cboxOverlay').remove();
                    });
                });

            },

            Wysiwyg: function () {
                $.getScript(LVSA.CDN.Configuration.Server + "Content/Templates/Ace/assets/js/jquery.hotkeys.js", function () {
                    $.getScript(LVSA.CDN.Configuration.Server + "Content/Templates/Ace/assets/js/bootstrap-wysiwyg.js", function () {

                        $('.textarea-editor').ace_wysiwyg({
                            toolbar:
                            [
                                'font',
                                null,
                                'fontSize',
                                null,
                                { name: 'bold', className: 'btn-info' },
                                { name: 'italic', className: 'btn-info' },
                                { name: 'strikethrough', className: 'btn-info' },
                                { name: 'underline', className: 'btn-info' },
                                null,
                                { name: 'insertunorderedlist', className: 'btn-success' },
                                { name: 'insertorderedlist', className: 'btn-success' },
                                { name: 'outdent', className: 'btn-purple' },
                                { name: 'indent', className: 'btn-purple' },
                                null,
                                { name: 'justifyleft', className: 'btn-primary' },
                                { name: 'justifycenter', className: 'btn-primary' },
                                { name: 'justifyright', className: 'btn-primary' },
                                { name: 'justifyfull', className: 'btn-inverse' },
                                null,
                                { name: 'createLink', className: 'btn-pink' },
                                { name: 'unlink', className: 'btn-pink' },
                                null,
                                { name: 'insertImage', className: 'btn-success' },
                                null,
                                'foreColor',
                                null,
                                { name: 'undo', className: 'btn-grey' },
                                { name: 'redo', className: 'btn-grey' }
                            ],
                            'wysiwyg': {
                                //fileUploadError: showErrorAlert
                            }
                        }).prev().addClass('wysiwyg-style2');

                        $('[data-toggle="buttons"] .btn').on('click', function (e) {
                            var target = $(this).find('input[type=radio]');
                            var which = parseInt(target.val());
                            var toolbar = $('#editor1').prev().get(0);
                            if (which >= 1 && which <= 4) {
                                toolbar.className = toolbar.className.replace(/wysiwyg\-style(1|2)/g, '');
                                if (which == 1) $(toolbar).addClass('wysiwyg-style1');
                                else if (which == 2) $(toolbar).addClass('wysiwyg-style2');
                                if (which == 4) {
                                    $(toolbar).find('.btn-group > .btn').addClass('btn-white btn-round');
                                } else $(toolbar).find('.btn-group > .btn-white').removeClass('btn-white btn-round');
                            }
                        });

                        if (typeof jQuery.ui !== 'undefined' && ace.vars['webkit']) {

                            var lastResizableImg = null;
                            function destroyResizable() {
                                if (lastResizableImg == null) return;
                                lastResizableImg.resizable("destroy");
                                lastResizableImg.removeData('resizable');
                                lastResizableImg = null;
                            }

                            var enableImageResize = function () {
                                $('.wysiwyg-editor')
                                .on('mousedown', function (e) {
                                    var target = $(e.target);
                                    if (e.target instanceof HTMLImageElement) {
                                        if (!target.data('resizable')) {
                                            target.resizable({
                                                aspectRatio: e.target.width / e.target.height,
                                            });
                                            target.data('resizable', true);

                                            if (lastResizableImg != null) {
                                                //disable previous resizable image
                                                lastResizableImg.resizable("destroy");
                                                lastResizableImg.removeData('resizable');
                                            }
                                            lastResizableImg = target;
                                        }
                                    }
                                })
                                .on('click', function (e) {
                                    if (lastResizableImg != null && !(e.target instanceof HTMLImageElement)) {
                                        destroyResizable();
                                    }
                                })
                                .on('keydown', function () {
                                    destroyResizable();
                                });
                            }

                            enableImageResize();
                        }

                    });
                });
            },

            Mask: function () {
                $.getScript(LVSA.CDN.Configuration.Server + "Content/Templates/Ace/assets/js/jquery.maskedinput.js", function () {
                    $('input[data-mask*="$"]').each(function () {
                        $(this).mask($(this).attr('data-mask').substring(1, $(this).attr('data-mask').length));
                    });
                });
                $.getScript(LVSA.CDN.Configuration.Server + "Content/Plugins/MaskMoney/jquery.maskMoney.min.js", function () {
                    $('input[type="text"].maskmoney').each(function () {
                        $(this).maskMoney({
                            showSymbol:true,
                            symbol: 'R$',
                            thousands: '',
                            decimal: ',',
                            symbolStay: false,
                            allowZero:true,

                        });
                    });
                });
            },

            Chosen: function () {
                $.getScript(LVSA.CDN.Configuration.Server + "Content/Templates/Ace/assets/js/chosen.jquery.js", function () {
                    $('.chosen-select').chosen({
                        allow_single_deselect: true,
                        no_results_text: "Ops, não encontrado!"
                    });
                    $('.chosen-select').on("update", function () {
                        $(this).trigger("chosen:updated");
                    });
                });
            },

            Tag: function () {
                $.getScript(LVSA.CDN.Configuration.Server + "Content/Templates/Ace/assets/js/bootstrap-tag.js", function () {
                    $('.field-tags').each(function () {
                        $(this).tag({
                            placeholder: $(this).attr('placeholder')
                        });
                    });
                });
            },

            Gritter: {
                Default: function (title, message, style, fixed) {

                    return $.gritter.add({
                        title: title,
                        text: message,
                        class_name: style,
                        sticky: fixed
                    });
                },
                Error: function (title, message, center, fixed) {
                    return LVSA.CDN.Plugins.Gritter.Default(title, message, (center ? "gritter-center " : "") + "gritter-error", fixed);
                },
                Information: function (title, message, center, fixed) {
                    return LVSA.CDN.Plugins.Gritter.Default(title, message, (center ? "gritter-center " : "") + "gritter-info", fixed);
                },
                Warning: function (title, message, center, fixed) {
                    return LVSA.CDN.Plugins.Gritter.Default(title, message, (center ? "gritter-center " : "") + "gritter-warning", fixed);
                },
                Success: function (title, message, center, fixed) {
                    return LVSA.CDN.Plugins.Gritter.Default(title, message, (center ? "gritter-center " : "") + "gritter-success", fixed);
                },
                Confirm: function (title, message, center, callback_yes, callback_no) {

                    title = "<small><small>" + title + "</small></small>";

                    message += "<br/><br/> <a href='javascript:void(0);' onclick='" + callback_yes + "' class='btn btn-sm btn-success close-gritter'><i class='fa fa-check'></i> Sim</a> <a href='javascript:void(0);' onclick='" + callback_no + "' class='btn btn-sm btn-danger close-gritter'><i class='fa fa-remove'></i> Não</a>";
                    var result = LVSA.CDN.Plugins.Gritter.Default(title, message, (center ? "gritter-center " : ""), true);
                    $('.close-gritter').on('click', function () {
                        $(this).parents('.gritter-item:first').find('.gritter-close:first').trigger('click');
                    });
                    return result;
                },
                Answer: function (title, message, center, answer) {

                    title = "<small><small>" + title + "</small></small>";

                    if (answer == 'sim')
                        message += "<br/><br/> <label class='label label-success'><i class='fa fa-check'></i> Sim</label>";
                    else
                        message += "<br/><br/> <label class='label label-danger'><i class='fa fa-remove'></i> Não</label>";

                    return LVSA.CDN.Plugins.Gritter.Default(title, message, (center ? "gritter-center " : ""), true);
                }
            },

            DataTable: function () {
                $.getScript(LVSA.CDN.Configuration.Server + "Content/Templates/Ace/assets/js/dataTables/jquery.dataTables.js", function () {
                    $.getScript(LVSA.CDN.Configuration.Server + "Content/Templates/Ace/assets/js/dataTables/jquery.dataTables.bootstrap.js", function () {
                        $.getScript(LVSA.CDN.Configuration.Server + "Content/Templates/Ace/assets/js/dataTables/extensions/TableTools/js/dataTables.tableTools.js", function () {
                            $.getScript(LVSA.CDN.Configuration.Server + "Content/Templates/Ace/assets/js/dataTables/extensions/ColVis/js/dataTables.colVis.js", function () {
                                //$.getScript(LVSA.CDN.Configuration.Server + "Content/Templates/Ace/assets/js/dataTables/extensions/pagination/select.js", function () {

                                var _datatable = $('table.datatable').dataTable({
                                    'sPaginationType': ((window.innerWidth > 0) ? window.innerWidth : screen.width) > 767 ? 'full_numbers' : 'listbox',
                                    'bSort': true,
                                    'aaSorting': [],
                                    'bProcessing': true,
                                    'oLanguage': {
                                        'sProcessing': 'Processando...',
                                        'sLengthMenu': ((window.innerWidth > 0) ? window.innerWidth : screen.width) > 767 ? 'Mostrar _MENU_ registros' : '_MENU_',
                                        'sZeroRecords': 'Não foram encontrados resultados',
                                        'sInfo': 'Mostrando de _START_ até _END_ de _TOTAL_ registros',
                                        'sInfoEmpty': 'Mostrando de 0 até 0 de 0 registros',
                                        'sInfoFiltered': '(filtrado de _MAX_ registros no total)',
                                        'sInfoPostFix': '',
                                        'sSearch': 'Filtrar:',
                                        'sUrl': '',
                                        'oPaginate': {
                                            'sFirst': '<<',
                                            'sPrevious': '<',
                                            'sNext': '>',
                                            'sLast': '>>'
                                        }
                                    },
                                    'bFilter': ((window.innerWidth > 0) ? window.innerWidth : screen.width) > 767,
                                    'fnInitComplete': function (oSettings, json) {

                                    }
                                });

                                TableTools.classes.container = "btn-group btn-overlap";
                                TableTools.classes.print = {
                                    "body": "DTTT_Print",
                                    "info": "tableTools-alert gritter-item-wrapper gritter-info gritter-center white",
                                    "message": "tableTools-print-navbar"
                                }

                                //initiate TableTools extension
                                var tableTools_obj = new $.fn.dataTable.TableTools(_datatable, {
                                    "sSwfPath": LVSA.CDN.Configuration.Server + "Content/Templates/Ace/assets/js/dataTables/extensions/TableTools/swf/copy_csv_xls_pdf.swf", //in Ace demo ../assets will be replaced by correct assets path

                                    "sRowSelector": "td:not(:last-child)",
                                    "sRowSelect": "multi",
                                    "fnRowSelected": function (row) {
                                        //check checkbox when row is selected
                                        try { $(row).find('input[type=checkbox]').get(0).checked = true }
                                        catch (e) { }
                                    },
                                    "fnRowDeselected": function (row) {
                                        //uncheck checkbox
                                        try { $(row).find('input[type=checkbox]').get(0).checked = false }
                                        catch (e) { }
                                    },

                                    "sSelectedClass": "success",
                                    "aButtons": [
                                        {
                                            "sExtends": "copy",
                                            "sToolTip": "Copiar para área de transferência",
                                            "sButtonClass": "btn btn-white btn-primary btn-bold",
                                            "sButtonText": "<i class='fa fa-copy bigger-110 pink'></i>",
                                            "fnComplete": function () {
                                                this.fnInfo('<h3 class="no-margin-top smaller">Tabela copiada</h3>\
									<p>Copiada '+ (_datatable.fnSettings().fnRecordsTotal()) + ' linha(s) para a área de transferência.</p>',
                                                    1500
                                                );
                                            },

                                        },

                                        {
                                            "sExtends": "csv",
                                            "sToolTip": "Exportar para CSV",
                                            "sButtonClass": "btn btn-white btn-primary  btn-bold",
                                            "sButtonText": "<i class='fa fa-file-excel-o bigger-110 green'></i>"
                                        },

                                        {
                                            "sExtends": "pdf",
                                            "sToolTip": "Exportar para PDF",
                                            "sButtonClass": "btn btn-white btn-primary  btn-bold",
                                            "sButtonText": "<i class='fa fa-file-pdf-o bigger-110 red'></i>"
                                        },

                                        {
                                            "sExtends": "print",
                                            "sToolTip": "Visualizar impressão",
                                            "sButtonClass": "btn btn-white btn-primary  btn-bold",
                                            "sButtonText": "<i class='fa fa-print bigger-110 grey'></i>",

                                            "sMessage": "<div class='navbar navbar-default'><div class='navbar-header pull-left'><a class='navbar-brand' href='#'><small>Visualização de impressão</small></a></div></div>",

                                            "sInfo": "<h3 class='no-margin-top'>Visualização de impressão</h3>\
									  <p>Por favor use a função de impressão do seu navegador \
									  para imprimir.\
									  <br />Pressione <b>ESC</b> para sair.</p>",
                                        }
                                    ]
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

                                //ColVis extension
                                var colvis = new $.fn.dataTable.ColVis(_datatable, {
                                    "buttonText": "<i class='fa fa-search'></i>",
                                    //"aiExclude": [0, 6],
                                    "bShowAll": true,
                                    //"bRestore": true,
                                    "sAlign": "right",
                                    "fnLabel": function (i, title, th) {
                                        return $(th).text();//remove icons, etc
                                    }
                                });

                                //style it
                                $(colvis.button()).addClass('btn-group').find('button').addClass('btn btn-white btn-info btn-bold')

                                //and append it to our table tools btn-group, also add tooltip
                                $(colvis.button())
                                .prependTo('.tableTools-container .btn-group')
                                .attr('title', 'Exibir/Ocultar colunas').tooltip({ container: 'body' });

                                //and make the list, buttons and checkboxed Ace-like
                                $(colvis.dom.collection)
                                .addClass('dropdown-menu dropdown-light dropdown-caret dropdown-caret-right')
                                .find('li').wrapInner('<a href="javascript:void(0)" />') //'A' tag is required for better styling
                                .find('input[type=checkbox]').addClass('ace').next().addClass('lbl padding-8');
                                //});
                            });
                        });
                    });
                });
            }



        },
    }
};