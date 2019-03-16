using System;
namespace CentralTelefonica.Util

{
    public class OpcionMenuException : Exception {
        private string message = "Error! Debe ingresar un numero, no un caracter...\n" ;
        public override string Message {
            get { return message; }
        }
    }
}