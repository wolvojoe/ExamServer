<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Subjects.aspx.cs" Inherits="Admin_Subjects" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Label ID="lblPageTitle" runat="server" Text=""></asp:Label>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="WideContent">
        <div class="SubHeader">
            <h2>Subjects</h2>
        </div>

        <div class="Row">
            <asp:GridView ID="gvSubjects" runat="server" AllowPaging="True">
            </asp:GridView>
        </div>

        <div class="SubHeader">
            <h2>New Subject</h2>
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
                <asp:TextBox ID="txtPassword" runat="server" CssClass="TextBox" TextMode="Password"></asp:TextBox>
            </div>
        </div>

        <div class="Row">
            <div class="RowContent">
                <asp:Label ID="lblFirstName" runat="server" Text="First Name:"></asp:Label>
            </div>

            <div class="RowValue">
                <asp:TextBox ID="txtFirstName" runat="server" CssClass="TextBox"></asp:TextBox>
            </div>
        </div>

        <div class="Row">
            <div class="RowContent">
                <asp:Label ID="lblLastName" runat="server" Text="Last Name:"></asp:Label>
            </div>

            <div class="RowValue">
                <asp:TextBox ID="txtLastName" runat="server" CssClass="TextBox"></asp:TextBox>
            </div>
        </div>


        <div class="Row">
            <div class="RowValue">
                <asp:Button ID="btnCreate" runat="server" Text="Create" class="Button" />
            </div>
        </div>

    </div>

</asp:Content>

