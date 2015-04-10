

$(document).ready(function () {

    if ($(".dataTables-example").size() > 0) {
        //dataTablesComFixedColumnAndExport();
        editorDataTableMOC();
    } else {
        return false;
    }


    iCheckBoxJquery();


});

function iCheckBoxJquery() {
    $('.i-checks').iCheck({
        checkboxClass: 'icheckbox_square-green',
        radioClass: 'iradio_square-green',
    });
}
function GetURLParameter() {
    //var pathname = window.location.pathname; // Returns path only
    var url = window.location.host;

    return url;
    //alert(pathname);
    //alert(url + "/js/jquery.generic/listTripa.txt");
};
function editDataTableElementInLine() {
    /* Init DataTables */
    var oTable = $('#editable').dataTable();

    /* Apply the jEditable handlers to the table */
    oTable.$('td').editable('../example_ajax.php', {
        "callback": function (sValue, y) {
            var aPos = oTable.fnGetPosition(this);
            oTable.fnUpdate(sValue, aPos[0], aPos[1]);
        },
        "submitdata": function (value, settings) {
            return {
                "row_id": this.parentNode.getAttribute('id'),
                "column": oTable.fnGetPosition(this)[2]
            };
        },

        "width": "90%",
        "height": "100%"
    });
}
function dataTablesComFixedColumnAndExport() {

    table = $('.dataTables-example').dataTable({
        ajax: "/js/jquery.generic/listTripa.json",
        columns: [
                { data: "FORNECEDOR" },
                { data: "NOME_FANTASIA" },
                { data: "RESPONSAVEL" },
                { data: "ANO" },
                { data: "ATIVO" },
                { data: "SERVICO" },
                { data: "TIPO_BLOCO" },
                { data: "BLOCO" },
                { data: "ALTERADO" },
                { data: "STATUS" },
                { data: "TIPO_DE_PGTO" },
                { data: "ORCADO_JANEIRO" },
                { data: "BACKLOG_JANEIRO" },
                { data: "CAIXA_JANEIRO" },
                { data: "REAL_JANEIRO" },
                { data: "ACUM_JANEIRO" },
                { data: "ORCADO_FEVEREIRO" },
                { data: "BACKLOG_FEVEREIRO" },
                { data: "CAIXA_FEVEREIRO" },
                { data: "REAL_FEVEREIRO" },
                { data: "ACUM_FEVEREIRO" },
                { data: "ORCADO_MARCO" },
                { data: "BACKLOG_MARCO" },
                { data: "CAIXA_MARCO" },
                { data: "REAL_MARCO" },
                { data: "ACUM_MARCO" },
                { data: "ORCADO_1_TRIMESTRE" },
                { data: "BACKLOG_1_TRIMESTRE" },
                { data: "CAIXA_-_1_TRIMESTRE" },
                { data: "REAL_1_TRIMESTRE" },
                { data: "ACUM_-_1_TRI" },
                { data: "ORCADO_ABRIL" },
                { data: "BACKLOG_ABRIL" },
                { data: "CAIXA_ABRIL" },
                { data: "REAL_ABRIL" },
                { data: "ACUM_ABRIL" },
                { data: "ORCADO_MAIO" },
                { data: "BACKLOG_MAIO" },
                { data: "CAIXA_MAIO" },
                { data: "REAL_MAIO" },
                { data: "ACUM_MAIO" },
                { data: "ORCADO_JUNHO" },
                { data: "BACKLOG_JUNHO" },
                { data: "CAIXA_JUNHO" },
                { data: "REAL_JUNHO" },
                { data: "ACUM_JUNHO" },
                { data: "ORCADO_2_TRIMESTRE" },
                { data: "BACKLOG_2_TRIMESTRE" },
                { data: "CAIXA_-_2_TRIMESTRE" },
                { data: "REAL_2_TRIMESTRE" },
                { data: "ACUM_-_2_TRI" },
                { data: "ORCADO_JULHO" },
                { data: "BACKLOG_JULHO" },
                { data: "CAIXA_JULHO" },
                { data: "REAL_JULHO" },
                { data: "ACUM_JULHO" },
                { data: "ORCADO_AGOSTO" },
                { data: "BACKLOG_AGOSTO" },
                { data: "CAIXA_AGOSTO" },
                { data: "REAL_AGOSTO" },
                { data: "ACUM_AGOSTO" },
                { data: "ORCADO_SETEMBRO" },
                { data: "BACKLOG_SETEMBRO" },
                { data: "CAIXA_SETEMBRO" },
                { data: "REAL_SETEMBRO" },
                { data: "ACUM_SETEMBRO" },
                { data: "ORCADO_3_TRIMESTRE" },
                { data: "BACKLOG_3_TRIMESTRE" },
                { data: "CAIXA_-_3_TRIMESTRE" },
                { data: "REAL_3_TRIMESTRE" },
                { data: "ACUM_-_3_TRI" },
                { data: "ORCADO_OUTUBRO" },
                { data: "BACKLOG_OUTUBRO" },
                { data: "CAIXA_OUTUBRO" },
                { data: "REAL_OUTUBRO" },
                { data: "ACUM_OUTUBRO" },
                { data: "ORCADO_NOVEMBRO" },
                { data: "BACKLOG_NOVEMBRO" },
                { data: "CAIXA_NOVEMBRO" },
                { data: "REAL_NOVEMBRO" },
                { data: "ACUM_NOVEMBRO" },
                { data: "ORCADO_DEZEMBRO" },
                { data: "BACKLOG_DEZEMBRO" },
                { data: "CAIXA_DEZEMBRO" },
                { data: "REAL_DEZEMBRO" },
                { data: "ACUM_DEZEMBRO" },
                { data: "ORCADO_4_TRIMESTRE" },
                { data: "BACKLOG_4_TRIMESTRE" },
                { data: "CAIXA_-_4_TRIMESTRE" },
                { data: "REAL_4_TRIMESTRE" },
                { data: "ACUM_-_4_TRI" },
                { data: "ORCADO_TOTAL" },
                { data: "BACKLOG_TOTAL" },
                { data: "CAIXA_TOTAL" },
                { data: "REAL_TOTAL" },
                { data: "ACUM_TOTAL" }
        ],
        "sDom": 'C<"clear"><"H"lfr>t<"F"ip>',
        "bPaginate": true,
        "scrollY": "400px",
        "scrollX": "auto",
        "scrollCollapse": false,
        "bFilter": true,
        "bSort": false,
        "bInfo": true,
        iDisplayStart: 20,
        "bAutoWidth": false,
        "bStateSave": false,
        "language": {
            "sEmptyTable": "Nenhum registro encontrado",
            "sInfo": "Mostrando de _START_ à _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
            "sInfoFiltered": "(Filtrados de _MAX_ registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "_MENU_ resultados por página",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "",//Próximo
                "sPrevious": "",//Anterior
                "sFirst": "Primeiro",
                "sLast": "Último"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }
        }

    });


    new $.fn.dataTable.FixedColumns(table, {
        leftColumns: 1,
        //"iLeftWidth": 400 // pixels
    });

    //new $.fn.dataTable.KeyTable(table);
}
function calculoSubTotalColumns() {

    var sums = [];

    $('.teste').each(function () {
        var rowSum = 0;
        $(this).find('.remaining-detail').each(function () {
            rowSum += parseInt($(this).html().replace('R$', ''));
        });
        sums.push(rowSum);
    });

    $('#sum2').text("Biggest sum is in row " + (1 + sums.indexOf(Math.max.apply(Math, sums))));



}
function editorDataTableMOC() {

    var editor; // use a global for the submit and return data rendering in the examples

    editor = new $.fn.dataTable.Editor({
        ajax: "/js/jquery.generic/listTripa.json",
        table: ".dataTables-example",
        fields: [
            {
                label: "FORNECEDOR", name: "FORNECEDOR"
            },
            {
                label: "NOME FANTASIA", name: "NOME_FANTASIA"
            },
            {
                label: "RESPONSAVEL", name: "RESPONSAVEL"
            },
            {
                label: "ANO", name: "ANO"
            },
            {
                label: "ATIVO", name: "ATIVO"
            },
            {
                label: "SERVICO", name: "SERVICO"
            },
            {
                label: "TIPO BLOCO", name: "TIPO_BLOCO"
            },
            {
                label: "BLOCO", name: "BLOCO"
            },
            {
                label: "ALTERADO", name: "ALTERADO"
            },
            {
                label: "STATUS", name: "STATUS"
            },
            {
                label: "TIPO DE PGTO", name: "TIPO_DE_PGTO"
            },
            {
                label: "ORCADO", name: "ORCADO_JANEIRO"
            },
            {
                label: "BACKLOG", name: "BACKLOG_JANEIRO"
            },
            {

                label: "CAIXA", name: "CAIXA_JANEIRO"
            },
            {
                label: "REAL", name: "REAL_JANEIRO"
            },
            {
                label: "ACUMULADO", name: "ACUM_JANEIRO"
            },
            {
                label: "ORCADO", name: "ORCADO_FEVEREIRO"
            },
            {
                label: "BACKLOG", name: "BACKLOG_FEVEREIRO"
            },
            {
                label: "CAIXA", name: "CAIXA_FEVEREIRO"
            },
            {
                label: "REAL", name: "REAL_FEVEREIRO"
            },
            {
                label: "ACUMULADO", name: "ACUM_FEVEREIRO"
            },
            {
                label: "ORCADO", name: "ORCADO_MARCO"
            },
            {
                label: "BACKLOG", name: "BACKLOG_MARCO"
            },
            {
                label: "CAIXA", name: "CAIXA_MARCO"
            },
            {
                label: "REAL", name: "REAL_MARCO"
            },
            {
                label: "ACUMULADO", name: "ACUM_MARCO"
            },
            {
                label: "ORCADO", name: "ORCADO_1_TRIMESTRE"
            },
            {
                label: "BACKLOG", name: "BACKLOG_1_TRIMESTRE"
            },
            {
                label: "CAIXA", name: "CAIXA_-_1_TRIMESTRE"
            },
            {
                label: "REAL", name: "REAL_1_TRIMESTRE"
            },
            {
                label: "ACUMULADO", name: "ACUM_-_1_TRI"
            },
            {
                label: "ORCADO", name: "ORCADO_ABRIL"
            },
            {
                label: "BACKLOG", name: "BACKLOG_ABRIL"
            },
            {
                label: "CAIXA", name: "CAIXA_ABRIL"
            },
            {
                label: "REAL", name: "REAL_ABRIL"
            },
            {
                label: "ACUMULADO", name: "ACUM_ABRIL"
            },
            {
                label: "ORCADO", name: "ORCADO_MAIO"
            },
            {
                label: "BACKLOG", name: "BACKLOG_MAIO"
            },
            {
                label: "CAIXA", name: "CAIXA_MAIO"
            },
            {
                label: "REAL", name: "REAL_MAIO"
            },
            {
                label: "ACUMULADO", name: "ACUM_MAIO"
            },
            {
                label: "ORCADO", name: "ORCADO_JUNHO"
            },
            {
                label: "BACKLOG", name: "BACKLOG_JUNHO"
            },
            {
                label: "CAIXA", name: "CAIXA_JUNHO"
            },
            {
                label: "REAL", name: "REAL_JUNHO"
            },
            {
                label: "ACUMULADO", name: "ACUM_JUNHO"
            },
            {
                label: "ORCADO", name: "ORCADO_2_TRIMESTRE"
            },
            {
                label: "BACKLOG", name: "BACKLOG_2_TRIMESTRE"
            },
            {
                label: "CAIXA", name: "CAIXA_-_2_TRIMESTRE"
            },
            {
                label: "REAL", name: "REAL_2_TRIMESTRE"
            },
            {
                label: "ACUMULADO", name: "ACUM_-_2_TRI"
            },
            {
                label: "ORCADO", name: "ORCADO_JULHO"
            },
            {
                label: "BACKLOG", name: "BACKLOG_JULHO"
            },
            {
                label: "CAIXA", name: "CAIXA_JULHO"
            },
            {
                label: "REAL", name: "REAL_JULHO"
            },
            {
                label: "ACUMULADO", name: "ACUM_JULHO"
            },
            {
                label: "ORCADO", name: "ORCADO_AGOSTO"
            },
            {
                label: "BACKLOG", name: "BACKLOG_AGOSTO"
            },
            {
                label: "CAIXA", name: "CAIXA_AGOSTO"
            },
            {
                label: "REAL", name: "REAL_AGOSTO"
            },
            {
                label: "ACUMULADO", name: "ACUM_AGOSTO"
            },
            {
                label: "ORCADO", name: "ORCADO_SETEMBRO"
            },
            {
                label: "BACKLOG", name: "BACKLOG_SETEMBRO"
            },
            {
                label: "CAIXA", name: "CAIXA_SETEMBRO"
            },
            {
                label: "REAL", name: "REAL_SETEMBRO"
            },
            {
                label: "ACUMULADO", name: "ACUM_SETEMBRO"
            },
            {
                label: "ORCADO", name: "ORCADO_3_TRIMESTRE"
            },
            {
                label: "BACKLOG", name: "BACKLOG_3_TRIMESTRE"
            },
            {
                label: "CAIXA", name: "CAIXA_-_3_TRIMESTRE"
            },
            {
                label: "REAL", name: "REAL_3_TRIMESTRE"
            },
            {
                label: "ACUMULADO", name: "ACUM_-_3_TRI"
            },
            {
                label: "ORCADO", name: "ORCADO_OUTUBRO"
            },
            {
                label: "BACKLOG", name: "BACKLOG_OUTUBRO"
            },
            {
                label: "CAIXA", name: "CAIXA_OUTUBRO"
            },
            {
                label: "REAL", name: "REAL_OUTUBRO"
            },
            {
                label: "ACUMULADO", name: "ACUM_OUTUBRO"
            },
            {
                label: "ORCADO", name: "ORCADO_NOVEMBRO"
            },
            {
                label: "BACKLOG", name: "BACKLOG_NOVEMBRO"
            },
            {
                label: "CAIXA", name: "CAIXA_NOVEMBRO"
            },
            {
                label: "REAL", name: "REAL_NOVEMBRO"
            },
            {
                label: "ACUMULADO", name: "ACUM_NOVEMBRO"
            },
            {
                label: "ORCADO", name: "ORCADO_DEZEMBRO"
            },
            {
                label: "BACKLOG", name: "BACKLOG_DEZEMBRO"
            },
            {
                label: "CAIXA", name: "CAIXA_DEZEMBRO"
            },
            {
                label: "REAL", name: "REAL_DEZEMBRO"
            },
            {
                label: "ACUMULADO", name: "ACUM_DEZEMBRO"
            },
            {
                label: "ORCADO", name: "ORCADO_4_TRIMESTRE"
            },
            {
                label: "BACKLOG", name: "BACKLOG_4_TRIMESTRE"
            },
            {
                label: "CAIXA", name: "CAIXA_-_4_TRIMESTRE"
            },
            {
                label: "REAL", name: "REAL_4_TRIMESTRE"
            },
            {
                label: "ACUMULADO", name: "ACUM_-_4_TRI"
            },
            {
                label: "ORCADO", name: "ORCADO_TOTAL"
            },
            {
                label: "BACKLOG", name: "BACKLOG_TOTAL"
            },
            {
                label: "CAIXA", name: "CAIXA_TOTAL"
            },
            {
                label: "REAL", name: "REAL_TOTAL"
            },
            {
                label: "ACUMULADO", name: "ACUM_TOTAL"
            }
        ]
    });

    editor
        .on('open', function (e, type) {
            if (type === 'inline') {
                // Listen for a tab key event when inline editing
                $(document).on('keydown.editor', function (e) {
                    if (e.keyCode === 13 || e.keyCode === 9 || e.keyCode === 37 || e.keyCode === 39) {
                        e.preventDefault();

                        // Find the cell that is currently being edited
                        var cell = $('div.DTE').parent();

                        if (e.shiftKey && cell.prev().length && cell.prev().index() !== 0) {
                            // One cell to the left (skipping the first column)
                            cell.prev().click();
                        }
                        else if (e.shiftKey) {
                            // Up to the previous row
                            cell.parent().prev().children().last(0).click();
                        }
                        else if (cell.next().length) {
                            // One cell to the right
                            cell.next().click();
                        }
                        else {
                            // Down to the next row
                            cell.parent().next().children().eq(1).click();
                        }
                    }
                });
            }
        })
        .on('close', function () {
            $(document).off('keydown.editor');
        });

    $('.dataTables-example').on('click', 'tbody td:not(:first-child)', function (e) {
        editor.inline(this, {
            submitOnBlur: true
        });
    });



    $('.dataTables-example').DataTable({
        ajax: "/js/jquery.generic/listTripa.json",
        columns: [
                { data: "FORNECEDOR" },
                { data: "NOME_FANTASIA" },
                { data: "RESPONSAVEL" },
                { data: "ANO" },
                { data: "ATIVO" },
                { data: "SERVICO" },
                { data: "TIPO_BLOCO" },
                { data: "BLOCO" },
                { data: "ALTERADO" },
                { data: "STATUS" },
                { data: "TIPO_DE_PGTO" },
                { data: "ORCADO_JANEIRO" },
                { data: "BACKLOG_JANEIRO" },
                { data: "CAIXA_JANEIRO" },
                { data: "REAL_JANEIRO" },
                { data: "ACUM_JANEIRO" },
                { data: "ORCADO_FEVEREIRO" },
                { data: "BACKLOG_FEVEREIRO" },
                { data: "CAIXA_FEVEREIRO" },
                { data: "REAL_FEVEREIRO" },
                { data: "ACUM_FEVEREIRO" },
                { data: "ORCADO_MARCO" },
                { data: "BACKLOG_MARCO" },
                { data: "CAIXA_MARCO" },
                { data: "REAL_MARCO" },
                { data: "ACUM_MARCO" },
                { data: "ORCADO_1_TRIMESTRE" },
                { data: "BACKLOG_1_TRIMESTRE" },
                { data: "CAIXA_-_1_TRIMESTRE" },
                { data: "REAL_1_TRIMESTRE" },
                { data: "ACUM_-_1_TRI" },
                { data: "ORCADO_ABRIL" },
                { data: "BACKLOG_ABRIL" },
                { data: "CAIXA_ABRIL" },
                { data: "REAL_ABRIL" },
                { data: "ACUM_ABRIL" },
                { data: "ORCADO_MAIO" },
                { data: "BACKLOG_MAIO" },
                { data: "CAIXA_MAIO" },
                { data: "REAL_MAIO" },
                { data: "ACUM_MAIO" },
                { data: "ORCADO_JUNHO" },
                { data: "BACKLOG_JUNHO" },
                { data: "CAIXA_JUNHO" },
                { data: "REAL_JUNHO" },
                { data: "ACUM_JUNHO" },
                { data: "ORCADO_2_TRIMESTRE" },
                { data: "BACKLOG_2_TRIMESTRE" },
                { data: "CAIXA_-_2_TRIMESTRE" },
                { data: "REAL_2_TRIMESTRE" },
                { data: "ACUM_-_2_TRI" },
                { data: "ORCADO_JULHO" },
                { data: "BACKLOG_JULHO" },
                { data: "CAIXA_JULHO" },
                { data: "REAL_JULHO" },
                { data: "ACUM_JULHO" },
                { data: "ORCADO_AGOSTO" },
                { data: "BACKLOG_AGOSTO" },
                { data: "CAIXA_AGOSTO" },
                { data: "REAL_AGOSTO" },
                { data: "ACUM_AGOSTO" },
                { data: "ORCADO_SETEMBRO" },
                { data: "BACKLOG_SETEMBRO" },
                { data: "CAIXA_SETEMBRO" },
                { data: "REAL_SETEMBRO" },
                { data: "ACUM_SETEMBRO" },
                { data: "ORCADO_3_TRIMESTRE" },
                { data: "BACKLOG_3_TRIMESTRE" },
                { data: "CAIXA_-_3_TRIMESTRE" },
                { data: "REAL_3_TRIMESTRE" },
                { data: "ACUM_-_3_TRI" },
                { data: "ORCADO_OUTUBRO" },
                { data: "BACKLOG_OUTUBRO" },
                { data: "CAIXA_OUTUBRO" },
                { data: "REAL_OUTUBRO" },
                { data: "ACUM_OUTUBRO" },
                { data: "ORCADO_NOVEMBRO" },
                { data: "BACKLOG_NOVEMBRO" },
                { data: "CAIXA_NOVEMBRO" },
                { data: "REAL_NOVEMBRO" },
                { data: "ACUM_NOVEMBRO" },
                { data: "ORCADO_DEZEMBRO" },
                { data: "BACKLOG_DEZEMBRO" },
                { data: "CAIXA_DEZEMBRO" },
                { data: "REAL_DEZEMBRO" },
                { data: "ACUM_DEZEMBRO" },
                { data: "ORCADO_4_TRIMESTRE" },
                { data: "BACKLOG_4_TRIMESTRE" },
                { data: "CAIXA_-_4_TRIMESTRE" },
                { data: "REAL_4_TRIMESTRE" },
                { data: "ACUM_-_4_TRI" },
                { data: "ORCADO_TOTAL" },
                { data: "BACKLOG_TOTAL" },
                { data: "CAIXA_TOTAL" },
                { data: "REAL_TOTAL" },
                { data: "ACUM_TOTAL" }
        ],
        "sDom": 'C<"clear"><"H"lfr>t<"F"ip>',
        "bPaginate": true,
        "scrollY": "400px",
        "scrollX": "auto",
        "scrollCollapse": false,
        "bFilter": true,
        "bSort": false,
        "bInfo": true,
        iDisplayStart: 20,
        "bAutoWidth": false,
        "bStateSave": false,
        "language": {
            "sEmptyTable": "Nenhum registro encontrado",
            "sInfo": "Mostrando de _START_ à _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
            "sInfoFiltered": "(Filtrados de _MAX_ registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "_MENU_ resultados por página",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "", //Próximo
                "sPrevious": "", //Anterior
                "sFirst": "Primeiro",
                "sLast": "Último"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }
        }
    });

    //new $.fn.dataTable.FixedColumns(table, {
    //    leftColumns: 1,
    //    //"iLeftWidth": 400 // pixels
    //});





}







