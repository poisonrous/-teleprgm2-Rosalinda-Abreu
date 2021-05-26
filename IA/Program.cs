using System;

namespace IA
{
    class Figuras
    {
        //declaracion de datos de la Clase
        private string forma;
        private float perimetro;
        private float area;

        //funciones de acceso
        public string _fo
        {
            get { return forma; }
            set { forma = value; }
        }

        public float _pe
        {
            get { return perimetro; }
            set { perimetro = value; }
        }

        public float _ar
        {
            get { return area; }
            set { area = value; }
        }

        //métodos de la Clase (no los declararé en la clase padre porque los métodos son diferentes para cada subclase)

        public void resultado()
        {
            Console.WriteLine("La imagen contiene una figura de forma " + _fo + " con " + _ar + " de área y " + _pe + " de perímetro.");
        }
    }

    class Circulo : Figuras
    {   //declaración de datos de la subclase
        private float radio;

        //funciones de acceso
        public float _ra
        {
            get { return radio; }
            set { radio = value; }
        }

        //nuevos métodos
        new public void leermedidas()
        {
            Console.WriteLine("Ingrese el radio del círculo: ");
            _ra = Single.Parse(Console.ReadLine());
        }

        new public void calperimetro()
        {
            _pe = 6.28f * _ra;
        }

        new public void calarea()
        {
            _ar = 3.14f * _ra * _ra;
        }

        private static int cantidad;

        public Circulo() //contador
        {
            _fo = "circular";
            cantidad++;
        }
        public static int getCantidad()
        {
            return cantidad;
        }
    }

    class Rectangulo : Figuras
    {   //declaración de datos de la subclase
        private float basee;
        private float altura;

        //funciones de acceso
        public float _ba
        {
            get { return basee; }
            set { basee = value; }
        }

        public float _al
        {
            get { return altura; }
            set { altura = value; }
        }
        //nuevos métodos
        new public void leermedidas()
        {
            Console.WriteLine("Ingrese la base del rectángulo: ");
            _ba = Single.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la altura del rectángulo: ");
            _al = Single.Parse(Console.ReadLine());
        }

        new public void calperimetro()
        {
            _pe = (2 * _ba) + (2 * _al);
        }

        new public void calarea()
        {
            _ar = _ba * _al;
        }

        private static int cantidad;

        public static int _can
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public Rectangulo()     //contador
        {
            _fo = "rectángular";
            cantidad++;
        }
        public static int getCantidad()
        {
            return cantidad;
        }
    }

    class Cuadrado : Rectangulo
    {   //declaración de datos de la subclase

        //nuevos métodos
        new public void leermedidas()
        {
            Console.WriteLine("Ingrese el lado del cuadrado: ");
            _ba = Single.Parse(Console.ReadLine());
            _al = _ba;
            
        }       //no se escriben nuevos métodos para calcular perímetro y área porque se pueden aplicar los de la clase Rectangulo

        private static int cantidad;

        public Cuadrado()   //contador
        {
            _fo = "cuadrada";
            Rectangulo._can = Rectangulo._can - 1;
            cantidad++;
        }
        new public static int getCantidad()
        {
            return cantidad;
        }
    }

    class Elipse : Figuras
    {   //declaración de datos de la subclase
        private float ejemayor;
        private float ejemenor;
        //funciones de acceso
        public float e_ma
        {
            get { return ejemayor; }
            set { ejemayor = value; }
        }

        public float e_me
        {
            get { return ejemenor; }
            set { ejemenor = value; }
        }
        //nuevos métodos
        new public void leermedidas()
        {
            Console.WriteLine("Ingrese el eje mayor: ");
            e_ma = Single.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el eje menor: ");
            e_me = Single.Parse(Console.ReadLine());
        }

        new public void calperimetro()
        {
            _pe = 6.28f * (float)Math.Sqrt((e_me * e_me + e_ma * e_ma) / 2);
        }

        new public void calarea()
        {
            _ar = 3.14f * e_me * e_ma;
        }

        private static int cantidad;

