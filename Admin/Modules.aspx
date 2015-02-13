<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Modules.aspx.cs" Inherits="Admin_Modules" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Label ID="lblPageTitle" runat="server" Text=""></asp:Label>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="WideContent">
        <div class="SubHeader">
            <h2>Modules</h2>
        </div>

        <div class="Search">

            <div class="RowSearch">
                <asp:Label ID="lblSearchSubject" runat="server" Text="Subject:"></asp:Label>

                <asp:DropDownList ID="dpSearchSubject" runat="server" CssClass="DropDown" OnSelectedIndexChanged="SearchModules" AutoPostBack="True"></asp:DropDownList>
            </div>

        </div>

        <div class="GridRow">
            <asp:GridView ID="gvModules" runat="server" AllowPaging="True" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField HeaderText="Module Name" DataField="Module_Name"/>
                    <asp:BoundField HeaderText="Subject Name" DataField="Subject_Name"/>
                    <asp:BoundField HeaderText="Active" DataField="Module_Active"/>

                    <asp:TemplateField HeaderText="Edit">
                      <ItemTemplate>
                       <asp:HyperLink ID="HyperLink1" runat="server" Text="Edit"  NavigateUrl='<%# Eval("pkModule_ID", "modules.aspx?ID={0}") %>'>
                           <img class="TableImage" src="../Images/png/wrench-3x.png"/>
                       </asp:HyperLink>
                      </ItemTemplate>
                    </asp:TemplateField>

                </Columns>

            </asp:GridView>
        </div>

        <div class="SubHeader">
            <h2>New Module</h2>
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
                <asp:Label ID="lblSubject" runat="server" Text="Subject:"></asp:Label>
            </div>

            <div class="RowValue">
                <asp:DropDownList ID="dpSubject" runat="server" CssClass="DropDown"></asp:DropDownList>
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

