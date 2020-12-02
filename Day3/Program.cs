using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("manager");
            Manager m1 = new Manager("akshay", 7000000, 1, "HR");
            Console.WriteLine("name "+m1.NAME);
            Console.WriteLine("net salary == "+m1.CalNetSalary());
            Console.WriteLine("===========================================");
            Console.WriteLine("general manager");
            GeneralManager gm1 = new GeneralManager("mahesh", 1000000, 1, "GM", "abccc");
            Console.WriteLine("name " + gm1.NAME);
            Console.WriteLine("net salary == " + gm1.CalNetSalary());
            Console.WriteLine("===========================================");
            Console.WriteLine("CEO");
            CEO c1 = new CEO("akash",800000,4);
            Console.WriteLine("name " + c1.NAME);
            Console.WriteLine("net salary == " + c1.CalNetSalary());
            Console.WriteLine("===========================================");
            Console.ReadLine();
        }
    }

    public abstract class Employee
    {
        private string name;
        private int empNo;
        private short deptNo;
        private decimal basic;
        private int lastEmpNo=0;

        public String NAME
        {
            set
            {
                if (value != "")
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

 

        public int EMPNO
        {

            get { return empNo; }
            private set { empNo = value; }

        }

        public abstract decimal BASIC
        {
            set;
            get;
            
        }

        public short DEPTNO
        {
            set
            {
                if (value > 0)
                {
                    deptNo = value;
                }
                else
                {
                    Console.WriteLine("invalid department no");
                }
            }

            get
            {
                return deptNo;
            }
        }

        public Employee()
        {
            EMPNO = ++lastEmpNo;
        }
        public Employee(string NAME="noname",decimal BASIC=150000,short DEPTNO=1)
        {
            EMPNO = ++lastEmpNo;
            this.NAME = NAME;
            this.BASIC = BASIC;
            this.DEPTNO = DEPTNO;
        }
        public abstract decimal CalNetSalary();
       
    }

    public class Manager : Employee
    {
        
        public override decimal BASIC { set; get; }

        private string designation;
        public string DESIGNATION
        {
            
            set 
            {

                if (value != "")
                {
                    designation = value;
                }
                else
                {
                    Console.WriteLine("invalid name");
                }    
            
            }
            get 
            { 
                return designation;
            }
        }

        public override decimal CalNetSalary()
        {
            decimal hra = 50000;
            decimal da = 60000;
            decimal netSalary = BASIC + hra +da ;
            return netSalary;
        }

        public Manager(string NAME="noname",decimal BASIC=600000,short DEPTNO=5,String DESIGNATION="HR") : base(NAME,BASIC,DEPTNO)
        {
           
            this.DESIGNATION = designation;
            this.NAME = NAME;
            this.BASIC = BASIC;
            this.DEPTNO = DEPTNO;
            
        }
    }

    public class GeneralManager : Manager
    {
        private string perks;

        public string PERKS
        {
            set;
            get;
           
        }

        public GeneralManager(string NAME="noname", decimal BASIC=700000, short DEPTNO=3, String DESIGNATION="gm",string PERKS="xyz"):base(NAME, BASIC, DEPTNO,DESIGNATION)
        {
           
            this.PERKS = PERKS;
            this.DESIGNATION = DESIGNATION;
            this.NAME = NAME;
            this.BASIC = BASIC;
            this.DEPTNO = DEPTNO;
        }
    }

    public class CEO : Employee
    {
        public CEO(string NAME = "noname", decimal BASIC = 900000, short DEPTNO = 6) :base(NAME,BASIC,DEPTNO)
        {
            
            this.NAME = NAME;
            this.BASIC = BASIC;
            this.DEPTNO = DEPTNO;
        }
        public override decimal BASIC { get ; set; }

        public sealed override decimal CalNetSalary()
        {
            decimal hra = 50000;
            decimal da = 60000;
            decimal netSalary = BASIC + hra + da;
            return netSalary;
        }
    }

}
