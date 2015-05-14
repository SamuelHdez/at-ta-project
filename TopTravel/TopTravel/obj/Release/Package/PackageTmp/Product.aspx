<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="TopTravel.Product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <hgroup class="title">
        <h1>Adlon Kempinski Hotel</h1>
        <h2>Berlin</h2>
    </hgroup>
    

    <!--<img class="imgBack" src="images/cities/Berlin.jpg" height=100% width=100%>-->
        

        <article>
            <p>        
               Berlin is one of the most fun cities in Europe.
            </p>
            <p>        
                Enjoy the amazing frankfurt sausages and beer. 
            </p>
            <p>        
                In the map below you can see one of the most modern hotels in Berlin. 
                Recommended by TopTravel.
            </p>
            <iframe class="map"
            width="100%"
            height="200"
            src="http://maps.google.co.uk/maps?q=Hotel+Adlon+Kempinski+Berlin
            &amp;output=embed">
        </iframe>
        </article>

        <aside>
            <h3>Add to Cart</h3>
            <p>        
               Info
            </p>
            <ul>
                <li><a id="A1" runat="server" href="~/">Buy</a></li>
                <li><a id="A2" runat="server" href="~/t.aspx">Save</a></li>
                <li><a id="A3" runat="server" href="~/.aspx">Share</a></li>
            </ul>
        </aside>
    

</asp:Content>
