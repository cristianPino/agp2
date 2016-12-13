<%@ Page Title="" Language="C#" MasterPageFile="~/Modal.Master" AutoEventWireup="true" CodeBehind="Grafico.aspx.cs" Inherits="sistemaAGP.Operacion_Hipotecario.modal.Grafico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../../javascript/highcharts.js"></script>
    
     <style type="text/css">
        .caja
        {
            width: 100%;
            margin: auto;
            height: 400px;
            transition: height .4s;
        }
        .caja table
        {
            margin: 0 auto;
            text-align: left;
        }
    </style>

        <script type="text/javascript">
            $(function () {

                var ve1 = parseInt($('#<%=v1.ClientID %>').val());
                var ve2 = parseInt($('#<%=v2.ClientID %>').val());
                var ve3 = parseInt($('#<%=v3.ClientID %>').val());
                var ve4 = parseInt($('#<%=v4.ClientID %>').val());
                var ve5 = parseInt($('#<%=v5.ClientID %>').val());
                var ve6 = parseInt($('#<%=v6.ClientID %>').val());
                var ve7 = parseInt($('#<%=v7.ClientID %>').val());
                var ve8 = parseInt($('#<%=v8.ClientID %>').val());
                var ve9 = parseInt($('#<%=v9.ClientID %>').val());
                var ve10 = parseInt($('#<%=v10.ClientID %>').val());


                var am1 = parseInt($('#<%=a1.ClientID %>').val());
                var am2 = parseInt($('#<%=a2.ClientID %>').val());
                var am3 = parseInt($('#<%=a3.ClientID %>').val());
                var am4 = parseInt($('#<%=a4.ClientID %>').val());
                var am5 = parseInt($('#<%=a5.ClientID %>').val());
                var am6 = parseInt($('#<%=a6.ClientID %>').val());
                var am7 = parseInt($('#<%=a7.ClientID %>').val());
                var am8 = parseInt($('#<%=a8.ClientID %>').val());
                var am9 = parseInt($('#<%=a9.ClientID %>').val());
                var am10 = parseInt($('#<%=a10.ClientID %>').val());


                var ro1 = parseInt($('#<%=r1.ClientID %>').val());
                var ro2 = parseInt($('#<%=r2.ClientID %>').val());
                var ro3 = parseInt($('#<%=r3.ClientID %>').val());
                var ro4 = parseInt($('#<%=r4.ClientID %>').val());
                var ro5 = parseInt($('#<%=r5.ClientID %>').val());
                var ro6 = parseInt($('#<%=r6.ClientID %>').val());
                var ro7 = parseInt($('#<%=r7.ClientID %>').val());
                var ro8 = parseInt($('#<%=r8.ClientID %>').val());
                var ro9 = parseInt($('#<%=r9.ClientID %>').val());
                var ro10 = parseInt($('#<%=r10.ClientID %>').val());


                var es1 = $('#<%=e1.ClientID %>').val();
                var es2 = $('#<%=e2.ClientID %>').val();
                var es3 = $('#<%=e3.ClientID %>').val();
                var es4 = $('#<%=e4.ClientID %>').val();
                var es5 = $('#<%=e5.ClientID %>').val();
                var es6 = $('#<%=e6.ClientID %>').val();
                var es7 = $('#<%=e7.ClientID %>').val();
                var es8 = $('#<%=e8.ClientID %>').val();
                var es9 = $('#<%=e9.ClientID %>').val();
                var es10 = $('#<%=e10.ClientID %>').val();
                var es11 = $('#<%=e11.ClientID %>').val();
                var es12 = $('#<%=e12.ClientID %>').val();


                Highcharts.setOptions({
                    colors: ['#6aa022', '#fed02d', '#b11a04', '#b11a04', '#64E572', '#FF9655', '#FFF263', '#6AF9C4']
                });

                $('#container').highcharts({
                    chart: {
                        type: 'column'
                    },
                    title: {
                        text: 'Estados y semáforos'
                    },
                    subtitle: {
                        text: 'Mis estados'
                    },
                    xAxis: {
                        categories: [
                        es1, es2, es3, es4, es5, es6, es7, es8, es9, es10, es11, es12
                    ],
                        crosshair: true
                    },
                    yAxis: {
                        min: 0,
                        title: {
                            text: 'Cantidad (un)'
                        }
                    },
                    tooltip: {
                        headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                        pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                        '<td style="padding:0"><b>{point.y:.1f} op</b></td></tr>',
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
                        name: 'Cumplen',
                        data: [ve1, ve2, ve3, ve4, ve5, ve6, ve7, ve8, ve9, ve10]

                    }, {
                        name: 'Alerta',
                        data: [am1, am2, am3, am4, am5, am6, am7, am8, am9, am10]

                    }, {
                        name: 'No cumplen',
                        data: [ro1, ro2, ro3, ro4, ro5, ro6, ro7, ro8, ro9, ro10]

                    }]
                });
            });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<asp:UpdatePanel runat="server" ID="udp" UpdateMode="Conditional">
        <ContentTemplate>
     <div id="container" class="caja" style="min-width: 310px; height: 400px; margin: 0 auto"/>
     
      </ContentTemplate>
    </asp:UpdatePanel>
      <asp:HiddenField ID="v1" runat="server" Value="" />
    <asp:HiddenField ID="v2" runat="server" Value="" />
    <asp:HiddenField ID="v3" runat="server" Value="" />
    <asp:HiddenField ID="v4" runat="server" Value="" />
    <asp:HiddenField ID="v5" runat="server" Value="" />
    <asp:HiddenField ID="v6" runat="server" Value="" />
    <asp:HiddenField ID="v7" runat="server" Value="" />
    <asp:HiddenField ID="v8" runat="server" Value="" />
    <asp:HiddenField ID="v9" runat="server" Value="" />
    <asp:HiddenField ID="v10" runat="server" Value="" />
    <asp:HiddenField ID="v11" runat="server" Value="" />
    <asp:HiddenField ID="v12" runat="server" Value="" />
    <asp:HiddenField ID="v13" runat="server" Value="" />
    <asp:HiddenField ID="v14" runat="server" Value="" />
    <asp:HiddenField ID="v15" runat="server" Value="" />
    <asp:HiddenField ID="v16" runat="server" Value="" />
    <asp:HiddenField ID="v17" runat="server" Value="" />
    <asp:HiddenField ID="v18" runat="server" Value="" />
    <asp:HiddenField ID="v19" runat="server" Value="" />
    <asp:HiddenField ID="v20" runat="server" Value="" />
    <asp:HiddenField ID="v21" runat="server" Value="" />
    <asp:HiddenField ID="v22" runat="server" Value="" />
    <asp:HiddenField ID="v23" runat="server" Value="" />
    <asp:HiddenField ID="v24" runat="server" Value="" />
    <asp:HiddenField ID="v25" runat="server" Value="" />
    <asp:HiddenField ID="v26" runat="server" Value="" />
    <asp:HiddenField ID="a1" runat="server" Value="" />
    <asp:HiddenField ID="a2" runat="server" Value="" />
    <asp:HiddenField ID="a3" runat="server" Value="" />
    <asp:HiddenField ID="a4" runat="server" Value="" />
    <asp:HiddenField ID="a5" runat="server" Value="" />
    <asp:HiddenField ID="a6" runat="server" Value="" />
    <asp:HiddenField ID="a7" runat="server" Value="" />
    <asp:HiddenField ID="a8" runat="server" Value="" />
    <asp:HiddenField ID="a9" runat="server" Value="" />
    <asp:HiddenField ID="a10" runat="server" Value="" />
    <asp:HiddenField ID="a11" runat="server" Value="" />
    <asp:HiddenField ID="a12" runat="server" Value="" />
    <asp:HiddenField ID="a13" runat="server" Value="" />
    <asp:HiddenField ID="a14" runat="server" Value="" />
    <asp:HiddenField ID="a15" runat="server" Value="" />
    <asp:HiddenField ID="a16" runat="server" Value="" />
    <asp:HiddenField ID="a17" runat="server" Value="" />
    <asp:HiddenField ID="a18" runat="server" Value="" />
    <asp:HiddenField ID="a19" runat="server" Value="" />
    <asp:HiddenField ID="a20" runat="server" Value="" />
    <asp:HiddenField ID="a21" runat="server" Value="" />
    <asp:HiddenField ID="a22" runat="server" Value="" />
    <asp:HiddenField ID="a23" runat="server" Value="" />
    <asp:HiddenField ID="a24" runat="server" Value="" />
    <asp:HiddenField ID="a25" runat="server" Value="" />
    <asp:HiddenField ID="a26" runat="server" Value="" />
    <asp:HiddenField ID="r1" runat="server" Value="" />
    <asp:HiddenField ID="r2" runat="server" Value="" />
    <asp:HiddenField ID="r3" runat="server" Value="" />
    <asp:HiddenField ID="r4" runat="server" Value="" />
    <asp:HiddenField ID="r5" runat="server" Value="" />
    <asp:HiddenField ID="r6" runat="server" Value="" />
    <asp:HiddenField ID="r7" runat="server" Value="" />
    <asp:HiddenField ID="r8" runat="server" Value="" />
    <asp:HiddenField ID="r9" runat="server" Value="" />
    <asp:HiddenField ID="r10" runat="server" Value="" />
    <asp:HiddenField ID="r11" runat="server" Value="" />
    <asp:HiddenField ID="r12" runat="server" Value="" />
    <asp:HiddenField ID="r13" runat="server" Value="" />
    <asp:HiddenField ID="r14" runat="server" Value="" />
    <asp:HiddenField ID="r15" runat="server" Value="" />
    <asp:HiddenField ID="r16" runat="server" Value="" />
    <asp:HiddenField ID="r17" runat="server" Value="" />
    <asp:HiddenField ID="r18" runat="server" Value="" />
    <asp:HiddenField ID="r19" runat="server" Value="" />
    <asp:HiddenField ID="r20" runat="server" Value="" />
    <asp:HiddenField ID="r21" runat="server" Value="" />
    <asp:HiddenField ID="r22" runat="server" Value="" />
    <asp:HiddenField ID="r23" runat="server" Value="" />
    <asp:HiddenField ID="r24" runat="server" Value="" />
    <asp:HiddenField ID="r25" runat="server" Value="" />
    <asp:HiddenField ID="r26" runat="server" Value="" />
    <asp:HiddenField ID="e1" runat="server" Value="" />
    <asp:HiddenField ID="e2" runat="server" Value="" />
    <asp:HiddenField ID="e3" runat="server" Value="" />
    <asp:HiddenField ID="e4" runat="server" Value="" />
    <asp:HiddenField ID="e5" runat="server" Value="" />
    <asp:HiddenField ID="e6" runat="server" Value="" />
    <asp:HiddenField ID="e7" runat="server" Value="" />
    <asp:HiddenField ID="e8" runat="server" Value="" />
    <asp:HiddenField ID="e9" runat="server" Value="" />
    <asp:HiddenField ID="e10" runat="server" Value="" />
    <asp:HiddenField ID="e11" runat="server" Value="" />
    <asp:HiddenField ID="e12" runat="server" Value="" />
    <asp:HiddenField ID="e13" runat="server" Value="" />
    <asp:HiddenField ID="e14" runat="server" Value="" />
    <asp:HiddenField ID="e15" runat="server" Value="" />
    <asp:HiddenField ID="e16" runat="server" Value="" />
    <asp:HiddenField ID="e17" runat="server" Value="" />
    <asp:HiddenField ID="e18" runat="server" Value="" />
    <asp:HiddenField ID="e19" runat="server" Value="" />
    <asp:HiddenField ID="e20" runat="server" Value="" />
    <asp:HiddenField ID="e21" runat="server" Value="" />
    <asp:HiddenField ID="e22" runat="server" Value="" />
    <asp:HiddenField ID="e23" runat="server" Value="" />
    <asp:HiddenField ID="e24" runat="server" Value="" />
    <asp:HiddenField ID="e25" runat="server" Value="" />
    <asp:HiddenField ID="e26" runat="server" Value="" />
          
</asp:Content>
