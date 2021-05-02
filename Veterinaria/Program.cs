using System;

namespace Veterinaria
{
    class Animales
    {
        //declaracion de datos de la Clase
        private string nombre;
        private string especie;
        private string sexo;
        private float edad;

        //funciones de acceso
        public string _no
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string _es
        {
            get { return especie; }
            set { especie = value; }
        }

        public string _se
        {
            get { return sexo; }
            set { sexo = value; }
        }

        public float _ed
        {
            get { return edad; }
            set { edad = value; }
        }

        //métodos de la Clase
        public void leerdatos()
        {
            Console.WriteLine("Ingrese la especie del animal: ");
            _es = Console.ReadLine();

            Console.WriteLine("Ingrese el sexo del " + _es + ": ");
            _se = Console.ReadLine();

            Console.WriteLine("Ingrese el nombre del " + _es + ": ");
            _no = Console.ReadLine();

            do
            {
                Console.WriteLine("Ingrese la edad del " + _es + ": ");
                _ed = Single.Parse(Console.ReadLine());
            } while (_ed < 0);
        }

        public void imprimirdatos()
        {
            Console.WriteLine("Datos del " + _es + ": ");
            Console.WriteLine("Nombre: " + _no);
            Console.WriteLine("Sexo: " + _se);
            Console.WriteLine("Edad: " + _ed);
        }
    }

    class Perro : Animales
    {   //declaración de datos de la subclase
        private string raza;
        private string perrarina;

        //funciones de acceso
        public string _ra
        {
            get { return raza; }
            set { raza = value; }
        }

        public string _pe
        {
            get { return perrarina; }
            set { perrarina = value; }
        }

        //nuevos métodos
        new public void leerdatos()
        {
            base.leerdatos();
            Console.WriteLine("Ingrese la raza del " + _es + ": ");
            _ra = Console.ReadLine();

            Console.WriteLine("Ingrese su perrarina favorita ");
            _pe = Console.ReadLine();
        }

        new public void imprimirdatos()
        {
            base.imprimirdatos();
            Console.WriteLine("Raza: " + _ra);
            Console.WriteLine("Perrarina: " + _pe);
        }

    }
    //Programa principal
    class Prueba
    {
        static void Main(string[] args)
        {
            Perro p = new Perro();  //instancia
            p.leerdatos();
            p.imprimirdatos();
        }
    }
}