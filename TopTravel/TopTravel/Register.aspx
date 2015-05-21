<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TopTravel.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <hgroup class="title">
        <h1>Register</h1>
        <h2>Make your own account</h2>
    </hgroup>

    <section id="Section1" style>
        
        <label>ID</label>
        <asp:TextBox ID="dniR" runat="server" CssClass="input" />

        <label>Name</label>
        <asp:TextBox ID="nameR" runat="server" CssClass="input" />
            
        <label>Surname</label>
        <asp:TextBox ID="surnameR" runat="server" CssClass="input" />

        <label>Phone</label>
        <asp:TextBox ID="phoneR" runat="server" CssClass="input" />

        <label>Email</label>
        <asp:TextBox ID="addressR" runat="server" CssClass="input" />

            <asp:RadioButtonList ID="gender" runat="server" CssClass="radioButtonList2">
                <asp:ListItem>Male</asp:ListItem> 
                <asp:ListItem>Female</asp:ListItem>
            </asp:RadioButtonList>

        <label>Credit Card</label>
        <asp:TextBox ID="cardR" runat="server" CssClass="input" />

        <label>Password</label>
        <asp:TextBox ID="passR" TextMode="Password" runat="server" CssClass="input" />

        <label>Repeat yor pass</label>
        <asp:TextBox ID="pass2R" TextMode="Password" runat="server" CssClass="input" />

        <label>Avatar (Link)</label>
        <asp:TextBox ID="avatarR" runat="server" CssClass="input" />

        <asp:Button ID="Button1" runat="server" Text="Register" OnClick="sendR" CssClass="inputBottom" validationgroup="1" />
    </section>

    <section id="Section2">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="You must introdude an ID." ControlToValidate="dniR" validationgroup="1" forecolor="Red" CssClass="validator" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="You must introdude a name." ControlToValidate="nameR" validationgroup="1" forecolor="Red" CssClass="validator" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="You must introdude a surname." ControlToValidate="surnameR" validationgroup="1" forecolor="Red" CssClass="validator" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="You must introdude a phone number." ControlToValidate="phoneR" validationgroup="1" forecolor="Red" CssClass="validator" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="You must introdude an adress." ControlToValidate="addressR" validationgroup="1" forecolor="Red" CssClass="validator" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="You must introdude a gender." ControlToValidate="gender" validationgroup="1" forecolor="Red" CssClass="validator" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="You must introdude a credit card." ControlToValidate="cardR" validationgroup="1" forecolor="Red" CssClass="validator" Display="None"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator2" runat="server" Operator="DataTypeCheck" Type="Integer" ControlToValidate="cardR" ErrorMessage="Credit card must be a number" validationgroup="1"  Display="None"/>
        <asp:RegularExpressionValidator ID="Regex1" runat="server" ControlToValidate="passR" ValidationExpression="^.{4,8}$" ErrorMessage="Password must contain between 4 and 8 characters" validationgroup="1" ForeColor="Red" CssClass="validator"  Display="None" />
        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Passwords do not match." ControlToCompare="passR" ControlToValidate="pass2R" validationgroup="1" ForeColor="Red" CssClass="validator" Display="None"></asp:CompareValidator>

         <asp:ValidationSummary ID="ValidationSummary3" runat="server" DisplayMode="BulletList" ShowSummary="True" validationgroup="1" forecolor="Red" ShowValidationErrors="True" />
    </section>

</asp:Content>

