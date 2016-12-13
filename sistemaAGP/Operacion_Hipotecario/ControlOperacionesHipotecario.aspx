<%@ Page Title="" Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true"
    CodeBehind="ControlOperacionesHipotecario.aspx.cs" Inherits="sistemaAGP.Operacion_Hipotecario.ControlOperacionesHipotecario" %>

<%@ Register Src="~/controles/wucGrillaHipoteca.ascx" TagName="SinSeleccion" TagPrefix="agp" %>
<%@ Register Src="~/controles/wucGrillaHipoteca.ascx" TagName="MisTareas" TagPrefix="agp2" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=3.5.40412.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=3.5.40412.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
    <script type="text/javascript" src="../jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="../jquery.mousewheel-3.0.6.pack.js"></script>
    <script type="text/javascript" src="../jquery.fancybox.js?v=2.0.6"></script>
    <link rel="Stylesheet" type="text/css" href="../jquery.fancybox.css?v=2.0.6" media="screen" />
    <script type="text/javascript" src="../javascript/ScrollableGrid.js"></script>
    
    
    
     <style type="text/css">
.tabpanel {
  margin: 20px;
  padding: 0;
  height: 100%; /* IE fix for float bug */
}
.tablist {
  margin: 0 0px;
  padding: 0;
  list-style: none;
}

.tab {

  margin: .2em 1px 0 0;
  padding: 10px;
  height: 1em;
  font-weight: bold;
  background-color: #23819C;
  color: #fff;
    font-size: xx-small;

  border: 1px solid #23819C;
    border-radius: 5px;
	    -ms-border-radius: 5px;
	    -moz-border-radius: 5px;
	    -webkit-border-radius: 5px;
	    -khtml-border-radius: 5px;
 -webkit-border-radius-topright: 5px;
  -webkit-border-radius-topleft: 5px;
  -moz-border-radius-topright: 5px;
  -moz-border-radius-topleft: 5px;
  border-radius-topright: 5px;
  border-radius-topleft: 5px;

  float: left;
  display: inline; /* IE float bug fix */
}

.panel {
  clear: both;
  display: block;
  margin: 0 0 0 0;
  padding: 10px;
  width: 100%;
  border: 1px solid #585858;
    background-color: #f1f1f1;
  -webkit-border-radius-topright: 10px;
  -webkit-border-radius-bottomleft: 10px;
  -webkit-border-radius-bottomright: 10px;
  -moz-border-radius-topright: 10px;
  -moz-border-radius-bottomleft: 10px;
  -moz-border-radius-bottomright: 10px;
  border-radius-topright: 10px;
  border-radius-bottomleft: 10px;
  border-radius-bottomright: 10px;
  
   -ms-border-radius: 5px;
	    -moz-border-radius: 5px;
	    -webkit-border-radius: 5px;
	    -khtml-border-radius: 5px;
	    
	     -moz-box-shadow: 10px 10px 5px #888;
        -webkit-box-shadow: 10px 10px 5px #888;
        box-shadow: 10px 10px 5px #888;
}

ul.controlList {
  list-style-type: none;
}

li.selected {
  color: black;
  background-color: #fff;
  border-bottom: 1px solid white;
}

.focus {
  margin-top: 0;
  height: 1.2em;
}

.accordian {
  margin: 0;
  float: none;
  -webkit-border-radius: 0;
  -moz-border-radius: 0;
  border-radius: 0;
  width: 600px;
}

