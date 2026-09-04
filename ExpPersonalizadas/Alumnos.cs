using ExpPersonalizadas.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Alumnos
{
    //propiedades
    public string Matricula { get; set; }
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public double Promedio { get; set; }

    //constructor por defecto
    public Alumnos(string matricula, string nombre, int edad, double promedio)
    {
        Matricula = matricula;
        Nombre = nombre;
        Edad = edad;
        Promedio = promedio;
    }

    //metodo para validad la matricula del alumno.
    public void ValidarMatricula()
    {
        if (Matricula.Length != 8)
        {
            throw new MatriculaInvalidaException("La matrícula es inválida. Debe tner 8 caracteres.");
        }
    }

    //metodo para validar la edad del alumno.
    public void ValidarEdad()
    {
        if (Edad < 17 || Edad > 60)
        {
            throw new EdadInvalidaException("La edad es inválida. Debe estar entre 17 y 60 años.");
        }
    }

    //metodo para validar el promedio del alumno.
    public void ValidarPromedio()
    {
        if (Promedio < 70)
        {
            throw new PromedioInsuficienteException("El promedio es insuficiente. El promedio minimo es 70.");
        }
    }

    //metodo para validar toda la informacion del alumno.
    public void ValidarInfo()
    {
        ValidarMatricula();
        ValidarEdad();
        ValidarPromedio();
    }

    //metodo para mostrar la informacion del alumno.
    public void MostrarInfo()
    {
        Console.WriteLine($"Matrícula: {Matricula}");
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Edad: {Edad}");
        Console.WriteLine($"Promedio: {Promedio}");
    }
}
