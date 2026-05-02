using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8602, CS8601, CS8604 // Dereference of a possibly null reference, Possible null assignment, Possible null argument

namespace GestionFuncionarios
{
    public partial class FrmPrincipal : Form
    {
        private EmpresaFuncionariosContext? _context;
        // Controles del formulario
        private GroupBox? grpDatosFuncionario;
        private GroupBox? grpListaFuncionarios;
        
        // Campos de entrada
        private Label? lblIdentificacion;
        private TextBox? txtIdentificacion;
        
        private Label? lblNombre;
        private TextBox? txtNombre;
        
        private Label? lblApellido;
        private TextBox? txtApellido;
        
        private Label? lblCorreo;
        private TextBox? txtCorreo;
        
        private Label? lblTelefono;
        private TextBox? txtTelefono;
        
        private Label? lblCargo;
        private ComboBox? cmbCargo;
        
        private Label? lblDependencia;
        private ComboBox? cmbDependencia;
        
        // Botones de acción
        private Button? btnGuardar;
        private Button? btnActualizar;
        private Button? btnEliminar;
        private Button? btnLimpiar;
        
        // DataGridView para listado
        private DataGridView? dgvFuncionarios;
        
        // Etiqueta de mensaje
        private Label? lblMensaje;

        private int? _idSeleccionado;

