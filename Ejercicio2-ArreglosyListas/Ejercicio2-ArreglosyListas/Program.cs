using System;


//se crea la clase CuentaBancaria, donde se maneja el saldo, la cuenta bancaria, y los metodos para depositar, retirar y consultar
class CuentaBancaria
{
    private decimal saldo;

    public CuentaBancaria(decimal saldoInicial)
    {
        saldo = saldoInicial;
    }

    //Metodo para consultar el saldo de la cuenta
    public void ConsultarSaldo()
    {
        Console.WriteLine($"El saldo actual es: {saldo}");
    }

    //Metodo para depositar dinero a la cuenta
    public void DepositarDinero()
    {
        decimal monto = LeerDecimalPositivo("Ingrese la cantidad a depositar: ");
        saldo += monto;
        Console.WriteLine($"Has depositado {monto}. El nuevo saldo es {saldo}.");
    }

    //Metodo para retirar dinero a la cuenta
    public void RetirarDinero()
    {
        decimal monto = LeerDecimalPositivo("Ingrese la cantidad a retirar: ");
        if (monto <= saldo)
        {
            saldo -= monto;
            Console.WriteLine($"Has retirado {monto}. El nuevo saldo es {saldo}.");
        }
        else
        {
            Console.WriteLine("Saldo insuficiente para realizar esta operación.");
        }
    }

    private decimal LeerDecimalPositivo(string mensaje)
    {
        decimal valor;
        do
        {
            Console.Write(mensaje);
            if (!decimal.TryParse(Console.ReadLine(), out valor) || valor <= 0)
            {
                Console.WriteLine("Por favor, ingrese un número decimal positivo.");
            }
        } while (valor <= 0);
        return valor;
    }
}

//Clase main del programa 
class Program
{
    static void Main(string[] args)
    {
        CuentaBancaria cuenta = new CuentaBancaria(1000); // Inicializa la cuenta con un saldo de 1000.
        int opcion;

        do
        {
            Console.WriteLine("\n--- Menú de Cuenta Bancaria ---");
            Console.WriteLine("1. Consultar saldo");
            Console.WriteLine("2. Depositar dinero");
            Console.WriteLine("3. Retirar dinero");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Por favor, ingrese una opción válida.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    cuenta.ConsultarSaldo();
                    break;
                case 2:
                    cuenta.DepositarDinero();
                    break;
                case 3:
                    cuenta.RetirarDinero();
                    break;
                case 4:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        } while (opcion != 4);
    }
}
