<%@ Page Title="Order" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="TopTravel.History" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1>History Cart</h1>
        <h2> <%: User.Identity.Name %></h2>
    </hgroup>

    <style type="text/css">
      .hiddencol
      {
        display: none;
      }
    </style>

    <article>

        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="8" Width="100%" AutoGenerateColumns="False" CssClass="Grid" AlternatingRowStyle-CssClass="alt">
                        <columns>
                            <asp:boundfield datafield="Product" headertext="Product"/>
                            <asp:boundfield datafield="ProductName" headertext="Product Name"/>
                            <asp:boundfield datafield="Adults" headertext="Adults"/>
                            <asp:boundfield datafield="Children" headertext="Children"/>
                            <asp:TemplateField HeaderText="Price/Person">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                                    <asp:Label ID="Label2" runat="server" Text= " €"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total Price">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("TotalPrice") %>'></asp:Label>
                                    <asp:Label ID="Label4" runat="server" Text= " €"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                           
                        </columns>
                    <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
         </asp:GridView>
        <br />
        </article>

</asp:Content>