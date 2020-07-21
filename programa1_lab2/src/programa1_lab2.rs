use std::env;

fn main(){
  let parametro: Vec<String> = env::args().collect();
  let numero_ingresado = &parametro[1];
  let cantidad: i32 = numero_ingresado.parse().expect("El numero debe ser positivo");

  for indice in 1..cantidad + 1 {
	println!("{}", indice);
  }

  println!("\r\n");
}