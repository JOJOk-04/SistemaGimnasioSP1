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
    public partial class FrmCortes : Form
    {
        public FrmCortes()
        {
            InitializeComponent();
        }


            // 1. EVENTO LOAD: Se ejecuta al abrir la pantalla
            private void FrmCortes_Load(object sender, EventArgs e)
            {
                // 🌟 TRUCO PRO: Calcular automáticamente el "Jueves Pasado"
                DateTime hoy = DateTime.Today;
                int diasRestar = (int)hoy.DayOfWeek - (int)DayOfWeek.Thursday;
                if (diasRestar < 0) diasRestar += 7; // Si hoy es mar/mie, regresamos a la semana pasada

                dtpDesde.Value = hoy.AddDays(-diasRestar);
                dtpHasta.Value = hoy; // Hasta hoy

                // Mostramos el número de folio actual
                CargarProximoFolio();
            }

            // 2. BOTÓN CONSULTAR: El que hace la magia
            private void btnConsultar_Click(object sender, EventArgs e)
            {
                GenerarCorte();
            }

            // 3. EL CEREBRO: La consulta SQL con INNER JOIN
            private void GenerarCorte()
            {
                ConexionDB bd = new ConexionDB();
                MySqlConnection conexion = bd.AbrirConexion();

                if (conexion == null) return;

                try
                {
                    // ✨ LA MAGIA DEL SQL: 
                    // Viajamos de la tabla Inscripciones -> Clientes -> Deportes para armar el ticket.
                    // El IF() de MySQL decide el precio automáticamente leyendo el municipio.
                    string query = @"
                    SELECT 
                        CONCAT('1-', LPAD(i.id_inscripcion, 5, '0')) AS Folio,
                        i.fecha_pago AS Fecha,
                        c.nombre AS Cliente,
                        d.nombre_deporte AS Concepto,
                        IF(c.municipio = 'San Pedro Garza García', 'Local', 'Foráneo') AS Tipo,
                        IF(c.municipio = 'San Pedro Garza García', d.precio_local, d.precio_foraneo) AS Monto_Cobrado
                    FROM inscripciones i
                    INNER JOIN clientes c ON i.id_cliente = c.id_cliente
                    INNER JOIN deportes d ON i.id_deporte = d.id_deporte
                    WHERE i.fecha_pago >= @inicio AND i.fecha_pago <= @fin
                    ORDER BY i.fecha_pago DESC, i.id_inscripcion DESC";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);

                    // Le pasamos las fechas de los calendarios a MySQL
                    cmd.Parameters.AddWithValue("@inicio", dtpDesde.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@fin", dtpHasta.Value.ToString("yyyy-MM-dd"));

                    MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
                    DataTable tablaCortes = new DataTable();
                    adaptador.Fill(tablaCortes);

                    // 1. Llenamos la tabla visual (DataGridView)
                    dgvCortes.DataSource = tablaCortes;

                    // 2. Calculamos el dinero contándolo directo de la tabla resultante
                    decimal granTotal = 0;
                    foreach (DataRow fila in tablaCortes.Rows)
                    {
                        granTotal += Convert.ToDecimal(fila["Monto_Cobrado"]);
                    }

                    // 3. Actualizamos la tarjeta verde gigante
                    lblGranTotal.Text = $"GRAN TOTAL: {granTotal:C}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al generar el corte: " + ex.Message, "Auditoría", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    bd.CerrarConexion();
                }
            }

            // 4. EL FOLIO: Para saber en qué recibo vamos (Arquitectura Multi-Sucursal)
            private void CargarProximoFolio()
            {
                ConexionDB bd = new ConexionDB();
                MySqlConnection conexion = bd.AbrirConexion();

                if (conexion != null)
                {
                    try
                    {
                        // Buscamos el ID más grande que exista y le sumamos 1
                        string query = "SELECT MAX(id_inscripcion) FROM inscripciones";
                        MySqlCommand cmd = new MySqlCommand(query, conexion);

                        object resultado = cmd.ExecuteScalar();
                        int maxId = (resultado == DBNull.Value || resultado.ToString() == "") ? 0 : Convert.ToInt32(resultado);
                        int proximoId = maxId + 1;

                        // Formateamos para que se vea estilo ticket: 1-00025
                        lblFolioSiguiente.Text = $"Próximo Folio: 1-{proximoId:D5}";
                    }
                    catch { } // Ignoramos errores menores aquí
                    finally { bd.CerrarConexion(); }
                }
            }

        private void lblFolioSiguiente_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalServicios_Click(object sender, EventArgs e)
        {

        }

        private void lblGranTotal_Click(object sender, EventArgs e)
        {

        }
    }
}
