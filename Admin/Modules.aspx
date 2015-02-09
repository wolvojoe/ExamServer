<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Modules.aspx.cs" Inherits="Admin_Modules" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Label ID="lblPageTitle" runat="server" Text=""></asp:Label>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="WideContent">
        <div class="SubHeader">
            <h2>Modules</h2>
        </div>

        <div class="GridRow">
            <asp:GridView ID="gvModules" runat="server" AllowPaging="True">
            </asp:GridView>
        </div>

        <div class="SubHeader">
            <h2>New Module</h2>
        </div>

        <div class="Row">
            <div class="RowContent">
                <asp:Label ID="lblName" runat="server" Text="Name:"></asp:Label>
            </div>

            <div class="RowValue">
                <asp:TextBox ID="txtName" runat="server" CssClass="TextBox"></asp:TextBox>
            </div>
        </div>

        <div class="Row">
            <div class="RowContent">
                <asp:Label ID="lblActive" runat="server" Text="Active:"></asp:Label>
            </div>

            <div class="RowValue">
                <asp:CheckBox ID="chkActive" runat="server" />  
            </div>
        </div>

        <div class="Row">
            <div class="RowValue">
                <asp:Button ID="btnSave" runat="server" Text="Create" class="Button" OnClick="btnSave_Click" />
            </div>
        </div>

    </div>

</asp:Content>

