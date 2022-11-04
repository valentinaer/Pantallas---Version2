using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Version_2___Pantallas
{
    internal class Usuario
    {
        public string CUIT { get; set; }
        public int DNIAutorizados { get; set; }

        public string ApellidoNombre { get; set; }

        public string Contraseña { get; set; }

        // C O N S T R U C T O R E S //
        public Usuario (string cuit, int dniautorizados, string apellidonombre, string contraseña)
        {
            CUIT = cuit;
            DNIAutorizados = dniautorizados;
            ApellidoNombre = apellidonombre;
            Contraseña = contraseña;
        }
   
        public Usuario()
        {

        }

        // MÉTODO CARGAR USUARIOS DE LA LISTA //

        List<Usuario> usuarios = new List<Usuario>();
        public void CargarUsuarios()
        {
            using var archivo = new StreamReader("Usuarios.txt");
            while (!archivo.EndOfStream)
            {
                var proximaLinea = archivo.ReadLine();
                string[] datosSeparados = proximaLinea.Split("|");

                Usuario usuario = new Usuario();
                usuario.CUIT = datosSeparados[0];
                usuario.DNIAutorizados = int.Parse(datosSeparados[1]);
                usuario.Contraseña = datosSeparados[2];
                usuario.ApellidoNombre = datosSeparados[3];

                usuarios.Add(usuario);
            }

        }

        //METODO BUSCAR CUIT (Devuelve una lista) 

        public Usuario BuscarCUIT(int dni)
        {
            return usuarios.Find(usuario => usuario.DNIAutorizados == dni);
        }

       
        
        public static string RetornoCuit()
        {

            Usuario U = new Usuario();

            


            return U.CUIT;
           
        }

        //Archivo
        //CUIT| DNI | Apellido y Nombre | Contraseña
        
    }
}
