<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarContacto.aspx.cs" Inherits="FranciscoMasisAgregarContactos.Pages.AgregarContacto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Agregar Contactos</title>
    <link rel="stylesheet" type="text/css" href="../styles/styles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <h1 id="formHeader">Agregar Contacto</h1>
        <div class="form-input">
            <asp:Label Text="Nombre:" AssociatedControlID="txtNombre" runat="server" />
            <asp:TextBox ID="txtNombre" runat="server" />
        </div>
        <div class="form-input">
            <asp:Label Text="Apellido:" AssociatedControlID="txtApellido" runat="server" />
            <asp:TextBox ID="txtApellido" runat="server" />
        </div>
        <div class="form-input">
            <asp:Label Text="Teléfono:" AssociatedControlID="txtTelefono" runat="server" />
            <asp:TextBox ID="txtTelefono" runat="server" />
        </div>
        <div class="form-input">
            <asp:Label Text="Email:" AssociatedControlID="txtEmail" runat="server" />
            <asp:TextBox ID="txtEmail" runat="server" />
            <asp:RegularExpressionValidator
                ControlToValidate="txtEmail"
                ErrorMessage="Email inválido"
                ValidationExpression="\w+@\w+\.\w+"
                runat="server" />
        </div>
        <asp:Button Text="Agregar" CssClass="btn-submit" OnClick="AgregarContacto_Click" runat="server" />

        <h3 id="listHeader">Listado de Contactos</h3>
        <asp:GridView ID="gvContactos" AutoGenerateColumns="true" CssClass="grid-view" runat="server" />
    </form>
</body>
</html>
