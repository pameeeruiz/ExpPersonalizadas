using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpPersonalizadas.Excepciones
{
    public class MatriculaInvalidaException: Exception
    {
        ///constructor por defecto
        public MatriculaInvalidaException() { }


        ///constructor con mensaje personalizado
        public MatriculaInvalidaException(string message) : base(message) { }
    }
}
