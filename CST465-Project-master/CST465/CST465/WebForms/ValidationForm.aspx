<%@ Page Language="C#" MasterPageFile="~/WebForms/Template.Master" AutoEventWireup="true" CodeBehind="ValidationForm.aspx.cs" Inherits="CST465.WebForms.ValidationForm" %>

<%@ Register TagPrefix="CST" Src="~/WebForms/RequiredTextBox.ascx" TagName="RequiredTextBox" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Validation Form things</title>
</asp:Content>

<asp:Content ID="main" ContentPlaceHolderID="main" runat="server">
    <form id="form1" runat="server">
        <asp:Panel ID="Panel1" runat="server">

            <CST:RequiredTextBox runat="server" ID="uxName" LabelText="Name"/>
            <CST:RequiredTextBox runat="server" ID="uxColor" LabelText="Favorite Color"/>
            <CST:RequiredTextBox runat="server" ID="uxCity" LabelText="City"/>
            <asp:Button ID="uxSubmit" OnClick="uxSubmit_Click" runat="server" Text="Submit" />
        </asp:Panel>
    </form>
</asp:Content>
