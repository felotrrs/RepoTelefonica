using System;
using static System.Console;
using System.Collections.Generic;
using CentralTelefonica.Entidades;
using CentralTelefonica.Util;

namespace CentralTelefonica.App {
    public class MenuPrincipal {
        private const float precioUnoDepartamental = 0.65f;
        private const float precioDosDepartamental = 0.85f;
        private const float precioTresDepartamental = 0.98f;
        private const float precioLocal = 1.25f;
        public List<Llamada> ListaDeLlamadas { get; set; } //crear una lista para objetos del tipo "Llamada"
        public MenuPrincipal () {
            this.ListaDeLlamadas = new List<Llamada> ();
        }
        public void MostrarMenu () {
            int opcion = 100;
            do {
                try {
                    WriteLine ("1. Registrar llamada local");
                    WriteLine ("2. Registrar llamada departamental");
                    WriteLine ("3. Costo total de llamada local");
                    WriteLine ("4. Costo total de la llamada departamental");
                    WriteLine ("5. Costo total de llamadas");
                    WriteLine ("6. Mostrar registros de llamadas");
                    WriteLine ("0. Salir");
                    WriteLine ("Ingrese su opcion ==>");
                    string valor = ReadLine ();
                    if (EsNumero(valor) == true){
                        opcion = Convert.ToInt16 (valor);
                    }
                    if (opcion == 1) {
                        RegistrarLlamada (opcion);
                    } else if (opcion == 6) {
                        MostrarDetalleForEach (); //Ejecuta metodo del ciclo
                    } else if (opcion == 2) {
                        RegistrarLlamada (opcion);
                    } else if (opcion == 3) {
                        MostrarCostoLlamadasLocales();
                    } else if (opcion == 4) {
                        MostrarCostoLlamadaDepartamental();
                    }
                } catch (OpcionMenuException e) {
                    WriteLine(e.Message);
                }
            } while (opcion != 0);
        }

        public Boolean EsNumero(string valor) {
            Boolean resultado = false;
            try {
                int numero = Convert.ToInt16(valor);
                resultado = true;
            } catch(Exception e) {
                throw new OpcionMenuException();
            }
            return resultado;
        }


        public void RegistrarLlamada (int opcion) {
            string numeroOrigen = "";
            string numeroDestino = "";
            string duracion = "";
            Llamada llamada = null;
            WriteLine ("Ingrese el numero de origen:");
            numeroOrigen = ReadLine ();
            WriteLine ("Ingrese el numero de destino:");
            numeroDestino = ReadLine ();
            WriteLine ("Duracion de la llamada:");
            duracion = ReadLine ();
            if (opcion == 1) {
                /* // Como asignar parametros a una clase sin constructor: 
                llamada = new LlamadaLocal();
                llamada.NumeroDestino = numeroDestino;
                llamada.NumeroOrigen = numeroOrigen;
                llamada.Duracion = Convert.ToDouble(duracion);
                */
                //Como asignar parametros a una clase con constructor:  
                llamada = new LlamadaLocal (numeroOrigen, numeroDestino, Convert.ToDouble (duracion));
                ((LlamadaLocal) llamada).Precio = precioLocal;
            } else if (opcion == 2) {
                llamada = new LlamadaDepartamental (numeroOrigen, numeroDestino, Convert.ToDouble (duracion));
                /*llamada.NumeroDestino = numeroDestino;
                llamada.NumeroOrigen = numeroOrigen;
                llamada.Duracion = Convert.ToDouble(duracion);*/
                ((LlamadaDepartamental) llamada).PrecioUno = precioUnoDepartamental;
                ((LlamadaDepartamental) llamada).PrecioDos = precioDosDepartamental;
                ((LlamadaDepartamental) llamada).PrecioTres = precioTresDepartamental;
                ((LlamadaDepartamental) llamada).Franja = calcularFranja(DateTime.Now);
            } else {
                WriteLine ("Tipo de llamada no registrado");
            }
            this.ListaDeLlamadas.Add (llamada);
        }

