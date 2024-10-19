using System;
using System.Collections.Generic; 

// Se crea la clase Producto que maneja el codigo, nombre, cantidad y precio
class Producto
{
    public int Codigo { get; set; }
    public string Nombre { get; set; }
    public int Cantidad { get; set; }
    public decimal Precio { get; set; }

    public Producto(int codigo, string nombre, int cantidad, decimal precio)
    {
        Codigo = codigo;
        Nombre = nombre;
        Cantidad = cantidad;
        Precio = precio;
    }

    public override string ToString()
    {
        return $"Código: {Codigo}, Nombre: {Nombre}, Cantidad: {Cantidad}, Precio: {Precio}";
    }
}

//clase inventario donde se manejan los productos que se ingresan
class Inventario
{
    //se crea la lista donde se van a guardar los prodcutos
    private List<Producto> productos = new List<Producto>();

    //metodo para agregar producto
    public void AgregarProducto()
    {
        Console.Write("Ingrese código del producto: ");
        int codigo = int.Parse(Console.ReadLine());

        Console.Write("Ingrese nombre del producto: ");
        string nombre = Console.ReadLine();

        Console.Write("Ingrese cantidad del producto: ");
        int cantidad = int.Parse(Console.ReadLine());

        Console.Write("Ingrese precio del producto: ");
        decimal precio = decimal.Parse(Console.ReadLine());

        productos.Add(new Producto(codigo, nombre, cantidad, precio));
        Console.WriteLine("Producto agregado con éxito.");
    }

    public void EliminarProducto()
    {
        Console.Write("Ingrese código del producto a eliminar: ");
        int codigo = int.Parse(Console.ReadLine());

        Producto producto = productos.Find(p => p.Codigo == codigo);
        if (producto != null)
        {
            productos.Remove(producto);
            Console.WriteLine("Producto eliminado con éxito.");
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }

    public void ModificarProducto()
    {
        Console.Write("Ingrese código del producto a modificar: ");
        int codigo = int.Parse(Console.ReadLine());

        Producto producto = productos.Find(p => p.Codigo == codigo);
        if (producto != null)
        {
            Console.Write("Ingrese nuevo nombre del producto: ");
            producto.Nombre = Console.ReadLine();

            Console.Write("Ingrese nueva cantidad del producto: ");
            producto.Cantidad = int.Parse(Console.ReadLine());

            Console.Write("Ingrese nuevo precio del producto: ");
            producto.Precio = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Producto modificado con éxito.");
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }

    public void ConsultarProducto()
    {
        Console.Write("Ingrese código del producto a consultar: ");
        int codigo = int.Parse(Console.ReadLine());

        Producto producto = productos.Find(p => p.Codigo == codigo);
        if (producto != null)
        {
            Console.WriteLine(producto.ToString());
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }

    public void MostrarTodosLosProductos()
    {
        if (productos.Count == 0)
        {
            Console.WriteLine("No hay productos en el inventario.");
        }
        else
        {
            foreach (var producto in productos)
            {
                Console.WriteLine(producto.ToString());
            }
        }
    }
}

class Ejercicio1
{
    static void Main(string[] args)
    {
        Inventario inventario = new Inventario();
        int opcion;

        do
        {
            Console.WriteLine("\n--- Menú de Inventario ---");
            Console.WriteLine("1. Agregar producto");
            Console.WriteLine("2. Eliminar producto");
            Console.WriteLine("3. Modificar producto");
            Console.WriteLine("4. Consultar producto");
            Console.WriteLine("5. Mostrar todos los productos");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    inventario.AgregarProducto();
                    break;
                case 2:
                    inventario.EliminarProducto();
                    break;
                case 3:
                    inventario.ModificarProducto();
                    break;
                case 4:
                    inventario.ConsultarProducto();
                    break;
                case 5:
                    inventario.MostrarTodosLosProductos();
                    break;
                case 6:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        } while (opcion != 6);
    }
}
