using static System.Math;

namespace NumericalMethodsLabs
{
    class SimpleIterationsMethod
    {
        public delegate double Func(double x);
        static int iterations = 0;
        static double eps = 0.0001;

        public static void Main(string[] args)
        {
            p();
            q();    
        }

        public static void q()
        {
            Console.WriteLine("\n\tq(x) root finding started\n");

            Func q = x => 2 * Pow(x, 3) - 3 * Pow(x, 2) - 12 * x + 8;             // roots: 0.611315455 , -2.1519448 , 3.0406293
            Console.WriteLine("q(x) = 2x^3 - 3x^2 - 12x + 8");

            //for root : x = 0.611315455
            //dFi(x01)<1 when x01=[-0.9 ; 1.9]
            Func fi = x => (2 * Pow(x, 3) - 3 * Pow(x, 2) + 8) / 12;          
            Func dFi = x => (Pow(x, 2) - x) / 2;
            double x01 = 1;

            Console.WriteLine("fi(x) = (2x^3 - 3x^2 + 8)/12");
            Console.WriteLine("dfi(x) = (x^2-x)/2");
            Console.WriteLine("|dfi(" + x01 + ")| = " + Abs(dFi(x01)));

            findRoot(q, fi, dFi, x01);

            // for roots : x = 3.0406293  x = -2.15194; 
            //dfi2(x02) < 1 when x02 = (-inf;-5.26] + [-4.14;0.14] + [1.253;+inf]
            Func fi2 = x => Cbrt((3 * Pow(x, 2) + 12 * x - 8) / 2);                                 
            Func dFi2 = x => (x + 2)*Cbrt(Pow(2,2)) / Cbrt(Pow(3 * Pow(x, 2) + 12 * x - 8, 2));
            double x02 = 0.14;

            Console.WriteLine("fi2(x) = Cbrt((3x^2 + 12x - 8)/2)");
            Console.WriteLine("dfi2(x) = Cbrt(3x^2 +12x - 8)/2");
            Console.WriteLine("|dfi2(" + x02 + ")| = " + Abs(dFi2(x02)));
            findRoot(q, fi2, dFi2, x02);

            double x03 = 1.5;

            Console.WriteLine("|dfi2(" + x03 + ")| = " + Abs(dFi(x03)));
            findRoot(q, fi2, dFi2, x03);

            Console.WriteLine("\n\tq(x) root finding ended");
        }

        public static void findRoot(Func f, Func fi, Func dFi, double x0)
        {
            double result;
            if (!MethodConverges(dFi, x0))
            {
                Console.WriteLine("Fi function picked up unsuccessfully. Try other way for bringing out the root" +
                    "\nPress any key to quit the program");
                Console.ReadKey();
                Environment.Exit(0);
            }
            result = SimpleIterations(fi, x0, eps);
            if (Abs(Round(result)%result) <= eps)
                result = Round(result);
            Console.WriteLine("root : x = " + result + "\t\t x0 = "+ x0 );
            Console.WriteLine("operations =  " + iterations + "\n");
        }

        public static void p()
        {
            Console.WriteLine("\tp(x) root finding started\n");
            Func p = x => Pow(x, 2) - Sin(PI * x);          // roots : x = 0 ;  x = 0.78723712
            Console.WriteLine("p(x) = x^2 - sin(PI*x)");

            //for root 0;   dFi(x01) < 1 when x01=[-0.9;0.9]
            Func fi = x => Asin(Pow(x, 2)) / PI;
            Func dFi = x => 2 * x / (PI * Sqrt(1 - Pow(x, 4)));
            double x01 = 0.9;
            Console.WriteLine("fi(x) = asin(x^2) / PI");
            Console.WriteLine("dfi(x) = 2x/(PI * sqrt(1-x^4))");
            Console.WriteLine("|dfi(" + x01 + ")| = " + Abs(dFi(x01)));

            findRoot(p, fi, dFi, x01);

            //for root 0.78723712;   dFi2(x02) < 1 when x02={... -1.5; 0.5; 2.5 ...}+-0.19
            Func fi2 = x => Sqrt(Sin(PI * x));
            Func dFi2 = x => PI * Cos(PI * x) / (2 * Sqrt(Sin(PI * x)));
            double x02 = 0.5 + 0.19;
            Console.WriteLine("fi2(x) = sqrt(sin(PI*x))");
            Console.WriteLine("dfi2(x) = PI * cos(PI * x) / (2*sqrt(sin(PI*x))5");
            Console.WriteLine("|dfi2("+x02+")| = " + Abs(dFi2(x02)));

            findRoot(p, fi2, dFi2, x02);
            Console.WriteLine("\tp(x) root finding ended\n");
        }

        public static bool HasRoot(Func f, double a, double b)
        {
            return (f(a) * f(b)) < 0;
        }

        public static bool MethodConverges(Func dfi, double x0)
        {
            return Abs(dfi(x0)) < 1;
        }

        public static double SimpleIterations(Func fi, double x0, double eps)
        {
            double x = fi(x0);
            double xprev = x0;
            iterations = 0;
            while (Abs(x-xprev) >= eps)
            {
                iterations++;
                xprev = x;
                x = fi(xprev);
            }
            return x;
        }
    }
}
