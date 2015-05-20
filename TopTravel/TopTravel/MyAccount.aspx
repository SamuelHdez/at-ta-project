<%@ Page Title="Companies" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyAccount.aspx.cs" Inherits="TopTravel.MyAccount" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1>My account</h1>
    </hgroup>

    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="8" Width="100%" AutoGenerateColumns="False" CssClass="Grid" AlternatingRowStyle-CssClass="alt">
                <columns>
                    <asp:boundfield datafield="dni" headertext="ID"/>
                    <asp:boundfield datafield="name" headertext="Name"/>
                    <asp:boundfield datafield="surname" headertext="Surname"/>
                    <asp:boundfield datafield="phone" headertext="Phone"/>
                    <asp:boundfield datafield="address" headertext="Address"/>
                    <asp:boundfield datafield="gender" headertext="Gender"/>
                    <asp:boundfield datafield="creditCard" headertext="Credit Card"/>
                    <asp:boundfield datafield="avatar" headertext="Avatar"/>
                    
                </columns>
                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
     </asp:GridView>
      <br />
    
</asp:Content>