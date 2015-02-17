<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Exams.aspx.cs" Inherits="Admin_Exams" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Label ID="lblPageTitle" runat="server" Text=""></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="WideContent">
        <div class="SubHeader">
            <h2>Exams</h2>
        </div>

        <div class="GridRow">
            <asp:GridView ID="gvExams" runat="server" AllowPaging="True" AutoGenerateColumns="False">

                <Columns>
                    <asp:BoundField HeaderText="Exam Name" DataField="Exam_Name"/>
                    <asp:BoundField HeaderText="Active" DataField="Exam_Active"/>

                    <asp:TemplateField HeaderText="Questions">
                      <ItemTemplate>
                       <asp:HyperLink ID="HyperLink1" runat="server" Text="Questions"  NavigateUrl='<%# Eval("pkExam_ID", "examquestions.aspx?ID={0}") %>'>
                           <img class="TableImage" src="../Images/png/question-mark-3x.png"/>
                       </asp:HyperLink>
                      </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Edit">
                      <ItemTemplate>
                       <asp:HyperLink ID="HyperLink1" runat="server" Text="Edit"  NavigateUrl='<%# Eval("pkExam_ID", "exam.aspx?ID={0}") %>'>
                           <img class="TableImage" src="../Images/png/wrench-3x.png"/>
                       </asp:HyperLink>
                      </ItemTemplate>
                    </asp:TemplateField>

                </Columns>

            </asp:GridView>
        </div>

       <div class="Row">
            <div class="RowValue">
                <asp:Button ID="btnCreate" runat="server" Text="Create Exam" class="Button" OnClick="btnCreate_Click" />
            </div>
        </div>


    </div>

 

</asp:Content>

