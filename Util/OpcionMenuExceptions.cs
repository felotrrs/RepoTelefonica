using System;
namespace CentralTelefonica.Util

{
    public class OpcionMenuException : Exception {
        private string message = "Error,  debe ingresar un numero,  no un caracter";
        public override string Message {
            get { return message; }
        }
    }
}