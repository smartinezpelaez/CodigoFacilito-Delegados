// Un delegado es un apuntador sobre una funciones
// Apartir de los delegados podes crear funciones que reciban como parametros otras funciones y metodos que reciban como argumentos otros metodos
// Con los delegados se puede implementar callbacks en c#
// Se puede validar la estructura de una funcion 
// se puede validar si retorna un valor o no

// Una operacón = una funcion
// Deposito
// Retiro

class Program
{
    public delegate float DelegateOperacion(float val1, float val2);

    public static float Deposito(float cantidad, float monto)
    {
        return cantidad + monto;
    }

    public static float Retiro(float cantidad, float monto)
    {
        if (cantidad > monto)
        {
            Console.WriteLine("No es posible realizr el retiro!!!");
            return 0.0f;
        }
        return monto - cantidad;
    }

    public static float EjecutarOperacion(DelegateOperacion operacion, float cantidad, float monto)
    {
        Console.WriteLine("Estamos por esjecutar una operación !!");
        float result = operacion(cantidad, monto);
        Console.WriteLine(result);
        Console.WriteLine("La operacion se ha ejecutado !!");
        return result;
    }

    private static void Main(string[] args)
    {
        //Delegate
        DelegateOperacion retiro = Retiro;
        DelegateOperacion deposito = Deposito;


        //Forma corta
        DelegateOperacion depositoInteres = (cantidad, monto) => 
        cantidad > 100 ? cantidad + monto + (cantidad * 0.02f) : cantidad + monto;

        //Forma larga de hacerlo
        //DelegateOperacion depositoInteres = (cantidad, monto) =>
        //{
        //        if (cantidad > 100)
        //        {
        //        Console.WriteLine("Deposito con interes");
        //        return cantidad + monto + (cantidad * 0.02f);
        //        }
        //        return cantidad + monto;
        //};

        EjecutarOperacion(depositoInteres, 101, 100);
    }
}