<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="TopTravel.Contact" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %></h1>
        <h2>Let's keep in touch.</h2>
    </hgroup>
   
    <section class="contact">
        <header>
            <h3>Phone numbers:</h3>
        </header>
        <p>
            <span class="label">Main number:</span>
            <span>425.555.0100</span>
        </p>
        <p>
            <span class="label">Customer Support:</span>
            <span>425.555.0199</span>
        </p>
    </section>

    <section class="contact">
        <header>
            <h3>Emails:</h3>
        </header>
        <p>
            <span class="label">Samuel Hern&aacutendez:</span>
            <span><a href="mailto:s.hernandezmartos@gmail.com">s.hernandezmartos@gmail.com</a></span>
        </p>
        <p>
            <span class="label">Javier Abell&aacuten:</span>
            <span><a href="mailto:javifreemind@gmail.com">javifreemind@gmail.com</a></span>
        </p>
        <p>
            <span class="label">Luke Blanes:</span>
            <span><a href="mailto:lukeblanes@gmail.com">lukeblanes@gmail.com</a></span>
        </p>
        <p>
            <span class="label">Ekaterina Zamiryakina:</span>
            <span><a href="mailto:ekaterina.zamiryakina@edu.lapinamk.fi">ekaterina.zamiryakina@edu.lapinamk.fi</a></span>
        </p>
        <p>
            <span class="label">Antonio Villaescusa Blanes:</span>
            <span><a href="mailto:antovillaescusa@gmail.com">antovillaescusa@gmail.com</a></span>
        </p>
        <p>
            <span class="label">Maxim Betin:</span>
            <span><a href="mailto:betinmaxim@gmail.com">betinmaxim@gmail.com</a></span>
        </p>
    </section>

    <section class="contact">
        <header>
            <h3>Adress:</h3>
        </header>
        <p>
            Universidad de Alicante<br />
            Carretera de San Vicente del Raspeig, s/n<br />
            03690 Alicante, Spain
        </p>
        <iframe class="map"
            width="100%"
            height="200"
            src="http://maps.google.co.uk/maps?q=Universidad+de+Alicante
            &amp;output=embed">
        </iframe>
    </section>

    
</asp:Content>