.hidden {
  position: absolute;
  left: -300em;
  top: -30em;
}
  </style>
  
  
  <script type="text/javascript">
      $(document).ready(function () {

          var panel1 = new tabpanel("tabpanel1", false);
          

          //var panel2 = new tabpanel("accordian1", true);
      });

      //
      // keyCodes() is an object to contain keycodes needed for the application
      //
      function keyCodes() {
          // Define values for keycodes
          this.tab = 9;
          this.enter = 13;
          this.esc = 27;

          this.space = 32;
          this.pageup = 33;
          this.pagedown = 34;
          this.end = 35;
          this.home = 36;

          this.left = 37;
          this.up = 38;
          this.right = 39;
          this.down = 40;

      } // end keyCodes

      //
      // tabpanel() is a class constructor to create a ARIA-enabled tab panel widget.
      //
      // @param (id string) id is the id of the div containing the tab panel.
      //
      // @param (accordian boolean) accordian is true if the tab panel should operate
      //         as an accordian; false if a tab panel
      //
      // @return N/A
      //
      // Usage: Requires a div container and children as follows:
      //
      //         1. tabs/accordian headers have class 'tab'
      //
      //         2. panels are divs with class 'panel'
      //
      function tabpanel(id, accordian) {

          // define the class properties

          this.panel_id = id; // store the id of the containing div
          this.accordian = accordian; // true if this is an accordian control
          this.$panel = $('#' + id);  // store the jQuery object for the panel
          this.keys = new keyCodes(); // keycodes needed for event handlers
          this.$tabs = this.$panel.find('.tab'); // Array of panel tabs.
          this.$panels = this.$panel.children('.panel'); // Array of panel.
        
          // Bind event handlers
          this.bindHandlers();

          // Initialize the tab panel
          this.init();

      } // end tabpanel() constructor

      //
      // Function init() is a member function to initialize the tab/accordian panel. Hides all panels. If a tab
      // has the class 'selected', makes that panel visible; otherwise, makes first panel visible.
      //
      // @return N/A
      //
      tabpanel.prototype.init = function () {
          var $tab; // the selected tab - if one is selected

          // add aria attributes to the panel container
          this.$panel.attr('aria-multiselectable', this.accordian);

          // add aria attributes to the panels
          this.$panels.attr('aria-hidden', 'true');

          // hide all the panels
          this.$panels.hide();

          // get the selected tab
          $tab = this.$tabs.filter('.selected');

          var valorHiden = document.getElementById('<%= Hidden1.ClientID %>').value;
          if (valorHiden == '0') {
              this.$panel.find('#panel1').show();
              this.$panel.find('#panel2').hide();
              $tab.addClass('selected');
          }
          else if (valorHiden = "1") {
              this.$panel.find('#panel2').show();
              this.$panel.find('#panel1').hide();
              $tab.addClass('selected');
          }

//          if ($tab == undefined) {
//              $tab = this.$tabs.first();
//              $tab.addClass('selected');
//          }


          // show the panel that the selected tab controls and set aria-hidden to false
          //this.$panel.find('#' + $tab.attr('aria-controls')).show().attr('aria-hidden', 'false');

      }     // end init()

      //
      // Function switchTabs() is a member function to give focus to a new tab or accordian header.
      // If it's a tab panel, the currently displayed panel is hidden and the panel associated with the new tab
      // is displayed.
      //
      // @param ($curTab obj) $curTab is the jQuery object of the currently selected tab
      //
      // @param ($newTab obj) $newTab is the jQuery object of new tab to switch to
      //
      // @param (activate boolean) activate is true if focus should be set on an element in the panel; false if on tab
      //
      // @return N/A
      //
      tabpanel.prototype.switchTabs = function ($curTab, $newTab) {

          // Remove the highlighting from the current tab
          $curTab.removeClass('selected');
          $curTab.removeClass('focus');
 
          // remove tab from the tab order
          $curTab.attr('tabindex', '-1');

          // update the aria attributes

          // Highlight the new tab
          $newTab.addClass('selected');

          // If this is a tab panel, swap displayed tabs
          if (this.accordian == false) {
           
              // hide the current tab panel and set aria-hidden to true
              this.$panel.find('#' + $curTab.attr('aria-controls')).hide().attr('aria-hidden', 'true');

              // show the new tab panel and set aria-hidden to false
              this.$panel.find('#' + $newTab.attr('aria-controls')).show().attr('aria-hidden', 'false');
          }

          // Make new tab navigable
          $newTab.attr('tabindex', '0');

          // give the new tab focus
          $newTab.focus();

      }  // end switchTabs()

      //
      // Function togglePanel() is a member function to display or hide the panel associated with an accordian header
      //
      // @param ($tab obj) $tab is the jQuery object of the currently selected tab
      //
      // @return N/A
      //
      tabpanel.prototype.togglePanel = function ($tab) {
         
          $panel = this.$panel.find('#' + $tab.attr('aria-controls'));

          if ($panel.attr('aria-hidden') == 'true') {
              $panel.slideDown(100);
              $panel.attr('aria-hidden', 'false');
             
          }
          else {
              $panel.slideUp(100);
              $panel.attr('aria-hidden', 'true');
             
          }
      } // end togglePanel()

      //
      // Function bindHandlers() is a member function to bind event handlers for the tabs
      //
      // @return N/A
      //
      tabpanel.prototype.bindHandlers = function () {

          var thisObj = this; // Store the this pointer for reference

          //////////////////////////////
          // Bind handlers for the tabs / accordian headers

          // bind a tab keydown handler
          this.$tabs.keydown(function (e) {
           
              return thisObj.handleTabKeyDown($(this), e);
          });

          // bind a tab keypress handler
          this.$tabs.keypress(function (e) {
              
              return thisObj.handleTabKeyPress($(this), e);
          });

          // bind a tab click handler
          this.$tabs.click(function (e) {
            
              return thisObj.handleTabClick($(this), e);
          });

          // bind a tab focus handler
          this.$tabs.focus(function (e) {
              
              return thisObj.handleTabFocus($(this), e);
          });

          // bind a tab blur handler
          this.$tabs.blur(function (e) {
              
              return thisObj.handleTabBlur($(this), e);
          });

          /////////////////////////////
          // Bind handlers for the panels

          // bind a keydown handlers for the panel focusable elements
          this.$panels.keydown(function (e) {
             
              return thisObj.handlePanelKeyDown($(this), e);
          });

          // bind a keypress handler for the panel
          this.$panels.keypress(function (e) {
             
              return thisObj.handlePanelKeyPress($(this), e);
          });

      } // end bindHandlers()

      //
      // Function handleTabKeyDown() is a member function to process keydown events for a tab
      //
      // @param ($tab obj) $tab is the jquery object of the tab being processed
      //
      // @paran (e obj) e is the associated event object
      //
      // @return (boolean) Returns true if propagating; false if consuming event
      //
      tabpanel.prototype.handleTabKeyDown = function ($tab, e) {

          if (e.altKey) {
              // do nothing
              return true;
          }
         
          switch (e.keyCode) {
              case this.keys.enter:
              case this.keys.space: 
                  {

                      // Only process if this is an accordian widget
                      if (this.accordian == true) {
                          // display or collapse the panel
                          this.togglePanel($tab);

                          e.stopPropagation();
                          return false;
                      }

                      return true;
                  }
              case this.keys.left:
              case this.keys.up: 
                  {

                      var thisObj = this;
                      var $prevTab; // holds jQuery object of tab from previous pass
                      var $newTab; // the new tab to switch to

                      if (e.ctrlKey) {
                          // Ctrl+arrow moves focus from panel content to the open
                          // tab/accordian header.
                      }
                      else {
                          var curNdx = this.$tabs.index($tab);

                          if (curNdx == 0) {
                              // tab is the first one:
                              // set newTab to last tab
                              $newTab = this.$tabs.last();
                          }
                          else {
                              // set newTab to previous
                              $newTab = this.$tabs.eq(curNdx - 1);
                          }

                          // switch to the new tab
                          this.switchTabs($tab, $newTab);
                      }

                      e.stopPropagation();
                      return false;
                  }
              case this.keys.right:
              case this.keys.down: 
                  {

                      var thisObj = this;
                      var foundTab = false; // set to true when current tab found in array
                      var $newTab; // the new tab to switch to

                      var curNdx = this.$tabs.index($tab);

                      if (curNdx == this.$tabs.last().index()) {
                          // tab is the last one:
                          // set newTab to first tab
                          $newTab = this.$tabs.first();
                      }
                      else {
                          // set newTab to next tab
                          $newTab = this.$tabs.eq(curNdx + 1);
                      }

                      // switch to the new tab
                      this.switchTabs($tab, $newTab);

                      e.stopPropagation();
                      return false;
                  }
              case this.keys.home: 
                  {

                      // switch to the first tab
                      this.switchTabs($tab, this.$tabs.first());

                      e.stopPropagation();
                      return false;
                  }
              case this.keys.end: 
                  {

                      // switch to the last tab
                      this.switchTabs($tab, this.$tabs.last());

                      e.stopPropagation();
                      return false;
                  }
          }
      } // end handleTabKeyDown()

      //
      // Function handleTabKeyPress() is a member function to process keypress events for a tab.
      //
      //
      // @param ($tab obj) $tab is the jquery object of the tab being processed
      //
      // @paran (e obj) e is the associated event object
      //
      // @return (boolean) Returns true if propagating; false if consuming event
      //
      tabpanel.prototype.handleTabKeyPress = function ($tab, e) {

          if (e.altKey) {
              // do nothing
              return true;
          }

          switch (e.keyCode) {
              case this.keys.enter:
              case this.keys.space:
              case this.keys.left:
              case this.keys.up:
              case this.keys.right:
              case this.keys.down:
              case this.keys.home:
              case this.keys.end: 
                  {
                      e.stopPropagation();
                      return false;
                  }
              case this.keys.pageup:
              case this.keys.pagedown: 
                  {

                      // The tab keypress handler must consume pageup and pagedown
                      // keypresses to prevent Firefox from switching tabs
                      // on ctrl+pageup and ctrl+pagedown

                      if (!e.ctrlKey) {
                          return true;
                      }

                      e.stopPropagation();
                      return false;
                  }
          }

          return true;

      } // end handleTabKeyPress()

      //
      // Function handleTabClick() is a member function to process click events for tabs
      //
      // @param ($tab object) $tab is the jQuery object of the tab being processed
      //
      // @paran (e object) e is the associated event object
      //
      // @return (boolean) returns true
      //
      tabpanel.prototype.handleTabClick = function ($tab, e) {

          // Remove the highlighting from all tabs
          this.$tabs.removeClass('selected');

          // remove all tabs from the tab order
          this.$tabs.attr('tabindex', '-1');

          // hide all tab panels
          this.$panels.hide();

          // Highlight the clicked tab
          $tab.addClass('selected');

          // show the clicked tab panel
          this.$panel.find('#' + $tab.attr('aria-controls')).show();
          var id = $tab.attr('id');
          // make clicked tab navigable
          $tab.attr('tabindex', '0');

          // give the tab focus
          $tab.focus();
       
    
          switch (id) {
              case "tab1":
                  document.getElementById('<%= Hidden1.ClientID %>').value = "0";
                  break;
              case "tab2":
                  document.getElementById('<%= Hidden1.ClientID %>').value = "1";
                  break;
                 
          }

          return true;

      }         // end handleTabClick()

      //
      // Function handleTabFocus() is a member function to process focus events for tabs
      //
      // @param ($tab object) $tab is the jQuery object of the tab being processed
      //
      // @paran (e object) e is the associated event object
      //
      // @return (boolean) returns true
      //
      tabpanel.prototype.handleTabFocus = function ($tab, e) {

          // Add the focus class to the tab
          $tab.addClass('focus');

          return true;

      } // end handleTabFocus()

      //
      // Function handleTabBlur() is a member function to process blur events for tabs
      //
      // @param ($tab object) $tab is the jQuery object of the tab being processed
      //
      // @paran (e object) e is the associated event object
      //
      // @return (boolean) returns true
      //
      tabpanel.prototype.handleTabBlur = function ($tab, e) {

          // Remove the focus class to the tab
          $tab.removeClass('focus');

          return true;

      } // end handleTabBlur()


      /////////////////////////////////////////////////////////
      // Panel Event handlers
      //

      //
      // Function handlePanelKeyDown() is a member function to process keydown events for a panel
      //
      // @param ($elem obj) $elem is the jquery object of the element being processed
      //
      // @paran (e obj) e is the associated event object
      //
      // @return (boolean) Returns true if propagating; false if consuming event
      //
      tabpanel.prototype.handlePanelKeyDown = function ($elem, e) {

          if (e.altKey) {
              // do nothing
              return true;
          }

          switch (e.keyCode) {
              case this.keys.esc: 
                  {
                      e.stopPropagation();
                      return false;
                  }
              case this.keys.left:
              case this.keys.up: 
                  {

                      if (!e.ctrlKey) {
                          // do not process
                          return true;
                      }

                      // get the jQuery object of the tab
                      var $tab = $('#' + $elem.attr('aria-labeledby'));

                      // Move focus to the tab
                      $tab.focus();

                      e.stopPropagation();
                      return false;
                  }
              case this.keys.pageup: 
                  {

                      var $newTab;

                      if (!e.ctrlKey) {
                          // do not process
                          return true;
                      }

                      // get the jQuery object of the tab
                      var $tab = this.$tabs.filter('.selected');

                      // get the index of the tab in the tab list
                      var curNdx = this.$tabs.index($tab);

                      if (curNdx == 0) {
                          // this is the first tab, set focus on the last one
                          $newTab = this.$tabs.last();
                      }
                      else {
                          // set focus on the previous tab
                          $newTab = this.$tabs.eq(curNdx - 1);
                      }

                      // switch to the new tab
                      this.switchTabs($tab, $newTab);

                      e.stopPropagation();
                      e.preventDefault();
                      return false;
                  }
              case this.keys.pagedown: 
                  {

                      var $newTab;

                      if (!e.ctrlKey) {
                          // do not process
                          return true;
                      }

                      // get the jQuery object of the tab
                      var $tab = $('#' + $elem.attr('aria-labeledby'));

                      // get the index of the tab in the tab list
                      var curNdx = this.$tabs.index($tab);

                      if (curNdx == this.$tabs.last().index()) {
                          // this is the last tab, set focus on the first one
                          $newTab = this.$tabs.first();
                      }
                      else {
                          // set focus on the next tab
                          $newTab = this.$tabs.eq(curNdx + 1);
                      }

                      // switch to the new tab
                      this.switchTabs($tab, $newTab);

                      e.stopPropagation();
                      e.preventDefault();
                      return false;
                  }
          }

          return true;

      } // end handlePanelKeyDown()

      //
      // Function handlePanelKeyPress() is a member function to process keypress events for a panel
      //
      // @param ($elem obj) $elem is the jquery object of the element being processed
      //
      // @paran (e obj) e is the associated event object
      //
      // @return (boolean) Returns true if propagating; false if consuming event
      //
      tabpanel.prototype.handlePanelKeyPress = function ($elem, e) {

          if (e.altKey) {
              // do nothing
              return true;
          }

          if (e.ctrlKey && (e.keyCode == this.keys.pageup || e.keyCode == this.keys.pagedown)) {
              e.stopPropagation();
              e.preventDefault();
              return false;
          }

          switch (e.keyCode) {
              case this.keys.esc: 
                  {
                      e.stopPropagation();
                      e.preventDefault();
                      return false;
                  }
          }

          return true;

      } // end handlePanelKeyPress()

      // focusable is a small jQuery extension to add a :focusable selector. It is used to
      // get a list of all focusable elements in a panel. Credit to ajpiano on the jQuery forums.
      //
      $.extend($.expr[':'], {
          focusable: function (element) {
              var nodeName = element.nodeName.toLowerCase();
              var tabIndex = $(element).attr('tabindex');

              // the element and all of its ancestors must be visible
              if (($(element)[nodeName == 'area' ? 'parents' : 'closest'](':hidden').length) == true) {
                  return false;
              }

              // If tabindex is defined, its value must be greater than 0
              if (!isNaN(tabIndex) && tabIndex < 0) {
                  return false;
              }

              // if the element is a standard form control, it must not be disabled
              if (/input|select|textarea|button|object/.test(nodeName) == true) {

                  return !element.disabled;
              }

              // if the element is a link, href must be defined
              if ((nodeName == 'a' || nodeName == 'area') == true) {

                  return (element.href.length > 0);
              }

              // this is some other page element that is not normally focusable.
              return false;
          }
      });

  </script>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
    
   
     

  <div id="div_titulo" style="width: 50%">
        <asp:Image ID="Image1" runat="server" 
                        ImageUrl="../imagenes/sistema/static/hipotecario/Logo.png" 
                        Height="34px" 
                        Width="37px" />
        &nbsp;<asp:Label ID="lbl_titulo" runat="server" Text="PANEL DE CONTROL"></asp:Label>
    </div>
    <br/>
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="upFiltros">
        <ContentTemplate>
    <table class="table">
        <tr>
            <td>
                Cliente
            </td>
            <td>
                <b>
                    <asp:DropDownList ID="dl_cliente" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dl_cliente_SelectedIndexChanged">
                    </asp:DropDownList>
                </b>
            </td>
            <td>
                Sucursal
            </td>
            <td>
                <b>
                    <asp:DropDownList ID="dl_sucursal" runat="server">
                    </asp:DropDownList>
                </b>
            </td>
             <td>
                Familia
            </td>
            <td>
                <b>
                    <asp:DropDownList ID="dlFamilia" runat="server" OnSelectedIndexChanged="dlFamilia_SelectedIndexChanged"
                        AutoPostBack="True">
                    </asp:DropDownList>
                </b>
            </td>
            <td>
                Producto
            </td>
            <td>
                <b>
                    <asp:DropDownList ID="dl_producto" runat="server">
                    </asp:DropDownList>
                </b>
            </td>
           
        </tr>
        <tr>
            <td>
                Nº AGP
            </td>
            <td>
                <asp:TextBox ID="txt_idSolicitud" runat="server"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txt_idSolicitud_FilteredTextBoxExtender" runat="server"
                    TargetControlID="txt_idSolicitud" FilterType="Custom, Numbers" ValidChars="">
                </cc1:FilteredTextBoxExtender>
            </td>
            <td>
                Nº Cliente
            </td>
            <td>
                <asp:TextBox ID="txt_numCliente" runat="server"></asp:TextBox>
            </td> 
             <td>
                Desde
            </td>
            <td>
                <asp:TextBox ID="txt_desde" runat="server"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_desde"
                    Format="dd/MM/yyyy" />
            </td>
            <td>
                Hasta
            </td>
            <td>
                <asp:TextBox ID="txt_hasta" runat="server"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_hasta"
                    Format="dd/MM/yyyy" />
            </td>
        </tr>
        <tr>
            <td>
                Ejecutivo
            </td>
            <td>
                <b>
                    <asp:DropDownList ID="dl_ejecutivo" runat="server">
                    </asp:DropDownList>
                </b>
            </td>
            <td>
                Rut Deudor
            </td>
            <td>
                <asp:TextBox ID="txtRutCliBanco" runat="server"></asp:TextBox>
            </td>
            <td>
                Rut Vendedor
            </td>
            <td>
                <asp:TextBox ID="txtRutVendedor" runat="server"></asp:TextBox>
            </td>
            <td>
                Tipo Credito
            </td>
            <td>
                <b>
                    <asp:DropDownList ID="dl_credito" runat="server">
                    </asp:DropDownList>
                </b>
            </td>
        </tr>
        <tr>
            <td>
                Tipo Propiedad
            </td>
            <td>
                <b>
                    <asp:DropDownList ID="dlTipoPropiedad" runat="server">
                    </asp:DropDownList>
                </b>
            </td>
            <td>
                Región
            </td>
            <td>
                <b>
                    <asp:DropDownList ID="dl_region" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="dl_region_SelectedIndexChanged">
                    </asp:DropDownList>
                </b>
            </td>
             <td>
                Provincia
            </td>
            <td>
                <b>
                    <asp:DropDownList ID="dl_provincia" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="dl_provincia_SelectedIndexChanged">
                    </asp:DropDownList>
                </b>
            </td>
             <td>
                Comuna
            </td>
            <td>
                <b>
                    <asp:DropDownList ID="dl_comuna" runat="server">
                    </asp:DropDownList>
                </b>
            </td>
            
        </tr>
    </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br/>
    <div  class="div_objetos" style="z-index: 1">
				
        
                <table style="font-size: xx-small">
                    <tr>
                            <td>
                                <strong>Flujo de Trabajo</strong>
                            </td>
                            <td>
                                <asp:DropDownList ID="dpl_estado" runat="server"></asp:DropDownList>
                            </td>
                              <td>
                                <strong>Semáforo</strong>
                            </td>
                            <td>
                                <asp:DropDownList ID="dlTipoSemaforo" runat="server" AutoPostBack="True"
                                    onselectedindexchanged="dlTipoSemaforo_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                            <td runat="server" id="tdSemaforo" Visible="False">
                                <asp:ImageButton ID="ibVerde" runat="server" 
                                    ImageUrl="../imagenes/sistema/static/verde.png" onclick="ibVerde_Click" />
                            
                                &nbsp;<asp:ImageButton ID="ibAmarillo" runat="server" 
                                    ImageUrl="../imagenes/sistema/static/amarillo.png" onclick="ibAmarillo_Click" />  
                            
                                &nbsp;<asp:ImageButton ID="ibRojo" runat="server" 
                                    ImageUrl="../imagenes/sistema/static/rojo.png" onclick="ibRojo_Click"/>	
                            </td>
                            <td>
                                <asp:ImageButton ID="ib_buscar" 
                                    runat="server" 
                                    CausesValidation="true" 
                                    AlternateText="Buscar" 
                                    ImageAlign="AbsMiddle" 
                                    ImageUrl="~/imagenes/sistema/static/panel_control/lupa.png" 
                                    OnClick="ib_buscar_Click" 
                                    ValidationGroup="filtros" /> 
                            </td>
                    </tr>
                </table>
                
               
				
					
				
			</div>


    <br/>
    
  
      <asp:UpdatePanel runat="server" UpdateMode="Conditional"  ID="upGrilla">
        <ContentTemplate>
           
               <%-- <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" Visible="False"
                    onclick="btnSeleccionar_Click" CssClass="botonTab" />
                     <asp:Button ID="btnSeleccionar2" runat="server" Text="Seleccionar" 
                    CssClass="botonTabSeleccionado" />

                <asp:Button ID="btnMistareas" runat="server" Text="Mis Tareas" 
                    onclick="btnMistareas_Click"  CssClass="botonTab" />
                 <asp:Button ID="btnMistareas2" runat="server" Text="Mis Tareas" Visible="False"
                    CssClass="botonTabSeleccionado" />
                    <hr/>--%>
             <%-- <agp:SinSeleccion ID="SinSeleccionar" runat="server"  />
              <agp2:MisTareas ID="MisPendientes" runat="server" Visible="False" />--%>
    
    </ContentTemplate>
    </asp:UpdatePanel>
    
    <div id="tabpanel1" class="tabpanel">

  <ul class="tablist" role="tablist">
    <li id="tab1" class="tab selected" aria-controls="panel1"  value="panel1"  role="tab">Sin Seleccionar</li>
    <li id="tab2" class="tab" aria-controls="panel2"  value="panel2"  role="tab">Mis Tareas</li>
    
  </ul>

  <div id="panel1" class="panel" aria-labeledby="tab1" role="tabpanel" value="panel1">
   
      <agp:SinSeleccion ID="SinSeleccionar" runat="server"  />
        <div class="div_objetos" id="divBotones" runat="server" Visible="False" style="z-index: 1">
        <center>
            <asp:ImageButton ID="imAvanzar" runat="server" 
                ImageUrl="../imagenes/sistema/static/hipotecario/avanzar.png" 
                onclick="imAvanzar_Click" />
             <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server"
                                            TargetControlID="imAvanzar" ConfirmText="¿Está seguro de avanzar lo seleccionado?">
                </ajaxToolkit:ConfirmButtonExtender>
        </center>
         
     </div>
         
  </div>

  <div id="panel2" class="panel" aria-labeledby="tab2" role="tabpanel"  value="panel2">
   
       <agp2:MisTareas ID="MisPendientes" runat="server" />
         
  </div>

 
</div>


   
         <asp:HiddenField ID="Hidden1" runat="server" Value="0" />

</asp:Content>
