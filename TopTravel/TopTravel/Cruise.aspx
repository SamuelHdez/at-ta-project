<%@ Page Title="Cruises" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cruise.aspx.cs" Inherits="TopTravel.Cruise" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
    <hgroup class="title">
        <h1><%: Title %></h1>
        <h2>Look up for your cruise</h2>
    </hgroup>

    <style type="text/css">
      .hiddencol
      {
        display: none;
      }
    </style>
    <section id="Form">

         <fieldset>
            <legend>Search your hotel</legend>

            <label>Region</label>
             <asp:DropDownList ID="region" runat="server" CssClass="input">
                <asp:ListItem Text="All" Value=""></asp:ListItem>
                <asp:ListItem Text="Mediterranean" Value="Mediterranean"></asp:ListItem>
                <asp:ListItem Text="Asia" Value="Asia"></asp:ListItem>
                <asp:ListItem Text="Bahamas" Value="Bahamas"></asp:ListItem>
                <asp:ListItem Text="Baltic" Value="Baltic"></asp:ListItem>
                <asp:ListItem Text="Bermuda" Value="Bermuda"></asp:ListItem>
                <asp:ListItem Text="Canary islands" Value="Canary islands"></asp:ListItem>
                <asp:ListItem Text="Caribbean" Value="Caribbean"></asp:ListItem>
                <asp:ListItem Text="Hawaii" Value="Hawaii"></asp:ListItem>
                <asp:ListItem Text="Scandinavia & Fjords" Value="Scandinavia & Fjords"></asp:ListItem> 
                     
            </asp:DropDownList>

            <!--<asp:Label ID="Label2" runat="server" Text="Label">Flying from: </asp:Label>--><label>City</label>
            <asp:TextBox id="dep" TextMode="SingleLine" Columns="30" runat="server" CssClass="input" />

            <label>Days</label>
            <input class="input" type="number" min="0" max="20" step="1" value="7">

            <label>Departure</label>
            <asp:Calendar ID="Departure" runat="server" CssClass="inputCal">
                <TitleStyle BackColor="#353E49" BorderColor="#353E49" 
                BorderWidth="1px" Font-Bold="True"
                Font-Size="10pt" Height="25px" />
            </asp:Calendar><br />

            <label>Adults</label>
            <input class="input" type="number" min="0" max="20" step="1" value="2">

            <label>Children</label>
            <input class="input" type="number" min="0" max="20" step="1" value="0">

            <asp:Button ID="SendButton" runat="server" Text="Button" OnClick="send" CssClass="inputBottom" />
            <asp:Label id="ProcessCruise" runat="server" Text="" />
        </fieldset>

    </section>

    <section id="Results">
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="8" Width="100%" AutoGenerateColumns="False" CssClass="Grid" AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="GridView1_PageIndexChanging" AutoGenerateSelectButton="true" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <columns>
                    <asp:boundfield datafield="city" headertext="Departure"/>
                    <asp:boundfield datafield="route" headertext="Route"/>
                    <asp:boundfield datafield="company" headertext="Company" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
                    <asp:boundfield datafield="extras" headertext="Extras" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
                    <asp:boundfield datafield="Id" headertext="Id" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
                    <asp:TemplateField HeaderText="Price/Person">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("price") %>'></asp:Label>
                        <asp:Label ID="Label2" runat="server" Text= " €"></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:hyperlinkfield text="View" navigateurl="~\Cruise.aspx" headertext="Link" target="_blank" />
                </columns>
                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
            </asp:GridView>
    </section>

<hgroup class="title">
       <h1><asp:Label ID="Label10" runat="server" Text="Hotels" Visible="false"></asp:Label></h1> 
       <h2><asp:Label ID="Label11" runat="server" Text="Details" Visible="false"></asp:Label></h2> 
    </hgroup>

    <section id="GBTop">
    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" PageSize="8" Width="100%" AutoGenerateColumns="False" CssClass="Grid" AlternatingRowStyle-CssClass="alt">
                <columns>
                    <asp:boundfield datafield="departureTime" headertext="Departure"/>
                    <asp:boundfield datafield="arrivalTime" headertext="Arrival"/>
                    <asp:boundfield datafield="City" headertext="City"/>
                    <asp:boundfield datafield="Route" headertext="Route"/>
                    <asp:TemplateField HeaderText="Price/Person">
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
    
        <asp:LoginView ID="LoginView1" runat="server" ViewStateMode="Disabled" Visible="false">
            <AnonymousTemplate>      
                <asp:Button ID="ButtonLogin" runat="server" Text="Login" OnClick="SendButtonLogin" CssClass="inputBottom" />
            </AnonymousTemplate>
            <LoggedInTemplate>
                <asp:Button ID="ButtonBuy" runat="server" Text="Buy" OnClick="SendButtonBuy" CssClass="inputBottom" />
            </LoggedInTemplate>
        </asp:LoginView>
    </section>  

</asp:Content>