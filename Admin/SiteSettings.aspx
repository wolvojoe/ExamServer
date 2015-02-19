<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="SiteSettings.aspx.cs" Inherits="Admin_SiteSettings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Label ID="lblPageTitle" runat="server" Text=""></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="WideContent">
        <div class="SubHeader">
            <h2>Site Settings</h2>
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
            <h2>Registration</h2>
        </div>

        <div class="Row">
            <div class="RowContent">
                <asp:Label ID="lblAllowExternalRegistration" runat="server" Text="Allow External Registration:"></asp:Label>
            </div>

            <div class="RowValue">
                <asp:CheckBox ID="chkExternalReg" runat="server" />  
            </div>
        </div>

        <div class="Row">
            <div class="RowValue">
                <asp:Button ID="btnSave" runat="server" Text="Save" class="Button" OnClick="btnSave_Click" />
            </div>
        </div>


        <div class="SubHeader">
            <h2>Upload Data</h2>
        </div>

        <div class="Row">
            <div class="RowValue">
                <asp:Button ID="btnInstallExam" runat="server" Text="Install Exam" class="Button" OnClick="btnInstallExam_Click" />
            </div>

            <div class="RowValue">
                <asp:Button ID="btnInstallQuestions" runat="server" Text="Install Questions" class="Button" OnClick="btnInstallQuestions_Click" />
            </div>

        </div>

    </div>
</asp:Content>

