using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpPersonalizadas.Excepciones
{
    public class PromedioInsuficienteException: Exception
    {
        ///constructor por defecto
        public PromedioInsuficienteException() { }


        ///constructor con mensaje personalizado
        public PromedioInsuficienteException(string message) : base(message) { }
    }
}
