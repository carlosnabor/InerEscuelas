<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="InerEscuelas._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron" >
        <h1 >  
            <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/Iner gobierno.jpg" />
            <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Iner.png" /> 
        </h1>        
    </div>

    <div class="row">
         <div class="col-md-4">
            <h2>Bienvenido al sitio de inscripciones a las escuelas del INER</h2>
             
        </div>
        <div class="col-md-4">
            <h2>ENSEÑANZA<span>&nbsp;</span></h2>
            <p>
                El Instituto Nacional de Enfermedades Respiratorias Ismael Cosío Villegas (INER) se caracteriza por mantener un reconocido prestigio a nivel nacional e internacional en el campo de la medicina respiratoria</p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Inscripciones</h2>
            <p>
                Periodo 2017</p>
            <p>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Catalogos/WfSolicitud.aspx" ToolTip="Ir a la captura de solicitud">Escuela de Enfermeria</asp:HyperLink>
            </p>
            <p>
                .- Escuela de Inaloterapia</p>
            <p>
                .- Escuela C</p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Inscribirme &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>
                <asp:Table ID="Table1" runat="server" CaptionAlign="Top">
                    <asp:TableRow HorizontalAlign="Center">
                        <asp:TableCell >
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/ensenanza2017.jpg" />
                <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/entrenamiento.png" />
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                
            </h2>
        </div>
    </div>

</asp:Content>
