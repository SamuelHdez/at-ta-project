<%@ Page Title="Companies" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyAccount.aspx.cs" Inherits="TopTravel.MyAccount" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1>My account</h1>
    </hgroup>

    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="8" Width="100%" AutoGenerateColumns="False" CssClass="Grid" AlternatingRowStyle-CssClass="alt" AutoGenerateSelectButton="true" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <columns>
                    <asp:boundfield datafield="dni" headertext="ID"/>
                    <asp:boundfield datafield="name" headertext="Name"/>
                    <asp:boundfield datafield="surname" headertext="Surname"/>
                    <asp:boundfield datafield="phone" headertext="Phone"/>
                    <asp:boundfield datafield="address" headertext="Address"/>
                    <asp:boundfield datafield="gender" headertext="Gender"/>
                    <asp:boundfield datafield="creditCard" headertext="Credit Card"/>
                </columns>
                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
     </asp:GridView>
      <br />
     <asp:GridView ID="GridView2" runat="server" Width="100%" AutoGenerateColumns="False" CssClass="Grid" AlternatingRowStyle-CssClass="alt">
                <Columns>
                    <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Bind("avatar") %>' Width="350"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
    </asp:GridView>
    <br />

    <label>name</label>
    <asp:TextBox ID="nameChange" runat="server" CssClass="input" />

    <label>Surname</label>
    <asp:TextBox ID="surnameChange" runat="server" CssClass="input" />

    <label>Phone</label>
    <asp:TextBox ID="phoneChange" runat="server" CssClass="input" />

    <label>Address</label>
    <asp:TextBox ID="addressChange" runat="server" CssClass="input" />

    <label>Credit Card</label>
    <asp:TextBox ID="creditCardChange" runat="server" CssClass="input" />

    <label>Confirm Password</label>
    <asp:TextBox ID="passwordConfirm" runat="server" CssClass="input" />

    <asp:Button ID="SendButton" runat="server" Text="Update" OnClick="send" CssClass="inputBottom" />

    
</asp:Content>