<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TopTravel.prueba" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <hgroup class="title">
        <h1><%: Title %></h1>
        <h2>Introduce your data</h2>
    </hgroup>

    <section id="loginForm">

         <fieldset>
            <legend>Insert your data</legend>

            <label>ID</label>
            <asp:TextBox ID="UserName" runat="server" CssClass="input" />

            <label>Password</label>
            <asp:TextBox ID="pass" TextMode="password" runat="server" CssClass="input" />

            <asp:Button ID="SendButton" runat="server" Text="Login" OnClick="send" CssClass="inputBottom" />
         </fieldset>

    </section>

    <section id="LoginResults">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="You must introdude an ID." ControlToValidate="UserName" forecolor="Red" CssClass="validator"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="You must introdude a password." ControlToValidate="pass" forecolor="Red" CssClass="validator"></asp:RequiredFieldValidator>
    </section>
    <br /><br /><br /><br /><br /><br />

</asp:Content>

