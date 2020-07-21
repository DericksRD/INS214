using System;
using System.Collections.Generic;

namespace Programa_captura
{
    public class Usuario{
        //Atributos:
        public string Nombre {get; private set;}
        public string Apellido {get; private set;}
        public string Ahorros {get; private set;}
        public string Password {get; private set;}
        public string Datos {get; private set;}

        public string nombreCompleto;

        //Métodos:

        //Constructor:
        public Usuario(string nombre, string apellido){  
            Nombre = nombre;
            Apellido = apellido;
            nombreCompleto = Nombre + " " + Apellido;
        }

        public Usuario(string nombre, string apellido, string ahorro, string password, string datos){
            Nombre = nombre;
            Apellido = apellido;
            Ahorros = ahorro;
            Password = password;
            Datos = datos;

            nombreCompleto = Nombre + " " + Apellido;
        }

        public override bool Equals(object obj) {
            Usuario other = obj as Usuario;

            if (other == null) {
                return false;
            }

            return nombreCompleto.Equals(other.nombreCompleto, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode() {
            char lastnameFirstChar = Apellido[0];

            return char.ToLowerInvariant(lastnameFirstChar);
        }

         public int CompareTo(Usuario other)
        {// a compareTo b
            if (other == null) {
                return 1; // > 0
            }
                    //==
            return ReferenceEquals(this, other) ? 0 : CompareByFullName(other);
        }

        private int CompareByFullName(Usuario other)
        {
            return string.Compare(nombreCompleto, other.nombreCompleto, StringComparison.OrdinalIgnoreCase);
        }

    }
}