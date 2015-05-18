﻿<%@ Page Title="Flights" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Flight.aspx.cs" Inherits="TopTravel.Flight" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1><%: Title %></h1>
        <h2>Look up for your flight</h2>
    </hgroup>

    <style type="text/css">
      .hiddencol
      {
        display: none;
      }
    </style>

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
             <legend>Search your flight</legend>


            <!--<asp:Label ID="Label2" runat="server" Text="Label">Flying from: </asp:Label>--><label>From</label>
            <asp:TextBox id="from" TextMode="SingleLine" Columns="30" runat="server" CssClass="input" />

            <!--<asp:Label ID="Label3" runat="server" Text="Label">Going to:</asp:Label>--><label>Going to</label>
            <asp:TextBox id="to" TextMode="SingleLine" Columns="30" runat="server" CssClass="input" />

            <!--<asp:Label ID="Label4" runat="server" Text="Label">Outbound:</asp:Label>--><label>Outbound</label>
            <asp:Calendar ID="FechaIda" runat="server" CssClass="inputCal">
                <TitleStyle BackColor="#353E49" BorderColor="#353E49" 
                BorderWidth="1px" Font-Bold="True"
                Font-Size="10pt" Height="25px" />
            </asp:Calendar><br />

            <!--<asp:CheckBox ID="VueltaCheck" runat="server" />-->
            <!--<asp:Label ID="Label5" runat="server" Text="Label">Return:</asp:Label>--><label>Return</label>
            <asp:Calendar ID="FechaVuelta" runat="server" CssClass="inputCal">
                <TitleStyle BackColor="#353E49" BorderColor="#353E49" 
                BorderWidth="1px" Font-Bold="True"
                Font-Size="10pt" Height="25px" />
            </asp:Calendar><br />

            <asp:Button ID="SendButton" runat="server" Text="Send" OnClick="send" CssClass="inputBottom" />
            <asp:Label id="ProcessVuelo" runat="server" Text="" CssClass="process" />
        </fieldset>

    </section>

    <section id="Results">
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="8" Width="100%" AutoGenerateColumns="False" AutoGenerateSelectButton="true" CssClass="Grid" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="GridView1_PageIndexChanging">
                <columns>
                    <asp:boundfield datafield="departureCity" headertext="Departure"/>
                    <asp:boundfield datafield="destinationCity" headertext="Destination"/>
                    <asp:boundfield datafield="ClassFlight" headertext="class"/>
                    <asp:boundfield datafield="company" headertext="Company" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
                    <asp:boundfield datafield="extras" headertext="Extras" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
                    <asp:TemplateField HeaderText="Price/Person">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("price") %>'></asp:Label>
                            <asp:Label ID="Label3" runat="server" Text= " €"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </columns>
                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
            </asp:GridView>
    </section>

    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" PageSize="8" Width="100%" AutoGenerateColumns="False" CssClass="Grid" AlternatingRowStyle-CssClass="alt">
                <columns>
                    <asp:boundfield datafield="departureCity" headertext="Departure"/>
                    <asp:boundfield datafield="destinationCity" headertext="Destination"/>
                    <asp:boundfield datafield="ClassFlight" headertext="class"/>
                    <asp:TemplateField HeaderText="Price/Person">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("price") %>'></asp:Label>
                            <asp:Label ID="Label2" runat="server" Text= " €"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Adults">
                        <ItemTemplate>
                            <asp:TextBox ID="adults" runat="server" type="number" min="1" max="20" step="1" value="1"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Children">
                        <ItemTemplate>
                            <asp:TextBox ID="children" runat="server" type="number" min="0" max="20" step="1" value="0"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>                      
                </columns>
                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
            </asp:GridView>

    <asp:GridView ID="GridView3" runat="server" Width="100%" AutoGenerateColumns="False" CssClass="Grid" AlternatingRowStyle-CssClass="alt">
                <Columns>
                    <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Bind("image") %>' Width="450"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
    </asp:GridView>

     <asp:GridView ID="GridView4" runat="server" Width="100%" AutoGenerateColumns="False" CssClass="Grid" AlternatingRowStyle-CssClass="alt">
                <Columns>
                    <asp:boundfield datafield="Name" headertext="Company"/>
                </Columns>
    </asp:GridView>

     <asp:GridView ID="GridView5" runat="server" Width="100%" AutoGenerateColumns="False" CssClass="Grid" AlternatingRowStyle-CssClass="alt">
                <Columns>
                    <asp:boundfield datafield="Wifi" headertext="Wifi"/>
                    <asp:boundfield datafield="Food" headertext="Food"/>
                    <asp:boundfield datafield="Discount" headertext="Discount"/>
                </Columns>
    </asp:GridView>

     <asp:LoginView ID="LoginView1" runat="server" ViewStateMode="Disabled" Visible="false">
        <AnonymousTemplate>      
            <asp:Button ID="ButtonLogin" runat="server" Text="Login" OnClick="SendButtonLogin" CssClass="inputBottom" />
        </AnonymousTemplate>
        <LoggedInTemplate>
            <asp:Button ID="ButtonBuy" runat="server" Text="Buy" OnClick="SendButtonBuy" CssClass="inputBottom" />
        </LoggedInTemplate>
     </asp:LoginView>  

</asp:Content>