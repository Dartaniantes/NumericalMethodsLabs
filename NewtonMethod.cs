using System.Numerics;

namespace NumericalMethodsLabs
{
    public class NewtonMethod
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введiть з якою точнiстю розрахувати резутьтат");
            double Eps = Double.Parse(Console.ReadLine());

            //double Eps = 0.0000001;
            Console.WriteLine("Введiть реальну частину комплексного числа");

            double rel = Double.Parse(Console.ReadLine());

            Console.WriteLine("Введiть уявну частину комплексного числа");

            double img = Double.Parse(Console.ReadLine());

            //double rel = -2;
            //double img = 0;

            Complex st = new Complex(rel, img);

            int coun = 0;

            Complex Nuton11(Complex start)
            {
                Complex del = new Complex(1, 0);
                while (Math.Abs(del.Real) > Eps)
                {
                    coun++;
                    del = Pohidna(0, start) / Pohidna(1, start);
                    start -= del;
                }
                return start;
            }

            Complex u = Pohidna(1, st);

            int coun2 = 0;
            Complex Nuton12(Complex start)
            {
                Complex del = new Complex(1, 0);
                while (Math.Abs(del.Real) > Eps)
                {
                    coun2++;

                    del = Pohidna(0, start) / u;
                    start -= del;
                }
                return start;
            }
            Console.WriteLine();
            Console.WriteLine("МЕТОД НЬЮТОНА");
            Console.WriteLine("Корiнь = " + Nuton11(st));
            Console.WriteLine("Значення = " + Pohidna(0, Nuton11(st)));
            Console.WriteLine(coun + " операцiй");


            Console.WriteLine();
            Console.WriteLine("СПРОЩЕНИЙ МЕТОД НЬЮТОНА");
            Console.WriteLine("Корiнь = " + Nuton12(st));
            Console.WriteLine("Значення = " + Pohidna(0, Nuton12(st)));
            Console.WriteLine(coun2 + " операцiй");

            //этот метод мспользуеться в ньютоновских методах

            Complex Pohidna(int index, Complex val)
            {
                //x ^ 6 - 3x ^ 2 + x - 1
                switch (index)
                {
                    case 0:
                        return Complex.Pow(val, 6) - (3 * Complex.Pow(val, 2)) + val - 1;
                    case 1:
                        return 6 * Complex.Pow(val, 5) - (3 * 2 * val) + 1;
                    case 2:
                        return 6 * 5 * Complex.Pow(val, 4) - 6;
                    case 3:
                        return 6 * 5 * 4 * Complex.Pow(val, 3);

                    case 4:
                        return 6 * 5 * 4 * 3 * Complex.Pow(val, 2);
                    case 5:
                        return 6 * 5 * 4 * 3 * 2 * val;
                }
                return 6 * 5 * 4 * 3 * 2;

                //tg(0,58x+0,1)-x^2=0
                //switch (index)
                //{
                //    case 0:
                //        return Complex.Tan(((0.58 * val) + 0.1)) - Complex.Pow(val, 2);
                //    case 1:
                //        return 0.58 * (Complex.Pow(Complex.Tan(((0.58 * val) + 0.1)), 2)) - 2 * val + 0.57;

                //}
                //return 0.58 * (Complex.Pow(Complex.Tan(((0.58 * val) + 0.1)), 2)) - 2 * val + 0.57;

            }
            Complex Iret(Complex z)
            {
                if (DifLChange(0, z).Real < 1)
                {
                    Complex d = new Complex(1, 0);
                    while (Math.Abs(d.Real) > Eps)
                    {
                        d = z - LChange(0, z);
                        z = LChange(0, z);
                    }
                }
                else
                {
                    Complex d = new Complex(1, 0);
                    Complex diff = -21;
                    //-10
                    while (Math.Abs(d.Real) > Eps)
                    {
                        d = l(z) / diff;
                        z = z - d;
                    }
                    return z;
                }
                return z;
            }

            Complex Iret2(Complex z)
            {
                if (DifLChange(1, z).Real < 1)
                {
                    Complex d = new Complex(1, 0);
                    while (Math.Abs(d.Real) > Eps)
                    {
                        d = z - LChange(1, z);
                        z = LChange(1, z);
                    }
                }
                else
                {
                    Complex d = new Complex(1, 0);
                    Complex diff = -5;
                    //-10
                    while (Math.Abs(d.Real) > Eps)
                    {
                        d = l(z) / diff;
                        z = z - d;
                    }
                    return z;
                }
                return z;
            }

            Complex l(Complex val)
            {
                //2x^3-3x^2-12x+8=0
                return 2 * Complex.Pow(val, 3) - (3 * Complex.Pow(val, 2)) - (12 * val) + 8;
            }

            Complex DifLChange(int index, Complex val)
            {
                //x^2/2-x/2

                switch (index)
                {
                    case 0:
                        //x^3/6-x^2/4+8/12
                        return Complex.Pow(val, 2) / 2 - val / 2;

                    case 1:
                        //
                        return (Complex.Pow(val, 2) - 2) / (Complex.Pow(2.0 / 3.0 * Complex.Pow(val, 3) - 4 * val + 8.0 / 3, 1.0 / 2.0));


                }
                return Complex.Pow(val, 2) / 2 - val / 2;
            }
            Complex LChange(int index, Complex val)
            {

                switch (index)
                {
                    case 0:
                        //x^3/6-x^2/4+8/12

                        return Complex.Pow(val, 3) / 6 - (Complex.Pow(val, 2) / 4) + 8.0 / 12.0;

                    case 1:
                        //
                        return Complex.Pow(2.0 / 3.0 * Complex.Pow(val, 3) - 4 * val + 8.0 / 3, 1.0 / 2.0);

                }
                return Complex.Pow(val, 3) / 6 - (Complex.Pow(val, 2) / 4) + 8.0 / 12.0;
            }
            //Console.WriteLine();
            //Console.WriteLine("МЕТОД ПРОСТОЇ IТЕРАЦIЇ");
            //Console.WriteLine("Корiнь = " + Iret(st));
            //Console.WriteLine("Значення = " + l(Iret(st)));
            //Console.WriteLine();
            //Console.WriteLine("МЕТОД ПРОСТОЇ IТЕРАЦIЇ");
            //Console.WriteLine("Корiнь = " + Iret2(st));
            //Console.WriteLine("Значення = " + l(Iret2(st)));
        }
    }
}

