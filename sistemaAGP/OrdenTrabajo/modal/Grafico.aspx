<%@ Page Title="" Language="C#" MasterPageFile="~/modal2.Master" AutoEventWireup="true" CodeBehind="Grafico.aspx.cs" Inherits="sistemaAGP.OrdenTrabajo.modal.Grafico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript" src="../../jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="../../jquery.mousewheel-3.0.6.pack.js"></script>
    <script type="text/javascript" src="../../jquery.fancybox.js?v=2.0.6"></script>
    <link rel="Stylesheet" type="text/css" href="../../jquery.fancybox.css?v=2.0.6" media="screen" />
    <script type="text/javascript" src="../../javascript/ScrollableGrid.js"></script>
    <%--   <script type="text/javascript" src="../javascript/highcharts.js"></script>--%>
    <script type="text/javascript" src="../../javascript/exporting.js"></script>
    <script type="text/javascript" src="http://code.highcharts.com/highcharts.js"></script>
    <script type="text/javascript" src="http://code.highcharts.com/modules/data.js"></script>
    <script type="text/javascript" src="http://code.highcharts.com/modules/drilldown.js"></script>
     <style type="text/css">
        .caja
        {
            width: 100%;
            margin: auto;
            height: 400px;
            transition: height .8s;
        }
        .caja table
        {
            margin: 0 auto;
            text-align: left;
        }
    </style>
     <script type="text/javascript">
         $(function () {
             var aV = parseInt($('#<%=hdFacturaVerde.ClientID %>').val());
             var aA = parseInt($('#<%=hdFacturaAmarillo.ClientID %>').val());
             var aR = parseInt($('#<%=hdFacturaRojo.ClientID %>').val());
             var bV = parseInt($('#<%=hdAsignacionVerde.ClientID %>').val());
             var bA = parseInt($('#<%=hdAsignacionAmarillo.ClientID %>').val());
             var bR = parseInt($('#<%=hdAsignacionRojo.ClientID %>').val());
             var cV = parseInt($('#<%=hdIngresoVerde.ClientID %>').val());
             var cA = parseInt($('#<%=hdIngresoAmarillo.ClientID %>').val());
             var cR = parseInt($('#<%=hdIngresoRojo.ClientID %>').val());
             var dV = parseInt($('#<%=hdReparoVerde.ClientID %>').val());
             var dA = parseInt($('#<%=hdReparoAmarillo.ClientID %>').val());
             var dR = parseInt($('#<%=hdReparoRojo.ClientID %>').val());

             Highcharts.setOptions({
                 colors: ['#6aa022', '#fed02d', '#b11a04', '#b11a04', '#64E572', '#FF9655', '#FFF263', '#6AF9C4']
             });
             $('#container').highcharts({
                 chart: {
                     type: 'column'
                 },
                 title: {
                     text: 'Semáforos Pre-Tickets'
                 },
                 subtitle: {
                     text: 'Vista actual'
                 },
                 xAxis: {
                     categories: [
                        'Espera factura',
                        'En Asignacion',
                        'Esperando ingreso AGP',
                        'Con Reparo'

                    ],
                     crosshair: true
                 },
                 yAxis: {
                     min: 0,
                     title: {
                         text: 'Pre-Ticket (un)'
                     }
                 },
                 tooltip: {
                     headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                     pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                        '<td style="padding:0"><b>{point.y:.1f} un</b></td></tr>',
                     footerFormat: '</table>',
                     shared: true,
                     useHTML: true
                 },
                 plotOptions: {
                     column: {
                         pointPadding: 0.2,
                         borderWidth: 0
                     }
                 },
                 series: [{
                     name: 'Cumple',
                     data: [aV, bV, cV, dV]

                 }, {
                     name: 'Alerta',
                     data: [aA, bA, cA, dA]

                 }, {
                     name: 'No Cumplen',
                     data: [aR, bR, cR, dR]

                 }]
             });
         });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div id="container" class="caja" style="min-width: 310px; height: 400px; margin: 0 auto"/>
      <asp:HiddenField ID="hdFacturaVerde" runat="server" Value="" />
            <asp:HiddenField ID="hdFacturaAmarillo" runat="server" Value="" />
            <asp:HiddenField ID="hdFacturaRojo" runat="server" Value="" />
            <asp:HiddenField ID="hdAsignacionVerde" runat="server" Value="" />
            <asp:HiddenField ID="hdAsignacionAmarillo" runat="server" Value="" />
            <asp:HiddenField ID="hdAsignacionRojo" runat="server" Value="" />
            <asp:HiddenField ID="hdIngresoVerde" runat="server" Value="" />
            <asp:HiddenField ID="hdIngresoAmarillo" runat="server" Value="" />
            <asp:HiddenField ID="hdIngresoRojo" runat="server" Value="" />
            <asp:HiddenField ID="hdReparoVerde" runat="server" Value="" />
            <asp:HiddenField ID="hdReparoAmarillo" runat="server" Value="" />
            <asp:HiddenField ID="hdReparoRojo" runat="server" Value="" />
</asp:Content>
