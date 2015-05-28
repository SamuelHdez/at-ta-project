<%@ Page Title="Companies" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyAccount.aspx.cs" Inherits="TopTravel.MyAccount" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1>My account</h1>
    </hgroup>

    <style type="text/css">
      .hiddencol
      {
        display: none;
      }
    </style>
    <asp:Label ID="success" runat="server" Text="Data updated succesfully" Visible="false" ForeColor="Green" CssClass="aspLabel"></asp:Label>
    <br />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="8" Width="100%" AutoGenerateColumns="False" CssClass="Grid" AlternatingRowStyle-CssClass="alt" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <columns>
                    <asp:boundfield datafield="dni" headertext="Username"/>
                    <asp:boundfield datafield="name" headertext="Name"/>
                    <asp:boundfield datafield="surname" headertext="Surname"/>
                    <asp:boundfield datafield="phone" headertext="Phone"/>
                    <asp:boundfield datafield="address" headertext="Address"/>
                    <asp:boundfield datafield="gender" headertext="Gender"/>
                    <asp:boundfield datafield="creditCard" headertext="Credit Card"/>
                    <asp:boundfield datafield="avatar" headertext="avatar" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
                     <asp:boundfield datafield="password" headertext="pass" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
                </columns>
                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
     </asp:GridView>
      <br />
     <asp:GridView ID="GridView2" runat="server" Width="100%" AutoGenerateColumns="False" CssClass="Grid" AlternatingRowStyle-CssClass="alt">
                <Columns>
                    <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Bind("avatar") %>' Width="350"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
    </asp:GridView>
    <br />
     
    <label>name</label>
    <asp:TextBox ID="nameChange" runat="server" CssClass="input" />

    <label>Surname</label>
    <asp:TextBox ID="surnameChange" runat="server" CssClass="input" />

    <label>Phone</label>
    <asp:TextBox ID="phoneChange" runat="server" CssClass="input" />

    <label>Email</label>
    <asp:TextBox ID="addressChange" runat="server" CssClass="input" />

    <label>Credit Card</label>
    <asp:TextBox ID="creditCardChange" runat="server" CssClass="input" />

    <label>Image profile</label>
    <asp:TextBox ID="imageChange" runat="server" CssClass="input" />

    <label>New Password</label>
    <asp:TextBox ID="passwordChange" TextMode="Password" runat="server" CssClass="input" />

    <label>Repeat Password</label>
    <asp:TextBox ID="passwordChangeConfirm" TextMode="Password" runat="server" CssClass="input" />

    <asp:Button ID="SendButton" runat="server" Text="Update" OnClick="send" CssClass="inputBottom" />
    <section id="Section2">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="You must introdude a name." ControlToValidate="nameChange" forecolor="Red" CssClass="validator"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="You must introdude a surname." ControlToValidate="surnameChange" forecolor="Red" CssClass="validator"></asp:RequiredFieldValidator>

         <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="You must introdude a phone number." ControlToValidate="phoneChange" forecolor="Red" CssClass="validator"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Phone number must be 9 numbers" ControlToValidate="phoneChange" ValidationExpression="^[0-9]{9,9}$" forecolor="Red" CssClass="validator" />

        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="You must introdude an email." ControlToValidate="addressChange" forecolor="Red" CssClass="validator"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="addressChange" ErrorMessage="Invalid Email Format" forecolor="Red" CssClass="validator"></asp:RegularExpressionValidator>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="You must introdude a credit card." ControlToValidate="creditCardChange" forecolor="Red" CssClass="validator" Display="None"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegExp1" runat="server" ErrorMessage="Credit card must be 12 numbers" ControlToValidate="creditCardChange" ValidationExpression="^[0-9]{12,12}$" forecolor="Red" CssClass="validator"/>

        <asp:RequiredFieldValidator ID="PasswordReq" runat="server" ControlToValidate="passwordChange" ValidationExpression="^.{4,8}$" ErrorMessage="Password must contain between 4 and 8 characters" forecolor="Red" CssClass="validator"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Passwords do not match." ControlToCompare="passwordChange" ControlToValidate="passwordChangeConfirm"  ForeColor="Red" CssClass="validator"></asp:CompareValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="You must confirm a password." ControlToValidate="passwordChangeConfirm" forecolor="Red" CssClass="validator"></asp:RequiredFieldValidator>
    </section>
</asp:Content>