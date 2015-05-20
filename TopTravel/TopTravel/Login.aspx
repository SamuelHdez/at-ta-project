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

    <style type="text/css">
      .hiddencol
      {
        display: none;
      }
    </style>

    <section id="Form">

         <fieldset>
            <legend>Insert your data</legend>

            <label>ID</label>
            <asp:TextBox ID="UserName" runat="server" CssClass="input" />

            <label>Password</label>
            <asp:TextBox ID="pass" runat="server" CssClass="input" />

            <asp:Button ID="SendButton" runat="server" Text="Send" OnClick="send" CssClass="inputBottom" />

        </fieldset>

    </section>

    <section id="Results">
        <hgroup class="title">
            <h1>Register</h1>
            <h2>Look up for your hotel</h2>
        </hgroup>
        
            <label>ID</label>
            <asp:TextBox ID="dniR" runat="server" CssClass="input" />

            <label>Name</label>
            <asp:TextBox ID="nameR" runat="server" CssClass="input" />
            
            <label>Surname</label>
            <asp:TextBox ID="surnameR" runat="server" CssClass="input" />

            <label>Phone</label>
            <asp:TextBox ID="phoneR" runat="server" CssClass="input" />

            <label>Address</label>
            <asp:TextBox ID="addressR" runat="server" CssClass="input" />

             <asp:RadioButtonList ID="gender" runat="server" CssClass="radioButtonList2">
                   <asp:ListItem>Male</asp:ListItem> 
                   <asp:ListItem>Female</asp:ListItem>
             </asp:RadioButtonList>

            <label>Credit Card</label>
            <asp:TextBox ID="cardR" runat="server" CssClass="input" />

            <label>Password</label>
            <asp:TextBox ID="passR" runat="server" CssClass="input" />

            <label>Avatar (Link)</label>
            <asp:TextBox ID="avatarR" runat="server" CssClass="input" />

            <asp:Button ID="Button1" runat="server" Text="Register" OnClick="sendR" CssClass="inputBottom" />
    </section>

</asp:Content>

