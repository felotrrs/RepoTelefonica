using system;
using static system.console;
using CentralTelefonica_master.Entidades;
using system.collections.Generic;
namespace CentralTelefonica_master.App
{
    public class MenuPrincipal
    {
        private const float precioUnoDepartamental = 0.65f;
        private const float precioDosDepartamental = 0.85f;
        private const float precioTresDepartamental = 0.98f; 
        public List<Llamada> ListaDeLlamadas{get; set;}   //crear una lista para objetos del tipo "Llamada"
        public void MostrarMenu()
        {
            var opcion = 0;
            do
            {
                Writeline("1. Registrar llamada local");
                Writeline("2. Registrar llamada departamental");
                Writeline("3. Costo total de llamada local");
                Writeline("4. Costo total de la llamada departamental");
                Writeline("5. Costo total de llamadas");
                Writeline("0. Salir");
                Writeline("Ingrese su opcion ==>");
                string valor = ReadLine();
                opcion = Convert.ToInt16(valor);
                if(opcion == 1){
                    RegistrarLlamada(opcion);
                }
            } while (opcion != 0);
        }
        public void RegistrarLlamada(int opcion)
        {
            string numeroOrigen = "";
            string numeroDestino= "";
            string duracion = "";
            Llamada llamada = null;
            Writeline("Ingrese el numero de origen:");
            numeroOrigen = ReadLine();
            Writeline("Ingrese el numero de destino:");
            numeroDestino = ReadLine();
            Writeline("Duracion de la llamada:");
            duracion = ReadLine();
            if (opcion == 1){
                /* // Como asignar parametros a una clase sin constructor: 
                llamada = new LlamadaLocal();
                llamada.NumeroDestino = numeroDestino;
                llamada.NumeroOrigen = numeroOrigen;
                llamada.Duracion = Convert.ToDouble(duracion);
                */
                //Como asignar parametros a una clase con constructor:  
                llamada = new LlamadaLocal(numeroOrigen, numeroDestino,Convert.ToDouble(duracion));
                ((LlamadaLocal)llamada).Precio = precioLocal;
            }else if(opcion == 2){
                llamada = new LlamadaDepartamental(numeroOrigen, numeroDestino,Convert.ToDouble(duracion));
                llamada.NumeroDestino = numeroDestino;
                llamada.NumeroOrigen = numeroOrigen;
                llamada.Duracion = Convert.ToDouble(duracion);
                ((LlamadaDepartamental)llamada).PrecioUno = precioUnoDepartamental;
                ((LlamadaDepartamental)llamada).PrecioDos = precioDosDepartamental;
                ((LlamadaDepartamental)llamada).PrecioTres = precioTresDepartamental;
                ((LlamadaDepartamental)llamada).Franja = 0
            }else {
                Writeline("Tipo de llamada no registrado")
            }

        }
    }
}