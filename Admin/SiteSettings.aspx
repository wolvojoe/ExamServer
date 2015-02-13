﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="SiteSettings.aspx.cs" Inherits="Admin_SiteSettings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Label ID="lblPageTitle" runat="server" Text=""></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="WideContent">
        <div class="SubHeader">
            <h2>Site Settings</h2>
        </div>

        <div class="Row">
            <div class="RowContent">
                <asp:Label ID="lblSiteName" runat="server" Text="Site Name:"></asp:Label>
            </div>

            <div class="RowValue">
                <asp:TextBox ID="txtSiteName" runat="server" CssClass="TextBox"></asp:TextBox>
            </div>
        </div>

        <div class="Row">
            <div class="RowValue">
                <asp:Button ID="btnSave" runat="server" Text="Save" class="Button" OnClick="btnSave_Click" />
            </div>
        </div>

    </div>
</asp:Content>
