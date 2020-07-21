use std::io;

fn main() -> std::io::Result<()>{
  let mut i = 0;
  let mut sumatoria = 0;
  let mut cantidad: i32 = 0;
  loop{
	let mut numero_nuevo = String::new();
	io::stdin().read_line(&mut numero_nuevo).expect("Valor no valido");
	println!("{}", numero_nuevo.trim());
	if numero_nuevo == "\r\n"{
		sumatoria = sumatoria - cantidad;
		sumatoria /= 2;
		let promedio = sumatoria / (i - 2);
		println!("{}", promedio);
		break;		
	}
	cantidad = numero_nuevo.trim().parse().expect("Valor no valido");
	sumatoria += cantidad;
	i += 1;
  }
  Ok(())
}