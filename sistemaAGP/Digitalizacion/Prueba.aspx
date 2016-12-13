<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prueba.aspx.cs" Inherits="GestionAGP.Prueba" %>

<!DOCTYPE html>
<html>
<head>
    <title>Scan and upload documents to a web server</title>
    <meta http-equiv="Content-type" content="text/html;charset=UTF-8" />
    <meta http-equiv="Content-Language" content="en-us" />
    <meta http-equiv="X-UA-Compatible" content="requiresActiveX=true" />
    <link href="Styles/style.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        .style1
        {
            color: #000000;
        }
        .style2
        {
            width: 55px;
        }
    </style>
</head>
<body onload="onPageLoad();">    
    <form id="form1" runat="server">
 
            <!-- DWT_PageHead.js is used to initiate the head of the sample page. Not necessary!-->
<!--            <script src="Scripts/DWT_PageHead.js"></script>
        </div>
        <div class="DWTBody" >
            <!--This is where Dynamic Web TWAIN control will be rendered.-->
            
            
            <table>
            <tr>
            <td class="style1">Numero Operacion AGP</td>
            <td class="style2">
                <asp:Label ID="txtFileName" runat="server"></asp:Label>
            </td>
            
            </tr>

            <tr>
            <td class="style1">Tipo Documento</td>
            <td class="style2">
                <asp:Label ID="txt_tipo" runat="server"></asp:Label>
            </td>
            
            </tr>
            <tr>
            <td>Url de Carga</td>
            
            <td class="style2">
            
            <input type="text" maxlength="0"  id="txtActionPage" runat="server"/>
            
            </td>
            </tr>

            </table>
            
            <div id="dwtcontrolContainer" class="DWTContainer"></div>

            <!--This is where you add the actual buttons to control the component.-->
            <div class="ScanWrapper" >
                <div>
                        <input class="DWTScanButton btn" type="button" value="Obtener Imagen" onclick="acquireImage();" /> </div>
                
                <di id="divSave">
                <ul>
                    
                    <li>
                            <input type="hidden"  id="txtHTTPServer" />
                            <input type="hidden"  id="txtHTTPPort" />
                            <input type="hidden"  id="txtUserName" />
                            <input type="hidden"  id="txtPassword" />
                            
                             
                             
        
                    </li>
                    <li>
	                    <label for="imgTypejpeg">
		                    <input type="radio" value="jpg" name="ImageType" id="imgTypejpeg" 
                            onclick ="rd_onclick();" class="style1"/><span class="style1">JPEG</span></label>
	                    <label for="imgTypetiff">
		                    <input type="radio" value="tif" name="ImageType" id="imgTypetiff" 
                            onclick ="rdTIFF_onclick();" class="style1"/><span class="style1">TIFF</span></label>
	                    <label for="imgTypepng">
		                    <input type="radio" value="png" name="ImageType" id="imgTypepng" 
                            onclick ="rd_onclick();" class="style1"/><span class="style1">PNG</span></label>
	                    <label for="imgTypepdf">
		                    <input type="radio" value="pdf" name="ImageType" id="imgTypepdf" 
                            onclick ="rdPDF_onclick();" class="style1"/><span class="style1">PDF</span></label></li>
                    <li style="padding-left:9px;">
                        <label for="MultiPageTIFF"><input type="checkbox" id="MultiPageTIFF" 
                            class="style1"/><span class="style1">Multi-Page TIFF</span></label>
                        <label for="MultiPagePDF"><input type="checkbox" id="MultiPagePDF" 
                            class="style1"/><span class="style1">Multi-Page PDF </span> </label></li>
                </ul>
                <input id="btnUpload" class="DWTScanButton btn" type="button" value="Subir Carpeta" onclick ="btnUpload_onclick()"/>
                </div>
        
    <script src="Scripts/dynamsoft.webtwain.initiate.js"></script>
    <script src="Scripts/DWTSample_ScanAndUpload.js"></script>
    </form>
</body>
</html>
