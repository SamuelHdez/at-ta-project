<%@ Page Title="Companies" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Companies.aspx.cs" Inherits="TopTravel.Companies" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Our Partners.<br />
        </h2>
    </hgroup>

    <div>

        <asp:RadioButtonList ID="typeCompany" runat="server" OnSelectedIndexChanged="radioChange" AutoPostBack="True">
            <asp:ListItem Value="">All</asp:ListItem> 
            <asp:ListItem Value="Hotel">Hotel</asp:ListItem>
            <asp:ListItem Value="Cruise company">Cruise</asp:ListItem>
            <asp:ListItem Value="Flight company">Flight</asp:ListItem>
            <asp:ListItem Value="Bus service">Bus</asp:ListItem>
            <asp:ListItem Value="Train company">Train</asp:ListItem>
            <asp:ListItem Value="Car rental">Car Rental</asp:ListItem>
            <asp:ListItem Value="Space Travel">Space Travel</asp:ListItem>
        </asp:RadioButtonList>
        <br />

    </div>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="8" Width="100%" AutoGenerateColumns="False" CssClass="Grid" AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="GridView1_PageIndexChanging">
                <columns>
                    <asp:boundfield datafield="Name" headertext="Name"/>
                    <asp:boundfield datafield="Type" headertext="Type"/>
                    <asp:boundfield datafield="Phone" headertext="Phone"/>
                    <asp:boundfield datafield="Email" headertext="Email"/>
                    <asp:boundfield datafield="Country" headertext="Country"/>
                    <asp:boundfield datafield="Website" headertext="Website"/>
                    <asp:boundfield datafield="Description" headertext="Description"/>
                    
                </columns>
                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
     </asp:GridView>

    
</asp:Content>