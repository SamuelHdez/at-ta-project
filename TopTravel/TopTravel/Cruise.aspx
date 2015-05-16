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

    <section id="Form">

         <fieldset>
            <legend>Search your hotel</legend>

            <label>Region</label>
             <asp:DropDownList ID="region" runat="server" CssClass="input">
                <asp:ListItem Text="Africa" Value="Africa"></asp:ListItem>
                <asp:ListItem Text="Alaska" Value="Alaska"></asp:ListItem>
                <asp:ListItem Text="Asia" Value="Asia"></asp:ListItem>
                <asp:ListItem Text="Bahamas" Value="Bahamas"></asp:ListItem>
                <asp:ListItem Text="Baltic" Value="Baltic"></asp:ListItem>
                <asp:ListItem Text="Bermuda" Value="Bermuda"></asp:ListItem>
                <asp:ListItem Text="Canary islands" Value="Canary islands"></asp:ListItem>
                <asp:ListItem Text="Caribbean" Value="Caribbean"></asp:ListItem>
                <asp:ListItem Text="European rivers" Value="European rivers"></asp:ListItem>
                <asp:ListItem Text="Greece/Turkey/Black Sea" Value="Greece/Turkey/Black Sea"></asp:ListItem>
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
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="8" Width="100%" AutoGenerateColumns="False" CssClass="Grid" AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="GridView1_PageIndexChanging">
                <columns>
                    <asp:boundfield datafield="city" headertext="Departure"/>
                    <asp:boundfield datafield="route" headertext="Route"/>
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


</asp:Content>
