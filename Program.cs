using System;
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
            try
            {
                MenuPrincipal menu = new MenuPrincipal();
                menu.MostrarMenu();
            }
            catch (System.Exception)
            {
                
                throw;
            }
           
        }
    }
}
