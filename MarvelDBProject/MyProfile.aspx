<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="MarvelDBProject.MyProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="MyProfile">
        <asp:Button ID="btnLogOut" runat="server" Text="Log Out" OnClick="btnLogOut_Click"/>
    </div>

    <style>
        .MyProfile{
            margin:100px;
        }

    </style>
</asp:Content>
