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
        static Alumnos alumnoRegistrado = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("Ingrese la matrícula del alumno: ");
                string matricula = Console.ReadLine();

                Console.WriteLine("Ingrese el nombre del alumno: ");
                string nombre = Console.ReadLine();

                Console.WriteLine("Ingrese la edad del alumno: ");
                int edad = int.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese el promedio del alumno: ");
                double promedio = double.Parse(Console.ReadLine());

                Alumnos nuevoAlumno = new Alumnos(matricula, nombre, edad, promedio);
                nuevoAlumno.ValidarInfo();
                alumnoRegistrado = nuevoAlumno;
                Console.WriteLine("Alumno registrado correctamente.");
            }
            catch (MatriculaInvalidaException ex)
            {
                Console.WriteLine($"Error de matrícula: {ex.Message}");
            }
            catch (EdadInvalidaException ex)
            {
                Console.WriteLine($"Error de edad: {ex.Message}");
            }
            catch (PromedioInsuficienteException ex)
            {
                Console.WriteLine($"Error de promedio: {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Formato de entrada inválido. Asegúrese de ingresar números válidos para la edad y el promedio.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Proceso de registro finalizado.");
            }
        }

        private void btnMostrarInfo_Click(object sender, EventArgs e)
        {
            try
            {

                if (alumnoRegistrado == null)
                {
                    Console.WriteLine("No hay alumnos registrados.");
                }
                else
                {
                    alumnoRegistrado.MostrarInfo();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Eror para mostrar alumno:", ex.Message);
            }
            finally
            {
                Console.WriteLine("Proceso de mostrar alumno finalizado.");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Saliendo del sistema...");
            Environment.Exit(0);
        }
    }
}

