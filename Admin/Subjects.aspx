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

