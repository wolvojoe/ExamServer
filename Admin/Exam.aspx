<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Exam.aspx.cs" Inherits="Admin_Exam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Label ID="lblPageTitle" runat="server" Text=""></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script>
        $(function () {
            $("#<%=txtDateOpen.ClientID%>").datepicker();
        });

    </script>

    <div class="WideContent">

        <div class="SubHeader">
            <h2>New Exam</h2>
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
                <asp:Label ID="lblDescription" runat="server" Text="Description:"></asp:Label>
            </div>

            <div class="RowValue">
                <asp:TextBox ID="txtDescription" runat="server" CssClass="TextBox"></asp:TextBox>
            </div>
        </div>

        <div class="SubHeader">
            <h2>Date of Exam</h2>
        </div>

        <div class="Row">
            <div class="RowContent">
                <asp:Label ID="lblDateOpenEnabled" runat="server" Text="Enable Open Date:"></asp:Label>
            </div>

            <div class="RowValue">
                <asp:CheckBox ID="chkEnableOpenDate" runat="server" /> 
            </div>
        </div>

        <div class="Row">
            <div class="RowContent">
                <asp:Label ID="lblDateOpen" runat="server" Text="Date Open:"></asp:Label>
            </div>

            <div class="RowValue">
                <asp:TextBox ID="txtDateOpen" runat="server" CssClass="TextBox"></asp:TextBox>
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
                <asp:Button ID="btnSave" runat="server" Text="Create" class="Button" OnClick="btnSave_Click" />
            </div>
        </div>

    </div>


</asp:Content>

