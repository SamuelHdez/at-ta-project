<%@ Page Title="Cruises" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cruise.aspx.cs" Inherits="TopTravel.Cruise" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
    <hgroup class="title">
        <h1><%: Title %></h1>
        <h2>Look up for your cruise</h2>
    </hgroup>

    <section id="Form">

         <fieldset>
            <legend>Search your hotel</legend>

            <label>Region</label>
             <asp:DropDownList ID="region" runat="server" CssClass="input">
                <asp:ListItem Text="Africa" Value="1"></asp:ListItem>
                <asp:ListItem Text="Alaska" Value="2"></asp:ListItem>
                <asp:ListItem Text="Asia" Value="3"></asp:ListItem>
                <asp:ListItem Text="Bahamas" Value="4"></asp:ListItem>
                <asp:ListItem Text="Baltic" Value="5"></asp:ListItem>
                <asp:ListItem Text="Bermuda" Value="6"></asp:ListItem>
                <asp:ListItem Text="Canary isladns" Value="7"></asp:ListItem>
                <asp:ListItem Text="Caribbean" Value="8"></asp:ListItem>
                <asp:ListItem Text="European rivers" Value="9"></asp:ListItem>
                <asp:ListItem Text="Greece/Turkey/Black Sea" Value="10"></asp:ListItem>
                <asp:ListItem Text="Hawaii" Value="11"></asp:ListItem>
                <asp:ListItem Text="Scandinavia & Fjords" Value="12"></asp:ListItem>     
            </asp:DropDownList>

            <label>Days</label>
            <input class="input" type="number" min="0" max="20" step="1" value="7">

            <label>Departure</label>
            <asp:Calendar ID="Departure" runat="server" CssClass="inputCal">
                <TitleStyle BackColor="#353E49" BorderColor="#353E49" 
                BorderWidth="1px" Font-Bold="True"
                Font-Size="10pt" Height="25px" />
            </asp:Calendar><br />

            <label>Adults</label>
            <input class="input" type="number" min="0" max="20" step="1" value="2">

            <label>Children</label>
            <input class="input" type="number" min="0" max="20" step="1" value="0">

            <asp:Button ID="SendButton" runat="server" Text="Button" OnClick="send" CssClass="inputBottom" />
            <asp:Label id="ProcessCruise" runat="server" Text="" />
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