        public Elipse()     //contador
        {
            _fo = "elíptica";
            cantidad++;
        }
        public static int getCantidad()
        {
            return cantidad;
        }
    }

    class Triangulo : Figuras
    {   //declaración de datos de la subclase
        private float ladoa;
        private float ladob;
        private float ladoc;
        private float semiperi;     //para calcular el área de un triángulo escaleno

        public float a
        {
            get { return ladoa; }
            set { ladoa = value; }
        }

        public float b
        {
            get { return ladob; }
            set { ladob = value; }
        }

        public float c
        {
            get { return ladoc; }
            set { ladoc = value; }
        }

        public float s
        {
            get { return semiperi; }
            set { semiperi = value; }
        }
        //nuevos métodos
        new public void leermedidas()
        {
            Console.WriteLine("Ingrese el lado a: ");
            a = Single.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el lado b: ");
            b = Single.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el lado c: ");
            c = Single.Parse(Console.ReadLine());
        }

        new public void calperimetro()
        {
            _pe = a + b + c;
        }

        new public void calarea()                   //ya que ya tengo los lados, evitaré solicitar la altura y la base, calculando el área según sus lados (la formula es diferente según el tipo de triángulo)
        {
            if((a == b)&&(a == c)){                  //triángulo equilatero
                _ar = (float)Math.Sqrt(3) / 4 * a * a;
            } else if ((a == b)&&(a != c)) {        //triángulo isosceles donde a y b son iguales
                _ar = c * (float)Math.Sqrt(a * a - c * c / 4) / 2;
            } else if ((b == c) && (b != a)){       //triángulo isosceles donde b y c son iguales
                _ar = a * (float)Math.Sqrt(b * b - a * a / 4) / 2;
            } else if ((a == c) && (a != b))
            {                                       //triángulo isosceles donde a y c son iguales
                _ar = a * (float)Math.Sqrt(a * a - b * b / 4) / 2;
            }
            else {                                   //triángulo escaleno
                  s = (a + b + c) / 2;
                _ar = (float)Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            }
        }

        private static int cantidad;

        public Triangulo()  //contador
        {
            _fo = "triangular";
            cantidad++;
        }
        public static int getCantidad()
        {
            return cantidad;
        }
    }
    //Programa principal
    class Prueba
    {
        static void Main(string[] args)
        {   //como el número de figuras detectadas puede variar en cada análisis, se le solicitará la cantidade de figuras detectadas para comenzar el bucle
            Console.Write("Número de figuras detectadas:");
            int i = Int32.Parse(Console.ReadLine());

            Figuras[] fig = new Figuras[i];
            int j = 0;
            while (j < i)
            {   int _f;
                Console.WriteLine("La figura es un 1) Circulo 2) Rectángulo 3) Cuadrado 4) Elipse 5) Triángulo");
                _f = int.Parse(Console.ReadLine());

                if (_f == 1)
                {
                    Circulo ci = new Circulo();  //instancia
                    ci.leermedidas();
                    ci.calperimetro();
                    ci.calarea();
                    ci.resultado();
                }
                else if (_f == 2)
                {
                    Rectangulo re = new Rectangulo();
                    re.leermedidas();
                    re.calperimetro();
                    re.calarea();
                    re.resultado();
                }
                else if (_f == 3)
                {
                    Cuadrado cu = new Cuadrado();
                    cu.leermedidas();
                    cu.calperimetro();
                    cu.calarea();
                    cu.resultado();
                }
                else if (_f == 4)
                {
                    Elipse el = new Elipse();
                    el.leermedidas();
                    el.calperimetro();
                    el.calarea();
                    el.resultado();
                }
                else if (_f == 5)
                {
                    Triangulo tr = new Triangulo();
                    tr.leermedidas();
                    tr.calperimetro();
                    tr.calarea();
                    tr.resultado();
                }
                j++;
            }
            Console.WriteLine("Hay un total de " + Circulo.getCantidad() + " circulos, " + Rectangulo.getCantidad() + " rectángulos, " + Cuadrado.getCantidad() + " cuadrados, " + Elipse.getCantidad() + " elipses y " + Triangulo.getCantidad() + " triángulos.");

        }
    }
}