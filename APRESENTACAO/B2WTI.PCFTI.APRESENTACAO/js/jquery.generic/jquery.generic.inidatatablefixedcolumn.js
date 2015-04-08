

$(document).ready(function () {
    dataTablesComFixedColumnAndExport();
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
        ajax: GetURLParameter() + "/js/jquery.generic/listTripa.json",
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
        "bPaginate": true,
        "bLengthChange": true,
        "bFilter": true,
        "bSort": false,
        "bInfo": true,
        "bAutoWidth": true,
        "bStateSave": true,
        "scrollY": 300,
        "scrollX": true,
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
        },
        responsive: true
        //"sDom": 'T<"clear">lfrtip',
        //"dom": 'T<"clear">lfrtip',
        //"tableTools": {
        //    "sSwfPath": GetURLParameter() + "/js/jquery.datatables/swf/copy_csv_xls_pdf.swf"
        //}
    });

    new $.fn.dataTable.FixedColumns(table);
    new $.fn.dataTable.KeyTable(table);
}


