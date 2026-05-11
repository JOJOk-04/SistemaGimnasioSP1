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

        // Se mantiene una sola definición de la clase interna
        public class ItemDeporte
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public override string ToString() { return Nombre; }
        }

        public FrmPruebaAccesos()
        {
            InitializeComponent();
            this.TextBoxId.KeyDown += new KeyEventHandler(TextBoxId_KeyDown);
            timerLimpieza.Interval = 5000;
            timerLimpieza.Tick += TimerLimpieza_Tick;
            this.Load += FrmPruebaAccesos_Load;
        }

        private void FrmPruebaAccesos_Load(object sender, EventArgs e)
        {
            BtnOpcionesDeportes.Items.Clear();

            ConexionDB baseDatos = new ConexionDB();
            MySqlConnection conexion = baseDatos.AbrirConexion();

            if (conexion != null)
            {
                try
                {
                    // Cargamos los deportes disponibles para el ComboBox/Botón
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

                    if (result != null)
                    {
                        string nombre = result.ToString();

                        string queryAsistencia = @"
                            SELECT COUNT(*) 
                            FROM accesos_diarios 
                            WHERE id_cliente = @id 
                            AND id_deporte = @idDeporte 
                            AND DATE(fecha_hora) = CURDATE()";

                        using (MySqlCommand cmdAsistencia = new MySqlCommand(queryAsistencia, conexion))
                        {
                            cmdAsistencia.Parameters.AddWithValue("@id", idCliente);
                            cmdAsistencia.Parameters.AddWithValue("@idDeporte", idDeporte);

                            int yaEntro = Convert.ToInt32(cmdAsistencia.ExecuteScalar());

                            if (yaEntro == 0)
                            {
                                string queryInsert = "INSERT INTO accesos_diarios (id_cliente, fecha_hora, id_deporte) VALUES (@id, NOW(), @idDeporte)";
                                using (MySqlCommand cmdInsert = new MySqlCommand(queryInsert, conexion))
                                {
                                    cmdInsert.Parameters.AddWithValue("@id", idCliente);
                                    cmdInsert.Parameters.AddWithValue("@idDeporte", idDeporte);
                                    cmdInsert.ExecuteNonQuery();
                                }
                                MostrarMensajeTemporal($"¡ACCESO: {nombre}!", Color.LimeGreen, nombre);
                            }
                            else
                            {
                                MostrarMensajeTemporal("YA SE REGISTRÓ HOY EN ESTE DEPORTE", Color.Orange, nombre);
                            }
                        }
                    }
                    else
                    {
                        MostrarMensajeTemporal("SIN INSCRIPCIÓN VIGENTE EN ESTE DEPORTE", Color.Red, "---");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el proceso: " + ex.Message);
            }
            finally
            {
                baseDatos.CerrarConexion();
                TextBoxId.Clear();
                TextBoxId.Focus();
            }
        }

        private void TextBoxId_TextChanged(object sender, EventArgs e)
        {
        }
    }
}