        public FrmPrincipal()
        {
            try
            {
                _context = new EmpresaFuncionariosContext();
                _context.Database.EnsureCreated(); // Crear BD si no existe
                InitializeComponent();
                CargarFuncionarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar la aplicación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void InitializeComponent()
        {
            // Configuración del formulario principal
            this.Text = "Gestión de Funcionarios";
            this.Size = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 9F);
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.MinimumSize = new Size(800, 600);

            // Crear controles
            CrearGroupBoxDatosFuncionario();
            CrearGroupBoxListaFuncionarios();
            CrearLabelMensaje();

            // Configurar el layout
            ConfigurarLayout();
        }

        private void CrearGroupBoxDatosFuncionario()
        {
            grpDatosFuncionario = new GroupBox
            {
                Text = "Datos del Funcionario",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(51, 51, 51),
                BackColor = Color.White,
                Size = new Size(950, 250),
                Location = new Point(20, 20),
                Padding = new Padding(15)
            };

            // Etiquetas y campos de entrada
            lblIdentificacion = new Label { Text = "Identificación:", Location = new Point(20, 30), Size = new Size(100, 23), Font = new Font("Segoe UI", 9F) };
            txtIdentificacion = new TextBox { Location = new Point(130, 30), Size = new Size(150, 23), Font = new Font("Segoe UI", 9F) };

            lblNombre = new Label { Text = "Nombre:", Location = new Point(20, 60), Size = new Size(100, 23), Font = new Font("Segoe UI", 9F) };
            txtNombre = new TextBox { Location = new Point(130, 60), Size = new Size(200, 23), Font = new Font("Segoe UI", 9F) };

            lblApellido = new Label { Text = "Apellido:", Location = new Point(350, 60), Size = new Size(100, 23), Font = new Font("Segoe UI", 9F) };
            txtApellido = new TextBox { Location = new Point(460, 60), Size = new Size(200, 23), Font = new Font("Segoe UI", 9F) };

            lblCorreo = new Label { Text = "Correo electrónico:", Location = new Point(20, 90), Size = new Size(120, 23), Font = new Font("Segoe UI", 9F) };
            txtCorreo = new TextBox { Location = new Point(150, 90), Size = new Size(250, 23), Font = new Font("Segoe UI", 9F) };

            lblTelefono = new Label { Text = "Teléfono:", Location = new Point(420, 90), Size = new Size(100, 23), Font = new Font("Segoe UI", 9F) };
            txtTelefono = new TextBox { Location = new Point(530, 90), Size = new Size(150, 23), Font = new Font("Segoe UI", 9F) };

            lblCargo = new Label { Text = "Cargo:", Location = new Point(20, 120), Size = new Size(100, 23), Font = new Font("Segoe UI", 9F) };
            cmbCargo = new ComboBox { Location = new Point(130, 120), Size = new Size(200, 23), Font = new Font("Segoe UI", 9F), DropDownStyle = ComboBoxStyle.DropDownList };
            cmbCargo.Items.AddRange(new[] { "Administrador", "Analista", "Coordinador", "Gerente", "Supervisor", "Técnico" });

            lblDependencia = new Label { Text = "Dependencia:", Location = new Point(350, 120), Size = new Size(100, 23), Font = new Font("Segoe UI", 9F) };
            cmbDependencia = new ComboBox { Location = new Point(460, 120), Size = new Size(200, 23), Font = new Font("Segoe UI", 9F), DropDownStyle = ComboBoxStyle.DropDownList };
            cmbDependencia.Items.AddRange(new[] { "Recursos Humanos", "Finanzas", "Tecnología", "Operaciones", "Marketing", "Ventas" });

            // Botones de acción
            btnGuardar = new Button 
            { 
                Text = "Guardar", 
                Location = new Point(20, 170), 
                Size = new Size(100, 35), 
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                BackColor = Color.FromArgb(76, 175, 80),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                UseVisualStyleBackColor = false
            };
            btnGuardar.FlatAppearance.BorderSize = 0;

            btnActualizar = new Button 
            { 
                Text = "Actualizar", 
                Location = new Point(130, 170), 
                Size = new Size(100, 35), 
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                BackColor = Color.FromArgb(33, 150, 243),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                UseVisualStyleBackColor = false
            };
            btnActualizar.FlatAppearance.BorderSize = 0;

            btnEliminar = new Button 
            { 
                Text = "Eliminar", 
                Location = new Point(240, 170), 
                Size = new Size(100, 35), 
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                BackColor = Color.FromArgb(244, 67, 54),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                UseVisualStyleBackColor = false
            };
            btnEliminar.FlatAppearance.BorderSize = 0;

            btnLimpiar = new Button 
            { 
                Text = "Limpiar", 
                Location = new Point(350, 170), 
                Size = new Size(100, 35), 
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                BackColor = Color.FromArgb(158, 158, 158),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                UseVisualStyleBackColor = false
            };
            btnLimpiar.FlatAppearance.BorderSize = 0;

            // Agregar controles al GroupBox
            grpDatosFuncionario.Controls.AddRange(new Control[] 
            {
                lblIdentificacion, txtIdentificacion,
                lblNombre, txtNombre,
                lblApellido, txtApellido,
                lblCorreo, txtCorreo,
                lblTelefono, txtTelefono,
                lblCargo, cmbCargo,
                lblDependencia, cmbDependencia,
                btnGuardar, btnActualizar, btnEliminar, btnLimpiar
            });

            // Eventos de botones (simulados visualmente)
            btnGuardar.Click += BtnGuardar_Click;
            btnActualizar.Click += BtnActualizar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            btnLimpiar.Click += BtnLimpiar_Click;
        }

        private void CrearGroupBoxListaFuncionarios()
        {
            grpListaFuncionarios = new GroupBox
            {
                Text = "Lista de Funcionarios",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(51, 51, 51),
                BackColor = Color.White,
                Size = new Size(950, 320),
                Location = new Point(20, 290),
                Padding = new Padding(15)
            };

            // Configurar DataGridView
            dgvFuncionarios = new DataGridView
            {
                Location = new Point(15, 25),
                Size = new Size(920, 280),
                Font = new Font("Segoe UI", 9F),
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            // Configurar columnas
            dgvFuncionarios.Columns.Add("ID", "ID");
            dgvFuncionarios.Columns.Add("Identificacion", "Identificación");
            dgvFuncionarios.Columns.Add("NombreCompleto", "Nombre Completo");
            dgvFuncionarios.Columns.Add("Correo", "Correo");
            dgvFuncionarios.Columns.Add("Telefono", "Teléfono");
            dgvFuncionarios.Columns.Add("Cargo", "Cargo");
            dgvFuncionarios.Columns.Add("Dependencia", "Dependencia");

            // Estilo del DataGridView
            dgvFuncionarios.DefaultCellStyle.BackColor = Color.White;
            dgvFuncionarios.DefaultCellStyle.ForeColor = Color.FromArgb(51, 51, 51);
            dgvFuncionarios.DefaultCellStyle.SelectionBackColor = Color.FromArgb(33, 150, 243);
            dgvFuncionarios.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvFuncionarios.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 51, 51);
            dgvFuncionarios.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvFuncionarios.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvFuncionarios.ColumnHeadersHeight = 30;
            dgvFuncionarios.RowTemplate.Height = 25;

            // Evento de clic en fila
            dgvFuncionarios.CellClick += DgvFuncionarios_CellClick;

            grpListaFuncionarios.Controls.Add(dgvFuncionarios);
        }

        private void CrearLabelMensaje()
        {
            lblMensaje = new Label
            {
                Text = "Listo para gestionar funcionarios",
                Location = new Point(20, 620),
                Size = new Size(950, 30),
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(76, 175, 80),
                TextAlign = ContentAlignment.MiddleLeft
            };
        }

        private void ConfigurarLayout()
        {
            this.Controls.AddRange(new Control[] 
            { 
                grpDatosFuncionario, 
                grpListaFuncionarios, 
                lblMensaje 
            });
        }

        private void CargarFuncionarios()
        {
            try
            {
                dgvFuncionarios.Rows.Clear();
                var funcionarios = _context.Funcionarios.ToList();
                foreach (var f in funcionarios)
                {
                    dgvFuncionarios.Rows.Add(
                        f.Id,
                        f.Identificacion,
                        $"{f.Nombre} {f.Apellido}",
                        f.Correo,
                        f.Telefono,
                        f.Cargo,
                        f.Dependencia
                    );
                }
                lblMensaje.Text = $"Cargados {funcionarios.Count} funcionarios";
                lblMensaje.ForeColor = Color.FromArgb(76, 175, 80);
            }
            catch (Exception ex)
            {
                lblMensaje.Text = $"Error al cargar funcionarios: {ex.Message}";
                lblMensaje.ForeColor = Color.Red;
            }
        }

        // Eventos de botones (simulados visualmente)
        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                try
                {
                    var funcionario = new Funcionario
                    {
                        Identificacion = txtIdentificacion.Text,
                        Nombre = txtNombre.Text,
                        Apellido = txtApellido.Text,
                        Correo = txtCorreo.Text,
                        Telefono = txtTelefono.Text,
                        Cargo = cmbCargo.Text,
                        Dependencia = cmbDependencia.Text
                    };

                    _context.Funcionarios.Add(funcionario);
                    _context.SaveChanges();

                    lblMensaje.Text = "Funcionario guardado exitosamente";
                    lblMensaje.ForeColor = Color.FromArgb(76, 175, 80);
                    CargarFuncionarios();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = $"Error al guardar: {ex.Message}";
                    lblMensaje.ForeColor = Color.Red;
                }
            }
        }

