using System;
using static System.Console;
using System.Collections.Generic;
using CentralTelefonica.Entidades;
using CentralTelefonica.App;
using CentralTelefonica.Util;
namespace CentralTelefonica
{
    class Program
    {
        static void Main(string[] args)
        {
            /*try
            {
                MenuPrincipal menu = new MenuPrincipal();
                menu.MostrarMenu();
            }

            catch(OpcionMenuException e)
            {
                Console.WriteLine(e.Message);
            } */
            DateTime fecha = DateTime.Now;

            WriteLine(fecha.DayOfWeek);
            WriteLine($"{fecha.Hour}:{fecha.Minute}");
            WriteLine(fecha.Day);    
        }
    }
}
