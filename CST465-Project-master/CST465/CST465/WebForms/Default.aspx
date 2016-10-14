<%@ Page Language="C#" MasterPageFile="~/WebForms/Template.Master" EnableViewState="false" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CST465.WebForms.Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Default things</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <form id="form1" runat="server">
        <div>
            <%--Text box for the name--%>
            <asp:Label ID="lblName" AssociatedControlID="uxName" runat="server">Name</asp:Label>
            <asp:TextBox ID="uxName" runat="server" />
            <br />
            <br />

            <%--Drop down list with priortiy--%>
            <asp:DropDownList ID="uxPriority" runat="server">
                <asp:ListItem Text="High"></asp:ListItem>
                <asp:ListItem Text="Medium"></asp:ListItem>
                <asp:ListItem Text="Low"></asp:ListItem>
            </asp:DropDownList><br />
            <br />

            <%--subject area.. boring text box--%>
            <asp:Label ID="lblSubject" AssociatedControlID="uxSubject" runat="server">Subject</asp:Label>
            <asp:TextBox ID="uxSubject" runat="server" />
            <br />
            <br />

            <%--Label that allows for multiple line inputs--%>
            <asp:Label ID="lblDescription" AssociatedControlID="uxDescription" runat="server">Description</asp:Label>
            <asp:TextBox ID="uxDescription" TextMode="MultiLine" runat="server" />
            <br />



            <asp:Literal ID="uxFormOutput" runat="server" Mode="Encode"></asp:Literal>
            <asp:Button ID="uxSubmit" OnClick="uxSubmit_Click" runat="server" Text="Submit" />
            <br />
            <br />

            <asp:Literal ID="uxEventOutput" runat="server" Mode="Encode"></asp:Literal>
        </div>
    </form>
</asp:Content>
