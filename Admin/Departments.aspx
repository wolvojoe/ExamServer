<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Departments.aspx.cs" Inherits="Admin_Departments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Label ID="lblPageTitle" runat="server" Text=""></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="WideContent">
        <div class="SubHeader">
            <h2>Departments</h2>
        </div>

        <div class="GridRow">
            <asp:GridView ID="gvDepartments" runat="server" AllowPaging="True" AutoGenerateColumns="False">

                <Columns>
                    <asp:BoundField HeaderText="Department Name" DataField="Department_Name"/>
                    <asp:BoundField HeaderText="Active" DataField="Department_Active"/>

                    <asp:TemplateField HeaderText="Edit">
                      <ItemTemplate>
                       <asp:HyperLink ID="HyperLink1" runat="server" Text="Edit"  NavigateUrl='<%# Eval("pkDepartment_ID", "departments.aspx?ID={0}") %>'>
                           <img class="TableImage" src="../Images/png/wrench-3x.png"/>
                       </asp:HyperLink>
                      </ItemTemplate>
                    </asp:TemplateField>

                </Columns>

            </asp:GridView>
        </div>

        <div class="SubHeader">
            <h2>New Department</h2>
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

