import java.util.Scanner;

public class MiClase
{
public static void main(string[] args)
{
//Esto es para comprobar
Scanner leer = new Scanner(System.in);
System.out.println("Ingresa la base");
int base = leer.nextInt();
System.out.println("Ingresa la altura");
int altura = leer.nextInt();

if(base == altura)
{
System.out.println("La figura es un cuadrado");
System.out.println("Area: "+(base*base)+" m2");
boolean cuadrado = true;
}
else if(base > altura)
{
System.out.println("La figura es un rectangulo a lo largo");
System.out.println("Area: "+(base*altura)+" m2");
boolean cuadrado = false;
}
else
{
System.out.println("La figura es un rectangulo a lo alto");
System.out.println("Area: "+(base*altura)+" m2");
boolean cuadrado = false;
}

switch(cuadrado)
{
case true:
System.out.println("Si era un cuadrado");
break;

case false:
System.out.println("No era un cuadrado");
break;

default:
System.out.println("Algo ocurrio");
break;
}

int[] arreglo = new int[10];

string[][] matriz = new string[10][20];
boolean matriz[][] = new boolean[10][20];

for(int i = 0; i < z; i = i + 1)
{
System.out.println("Mensaje numero: "+(i+1));
}

int numero = 42;

do
{
System.out.println("Adivina el numero");
int adivina = leer.nextInt();
if(adivina > numero)
{
System.out.println("Prueba con un numero mas chico");
}
else if( adivina < numero)
{
System.out.println("Prueba con un numero mas grande");
}

}
while(adivina != numero);

System.out.println("Felicidades has ganado");

boolean valor = false;

while(valor == false)
{
System.out.println("El valor es false");
}

//Esto es un comentario de una sola linea

}
}

