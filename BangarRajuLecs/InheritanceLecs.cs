using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BangarRajuLecs
{

    // Delegates
    public delegate void AddNumsDelegates(int a, int b);
    public delegate string GetNameDelegates(string name);
    public delegate void GetAreaDelegates(double a, double b);
    public delegate void GetPerimeterDelegates(double a, double b);
    public delegate double GetArea2Delegates(double a, double b);
    public delegate double GetPerimeter2Delegates(double a, double b);
    public delegate string GetName2Delegates(string name);
    public delegate double Calaculate1Delegates(int a, float b,double c);
    public delegate void Calaculate2Delegates(int a, float b, double c);
    public delegate bool checkLengthDelegates(string name);

    public class Animal
    {
        public void Eat()
        {
            Console.WriteLine("Animal is eating...");
        }

        public void Sleep()
        {
            Console.WriteLine("Animal is sleeping...");
        }

        public Animal(int i) 
        {
            Console.WriteLine("Parents class constructor called from child class instance: " + i);
        }
    }

    public class Dog : Animal
    {
        public void Bark()
        {
            Console.WriteLine("Dog is barking...");
        }

        public Dog() : base(10)
        {
            Console.WriteLine("Child class constructor called from child class instance");
        }
    }


    // example
    public class Person
    {
        public int id;
        public string Name, Address, Phone;
    }

    public class Staff: Person
    {
        public double Salary;
        public string Designation, Qualification;
    }


    public class Student: Person
    {
        public double Fees, Marks;
        public char Garde;
        public string Class;
    }

    public class TeachinStaff : Staff
    {
        public string Designation, Subject;
    }

    public class NonTeachinStaff : Staff
    {
        public string  DeptName, RptManager;
    }

    // Polymorphism 
    public class EmplPol
    {
        public virtual void PrintEmpPolMtd() // Overidable
        {
            Console.WriteLine("EmplPol");
        }
        public EmplPol() 
        {
            Console.WriteLine("EmplPol Constrcutor");
        }
    }

    public class Tempemp : EmplPol
    {
        public override void PrintEmpPolMtd()
        {
            Console.WriteLine("Tempemp"); // overidding
        }
    }

    // Method Hiding
    public class ParentClass
    {
        public void PrintInfo()
        {
            Console.WriteLine("ParentClass"); // 
        }
    }

    public class ChildClass : ParentClass
    {
        public  new void PrintInfo()
        {
            Console.WriteLine("ChildClass"); // Method Hiding
        }

        // -- using base keywords also we can call parent class
        public void ParentMethodCallfromChild()

        {
            base.PrintInfo();
        }
    }



    // ************ Operator Overloading *************


    public class Complex
    {
        public int Real { get; set; }
        public int Imaginary { get; set; }

        public Complex(int real, int imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);
        }

        public override string ToString()
        {
                return $"{Real} + {Imaginary}i";
        }


    }

    public class Matrix
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        public int D { get; set; }

        public Matrix(int a, int b, int c, int d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }

        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            return new Matrix
                (
                m1.A + m2.A, 
                m1.B + m2.B,
                m1.C + m2.C ,
                m1.D + m2.D
                );
        }

        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            return new Matrix
                (
                m1.A - m2.A,
                m1.B - m2.B,
                m1.C - m2.C,
                m1.D - m2.D
                );
        }

        public override string ToString()
        {
            return $"{A} {B} \n{C} {D}";
        }

    }


    // Abstract 
    public abstract class Figure
    {
        public double Width, Height, Radius;
        public const float PI = 3.14F;
        public abstract double GetArea(); // if abstract method declare in parent it is mandary to use it in child class
        // declare the abstract ethod in parent class then go to impement in child class
    
    
    }

    public class Rectangle:Figure
    {
        public Rectangle(double w, double h)
        {
            Width = w;
            Height = h;
        }

        public override double GetArea() // implement teh abstract class by overriding it from parent class
        {
            return Width * Height;
        }
    }

    public class Cone : Figure
    {
        public Cone(double w, double h, double r)
        {
            Width = w;
            Height = h;
            Radius = r;
        }

        public override double GetArea()
        {
            return PI * Radius * (Radius + Math.Sqrt(Height * Height + Radius * Radius));
        }
    }

    public class Circle : Figure
    {

        public Circle(double w, double h, double r)
        {
            Width = w;
            Height = h;
            Radius = r;
        }

        public override double GetArea()
        {
            return PI * Radius * Radius;
        }
    }

      // **************** Interfaces  **************

    public interface IDemo
    {
        void Add(double x, double y);
    }

    public interface IDemo2
    {
        void Info(double x, double y);
    }

    public interface IDemo1 : IDemo, IDemo2
    {
        void Subtract(double x, double y);
        void Info(double x, double y);
    }

    public class SubDemo : IDemo1
    {
        public void Add(double x, double y)
        {
            Console.WriteLine($"Add:  {x + y}");
        }

        public void Subtract(double x, double y)
        {
            Console.WriteLine($"Subtract:  {x - y}");
        }

         void IDemo1.Info(double x, double y)
        {
            Console.WriteLine($"Info for Demo1:  {x * y}");
        }

         void IDemo2.Info(double x, double y)
        {
            Console.WriteLine($"Info for Demo2:  {x * y}");
        }
    }


    // Structures

    public struct DemoStructures
    {
        public int x;

        public DemoStructures(int value)
        {
            x = value;
        }

        public void ShowDetails()
        {
            Console.WriteLine("Demo Structures " + x);
        }
    }


    // Enumeration/Enum

    public enum WeekDays
    {
        Sunday =1,
        Monday,
        Tuesday,
        Wednesday, 
        Thursday,
        Friday,
        Saturday
    }




    // Properties
    public class Circle2
    {
        private double _Radius = 12.5;
        private double _Height = 1.5;

        public double Radius
        {
            get
            {
                return _Radius; // Represents a value returning method without parameter
            }

            set
            {
                if(value > _Radius)
                {
                    _Radius = value; // Represents a non-value returning method with parameter
                }
            }
        }

        public double Height
        {
            get
            {
                return _Height;
            }

            set
            {
                _Height = value;
            }
        }
    }


    public enum Cities
    {
        Mumbai , 
        Pune ,   
        Surat ,   
        Delhi,
        Punjab,
        UP
    }


    public enum States
    {
        Maharashtra,
        Karnataka,
        Bihar,
        Gujarat,
        Kerala,
        Jharkhand
    }


    public class CustomerBank
    {
        int _cust_id;
        bool _status;
        string _cus_name;
        double _salary;
        Cities _city;
        States _state;
        public string _Country { get; set; }


        public CustomerBank(int cust_id,
        bool status,
        string cus_name,
        double salary,
        Cities city,
        States state,
            string Country
         )
        {
            this._cust_id = cust_id;
            this._status = status;
            this._cus_name = cus_name;
            this._salary = salary;
            this._city = city;
            this._state = state;
            this._Country = Country;
            

        }


        public int CustID
        {
            get { return _cust_id; }
            set { _cust_id = value; }
        }

        public bool Status
        {
            get { return _status; }
            set { _status = value; }
        }
        public string CusName
        {
            get { return _cus_name; }

            set {
            if(_status == true)
                _cus_name = value; 
                
            }
        }

        public double Salary
        {
            get { return _salary; }
            set {
                if (_status == true)
                    if(value > 5000)
                        _salary = value; 
            }
        }

        public Cities City
        {
            get { return _city; }

            set
            {
                if (_status == true)
                    if (value == Cities.Pune || value == Cities.Delhi || value == Cities.UP || value == Cities.Surat || value == Cities.Mumbai || value== Cities.Punjab)
                        _city = value;
            }
        }

        public States State
        {
            get { return _state; }

            set
            {
                if (_status == true)
                    if (value == States.Kerala || value == States.Gujarat || value == States.Maharashtra || value == States.Bihar || value == States.Karnataka || value == States.Jharkhand)
                        _state = value;
            }
        }

    }



    //  Indexers

    public class EmployeeIndexers
    {
        int _EmpId;
        double _Salary;
        string _EmpName, _Job, _DeptName, _DeptLoc;

        public EmployeeIndexers(int EmpId, double Salary, string EmpName, string Job, string deptname, string deptloc)
        {
            this._EmpId = EmpId;
            this._Salary = Salary;
            this._EmpName = EmpName;
            this._Job = Job;
            this._DeptName = deptname;
            this._DeptLoc = deptloc;
        }


        public object this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return _EmpId;
                    case 1: return _Salary;
                    case 2: return _EmpName;
                    case 3: return _Job;
                    case 4: return _DeptName;
                    case 5: return _DeptLoc;
                    default: throw new IndexOutOfRangeException("Invalid index");
                }
            }
            set
            {
                switch (index)
                {
                    case 0: _EmpId = Convert.ToInt32(value); break;
                    case 1: _Salary = Convert.ToDouble(value); break;
                    case 2: _EmpName = value as string; break;
                    case 3: _Job = value as string; break;
                    case 4: _DeptName = value as string; break;
                    case 5: _DeptLoc = value as string; break;
                    default: throw new IndexOutOfRangeException("Invalid index");
                }
            }


        }

        public object this[string name]
        {
            get
            {
                switch (name)
                {
                    case "_EmpId" : return _EmpId;
                    case "_Salary" : return _Salary;
                    case "_EmpName": return _EmpName;
                    case "_Job": return _Job;
                    case "_DeptName": return _DeptName;
                    case "_DeptLoc": return _DeptLoc;
                    default: throw new IndexOutOfRangeException("Invalid index");
                }
            }
            set
            {
                switch (name)
                {
                    case "_EmpId": _EmpId = Convert.ToInt32(value); break;
                    case "_Salary": _Salary = Convert.ToDouble(value); break;
                    case "_EmpName": _EmpName = value as string; break;
                    case "_Job": _Job = value as string; break;
                    case "_DeptName": _DeptName = value as string; break;
                    case "_DeptLoc": _DeptLoc = value as string; break;
                    default: throw new IndexOutOfRangeException("Invalid index");
                }
            }


        }


    }


    //  Extension Methods

    public class ExtensionsMethdod1
    {
        // Extension Methods
        public void ExtensionMethod1()
        {
            Console.WriteLine("Extension Methods 1");
        }

        public void ExtensionMethod2()
        {
            Console.WriteLine("Extension Methods 2");
        }

        public void ExtensionMethod3()
        {
            Console.WriteLine("Extension Methods 3");
        }

        public void ExtensionMethod4()
        {
            Console.WriteLine("Extension Methods 4");
        }
    }


    static class ExtensionsMethdod2 
    {
        // binding this with above class
        public static void ExtensionMethod5( this ExtensionsMethdod1 emtd)
        {
            Console.WriteLine("Extension Methods static 5");
        }

        public static long Factorial(this Int32 x)
        {
            if (x == 1) return 1;
            if(x == 2) return 2;

            return x * Factorial(x - 1);
        }

        public static string ToProper(this String old)
        {
            string NewStr = null;

            if(old.Trim().Length > 0)
            {
                old = old.ToLower();
                string[] sStr = old.Split(' ');

                foreach(string s in sStr)
                {
                    char[] ch =s.ToCharArray();
                    if (ch.Length > 0)
                        ch[0] = Char.ToUpper(ch[0]);

                    if(NewStr == null)
                    {
                    NewStr = new string(ch);
                    }
                    else
                    {
                        NewStr += " "+ new string(ch);
                    }
                }
                return NewStr;
            }
            else
            {
                return old;
            }
        }
    }



    internal class InheritanceLecs
    {
        // ************ Method Overloading ***********
        public static void TestMethod()
        {
            Console.WriteLine("TestMethod with no parameters called.");
        }

        public static void TestMethod(int x)
        {
            Console.WriteLine("TestMethod with int parameter called: " + x);
        }

        public static void TestMethod(string x)
        {
            Console.WriteLine("TestMethod with string parameter called: " + x);
        }

        public static void TestMethod(string x, int y)
        {
            Console.WriteLine("TestMethod with int & string parameter called: " + x + " " + y);
        }

        public static void TestMethod(int x, string y)
        {
            Console.WriteLine("TestMethod with string & int parameter called: " + x + " " + y);
        }


        // ************ Operator Overloading in C# *************
        //public static int operator +(int a, int b)
        //{
        //    return a + b;
        //}

        //public static int operator -(int a, int b)
        //{
        //    return a - b;
        //}

        //public static bool operator >(int a, int b)
        //{
        //    return a > b;
        //}

        //public static string operator +(string a, string b)
        //{
        //    return a + " " + b;
        //}

        //public static bool operator ==(string a, string b)
        //{
        //    return a == b;
        //}


        // enum
        //public static WeekDays MeetingDate
        //{
        //    get; set;
        //} = (WeekDays)6; // by default value 0 if indx is not customize but if the indx is customize then we need to specific to change/trycaste it to (Weekday) 


        //public static WeekDays MeetingDate1
        //{
        //    get; set;
        //} = WeekDays.Wednesday; // by default value 0 if indx is not customize but if the indx is customize then we need to specific to change/trycaste it to (Weekday) 



        // Delegates 
        public void AddNums(int a, int b)
        {
            Console.WriteLine($"{a} {b}: {a+b}");
        }

        public static string GetName(string name)
        {
            return "Hello, " + name;
        }

        public void GetArea(double width, double height)
        {
            Console.WriteLine("Area: " + width * height);
        }

        public void GetPerimeter(double width, double height)
        {
            Console.WriteLine("Perimeter: " + 2* (width * height));
        }

        public double GetArea2(double width, double height)
        {
            return width * height;
        }

        public double GetPerimeter2(double width, double height)
        {
            return 2 * (width * height);
        }

        // Anonymous Methods
        public static string GetNameAno(string name)
        {
            return "Hello " + name + " , good morning!";
        }


        // Func, Action and Predicate Delegates

        public static double Calaculate1(int x,float y, double z)
        {
            return x + y + z;
        }

        public static void Calaculate2(int x, float y, double z)
        {
            Console.WriteLine("Calaculate2: " + x+y+z);
        }

        public static bool checkLength(string name)
        {
            if(name.Length > 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


       


        static void Main(string[] args)
        {
            //Console.WriteLine("Inheritance");
            // Inheritance --> mechanism of consuming the members of one class in another class by establishing parent/child relationship between the classes.
            // types of Inheritance
            // - Single --> class1 -> class2

            // - Multi-level --> class1 -> class2 -> class3

            // - Hierarchical -->  class1 -> class2
            //                            -> class3
            // 
            // - Hybrid -->  class1 -> class2 -> class4
            //                      -> class3 -> 

            // - Multiple -> class1 + class2 -> class3

            // In this, child class can consume members of its parents class as if it the owner of those members(except private members of parents)
            // -- Parent constructor must be accessible to child class otherwise Inheritance is not possible
            // -- In this, child class can accessed parent class members but parent class can never access any members of child class that is purely defined under child class
            // -- we can initialize parent classes variable by using the child instance to make it as a reference.
            // -- Every class that is defined by us or pre-defined in the libraries of the language ahs a default parent class i.e object class of system namespace
            //    that is ToString,Equals,GetType,GetHashCode
            // -- In C#, we don't have support for Multiple Inheritance through classess
            // --  In the first point we learnt when ever child class instance is created, child class constructor will implicitly call its parent classes constructor but only if the constructor is parameter less, where as if the constructor of parent class is parameterized,
            //     child class constructor can't implicitly call it's parent's constructor, so to overcome the problem it is the responsibility of the programmer to explicitly call parent classes constructor from child class constructor and pass values to those parameters. To call parent's
            //     constructor from child class we need to use the "base" keyword.

            // Fn+f11 --->to see step by step implemetation in vs studio

            //Dog d = new Dog();
            //d.Eat();
            //d.Sleep();
            //d.Bark();

            //Animal al; // variable od parent class
            //Dog d = new Dog(); // Instance of child class
            //al = d; // Reference of a child class to parent class
            //al.Bark(); // still can't parent class can't access child class methods

            //Object obj = new Object();
            //obj.ToString();
            //obj.Equals(obj);
            //obj.GetHashCode();
            //obj.GetType();


            // ************ Method Overloading ***********

            //TestMethod();                          // No parameters
            //TestMethod(10);                        // int
            //TestMethod("Hello");                   // string
            //TestMethod("Test", 100);               // string, int
            //TestMethod(200, "World");              // int, string


            // Polymorphism 
            // ************ Method OverRidding ***********
            // Its an approach of re-implementing a parents classes method under the child class with the same signature.
            // this can be performed only between parent child class and never be performed with in the same


            // if we want to override a parent's method under the child class first that method should be declared by using the virtual modifier in parents class
            // any virtaul metod of the parents class can be overridden by the child if required by using the override modifier
            // Overridding is all about changing the behaviour of parent method under child  class

            //Tempemp tc = new Tempemp();
            //tc.PrintEmpPolMtd();        // Tempemp without keywords

            //EmplPol et = new Tempemp();
            //et.PrintEmpPolMtd();  // EmplPol → base version is called, not child

            //### **Overloading:**

            //1.In this case we define multiple methods with the same name by changing their parameters.
            //2.This can be performed either within a class as well as between parent child classes also.
            //3. While overloading a parent class's method under the child class, child class doesn't require to take any permission from the parent class.
            //4. Overloading is all about defining multiple behaviours to a method.

            //### **Overriding:**

            //1. In this case we define multiple methods with the same name and same parameters.
            //2. This can be performed only between parent child classes, can never be performed within the same class.
            //3. While overriding a parent's method under child class, child class requires a permission from its parent.
            //4. Overriding is all about changing the behaviour of a method under child class.



            // ************ Method Hiding ***********
            // Its an approach ot re-implementing a parent classes method under the child class exactly with the same name and signature

            //  -- diff method overriding and hiding
            // In overriding case the child class re-implements its parent class methods which are declared as virtual, where as in hiding cae child case can re-implements any parent's method even if method is not delcare as virtual
            //  we can re-implement a praents classes method uner child class using 2 approaches:
            // 1 Method Hiding
            // 2 Method Overriding

            // After re-implementing parent classes methods under child classes  teh child class instances will start calling teh local methods only taht is teh re-implements methods, but if required in any case we can also call teh parent classes methods from child classes by using 2 approaches
            // -- direct creating insatnce of parent class
            // -- using base keywords in methods/non static methods also we can call parent class from child class , but keywords like this and "base" can't used from static blocks
            // -- A parent class refernce even if created by using the child class instance can't access any member that are purely defined under teh child class but can call
            // overridden as pure child class members, but members which are re-implemented by using the approach of hiding are considered as pure child class members and not accessaible
            // to parent's refernces.

            //ChildClass cd = new ChildClass();
            //cd.PrintInfo(); // childclass

            //// -- direct creating insatnce of parent class
            //ParentClass parent = new ChildClass();
            //parent.PrintInfo(); // Parentclass without "new" keyword

            //ChildClass cd1 = new ChildClass();
            //cd1.PrintInfo(); // childclass with  "new" keyword

            //// -- using base keywords also we can call parent class
            //cd1.ParentMethodCallfromChild(); // Parentclass


            // ************ Operator Overloading *************
            // It's an approach of defining multiple behaviours to an operator and those behvaiour will vary based on the operand types between he opaertors
            // "+" is an addititon operator when used between 2 nmeric operands
            // // but conacatenation opertaor when used between 2 string

            //string str = "hello how are you?";
            //Console.WriteLine(str.Substring(5)); // staring from 5 to last
            //Console.WriteLine(str.Substring(7)); // staring from 5 to   last         
            //Console.WriteLine(str.Substring(7,5)); // staring from 5 to no.of character u want       

            //Complex num1 = new Complex(4, 5);
            //Complex num2 = new Complex(3, 8);
            //Complex Res = num1 + num2;
            //Console.WriteLine("Result: " + Res);

            //Matrix m1 = new Matrix(1, 2, 3, 4);
            //Matrix m2 = new Matrix(7,8,6,5);
            //Matrix m3 = new Matrix(17, 28, 46, 75);

            //Matrix Ans = m1 + m2 +m3;
            //Console.WriteLine("Result: ");
            //Console.WriteLine( Ans);

            //Matrix Ans1 = m1 - m2;
            //Console.WriteLine("Result1: ");
            //Console.WriteLine(Ans1);

            // *************** Abstract Classes ************
            // A methods without any method body is called abstract method, what the method contains is only declaration of the method
            // It's concept is near to method overriding but incase of overriding child class can override the methods of parent class but in abstarct it is compluasry to override the parent class ethod with implememtaion
            // Abstract Class:
            // -- Abstract Methods
            // -- Non-Abstract Methods

            // Child Class of Abstract Class:
            // -- Implement each and every Abstract Methods of parent class
            //    then only we can consume Non-Abstract Methods


            // ************ Working with Abstract class and method *********
            // Abstract Method --> A method without any method body is known as abstract method
            // A Class which contains any Abstract members in it is known as abstract class


            //Rectangle rec = new Rectangle(4.5, 7);
            //Console.WriteLine($" Area of Rectangle: {rec.GetArea()}");

            //Cone c = new Cone(6,8,9.9);
            //Console.WriteLine($" Area of Rectangle: {c.GetArea()}");

            //Circle cl = new Circle(3,5.5, 7.8);
            //Console.WriteLine($" Area of Rectangle: {cl.GetArea()}");



            // **************** Interfaces  **************
            // It's user defined data type

            // CLASS --> Non-Abstract Methods(Methods with method body)
            // ABSTRACT CLASS -->  Non-Abstract Methods(Methods with method body) and also Abstract Methods(Methods with out method body)
            // Interfaces --> Contains only Abstract Methods (Methods without method body)
            // Every Abstract method of an interface should be implemented by the child class of the interface with out fail.
            // Generally a class inherits from another class to consume the members of its parent, whereas if class is inheriting from an interface it is to implement the members of its a parents.
            // A class can inherit from a class and interface at a time.
            // Default scope the members of a interface in public whereas private in class
            // We can't declare any fields/variable under an interface.
            // If Required an interface can inherit from another interface
            // Every member of an interface should be implemented under the child class of the interface without fail, but while implementing we don't require to use override modifier just like we have done in case of abstract class.
            //  but we can create reference of an interface not instance
            // Multiple inheritance is supported by interface but not in class due to ambiuigty
            // class inherit to consume teh methods/call, changing behaviour but interface not consume it implemented to solve ambiguity

            //SubDemo sbdm = new SubDemo();
            //sbdm.Add(3.4, 7.8);
            //sbdm.Subtract(13.4, 7.8);

            //IDemo1 demo1 = new SubDemo();
            //demo1.Subtract(3.7, 7.7);
            //demo1.Add(67.7, 17.7);
            //demo1.Info(67.7, 17.7);

            //IDemo2 demo2 = new SubDemo();
            //demo2.Info(67.7, 17.7);





            // *********** Structures ****************
            // Structures is user-defined type.
            // In this, most of the member what a class can contains like,fields, methods, constrcutors, properties, Indexers, Operator Methods etc

            // Structures is value type whereas class is references type
            // Memory Allocation for Structures is stack whereas for class is Heap
            // Structures u have only implicit parameterless constructor by complier u can't write ur own parameterless cons only with parameters can be defined
            // Structures can't defined destrcutors
            // Structures can declared field only instance type in declaration and assign value using instanace of object
            // In Class f we defined 0 cons then there will be one cons implicit one and if we defined "n" expicit cons there will be "n" expicit cons the default impiclit will be removed then we decalare teh exp cons
            // whereas in Structures if we define 0 cons there will be 1 implicit cons and if we defined "n" cons then there will "n+1" cons
            // class can be inherited by other classes by struct can't be inherit by other structs only by class
            // class and struct can implement Interfaces

            //DemoStructures DmStruct = new DemoStructures();
            //DmStruct.x = 56;
            //DmStruct.ShowDetails();



            // ************ Enumeration  ***************
            // Set of named constants values
            // it's better to define an Enum directly under the namespace, but it is also possible to define a Enum under a class or Structures also

            //Console.BackgroundColor = ConsoleColor.Yellow;
            //Console.WriteLine("Hello Color Enum");

            //WeekDays wkdys = WeekDays.Sunday;
            //Console.WriteLine(WeekDays.Sunday);

            //Console.WriteLine("WeekDays GetValues");
            //foreach (int wkdy in Enum.GetValues(typeof(WeekDays)))
            //{
            //    Console.WriteLine(wkdy);
            //}

            //Console.WriteLine("\n WeekDays GetNames");
            //foreach (string wkdy in Enum.GetNames(typeof(WeekDays)))
            //{
            //    Console.WriteLine(wkdy);
            //}

            //Console.WriteLine("MeetingDate: " + MeetingDate);
            //MeetingDate = WeekDays.Friday;
            //Console.WriteLine("MeetingDate after: " + MeetingDate);
            //Console.WriteLine("MeetingDate1: " + MeetingDate1);





            // ************* Properties  *****************
            // Properties is a member of class using which we can expose values associated with a class to the outside environment.
            //Circle2 c2 = new Circle2();
            //c2.Height = 34.5;
            //c2.Radius = 5.5;

            //CustomerBank CusBnk = new CustomerBank(101, true, "Neha Singh", 23000.0, Cities.Surat, States.Kerala , "India");
            //Console.WriteLine("CusBnk.CustID: " + CusBnk.CustID);

            //Console.WriteLine("CusBnk.CusName: " + CusBnk.CusName);
            //CusBnk.CusName = "Piyush Goyal";
            //Console.WriteLine("CusBnk.CusName: " + CusBnk.CusName);

            //Console.WriteLine("CusBnk.Salary: " + CusBnk.Salary);
            //CusBnk.Salary += 1000;
            //Console.WriteLine("CusBnk.Salary: " + CusBnk.Salary);
            //CusBnk.Salary -= 10000;
            //Console.WriteLine("CusBnk.Salary: " + CusBnk.Salary);

            //Console.WriteLine("CusBnk.city: " + CusBnk.City);
            //CusBnk.City = Cities.Punjab;
            //Console.WriteLine("CusBnk.city: " + CusBnk.City);

            //Console.WriteLine("CusBnk.State: " + CusBnk.State);
            //CusBnk.State = States.Maharashtra;
            //Console.WriteLine("CusBnk.State: " + CusBnk.State);

            //Console.WriteLine("CusBnk.State: " + CusBnk._Country);
            //CusBnk._Country = "UK";
            //Console.WriteLine("CusBnk.State: " + CusBnk._Country);




            // Indexers 
            // is member of class and if u define indexers in a class ur class start to behaviour like an virtual array

            EmployeeIndexers EmpIdx = new EmployeeIndexers(1001, 50000.0, "Neha Singh", "SDE", "IT", "Mumbai");
            //Console.WriteLine("Id: "  + EmpIdx[0]);
            //Console.WriteLine("Salary: " + EmpIdx[1]);
            //Console.WriteLine("EmpName: " + EmpIdx[2]);
            //Console.WriteLine("Job: " + EmpIdx[3]);
            //Console.WriteLine("DeptName: " + EmpIdx[4]);
            //Console.WriteLine("DeptLoc: " + EmpIdx[5]);

            //EmpIdx[1] = 600000.0;
            //EmpIdx[3] = "Sr. SDE";
            //EmpIdx[4] = "IT and Support";
            //EmpIdx[5] = "Pune";

            //Console.WriteLine("Salary: " + EmpIdx[1]);
            //Console.WriteLine("Job: " + EmpIdx[3]);
            //Console.WriteLine("DeptName: " + EmpIdx[4]);
            //Console.WriteLine("DeptLoc: " + EmpIdx[5]);

            //Console.WriteLine("\n");

            //EmpIdx["_Salary"] = 230000.0;
            //EmpIdx["_Job"] = "Sales Head";
            //EmpIdx["_DeptName"] = "Sales";
            //EmpIdx["DeptLoc"] = "New Delhi";

            //Console.WriteLine("Salary s: " + EmpIdx["_Salary"]);
            //Console.WriteLine("Job s: " + EmpIdx["_Job"]);
            //Console.WriteLine("DeptName s: " + EmpIdx["_DeptName"]);
            //Console.WriteLine("DeptLoc s: " + EmpIdx["DeptLoc"]);




            // ************ Delegates ***************** 
            // It's a type safe function pointer.
            // A delegate holds the reference of a method and then calls the method for execution.
            // 

            //InheritanceLecs I = new InheritanceLecs();
            //I.AddNums(5, 9);

            //string str = "Mansi Patel";
            //string ans = GetName(str);
            //Console.WriteLine(ans);

            //AddNumsDelegates add = new AddNumsDelegates(I.AddNums);
            //GetNameDelegates anonamename = new GetNameDelegates(GetName);

            //add(2, 78);
            //string ans = name("Pinky");
            //Console.WriteLine(ans);

            // Multicast Delegates
            //I.GetArea(4.6, 17.8);
            //I.GetPerimeter(64.6, 78.8);

            //GetAreaDelegates gad = new GetAreaDelegates(I.GetArea); 
            //gad += I.GetPerimeter;
            //gad(23.67, 89.6);

            //// for return type only last outpt will be shown 
            //GetArea2Delegates gad2 = new GetArea2Delegates(I.GetArea2); 
            //gad2 += I.GetPerimeter2;
            //double ans = gad2(23.67, 89.6);
            //Console.WriteLine(ans);

            // ********** Anonymous Methods in Delegates ********
            // U can bind code block to the delegate laong iwth function name

            //GetName2Delegates getname = new GetName2Delegates(GetNameAno);
            //string ans1 = getname("Sam Root");
            //Console.WriteLine(ans1);

            //GetName2Delegates getname2 = delegate(string anoname)
            //{
            //   return anoname + " Anonymous Methods!"; 
            //};

            //string str = getname2("Scott");
            //Console.WriteLine(str);


            // ************ Lambda Expressions ***********


            //GetName2Delegates getname3 = (lmdname) =>
            //{
            //    return lmdname + ", Good Afternoon";
            //};

            //string str = getname3("Scott");
            //Console.WriteLine(str);



            // **************** Generic Delegates --> Func, Action and Predicate ***********
            // Func --> used for value returining method
            // Action --> when method is void
            // Predicate --> when return is boolean

            //Calaculate1Delegates cal1Del = Calaculate1;
            //double ans = cal1Del(4, 76.7F, 8.90);
            //Console.WriteLine(ans);

            //Calaculate2Delegates cal2Del = Calaculate2;
            //cal2Del(4, 76.7F, 8.90);

            //checkLengthDelegates chklen = checkLength;
            //bool ans1 = chklen("Piyush");
            //Console.WriteLine(ans1);

            //Func<int, float, double, double> mtd1 = (x,y,z) =>   x + y + z; 
            //double ans = mtd1(4, 76.7F, 8.90);
            //Console.WriteLine(ans);

            //Action< int, float, double> mtd2 = (x, y, z) => Console.WriteLine("Add: " + (x + y + z));
            //mtd2(12, 56.7F, 2345.789);

            //Predicate<string> mtd3 = (name) =>
            //{
            //    if (name.Length > 5)
            //        return true;

            //    return false;
            //};

            //bool  ans1 = mtd3("technologies");
            //Console.WriteLine(ans1);




            // *********** Extension Methods ***************
            // It's mechanism of adding new methods into an existing class or structure also with out modifying the source code fo the type and this process
            // we don't require any permissions from original type and the original type doesn't require any re-compilation.
            // EM are define as static but once they are bound with nay class or strcut they turn into non-static
            // when EM define with same name and signature of an existing method in the class, them EM will not be called and the prefenece always goto the original method only.
            // the first parameter of an extension methd should be the name of the type to which that method has to be bound with and this paramter isnot taken into considertaion while clalign thhe externsion method,
            // An existing method should have onr and only one binding parameter adn it should be in the first place of parameter list.
            // If an extension method is defined with "n"parameter then while calling it there will be n-1 parameters only bcoz the binding parameter is excluded.

            //ExtensionsMethdod1 em1 = new ExtensionsMethdod1();
            //em1.ExtensionMethod1();
            //em1.ExtensionMethod2();
            //em1.ExtensionMethod3();
            //em1.ExtensionMethod4();
            //em1.ExtensionMethod5(); // Extension method

            //int fact = 8;
            //long ans = fact.Factorial();
            //Console.WriteLine(ans);

            //// with sealed class
            //string str = "hELlo HoW Are YoU? ";
            //str = str.ToProper();
            //Console.WriteLine(str);


            // ********************** Differences between String and StringBuilder ******************
            // strings are immutable
            // StringBuilder are imutable


            //string str = "Neha ";
            //str += "Singh!";
            //Console.WriteLine (str);

            //StringBuilder sb = new StringBuilder("Hello ");
            //sb.Append(str);
            //Console.WriteLine(sb);

            Stopwatch stp = new Stopwatch();
            stp.Start();
            string s = "";
            Console.WriteLine(" \n ************* s *************");
            for (int i = 1; i< 10000; i++)
            {
                s += i;
                //Console.Write(s + " ");
            }

            stp.Stop();
            Console.WriteLine(" \n");
            Console.WriteLine("stopwatch for s: " + stp.ElapsedMilliseconds);


            Stopwatch stp1 = new Stopwatch();
            stp1.Start();
            StringBuilder sb1 = new StringBuilder(10000);

            Console.WriteLine(" \n ************* sb1 *************");

            for (int i = 1; i < 10000; i++)
            {
                sb1.Append(i);
                //Console.Write(sb1 + " ");
            }
            stp1.Stop();

            Console.WriteLine(" \n");

           Console.WriteLine("stopwatch for sb1: " + stp1.ElapsedMilliseconds);









        }
    }
}