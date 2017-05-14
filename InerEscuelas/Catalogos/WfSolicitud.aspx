<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WfSolicitud.aspx.cs" Inherits="InerEscuelas.Catalogos.WfSolicitud" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" >
    <div style="width:100%;text-align:center;">
    <asp:Label ID="Label1" runat="server" Text="Label" Font-Size="X-Large"  >

        SOLICITUD DE ADMISIÓN A LA LICENCIATURA EN ENFERMERÍA Y OBSTETRICIA ACUERDO UNAM. 07/06 DEL 30 DE MAYO DE 2006 CLAVE INCORPORACIÓN 3382-12
    </asp:Label>
        </div>
    <div>

    </div>
    <div align="center">
       
        <ajaxToolkit:Accordion ID="Accordion1" runat="server" Width="100%" >
             <Panes >
                 <ajaxToolkit:AccordionPane>
                     <Header>JAVASCRIPT</Header>
                    <Content>This section will reresent hte javascript section</Content>
                 </ajaxToolkit:AccordionPane>
             </Panes>

        </ajaxToolkit:Accordion>
      
    <asp:Table ID="Table1" runat="server" >
        <asp:TableRow HorizontalAlign="Center" >
            
            <asp:TableCell  >
                <asp:Panel ID="Panel1"  runat="server" Height="10" BackColor="Gray"></asp:Panel>
            </asp:TableCell>
                 
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableHeaderCell>
               
            </asp:TableHeaderCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left">
                <asp:Label ID="Label2" runat="server" Text="Label" >
                   Nombre (S)
                </asp:Label>
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Left">
                <asp:TextBox ID="TextBox1" runat="server" Width="400"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left">
                <asp:Label ID="Label3" runat="server" Text="Label">Apellido Paterno</asp:Label>
            </asp:TableCell>
            <asp:TableCell Width="200">
           <asp:TextBox ID="TextBox2" runat="server" Width="400"></asp:TextBox>
           </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left">
                <asp:Label ID="Label4" runat="server" Text="Label">Apellido Materno</asp:Label>
            </asp:TableCell>
            <asp:TableCell Width="200">
           <asp:TextBox ID="TextBox3" runat="server" Width="400"></asp:TextBox>
           </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left">
                <asp:Label ID="Label5" runat="server" Text="Label">Fecha de Nacimiento</asp:Label>
            </asp:TableCell>
            <asp:TableCell Width="200" HorizontalAlign="Left">
                <asp:TextBox ID="TextBox4" runat="server" Width="80" ></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBox4"/>
                            
           </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left">
                <asp:Label ID="Label6" runat="server" Text="Label">Edad</asp:Label>
            </asp:TableCell>
            <asp:TableCell Width="30">
           <asp:TextBox ID="TextBox5" runat="server" Width="30"></asp:TextBox>
           </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left">
                <asp:Label ID="Label7" runat="server" Text="Label">Sexo</asp:Label>
            </asp:TableCell>
            <asp:TableCell Width="200" HorizontalAlign="Left">
                <asp:DropDownList id ="ddlComputedColumns" runat ="server">
                    <asp:ListItem>
                       Seleccione
                   </asp:ListItem>
                   <asp:ListItem>
                       Masculino
                   </asp:ListItem>
                     <asp:ListItem>Femenino</asp:ListItem>
                  </asp:DropDownList>

           </asp:TableCell>
        </asp:TableRow>
           <asp:TableRow HorizontalAlign="Left">
            <asp:TableCell HorizontalAlign="Left">
                <asp:Label ID="Label8" runat="server" Text="Label">CURP</asp:Label>
            </asp:TableCell>
            <asp:TableCell Width="100">
           <asp:TextBox ID="TextBox6" runat="server"  ></asp:TextBox>
           </asp:TableCell>
                <asp:TableCell Width="30" HorizontalAlign="Left">
                    <asp:Button ID="Button1" runat="server" Text="Buscar" />
           </asp:TableCell>
        </asp:TableRow>
             <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left">
                <asp:Label ID="Label9" runat="server" Text="Label">Lugar de Nacimiento</asp:Label>
            </asp:TableCell>
            <asp:TableCell Width="30">
           <asp:TextBox ID="TextBox7" runat="server" Width="150"></asp:TextBox>
           </asp:TableCell>
        </asp:TableRow>
         <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left">
                <asp:Label ID="Label10" runat="server" Text="Label">Nacionalidad</asp:Label>
            </asp:TableCell>
            <asp:TableCell Width="30">
           <asp:TextBox ID="TextBox8" runat="server" Width="200"></asp:TextBox>
           </asp:TableCell>
        </asp:TableRow>
         <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left">
                <asp:Label ID="Label11" runat="server" Text="Label">Estado Civil</asp:Label>
            </asp:TableCell>
            <asp:TableCell Width="30">
           <asp:TextBox ID="TextBox9" runat="server" Width="150"></asp:TextBox>
           </asp:TableCell>
        </asp:TableRow>
         <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left">
                <asp:Label ID="Label12" runat="server" Text="Label">Calle</asp:Label>
            </asp:TableCell>
            <asp:TableCell Width="30">
           <asp:TextBox ID="TextBox10" runat="server" Width="150"></asp:TextBox>
           </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
        </div>
</asp:Content>
