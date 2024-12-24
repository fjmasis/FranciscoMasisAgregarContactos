<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarContacto.aspx.cs" Inherits="FranciscoMasisAgregarContactos.Pages.AgregarContacto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Agregar Contacto</title>
</head>
<body>
    <h1 id="formHeader">Agregar Contacto</h1>
    <form id="formAgregarContacto" runat="server">
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
    </form>
</body>
</html>
