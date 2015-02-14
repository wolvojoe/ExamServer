<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Questions.aspx.cs" Inherits="Admin_Questions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Label ID="lblPageTitle" runat="server" Text=""></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div class="WideContent">
        <div class="SubHeader">
            <h2>Question</h2>
        </div>

        <div class="Search">

            <div class="RowSearch">
                <asp:Label ID="lblSearchSubject" runat="server" Text="Subject:"></asp:Label>

                <asp:DropDownList ID="dpSearchSubject" runat="server" CssClass="DropDown" OnSelectedIndexChanged="SearchSubjectSelected" AutoPostBack="True" AppendDataBoundItems="true">
                    <asp:ListItem Text=" - Select - " Value="0" />
                </asp:DropDownList>
            </div>

            <div class="RowSearch">
                <asp:Label ID="lblSearchModule" runat="server" Text="Module:"></asp:Label>

                <asp:DropDownList ID="dpSearchModule" runat="server" CssClass="DropDown" OnSelectedIndexChanged="Search" AutoPostBack="True" AppendDataBoundItems="true">
                    <asp:ListItem Text=" - Select - " Value="0" />
                </asp:DropDownList>
            </div>

        </div>

        <div class="GridRow">
            <asp:GridView ID="gvQuestions" runat="server" AllowPaging="True">
            </asp:GridView>
        </div>

        <div class="SubHeader">
            <h2>New Question</h2>
        </div>

        <div class="Row">
            <div class="RowContent">
                <asp:Label ID="lblName" runat="server" Text="Question:"></asp:Label>
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

        <div class="Row">
            <div class="RowContent">
                <asp:Label ID="lblSubject" runat="server" Text="Subject:"></asp:Label>
            </div>

            <div class="RowValue">
                <asp:DropDownList ID="dpSubject" runat="server" CssClass="DropDown" OnSelectedIndexChanged="SubjectSelected"></asp:DropDownList>
            </div>
        </div>

        <div class="Row">
            <div class="RowContent">
                <asp:Label ID="lblModule" runat="server" Text="Module:"></asp:Label>
            </div>

            <div class="RowValue">
                <asp:DropDownList ID="dpModule" runat="server" CssClass="DropDown"></asp:DropDownList>
            </div>
        </div>

        <div class="Row">
            <div class="RowContent">
                <asp:Label ID="lblQuestionType" runat="server" Text="Question Type:"></asp:Label>
            </div>

            <div class="RowValue">
                <asp:DropDownList ID="dpQuestionType" runat="server" CssClass="DropDown"></asp:DropDownList>
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

