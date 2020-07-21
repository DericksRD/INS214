using System;
using System.IO;

/*
 * 1. No permitir que se ingrese el mismo usuario dos veces.
 * 2. Permitir editar datos, siempre y cuando se cumpla el 1.
 */
 
namespace Programa_captura{
    public class Captura{
        //Atriutos:
        public static string texto = "";
        public static string linea = "";

        //Métodos:
        public static void Main(String[] args){

            //Mostrar informacion docuento:
            if(args.Length > 0 && args[0] == "-r"){
                if(File.Exists("usuarios.csv")){
                    StreamReader lector = new StreamReader("usuarios.csv");
                    texto = lector.ReadToEnd();
                    string[] columnas = new string[4];
                    int informacion = 0;
                    
                    RegresarLinea();
                    while (texto != "") { //Environment.NewLine
                        int contador = 0;
                        RegresarLinea();

                        columnas = linea.Split(',');

                        foreach (string dato in columnas) {
                            if (contador != 4) {
                                Console.Write(dato + ", ");
                            }
                            contador++;
                        }

                        informacion = Convert.ToInt32(columnas[4]);

                        if ((informacion & 1) == 1) {
                            Console.Write("\n Su sexo es hombre");
                        }

                        if ((informacion & 2) == 2) {
                            Console.Write("\n Es mayor de edad");
                        }

                        if ((informacion & 4) == 4) {
                            Console.Write("\n Tine licencia");
                        }

                        if ((informacion & 8) == 8) {
                            Console.Write("\n Tiene vehiculo");
                        }
                        Console.WriteLine("\n");
                    }
                } else{
                    Console.WriteLine("No se puede mostrar los datos porque el archivo no existe.");
                }
            }else {     
                string nombre, apellido;

                Console.WriteLine("Ingresa la opcion que desea" + 
                                "\n1. Ingresar Datos" + 
                                "\n2. Modificar Datos" + 
                                "\n3. Eliminar Datos");
                int opcion = leer_int();

                HashSetBasedArray hashArray = new HashSetBasedArray();
                switch (opcion)
                {
                    case 1:
                        do{
                            Console.WriteLine("Escriba su nombre:");
                            nombre = leer_linea();

                            Console.WriteLine("Escriba su apellido:");
                            apellido = leer_linea();

                            if( !File.Exists("usuarios.csv") ){
                                break;
                            }
                        }while(hashArray.ComprobarUsuario(nombre, apellido));
                        
                        Console.WriteLine("Escriba sus ahorros:");
                        double ahorros = leer_double();

                        Console.WriteLine("Escriba su contraseña:");
                        string password = leer_password();

                        Console.WriteLine("Escriba la contraseña nuevamente:");
                        string password_confirm = leer_password(); 

                        if(password == password_confirm){
                            Console.WriteLine("Sus contraseñas coinciden.");

                            //Consiguiendo información:
                            int informacion = 0;
                            string datos = "";

                            Console.WriteLine("Cual es su sexo? (m/f)");
                            datos = leer_linea();

                            if(datos == "m"){
                                informacion = 1; 
                            }

                            Console.WriteLine("Usted es mayor de edad? (si/no)");
                            datos = leer_linea();

                            if(datos == "si")
                                informacion = informacion | 2; 
                            
                            Console.WriteLine("Usted tiene licencia? (si/no)");
                            datos = leer_linea();

                            if(datos == "si")
                                informacion = informacion | 4; 

                            Console.WriteLine("Usted tiene vehiculo? (si/no)");
                            datos = leer_linea();

                            if(datos == "si")
                                informacion = informacion | 8; 


                            //Guardar los campos en el archivo .csv
                            Usuario usuarioGuardar = new Usuario(nombre, apellido, ahorros.ToString(), password, informacion.ToString());
                            hashArray.Add(usuarioGuardar);
                        }else {
                            Console.WriteLine("No se pueden ingresar datos porque las contraseñas no coinciden");
                        }
                        break;
                    case 2:
                        if( !File.Exists("usuarios.csv") ){
                            Console.WriteLine("No se puede modificar el archivo porque este está vacío. Favor introduzaca datos");
                        } else{
                            //Modificar el usuario:
                            Console.WriteLine("Para cambiar un usuario, ingrese su nombre:");
                            nombre = leer_linea();

                            Console.WriteLine("Ingrese su apelido:");
                            apellido = leer_linea();

                            Usuario usuarioModificar = new Usuario(nombre, apellido);
                            if(hashArray.Buscar(usuarioModificar)){
                                using( StreamReader lector = new StreamReader("usuarios.csv") ){
                                    texto = lector.ReadToEnd();

                                    while(texto != ""){
                                        RegresarLinea();

                                        if(linea.Contains(usuarioModificar.Nombre) && linea.Contains(usuarioModificar.Apellido))
                                            break;
                                    }    
                                } 


                                Console.WriteLine("Que campo desea cambiar?" + 
                                                "\n1. Nombre" +  
                                                "\n2. Ahorros" + 
                                                "\n3. Contraseña");
                                string decision = leer_linea();

                                string datoIngresado = "",
                                        datoNuevo = "";

                                switch (decision)
                                {
                                    case "1":
                                        Console.WriteLine("Ingrese el dato que desea cambiar:");
                                        datoIngresado = leer_linea();

                                        Console.WriteLine("Ingrese el nuevo dato:");
                                        datoNuevo = leer_linea();

                                        string[] columnas = linea.Split(',');
                                        if( !hashArray.ComprobarUsuario(datoNuevo, columnas[1] /*&& datoNuevo != columnas[1]*/) ){
                                            Modificar(linea, datoIngresado, datoNuevo);
                                        }
                                        break;
                                    case "2":
                                        Console.WriteLine("Ingrese el dato que desea cambiar:");
                                        datoIngresado = leer_linea();

                                        Console.WriteLine("Ingrese el nuevo dato:");
                                        datoNuevo = leer_linea();

                                        Modificar(linea, datoIngresado, datoNuevo);
                                        break;
                                    case "3":
                                        Console.WriteLine("Ingrese el dato que desea cambiar:");
                                        datoIngresado = leer_password();

                                        Console.WriteLine("Ingrese el dato nuevo:");
                                        datoNuevo = leer_password();
                                        Modificar(linea, datoIngresado, datoNuevo);
                                        break;
                                    default:
                                        Console.WriteLine("Esa opcion no es valida");
                                        break;
                                }
                                
                            } ///////////////////////////////////////////////////////////////    
                            else{
                                Console.WriteLine("No existe ningun usuario con ese nombre y apellido");
                            }
                        }

                        break;
                    case 3:
                        Console.WriteLine("Para eliminar un usuario, Ingrese su nombre:");
                        nombre = leer_linea();

                        Console.WriteLine("Ingrese el apellido");
                        apellido = leer_linea();

                        Usuario usuarioEliminar = new Usuario(nombre, apellido);
                        if(hashArray.Buscar(usuarioEliminar)){
                            hashArray.Remove(usuarioEliminar);
                        }else{
                            Console.WriteLine("El usuario que ingreso no se encuentra dentro del csv");
                        }
                        break;
                    default:
                        Console.WriteLine("La opcion introducida no es valida");
                        break;
                }
                
            }
        }

