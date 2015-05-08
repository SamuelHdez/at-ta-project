<%@ Page Title="Flights" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Flight.aspx.cs" Inherits="TopTravel.Flight" %>




<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>





<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1><%: Title %></h1>
    </hgroup>

    <section id="Form">
        <h3>Estas dentro de vuelos</h3>

        <!--<ol class="round">
            <li class="one">
                <h5>Introducción</h5>
                Los formularios Web Forms de ASP.NET permiten crear sitios web dinámicos mediante modelos basados en eventos y de arrastrar y colocar.
                La superficie de diseño y los cientos de controles y componentes permiten crear rápidamente sitios sofisticados y controlados mediante UI con acceso de datos.
                <a href="http://go.microsoft.com/fwlink/?LinkId=245146">Más información…</a>
            </li>
            <li class="two">
                <h5>Agregar paquetes NuGet y poner en marcha su codificación</h5>
                NuGet facilita la instalación y actualización de herramientas y bibliotecas gratuitas.
                <a href="http://go.microsoft.com/fwlink/?LinkId=245147">Más información…</a>
            </li>
            <li class="three">
                <h5>Buscar hospedaje de sitios web</h5>
                Encuentre fácilmente empresas de alojamiento web que ofrezcan la mejor relación de características y precio para sus aplicaciones.
                <a href="http://go.microsoft.com/fwlink/?LinkId=245143">Más información…</a>
            </li>
        </ol>-->



         <fieldset>
             <legend>Search your flight</legend>


            <!--<asp:Label ID="Label2" runat="server" Text="Label">Flying from: </asp:Label>--><label>From</label>
            <asp:TextBox id="userTextBox" TextMode="SingleLine" Columns="30" runat="server" CssClass="input" />

            <!--<asp:Label ID="Label3" runat="server" Text="Label">Going to:</asp:Label>--><label>Going to</label>
            <asp:TextBox id="TextBox1" TextMode="SingleLine" Columns="30" runat="server" CssClass="input" />

            <!--<asp:Label ID="Label4" runat="server" Text="Label">Outbound:</asp:Label>--><label>Outbound</label>
            <asp:Calendar ID="FechaIda" runat="server" CssClass="input"></asp:Calendar>
             <br />

            <!--<asp:CheckBox ID="VueltaCheck" runat="server" />-->
            <!--<asp:Label ID="Label5" runat="server" Text="Label">Return:</asp:Label>--><label>Return</label>
            <asp:Calendar ID="FechaVuelta" runat="server" CssClass="input"></asp:Calendar>
             <br />

            <!--<asp:Label ID="Label6" runat="server" Text="Label">Adults:</asp:Label>--><label>Adults</label>
            <input class="input" type="number" min="0" max="20" step="1" value="1">


            <!--<asp:Label ID="Label7" runat="server" Text="Label">Children:</asp:Label>--><label>Children</label>
            <input class="input" type="number" min="0" max="20" step="1" value="0">

            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="aaaa" CssClass="inputBottom" />
            <asp:Label id="Label1" runat="server" Text="Label" />
        </fieldset>

    </section>

    <section id="Results">
            <div class="app">
                <img src="images/cities/Berlin.jpg" height=100% width=100%>
                <div class="footerImg">
                    <div class="place">Berl&iacute;n</div>
                    <div class="price">120 &euro;</div>
                </div>
            </div>
            <div class="app">
                <img src="images/cities/Florence.jpg" height=100% width=100%>
                <div class="footerImg">
                    <div class="place">Florence</div>
                    <div class="price">90 &euro;</div>
                </div>
            </div>
            <div class="app">
                <img src="images/cities/Istanbul.jpg" height=100% width=100%>
                <div class="footerImg">
                    <div class="place">Istanbul</div>
                    <div class="price">60 &euro;</div>
                </div>
            </div>
            <div class="app">
                <img src="images/cities/New-York.jpg" height=100% width=100%>
                <div class="footerImg">
                    <div class="place">New York</div>
                    <div class="price">200 &euro;</div>
                </div>
            </div>
    </section>

</asp:Content>