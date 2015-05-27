<%@ Page Title="Buses" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bus.aspx.cs" Inherits="TopTravel.Bus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1><%: Title %></h1>
        <h2>Look up for your bus</h2>
    </hgroup>

    <style type="text/css">
      .hiddencol
      {
        display: none;
      }
    </style>
    <section id="Form">
         <fieldset>
             <legend>Search your bus</legend>


            <!--<asp:Label ID="Label2" runat="server" Text="Label">Flying from: </asp:Label>-->
             <asp:Label runat="server" ID="FromText" CssClass="aspLabel">From</asp:Label>
            <asp:TextBox id="from" TextMode="SingleLine" Columns="30" runat="server" CssClass="input" />

             <br />
            <!--<asp:Label ID="Label3" runat="server" Text="Label">Going to:</asp:Label>-->
             <asp:Label runat="server" ID="toText" CssClass="aspLabel">Going to</asp:Label>
            <asp:TextBox id="to" TextMode="SingleLine" Columns="30" runat="server" CssClass="input" />

             <br />
            <asp:Button ID="SendButton" runat="server" Text="Search" OnClick="send" CssClass="inputBottom" />

        </fieldset>

    </section>

    <section id="Results">
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="8" Width="100%" AutoGenerateColumns="False" AutoGenerateSelectButton="true" CssClass="Grid" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="GridView1_PageIndexChanging">
                <columns>
                    <asp:boundfield datafield="departureCity" headertext="Departure"/>
                    <asp:boundfield datafield="destinationCity" headertext="Destination"/>
                    <asp:boundfield datafield="company" headertext="Company" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
                    <asp:boundfield datafield="extras" headertext="Extras" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
                    <asp:boundfield datafield="Id" headertext="ID" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
                    <asp:TemplateField HeaderText="Price/Person">
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
       <h1><asp:Label ID="Label10" runat="server" Text="Buses" Visible="false"></asp:Label></h1> 
       <h2><asp:Label ID="Label11" runat="server" Text="Details" Visible="false"></asp:Label></h2> 
    </hgroup>

    <section id="GBTop">
    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" PageSize="8" Width="100%" AutoGenerateColumns="False" CssClass="Grid" AlternatingRowStyle-CssClass="alt">
                <columns>
                    <asp:boundfield datafield="departureCity" headertext="Departure"/>
                    <asp:boundfield datafield="destinationCity" headertext="Destination"/>
                    <asp:boundfield datafield="departureTime" headertext="Deperture Time"/>
                    <asp:boundfield datafield="arrivaldTime" headertext="Arrival Time"/>
                    <asp:boundfield datafield="Id" headertext="ID" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
                    <asp:boundfield datafield="price" headertext="pricebuy" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
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

         <br />

            <asp:Label ID="LAdults" runat="server" Text="Adults" Visible="false" CssClass="aspLabel"></asp:Label>
            <asp:TextBox ID="Adults" runat="server" CssClass="input" Visible="false" />

            <br />

            <asp:Label ID="LChildren" runat="server" Text="Children" Visible="false" CssClass="aspLabel"></asp:Label>
            <asp:TextBox ID="Children" runat="server" CssClass="input" Visible="false" />


            <asp:RangeValidator ID="RangeValidator2" controltovalidate="Adults" validationgroup="2" runat="server" ErrorMessage="Please enter value between 0-20 in adults." MinimumValue="0" MaximumValue="20" Type="Integer" forecolor="Red" CssClass="validator" Display="None"></asp:RangeValidator>
            <asp:RangeValidator ID="RangeValidator3" controltovalidate="Children" validationgroup="2" runat="server" ErrorMessage="Please enter value between 0-20 in children." MinimumValue="0" MaximumValue="20" Type="Integer" forecolor="Red" CssClass="validator" Display="None"></asp:RangeValidator>        
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="You must specify the numer of adults." ControlToValidate="Adults" validationgroup="2" forecolor="Red" CssClass="validator" Display="None"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="You must specify the numer of children." ControlToValidate="Children" validationgroup="2" forecolor="Red" CssClass="validator" Display="None"></asp:RequiredFieldValidator>
            <asp:ValidationSummary ID="ValidationSummary3" runat="server" DisplayMode="BulletList" ShowSummary="True"  validationgroup="2" forecolor="Red" ShowValidationErrors="True" />
        <br />
        <asp:ValidationSummary ID="ValidationSummary2" runat="server" HeaderText="You have some errors." ShowMessageBox="false" DisplayMode="BulletList" ShowSummary="true"  validationgroup="2" forecolor="Red" CssClass="hideValidationSummary" />
        <asp:Button ID="ButtonLogin" runat="server" Text="Login" OnClick="SendButtonLogin" CssClass="inputBottom" />
        <asp:Button ID="ButtonBuy" runat="server" validationgroup="2" Text="Buy" OnClick="SendButtonBuy" CssClass="inputBottom" />
    </section>  

</asp:Content>