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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            this.AcceptButton = btnEntrar;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ConexionDB objetoConexion = new ConexionDB();
            if (objetoConexion.AbrirConexion() != null)
            {
                MessageBox.Show("¡Conexión Exitosa con GimnasioSP1!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                objetoConexion.CerrarConexion();
            }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            // 1. Atrapamos lo que escribieron
            string usuario = txtUsuario.Text.Trim();
            string passwordIngresada = txtPassword.Text.Trim();

            // 2. Validamos campos vacíos
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(passwordIngresada))
            {
                MessageBox.Show("Por favor, ingresa tu usuario y contraseña.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ConexionDB bd = new ConexionDB();
            MySqlConnection conexion = bd.AbrirConexion();

            if (conexion != null)
            {
                try
                {
                    // Buscamos solo por usuario para traer su hash y verificarlo aquí en C#.
                    string query = "SELECT id_usuario, nombre_completo, rol, contrasena, estatus FROM Usuarios WHERE usuario_login = @user";
                    MySqlCommand comando = new MySqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@user", usuario);

                    using (MySqlDataReader lector = comando.ExecuteReader())
                    {
                        if (lector.Read()) // Si el usuario existe...
                        {
                            string hashEnBaseDatos = lector["contrasena"].ToString();
                            string estatus = lector["estatus"].ToString();

                            // 4. Verificamos si el usuario está activo
                            if (estatus != "Activo")
                            {
                                MessageBox.Show("Tu cuenta está desactivada. Contacta al administrador.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }

                            // 5. LA MAGIA: Comparamos la clave ingresada contra el Hash de la DB
                            bool esValida = BCrypt.Net.BCrypt.Verify(passwordIngresada, hashEnBaseDatos);

                            if (esValida)
                            {
                                // =================================================================
                                // ✨ AQUÍ LE PONEMOS EL GAFETE VIRTUAL AL USUARIO ✨
                                // =================================================================
                                UsuarioSesion.IdUsuario = Convert.ToInt32(lector["id_usuario"]);
                                UsuarioSesion.NombreCompleto = lector["nombre_completo"].ToString();
                                UsuarioSesion.Rol = lector["rol"].ToString();
                                // =================================================================

                                string nombre = lector["nombre_completo"].ToString();
                                string rol = lector["rol"].ToString();

                                MessageBox.Show($"¡Bienvenido {nombre}! Entrando como {rol}.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                FrmPruebaMenu ventanaMenu = new FrmPruebaMenu();
                                ventanaMenu.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Contraseña incorrecta.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtPassword.Clear();
                                txtPassword.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("El usuario no existe.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la validación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    bd.CerrarConexion();
                }
            }
        }
    }
}
