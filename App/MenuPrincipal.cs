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
        private const float precioLocal = 0.49f;
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
                    opcion = Convert.ToInt16 (valor);
                    if (opcion == 1) {
                        RegistrarLlamada (opcion);
                    } else if (opcion == 6) {
                        MostrarDetalleDoWhile (); //Ejecuta metodo del ciclo
                    } else if (opcion == 2) {
                        RegistrarLlamada (opcion);
                    }
                } catch (OpcionMenuException e) {
                    throw new OpcionMenuException ();
                }
            } while (opcion != 0);

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
                ((LlamadaDepartamental) llamada).Franja = 0;
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
        }
    }
}