        public static void RegresarLinea(){
            linea = "";
            int indice = 0;
            try{
            indice = texto.IndexOf(Environment.NewLine);
                linea = texto.Substring(0, indice + 2);
                texto = texto.Substring(indice + 2); 
            }catch(Exception e){
                texto = "";
            }

        }

        
        public static void Modificar(string lineaAuxiliar, string datoIngresado, string datoNuevo){
            using( StreamReader lector = new StreamReader("usuarios.csv")){
                texto = lector.ReadToEnd();
            }

            string lineaNueva = lineaAuxiliar.Replace(datoIngresado, datoNuevo);
            texto = texto.Replace(lineaAuxiliar, lineaNueva);

            using( StreamWriter redactor = new StreamWriter("usuarios.csv") ){
                redactor.Write(texto);
            }
        }
        //Leer datos:

        public static String leer_linea(){
            char caracter;
            string palabra = "";

            while(true){
                caracter = Console.ReadKey().KeyChar;
                int ascii = (int)caracter;

                if(ascii == 13){
                    break;
                } else if(caracter == ''){
                    palabra = palabra.Substring(0, (palabra.Length - 1));
                    Console.Write(" \b");
                }else{
                    palabra += caracter.ToString();
                }
            }

            Console.WriteLine("");

            return palabra;
        }

        public static Int32 leer_int(){
            char caracter;
            string palabra = "";
            int numero = 0;

            while(true){
                caracter = Console.ReadKey(true).KeyChar;
                int ascii = (int)caracter;

                try{
                    numero = Convert.ToInt32( caracter.ToString() );
                    Console.Write(numero);
                }catch(Exception e){
                    numero = 0;
                }

                if(ascii == 13){
                    break;
                }else if(caracter == ''){
                    palabra = palabra.Substring(0, (palabra.Length - 1));
                    Console.Write(" \b");
                }else if(numero != 0){
                    palabra += numero.ToString();
                }
            }
            Console.WriteLine("");
            numero = Convert.ToInt32(palabra);

            return numero;
        }

        public static double leer_double(){
            char caracter;
            string palabra = "";
            double numero = 0;

            while(true){
                caracter = Console.ReadKey(true).KeyChar;
                int ascii = (int)caracter;

                try{
                    numero = Convert.ToDouble( caracter.ToString() );
                    Console.Write(numero);
                }catch(Exception e){
                    numero = 0;
                    if(caracter == '.'){
                        Console.Write(".");
                        palabra += caracter;
                    }
                }

                if(ascii == 13){
                    break;
                }else if(caracter == ''){
                    palabra = palabra.Substring(0, (palabra.Length - 1));
                    Console.Write(" \b");
                }else if(numero != 0){
                    palabra += numero.ToString();
                }
            }
            Console.WriteLine("");
            numero = Convert.ToDouble(palabra);

            return numero;
        }

        public static String leer_password(){
            char caracter;
            string palabra = "";

            while(true){
                caracter = Console.ReadKey(true).KeyChar;
                int ascii = (int)caracter;

                Console.Write("*");

                if(ascii == 13){
                    break;
                }else if(caracter == ''){
                    palabra = palabra.Substring(0, (palabra.Length - 1));
                    Console.Write(" \b");
                }else{
                    palabra +=caracter.ToString();
                }

            }
            Console.WriteLine("");

            return palabra;
        }
    }
}
