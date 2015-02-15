<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Answers.aspx.cs" Inherits="Admin_Answers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Label ID="lblPageTitle" runat="server" Text=""></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="WideContent">
        <div class="SubHeader">
            <h2>Answers</h2>
        </div>

        <div class="GridRow">
            <asp:GridView ID="gvAnswers" runat="server" AllowPaging="True" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField HeaderText="Answer Value" DataField="Answer_Name"/>
                    <asp:BoundField HeaderText="Answer Correct" DataField="Answer_Correct"/>

                    <asp:TemplateField HeaderText="Edit">
                      <ItemTemplate>
                       <asp:HyperLink ID="HyperLink1" runat="server" Text="Edit"  NavigateUrl='<%# Eval("fkQuestion_ID", "answers.aspx?ID={0}&AnsID=") + Eval("pkAnswer_ID")  %>'>
                           <img class="TableImage" src="../Images/png/wrench-3x.png"/>
                       </asp:HyperLink>
                      </ItemTemplate>
                    </asp:TemplateField>

                </Columns>

            </asp:GridView>
        </div>

        <div class="SubHeader">
            <h2>New Answer</h2>
        </div>

        <div class="Row">
            <div class="RowContent">
                <asp:Label ID="lblValue" runat="server" Text="Value:"></asp:Label>
            </div>

            <div class="RowValue">
                <asp:TextBox ID="txtValue" runat="server" CssClass="TextBox"></asp:TextBox>
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
                <asp:Label ID="lblCorrect" runat="server" Text="Correct:"></asp:Label>
            </div>

            <div class="RowValue">
                <asp:CheckBox ID="chkCorrect" runat="server" />  
            </div>
        </div>

        <div class="Row">
            <div class="RowValue">
                <asp:Button ID="btnSave" runat="server" Text="Create" class="Button" OnClick="btnSave_Click" />
            </div>
        </div>

    </div>

</asp:Content>

