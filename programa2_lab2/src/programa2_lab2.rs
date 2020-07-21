use std::io;

fn main() -> std::io::Result<()>{
  let mut sumatoria: i32 = 0;
  loop{
	let mut numero_nuevo = String::new();
	io::stdin().read_line(&mut numero_nuevo).expect("Valor no valido");
	if numero_nuevo == "\r\n" {
		println!("{}", sumatoria);
		break;
	}
	let mut cantidad: i32 = numero_nuevo.trim().parse().expect("Valor no valido");
	sumatoria += cantidad;
	println!("{}", cantidad);
  }
  println!("\r\n");
  Ok(())
} 


/*
use std::io;

mod tokenizer {

pub fn read () -> [i32] {
       let reader = io::stdin();
       let mut bytes: [i32] = [];

       loop {
           let byte: int = reader.read_byte();
           if byte < 0 {
               return bytes;
           }
           bytes += [byte];
       }
}

}

fn main () {
       let bytes: [i32] = tokenizer::read();
       for bytes.each |byte| {
           io::print(#fmt("%c", *byte as char));
       }
    }  
*/

/**Todo lo que podria ser necesario:
extern crate char_stream;

use std::io::{self, Read, Write};
use std::str;
use char_stream::CharStream;

fn main() -> std::io::Result<()> {
    /*let mut buffer = String::new();
    let stdin = io::stdin();
    let mut handle = stdin.lock();

    handle.read_to_string(&mut buffer)?;

    **************************************************** */

    let unicode = '\u{f1}'.to_string(); //Letra ñ en unicode hexadecimal.
    let mut texto = String::new();

    texto.push_str(&unicode);

    println!("{}", texto);

    let stdout = io::stdout();
    let mut handle = stdout.lock();
    for i in 1..10 {
        handle.write_all(b"*")?;
    }

    let letra = "ñ";
    let letra_codificada = &letra.escape_unicode();

    println!("\nLetra a codificada: {}", letra_codificada);

    /*let mut letra_byte = "ñ".as_bytes();
    let letra_traducida = str::from_utf8(&letra_byte);

    let mut tamanho = [0 ; 2];
    let reader = &letra_byte.read(&mut tamanho[..]);
    println!("{}", reader);*/

    let arreglo_caracteres: Vec<char> = vec!['1', 'e'];

    let cadena_texto = String::from( &arreglo_caracteres[0].to_string() );
    println!("{}", &cadena_texto);

    for i in 0..2 {
        if arreglo_caracteres[i].is_numeric() {
            println!("Is numeric!");
        } else {
            println!("It isn't numeric :(");
        }
    }    

    let numero: i32 = cadena_texto.parse().expect("Valor no valido");
    println!("{}", numero);

    for i in io::stdin().bytes() {
        println!("{}", i);
    }
    //Mientras tanto.
    /*let mut stream = CharStream::from_stdin();
    while let Some(caracter) = stream.next() {
        println!("{}", caracter);
    }*/

    /*let mut cadena = String::new();

    for caracter in io::stdin() {
        /*let caracter_ingresado: String = caracter;
        cadena.push_str(&caracter_ingresado);*/
        cadena.push_str(&caracter);
    }

    println!("{}", cadena);*/

    Ok(())

    
}






















/*
    extern crate unicode_width;

    use unicode_width::UnicodeWidthStr;
    
    fn main(){
        let texto_prueba = "Hola mundo";
        let largo = UnicodeWidthStr::width(texto_prueba);
    
        println!("Largo en unicode de {}: {}", texto_prueba, largo);
    }
*/