        private void BtnActualizar_Click(object? sender, EventArgs e)
        {
            if (_idSeleccionado.HasValue && ValidarCampos())
            {
                try
                {
                    var funcionario = _context.Funcionarios.Find(_idSeleccionado.Value);
                    if (funcionario != null)
                    {
                        funcionario.Identificacion = txtIdentificacion.Text;
                        funcionario.Nombre = txtNombre.Text;
                        funcionario.Apellido = txtApellido.Text;
                        funcionario.Correo = txtCorreo.Text;
                        funcionario.Telefono = txtTelefono.Text;
                        funcionario.Cargo = cmbCargo.Text;
                        funcionario.Dependencia = cmbDependencia.Text;

                        _context.SaveChanges();

                        lblMensaje.Text = "Funcionario actualizado exitosamente";
                        lblMensaje.ForeColor = Color.FromArgb(33, 150, 243);
                        CargarFuncionarios();
                        LimpiarCampos();
                        _idSeleccionado = null;
                    }
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = $"Error al actualizar: {ex.Message}";
                    lblMensaje.ForeColor = Color.Red;
                }
            }
            else if (!_idSeleccionado.HasValue)
            {
                lblMensaje.Text = "Seleccione un funcionario para actualizar";
                lblMensaje.ForeColor = Color.FromArgb(255, 152, 0);
            }
        }

