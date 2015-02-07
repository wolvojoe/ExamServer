<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Base.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Admin_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainHeader" Runat="Server">
    <asp:Label ID="lblHeaderText" runat="server" Text=""></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="LoginBox">
        <div class="LoginHeader">
            <h2>Login</h2>
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
                <asp:Button ID="btnLogin" runat="server" Text="Login" class="Button"/>
            </div>
        </div>



    </div>
</asp:Content>

