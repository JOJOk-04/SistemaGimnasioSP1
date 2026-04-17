using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaGimnasioSP
{
    public partial class FrmConsultas : Form
    {
            public FrmConsultas()
            {
                InitializeComponent();
            }

        // Método para limpiar la pantalla si no se encuentra al socio
        private void LimpiarFicha()
        {
            lblNombreResultado.Text = "Nombre: ---";
            lblMunicipioResultado.Text = "Municipio: ---";
            lblEstatusResultado.Text = "Estatus: ---";
            lblEdadResultado.Text = "Edad: ---";
            lblEstatusResultado.ForeColor = Color.Black; // Regresa el color a la normalidad
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // 1. EL TRUCO: .Trim() borra los espacios accidentales al inicio o al final
            string textoBuscado = txtBuscar.Text.Trim();

            if (string.IsNullOrWhiteSpace(textoBuscado)) return;

            ConexionDB baseDatos = new ConexionDB();
            MySqlConnection conexion = baseDatos.AbrirConexion();

            if (conexion == null) return;

            try
            {
                // 2. Usamos LIKE en lugar de "=" para que no sea tan estricto
                string query = "SELECT nombre, fecha_nacimiento, municipio, estatus FROM Clientes WHERE id_cliente LIKE @busqueda OR nombre LIKE @busqueda LIMIT 1";

                MySqlCommand cmd = new MySqlCommand(query, conexion);

                // 3. Los "%" a los lados le dicen a MySQL: "Tráeme lo que contenga este texto, no importa si hay letras antes o después"
                cmd.Parameters.AddWithValue("@busqueda", "%" + textoBuscado + "%");

                MySqlDataReader lector = cmd.ExecuteReader();

                if (lector.Read()) // Si encontró a alguien...
                {
                    lblNombreResultado.Text = "Nombre: " + lector["nombre"].ToString();
                    lblMunicipioResultado.Text = "Municipio: " + lector["municipio"].ToString();

                    string estatus = lector["estatus"].ToString();
                    lblEstatusResultado.Text = "Estatus: " + estatus;

                    DateTime fechaNac = Convert.ToDateTime(lector["fecha_nacimiento"]);
                    int edad = DateTime.Today.Year - fechaNac.Year;
                    if (fechaNac.Date > DateTime.Today.AddYears(-edad)) edad--;

                    lblEdadResultado.Text = "Edad: " + edad + " años";
                    lblEstatusResultado.ForeColor = (estatus == "Activo") ? Color.Green : Color.Red;
                }
                else
                {
                    MessageBox.Show("No se encontró ningún socio con ese ID o nombre.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    LimpiarFicha();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar: " + ex.Message);
            }
            finally
            {
                baseDatos.CerrarConexion();
            }
    }
    }
}