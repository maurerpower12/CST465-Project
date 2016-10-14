<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RequiredTextBox.ascx.cs" Inherits="CST465.WebForms.RequiredTextBox" %>

    <%--Required text box--%>
    <asp:Label ID="lblRequired" AssociatedControlID="uxRequired" Text="Answer" runat="server" />
    <asp:TextBox ID="uxRequired" runat="server" />
    <asp:RequiredFieldValidator ID="valRequired" SetFocusOnError="true" ControlToValidate="uxRequired" Text="*" ErrorMessage="'Answer' is reuired" runat="server" />
    <br />