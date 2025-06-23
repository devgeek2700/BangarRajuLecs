using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BangarRajuLecs
{
    internal class Program
    {
        static  int x = 90;
        public int y = 4;
        static Program()
        {
            Console.WriteLine("Static Constructors");
        }

        //public Program(int x)
        //{
        //    this.y = x;
        //    Console.WriteLine("Non Static Constructors");
        //}

        public void pubAccessSpecifiers()
        {
            Console.WriteLine("Public Access Specifiers called"); ;
        }

        private void priAccessSpecifiers()
        {
            Console.WriteLine("private Access Specifiers called"); ;
        }

        internal void internalAccessSpecifiers()
        {
            Console.WriteLine("internal Access Specifiers called"); ;
        }

        protected  void protectedAccessSpecifiers()
        {
            Console.WriteLine("protected Access Specifiers called"); ;
        }

        protected internal void protectedinternalAccessSpecifiers()
        {
            Console.WriteLine("protected internal Access Specifiers called"); ;
        }

        private protected void privateprotectedAccessSpecifiers()
        {
            Console.WriteLine("private protected Access Specifiers called"); ;
        }

        int a = 49;
        static int b = 78;

        static void Main(string[] args)
        {

            //  Part 4 --> start lecs 6 video
            // ************ Static Constructors vs Non Static Constructor ***************
            // Static Constructors --> if constructor explicitly declared by using static modifier while rest are non static constructors
            // Non static Constructors are called as instance Constructors
            // Constructors--> used to initailize the fileds/varibale of class
            // static fields are initialized by staic constuctors and non static fileds are intiallized by non static constructors
            // static cons are implicitly called whereas non static are explicitly called 

            // static constructors executes immediately once the execution of a class starts and moreover it is first block of code to run under class
            // whereas non static cons executes only after creating the instances of class as well as each adn every time the instance of class is created.

            // even before the main method is called static constructors is called

            // start of execution to end of execution is called one lifecycle --> In the lifecycle of static constructors executes one and only one time whereas non static constructors  executes for zero time if no instances is created and 'n'
            // times if 'n' instances are created.

            // non static constructors can be parameterized but static constrcutors can't have ang parameters
            // bcoz there are implicitly called

            // non static constructors can be overloaded where static cons can't be overloaded --> bcox overloading comes t image bcoz of parameters then static cons can't have parameters.
            // Every class conatins an implicit cons if not defined explicitly and those implicit cons are defines based on the following criteria:
            // -- every class except a static class contains an implicit non static constructor if not defines with an explicit cons
            // -- static constructors are implicit defined only if that class conatians any static fields or else that constructors will not the present at all


            //Console.WriteLine("Main methods is called");
            //Program p = new Program(6);
            //Program p1 = new Program(9);

            //Console.WriteLine("Static value: "+x);
            //Console.WriteLine("non Static value: " + p.y);


            // ********** Differences between Variable Instance and Reference ********
            // class --> user defined type (kind off data type)
            // Variable of a class --> copy of the class that is not initialized
            // Instance of a class --> copy of the class that is initialized by using "new" keyword.
            // Reference of a class --> a copy of the class that is initialized by using an existing inastance and references of class will not have any memory alloaction they will be sharing the same memory of the instance that assigned for initailizing the varibale
            // Reference of a class can be called as a pointer to teh insatance and every modifictaion we perform on the members through refernces and vice versa.

            //Program p; // Variable of a class
            //p = new Program(6); // Instance of a class

            //Program p1 = p; // Reference of a class

            // ******************** Access Specifiers ****************
            // It's a special kind of modifiers using which we can define teh scope of a type and it's members
            // private --> Accessible only within the same class or struct.
            // internal --> Accessible within the same assembly (project), but not from another assembly.
            // protected --> Accessible within the same class and its derived (child) classes.
            // protected internal --> Accessible from the same assembly or any derived class (even if in a different assembly).
            // public --> Accessible from anywhere.
            // private protected --> Accessible within the same class or derived classes, but only within the same assembly.
            // class --> by default --> internal --> and only internal and public are allowed
            // Fields, Methods, Properties, etc/ class members --> by default --> private

            //Program p = new Program();
            //p.pubAccessSpecifiers();
            //p.privateprotectedAccessSpecifiers();
            //p.priAccessSpecifiers();
            //p.protectedinternalAccessSpecifiers();
            //p.internalAccessSpecifiers();
            //p.protectedAccessSpecifiers();


            // *************** Different kinds of Variables in a class ********************
            // Non-Static/Instance variables
            // static --> if a variable is expliciyly declared by using static modifier or within static block then those variables are static whereas rest all are non static variables.
            // Constants --> declare with "const" keyword we call it as a constant variable and these can't modified it --> bheviour of const var is similar to static allocated at the start of implememtaion
            // diff const and static var --> static var can be modified whereas const can't
            // ReadOnly -->   declare using "ReadOnly" keyword , can't modidfied after initatilzation. nt compluasary to initialize like "const" at time od declaration
            // ReadOnly behavior similar to non static vars, initialized only after creating the instance of class & once for each instance created
            // const is fixed valued for whole class
            // readonly is fixed value specific to an instance of class

            //Console.WriteLine("static var: "+b);
            //Program p = new Program();
            //Console.WriteLine("non-static var: " + p.a);

            //const float pi = 3.14F;
            //readonly bool flag;
            //flag = true;









        }
    }
}