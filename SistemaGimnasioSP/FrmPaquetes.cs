using MySql.Data.MySqlClient;
using Mysqlx.Crud;
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
    public partial class FrmPaquetes : Form
    {

        
        private string idTitularRecibido;
        private int limiteMaximo;
        private string municipioTitular;
        private Dictionary<string, List<int>> memoriaSeleccion = new Dictionary<string, List<int>>();
        public List<InscripcionTemporal> ResultadoFinal = new List<InscripcionTemporal>();



        // --- TU CONSTRUCTOR INICIA AQUÍ ABAJO ---
        public FrmPaquetes(string idTitular, int limite, string municipio)
        {
            InitializeComponent();
            this.idTitularRecibido = idTitular;
            this.limiteMaximo = limite; // Guardamos el límite que nos mandaron
            this.municipioTitular = municipio;
            // Llamamos a la función de carga
            CargarIntegrantes();

        }

        private void CargarIntegrantes()
        {
            ConexionDB baseDatos = new ConexionDB();
            MySqlConnection conexion = baseDatos.AbrirConexion();

            if (conexion != null)
            {
                try
                {
                    // Rastrea al titular original y trae a todos los que compartan su ID
                    string query = @"
                SELECT id_cliente, nombre, CONCAT(id_cliente, ' - ', nombre) AS info_completa 
                FROM clientes 
                WHERE id_titular_familia = (SELECT id_titular_familia FROM clientes WHERE id_cliente = @id)
                   OR id_cliente = (SELECT id_titular_familia FROM clientes WHERE id_cliente = @id)
                   OR id_titular_familia = @id
                   OR id_cliente = @id";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@id", idTitularRecibido);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // VALIDACIÓN DE LÍMITE
                    if (dt.Rows.Count > limiteMaximo)
                    {
                        MessageBox.Show($"Este paquete solo permite {limiteMaximo} personas, " +
                                        $"pero se encontraron {dt.Rows.Count} ligadas a este grupo. " +
                                        $"Solo podrás asignar a las primeras {limiteMaximo}.", "Aviso de Capacidad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    cmbMiembros.DataSource = dt;
                    cmbMiembros.DisplayMember = "info_completa";
                    cmbMiembros.ValueMember = "id_cliente";

                    // Inicializamos la memoria RAM para cada uno
                    memoriaSeleccion.Clear();
                    foreach (DataRow fila in dt.Rows)
                    {
                        memoriaSeleccion.Add(fila["id_cliente"].ToString(), new List<int>());
                    }
                }
                catch (Exception ex) { MessageBox.Show("Error al cargar familia: " + ex.Message); }
                finally { baseDatos.CerrarConexion(); }
            }
        }
        private void ActualizarColoresBotones()
        {
            // 1. Verificamos que haya alguien seleccionado
            if (cmbMiembros.SelectedValue == null) return;

            // 2. Extraemos el ID de forma segura (por si el ComboBox devuelve toda la fila)
            string idSeleccionado = "";
            if (cmbMiembros.SelectedValue is DataRowView filaVista)
            {
                idSeleccionado = filaVista["id_cliente"].ToString();
            }
            else
            {
                idSeleccionado = cmbMiembros.SelectedValue.ToString();
            }

            // 3. Verificamos que este ID exista en nuestra memoria RAM
            if (!memoriaSeleccion.ContainsKey(idSeleccionado)) return;

            // 4. Sacamos la lista de deportes que tiene ESTA persona específica
            List<int> deportesDeEstaPersona = memoriaSeleccion[idSeleccionado];

            // 5. ✨ EL SECRETO DE GUNA: Usar FillColor casteando el control ✨
            if (btnAcondicionamiento is Guna.UI2.WinForms.Guna2Button btn1)
                btn1.FillColor = deportesDeEstaPersona.Contains(1) ? Color.LightGreen : Color.White;

            if (btnFutbol is Guna.UI2.WinForms.Guna2Button btn2)
                btn2.FillColor = deportesDeEstaPersona.Contains(2) ? Color.LightGreen : Color.White;

            if (btnHeterofilia is Guna.UI2.WinForms.Guna2Button btn4)
                btn4.FillColor = deportesDeEstaPersona.Contains(4) ? Color.LightGreen : Color.White;

            if (btnTaekwondo is Guna.UI2.WinForms.Guna2Button btn3)
                btn3.FillColor = deportesDeEstaPersona.Contains(3) ? Color.LightGreen : Color.White;

            if (btnRitmos is Guna.UI2.WinForms.Guna2Button btn5)
                btn5.FillColor = deportesDeEstaPersona.Contains(5) ? Color.LightGreen : Color.White;

            // (Si tienes más botones de deportes en tu paquete familiar, agrégalos aquí con la misma lógica)
        }

        private void cmbMiembros_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarColoresBotones();
        }
        private void ToggleDeporteFamiliar(Control btn, int idDeporte)
        {
            if (cmbMiembros.SelectedValue == null) return;
            string idSeleccionado = cmbMiembros.SelectedValue.ToString();

            // Si ya lo tenía seleccionado, lo quitamos (lo apaga)
            if (memoriaSeleccion[idSeleccionado].Contains(idDeporte))
            {
                memoriaSeleccion[idSeleccionado].Remove(idDeporte);
            }
            else
            {
                // 🛑 REGLA 2: Validamos en MySQL si ya lo tiene pagado antes de encenderlo
                if (TieneDeporteActivo(idSeleccionado, idDeporte))
                {
                    return; // Cortamos el flujo, el botón se queda en blanco
                }

                // Si no lo tiene activo, lo agregamos a la memoria
                memoriaSeleccion[idSeleccionado].Add(idDeporte);
            }

            ActualizarColoresBotones();
        }
        private bool TieneDeporteActivo(string idCliente, int idDeporte)
        {
            bool activo = false;
            ConexionDB bd = new ConexionDB();
            MySqlConnection conexion = bd.AbrirConexion();

            if (conexion != null)
            {
                try
                {
                    string query = "SELECT fecha_vencimiento FROM inscripciones WHERE id_cliente = @idC AND id_deporte = @idD AND fecha_vencimiento > CURDATE() LIMIT 1";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@idC", idCliente);
                    cmd.Parameters.AddWithValue("@idD", idDeporte);

                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null && resultado != DBNull.Value)
                    {
                        DateTime fechaVencimiento = Convert.ToDateTime(resultado);
                        MessageBox.Show($"Este familiar ya tiene este deporte pagado y activo.\n\nLa membresía actual vence el: {fechaVencimiento.ToString("dd/MM/yyyy")}.\n\nNo es necesario incluirlo en el paquete por esta disciplina.",
                                        "Suscripción Activa Detectada", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        activo = true;
                    }
                }
                catch (Exception ex) { MessageBox.Show("Error al verificar estatus: " + ex.Message); }
                finally { bd.CerrarConexion(); }
            }
            return activo;
        }

        private void btnAcondicionamiento_Click(object sender, EventArgs e)
        {
            ToggleDeporteFamiliar((Control)sender, 1);
        }

        private void btnFutbol_Click(object sender, EventArgs e)
        {
            ToggleDeporteFamiliar((Control)sender, 2);
        }

        private void btnTaekwondo_Click(object sender, EventArgs e)
        {
            ToggleDeporteFamiliar((Control)sender, 3);
        }

        private void btnHeterofilia_Click(object sender, EventArgs e)
        {
            ToggleDeporteFamiliar((Control)sender, 4);
        }

        private void btnRitmos_Click(object sender, EventArgs e)
        {
            ToggleDeporteFamiliar((Control)sender, 5);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // --- ✨ NUEVA VALIDACIÓN: REGLA DE MÍNIMO DE PERSONAS ---
            int cantidadPersonasActuales = memoriaSeleccion.Count;
            int limiteMinimo = 1; // Por defecto es 1 (para inscripciones normales)

            // Deducimos el mínimo basándonos en el límite máximo del paquete
            if (limiteMaximo == 2)
            {
                limiteMinimo = 2; // El paquete de pareja exige a fuerzas 2 personas
            }
            else if (limiteMaximo > 2)
            {
                limiteMinimo = 3; // El paquete de 3 a 5 exige mínimo 3 personas
            }

            // Si no cumplen con el mínimo, detenemos el guardado
            if (cantidadPersonasActuales < limiteMinimo)
            {
                MessageBox.Show($"Este paquete requiere un mínimo de {limiteMinimo} personas para ser válido.\n\nActualmente solo tienes {cantidadPersonasActuales} persona(s) en la lista. Por favor, agrega a los integrantes faltantes usando el campo de búsqueda.",
                                "Faltan Integrantes",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return; // El "return" cancela el guardado y los deja en la pantalla
            }
            // --------------------------------------------------------

            // Si pasaron la validación del cadenero, ahora sí procesamos el cobro
            foreach (var registro in memoriaSeleccion)
            {
                string idCliente = registro.Key;

                // Opcional: Validar que la persona tenga al menos 1 deporte seleccionado
                if (registro.Value.Count == 0)
                {
                    MessageBox.Show($"El cliente con ID {idCliente} no tiene ningún deporte seleccionado. Selecciona al menos uno.", "Falta Deporte", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                foreach (int idDeporte in registro.Value)
                {
                    // Si es el primer deporte (índice 0), cuesta 0 (ya lo incluye el paquete).
                    // Si es el segundo o más, le ponemos un "1" (como bandera de "Deporte Extra")
                    decimal cobroExtra = (registro.Value.IndexOf(idDeporte) == 0) ? 0 : 1;

                    ResultadoFinal.Add(new InscripcionTemporal
                    {
                        IdCliente = idCliente,
                        IdDeporte = idDeporte,
                        Monto = cobroExtra // FrmCobros se encargará de convertir este 1 en dinero real
                    });
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public class InscripcionTemporal
        {
            public string IdCliente { get; set; }
            public int IdDeporte { get; set; }
            public decimal Monto { get; set; }
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            string idNuevo = txtAgregar.Text.Trim();
            if (string.IsNullOrWhiteSpace(idNuevo)) return;

            // ✨ EL TRUCO DE LOS CEROS: Convierte "2" en "00002" automáticamente
            if (idNuevo.Length < 5 && int.TryParse(idNuevo, out int idNumerico))
            {
                idNuevo = idNumerico.ToString("D5");
            }

            // 1. Verificamos que no pasemos el límite del paquete
            DataTable dtActual = (DataTable)cmbMiembros.DataSource;

            if (dtActual.Rows.Count >= limiteMaximo)
            {
                MessageBox.Show($"¡El paquete ya está lleno! Límite: {limiteMaximo} personas.", "Límite Alcanzado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Buscamos al cliente en MySQL
            ConexionDB bd = new ConexionDB();
            MySqlConnection conexion = bd.AbrirConexion();

            if (conexion != null)
            {
                try
                {
                    // ✨ TRAEMOS id_titular_familia PARA VALIDAR
                    string query = "SELECT id_cliente, nombre, municipio, id_titular_familia, CONCAT(id_cliente, ' - ', nombre) AS info_completa FROM clientes WHERE id_cliente = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@id", idNuevo);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string municipioNuevo = reader["municipio"].ToString();
                        string titularExistente = reader["id_titular_familia"].ToString();

                        // 🛑 REGLA 1: Evitar que esté en múltiples paquetes
                        // Si ya tiene un titular, y NO es el de este paquete, lo bloqueamos de inmediato
                        if (!string.IsNullOrWhiteSpace(titularExistente) && titularExistente != idTitularRecibido && titularExistente != idNuevo)
                        {
                            MessageBox.Show($"Esta persona ya pertenece a otro paquete familiar (Titular ID: {titularExistente}).\n\nNo puede estar inscrita en dos paquetes a la vez.", "Bloqueo de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        // Verificamos si ya está en la lista actual para no duplicarlo en la vista
                        if (memoriaSeleccion.ContainsKey(idNuevo))
                        {
                            MessageBox.Show("Esta persona ya está agregada en el paquete actual.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            DataRow nuevaFila = dtActual.NewRow();
                            nuevaFila["id_cliente"] = reader["id_cliente"].ToString();
                            nuevaFila["nombre"] = reader["nombre"].ToString();
                            nuevaFila["info_completa"] = reader["info_completa"].ToString();
                            dtActual.Rows.Add(nuevaFila);

                            memoriaSeleccion.Add(idNuevo, new List<int>());

                            MessageBox.Show($"{reader["nombre"]} agregado al paquete.", "Éxito");
                            txtAgregar.Clear();

                            // ✨ REGLA 3: Forzamos el reinicio de los Toggles
                            // Seleccionamos al nuevo integrante, lo que disparará el evento de limpiar colores
                            cmbMiembros.SelectedValue = idNuevo;
                        }
                    }
                    else
                    {
                        MessageBox.Show($"No se encontró ningún cliente con el ID: {idNuevo}", "Error de Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    reader.Close();
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
                finally { bd.CerrarConexion(); }
            }
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void Heterofilia_Click(object sender, EventArgs e)
        {

        }

        private void FrmPaquetes_Load(object sender, EventArgs e)
        {

        }
    }
}