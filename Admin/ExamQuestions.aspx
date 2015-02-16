<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ExamQuestions.aspx.cs" Inherits="Admin_ExamQuestions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Label ID="lblPageTitle" runat="server" Text=""></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="WideContent">
        <div class="SubHeader">
            <h2>Select Questions</h2>
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
            <asp:GridView ID="gvQuestions" runat="server" AllowPaging="True" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField HeaderText="Question Name" DataField="Question_Name"/>
                    <asp:BoundField HeaderText="Module Name" DataField="Module_Name"/>
                    <asp:BoundField HeaderText="Subject Name" DataField="Subject_Name"/>
                    <asp:BoundField HeaderText="Active" DataField="Question_Active"/>

                    <asp:TemplateField HeaderText="Select">
                      <ItemTemplate>

                          <asp:Button ID="btnSelect" runat="server" CommandArgument=<%# Bind("pkQuestion_ID") %> CommandName="QuestionID" OnClick="btnSelect_Click" />
                      
                      </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        <div class="SubHeader">
            <h2>Exam Questions</h2>
        </div>

       <div class="GridRow">
            <asp:GridView ID="gvQuestionBank" runat="server" AllowPaging="True" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField HeaderText="Question Name" DataField="Question_Name"/>
                    <asp:BoundField HeaderText="Module Name" DataField="Module_Name"/>
                    <asp:BoundField HeaderText="Subject Name" DataField="Subject_Name"/>
                    <asp:BoundField HeaderText="Active" DataField="Question_Active"/>

                    <asp:TemplateField HeaderText="Select">
                      <ItemTemplate>

                          <asp:Button ID="btnRemove" runat="server" CommandArgument=<%# Bind("pkQuestion_Bank_ID") %> CommandName="QuestionBankID" OnClick="btnRemove_Click" />
                      
                      </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>


    </div>

</asp:Content>

