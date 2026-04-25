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

        // 1. Aquí guardamos el ID del papá que nos mandó la pantalla de cobros
        private string idTitularRecibido;
        private int limiteMaximo;
        private string municipioTitular;

        // 2. Esta es la "Memoria Temporal" que sabe qué deporte eligió cada hijo
        // (Ejemplo: Al ID "005" le tocan los deportes 1 y 3)
        private Dictionary<string, List<int>> memoriaSeleccion = new Dictionary<string, List<int>>();

        // 3. Esta es la cajita final que se llevará la pantalla de cobros cuando le demos a Guardar
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
                    // EL SQL MAESTRO: Rastrea al titular original y trae a todos los que compartan su ID
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

            // 2. Obtenemos el ID oculto del familiar seleccionado (Ej: "005")
            string idSeleccionado = cmbMiembros.SelectedValue.ToString();

            // 3. Verificamos que este ID ya exista en nuestra memoria RAM
            if (!memoriaSeleccion.ContainsKey(idSeleccionado)) return;

            // 4. Sacamos la lista de deportes que tiene esta persona
            List<int> deportesDeEstaPersona = memoriaSeleccion[idSeleccionado];

            // 5. Encendemos o apagamos los botones (¡OJO! Cambia los nombres de los botones por los tuyos y el número por el ID de tu base de datos)
            btnAcondicionamiento.BackColor = deportesDeEstaPersona.Contains(1) ? Color.LightGreen : Color.White;
            btnFutbol.BackColor = deportesDeEstaPersona.Contains(2) ? Color.LightGreen : Color.White;
            btnHeterofilia.BackColor = deportesDeEstaPersona.Contains(3) ? Color.LightGreen : Color.White;
            btnTaekwondo.BackColor = deportesDeEstaPersona.Contains(4) ? Color.LightGreen : Color.White;
            btnRitmos.BackColor = deportesDeEstaPersona.Contains(5) ? Color.LightGreen : Color.White;
            // Agrega aquí los demás botones que tengas...

        }

        private void cmbMiembros_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarColoresBotones();
        }
        private void ToggleDeporteFamiliar(Button btn, int idDeporte)
        {
            if (cmbMiembros.SelectedValue == null) return;
            string idSeleccionado = cmbMiembros.SelectedValue.ToString();

            if (memoriaSeleccion[idSeleccionado].Contains(idDeporte))
            {
                memoriaSeleccion[idSeleccionado].Remove(idDeporte);
            }
            else
            {
                memoriaSeleccion[idSeleccionado].Add(idDeporte);
            }

            ActualizarColoresBotones();
        }

        private void btnAcondicionamiento_Click(object sender, EventArgs e)
        {
            ToggleDeporteFamiliar((Button)sender, 1);
        }

        private void btnFutbol_Click(object sender, EventArgs e)
        {
            ToggleDeporteFamiliar((Button)sender, 2);
        }

        private void btnTaekwondo_Click(object sender, EventArgs e)
        {
            ToggleDeporteFamiliar((Button)sender, 3);
        }

        private void btnHeterofilia_Click(object sender, EventArgs e)
        {
            ToggleDeporteFamiliar((Button)sender, 4);
        }

        private void btnRitmos_Click(object sender, EventArgs e)
        {
            ToggleDeporteFamiliar((Button)sender, 5);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            foreach (var registro in memoriaSeleccion)
            {
                string idCliente = registro.Key;
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
                    string query = "SELECT id_cliente, nombre, municipio, CONCAT(id_cliente, ' - ', nombre) AS info_completa FROM clientes WHERE id_cliente = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@id", idNuevo); // Ahora busca "00002"

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string municipioNuevo = reader["municipio"].ToString();

                        // REGLA DE VALIDACIÓN:
                        if (municipioNuevo != municipioTitular)
                        {
                            MessageBox.Show($"No puedes agregar a esta persona. El titular es de '{municipioTitular}' y esta persona es de '{municipioNuevo}'. Todos deben ser del mismo municipio.", "Conflicto de Ubicación", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            reader.Close();
                            return;
                        }

                        // Verificamos si ya está en la lista para no duplicarlo
                        if (memoriaSeleccion.ContainsKey(idNuevo))
                        {
                            MessageBox.Show("Esta persona ya está agregada en el paquete actual.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            // ¡Lo encontramos! Lo agregamos a la tabla visual (ComboBox)
                            DataRow nuevaFila = dtActual.NewRow();
                            nuevaFila["id_cliente"] = reader["id_cliente"].ToString();
                            nuevaFila["nombre"] = reader["nombre"].ToString();
                            nuevaFila["info_completa"] = reader["info_completa"].ToString();
                            dtActual.Rows.Add(nuevaFila);

                            // Lo agregamos a la Memoria RAM de deportes
                            memoriaSeleccion.Add(idNuevo, new List<int>());

                            MessageBox.Show($"{reader["nombre"]} agregado al paquete.", "Éxito");
                            txtAgregar.Clear();
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
    }
}









