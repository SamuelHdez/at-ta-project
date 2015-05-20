<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TopTravel._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section>
        <div class="apps">
            <a class="app" href="Product.aspx">
                    <img src="images/cities/Berlin.jpg" height=100% width=100%>
                    <div class="footerImg">
                        <div class="place">Berlin</div>
                        <div class="price">120 &euro;</div>
                        <p>Description here</p>
                    </div>
            </a>
                <a class="app" href="Product.aspx">
                    <img src="images/cities/Moon.jpg" height=100% width=100%>
                    <div class="footerImg">
                        <div class="place">Moon</div>
                        <div class="price">10000 &euro;</div>
                        <p>An affordable travel right to moon</p>
                    </div>
                </a>
                <a class="app" href="#">
                    <img src="images/cities/Istanbul.jpg" height=100% width=100%>
                    <div class="footerImg">
                        <div class="place">Istanbul</div>
                        <div class="price">60 &euro;</div>
                        <p>Description here</p>
                    </div>
                </a>
                <a class="app" href="#">
                    <img src="images/cities/New-York.jpg" height=100% width=100%>
                    <div class="footerImg">
                        <div class="place">New York</div>
                        <div class="price">200 &euro;</div>
                        <p>Description here</p>
                    </div>
                </a>
                <a class="app" href="#">
                    <img src="images/cities/Rio-de-Janeiro.jpg" height=100% width=100%>
                    <div class="footerImg">
                        <div class="place">R&iacute;o de Janeiro</div>
                        <div class="price">70 &euro;</div>
                        <p>Description here</p>
                    </div>
                </a>
                <a class="app" href="#">
                    <img src="images/cities/Rome.jpg" height=100% width=100%>
                    <div class="footerImg">
                        <div class="place">Rome   </div>
                        <div class="price">110 &euro;</div>
                        <p>Description here</p>
                    </div>
                </a>
                <a class="app" href="#">
                    <img src="images/cities/San-Francisco.jpg" height=100% width=100%>
                    <div class="footerImg">
                        <div class="place">San Francisco</div>
                        <div class="price">150 &euro;</div>
                        <p>Description here</p>
                    </div>
                </a>
                <a class="app" href="#">
                    <img src="images/cities/Seville.jpg" height=100% width=100%>
                    <div class="footerImg">
                        <div class="place">Seville </div>
                        <div class="price">40 &euro;</div>
                        <p>Description here</p>
                    </div>
                </a>
                <a class="app" href="#">
                    <img src="images/cities/Sydney.jpg" height=100% width=100%>
                    <div class="footerImg">
                        <div class="place">Sydney</div>
                        <div class="price">130 &euro;</div>
                        <p>Description here</p>
                    </div>
                </a>
                <a class="app" href="#">
                    <img src="images/cities/Tokyo.jpg" height=100% width=100%>
                    <div class="footerImg">
                        <div class="place">Tokyo</div>
                        <div class="price">170 &euro;</div>
                        <p>Description here</p>
                    </div>
                </a>
                <a class="app" href="#">
                    <img src="images/cities/Venice.jpg" height=100% width=100%>
                    <div class="footerImg">
                        <div class="place">Venice</div>
                        <div class="price">100 &euro;</div>
                        <p>Description here</p>
                    </div>
                </a>
                <a class="app" href="#">
                    <img src="images/cities/Vienna.jpg" height=100% width=100%>
                    <div class="footerImg">
                        <div class="place">Vienna </div>
                        <div class="price">80 &euro;</div>
                        <p>Description here</p>
                    </div>
                </a>
            </div>
    </section>
    <asp:Label ID="sess" runat="server"></asp:Label>



    <section>
        <div class="videoTitle">
	        <h1>The desire for distance.</h1>
	        <h1>The longing for experience.</h1>
	        <h1>The need to escape.</h1>
        </div>
        <video id="LandingVideo" class="video" preload="auto" autobuffer="" autoload="" autoplay="" loop="">
	        <source src="http://cdn.thefernway.com/_assets/videos/landing.mp4" type="video/mp4">			
        </video>
    </section>



    <!--

    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>Modifique esta plantilla para poner en marcha su aplicación ASP.NET.</h2>
            </hgroup>
            <p>
                Para obtener más información sobre ASP.NET, visite <a href="http://asp.net" title="ASP.NET Website">http://asp.net</a>.
                La página incluye <mark>vídeos, cursos y ejemplos</mark> para ayudarle a sacar el máximo partido a ASP.NET.
                Si tiene alguna pregunta relacionada con ASP.NET, visite
                <a href="http://forums.asp.net/18.aspx" title="ASP.NET Forum">nuestros foros</a>.
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Recomendamos lo siguiente:</h3>
    <ol class="round">
        <li class="one">
            <h5>Introducción</h5>
            Los formularios Web Forms de ASP.NET permiten crear sitios web dinámicos mediante modelos basados en eventos y de arrastrar y colocar.
            La superficie de diseño y los cientos de controles y componentes permiten crear rápidamente sitios sofisticados y controlados mediante UI con acceso de datos.
            <a href="http://go.microsoft.com/fwlink/?LinkId=245146">Más información…</a>
        </li>
        <li class="two">
            <h5>Agregar paquetes NuGet y poner en marcha su codificación</h5>
            NuGet facilita la instalación y actualización de herramientas y bibliotecas gratuitas.
            <a href="http://go.microsoft.com/fwlink/?LinkId=245147">Más información…</a>
        </li>
        <li class="three">
            <h5>Buscar hospedaje de sitios web</h5>
            Encuentre fácilmente empresas de alojamiento web que ofrezcan la mejor relación de características y precio para sus aplicaciones.
            <a href="http://go.microsoft.com/fwlink/?LinkId=245143">Más información…</a>
        </li>
    </ol>-->
</asp:Content>