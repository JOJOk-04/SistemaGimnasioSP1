// 1. Hasta arriba van TODOS tus "usings"
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
// (Aquí pon los de iTextSharp si los ocupas en esta pantalla)

// 2. El "namespace" (Normalmente es el nombre de tu proyecto)
namespace SistemaGimnasioSP
{
    // 3. ¡ESTO ES LO QUE SE TE BORRÓ! La clase de tu pantalla
    // OJO: Cambia "FormUsuarios" por el nombre real de tu ventana (ej. Form1, FrmRegistro, etc.)
    public partial class FrmUsuarios : Form
    {
        // 4. El constructor (VITAL para que tu Diseño se siga viendo)
        public FrmUsuarios()
        {
            InitializeComponent(); // ¡Nunca borres esta línea o desaparece tu diseño!
        }

        // 5. De aquí para abajo ya van todas tus funciones y botones
        private void btnInscribir_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text.Trim();
            string rol = cmbRol.SelectedItem?.ToString();

            // 1. Validar que no haya campos vacíos
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(usuario) ||
                string.IsNullOrEmpty(contrasena) || string.IsNullOrEmpty(rol))
            {
                MessageBox.Show("¡Hey! Todos los campos son obligatorios. Llénalos por favor.",
                                "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // === INICIO DE LA MAGIA: VENTANA EMERGENTE PARA EL GERENTE ===
            string passwordIngresada = "";

            // Creamos el Pop-up dinámico
            using (Form prompt = new Form() { Width = 350, Height = 180, FormBorderStyle = FormBorderStyle.FixedDialog, Text = "🔒 Autorización de Gerente", StartPosition = FormStartPosition.CenterScreen })
            {
                Label textLabel = new Label() { Left = 20, Top = 20, Width = 300, Text = "Para registrar a este usuario, ingresa la clave de Gerente:" };
                TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 280, UseSystemPasswordChar = true }; // Puntitos ocultos
                Button confirmation = new Button() { Text = "Autorizar", Left = 200, Width = 100, Top = 90, DialogResult = DialogResult.OK };

                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.AcceptButton = confirmation;

                // Mostramos el pop-up
                if (prompt.ShowDialog() == DialogResult.OK)
                {
                    passwordIngresada = textBox.Text.Trim();
                }
                else
                {
                    return; // Si cierran la ventanita, cancelamos el registro
                }
            }

            // Usamos la misma función que ya habías creado para "Eliminar"
            if (EsPasswordDeGerente(passwordIngresada) == false)
            {
                MessageBox.Show("¡Contraseña incorrecta o el usuario no es Gerente! Registro abortado.",
                                "🚨 Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // === FIN DE LA MAGIA ===

            // 2. Si el gerente firmó, ahora sí encriptamos la contraseña del NUEVO usuario
            string hashContrasena = BCrypt.Net.BCrypt.HashPassword(contrasena);

            // 3. Conexión y guardado
            ConexionDB miBaseDeDatos = new ConexionDB();
            MySqlConnection conn = miBaseDeDatos.AbrirConexion();

            if (conn != null)
            {
                try
                {
                    string query = @"INSERT INTO Usuarios (nombre_completo, usuario_login, contrasena, rol, estatus) 
                             VALUES (@nombre, @usuario, @contrasenaHash, @rol, 'Activo')";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@contrasenaHash", hashContrasena);
                        cmd.Parameters.AddWithValue("@rol", rol);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("¡Usuario inscrito exitosamente en el sistema con la firma del gerente!",
                                        "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Limpiamos las cajas de texto
                        txtNombre.Clear();
                        txtUsuario.Clear();
                        txtContrasena.Clear();
                        cmbRol.SelectedIndex = -1;

                        // ¡SÚPER TRUCO! Llamamos a tu función de llenar la lista aquí mismo
                        // Así, el nuevo usuario aparece en la pestaña de Eliminar instantáneamente
                        CargarUsuariosRegistrados();
                    }
                }
                catch (MySqlException ex)
                {
                    if (ex.Number == 1062)
                    {
                        MessageBox.Show("El nombre de usuario ya está registrado. Intente con otro.",
                                        "Usuario Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Error en la base de datos: " + ex.Message, "Error MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                finally
                {
                    miBaseDeDatos.CerrarConexion();
                }
            }
        }
        private void CargarUsuariosRegistrados()
        {
            // 1. Instanciamos tu clase de conexión
            ConexionDB bd = new ConexionDB();
            MySqlConnection conexion = bd.AbrirConexion();

            if (conexion != null)
            {
                try
                {
                    // 2. Consulta SQL: Solo queremos el ID y el Nombre de los que están Activos
                    string query = "SELECT id_usuario, nombre_completo FROM Usuarios WHERE estatus = 'Activo'";

                    // 3. Usamos un adaptador para traer los datos
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(query, conexion);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);

                    // 4. Vinculamos la tabla al ComboBox
                    // (Asumo que tu ComboBox se llama cmbUsuariosEliminar)
                    cmbUsuariosEliminar.DataSource = tabla;

                    // DisplayMember: Es lo que el usuario ve (el nombre)
                    cmbUsuariosEliminar.DisplayMember = "nombre_completo";

                    // ValueMember: Es lo que el sistema procesa por detrás (el ID)
                    cmbUsuariosEliminar.ValueMember = "id_usuario";

                    // 5. Lo dejamos vacío por defecto para que no seleccione al primero en automático
                    cmbUsuariosEliminar.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No pudimos traer a los usuarios: " + ex.Message, "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    bd.CerrarConexion();
                }
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (cmbUsuariosEliminar.SelectedIndex == -1)
            {
                MessageBox.Show("Papu, selecciona un usuario de la lista primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idUsuarioSeleccionado = Convert.ToInt32(cmbUsuariosEliminar.SelectedValue);
            string nombreUsuario = cmbUsuariosEliminar.Text;

            DialogResult respuesta = MessageBox.Show($"¿Estás totalmente seguro de dar de baja a: {nombreUsuario}?",
                                                     "Confirmar Baja",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                // === INICIO DE LA MAGIA: VENTANA EMERGENTE PARA EL GERENTE ===
                string passwordIngresada = "";

                // Creamos un Pop-up dinámico
                using (Form prompt = new Form() { Width = 350, Height = 180, FormBorderStyle = FormBorderStyle.FixedDialog, Text = "🔒 Autorización de Gerente", StartPosition = FormStartPosition.CenterScreen })
                {
                    Label textLabel = new Label() { Left = 20, Top = 20, Width = 300, Text = "Para continuar, ingresa la contraseña de un Gerente:" };
                    TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 280, UseSystemPasswordChar = true }; // Los puntitos mágicos para ocultar texto
                    Button confirmation = new Button() { Text = "Autorizar", Left = 200, Width = 100, Top = 90, DialogResult = DialogResult.OK };

                    prompt.Controls.Add(textLabel);
                    prompt.Controls.Add(textBox);
                    prompt.Controls.Add(confirmation);
                    prompt.AcceptButton = confirmation;

                    // Mostramos el pop-up y esperamos a que el usuario le dé a "Autorizar"
                    if (prompt.ShowDialog() == DialogResult.OK)
                    {
                        passwordIngresada = textBox.Text.Trim();
                    }
                    else
                    {
                        return; // Si el cajero cerró la ventanita por miedo, se cancela todo
                    }
                }

                // Llamamos a la bóveda. Si la contraseña no es de un gerente... ¡Rebotado!
                if (EsPasswordDeGerente(passwordIngresada) == false)
                {
                    MessageBox.Show("¡Contraseña incorrecta o el usuario no es Gerente! Operación abortada.",
                                    "🚨 Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // === FIN DE LA MAGIA ===

                // Si llegó hasta aquí, es porque el gerente puso su firma correcta. ¡Procedemos con la guillotina!
                ConexionDB miBD = new ConexionDB();
                MySqlConnection conn = miBD.AbrirConexion();

                if (conn != null)
                {
                    try
                    {
                        string query = "UPDATE Usuarios SET estatus = 'Inactivo' WHERE id_usuario = @id";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", idUsuarioSeleccionado);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("¡Usuario dado de baja exitosamente! La autorización fue registrada.",
                                            "Baja Confirmada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            CargarUsuariosRegistrados(); // Actualizamos la lista para que desaparezca
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al intentar eliminar: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        miBD.CerrarConexion();
                    }
                }
            }
        }
        private bool EsPasswordDeGerente(string passwordIngresada)
        {
            bool esValido = false;
            ConexionDB miBD = new ConexionDB();
            MySqlConnection conn = miBD.AbrirConexion();

            if (conn != null)
            {
                try
                {
                    // Traemos TODOS los hashes de los que sean Gerentes y estén Activos
                    string query = "SELECT contrasena FROM Usuarios WHERE rol = 'Gerente' AND estatus = 'Activo'";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string hashGuardado = reader["contrasena"].ToString();

                                // Si la contraseña ingresada coincide con el hash de algún gerente...
                                if (BCrypt.Net.BCrypt.Verify(passwordIngresada, hashGuardado))
                                {
                                    esValido = true;
                                    break; // ¡Bingo! Encontramos a un gerente, detenemos la búsqueda
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al verificar gerente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    miBD.CerrarConexion();
                }
            }
            return esValido; // Retorna true si era de un gerente, o false si se equivocó
        }

        private void FrmUsuarios_Load_1(object sender, EventArgs e)
        {
            CargarUsuariosRegistrados();
        }
        private void CargarClientes(string textoBusqueda = "")
        {
            ConexionDB miBD = new ConexionDB();
            MySqlConnection conn = miBD.AbrirConexion();

            if (conn != null)
            {
                try
                {
                    // 1. Quitamos 'matricula' y dejamos solo las columnas que SÍ sabemos que existen
                    string query = @"SELECT id_cliente AS 'ID', 
                                    nombre AS 'Nombre', 
                                    telefono AS 'Teléfono',
                                    fecha_Nacimiento AS 'Nacimiento' 
                             FROM Clientes";

                    // 2. Ahora buscamos por nombre o por el ID del cliente
                    if (!string.IsNullOrEmpty(textoBusqueda))
                    {
                        query += " WHERE nombre LIKE @busqueda OR id_cliente LIKE @busqueda";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(textoBusqueda))
                        {
                            cmd.Parameters.AddWithValue("@busqueda", "%" + textoBusqueda + "%");
                        }

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgvClientes.DataSource = dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar clientes: " + ex.Message, "Error MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    miBD.CerrarConexion();
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text.Trim();
            CargarClientes(busqueda);
        }
        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona toda la fila del cliente que deseas eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idCliente = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["ID"].Value);
            string nombreCliente = dgvClientes.SelectedRows[0].Cells["Nombre"].Value.ToString();

            DialogResult respuesta = MessageBox.Show($"¿Estás seguro de ELIMINAR POR COMPLETO al cliente: {nombreCliente}?\n\nEsta acción es irreversible.",
                                                     "Alerta de Eliminación",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Warning);

            if (respuesta == DialogResult.Yes)
            {
                // === INICIO BÓVEDA GERENCIAL ===
                string passwordIngresada = "";
                using (Form prompt = new Form() { Width = 350, Height = 180, FormBorderStyle = FormBorderStyle.FixedDialog, Text = "🔒 Autorización Requerida", StartPosition = FormStartPosition.CenterScreen })
                {
                    Label textLabel = new Label() { Left = 20, Top = 20, Width = 300, Text = "Clave de Gerente requerida para eliminar clientes:" };
                    TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 280, UseSystemPasswordChar = true };
                    Button confirmation = new Button() { Text = "Autorizar", Left = 200, Width = 100, Top = 90, DialogResult = DialogResult.OK };
                    prompt.Controls.Add(textLabel); prompt.Controls.Add(textBox); prompt.Controls.Add(confirmation); prompt.AcceptButton = confirmation;

                    if (prompt.ShowDialog() == DialogResult.OK) { passwordIngresada = textBox.Text.Trim(); }
                    else { return; }
                }

                if (EsPasswordDeGerente(passwordIngresada) == false)
                {
                    MessageBox.Show("¡Autorización denegada! Operación abortada.", "🚨 Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // === FIN BÓVEDA GERENCIAL ===

                // 3. Baja FÍSICA del Cliente (DELETE)
                ConexionDB miBD = new ConexionDB();
                MySqlConnection conn = miBD.AbrirConexion();

                if (conn != null)
                {
                    try
                    {
                        // Borramos el registro por completo de la base de datos
                        string query = "DELETE FROM Clientes WHERE id_cliente = @id";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", idCliente);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("¡Cliente eliminado permanentemente del sistema!", "Eliminación Confirmada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            CargarClientes(txtBuscar.Text.Trim());
                        }
                    }
                    catch (MySqlException ex)
                    {
                        // Advertencia de Arquitectura: Si el cliente ya tiene pagos registrados, MySQL no dejará borrarlo para proteger las relaciones.
                        if (ex.Number == 1451)
                        {
                            MessageBox.Show("No se puede eliminar a este cliente porque tiene historial de pagos o asistencias registradas en el sistema. (Protección de Integridad MySQL).",
                                            "No se puede borrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Error de MySQL: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    finally { miBD.CerrarConexion(); }
                }
            }
        }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}