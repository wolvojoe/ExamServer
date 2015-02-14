<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Students.aspx.cs" Inherits="Admin_Students" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Label ID="lblPageTitle" runat="server" Text=""></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="WideContent">
        <div class="SubHeader">
            <h2>Students</h2>
        </div>

        <div class="Search">

            <div class="RowSearch">
                <asp:Label ID="lblSearchDepartment" runat="server" Text="Department:"></asp:Label>

                <asp:DropDownList ID="dpSearchDepartment" runat="server" CssClass="DropDown" OnSelectedIndexChanged="Search" AutoPostBack="True" AppendDataBoundItems="true">
                    <asp:ListItem Text=" - Select - " Value="0" />
                </asp:DropDownList>
            </div>

        </div>


        <div class="GridRow">
            <asp:GridView ID="gvStudents" runat="server" AllowPaging="True" AutoGenerateColumns="False">

                <Columns>
                    <asp:BoundField HeaderText="First Name" DataField="Student_First_Name"/>
                    <asp:BoundField HeaderText="Last Name" DataField="Student_Last_Name"/>
                    <asp:BoundField HeaderText="Email" DataField="Student_Email"/>
                    <asp:BoundField HeaderText="Department Name" DataField="Department_Name"/>
                    <asp:BoundField HeaderText="Active" DataField="Student_Active"/>

                    <asp:TemplateField HeaderText="Edit">
                      <ItemTemplate>
                       <asp:HyperLink ID="HyperLink1" runat="server" Text="Edit"  NavigateUrl='<%# Eval("pkStudent_ID", "students.aspx?ID={0}") %>'>
                           <img class="TableImage" src="../Images/png/wrench-3x.png"/>
                       </asp:HyperLink>
                      </ItemTemplate>
                    </asp:TemplateField>

                </Columns>

            </asp:GridView>
        </div>

        <div class="SubHeader">
            <h2>New Student</h2>
        </div>

        <div class="Row">
            <div class="RowContent">
                <asp:Label ID="lblFirstName" runat="server" Text="First Name:"></asp:Label>
            </div>

            <div class="RowValue">
                <asp:TextBox ID="txtFirstName" runat="server" CssClass="TextBox"></asp:TextBox>
            </div>
        </div>

        <div class="Row">
            <div class="RowContent">
                <asp:Label ID="lblLastName" runat="server" Text="Last Name:"></asp:Label>
            </div>

            <div class="RowValue">
                <asp:TextBox ID="txtLastName" runat="server" CssClass="TextBox"></asp:TextBox>
            </div>
        </div>

        <div class="Row">
            <div class="RowContent">
                <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
            </div>

            <div class="RowValue">
                <asp:TextBox ID="txtEmailUpdate" runat="server" CssClass="TextBox"></asp:TextBox>
            </div>
        </div>

        <div class="Row">
            <div class="RowContent">
                <asp:Label ID="lblPassword" runat="server" Text="Change Password:"></asp:Label>
            </div>

            <div class="RowValue">
                <asp:TextBox ID="txtPasswordUpdate" runat="server" CssClass="TextBox" TextMode="Password"></asp:TextBox>
            </div>
        </div>

        <div class="Row">
            <div class="RowContent">
                <asp:Label ID="lblDepartment" runat="server" Text="Department:"></asp:Label>
            </div>

            <div class="RowValue">
                <asp:DropDownList ID="dpDepartment" runat="server" CssClass="DropDown"></asp:DropDownList>
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

