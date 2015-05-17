<%@ Page Title="Registrarse" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TopTravel.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Use el formulario siguiente para crear una cuenta nueva.</h2>
    </hgroup>

    <asp:CreateUserWizard runat="server" ID="RegisterUser" ViewStateMode="Disabled" OnCreatedUser="RegisterUser_CreatedUser">
        <LayoutTemplate>
            <asp:PlaceHolder runat="server" ID="wizardStepPlaceholder" />
            <asp:PlaceHolder runat="server" ID="navigationPlaceholder" />
        </LayoutTemplate>
        <WizardSteps>
            <asp:CreateUserWizardStep runat="server" ID="RegisterUserWizardStep">
                <ContentTemplate>
                    <p class="message-info">
                        Es necesario que las contraseñas tengan al menos <%: Membership.MinRequiredPasswordLength %> caracteres.
                    </p>

                    <p class="validation-summary-errors">
                        <asp:Literal runat="server" ID="ErrorMessage" />
                    </p>

                    <fieldset>
                        <legend>Formulario de registro</legend>
                        <ol>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="UserName">User Name</asp:Label>
                                <asp:TextBox runat="server" ID="UserName" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                                    CssClass="field-validation-error" ErrorMessage="This field is mandatory." />
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="dni">Identification document</asp:Label>
                                <asp:TextBox runat="server" ID="dni" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="dni"
                                    CssClass="field-validation-error" ErrorMessage="This field is mandatory." />
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="name">First Name</asp:Label>
                                <asp:TextBox runat="server" ID="name" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="name"
                                    CssClass="field-validation-error" ErrorMessage="This field is mandatory." />
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="dni">Surname</asp:Label>
                                <asp:TextBox runat="server" ID="surname" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="surname"
                                    CssClass="field-validation-error" ErrorMessage="This field is mandatory." />
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="dni">Phone</asp:Label>
                                <asp:TextBox runat="server" ID="phone" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="phone"
                                    CssClass="field-validation-error" ErrorMessage="This field is mandatory." />
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="address">Address</asp:Label>
                                <asp:TextBox runat="server" ID="address" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="address"
                                    CssClass="field-validation-error" ErrorMessage="This field is mandatory." />
                            </li>
                                <asp:RadioButtonList ID="gender" runat="server">
                                <asp:ListItem>Male</asp:ListItem> 
                                <asp:ListItem>Female</asp:ListItem>
                                </asp:RadioButtonList>
                               
                            <li>
                                <asp:Label runat="server" AssociatedControlID="Email">Email account</asp:Label>
                                <asp:TextBox runat="server" ID="Email" TextMode="Email" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                    CssClass="field-validation-error" ErrorMessage="This field is mandatory." />
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="Password">Password</asp:Label>
                                <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                                    CssClass="field-validation-error" ErrorMessage="This field is mandatory." />
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="ConfirmPassword">Confirm Password</asp:Label>
                                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                                     CssClass="field-validation-error" Display="Dynamic" ErrorMessage="This field is mandatory." />
                                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                                     CssClass="field-validation-error" Display="Dynamic" ErrorMessage="The password is wrong" />
                            </li>
                        </ol>
                        <asp:Button runat="server" CommandName="MoveNext" Text="Registrarse" />
                    </fieldset>
                </ContentTemplate>
                <CustomNavigationTemplate />
            </asp:CreateUserWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
</asp:Content>