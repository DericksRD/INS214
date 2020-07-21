using System;
using System.IO;
using System.Collections.Generic;

namespace Programa_captura{
    public class HashSetBasedArray{
        //atributos:
        public LinkedList<Usuario>[] gavetas;

        public HashSetBasedArray(){
            gavetas = new LinkedList<Usuario>[9];

            for(int i = 0; i < gavetas.Length; i++){
                gavetas[i] = new LinkedList<Usuario>();
            }

            if(File.Exists("usuarios.csv")){
                string[] texto = File.ReadAllLines("usuarios.csv");

                foreach(string linea in texto){
                    string[] columnas = linea.Split(',');
                    Usuario usuario1 = new Usuario(columnas[0], columnas[1], columnas[2], columnas[3], columnas[4]);
                    int numeroHash = Math.Abs( usuario1.GetHashCode() % 9);

                    gavetas[numeroHash].AddFirst(usuario1);
                }
            }
        }

        public void Add(Usuario nuevoUsuario){
            int numeroHash = Math.Abs(nuevoUsuario.GetHashCode() % 9);
            gavetas[numeroHash].AddFirst(nuevoUsuario);

            CompletarCSV();
        }

        public void Remove(Usuario nuevoUsuario){
            int numeroHash = Math.Abs(nuevoUsuario.GetHashCode() % 9);
            gavetas[numeroHash].Remove(nuevoUsuario);

            CompletarCSV();
        }
        public bool Buscar(Usuario busqueda){
            int numeroHash = Math.Abs(busqueda.GetHashCode() % 9);
            foreach(Usuario usuario in gavetas[numeroHash]){
                if(usuario.Equals(busqueda)){
                    return true;
                }
            }
            return false;
        }

        public bool ComprobarUsuario(string nombre, string apellido){
           Usuario confirmarUsuario = new Usuario(nombre, apellido);

           bool usuarioIngresado = Buscar(confirmarUsuario);

            if( usuarioIngresado){
                Console.WriteLine("Ese nombre y apellido ya han sido ingresados, intentelo de nuevo");
                return true;
            }

            return false;
        }

        public void CompletarCSV(){
            Usuario encabezado = new Usuario("Nombre","Apellido","Ahorros","Contraseña","Información");
            using(StreamWriter usuario = new StreamWriter("usuarios.csv")){
                usuario.WriteLine(encabezado.Nombre + "," + encabezado.Apellido + "," + encabezado.Ahorros + "," +
                                  encabezado.Password + "," + encabezado.Datos);

                foreach(LinkedList<Usuario> lista in gavetas){
                    foreach(Usuario usuario1 in lista){
                        if(!usuario1.Equals(encabezado))
                            usuario.WriteLine(usuario1.Nombre + "," + usuario1.Apellido + "," + usuario1.Ahorros + 
                                                      "," + usuario1.Password + "," + usuario1.Datos);
                    }
                }
            }
        }

    }
}