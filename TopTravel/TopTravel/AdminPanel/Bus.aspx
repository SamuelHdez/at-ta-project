﻿<%@ Page Title="Bus Admin" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bus.aspx.cs" Inherits="TopTravel.BusAdmin" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Control Panel.<br />
        </h2>
    </hgroup>
    <div>
       <div>
        <asp:RadioButtonList ID="typeAdmin" runat="server" OnSelectedIndexChanged="radioChange" AutoPostBack="True" RepeatDirection="Horizontal" CssClass="radioButtonList">
            <asp:ListItem Value="Hotel">Hotel</asp:ListItem>
            <asp:ListItem Value="Cruise">Cruise</asp:ListItem>
            <asp:ListItem Value="Flight">Flight</asp:ListItem>
            <asp:ListItem Value="Bus">Bus</asp:ListItem>
            <asp:ListItem Value="Train">Train</asp:ListItem>
            <asp:ListItem Value="CarRental">Car Rental</asp:ListItem>
            <asp:ListItem Value="SpaceTravel">Space Travel</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False" CssClass="Grid" AlternatingRowStyle-CssClass="alt" AutoGenerateSelectButton="true" AutoGenerateDeleteButton="true" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDeleting="GridView1_RowDeleting" >
                <columns>
                    <asp:boundfield datafield="Id" headertext="ID"/>
                    <asp:boundfield datafield="departureTime" headertext="Departure Time"/>
                    <asp:boundfield datafield="arrivaldTime" headertext="Arrival Time"/>
                    <asp:boundfield datafield="departureCity" headertext="Departure"/>     
                    <asp:boundfield datafield="destinationCity" headertext="Destination"/>
                    <asp:boundfield datafield="price" headertext="Price"/>
                    <asp:boundfield datafield="company" headertext="Company"/>
                    <asp:boundfield datafield="extras" headertext="Extras"/>   
                    <asp:boundfield datafield="image" headertext="Image"/>      
                </columns>
                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
     </asp:GridView>
        <br />
        <div>
          <label>ID</label>
            <asp:TextBox id="idC" TextMode="SingleLine" Columns="30" runat="server" CssClass="input" />
          <label>Departure Time</label>
            <asp:TextBox id="depTime" TextMode="SingleLine" Columns="30" runat="server" CssClass="input" />
           <label>Arrival Time</label>
            <asp:TextBox id="arTime" TextMode="SingleLine" Columns="30" runat="server" CssClass="input" />
           <label>Departure City</label>
            <asp:TextBox id="depCi" TextMode="SingleLine" Columns="30" runat="server" CssClass="input" />
            <label>Destination City</label>
            <asp:TextBox id="desCi" TextMode="SingleLine" Columns="30" runat="server" CssClass="input" />
            <label>Price</label>
            <asp:TextBox id="priceB" TextMode="SingleLine" Columns="30" runat="server" CssClass="input" />
           <label>Company</label>
            <asp:TextBox id="companyB" TextMode="SingleLine" Columns="30" runat="server" CssClass="input" />
           <label>Extras</label>
            <asp:TextBox id="extrasB" TextMode="SingleLine" Columns="30" runat="server" CssClass="input" />
           <label>Image</label>
            <asp:TextBox id="img" TextMode="SingleLine" Columns="30" runat="server" CssClass="input" />
          <asp:Button ID="EditButton" runat="server" Text="Edit" OnClick="GridView1_sendUpdate" CssClass="inputBottom" />
          <asp:Button ID="InsertButton" runat="server" Text="Insert" OnClick="sendInsert" CssClass="inputBottom" />
      </div>
    
    </div>
    </div>
</asp:Content>