<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Exam.aspx.cs" Inherits="Admin_Exam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Label ID="lblPageTitle" runat="server" Text=""></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script>
        $(function () {
            $("#<%=txtOpenDate.ClientID%>").datepicker({ dateFormat: 'yy-mm-dd' });
            $("#<%=txtClosedDate.ClientID%>").datepicker({ dateFormat: 'yy-mm-dd' });
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
                <asp:Label ID="lblEnableOpenDate" runat="server" Text="Enable Open Date:"></asp:Label>
            </div>

            <div class="RowValue">
                <asp:CheckBox ID="chkEnableOpenDate" runat="server" /> 
            </div>
        </div>

        <div class="Row">
            <div class="RowContent">
                <asp:Label ID="lblOpenDate" runat="server" Text="Open Date:"></asp:Label>
            </div>

            <div class="RowValue">
                <asp:TextBox ID="txtOpenDate" runat="server" CssClass="TextBox"></asp:TextBox>
            </div>
        </div>


        <div class="Row">
            <div class="RowContent">
                <asp:Label ID="lblEnableClosedDate" runat="server" Text="Enable Closed Date:"></asp:Label>
            </div>

            <div class="RowValue">
                <asp:CheckBox ID="chkEnableClosedDate" runat="server" /> 
            </div>
        </div>

        <div class="Row">
            <div class="RowContent">
                <asp:Label ID="lblClosedDate" runat="server" Text="Closed Date:"></asp:Label>
            </div>

            <div class="RowValue">
                <asp:TextBox ID="txtClosedDate" runat="server" CssClass="TextBox"></asp:TextBox>
            </div>
        </div>


        <div class="Row">
            <div class="RowContent">
                <asp:Label ID="lblEnableTimeLimit" runat="server" Text="Enable Time Limit:"></asp:Label>
            </div>

            <div class="RowValue">
                <asp:CheckBox ID="chkEnableTimeLimit" runat="server" /> 
            </div>
        </div>

        <div class="Row">
            <div class="RowContent">
                <asp:Label ID="lblTimeLimit" runat="server" Text="Time Limit:"></asp:Label>
            </div>

            <div class="RowValue">
                <asp:TextBox ID="txtTimeLimit" runat="server" CssClass="TextBox" TextMode="Time">60</asp:TextBox>
            </div>
        </div>




        <div class="SubHeader">
            <h2>Exam Details</h2>
        </div>


        <div class="Row">
            <div class="RowContent">
                <asp:Label ID="lblNumberOfAttempts" runat="server" Text="Number of Attempts:"></asp:Label>
            </div>

            <div class="RowValue">
                <asp:TextBox ID="txtNumberOfAttempts" runat="server" CssClass="TextBox"></asp:TextBox>
            </div>
        </div>


        <div class="Row">
            <div class="RowContent">
                <asp:Label ID="lblOrderQuestions" runat="server" Text="Order Questions:"></asp:Label>
            </div>

            <div class="RowValue">
                <asp:CheckBox ID="chkOrderQuestions" runat="server" /> 
            </div>
        </div>


        <div class="Row">
            <div class="RowContent">
                <asp:Label ID="lblShuffleAnswers" runat="server" Text="Shuffle Answers:"></asp:Label>
            </div>

            <div class="RowValue">
                <asp:CheckBox ID="chkShuffleAnswers" runat="server" /> 
            </div>
        </div>

        <div class="Row">
            <div class="RowContent">
                <asp:Label ID="lblLearningMode" runat="server" Text="Learning Mode:"></asp:Label>
            </div>

            <div class="RowValue">
                <asp:CheckBox ID="chkLearningMode" runat="server" /> 
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

