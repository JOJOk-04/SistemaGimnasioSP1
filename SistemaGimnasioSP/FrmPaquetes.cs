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

        // 2. Esta es la "Memoria Temporal" que sabe qué deporte eligió cada hijo
        // (Ejemplo: Al ID "005" le tocan los deportes 1 y 3)
        private Dictionary<string, List<int>> memoriaSeleccion = new Dictionary<string, List<int>>();

        // 3. Esta es la cajita final que se llevará la pantalla de cobros cuando le demos a Guardar
        public List<InscripcionTemporal> ResultadoFinal = new List<InscripcionTemporal>();
       


        // --- TU CONSTRUCTOR INICIA AQUÍ ABAJO ---
        public FrmPaquetes(string idTitular, int limite)
        {
            InitializeComponent();
            this.idTitularRecibido = idTitular;
            this.limiteMaximo = limite; // Guardamos el límite que nos mandaron

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
                    // Buscamos al titular y a quienes tengan a ese titular asignado
                    string query = @"SELECT id_cliente, nombre, 
                             CONCAT(id_cliente, ' - ', nombre) AS info_completa 
                             FROM clientes 
                             WHERE id_cliente = @id 
                             OR id_titular_familia = @id";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@id", idTitularRecibido);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // VALIDACIÓN DE LÍMITE:
                    // Si la base de datos tiene más personas de las que el paquete permite
                    if (dt.Rows.Count > limiteMaximo)
                    {
                        MessageBox.Show($"Este paquete solo permite {limiteMaximo} personas, " +
                                        $"pero se encontraron {dt.Rows.Count} ligadas a este ID. " +
                                        $"Solo podrás asignar a las primeras {limiteMaximo}.", "Aviso de Capacidad");
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
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
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
                    // Calculas si es extra o no basándote en la cuenta de la lista
                    decimal monto = (registro.Value.IndexOf(idDeporte) == 0) ? 0 : 100;

                    ResultadoFinal.Add(new InscripcionTemporal
                    {
                        IdCliente = idCliente,
                        IdDeporte = idDeporte,
                        Monto = monto
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
    }
}
