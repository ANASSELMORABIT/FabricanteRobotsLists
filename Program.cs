using System.Runtime.InteropServices;

internal class Program

{
    private static void Main(string[] args)
    {
        var rand = new Random();
        List<Robot> fabricaRobots = new List<Robot>();
        List<string> Modelos= ["R2D2", "C3PO", "BBB"];
        bool controlOpciones=true;
        int opcion;
        
        while(controlOpciones){
            Console.WriteLine("0-Salir");
            Console.WriteLine("1- Agregar Robot");
            Console.WriteLine("2- Mostrar un robot a traves de su posicion");
            Console.WriteLine("3- Mostrar todos los robots");
            Console.WriteLine("4-Eliminar un robot");
            Console.WriteLine("5-Restablecer un robot");
            Console.WriteLine("----------------");
            Console.WriteLine("ingresa un opcion");
            opcion=Convert.ToInt32(Console.ReadLine());
            switch (opcion){
                case 0: Console.WriteLine("Fin Programma");
                        controlOpciones=false;
                        break;
                case 1: Console.WriteLine("Agregando Robot...");
                        fabricaRobots=crearRobots(fabricaRobots,rand,Modelos);
                        break;
                case 2: Console.WriteLine("Mostrando robot por posicion...");
                        mostratRobotPorPosicion(fabricaRobots);
                        break;
                case 3:Console.WriteLine("Mostrar Todo los robots...");
                        MostrarTodoRobots(fabricaRobots);
                        break;
                case 4:Console.WriteLine("Eliminar Robot...");
                        fabricaRobots=EliminarRobot(fabricaRobots);
                        break;
                case 5: Console.WriteLine("Restableciendo Robot...");
                        fabricaRobots=RestablecerRobots(fabricaRobots,rand);
                        break;
                default:Console.WriteLine("Opcion no valida");
                        Console.WriteLine("Ingresa una opcion nueva");
                        break;

            }

        }
    }
    //---------------------------------------------------------------------
    //El Struct del Robot(Cada robot tiene nombre,modelo,posicion)
    public struct Robot{
        public string nombre;
        public string modelo;
        public int posicion;
    }
    //----------------------------------------------------------------------
    //Funcion de Verificar si el nombre aleatoeio exite en la lista de robots.
    static string verificarNombres(List<Robot> fabricaRobots,Random rand) {
       bool test;
       bool control=true;
       string nombreRobot=generalNombreAleatorio(rand);
       while(control){ /*Este while nos ayuda a generar un nombre aleatorio que no exista en la fabrica de robots*/
           test=false;
           foreach(Robot robot in fabricaRobots){
               if(robot.nombre==nombreRobot){
                   test=true;
                   break;
               }
           }
           if( test==false){
              control=false; 
           }
           else{
               nombreRobot=generalNombreAleatorio(rand);
           }
       }
       return nombreRobot;
    }
    //----------------------------------------------------------------------
    //Funcion de Crear un nuevo robot en la lista de robots.
    static List<Robot> crearRobots(List<Robot> fabricaRobots,Random rand,List<string> Modelos) {
       Robot robotnuevo;
       string nombreRobot=verificarNombres(fabricaRobots,rand);
       robotnuevo.nombre=nombreRobot; //Asignamos el nombre aleatorio a la variable nombreRobot
       robotnuevo.modelo=generalModeloAleatorio(Modelos,rand); //Asignamos el modelo aleatorio a la variable modelo
       robotnuevo.posicion=fabricaRobots.Count; //Asignamos la posicion del robot en la lista de robots, utilizamos fabricaRobots.Count para saber la posicion del ultimo robot agregado
       fabricaRobots.Add(robotnuevo); //Agregamos el nuevo robot a la lista
       Console.WriteLine("El robot Creado Corectamente,Con los Siguientes Datos:");
       Console.WriteLine("Nombre: " + robotnuevo.nombre);
       Console.WriteLine("Modelo: "+robotnuevo.modelo);
       Console.WriteLine("Posicion: "+robotnuevo.posicion);
       return fabricaRobots;
    }
    //-----------------------------------------------------------------------
    //Funcion de restablecer la configuracion de un robot.
    static List<Robot> RestablecerRobots(List<Robot> fabricaRobots,Random rand) {
        int posicionRobot;
        do{ //Preguntamos por la posicion del robot que queremos restablecer
            Console.WriteLine("Ingresa la posicion del robot que deseas restablecer");
            posicionRobot=Convert.ToInt32(Console.ReadLine());
        }while(posicionRobot>=fabricaRobots.Count);
        Robot robotRestablecido=fabricaRobots[posicionRobot];
        robotRestablecido.nombre=verificarNombres(fabricaRobots,rand); //Asignamos un nuevo nombre aleatorio al robot
        fabricaRobots[posicionRobot]=robotRestablecido;
        Console.WriteLine("El nuevo nombre del robot es: "+robotRestablecido.nombre);
        return fabricaRobots;
    }
    //----------------------------------------------------------------------
    //Funcion de general un nombre aleatorio para un robot.
    static string generalNombreAleatorio(Random rand) //Funcion que nos ayuda a generar un nombre aleatorio
    {
            int randomNumber1 = rand.Next(0, 26); /*Este linaje genera un numero aleatorio entre 0 y 25,porque la funcion random acebta solo enteros*/
            int randomNumber2 = rand.Next(0, 26); /* En este parte de codigo aplicamos la formula para convertir el numero aleatorio a letra*/
            int numero1=rand.Next(0, 10);
            int numero2=rand.Next(0, 10);
            char letraAleatoria1 = (char)('A' + randomNumber1);
            char letraAleatoria2 = (char)('A' + randomNumber2);
            string nombreRobot = $"{letraAleatoria1}{letraAleatoria2}{numero1}{numero2}";
            return nombreRobot;
    }
    //---------------------------------------------------------------------
    //Funcion de general un Modelo Aleatario para un robot
    static string generalModeloAleatorio(List<string> Modelos,Random rand){
        int randomNumber = rand.Next(0, Modelos.Count);
        string modelo = Modelos[randomNumber];
        return modelo;
    }
    //--------------------------------------------------------------------
    //Funcion de mostrar un robot a traves de su posicion en la lista.
    static void mostratRobotPorPosicion(List<Robot> fabricaRobots){
        int posicionMostrar;
        do{ //Preguntamos por la posicion del robot que queremos restablecer
            Console.WriteLine("Ingresa la posicion del robot que deseas restablecer");
            posicionMostrar=Convert.ToInt32(Console.ReadLine());
        }while(posicionMostrar>=fabricaRobots.Count);// Este while es para que no se salga de la lista de robots
        Console.WriteLine("El nombre del robot es: ");
        Console.WriteLine(fabricaRobots[posicionMostrar].nombre);
        Console.WriteLine("El modelo del robot es: ");
        Console.WriteLine(fabricaRobots[posicionMostrar].modelo);
        Console.WriteLine("La posicion del robot es: ");
        Console.WriteLine(fabricaRobots[posicionMostrar].posicion);
    }
    //--------------------------------------------------------------------
    // Funcion de Eliminar un roboto de la lista.
    static List<Robot> EliminarRobot(List<Robot> fabricaRobots) {
        int posicionEliminar;
        do{
            Console.WriteLine("Ingresa la posicion del robot que deseas eliminar");
            posicionEliminar=Convert.ToInt32(Console.ReadLine());
        }while(posicionEliminar>=fabricaRobots.Count);
        fabricaRobots.RemoveAt(posicionEliminar);
        Console.WriteLine("Robot eliminado correctamente");
        return fabricaRobots;
    }
    //----------------------------------------------------------------------
    //Funcion de Mostrar Todos los robots de la lista.
    static void MostrarTodoRobots(List<Robot> fabricaRobots){
        foreach(Robot robot in fabricaRobots){
            Console.WriteLine("-----------------------");
            Console.WriteLine("Nombre: "+robot.nombre);
            Console.WriteLine("Modelo: "+robot.modelo);
            Console.WriteLine("Posicion:"+robot.posicion);
        }
    }
}