        public void MostrarDetalleWhile () {
            int i = 0;
            while (this.ListaDeLlamadas.Count > i) {
                WriteLine (this.ListaDeLlamadas[i]);
                i = i + 1;
            }
            //while(++){}   
        }

        public void MostrarDetalleDoWhile () {
            int i = 0;
            do {
                WriteLine (this.ListaDeLlamadas[i]);
                i++;
            } while (this.ListaDeLlamadas.Count > i);
        }

        public void MostrarDetallleFor () {
            for (int i = 0; i < this.ListaDeLlamadas.Count; i++) {
                WriteLine (this.ListaDeLlamadas[i]);
            }
        }

        public void MostrarDetalleForEach () {
            foreach (var llamada in this.ListaDeLlamadas) {
                WriteLine (llamada);
            }
            WriteLine("\n");
        }

        public void MostrarCostoLlamadasLocales(){
            double tiempoLlamada = 0.0;
            double costoTotal = 0.0;
            foreach(var elemento in ListaDeLlamadas) {

                if(elemento.GetType() == typeof(LlamadaLocal)){
                    tiempoLlamada += elemento.Duracion;
                    costoTotal +=  elemento.CalcularPrecio();
                }
            }
            WriteLine($"Costo minuto: {precioLocal}");
            WriteLine($"Tiempo total de llamadas: {tiempoLlamada}");
            WriteLine($"Costo total: {costoTotal} \n");
        }

        public void MostrarCostoLlamadaDepartamental(){
            double tiempoLlamadaFranja1 = 0.0;
            double tiempoLlamadaFranja2 = 0.0;
            double tiempoLlamadaFranja3 = 0.0;
            double costoTotalFranja1 = 0.0;
            double costoTotalFranja2 = 0.0;
            double costoTotalFranja3 = 0.0;
            foreach(var elemento in ListaDeLlamadas) { 
                if(elemento.GetType() == typeof(LlamadaDepartamental)){
                    switch (((LlamadaDepartamental)elemento).Franja)
                    {
                        case 0:
                            tiempoLlamadaFranja1 += elemento.Duracion;
                            costoTotalFranja1 +=  elemento.CalcularPrecio();
                            break;
                        case 1:
                            tiempoLlamadaFranja2 += elemento.Duracion;
                            costoTotalFranja2 +=  elemento.CalcularPrecio();
                            break;
                        case 2:
                            tiempoLlamadaFranja3 += elemento.Duracion;
                            costoTotalFranja3 +=  elemento.CalcularPrecio();
                            break;
                    }    
                }
            }
            WriteLine("FRANJA 1");
            WriteLine($"Costo minuto: {precioUnoDepartamental}");
            WriteLine($"Tiempo total de llamadas: {tiempoLlamadaFranja1}");
            WriteLine($"Costo total: {costoTotalFranja1} \n");

            WriteLine("FRANJA 2");
            WriteLine($"Costo minuto: {precioDosDepartamental}");
            WriteLine($"Tiempo total de llamadas: {tiempoLlamadaFranja2}");
            WriteLine($"Costo total: {costoTotalFranja2} \n");

            WriteLine("FRANJA 1");
            WriteLine($"Costo minuto: {precioTresDepartamental}");
            WriteLine($"Tiempo total de llamadas: {tiempoLlamadaFranja3}");
            WriteLine($"Costo total: {costoTotalFranja3} \n");
        }

        public int calcularFranja(DateTime fecha){
            int resultado = -1;
               /*   Franja 0:  Lunes 6:00 a Viernes 21:59
                    Franja 1:  Lunes 22:00 a Viernes 5:59
                    Franja 2:  Viernes 22:00 a Lunes 5:59
                */

            return resultado; //0,1,2
        }

    }
}