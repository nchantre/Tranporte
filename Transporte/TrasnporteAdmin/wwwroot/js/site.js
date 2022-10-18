$(document).ready(function () {
  loadDataTables();
  //MENU
  $('img.svg').each(function () {
    var $img = jQuery(this);
    var imgID = $img.attr('id');
    var imgClass = $img.attr('class');
    var imgURL = $img.attr('src');

    jQuery.get(imgURL, function (data) {
      // Get the SVG tag, ignore the rest
      var $svg = jQuery(data).find('svg');

      // Add replaced image's ID to the new SVG
      if (typeof imgID !== 'undefined') {
        $svg = $svg.attr('id', imgID);
      }
      // Add replaced image's classes to the new SVG
      if (typeof imgClass !== 'undefined') {
        $svg = $svg.attr('class', imgClass + ' replaced-svg');
      }

      // Remove any invalid XML tags as per http://validator.w3.org
      $svg = $svg.removeAttr('xmlns:a');

      // Replace image with new SVG
      $img.replaceWith($svg);

    }, 'xml');

  });

  var menu = $('.menu-principal');

  menu.mouseover(function () {
    menu.removeClass('menu-principal-cerrado');

    $('.item-menu-principal-titulo').css({
      'visibility': 'visible',
      'opacity': '1',
      'padding-left': '0.5em'
    })

  })
    .mouseleave(function () {
      menu.addClass('menu-principal-cerrado')

      $('.item-menu-principal-titulo').css({
        'visibility': 'hidden',
        'opacity': '0',
        'padding-left': '0'
      })

    });

  //middle
  menuDisplay('#drawer-seguridad', '#drawer-seguridad-sm1');
  menuDisplay('#seguridad-logs-sm1', '#seguridad-logs-sm2');
  menuDisplay('#drawer-parametrizar', '#drawer-parametrizar-sm1');
  menuDisplay('#drawer-consultas', '#drawer-consultas-sm1');
  menuDisplay('#drawer-operaciones', '#drawer-operaciones-sm1');
  menuDisplay('#operaciones-descarga-sm1', '#operaciones-descarga-sm2');
  menuDisplay('#drawer-tarjetaRecaudo', '#drawer-tarjetaRecaudo-sm1');


  //front
  menuDisplay('#header-menu-btn', '#header-menu-list');
  menuDisplay('#header-menu-noti-btn', '#header-menu-noti-list');
  menuDisplay('#drawer-consultas', '#drawer-consultas-sm1');
  menuDisplay('#movimientos-sm1', '#movimientos-sm2');
  menuDisplay('#certificaciones-sm1', '#certificaciones-sm2');
  menuDisplay('#drawer-transacciones', '#drawer-transacciones-sm');



  $(document).mouseup(function (e) {
    var container = $("nav, #btn-menu");

    if (!container.is(e.target) && container.has(e.target).length === 0) {
      $('nav').css("left", "-100%");
    }
  });
  $(document).on('hidden.bs.modal', function () {
    if ($('.modal.fade.in').length) {
      $('body').addClass('modal-open');
    }
    else if ($('.modal.fade').length) {
      $('body').removeClass('modal-open');
    }
  });


  //CHECK BOX IN SELECT
  $('.opcion-menu').fSelect({
    placeholder: 'Seleccione una o más opciones',
    numDisplayed: 2,
    overflowText: '{n} seleccionados',
    noResultsText: 'No se encontraron resultados',
    searchText: 'Buscar',
    showSearch: true,
    showSelectAll: true
  });


});

