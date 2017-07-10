<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/AdminFolder/Admin.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Siregra.Home" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

    <link rel="stylesheet" type="text/css" href="css/MainCSS.css" />
        <script lang="javascript">
     function show()
        {
            document.write("<head runat='server'></head>");
        }
    </script>
    <style>
        .SiregraLogo {
            position: absolute;
            margin: 0 auto;
            left:50%;
            top:50%;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="upanel" runat="server">
        <ContentTemplate>
       <div runat="server" class="SiregraLogo">
        <asp:Image runat="server" ImageUrl="~/images/SiregraLogo.png"/>
    </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>
