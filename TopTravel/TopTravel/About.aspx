<%@ Page Title="Acerca de" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="TopTravel.About" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Página de descripción de su aplicación.</h2>
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
                     Está logueqado
                 </p>
                   </LoggedInTemplate>
              </asp:LoginView>
        <p>        
            Use esta área para proporcionar información adicional.
        </p>

        <p>        
            Use esta área para proporcionar información adicional.
        </p>

        <p>        
            Use esta área para proporcionar información adicional.
        </p>
        <p>        
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            User&nbsp;&nbsp;
        </p>
        <p>        
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            Pass</p>
        <p>        
            <asp:Button ID="Button1" runat="server" OnClick="Button1_click" Text="Button" />
        </p>
        <p>        
            &nbsp;</p>
    </article>

    <aside>
        <h3>Título complementario</h3>
        <p>        
            Use esta área para proporcionar información adicional.
        </p>
        <ul>
            <li><a runat="server" href="~/">Inicio</a></li>
            <li><a runat="server" href="~/About.aspx">Acerca de</a></li>
            <li><a runat="server" href="~/Contact.aspx">Contacto</a></li>
        </ul>
    </aside>
</asp:Content>