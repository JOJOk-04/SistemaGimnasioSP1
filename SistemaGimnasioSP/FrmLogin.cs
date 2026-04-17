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

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            // 1. Atrapamos lo que escribieron
            string usuario = txtUsuario.Text.Trim();
            string password = txtPassword.Text.Trim();

            // 2. Validamos que no estén vacíos
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, ingresa tu usuario y contraseña.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Llamamos a nuestra conexión que ya sabemos que funciona
            ConexionDB bd = new ConexionDB();
            MySqlConnection conexion = bd.AbrirConexion();

            if (conexion != null)
            {
                try
                {
                    // 4. Buscamos al usuario en MySQL
                    string query = "SELECT id_usuario, nombre_completo, rol FROM Usuarios WHERE usuario_login = @user AND contrasena = @pass";
                    MySqlCommand comando = new MySqlCommand(query, conexion);

                    // Bloqueamos inyecciones SQL
                    comando.Parameters.AddWithValue("@user", usuario);
                    comando.Parameters.AddWithValue("@pass", password);

                    // 5. Leemos el resultado
                    MySqlDataReader lector = comando.ExecuteReader();

                    if (lector.Read()) // ¡Sí existe y la clave es correcta!
                    {
                        string nombre = lector["nombre_completo"].ToString();
                        string rol = lector["rol"].ToString();
                        string idUsuario = lector["id_usuario"].ToString();

                        // 1. Creamos el objeto de la nueva ventana mandándole el nombre y rol (opcional, pero útil)
                        FrmMenuPrincipal ventanaMenu = new FrmMenuPrincipal();

                        // 2. Mostramos el Menú Principal
                        ventanaMenu.Show();

                        // 3. Ocultamos el Login para que no estorbe atrás
                        this.Hide();

                        // TODO: Aquí después agregaremos el código para abrir el Menú Principal y esconder el Login
                    }
                    else // No existe o se equivocó de clave
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPassword.Clear(); // Limpiamos la clave para que vuelva a intentar
                        txtUsuario.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la validación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    bd.CerrarConexion(); // Cerramos la puerta
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
