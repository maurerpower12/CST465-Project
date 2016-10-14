<%@ Page Language="C#" MasterPageFile="~/WebForms/Template.Master" AutoEventWireup="true" CodeBehind="ValidatedFormOutput.aspx.cs" Inherits="CST465.WebForms.ValidatedFormOutput" %>

<%@ Register TagPrefix="CST" Src="~/WebForms/RequiredTextBox.ascx" TagName="RequiredTextBox" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Output  things</title>
</asp:Content>

<asp:Content ID="main" ContentPlaceHolderID="main" runat="server">
    <form id="form1" runat="server">
          <asp:PlaceHolder ID="uxInvalidDataArgs" runat="server" Visible="false">
              <p>This form did not recieve the parameters expected!</p>
          </asp:PlaceHolder>

          <asp:PlaceHolder ID="uxValidDataArea" runat="server" Visible="false">
              <div>
                  Name
               <asp:Literal ID="uxName" runat="server" Mode="Encode"></asp:Literal>
              </div>
              <div>
                  Favorite Color
               <asp:Literal ID="uxFavoriteColor" runat="server" Mode="Encode"></asp:Literal>
              </div>
              <div>
                  City
               <asp:Literal ID="uxCity" runat="server" Mode="Encode"></asp:Literal>
               </div>
          </asp:PlaceHolder>

    </form>
</asp:Content>