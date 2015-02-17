<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Results.aspx.cs" Inherits="Admin_Results" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Label ID="lblPageTitle" runat="server" Text=""></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="WideContent">
        <div class="SubHeader">
            <h2>Results</h2>
        </div>


        <div class="Search">

            <div class="RowSearch">
                <asp:Label ID="lblSearchDepartment" runat="server" Text="Department:"></asp:Label>

                <asp:DropDownList ID="dpSearchDepartment" runat="server" CssClass="DropDown" OnSelectedIndexChanged="SearchDepartmentSelected" AutoPostBack="True" AppendDataBoundItems="true">
                    <asp:ListItem Text=" - Select - " Value="0" />
                </asp:DropDownList>
            </div>

        </div>


        <div class="GridRow">
            <asp:GridView ID="gvResults" runat="server" AllowPaging="True" AutoGenerateColumns="False">

                <Columns>
                    <asp:BoundField HeaderText="First Name" DataField="Student_First_Name"/>
                    <asp:BoundField HeaderText="Last Name" DataField="Student_Last_Name"/>
                    <asp:BoundField HeaderText="Department" DataField="Department_Name"/>
                    <asp:BoundField HeaderText="Exam" DataField="Exam_Name"/>

                    <asp:TemplateField HeaderText="View">
                      <ItemTemplate>
                       <asp:HyperLink ID="HyperLink1" runat="server" Text="View"  NavigateUrl='<%# Eval("pkResult_ID", "result.aspx?ID={0}") %>'>
                           <img class="TableImage" src="../Images/png/magnifying-glass-3x.png"/>
                       </asp:HyperLink>
                      </ItemTemplate>
                    </asp:TemplateField>

                </Columns>

            </asp:GridView>
        </div>



    </div>


</asp:Content>

