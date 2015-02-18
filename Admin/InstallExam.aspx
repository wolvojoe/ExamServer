<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="InstallExam.aspx.cs" Inherits="Admin_InstallExam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Label ID="lblPageTitle" runat="server" Text=""></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="WideContent">
        <div class="SubHeader">
            <h2>Install Exam</h2>
        </div>

        <div class="Row">
            <div class="RowContent">
                <asp:Label ID="lblUploadExam" runat="server" Text="Upload Exam:"></asp:Label>
            </div>

            <div class="RowValue">
                <asp:FileUpload ID="fuUploadExam" runat="server" />
            </div>
        </div>

        <div class="Row">
            <div class="RowValue">
                <asp:Button ID="btnUpload" runat="server" Text="Save" class="Button" OnClick="btnUpload_Click" />
            </div>
        </div>

    </div>




</asp:Content>

