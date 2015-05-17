<%@ Page Title="Flight Admin" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cruise.aspx.cs" Inherits="TopTravel.AdminPanel.Cruise" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Control Panel.<br />
        </h2>
    </hgroup>
    <div>
       <div>
        <asp:RadioButtonList ID="typeAdmin" runat="server" OnSelectedIndexChanged="radioChange" AutoPostBack="True">
            <asp:ListItem Value="Hotel">Hotel</asp:ListItem>
            <asp:ListItem Value="Cruise">Cruise</asp:ListItem>
            <asp:ListItem Value="Flight">Flight</asp:ListItem>
            <asp:ListItem Value="Bus">Bus</asp:ListItem>
            <asp:ListItem Value="Train">Train</asp:ListItem>
            <asp:ListItem Value="CarRental">Car Rental</asp:ListItem>
            <asp:ListItem Value="SpaceTravel">Space Travel</asp:ListItem>
        </asp:RadioButtonList>
        <br />
     <asp:GridView ID="GridView1" runat="server" AllowPaging="True" Width="100%" AutoGenerateColumns="False" CssClass="Grid" AlternatingRowStyle-CssClass="alt">
                <columns>
                    <asp:boundfield datafield="departureTime" headertext="Departure Time"/>
                    <asp:boundfield datafield="arrivalTime" headertext="Arrival Time"/>
                    <asp:boundfield datafield="City" headertext="Departure"/>     
                    <asp:boundfield datafield="Route" headertext="Route"/>
                    <asp:boundfield datafield="price" headertext="Price"/>
                    <asp:boundfield datafield="company" headertext="Company"/>
                    <asp:boundfield datafield="extras" headertext="Extras"/>         
                </columns>
                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
     </asp:GridView>    
    </div>
    </div>
</asp:Content>