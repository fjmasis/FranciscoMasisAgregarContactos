using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.UI;
using Newtonsoft.Json;

namespace FranciscoMasisAgregarContactos.Pages
{
    public partial class AgregarContacto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarContactos();
            }
        }

        protected void AgregarContacto_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear el objeto JSON para enviar al API
                string jsonData = $"{{\"Nombre\":\"{txtNombre.Text}\",\"Apellido\":\"{txtApellido.Text}\",\"Telefono\":\"{txtTelefono.Text}\",\"Email\":\"{txtEmail.Text}\"}}";

                // Configurar la solicitud POST al API
                WebRequest request = WebRequest.Create("http://localhost:5177/api/agenda"); 
                request.Method = "POST";
                request.ContentType = "application/json";

                // Enviar los datos JSON en el cuerpo de la solicitud
                using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
                {
                    writer.Write(jsonData);
                    writer.Flush();
                }

                // Obtener la respuesta del servidor
                using (WebResponse response = request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string result = reader.ReadToEnd();
                        Response.Write("<script>alert('Contacto agregado con éxito.');</script>");
                    }
                }

                // Actualizar la lista de contactos
                CargarContactos();
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error al agregar el contacto: {ex.Message}');</script>");
            }
        }

        private void CargarContactos()
        {
            try
            {
                // Configurar la solicitud GET al API
                WebRequest request = WebRequest.Create("http://localhost:5177/api/agenda"); // URL correcta
                request.Method = "GET";

                // Obtener la respuesta del servidor
                using (WebResponse response = request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string jsonContent = reader.ReadToEnd();

                        // Deserializar el contenido JSON en una lista de contactos
                        var contactos = JsonConvert.DeserializeObject<List<Contacto>>(jsonContent);

                        // Mostrar los contactos en el GridView
                        gvContactos.DataSource = contactos;
                        gvContactos.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error al cargar los contactos: {ex.Message}');</script>");
            }
        }
    }

    // Clase Contacto para mapear los datos del API
    public class Contacto
    {
        public int IdContacto { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
    }
}
