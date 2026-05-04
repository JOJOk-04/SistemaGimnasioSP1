using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AccesosGimnasioSP1
{
    public partial class FrmPruebaAccesos : Form
    {
        // 1. Declaramos el Timer
        private Timer timerLimpieza = new Timer();

        public FrmPruebaAccesos()
        {
            InitializeComponent();
            this.TextBoxId.KeyDown += new KeyEventHandler(TextBoxId_KeyDown);

            // 2. Configuramos el Timer
            timerLimpieza.Interval = 5000; // 5 segundos
            timerLimpieza.Tick += TimerLimpieza_Tick;
        }

        // Este evento se ejecuta cuando pasan los 5 segundos
        private void TimerLimpieza_Tick(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
            timerLimpieza.Stop();
        }

        // Método auxiliar para mostrar mensajes y resetear el tiempo
        private void MostrarMensajeTemporal(string mensaje, Color color, string nombre)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.ForeColor = color;
            // Si tienes un label específico para el nombre, úsalo, si no, puedes concatenar
            // Asumo que lblMensaje es el que usas para el estatus y el nombre

            timerLimpieza.Stop();
            timerLimpieza.Start();
        }

        private void BtnBuscarId_Click(object sender, EventArgs e)
        {
            EjecutarProcesoAcceso();
        }

        private void TextBoxId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                EjecutarProcesoAcceso();
            }
        }

        private void EjecutarProcesoAcceso()
        {
            string gafete = TextBoxId.Text.Trim();
            if (!string.IsNullOrWhiteSpace(gafete))
            {
                VerificarAcceso(gafete);
            }
        }

        private void VerificarAcceso(string idCliente)
        {
            if (idCliente.Length != 5 || !int.TryParse(idCliente, out _))
            {
                MostrarMensajeTemporal("ID INVÁLIDO (5 DÍGITOS)", Color.Red, "---");
                TextBoxId.Clear();
                TextBoxId.Focus();
                return;
            }

            ConexionDB baseDatos = new ConexionDB();
            MySqlConnection conexion = baseDatos.AbrirConexion();

            if (conexion == null)
            {
                MostrarMensajeTemporal("ERROR DE RED", Color.Orange, "---");
                return;
            }

            try
            {
                // 1. Buscamos al cliente y su estatus
                string queryBuscar = @"
                    SELECT c.nombre, 
                           IF(i.fecha_vencimiento >= CURDATE(), 'Activo', 'Inactivo') AS estatus_calculado 
                    FROM Clientes c 
                    INNER JOIN Inscripciones i ON c.id_cliente = i.id_cliente 
                    WHERE c.id_cliente = @id 
                    ORDER BY i.fecha_vencimiento DESC LIMIT 1";

                using (MySqlCommand cmdBuscar = new MySqlCommand(queryBuscar, conexion))
                {
                    cmdBuscar.Parameters.AddWithValue("@id", idCliente);
                    using (MySqlDataReader lector = cmdBuscar.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            string estatus = lector["estatus_calculado"].ToString();
                            string nombre = lector["nombre"].ToString().Trim();
                            lector.Close(); // Necesario cerrar antes de otra consulta

                            if (estatus == "Activo")
                            {
                                // 2. VALIDACIÓN: Verificar si ya tiene asistencia hoy
                                string queryVerificar = "SELECT COUNT(*) FROM accesos_diarios WHERE id_cliente = @id AND DATE(fecha_hora) = CURDATE()";

                                using (MySqlCommand cmdVerificar = new MySqlCommand(queryVerificar, conexion))
                                {
                                    cmdVerificar.Parameters.AddWithValue("@id", idCliente);
                                    int cantidadHoy = Convert.ToInt32(cmdVerificar.ExecuteScalar());

                                    if (cantidadHoy == 0)
                                    {
                                        // No ha entrado hoy, registramos
                                        string queryIngreso = "INSERT INTO accesos_diarios (id_cliente, fecha_hora, id_deporte) VALUES (@id, NOW(), 1)";
                                        using (MySqlCommand cmdIngreso = new MySqlCommand(queryIngreso, conexion))
                                        {
                                            cmdIngreso.Parameters.AddWithValue("@id", idCliente);
                                            cmdIngreso.ExecuteNonQuery();
                                        }
                                        MostrarMensajeTemporal("¡ACCESO CONCEDIDO!", Color.LimeGreen, "Bienvenido, " + nombre);
                                    }
                                    else
                                    {
                                        // Ya tiene asistencia
                                        MostrarMensajeTemporal("YA REGISTRADO HOY", Color.Blue, "Bienvenido de nuevo, " + nombre);
                                    }
                                }
                            }
                            else
                            {
                                MostrarMensajeTemporal("MENSUALIDAD VENCIDA", Color.Red, nombre);
                            }
                        }
                        else
                        {
                            MostrarMensajeTemporal("GAFETE NO VÁLIDO", Color.Orange, "---");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el sistema: " + ex.Message, "Error de SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baseDatos.CerrarConexion();
                TextBoxId.Clear();
                TextBoxId.Focus();
            }
        }
    }
}