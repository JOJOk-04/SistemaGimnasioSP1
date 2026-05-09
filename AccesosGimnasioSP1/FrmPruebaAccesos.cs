using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AccesosGimnasioSP1
{

    public partial class FrmPruebaAccesos : Form
    {
        private Timer timerLimpieza = new Timer();

        public FrmPruebaAccesos()
        {
            InitializeComponent();
            this.TextBoxId.KeyDown += new KeyEventHandler(TextBoxId_KeyDown);
            timerLimpieza.Interval = 5000;
            timerLimpieza.Tick += TimerLimpieza_Tick;
            this.Load += FrmPruebaAccesos_Load;
        }

        public class ItemDeporte
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public override string ToString() { return Nombre; }
        }

        private void FrmPruebaAccesos_Load(object sender, EventArgs e)
        {
            BtnOpcionesDeportes.Items.Clear();

            // Conectamos a la BD para llenar los deportes
            ConexionDB baseDatos = new ConexionDB();
            MySqlConnection conexion = baseDatos.AbrirConexion();

            if (conexion != null)
            {
                try
                {
                    // CAMBIA 'deportes' POR EL NOMBRE REAL DE TU TABLA DE DEPORTES
                    string query = "SELECT id_deporte, nombre_deporte FROM deportes";
                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                BtnOpcionesDeportes.Items.Add(new ItemDeporte
                                {
                                    Id = Convert.ToInt32(reader["id_deporte"]),
                                    Nombre = reader["nombre_deporte"].ToString()
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar deportes: " + ex.Message);
                }
                finally
                {
                    baseDatos.CerrarConexion();
                }
            }
        }

        private void TimerLimpieza_Tick(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
            timerLimpieza.Stop();
        }

        private void MostrarMensajeTemporal(string mensaje, Color color, string nombre)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.ForeColor = color;
            timerLimpieza.Stop();
            timerLimpieza.Start();
        }

        private void BtnBuscarId_Click(object sender, EventArgs e)
        {
            ProcesarAcceso();
        }

        private void TextBoxId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                ProcesarAcceso();
            }
        }

        private void ProcesarAcceso()
        {
            if (BtnOpcionesDeportes.SelectedItem == null)
            {
                MostrarMensajeTemporal("¡SELECCIONA UN DEPORTE!", Color.Red, "---");
                return;
            }

            ItemDeporte deporteSeleccionado = (ItemDeporte)BtnOpcionesDeportes.SelectedItem;
            int idDeporte = deporteSeleccionado.Id;

            string gafete = TextBoxId.Text.Trim();
            if (!string.IsNullOrWhiteSpace(gafete))
            {
                VerificarAcceso(gafete, idDeporte);
            }
        }

        private void VerificarAcceso(string idCliente, int idDeporte)
        {
            if (idCliente.Length != 5 || !int.TryParse(idCliente, out _))
            {
                MostrarMensajeTemporal("ID INVÁLIDO", Color.Red, "---");
                return;
            }

            ConexionDB baseDatos = new ConexionDB();
            MySqlConnection conexion = baseDatos.AbrirConexion();

            if (conexion == null) return;

            try
            {
                // 1. Buscamos al cliente y verificamos si tiene una inscripción ACTIVA para ESE DEPORTE específico
                // Cambiamos la tabla a 'inscripciones' como pediste anteriormente
                string queryValidarInscripcion = @"
                    SELECT c.nombre 
                    FROM Clientes c 
                    INNER JOIN inscripciones i ON c.id_cliente = i.id_cliente 
                    WHERE c.id_cliente = @id 
                    AND i.id_deporte = @idDeporte 
                    AND i.fecha_vencimiento >= CURDATE() 
                    LIMIT 1";

                using (MySqlCommand cmdValidar = new MySqlCommand(queryValidarInscripcion, conexion))
                {
                    cmdValidar.Parameters.AddWithValue("@id", idCliente);
                    cmdValidar.Parameters.AddWithValue("@idDeporte", idDeporte);

                    object result = cmdValidar.ExecuteScalar();

                    if (result != null) // Si encontró registro, el cliente está activo en ESE deporte
                    {
                        string nombre = result.ToString();

                        // 2. Ahora verificamos si ya registró asistencia en ESE deporte HOY
                        string queryAsistencia = "SELECT COUNT(*) FROM accesos_diarios WHERE id_cliente = @id AND id_deporte = @idDeporte AND DATE(fecha_hora) = CURDATE()";

                        using (MySqlCommand cmdAsistencia = new MySqlCommand(queryAsistencia, conexion))
                        {
                            cmdAsistencia.Parameters.AddWithValue("@id", idCliente);
                            cmdAsistencia.Parameters.AddWithValue("@idDeporte", idDeporte);

                            int yaEntro = Convert.ToInt32(cmdAsistencia.ExecuteScalar());

                            if (yaEntro == 0)
                            {
                                // 3. Insertar el acceso
                                string queryInsert = "INSERT INTO accesos_diarios (id_cliente, fecha_hora, id_deporte) VALUES (@id, NOW(), @idDeporte)";
                                using (MySqlCommand cmdInsert = new MySqlCommand(queryInsert, conexion))
                                {
                                    cmdInsert.Parameters.AddWithValue("@id", idCliente);
                                    cmdInsert.Parameters.AddWithValue("@idDeporte", idDeporte);
                                    cmdInsert.ExecuteNonQuery();
                                }
                                MostrarMensajeTemporal("¡ACCESO CONCEDIDO!", Color.LimeGreen, nombre);
                            }
                            else
                            {
                                MostrarMensajeTemporal("YA ENTRÓ A ESTE DEPORTE HOY", Color.Blue, nombre);
                            }
                        }
                    }
                    else
                    {
                        // Si no encontró registro en la tabla inscripciones para ese ID y ese Deporte
                        MostrarMensajeTemporal("SIN INSCRIPCIÓN VIGENTE", Color.Red, "Revisar Deporte");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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