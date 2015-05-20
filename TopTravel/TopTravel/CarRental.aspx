<%@ Page Title="Trains" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CarRental.aspx.cs" Inherits="TopTravel.CarRental" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1><%: Title %></h1>
        <h2>Look up for your Car</h2>
    </hgroup>

    <style type="text/css">
      .hiddencol
      {
        display: none;
      }
    </style>
    <section id="Form">
         <fieldset>
             <legend>Search your Car</legend>


            <!--<asp:Label ID="Label2" runat="server" Text="Label">Flying from: </asp:Label>--><label>City</label>
            <asp:TextBox id="from" TextMode="SingleLine" Columns="30" runat="server" CssClass="input" />

             <label>Brand</label>
            <asp:TextBox id="brandcar" TextMode="SingleLine" Columns="30" runat="server" CssClass="input" />

            <!--<asp:Label ID="Label4" runat="server" Text="Label">Outbound:</asp:Label>--><label>Calendar</label>
            <asp:Calendar ID="cal" runat="server" CssClass="inputCal">
                <TitleStyle BackColor="#353E49" BorderColor="#353E49" 
                BorderWidth="1px" Font-Bold="True"
                Font-Size="10pt" Height="25px" />
            </asp:Calendar><br />

            <!--<asp:CheckBox ID="VueltaCheck" runat="server" />-->
            <!--<asp:Label ID="Label5" runat="server" Text="Label">Return:</asp:Label>--><label>Return</label>
            <asp:Calendar ID="FechaVuelta" runat="server" CssClass="inputCal">
                <TitleStyle BackColor="#353E49" BorderColor="#353E49" 
                BorderWidth="1px" Font-Bold="True"
                Font-Size="10pt" Height="25px" />
            </asp:Calendar><br />

            <asp:Button ID="SendButton" runat="server" Text="Send" OnClick="send" CssClass="inputBottom" />
            
             <asp:Label id="ProcessVuelo" runat="server" Text="" CssClass="process" />
        </fieldset>

    </section>

    <section id="Results">
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="8" Width="100%" AutoGenerateColumns="False" AutoGenerateSelectButton="true" CssClass="Grid" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="GridView1_PageIndexChanging">
                <columns>
                    <asp:boundfield datafield="City" headertext="City"/>
                    <asp:boundfield datafield="Brand" headertext="Brand"/>
                    <asp:boundfield datafield="Model" headertext="Model"/>
                    <asp:boundfield datafield="company" headertext="Company" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
                    <asp:boundfield datafield="extras" headertext="Extras" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
                    <asp:boundfield datafield="Id" headertext="ID" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
                    <asp:TemplateField HeaderText="Price">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("price") %>'></asp:Label>
                            <asp:Label ID="Label3" runat="server" Text= " €"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </columns>
                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
            </asp:GridView>
    </section>

     <hgroup class="title">
       <h1><asp:Label ID="Label10" runat="server" Text="Flights" Visible="false"></asp:Label></h1> 
       <h2><asp:Label ID="Label11" runat="server" Text="Details" Visible="false"></asp:Label></h2> 
    </hgroup>

    <section id="GBTop">
    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" PageSize="8" Width="100%" AutoGenerateColumns="False" CssClass="Grid" AlternatingRowStyle-CssClass="alt">
                <columns>
                    <asp:boundfield datafield="City" headertext="City"/>
                    <asp:boundfield datafield="Brand" headertext="Brand"/>
                    <asp:boundfield datafield="Model" headertext="Model"/>
                    <asp:boundfield datafield="Days" headertext="Days"/>
                    <asp:boundfield datafield="Id" headertext="ID" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
                    <asp:boundfield datafield="price" headertext="pricebuy" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
                    <asp:TemplateField HeaderText="Price">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("price") %>'></asp:Label>
                            <asp:Label ID="Label2" runat="server" Text= " €"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>           
                </columns>
                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
            </asp:GridView>
    </section>

    <section id="GBHalf">
    <asp:GridView ID="GridView3" runat="server" Width="100%" AutoGenerateColumns="False" CssClass="Grid" AlternatingRowStyle-CssClass="alt">
                <Columns>
                    <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Bind("image") %>' Width="100%"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
    </asp:GridView>
    </section><section id="GBHalf">
        <asp:GridView ID="GridView4" runat="server" Width="100%" AutoGenerateColumns="False" CssClass="Grid" AlternatingRowStyle-CssClass="alt">
            <Columns>
                <asp:boundfield datafield="Name" headertext="Company"/>
            </Columns>
        </asp:GridView>

        <section id="GBLast">
        <asp:GridView ID="GridView5" runat="server" Width="100%" AutoGenerateColumns="False" CssClass="Grid" AlternatingRowStyle-CssClass="alt">
            <Columns>
                <asp:boundfield datafield="Wifi" headertext="Wifi"/>
                <asp:boundfield datafield="Food" headertext="Food"/>
                <asp:boundfield datafield="Discount" headertext="Discount"/>
            </Columns>
        </asp:GridView>
        </section>
                <asp:Button ID="ButtonLogin" runat="server" Text="Login" OnClick="SendButtonLogin" CssClass="inputBottom" />
                <asp:Button ID="ButtonBuy" runat="server" Text="Buy" OnClick="SendButtonBuy" CssClass="inputBottom" />
    </section>  

</asp:Content>