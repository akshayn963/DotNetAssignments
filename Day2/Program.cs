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
            
            Employee o1 = new Employee("Amol", 123465, 10);
            Employee o2 = new Employee("Amol", 123465);
            Employee o3 = new Employee("Amol");
            Employee o4 = new Employee();

            Console.WriteLine();
            Console.WriteLine(o1.EMPNO);
            Console.WriteLine(o1.GetNetSalary());
            Console.WriteLine();
            Console.WriteLine(o2.EMPNO);
            Console.WriteLine(o2.GetNetSalary());
            Console.WriteLine();
            Console.WriteLine(o3.EMPNO);
            Console.WriteLine(o3.GetNetSalary());
            Console.WriteLine();
            Console.WriteLine(o4.EMPNO);
            Console.WriteLine(o4.GetNetSalary());
            Console.WriteLine("===================");

            Console.WriteLine();
            Console.WriteLine(o4.EMPNO);
            Console.WriteLine(o4.GetNetSalary());
            Console.WriteLine();
            Console.WriteLine(o3.EMPNO);
            Console.WriteLine(o3.GetNetSalary());
            Console.WriteLine();
            Console.WriteLine(o2.EMPNO);
            Console.WriteLine(o2.GetNetSalary());
            Console.WriteLine();
            Console.WriteLine(o1.EMPNO);
            Console.WriteLine(o1.GetNetSalary());
            Console.WriteLine();
            Console.ReadLine();
        }
    }

    public class Employee
    {
        #region constructors
       
        public Employee(string NAME="noname",decimal BASIC=150000,short DEPTNO=10)
        {

            this.EMPNO=++lastEmpNo;
           

            this.NAME = NAME;
            this.BASIC = BASIC;
            this.DEPTNO = DEPTNO;

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

        private static int lastEmpNo = 0;

        private  int EmpNo;

        public  int EMPNO
        {

            get { return EmpNo; }
            private set { EmpNo = value; }

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
            decimal da = 60000;

            decimal netSalary = BASIC + hra + da;

            return netSalary;
        }
        #endregion
    }
}
