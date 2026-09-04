using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpPersonalizadas.Excepciones
{
    public  class EdadInvalidaException: Exception
    {
        ///constructor por defecto
        public EdadInvalidaException() { }


        ///constructor con mensaje personalizado
        public EdadInvalidaException(string message) : base(message) { }
    }
}
