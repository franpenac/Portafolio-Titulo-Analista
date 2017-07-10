<%@ Page Title="" Language="C#" MasterPageFile="~/AdminFolder/Admin.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Siregra.AdminFolder.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header id="header">
			<h1 class="site_title"><asp:Label runat="server" Font-Italic="true">SIREGRA</asp:Label></h1>
			<h2 class="section_title">Siregra System</h2><div class="btn_view_site"><asp:LinkButton runat="server">Log Out</asp:LinkButton></div>
	</header> <!-- end of header bar -->
	
	<section id="secondary_bar">
		<div class="user">
			<p><a>Rodrigo Vidal</a></p>
			<!-- <a class="logout_user" href="#" title="Logout">Logout</a> -->
		</div>
	</section><!-- end of secondary bar -->
	
	<aside id="sidebar" class="column" style="width:210px">
		<hr/>
		<h3>Configuracion</h3>
		<ul class="toggle">
			<li class="icn_new_article"><asp:LinkButton ID="lnkBtnCrearRepuesto" runat="server">Creación de Repuesto</asp:LinkButton></li>
			<li class="icn_new_article"><asp:LinkButton ID="lnkBtnCrearTaller" runat="server">Creación de Taller</asp:LinkButton></li>
            <li class="icn_new_article"><asp:LinkButton ID="lnkBtnCrearMantencion" runat="server">Creación de Mantencion</asp:LinkButton></li>
		</ul>
		<h3>Acciones</h3>
		<ul class="toggle">
            <li class="icn_edit_article"><asp:LinkButton ID="lnkBtnOperaciones" runat="server">Operaciones</asp:LinkButton></li>
            <li class="icn_edit_article"><asp:LinkButton ID="lnkBtnAsignacionRepuestos" runat="server">Asignacion de Repuestos</asp:LinkButton></li>
            <li class="icn_edit_article"><asp:LinkButton ID="lnkBtnAsignacionServicios" runat="server">Asignacion de Servicios</asp:LinkButton></li>
            <li class="icn_edit_article"><asp:LinkButton ID="lnkBtnRevisarMantencion" runat="server">Revisar Mantencion</asp:LinkButton></li>
		</ul>
		<h3>Usuarios</h3>
		<ul class="toggle">
            <li class="icn_add_user"><asp:LinkButton ID="lnkBtnRegistrar" runat="server">Registrar Usuario</asp:LinkButton></li>
		</ul>
		<%--<h3>Admin</h3>
		<ul class="toggle">
			<li class="icn_settings"><a href="#">Options</a></li>
			<li class="icn_security"><a href="#">Security</a></li>
			<li class="icn_jump_back"><a href="#">Logout</a></li>
		</ul>--%>
		
		<footer>
			<hr />
			<p><strong>Copyright &copy; SIREGRA PAGE</strong></p>
			<p>Theme by <a href="http://www.medialoot.com">You dont care mdfk</a></p>
		</footer>
	</aside><!-- end of sidebar -->
	
	<section id="main" class="column">

		</section>

</asp:Content>