        private void BtnEliminar_Click(object? sender, EventArgs e)
        {
            if (_idSeleccionado.HasValue)
            {
                try
                {
                    var funcionario = _context.Funcionarios.Find(_idSeleccionado.Value);
                    if (funcionario != null)
                    {
                        _context.Funcionarios.Remove(funcionario);
                        _context.SaveChanges();

                        lblMensaje.Text = "Funcionario eliminado exitosamente";
                        lblMensaje.ForeColor = Color.FromArgb(244, 67, 54);
                        CargarFuncionarios();
                        LimpiarCampos();
                        _idSeleccionado = null;
                    }
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = $"Error al eliminar: {ex.Message}";
                    lblMensaje.ForeColor = Color.Red;
                }
            }
            else
            {
                lblMensaje.Text = "Seleccione un funcionario para eliminar";
                lblMensaje.ForeColor = Color.FromArgb(255, 152, 0);
            }
        }

        private void BtnLimpiar_Click(object? sender, EventArgs e)
        {
            LimpiarCampos();
            _idSeleccionado = null;
            lblMensaje.Text = "Formulario limpiado";
            lblMensaje.ForeColor = Color.FromArgb(158, 158, 158);
        }

        private void LimpiarCampos()
        {
            txtIdentificacion.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtCorreo.Clear();
            txtTelefono.Clear();
            cmbCargo.SelectedIndex = -1;
            cmbDependencia.SelectedIndex = -1;
        }

        private void DgvFuncionarios_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvFuncionarios.Rows[e.RowIndex];
                
                _idSeleccionado = Convert.ToInt32(row.Cells["ID"].Value);
                
                // Cargar datos en los campos
                txtIdentificacion.Text = row.Cells["Identificacion"].Value?.ToString() ?? "";
                txtNombre.Text = row.Cells["NombreCompleto"].Value?.ToString()?.Split(' ')[0] ?? "";
                txtApellido.Text = row.Cells["NombreCompleto"].Value?.ToString()?.Split(' ').Length > 1 
                    ? string.Join(" ", row.Cells["NombreCompleto"].Value?.ToString()?.Split(' ').Skip(1)) 
                    : "";
                txtCorreo.Text = row.Cells["Correo"].Value?.ToString() ?? "";
                txtTelefono.Text = row.Cells["Telefono"].Value?.ToString() ?? "";
                cmbCargo.Text = row.Cells["Cargo"].Value?.ToString() ?? "";
                cmbDependencia.Text = row.Cells["Dependencia"].Value?.ToString() ?? "";
                
                lblMensaje.Text = "Funcionario seleccionado";
                lblMensaje.ForeColor = Color.FromArgb(33, 150, 243);
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtIdentificacion.Text) ||
                string.IsNullOrEmpty(txtNombre.Text) ||
                string.IsNullOrEmpty(txtApellido.Text) ||
                string.IsNullOrEmpty(txtCorreo.Text) ||
                string.IsNullOrEmpty(txtTelefono.Text) ||
                cmbCargo.SelectedIndex == -1 ||
                cmbDependencia.SelectedIndex == -1)
            {
                lblMensaje.Text = "Por favor complete todos los campos";
                lblMensaje.ForeColor = Color.FromArgb(255, 152, 0);
                return false;
            }

            if (!txtCorreo.Text.Contains("@"))
            {
                lblMensaje.Text = "El correo electrónico no es válido";
                lblMensaje.ForeColor = Color.FromArgb(255, 152, 0);
                return false;
            }

            return true;
        }
    }
}
