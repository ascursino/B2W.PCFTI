

$(document).ready(function () {

    dataTablesComFixedColumnAndExport();

});

function GetURLParameter() {
    //var pathname = window.location.pathname; // Returns path only
    var url = window.location.host;

    return url;
    //alert(pathname);
    //alert(url);
};

function editDataTableElementInLine () {
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
                "sNext": "Próximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Último"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }
        },
        responsive: true,
        //"sDom": 'T<"clear">lfrtip',
        //"dom": 'T<"clear">lfrtip',
        //"tableTools": {
        //    "sSwfPath": "../js/jquery.datatables/swf/copy_csv_xls_pdf.swf"
        //}
    });

    new $.fn.dataTable.FixedColumns(table);
}