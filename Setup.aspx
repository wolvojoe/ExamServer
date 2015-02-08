<%@ Page Title="" Language="C#" MasterPageFile="~/Base.master" AutoEventWireup="true" CodeFile="Setup.aspx.cs" Inherits="Setup_Setup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainNavigation" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">

    <div class="Content">
        <div class="SubHeader">
            <h2>Site Details</h2>
        </div>

        <div class="Row">
            <div class="RowContent">
                <asp:Label ID="lblSiteName" runat="server" Text="Site Name:"></asp:Label>
            </div>

            <div class="RowValue">
                <asp:TextBox ID="txtSiteName" runat="server" CssClass="TextBox"></asp:TextBox>
            </div>
        </div>

        <div class="SubHeader">
            <h2>Admin Register</h2>
        </div>

        <div class="Row">
            <div class="RowContent">
                <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
            </div>

            <div class="RowValue">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="TextBox"></asp:TextBox>
            </div>
        </div>

        <div class="Row">
            <div class="RowContent">
                <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
            </div>

            <div class="RowValue">
                <asp:TextBox ID="txtPassword" runat="server" CssClass="TextBox"></asp:TextBox>
            </div>
        </div>

        <div class="Row">
            <div class="RowValue">
                <asp:Button ID="btnCreate" runat="server" Text="Create" class="Button" OnClick="btnCreate_Click"/>
            </div>
        </div>

    </div>

</asp:Content>

