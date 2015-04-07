

$(document).ready(function () {
    dataTablesComFixedColumnAndExport();
});

function GetURLParameter() {
    //var pathname = window.location.pathname; // Returns path only
    var url = window.location.host;

    return url + "/js/jquery.generic/listTripa.txt";
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
       
        "sAjaxSource": GetURLParameter() + "/js/jquery.generic/listTripa.json",
        "sAjaxDataProp": "",
        "bProcessing": true,
        "aoColumns": [
                { "mData": "FORNECEDOR" },
                { "mData": "NOME_FANTASIA" },
                { "mData": "RESPONSAVEL" },
                { "mData": "ANO" },
                { "mData": "ATIVO" },
                { "mData": "SERVICO" },
                { "mData": "TIPO_BLOCO" },
                { "mData": "BLOCO" },
                { "mData": "ALTERADO" },
                { "mData": "STATUS" },
                { "mData": "TIPO_DE_PGTO" },
                { "mData": "ORCADO_JANEIRO" },
                { "mData": "BACKLOG_JANEIRO" },
                { "mData": "CAIXA_JANEIRO" },
                { "mData": "REAL_JANEIRO" },
                { "mData": "ACUM_JANEIRO" },
                { "mData": "ORCADO_FEVEREIRO" },
                { "mData": "BACKLOG_FEVEREIRO" },
                { "mData": "CAIXA_FEVEREIRO" },
                { "mData": "REAL_FEVEREIRO" },
                { "mData": "ACUM_FEVEREIRO" },
                { "mData": "ORCADO_MARCO" },
                { "mData": "BACKLOG_MARCO" },
                { "mData": "CAIXA_MARCO" },
                { "mData": "REAL_MARCO" },
                { "mData": "ACUM_MARCO" },
                { "mData": "ORCADO_1_TRIMESTRE" },
                { "mData": "BACKLOG_1_TRIMESTRE" },
                { "mData": "CAIXA_-_1_TRIMESTRE" },
                { "mData": "REAL_1_TRIMESTRE" },
                { "mData": "ACUM_-_1_TRI" },
                { "mData": "ORCADO_ABRIL" },
                { "mData": "BACKLOG_ABRIL" },
                { "mData": "CAIXA_ABRIL" },
                { "mData": "REAL_ABRIL" },
                { "mData": "ACUM_ABRIL" },
                { "mData": "ORCADO_MAIO" },
                { "mData": "BACKLOG_MAIO" },
                { "mData": "CAIXA_MAIO" },
                { "mData": "REAL_MAIO" },
                { "mData": "ACUM_MAIO" },
                { "mData": "ORCADO_JUNHO" },
                { "mData": "BACKLOG_JUNHO" },
                { "mData": "CAIXA_JUNHO" },
                { "mData": "REAL_JUNHO" },
                { "mData": "ACUM_JUNHO" },
                { "mData": "ORCADO_2_TRIMESTRE" },
                { "mData": "BACKLOG_2_TRIMESTRE" },
                { "mData": "CAIXA_-_2_TRIMESTRE" },
                { "mData": "REAL_2_TRIMESTRE" },
                { "mData": "ACUM_-_2_TRI" },
                { "mData": "ORCADO_JULHO" },
                { "mData": "BACKLOG_JULHO" },
                { "mData": "CAIXA_JULHO" },
                { "mData": "REAL_JULHO" },
                { "mData": "ACUM_JULHO" },
                { "mData": "ORCADO_AGOSTO" },
                { "mData": "BACKLOG_AGOSTO" },
                { "mData": "CAIXA_AGOSTO" },
                { "mData": "REAL_AGOSTO" },
                { "mData": "ACUM_AGOSTO" },
                { "mData": "ORCADO_SETEMBRO" },
                { "mData": "BACKLOG_SETEMBRO" },
                { "mData": "CAIXA_SETEMBRO" },
                { "mData": "REAL_SETEMBRO" },
                { "mData": "ACUM_SETEMBRO" },
                { "mData": "ORCADO_3_TRIMESTRE" },
                { "mData": "BACKLOG_3_TRIMESTRE" },
                { "mData": "CAIXA_-_3_TRIMESTRE" },
                { "mData": "REAL_3_TRIMESTRE" },
                { "mData": "ACUM_-_3_TRI" },
                { "mData": "ORCADO_OUTUBRO" },
                { "mData": "BACKLOG_OUTUBRO" },
                { "mData": "CAIXA_OUTUBRO" },
                { "mData": "REAL_OUTUBRO" },
                { "mData": "ACUM_OUTUBRO" },
                { "mData": "ORCADO_NOVEMBRO" },
                { "mData": "BACKLOG_NOVEMBRO" },
                { "mData": "CAIXA_NOVEMBRO" },
                { "mData": "REAL_NOVEMBRO" },
                { "mData": "ACUM_NOVEMBRO" },
                { "mData": "ORCADO_DEZEMBRO" },
                { "mData": "BACKLOG_DEZEMBRO" },
                { "mData": "CAIXA_DEZEMBRO" },
                { "mData": "REAL_DEZEMBRO" },
                { "mData": "ACUM_DEZEMBRO" },
                { "mData": "ORCADO_4_TRIMESTRE" },
                { "mData": "BACKLOG_4_TRIMESTRE" },
                { "mData": "CAIXA_-_4_TRIMESTRE" },
                { "mData": "REAL_4_TRIMESTRE" },
                { "mData": "ACUM_-_4_TRI" },
                { "mData": "ORCADO_TOTAL" },
                { "mData": "BACKLOG_TOTAL" },
                { "mData": "CAIXA_TOTAL" },
                { "mData": "REAL_TOTAL" },
                { "mData": "ACUM_TOTAL" }
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
}


