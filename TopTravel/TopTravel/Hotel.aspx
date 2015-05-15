<%@ Page Title="Hotels" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Hotel.aspx.cs" Inherits="TopTravel.Hotel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <hgroup class="title">
        <h1><%: Title %></h1>
        <h2>Look up for your hotel</h2>
    </hgroup>

    <section id="Form">
        

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
            <legend>Search your hotel</legend>

            <label>Place/hotel</label>
            <asp:TextBox id="Place2" TextMode="SingleLine" Columns="30" runat="server" CssClass="input" />

            <label>Date</label>
            <asp:Calendar ID="Date" runat="server" CssClass="inputCal">
                <TitleStyle BackColor="#353E49" BorderColor="#353E49" 
                BorderWidth="1px" Font-Bold="True"
                Font-Size="10pt" Height="25px" />
            </asp:Calendar><br />

            <label>Nights</label>
            <asp:TextBox ID="Nights" runat="server" type="number" CssClass="input" />
            <!--<input class="input" type="number" min="0" max="10" step="1" value="5">-->

            <label>Adults</label>
            <asp:TextBox ID="Adults" runat="server" type="number" CssClass="input" />

            <label>Children</label>
            <asp:TextBox ID="Children" runat="server" type="number" CssClass="input" />

            <asp:Button ID="SendButton" runat="server" Text="Send" OnClick="send" CssClass="inputBottom" />
            

             <asp:RangeValidator ID="RangeValidator1" controltovalidate="Nights" runat="server" ErrorMessage="Please enter value between 1-50 in nights." MinimumValue="1" MaximumValue="50" Type="Integer" forecolor="Red" CssClass="validator"></asp:RangeValidator>
             <asp:RangeValidator ID="RangeValidator2" controltovalidate="Adults" runat="server" ErrorMessage="Please enter value between 1-20 in adults." MinimumValue="1" MaximumValue="20" Type="Integer" forecolor="Red" CssClass="validator"></asp:RangeValidator>
             <asp:RangeValidator ID="RangeValidator3" controltovalidate="Children" runat="server" ErrorMessage="Please enter value between 1-20 in children." MinimumValue="1" MaximumValue="20" Type="Integer" forecolor="Red" CssClass="validator"></asp:RangeValidator>
            <asp:Label id="ProcessHotel" runat="server" Text="" CssClass="process" />
        </fieldset>

    </section>

    <section id="Results">
            <asp:GridView ID="GridView1" runat="server"  AllowPaging="True" PageSize="10" Width="100%" AutoGenerateColumns="False" CssClass="Grid" AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="GridView1_PageIndexChanging" >
                <columns>
                    <asp:boundfield datafield="Name" headertext="Name"/>
                    <asp:boundfield datafield="City" headertext="City"/>
                    <asp:boundfield datafield="Stars" headertext="Stars"/>
                    <asp:TemplateField HeaderText="Price/Person">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("price") %>'></asp:Label>
                        <asp:Label ID="Label2" runat="server" Text= " €"></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:hyperlinkfield text="View" navigateurl="~\Hotel.aspx" headertext="Link" target="_blank" />
                </columns>
            </asp:GridView>
    </section>



</asp:Content>
