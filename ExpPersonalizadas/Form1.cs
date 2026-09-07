using ExpPersonalizadas.Excepciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpPersonalizadas
{
    public partial class Form1 : Form
    {
        private static Alumnos alumnoRegistrado = null;
        private System.ComponentModel.BindingList<Alumnos> alumnosBinding = new System.ComponentModel.BindingList<Alumnos>();
        public static Alumnos AlumnoRegistrado => alumnoRegistrado;
        public Form1()
        {
            InitializeComponent();
            // Vincular la lista al ListBox para mostrar registros automáticamente
            listBox1.DisplayMember = "Nombre";
            listBox1.DataSource = alumnosBinding;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                string matricula = txbMatricula.Text.Trim();
                string nombre = txbNombre.Text.Trim();
                int edad = int.Parse(txbEdad.Text.Trim());
                double promedio = double.Parse(txbPromedio.Text.Trim());

                Alumnos nuevoAlumno = new Alumnos(matricula, nombre, edad, promedio);
                nuevoAlumno.ValidarInfo();
                alumnoRegistrado = nuevoAlumno;
                // Añadir a la lista vinculada para que se muestre en el DataGridView
                alumnosBinding.Add(nuevoAlumno);
                MessageBox.Show("Alumno registrado correctamente.", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Limpiar campos de entrada
                txbMatricula.Clear();
                txbNombre.Clear();
                txbEdad.Clear();
                txbPromedio.Clear();
            }
            catch (MatriculaInvalidaException ex)
            {
                MessageBox.Show($"Error de matrícula: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (EdadInvalidaException ex)
            {
                MessageBox.Show($"Error de edad: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (PromedioInsuficienteException ex)
            {
                MessageBox.Show($"Error de promedio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (FormatException)
            {
                MessageBox.Show("Error: Formato de entrada inválido. Asegúrese de ingresar números válidos para la edad y el promedio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMostrarInfo_Click(object sender, EventArgs e)
        {
            if (alumnoRegistrado == null)
            {
                MessageBox.Show("No hay alumnos registrados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // Seleccionar y desplazar al alumno registrado en el ListBox
            int idx = alumnosBinding.IndexOf(alumnoRegistrado);
            if (idx >= 0 && idx < listBox1.Items.Count)
            {
                listBox1.ClearSelected();
                listBox1.SelectedIndex = idx;
                try { listBox1.TopIndex = idx; } catch { }
            }

            // También mostrar la información en un cuadro si se desea
            string info = $"Matrícula: {alumnoRegistrado.Matricula}\nNombre: {alumnoRegistrado.Nombre}\nEdad: {alumnoRegistrado.Edad}\nPromedio: {alumnoRegistrado.Promedio}";
            MessageBox.Show(info, "Información del alumno", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

