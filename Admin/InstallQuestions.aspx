<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="InstallQuestions.aspx.cs" Inherits="Admin_InstallQuestions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Label ID="lblPageTitle" runat="server" Text=""></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="WideContent">
        <div class="SubHeader">
            <h2>Install Questions</h2>
        </div>


        <div class="Row">
            <div class="RowContent">
                <asp:Label ID="lblSubject" runat="server" Text="Subject:"></asp:Label>
            </div>

            <div class="RowValue">
                <asp:DropDownList ID="dpSubject" runat="server" CssClass="DropDown" OnSelectedIndexChanged="SubjectSelected" AutoPostBack="True" AppendDataBoundItems="true">
                    <asp:ListItem Text=" - Select - " Value="0" />
                </asp:DropDownList>
            </div>
        </div>

        <div class="Row">
            <div class="RowContent">
                <asp:Label ID="lblModule" runat="server" Text="Module:"></asp:Label>
            </div>

            <div class="RowValue">
                <asp:DropDownList ID="dpModule" runat="server" CssClass="DropDown" AppendDataBoundItems="true">
                    <asp:ListItem Text=" - Select - " Value="0" />
                </asp:DropDownList>
            </div>
        </div>



        <div class="Row">
            <div class="RowContent">
                <asp:Label ID="lblUploadQuestions" runat="server" Text="Upload Questions:"></asp:Label>
            </div>

            <div class="RowValue">
                <asp:FileUpload ID="fuUploadQuestions" runat="server" />
            </div>
        </div>

        <div class="Row">
            <div class="RowValue">
                <asp:Button ID="btnUpload" runat="server" Text="Save" class="Button" OnClick="btnUpload_Click" />
            </div>
        </div>

    </div>

</asp:Content>

