<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MultiSelectCombo.ascx.cs" 
	Inherits="sistemaAGP.controles.MultiSelectCombo" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>

<script type="text/javascript" src="../jquery-1.7.2.min.js"></script>
<script type="text/javascript" src="../jquery.mousewheel-3.0.6.pack.js"></script>
<script type="text/javascript" src="../jquery.fancybox.js?v=2.0.6"></script>

<script type="text/javascript">
    $(function () {
        var count;
        $('#<%=chkList.ClientID %> input').bind("click", function () {
            if ($('#<%=chkList.ClientID %> input:checked').length == 0) {
                $('#<%=DDLabel.ClientID %>').text('Seleccione Objetos a Utilizar');
            }
            else {
                count = $('#<%=chkList.ClientID %> input:checked').length.toString();
                $('#<%=DDLabel.ClientID %>').text('Cantidad Seleccionada: ' + count);
            }
        });
    });
</script>

<script type="text/javascript">
    $(function () {
        $('#<%=checkall.ClientID %>').bind("click", function () {
            if ($(this).is(":checked")) {
                $('#<%=chkList.ClientID %> input').attr("checked", "checked");
                var count = '';
                $('#<%=chkList.ClientID %> input[type=checkbox]:checked').each(function () {
                    count = $('#<%=chkList.ClientID %> input:checked').length.toString();
                });
                $('#<%=DDLabel.ClientID %>').text('Cantidad Seleccionada: ' + count);
            }
            else {
                $('#<%=chkList.ClientID %> input').removeAttr("checked");
                $('#<%=DDLabel.ClientID %>').text('Seleccione Objetos a Utilizar');
            }
        });
        $('#<%=chkList.ClientID %> input').bind("click", function () {
            if ($('#<%=chkList.ClientID %> input:checked').length == $('#<%=chkList.ClientID %> input').length) {
                $('#<%=checkall.ClientID %>').attr("checked", "checked");
            } else {
                $('#<%=checkall.ClientID %>').removeAttr("checked");
            }
        });
    });  
</script>  

<script type="text/javascript">

    var color = 'White'; 

    function changeColor(obj) 
    { 
        var rowObject = getParentRow(obj); 
        var parentTable = document.getElementById("<%=chkList.ClientID%>"); 
        if(color == '') 
        {
            color = getRowColor(); 
        } 
        if(obj.checked) 
        {
            rowObject.style.backgroundColor = '#A3B1D8'; 
        }
        else 
        {
            rowObject.style.backgroundColor = color; 
            color = 'White'; 
        }

    // private method
    function getRowColor() 
    {
        if(rowObject.style.backgroundColor == 'White') return parentTable.style.backgroundColor; 
        else return rowObject.style.backgroundColor; 
    }

}

// This method returns the parent row of the object

function getParentRow(obj) 
{ 
    do 
    {
        obj = obj.parentElement; 
    }
    while(obj.tagName != "TR") 
    return obj; 
}


function TurnCheckBoixGridView(id)
{
    var frm = document.forms[0];
         
    for (i=0;i<frm.elements.length;i++)
    {
        if (frm.elements[i].type == "checkbox" && frm.elements[i].id.indexOf("<%= chkList.ClientID %>") == 0)
        {
            frm.elements[i].checked = document.getElementById(id).checked;
        }
     }
}

function SelectAll(id)
{
    
    var parentTable = document.getElementById("<%=chkList.ClientID%>"); 
    var color
    
    if (document.getElementById(id).checked)
    {
        color = '#A3B1D8'
    }
    else
    {
        color = 'White'
    }
    
    for (i=0;i<parentTable.rows.length;i++)
    {
	    parentTable.rows[i].style.backgroundColor = color;
    }
    TurnCheckBoixGridView(id);
    
}



</script>

<script type="text/javascript">
    $(document).ready(function () {
        $('#<%=button1.ClientID %>').toggle(
        function (e) {
            $('#<%=div_chk.ClientID %>').slideDown();
            e.preventDefault();
        },
        function (e) {
            $('#<%=div_chk.ClientID %>').slideUp();
            e.preventDefault();
        }
    );
    });
</script>


<style type="text/css">
    @import url("/otros.css");
    @import url("/sitio.css");
    .style8
    {
        width: 206px;
    }
    
    .scroll_checkboxes
    {
        height: 120px;
        width: 230px;
        padding: 5px;
        overflow: auto;
        border: 1px solid #ccc;
    }
    
     .FormText
    {
        FONT-SIZE: 11px;
        FONT-FAMILY: tahoma,sans-serif
    }
    </style>

    <div id="div_select" class="div_multi">
        <asp:Label ID="DDLabel" runat="server" MaxLength="50" Height="16px" 
            AutoPostBack="true" ReadOnly="true" 
            Width="217px"></asp:Label>
        <asp:Button ID="button1" runat="server" CssClass="button_azul" Height="16px" 
            onclick="button1_Click" Width="18px"  />
    </div>

        <div id="div_chk" runat="server" class="div1">
            <asp:CheckBox ID="checkall" runat="server" Text="Seleccionar Todo" />
            <asp:CheckBoxList Width="180px"  ID="chkList" runat="server" CssClass="FormText" RepeatDirection="Vertical" 
            RepeatColumns="1" BorderWidth="0" Datafield="description" DataValueField="value">
            </asp:CheckBoxList>
        </div>


