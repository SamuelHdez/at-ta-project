﻿<%@ Page Title="Order" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="TopTravel.Order" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2> <%: User.Identity.Name %></h2>
    </hgroup>

    <article>
          <asp:LoginView ID="LoginView1" runat="server" ViewStateMode="Disabled">
               <AnonymousTemplate>
                    <p>        
                     NO está logueqado
                    </p>
                   </AnonymousTemplate>
               <LoggedInTemplate>
                    <p>        
                    <h1>Shopping Cart</h1>
                    </p>
               </LoggedInTemplate>
              </asp:LoginView>

        <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False" CssClass="Grid" AlternatingRowStyle-CssClass="alt" AutoGenerateDeleteButton="true" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                        <columns>
                            <asp:boundfield datafield="Product" headertext="Product"/>
                            <asp:boundfield datafield="ProductName" headertext="Product Name"/>
                            <asp:boundfield datafield="Adults" headertext="Adults"/>
                            <asp:boundfield datafield="Children" headertext="Children"/>
                            <asp:boundfield datafield="Price" headertext="Price/Person €"/>
                            <asp:boundfield datafield="TotalPrice" headertext="Total Price €"/> 
                            <asp:buttonfield buttontype="Button" CommandName="select" headertext="Buy product" text="Confirm and buy"/>
                        </columns>
                    <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
         </asp:GridView>


        <asp:LoginView ID="LoginView2" runat="server" ViewStateMode="Disabled">
               <AnonymousTemplate>
                   
                   </AnonymousTemplate>
               <LoggedInTemplate>
                    <p>        
                    <h1>Shopping History</h1>
                    </p>
               </LoggedInTemplate>
        </asp:LoginView>

        <asp:GridView ID="GridView2" runat="server" AllowPaging="True" PageSize="8" Width="100%" AutoGenerateColumns="False" CssClass="Grid" AlternatingRowStyle-CssClass="alt">
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
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("TotalPrice") %>'></asp:Label>
                                    <asp:Label ID="Label2" runat="server" Text= " €"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                           
                        </columns>
                    <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
         </asp:GridView>
        
    </article>

</asp:Content>