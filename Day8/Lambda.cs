using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7
{
    class Lambda
    {
        static void Main()
        {
            Employee e = new Employee();
            
            Func<decimal, decimal, decimal, decimal> s1 = (P, N, R) => (P * R * N) / 100;
            Console.WriteLine(s1(100,5,10));

            Console.WriteLine();
            Console.WriteLine();

            Func<int, int, bool> b1 = (a, b) => (a > b);
            Console.WriteLine(b1(10,20));

            Console.WriteLine();
            Console.WriteLine();

            Func<Employee, decimal> bs = e1 => e1.basic;
            Console.WriteLine(bs(e));

            Console.WriteLine();
            Console.WriteLine();

            Func<int, bool> even = num => num % 2 == 0;
            Console.WriteLine(even(13));

            Console.WriteLine();
            Console.WriteLine();

            Func<Employee, bool> greater = e2 => e2.basic > 10000;
            Console.WriteLine(greater(e));

            Console.ReadLine();
        }

       static decimal SimpleInterest(decimal P, decimal N, decimal R)
        {
            return (P * N * R) / 100;
        }

        static bool IsGreater(int a, int b)
        {
            return a > b;
        }

        static bool IsEven(int num)
        {
            return num % 2 == 0;
        }
    }

    class Employee
    {
        public decimal basic = 15000;

       static decimal getBasic(Employee e)
        {
            return e.basic;
        }

        static bool IsGreaterThan10000(Employee e)
        {
            return e.basic > 10000;
        }
    }
}
