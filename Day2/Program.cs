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

            Console.WriteLine();

            e.BASIC = 190000;
            Console.WriteLine("basic salary = "+ e.BASIC);

            e.BASIC = 19000000;

            Console.WriteLine();

            e.DEPTNO = 1;
            Console.WriteLine("department no is "+ e.DEPTNO);

            e.DEPTNO = -2;
            Console.WriteLine();
            Employee o1 = new Employee("Amol", 123465, 10);
            Employee o2 = new Employee("Amol", 123465);
            Employee o3 = new Employee("Amol");

            Console.WriteLine();
            Employee o4 = new Employee();
            Employee o5 = new Employee();
            Employee o6 = new Employee();

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

            EmpNo++;
            Console.WriteLine("employee no = " + EmpNo);

            this.NAME = NAME;
            this.BASIC = BASIC;
            this.DEPTNO = DEPTNO;

            Console.WriteLine(NAME+" "+BASIC+" "+DEPTNO+ " netsalary is "+GetNetSalary() );
        }

        public Employee(string NAME, decimal BASIC)
        {
            EmpNo++;
            Console.WriteLine("employee no = " + EmpNo);

            this.NAME = NAME;
            this.BASIC = BASIC;
            Console.WriteLine(NAME + " " + BASIC + " netsalary is " + GetNetSalary());
        }

        public Employee(string NAME)
        {
            EmpNo++;
            Console.WriteLine(" employee no = " + EmpNo);

            this.NAME = NAME;

            Console.WriteLine(NAME + " netsalary is " + GetNetSalary());
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
       
            get;
           
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
           
            decimal hra = 50000;
            decimal da = 40000;

            decimal netSalary = BASIC + hra + da;

            return netSalary;
        }
        #endregion
    }
}
