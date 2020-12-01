using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments1
{
    class Program
    {
        static void Main()
        {
            Employee e = new Employee();
            
            e.NAME = "";
            Console.WriteLine(e.NAME);
            Employee e1 = new Employee();
            e1.NAME = "akshay";
            Console.WriteLine(e1.NAME);



            e.BASIC = 190000;
            Console.WriteLine("basic salary = "+ e.BASIC);

            e.BASIC = 19000000;

            e.DEPTNO = 1;
            Console.WriteLine("department no is "+ e.DEPTNO);

            e.DEPTNO = -2;

            Employee o1 = new Employee("Amol", 123465, 10);
            Employee o2 = new Employee("Amol", 123465);
            Employee o3 = new Employee("Amol");


            Employee o4 = new Employee();
            Employee o5 = new Employee();
            Employee o6 = new Employee();
           


            Console.WriteLine("netsalary is "+e.GetNetSalary());

            Console.ReadLine();
        }
    }

    public class Employee
    {
        #region constructors
        public Employee()
        {
            EmpNo++;
            Console.WriteLine("employee no = "+EmpNo);
        }

        public Employee(string NAME,decimal BASIC,short DEPTNO)
        {
            this.NAME = NAME;
            this.BASIC = BASIC;
            this.DEPTNO = DEPTNO;

            Console.WriteLine(NAME+" "+BASIC+" "+DEPTNO );
        }

        public Employee(string NAME, decimal BASIC)
        {
            this.NAME = NAME;
            this.BASIC = BASIC;
            Console.WriteLine(NAME + " " + BASIC );
        }

        public Employee(string NAME)
        {
            this.NAME = NAME;

            Console.WriteLine(NAME );
        }

        #endregion

        #region properties
        private String name;

        public String NAME
        {
            set
            {
                if(value != "")
                {
                    name = value;
                }
                else
                {
                    Console.WriteLine("wrong input!!! please enter valid input!!");
                }
            }

            get
            {
                return name;
            }
        }

        private static int EmpNo;

        public static int EMPNO
        {
            get
            {
                return EmpNo;
            }
        }

        private decimal Basic;

        public decimal BASIC
        {
            set
            {
                if(value>100000 && value <999999)
                {
                    Basic = value;
                }
                else
                {
                    Console.WriteLine("invalid basic salary");
                }
            }

            get
            {
                return Basic;
            }

        }

        private short DeptNo;

        public short DEPTNO
        {
            set
            {
                if (value > 0)
                {
                    DeptNo = value;
                }
                else
                {
                    Console.WriteLine("invalid department no");
                }
            }

            get
            {
                return DeptNo;
            }
        }
        #endregion

        #region methods
        public decimal GetNetSalary()
        {
            decimal basic = 100000;
            decimal hra = 50000;
            decimal da = 40000;

            decimal netSalary = basic + hra + da;

            return netSalary;
        }
        #endregion
    }
}