//DATATABLE
function loadDataTables() {
  $('#adminProfile').DataTable({
    "paging": true,
    "pageLength": 10,
    "ordering": false,
    "info": false,
    "bLengthChange": false,
    "searching": true,
    "autoWidth": true,
    columnDefs: [
      {
        targets: '_all',
        width: "180px"
      }
    ],
    "language": {
      search: "_INPUT_",
      searchPlaceholder: "Buscar en tabla",
      "lengthMenu": "Mostrar _MENU_ contenidos por página",
      "zeroRecords": "No se encontraron resultados",
      "info": "Página _PAGE_ de _PAGES_",
      "infoEmpty": "No hay información disponible",
      "infoFiltered": "(Se filtraron _MAX_ total de contenidos)",
      "paginate": {
        "first": "Primero",
        "last": "Último",
        "next": "Siguiente",
        "previous": "Anterior"
      }
    },
    "sDom": 'l<"toolbar">fr<"datatable-scroll"t>ip'
  })
  $('.clientesInversionistas').DataTable({
    "paging": true,
    "pageLength": 10,
    "ordering": false,
    "info": false,
    "bLengthChange": false,
    "searching": true,
    "autoWidth": true,
    columnDefs: [
      {
        targets: '_all',
        width: "180px"
      }
    ],
    "language": {
      search: "_INPUT_",
      searchPlaceholder: "Buscar en tabla",
      "lengthMenu": "Mostrar _MENU_ contenidos por página",
      "zeroRecords": "No se encontraron resultados",
      "info": "Página _PAGE_ de _PAGES_",
      "infoEmpty": "No hay información disponible",
      "infoFiltered": "(Se filtraron _MAX_ total de contenidos)",
      "paginate": {
        "first": "Primero",
        "last": "Último",
        "next": "Siguiente",
        "previous": "Anterior"
      }
    },
    "sDom": 'l<"toolbar">fr<"datatable-scroll"t>ip'
  })

  $('#gestionarUsuario').DataTable({
    "paging": true,
    "pageLength": 10,
    "ordering": false,
    "info": true,
    "bLengthChange": false,
    "searching": true,
    columnDefs: [
      {
        targets: '_all',
        width: "180px"
      }
    ],
    "language": {
      search: "_INPUT_",
      searchPlaceholder: "Buscar en tabla",
      "lengthMenu": "Mostrar _MENU_ contenidos por página",
      "zeroRecords": "No se encontraron resultados",
      "info": "Página _PAGE_ de _PAGES_",
      "infoEmpty": "No hay información disponible",
      "infoFiltered": "(Se filtraron _MAX_ total de contenidos)",
      "paginate": {
        "first": "Primero",
        "last": "Último",
        "next": "Siguiente",
        "previous": "Anterior"
      }
    },
    "sDom": 'l<"toolbar">fr<"datatable-scroll"t>ip',
  }).columns.adjust().draw();

  $("#logEventos").dataTable().fnDestroy();
  $('#logEventos').DataTable({
    "paging": true,
    "pageLength": 10,
    "ordering": false,
    "sDom": 'r<"H"lf><"datatable-scroll"t><"F"ip>',
    "info": false,
    "bLengthChange": false,
    "searching": false,
    "autoWidth": true,
    columnDefs: [
      {
        targets: '_all',
        width: "180px"
      }
    ],
    "language": {
      search: "_INPUT_",
      searchPlaceholder: "Buscar en tabla",
      "lengthMenu": "Mostrar _MENU_ contenidos por página",
      "zeroRecords": "No se encontraron resultados",
      "info": "Página _PAGE_ de _PAGES_",
      "infoEmpty": "No hay información disponible",
      "infoFiltered": "(Se filtraron _MAX_ total de contenidos)",
      "paginate": {
        "first": "Primero",
        "last": "Último",
        "next": "Siguiente",
        "previous": "Anterior"
      }
    }
  }).columns.adjust().draw();

  $('#logs').DataTable({
    "paging": true,
    "pageLength": 10,
    "ordering": false,
    "sDom": 'r<"H"lf><"datatable-scroll"t><"F"ip>',
    "info": false,
    "bLengthChange": false,
    "searching": false,
    "language": {
      search: "_INPUT_",
      searchPlaceholder: "Buscar en tabla",
      "lengthMenu": "Mostrar _MENU_ contenidos por página",
      "zeroRecords": "No se encontraron resultados",
      "info": "Página _PAGE_ de _PAGES_",
      "infoEmpty": "No hay información disponible",
      "infoFiltered": "(Se filtraron _MAX_ total de contenidos)",
      "paginate": {
        "first": "Primero",
        "last": "Último",
        "next": "Siguiente",
        "previous": "Anterior"
      }
    }
  }).columns.adjust().draw();

  $("#LogsDavicash").dataTable().fnDestroy();
  $('#LogsDavicash').DataTable({
    "paging": true,
    "pageLength": 10,
    "ordering": false,
    "sDom": 'r<"H"lf><"datatable-scroll"t><"F"ip>',
    "info": false,
    "bLengthChange": false,
    "searching": false,
    "language": {
      search: "_INPUT_",
      searchPlaceholder: "Buscar en tabla",
      "lengthMenu": "Mostrar _MENU_ contenidos por página",
      "zeroRecords": "No se encontraron resultados",
      "info": "Página _PAGE_ de _PAGES_",
      "infoEmpty": "No hay información disponible",
      "infoFiltered": "(Se filtraron _MAX_ total de contenidos)",
      "paginate": {
        "first": "Primero",
        "last": "Último",
        "next": "Siguiente",
        "previous": "Anterior"
      }
    }
  }).columns.adjust().draw();

  $("#LogsError").dataTable().fnDestroy();
  $('#LogsError').DataTable({
    "paging": true,
    "pageLength": 10,
    "ordering": false,
    "sDom": 'r<"H"lf><"datatable-scroll"t><"F"ip>',
    "info": false,
    "bLengthChange": false,
    "searching": false,
    "language": {
      search: "_INPUT_",
      searchPlaceholder: "Buscar en tabla",
      "lengthMenu": "Mostrar _MENU_ contenidos por página",
      "zeroRecords": "No se encontraron resultados",
      "info": "Página _PAGE_ de _PAGES_",
      "infoEmpty": "No hay información disponible",
      "infoFiltered": "(Se filtraron _MAX_ total de contenidos)",
      "paginate": {
        "first": "Primero",
        "last": "Último",
        "next": "Siguiente",
        "previous": "Anterior"
      }
    }
  }).columns.adjust().draw();

  $("#LogsReceip").dataTable().fnDestroy();
  $('#LogsReceip').DataTable({
    "paging": true,
    "pageLength": 10,
    "ordering": false,
    "sDom": 'r<"H"lf><"datatable-scroll"t><"F"ip>',
    "info": false,
    "bLengthChange": false,
    "searching": false,
    "language": {
      search: "_INPUT_",
      searchPlaceholder: "Buscar en tabla",
      "lengthMenu": "Mostrar _MENU_ contenidos por página",
      "zeroRecords": "No se encontraron resultados",
      "info": "Página _PAGE_ de _PAGES_",
      "infoEmpty": "No hay información disponible",
      "infoFiltered": "(Se filtraron _MAX_ total de contenidos)",
      "paginate": {
        "first": "Primero",
        "last": "Último",
        "next": "Siguiente",
        "previous": "Anterior"
      }
    }
  }).columns.adjust().draw();

  $('#empresas').DataTable({
    "paging": true,
    "pageLength": 10,
    "ordering": false,
    "sDom": 'r<"H"lf><"datatable-scroll"t><"F"ip>',
    "info": false,
    "bLengthChange": false,
    "searching": false,
    "language": {
      search: "_INPUT_",
      searchPlaceholder: "Buscar en tabla",
      "lengthMenu": "Mostrar _MENU_ contenidos por página",
      "zeroRecords": "No se encontraron resultados",
      "info": "Página _PAGE_ de _PAGES_",
      "infoEmpty": "No hay información disponible",
      "infoFiltered": "(Se filtraron _MAX_ total de contenidos)",
      "paginate": {
        "first": "Primero",
        "last": "Último",
        "next": "Siguiente",
        "previous": "Anterior"
      }
    }
  }).columns.adjust().draw();

  $('#bancosCanales').DataTable({
    "sScrollX": false,
    "paging": true,
    "pageLength": 10,
    "ordering": false,
    "info": true,
    "bLengthChange": false,
    "searching": true,
    "language": {
      search: "_INPUT_",
      searchPlaceholder: "Buscar en tabla",
      "lengthMenu": "Mostrar _MENU_ contenidos por página",
      "zeroRecords": "No se encontraron resultados",
      "info": "Página _PAGE_ de _PAGES_",
      "infoEmpty": "No hay información disponible",
      "infoFiltered": "(Se filtraron _MAX_ total de contenidos)",
      "paginate": {
        "first": "Primero",
        "last": "Último",
        "next": "Siguiente",
        "previous": "Anterior"
      }
    },
    dom: 'lfr<"datatable-scroll"t>ip',
  }).columns.adjust().draw();

  $('#documentos').DataTable({
    "paging": true,
    "pageLength": 10,
    "ordering": false,
    "info": false,
    "bLengthChange": false,
    "searching": true,
    "language": {
      search: "_INPUT_",
      searchPlaceholder: "Buscar en tabla",
      "lengthMenu": "Mostrar _MENU_ contenidos por página",
      "zeroRecords": "No se encontraron resultados",
      "info": "Página _PAGE_ de _PAGES_",
      "infoEmpty": "No hay información disponible",
      "infoFiltered": "(Se filtraron _MAX_ total de contenidos)",
      "paginate": {
        "first": "Primero",
        "last": "Último",
        "next": "Siguiente",
        "previous": "Anterior"
      }
    },
    dom: 'lfr<"datatable-scroll"t>ip',
  }).columns.adjust().draw();

  $('#emailTarjetas').DataTable({
    "paging": true,
    "pageLength": 10,
    "ordering": false,
    "info": false,
    "bLengthChange": false,
    "searching": false,
    "language": {
      search: "_INPUT_",
      searchPlaceholder: "Buscar en tabla",
      "lengthMenu": "Mostrar _MENU_ contenidos por página",
      "zeroRecords": "No se encontraron resultados",
      "info": "Página _PAGE_ de _PAGES_",
      "infoEmpty": "No hay información disponible",
      "infoFiltered": "(Se filtraron _MAX_ total de contenidos)",
      "paginate": {
        "first": "Primero",
        "last": "Último",
        "next": "Siguiente",
        "previous": "Anterior"
      }
    },
    dom: 'lfr<"datatable-scroll"t>ip',
  }).columns.adjust().draw();

  $('#formasPago').DataTable({
    "paging": true,
    "pageLength": 10,
    "ordering": false,
    "info": false,
    "bLengthChange": false,
    "searching": true,
    "language": {
      search: "_INPUT_",
      searchPlaceholder: "Buscar en tabla",
      "lengthMenu": "Mostrar _MENU_ contenidos por página",
      "zeroRecords": "No se encontraron resultados",
      "info": "Página _PAGE_ de _PAGES_",
      "infoEmpty": "No hay información disponible",
      "infoFiltered": "(Se filtraron _MAX_ total de contenidos)",
      "paginate": {
        "first": "Primero",
        "last": "Último",
        "next": "Siguiente",
        "previous": "Anterior"
      }
    },
    dom: 'l<"toolbar">fr<"datatable-scroll"t>ip',
  }).columns.adjust().draw();

  $('#diasFestivos').DataTable({
    "paging": true,
    "pageLength": 10,
    "ordering": false,
    "info": false,
    "bLengthChange": false,
    "searching": true,
    "language": {
      search: "_INPUT_",
      searchPlaceholder: "Buscar en tabla",
      "lengthMenu": "Mostrar _MENU_ contenidos por página",
      "zeroRecords": "No se encontraron resultados",
      "info": "Página _PAGE_ de _PAGES_",
      "infoEmpty": "No hay información disponible",
      "infoFiltered": "(Se filtraron _MAX_ total de contenidos)",
      "paginate": {
        "first": "Primero",
        "last": "Último",
        "next": "Siguiente",
        "previous": "Anterior"
      }
    },
    dom: 'lfr<"datatable-scroll"t>ip',
  }).columns.adjust().draw();

  $('#inconsisteciasRecibos').DataTable({
    "paging": true,
    "pageLength": 10,
    "ordering": false,
    "info": false,
    "bLengthChange": false,
    "searching": true,
    "sDom": 'rlf<"datatable-scroll"t>ip',
    "language": {
      search: "_INPUT_",
      searchPlaceholder: "Buscar en tabla",
      "lengthMenu": "Mostrar _MENU_ contenidos por página",
      "zeroRecords": "No se encontraron resultados",
      "info": "Página _PAGE_ de _PAGES_",
      "infoEmpty": "No hay información disponible",
      "infoFiltered": "(Se filtraron _MAX_ total de contenidos)",
      "paginate": {
        "first": "Primero",
        "last": "Último",
        "next": "Siguiente",
        "previous": "Anterior"
      }
    }
  }).columns.adjust().draw();


  tablaMenu = $('#consignantes').DataTable({
    "paging": true,
    "pageLength": 10,
    "ordering": false,
    "searching": true,
    "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
    "language": {
      search: "_INPUT_",
      searchPlaceholder: "Buscar en tabla",
      "lengthMenu": "Mostrar _MENU_ contenidos por página",
      "zeroRecords": "No se encontraron resultados",
      "info": "Página _PAGE_ de _PAGES_",
      "infoEmpty": "No hay información disponible",
      "infoFiltered": "(Se filtraron _MAX_ total de contenidos)",
      "paginate": {
        "first": "Primero",
        "last": "Último",
        "next": "Siguiente",
        "previous": "Anterior"
      }
    },
    dom: 'lf<"tabla-menu__contenedor">r<"datatable-scroll"t>ip',
    initComplete: function () {
      $("div.tabla-menu__contenedor")
        .html('<div class="tabla-menu ocultar-menu boton-icono"´>' +
          '<span class="tooltiptext2">Ocultar columnas</span><img class="tabla-menu-icono" src="/images/icon/icon-Menu.svg" alt="Filtrar" />' +
          '<ul id="">' +
          '<li><label class="check-normal toggle-vis" data-column="0">Convenio<input type="checkbox"><span class="checkmark"></span></label></li>' +
          '<li><label class="check-normal toggle-vis" data-column="1">Tipo de consignante<input type="checkbox"><span class="checkmark"></span></label></li>' +
          '<li><label class="check-normal toggle-vis" data-column="2">Tipo de documento<input type="checkbox"><span class="checkmark"></span></label></li>' +
          '<li><label class="check-normal toggle-vis" data-column="3">Número de identificación<input type="checkbox"><span class="checkmark"></span></label></li>' +
          '<li><label class="check-normal toggle-vis" data-column="4">Número de concepto<input type="checkbox"><span class="checkmark"></span></label></li>' +
          '<li><label class="check-normal toggle-vis" data-column="5">Número de referencia 2<input type="checkbox"><span class="checkmark"></span></label></li>' +
          '<li><label class="check-normal toggle-vis" data-column="6">Nombre del consignante<input type="checkbox"><span class="checkmark"></span></label></li>' +
          '<li><label class="check-normal toggle-vis" data-column="7">Correo<input type="checkbox"><span class="checkmark"></span></label></li>' +
          '<li><label class="check-normal toggle-vis" data-column="8">Estado<input type="checkbox"><span class="checkmark"></span></label></li>' +
          '<li><label class="check-normal toggle-vis" data-column="9">Estado Sarlaft<input type="checkbox"><span class="checkmark"></span></label></li>' +
          '<li><label class="check-normal toggle-vis" data-column="10">Fecha Verificacion Sarlaft<input type="checkbox"><span class="checkmark"></span></label></li>' +
          '<li><label class="check-normal toggle-vis" data-column="11">Modo factura<input type="checkbox"><span class="checkmark"></span></label></li>' +
          '<li><label class="check-normal toggle-vis" data-column="12">Modo recibo<input type="checkbox"><span class="checkmark"></span></label></li>' +
          '<li><label class="check-normal toggle-vis" data-column="13">Modo tarjeta<input type="checkbox"><span class="checkmark"></span></label></li>' +
          '<li><label class="check-normal toggle-vis" data-column="14">Cantidad Tarjetas<input type="checkbox"><span class="checkmark"></span></label></li>' +
          '<li><label class="check-normal toggle-vis" data-column="15">Fecha PagoPSE<input type="checkbox"><span class="checkmark"></span></label></li>' +
          '<li><label class="check-normal toggle-vis" data-column="16">Pago PSE<input type="checkbox"><span class="checkmark"></span></label></li>' +
          '<li><label class="check-normal toggle-vis" data-column="17">Valor PSE<input type="checkbox"><span class="checkmark"></span></label></li>' +
          '<li><label class="check-normal toggle-vis" data-column="18">Acciones<input type="checkbox"><span class="checkmark"></span></label></li>' +
          '</ul></div >');
    }
  }).columns.adjust().draw();

    myTable =  $('#generarReciboConsignacion').DataTable({
        "paging": true,
        "pageLength": 10,
        "ordering": false,
        "info": true,
        "bLengthChange": false,
        "searching": true,
        columnDefs: [
            {
                targets: '_all',
                width: "180px"
            }
        ],
        "language": {
            search: "_INPUT_",
            searchPlaceholder: "Buscar en tabla",
            "lengthMenu": "Mostrar _MENU_ contenidos por página",
            "zeroRecords": "No se encontraron resultados",
            "info": "Página _PAGE_ de _PAGES_",
            "infoEmpty": "No hay información disponible",
            "infoFiltered": "(Se filtraron _MAX_ total de contenidos)",
            "paginate": {
                "first": "Primero",
                "last": "Último",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },
        "sDom": 'l<"toolbar">fr<"datatable-scroll"t>ip',
    }).columns.adjust().draw();

  $("#logEventos").dataTable().fnDestroy();
  $('#logEventos').DataTable({
    "paging": true,
    "pageLength": 10,
    retrieve: true,
    "info": false,
    "bLengthChange": false,
    "searching": true,
    "sDom": 'l<"toolbar">fr<"datatable-scroll"t>ip',
    "language": {
      search: "_INPUT_",
      searchPlaceholder: "Buscar en tabla",
      "lengthMenu": "Mostrar _MENU_ contenidos por página",
      "zeroRecords": "No se encontraron resultados",
      "info": "Página _PAGE_ de _PAGES_",
      "infoEmpty": "No hay información disponible",
      "infoFiltered": "(Se filtraron _MAX_ total de contenidos)",
      "paginate": {
        "first": "Primero",
        "last": "Último",
        "next": "Siguiente",
        "previous": "Anterior"
      }
    }
  }).columns.adjust().draw();

  $('#resultadoFiltro').DataTable({
    "paging": true,
    "pageLength": 10,
    "ordering": false,
    "info": false,
    "bLengthChange": false,
    "searching": true,
    "sDom": 'l<"toolbar">fr<"datatable-scroll"t>ip',
    "language": {
      search: "_INPUT_",
      searchPlaceholder: "Buscar en tabla",
      "lengthMenu": "Mostrar _MENU_ contenidos por página",
      "zeroRecords": "No se encontraron resultados",
      "info": "Página _PAGE_ de _PAGES_",
      "infoEmpty": "No hay información disponible",
      "infoFiltered": "(Se filtraron _MAX_ total de contenidos)",
      "paginate": {
        "first": "Primero",
        "last": "Último",
        "next": "Siguiente",
        "previous": "Anterior"
      }
    }
  }).columns.adjust().draw();

  $('#descargueMasivo').DataTable({
    "paging": true,
    "pageLength": 10,
    "ordering": false,
    "info": false,
    "bLengthChange": false,
    "searching": true,
    "sDom": 'lfr<"datatable-scroll"t>ip',
    "language": {
      search: "_INPUT_",
      searchPlaceholder: "Buscar en tabla",
      "lengthMenu": "Mostrar _MENU_ contenidos por página",
      "zeroRecords": "No se encontraron resultados",
      "info": "Página _PAGE_ de _PAGES_",
      "infoEmpty": "No hay información disponible",
      "infoFiltered": "(Se filtraron _MAX_ total de contenidos)",
      "paginate": {
        "first": "Primero",
        "last": "Último",
        "next": "Siguiente",
        "previous": "Anterior"
      }
    }
  }).columns.adjust().draw();

  $('.conveniosBancoCanal').DataTable({
    "paging": true,
    "pageLength": 5,
    "ordering": false,
    "info": false,
    "bLengthChange": false,
    "searching": false,
    "sDom": 'lfr<"datatable-scroll"t>ip',
    "pagingType": "numbers",
    "language": {
      search: "_INPUT_",
      searchPlaceholder: "Buscar en tabla",
      "lengthMenu": "Mostrar _MENU_ contenidos por página",
      "zeroRecords": "No se encontraron resultados",
      "info": "Página _PAGE_ de _PAGES_",
      "infoEmpty": "No hay información disponible",
      "infoFiltered": "(Se filtraron _MAX_ total de contenidos)"
      //"paginate": {
      //    "first": "Primero",
      //    "last": "Último",
      //    "next": "Siguiente",
      //    "previous": "Anterior"
      //}
    }
  }).columns.adjust().draw();

  $i(".btnExcel").click(function (e) {

    $i('.tablaExcel').table2excel({
      exclude: ".noExl",
      name: "Excel Document Name",
      filename: "myFileName" + new Date().toISOString().replace(/[\-\:\.]/g, "") + ".xls",
      fileext: ".xls",
      exclude_img: true,
      exclude_links: true,
      exclude_inputs: true
    });
  });

  $(".toast__dismiss-btn").click(function () {
    //$(".toast__close").css("display", "none");
    $(".contenedor-toast").addClass("toast__close");
  })
}


//++++ AL CARGAR LA PAGINA
$(window).on('load', function () {
  (function ($) {
    preloaderFadeOutInit();
  })($);

});

///functions

$(function () {

  $(".calendario").datepicker({
    language: "es",
    todayHighlight: true,
    autoclose: true,

  }).datepicker('update');
});


!function (a) {
  a.fn.datepicker.dates.es =
  {
    days: ["Domingo", "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado"],
    daysShort: ["Dom", "Lun", "Mar", "Mié", "Jue", "Vie", "Sáb"],
    daysMin: ["Do", "Lu", "Ma", "Mi", "Ju", "Vi", "Sa"],
    months: ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"],
    monthsShort: ["Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic"],
    today: "Hoy",
    monthsTitle: "Meses",
    clear: "Borrar",
    weekStart: 1,
    format: "mm/dd/yyyy"
  }
}($);

function menuDisplay(obj1, obj2) {

  let
    objeto1 = document.querySelector(obj1),
    objeto2 = document.querySelector(obj2)
    ;

  if (objeto1 != null && objeto2 != null) {
    var estado = false

    objeto1.addEventListener('click', () => {

      if (estado) {
        objeto2.classList.add('cerrar-menu');
        estado = false;
      } else {
        objeto2.classList.remove('cerrar-menu');
        estado = true;
      }
    });

  }

}
//CONTADOR DE CARACTERES
function countChars(obj) {
  var maxLength = 230;
  var strLength = obj.value.length;
  var charRemain = (maxLength - strLength);

  if (charRemain < 0) {
    document.getElementById("charNum").innerHTML = '<span style="color: red;">Ha excedido el límite de caracteres permitidos ' + maxLength + ' </span>';
  } else {
    document.getElementById("charNum").innerHTML = charRemain + ' Caracteres restantes';
  }
}

//PRELOADER
function preloaderFadeOutInit() {
  setTimeout(function () {
    $('.content__preloader').fadeOut('slow', function () {
    });
  }, 600);
}

function ShowMessageAlert(type, message) {
  toastr.options = {
    "closeButton": false,
    "debug": false,
    "newestOnTop": false,
    "progressBar": true,
    "positionClass": "toast-top-right",
    "preventDuplicates": false,
    "showDuration": "300",
    "hideDuration": "1000",
    "timeOut": "5000",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
  }
  Command: toastr[type]
    (message)
};

//modal sobre modal 
(function ($, window) {
  'use strict';

  var MultiModal = function (element) {
    this.$element = $(element);
    this.modalCount = 0;
  };

  MultiModal.BASE_ZINDEX = 1040;

  MultiModal.prototype.show = function (target) {
    var that = this;
    var $target = $(target);
    var modalIndex = that.modalCount++;

    $target.css('z-index', MultiModal.BASE_ZINDEX + (modalIndex * 20) + 10);


    window.setTimeout(function () {
      if (modalIndex > 0)
        $('.modal-backdrop').not(':first').addClass('hidden');

      that.adjustBackdrop();
    });
  };

  MultiModal.prototype.hidden = function (target) {
    this.modalCount--;
    if (this.modalCount) {
      this.adjustBackdrop();
      $('body').addClass('modal-open');
    }
  };

  MultiModal.prototype.adjustBackdrop = function () {
    var modalIndex = this.modalCount - 1;
    $('.modal-backdrop:first').css('z-index', MultiModal.BASE_ZINDEX + (modalIndex * 20));
  };

  function Plugin(method, target) {
    return this.each(function () {
      var $this = $(this);
      var data = $this.data('multi-modal-plugin');

      if (!data)
        $this.data('multi-modal-plugin', (data = new MultiModal(this)));

      if (method)
        data[method](target);
    });
  }

  $.fn.multiModal = Plugin;
  $.fn.multiModal.Constructor = MultiModal;

  $(document).on('show.bs.modal', function (e) {
    $(document).multiModal('show', e.target);
  });

  $(document).on('hidden.bs.modal', function (e) {
    $(document).multiModal('hidden', e.target);
  });
}(jQuery, window));

(function (document, window, index) {
  var inputs = document.querySelectorAll('.inputfile');
  Array.prototype.forEach.call(inputs, function (input) {
    var label = input.nextElementSibling,
      labelVal = label.innerHTML;

    input.addEventListener('change', function (e) {
      var fileName = '';
      if (this.files && this.files.length > 1)
        fileName = (this.getAttribute('data-multiple-caption') || '').replace('{count}', this.files.length);
      else
        fileName = e.target.value.split('\\').pop();

      if (fileName)
        label.querySelector('span').innerHTML = fileName;
      else
        label.innerHTML = labelVal;
    });

    // Firefox bug fix
    input.addEventListener('focus', function () { input.classList.add('has-focus'); });
    input.addEventListener('blur', function () { input.classList.remove('has-focus'); });
  });
}(document, window, 0));

function btnMenuMovil() {
  $('nav').css("left", "0");
  menu.removeClass('menu-principal-cerrado');
  $('.item-menu-principal-titulo').css({
    'visibility': 'visible',
    'opacity': '1',
    'padding-left': '0.5em'
  });
}

function activarItem(id) {
  let item = document.getElementById(id);
  item.classList.add('item-seleccionado');
}