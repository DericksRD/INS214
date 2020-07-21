use std::io;

fn main() -> std::io::Result<()>{
  let mut cuadrado = 0;
  loop{
	let mut numero_nuevo = String::new();
	io::stdin().read_line(&mut numero_nuevo).expect("Valor no valido");
	if numero_nuevo == "\r\n"{
		println!("{}", cuadrado);
		break;
	}
	println!("{}", numero_nuevo.trim());
	let cantidad: i32 = numero_nuevo.trim().parse().expect("Valor no valido");
	cuadrado = cantidad * cantidad;
  }
  println!("\r\n");
  Ok(())
}