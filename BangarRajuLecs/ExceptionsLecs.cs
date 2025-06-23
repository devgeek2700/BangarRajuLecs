using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BangarRajuLecs
{
    // Exceptions and Exception Handling
    // Custom Exceptions and Exception Handling

    public class DivideByOddException : ApplicationException
    {
        public override string Message
        {
            get
            {
                return "Attempted to divide by odd number.";
            }
        }
    }

    public class CustomerCollections
    {
        public int CustId { get; set; }
        public string CustName { get; set; }
        public double balance { get; set; }
    }

    // Collections  Generics

    public class OperationsCollectionsGen<T>
    {
        public void Muliple(T a, T b)
        {
            dynamic d1 = a;
            dynamic d2 = b;
            Console.WriteLine($"Muliple: {d1 * d2}");
        }

        public void Divide(T a, T b)
        {
            dynamic d1 = a;
            dynamic d2 = b;
            Console.WriteLine($"Divide: {d1 / d2}");
        }
    }



    // IComparable and IComparer

    public class ComparableGen : IComparable<ComparableGen>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Class { get; set; }
        public float Marks { get; set; }

        public int CompareTo(ComparableGen other)
        {
            if (this.Marks > other.Marks)
            {
                return 1;
            }
            else if (this.Marks < other.Marks)
            {
                return -1;
            }
            else
            {
                return 0;
            }

        }
    }

    //public class CompareDevierdclassId: IComparer<ComparableGen>
    //{
    //    public int Compare(ComparableGen x, ComparableGen y)
    //    {
    //        if (x.ID > y.ID && x.Marks > y.Marks)
    //        {
    //            return 1;
    //        }
    //        else if (x.ID < y.ID && x.Marks < y.Marks)
    //        {
    //            return -1;
    //        }
    //        else
    //        {
    //            return 0;
    //        }
    //    }
    //}

    public class CompareDevierdclassId : IComparer<ComparableGen>
    {
        public int Compare(ComparableGen x, ComparableGen y)
        {
            if (x.ID > y.ID)
            {
                return 1;
            }
            else if (x.ID < y.ID)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }

    //  IEnumerable Interface
    public class EmployeeColl
    {
        public int empId { get; set; }
        public string EmpName { get; set; }
        public string EmpJob { get; set; }

        public double Salary { get; set; }
    }

    // define my own class that works like a list
    public class Oragnization : IEnumerable
    {
        List<EmployeeColl> emplst = new List<EmployeeColl>();
        public void Add(EmployeeColl emp)
        {
            emplst.Add(emp);
        }

        //public IEnumerator GetEnumerator()
        //{
        //    return emplst.GetEnumerator();
        //}

        public int Count
        {
            get { return emplst.Count; }
        }

        public EmployeeColl this[int  idx]
        {
            get
            {
                return emplst[idx];
            }
        }
        public IEnumerator GetEnumerator()
        {
            return new OragnizationEnumerator(this);
        }
       
    }

    // Replace OragnizationEnumerator class with the correct IEnumerator implementation
    public class OragnizationEnumerator : IEnumerator
    {
        Oragnization orgcoll;
        int currentIdx;
        EmployeeColl currEmp;

        public OragnizationEnumerator(Oragnization org)
        {
            orgcoll = org;
            currentIdx = -1;
        }

        public object Current // is used to access the current data in list
        {
            get
            {
                if (currentIdx < 0 || currentIdx >= orgcoll.Count)
                    throw new InvalidOperationException();
                return currEmp;
            }
        }

        public bool MoveNext() // to move to next list data 
        {
            if (++currentIdx >= orgcoll.Count)
            {
                return false;
            }
            else
            {
                currEmp = orgcoll[currentIdx];
            }
            return true;
        }

        public void Reset()
        {
            currentIdx = -1;
            currEmp = null;
        }
    }


    // Language Integrated Query 
    public class EmployeeLinq
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public bool IsActive { get; set; }
    }

    internal class ExceptionsLecs
    {

        static void Test1()
        {
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine("Test1: " + i);
                if (i == 50)
                {
                    Console.WriteLine("Thread1 Sleep");
                    Thread.Sleep(5000);
                    Console.WriteLine("Thread1 Wake up");
                }
            }
        }

        static void Test2()
        {
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine("Test2: " + i);
                if (i == 67)
                {
                    Console.WriteLine("Thread2 Sleep");
                    Thread.Sleep(5000);
                    Console.WriteLine("Threa2 Wake up");
                }
            }
        }

        static void Test3()
        {
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine("Test3: " + i);

                if (i == 45)
                {
                    Console.WriteLine("Thread3 Sleep");
                    Thread.Sleep(5000);
                    Console.WriteLine("Thread3 Wake up");
                }
            }
        }

        static void Test4(object n1)
        {
            int n = Convert.ToInt32(n1);
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("Test4: " + i);

                if (i == 20)
                {
                    Console.WriteLine("Thread4 Sleep");
                    Thread.Sleep(5000);
                    Console.WriteLine("Thread4 Wake up");
                }
            }
        }

        public void Display()
        {
            lock (this) // make a thread to execute at a time
            {
                Console.Write("C# is an ");
                Thread.Sleep(5000);
                Console.WriteLine("Object Oriented Language ");
            }
        }

        static long count1, count2 = 0;
        public static void IncrementCount1()
        {
            while (true)
            {
                count1 += 1;
            }
        }

        public static void IncrementCount2()
        {
            while (true)
            {
                count2 += 1;
            }
        }

        public static void IncrementCount3()
        {
            long count = 0;
            for (long i = 0; i <= 10000000000; i++)
            {
                count++;
            }
            //Console.WriteLine("IncrementCount3: " + count);

        }

        public static void IncrementCount4()
        {
            long count = 0;
            for (long i = 0; i <= 10000000000; i++)
            {
                count++;
            }
            //Console.WriteLine("IncrementCount4: " + count);

        }


        public bool CompareGen(int a, int b)
        {
            if (a == b)
                return true;
            return false;
        }

        public bool CompareGen1(float a, float b)
        {
            if (a == b)
                return true;
            return false;
        }

        public bool CompareGen2<T>(T a, T b)
        {
            if (a.Equals(b))
                return true;
            return false;
        }

        public void Add<T>(T a, T b)
        {
            dynamic d1 = a;
            dynamic d2 = b;
            Console.WriteLine($"Add: {d1 + d2}");
        }

        public void Subtract<T>(T a, T b)
        {
            dynamic d1 = a;
            dynamic d2 = b;
            Console.WriteLine($"Subtract: {d1 - d2}");
        }


        // Comparison Delegate for Sorting Collections 
        public static int CompareNames(ComparableGen n1, ComparableGen n2)
        {
            return n1.Name.CompareTo(n2.Name);
        }
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello world");

            // ************ Exceptions and Exception Handling *********
            // Compile time Errors --> Prevent your code from being compiled
            // Run time Errors --> Occur after successful compilation, while the program is running
            // -- Wrong implementation of logic
            // -- Wrong input supplied
            // -- wrong resources


            // Exceptions -->logic for abnormal termination
            //  Contains a readonly property to display an error message which is deciscrbed as virtual "Message".
            // -- ApplicationException --> Developers will do
            // -- SystemException --> CLR will do 
            //               └── NullReferenceException
            //               └── ArithmeticException
            //               └── IndexOutOfRangeException


            // Exception Handling -->  Exception Handling in C# is a mechanism to gracefully handle runtime errors (like divide by zero, null reference, etc.) and prevent program crashes.

            //try
            //{
            //    Console.WriteLine("enter num1: ");
            //    int num1 = int.Parse(Console.ReadLine());

            //    Console.WriteLine("enter num2: ");
            //    int num2 = int.Parse(Console.ReadLine());

            //    double res = num1 / num2;
            //    Console.WriteLine("RES: " + res);
            //}
            //catch (DivideByZeroException e)
            //{
            //    Console.WriteLine("Can't Divide by ZERO!: " + e.Message);
            //}
            //catch (FormatException fe)
            //{
            //    Console.WriteLine("Invalid Format: " + fe.Message);
            //}
            //catch (Exception ex) 
            //{ 
            //    Console.WriteLine("Message: "+ ex.Message);
            //}finally
            //{
            //    Console.WriteLine("Completed Operation");
            //}

            // Application Exception
            //ApplicationException AppExp = new ApplicationException("<Error Msg>");
            //throw AppExp;

            ////or

            //throw new ApplicationException("<error msg>");


            //try
            //{
            //    Console.WriteLine("enter num1: ");
            //    int num1 = int.Parse(Console.ReadLine());

            //    Console.WriteLine("enter num2: ");
            //    int num2 = int.Parse(Console.ReadLine());

            //    if(num2 % 2 > 0)
            //    {
            //        //throw new ApplicationException("Only Even numbers on num2");
            //        throw new DivideByOddException();
            //    }
            //    double res = num1 / num2;
            //    Console.WriteLine("RES: " + res);
            //}
            //catch (DivideByZeroException e)
            //{
            //    Console.WriteLine("Can't Divide by ZERO!: " + e.Message);
            //}
            //catch (FormatException fe)
            //{
            //    Console.WriteLine("Invalid Format: " + fe.Message);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Message: " + ex.Message);
            //}
            //finally
            //{
            //    Console.WriteLine("Completed Operation");
            //}





            // ************ Multithreading ******************
            // Every application by default contains one thread to execute the program and that is known as Main Thread.

            //Thread t1 = Thread.CurrentThread;
            //t1.Name = "Main thread";
            //Console.WriteLine("Current thread: " + Thread.CurrentThread.Name);

            // single threaded
            //Test1();
            //Test2();
            //Test3();

            // Multi threaded
            //Thread t1 = new Thread(Test1);
            //Thread t2 = new Thread(Test2);
            //Thread t3 = new Thread(Test3);
            //t1.Start();
            //t2.Start();
            //t3.Start();

            // ThreadStart is a delegate -->  used when creating a new thread with the Thread class.
            // diff ThreadStart vs Thread --> exactly same
            // When function is pass in Thread the system implicitly ThreadStart call the delegate here

            //ThreadStart threadStart = new ThreadStart(Test3);
            //Thread t4 = new Thread(threadStart);
            //or
            //ThreadStart threadStart1 = Test2;
            //Thread t4 = new Thread(threadStart1);
            // or
            //ThreadStart threadStart1 = delegate { Test1(); };
            //Thread t4 = new Thread(threadStart1);
            // or
            //ThreadStart threadStart1 = () => Test1();
            //Thread t4 = new Thread(threadStart1);
            //t4.Start();
            // or
            //ParameterizedThreadStart parathreadStart1 = new ParameterizedThreadStart(Test4);
            //Thread t4 = new Thread(parathreadStart1);
            //t4.Start(40);

            //Console.WriteLine("Main thread started.");
            //Thread t1 = new Thread(Test1);
            //Thread t2 = new Thread(Test2);
            //Thread t3 = new Thread(Test3);
            //Thread t4 = new Thread(Test4);

            //t1.Start();
            //t2.Start();
            //t3.Start();
            //t4.Start();

            //t1.Join();
            //t2.Join(); // Main thread is calling the join main thread is not allow to exit the program until all programs are exited
            //t3.Join();
            //t4.Join();

            //Console.WriteLine("Main thread stopped.");


            // Thread Locking --> Thread locking is a mechanism used in multithreaded applications to prevent multiple threads from accessing the same resource (like variables, files, or memory) at the same time, which can cause race conditions and unpredictable behavior.

            //ExceptionsLecs ex = new ExceptionsLecs();
            //ex.Display();
            //ex.Display();
            //ex.Display();

            //Thread t1 = new Thread(ex.Display);
            //Thread t2 = new Thread(ex.Display);
            //Thread t3 = new Thread(ex.Display);

            //t1.Start();
            //t2.Start();
            //t3.Start();

            // thread priority --> Highest will consume more CPU resource by default it is set to normal

            //Thread t1 = new Thread(IncrementCount1);
            //Thread t2 = new Thread(IncrementCount2);

            //t1.Priority = ThreadPriority.Highest;
            //t2.Priority = ThreadPriority.BelowNormal;

            //t1.Start();
            //t2.Start();

            //Console.WriteLine("Main thread sleep");
            //Thread.Sleep(10000);
            //Console.WriteLine("Main Thread Woke up ");

            //t1.Abort();
            //t2.Abort();

            //Console.WriteLine("count1: " + count1);
            //Console.WriteLine("count2: " + count2);

            //Stopwatch stp = new Stopwatch();
            //stp.Start();
            //IncrementCount3();
            //IncrementCount4();
            //stp.Stop();

            //Console.WriteLine("IncrementCount single: " + stp.ElapsedMilliseconds);

            //Thread t1 = new Thread(IncrementCount3);
            //Thread t2 = new Thread(IncrementCount4);

            //Stopwatch stp1 = new Stopwatch();

            //stp1.Start();
            //t1.Start();
            //t2.Start();
            //stp1.Stop();

            //Console.WriteLine("IncrementCount multi: " + stp1.ElapsedMilliseconds);



            // ************** Collections  ***********
            //int[] arr = new int[10];
            //Array.Resize(ref arr, 20);
            // ** disadvantages of aaray ****
            // Increasing the size
            // Inserting values into the middle
            // Deleting or removing values from the middle.

            // Non - generic collections --> not type safe but auto resizing
            // Non-generics are types that are tightly bound to specific data types, meaning they can only store or work with a predefined type.
            // stack, Queue, LinkedList, SortedLis, ArrayList,Hashtable

            // Array vs ArrayList:
            // fixed length but it's variable length
            // not possible but Inserting values into the middle
            // not possible but Deleting or removing values from the middle.


            //ArrayList arlst = new ArrayList();
            //Console.WriteLine("Capacity after: " + arlst.Capacity);

            //arlst.Add(2);
            //arlst.Add(true);
            //arlst.Add(92);
            //arlst.Add("Neha Singh");
            //arlst.Add(89.98);
            //arlst.Insert(2, 102);
            //Console.WriteLine("Capacity after: " + arlst.Capacity);


            //foreach (object i in arlst)
            //{
            //    Console.WriteLine(i + " ");
            //}


            // Hashtable --> same as arraylist but stores vlaues in key value combination

            //Hashtable ht = new Hashtable();
            //ht.Add("id", 1001);
            //ht.Add("name", "Neha Singh");
            //ht.Add("job", "Sr. SDE");
            //ht.Add("MgID", 11001);
            //ht.Add("dept", "IT");
            //ht.Add("Phone", 9876543218);
            //ht.Add("DLoc", "Mumbai");
            //ht.Add("email", "neha@gmail.com");

            //Console.WriteLine("Email: " + ht["email"]);
            //Console.WriteLine("DLoc: " + ht["DLoc"]);
            //Console.WriteLine("Hello".GetHashCode());

            //foreach (object k in ht.Keys)
            //{
            //    Console.WriteLine(k + " : " + ht[k] + " : " + ht[k].GetHashCode());
            //}


            // Generics collections --> type safe and auto resizing
            // Generics allow you to define a class, interface, method, or delegate with a placeholder for the data type. You specify the actual type when you use it.

            //ExceptionsLecs ex = new ExceptionsLecs();
            //bool ans = ex.CompareGen(5, 95);
            //Console.WriteLine(ans);

            //bool ans1 = ex.CompareGen1(5.6F, 95.6F);
            //Console.WriteLine(ans1);

            //// using Generics Type <T>
            //bool ans2 = ex.CompareGen2<float>(5.6F, 5.6f);
            //Console.WriteLine(ans2);

            //ex.Add<float>(3.4F, 5.76F);
            //ex.Subtract<int>(30, 5);


            //OperationsCollectionsGen<double> opcollgen = new OperationsCollectionsGen<double>();
            //opcollgen.Muliple(345.6, 789.5);
            //opcollgen.Muliple(39845.6, 789.5);


            // In case of a genric collections the types of values we want we want to store under the collections need not be pre-defined types only like int, float, char, string etxc
            // but it can also be some user -defined type also.
            // List<T>  --> T respresebt data type liek int, string for type safety
            // Dictionary<TKey, TValue>
            // Queue<T>
            // Stack<T>
            // Func<T>, Action<T>

            //Dictionary<string, object> dic = new Dictionary<string, object>();
            //dic.Add("Id", 10001);
            //dic.Add("Name", "Priya Gupta");
            //dic.Add("Job", "Sr Sales Head");
            //dic.Add("Dname", "Sales");
            //dic.Add("Salary", 600000.0);

            // key data type
            //foreach(string k in dic.Keys)
            //{
            //    Console.WriteLine($"{k} : {dic[k]}");
            //}

            //Console.WriteLine();

            //List<CustomerCollections> customerCollections = new List<CustomerCollections>()
            //{
            //    new CustomerCollections { CustId = 201, CustName = "Alice", balance = 1000.0 },
            //    new CustomerCollections { CustId = 202, CustName = "Bob", balance = 1500.5 },
            //    new CustomerCollections { CustId = 203, CustName = "Charlie", balance = 200.75 }
            //};

            //customerCollections.Insert(1, new CustomerCollections { CustId = 205, CustName = "Priya", balance = 345200.75 });

            //foreach (CustomerCollections customerCollections1 in customerCollections)
            //{
            //    Console.WriteLine($"ID: {customerCollections1.CustId}, Name: {customerCollections1.CustName}, Balance: {customerCollections1.balance}");
            //}




            // IComparable and IComparer

            //ComparableGen student1 = new ComparableGen { ID = 15, Name = "Neha", Class = 10, Marks = 89.5f };
            //ComparableGen student2 = new ComparableGen { ID = 452, Name = "Amit", Class = 10, Marks = 76.0f };
            //ComparableGen student3 = new ComparableGen { ID = 3003, Name = "Riya", Class = 10, Marks = 91.2f };
            //ComparableGen student4 = new ComparableGen { ID = 423, Name = "Vikram", Class = 10, Marks = 68.4f };
            //ComparableGen student5 = new ComparableGen { ID = 52, Name = "Sneha", Class = 10, Marks = 95.0f };
            //ComparableGen student6 = new ComparableGen { ID = 8906, Name = "Rahul", Class = 10, Marks = 82.3f };
            //ComparableGen student7 = new ComparableGen { ID = 73, Name = "Kavya", Class = 10, Marks = 88.9f };

            //List<ComparableGen> students = new List<ComparableGen>();
            //students.Add(student1);
            //students.Add(student2);
            //students.Add(student3);
            //students.Add(student4);
            //students.Add(student5);
            //students.Add(student6);
            //students.Add(student7);

            //students.Sort();


            //foreach (ComparableGen student in students)
            //{
            //    Console.WriteLine($"ID: {student.ID}, Name: {student.Name}, Balance: {student.Class}, Marks: {student.Marks} ");

            //}

            //students.Reverse();

            //Console.WriteLine();

            //foreach (ComparableGen student in students)
            //{
            //    Console.WriteLine($"ID: {student.ID}, Name: {student.Name}, Balance: {student.Class}, Marks: {student.Marks} ");

            //}


            //foreach (ComparableGen student in students)
            //{
            //    Console.WriteLine($"ID: {student.ID}, Name: {student.Name}, Balance: {student.Class}, Marks: {student.Marks} ");

            //}

            //CompareDevierdclassId compareDevierdclassId = new CompareDevierdclassId();

            //students.Sort(compareDevierdclassId);

            //Console.WriteLine();

            //foreach (ComparableGen student in students)
            //{
            //    Console.WriteLine($"ID: {student.ID}, Name: {student.Name}, Balance: {student.Class}, Marks: {student.Marks} ");

            //}


            //students.Sort(0, 4,compareDevierdclassId);

            //to comapre based on names
            //Comparison<ComparableGen> compnames = new Comparison<ComparableGen>(CompareNames);
            //students.Sort(compnames);
            // or 
            //students.Sort(CompareNames);
            // or
            //students.Sort(delegate(ComparableGen a, ComparableGen b) { return a.Name.CompareTo(b.Name); });
            // or
            //students.Sort((s1, s2) => s1.Name.CompareTo(s2.Name));

            //foreach (ComparableGen student in students)
            //{
            //    Console.WriteLine($"ID: {student.ID}, Name: {student.Name}, Balance: {student.Class}, Marks: {student.Marks} ");

            //}



            //  IEnumerable Interface --> is parent of collections.

            //            List<EmployeeColl> employees = new List<EmployeeColl>()
            //{
            //    new EmployeeColl { empId = 101, EmpName = "Jatin Shah", EmpJob = "IT", Salary = 45000.0 },
            //    new EmployeeColl { empId = 102, EmpName = "Neha Singh", EmpJob = "HR", Salary = 40000.0 },
            //    new EmployeeColl { empId = 103, EmpName = "Aman Verma", EmpJob = "Finance", Salary = 55000.0 },
            //    new EmployeeColl { empId = 104, EmpName = "Sneha Rao", EmpJob = "Marketing", Salary = 47000.0 },
            //    new EmployeeColl { empId = 105, EmpName = "Ravi Patel", EmpJob = "IT", Salary = 62000.0 },
            //    new EmployeeColl { empId = 106, EmpName = "Priya Nair", EmpJob = "Admin", Salary = 39000.0 },
            //    new EmployeeColl { empId = 107, EmpName = "Mohit Kumar", EmpJob = "Sales", Salary = 51000.0 },
            //    new EmployeeColl { empId = 108, EmpName = "Kavita Joshi", EmpJob = "Finance", Salary = 58000.0 },
            //    new EmployeeColl { empId = 109, EmpName = "Deepak Yadav", EmpJob = "IT", Salary = 60000.0 },
            //    new EmployeeColl { empId = 110, EmpName = "Anjali Mehta", EmpJob = "HR", Salary = 43000.0 }
            //};


            //            foreach(EmployeeColl emc in employees)
            //            {
            //                Console.WriteLine($"ID: {emc.empId}, Name: {emc.EmpName}, Salary: {emc.Salary}, EmpJob: {emc.EmpJob} ");

            //            }

            //Oragnization org = new Oragnization();
            //org.Add(new EmployeeColl { empId = 101, EmpName = "Jatin Shah", EmpJob = "IT", Salary = 45000.0 });
            //org.Add(new EmployeeColl { empId = 102, EmpName = "Neha Singh", EmpJob = "HR", Salary = 40000.0 });
            //org.Add(new EmployeeColl { empId = 103, EmpName = "Aman Verma", EmpJob = "Finance", Salary = 55000.0 });
            //org.Add(new EmployeeColl { empId = 104, EmpName = "Sneha Rao", EmpJob = "Marketing", Salary = 47000.0 });
            //org.Add(new EmployeeColl { empId = 105, EmpName = "Ravi Patel", EmpJob = "IT", Salary = 62000.0 });
            //org.Add(new EmployeeColl { empId = 106, EmpName = "Priya Nair", EmpJob = "Admin", Salary = 39000.0 });
            //org.Add(new EmployeeColl { empId = 107, EmpName = "Mohit Kumar", EmpJob = "Sales", Salary = 51000.0 });
            //org.Add(new EmployeeColl { empId = 108, EmpName = "Kavita Joshi", EmpJob = "Finance", Salary = 58000.0 });
            //org.Add(new EmployeeColl { empId = 109, EmpName = "Deepak Yadav", EmpJob = "IT", Salary = 60000.0 });
            //org.Add(new EmployeeColl { empId = 110, EmpName = "Anjali Mehta", EmpJob = "HR", Salary = 43000.0 });



            //foreach (EmployeeColl emc in org)
            //{
            //    Console.WriteLine($"ID: {emc.empId}, Name: {emc.EmpName}, Salary: {emc.Salary}, EmpJob: {emc.EmpJob} ");
            //}


            // *********** LINQ(Language Integrated Query) **************
            // Language Integrated Query 
            // Syntax of LINQ
            // There are two syntaxes of LINQ. 
            // -- Lamda (Method) Syntax
            // -- Query (Comprehension) Syntax
           

            
                List <EmployeeLinq> employees = new List<EmployeeLinq>()
{
    new EmployeeLinq { Id = 1, Name = "Neha", Department = "IT", Salary = 60000, Age = 28, City = "Mumbai", IsActive = true },
    new EmployeeLinq { Id = 2, Name = "Aman", Department = "HR", Salary = 50000, Age = 32, City = "Delhi", IsActive = true },
    new EmployeeLinq { Id = 3, Name = "Ravi", Department = "Finance", Salary = 45000, Age = 26, City = "Mumbai", IsActive = false },
    new EmployeeLinq { Id = 4, Name = "Nikita", Department = "IT", Salary = 70000, Age = 30, City = "Chennai", IsActive = true },
    new EmployeeLinq { Id = 5, Name = "Anil", Department = "HR", Salary = 30000, Age = 24, City = "Delhi", IsActive = true },
};

            //  1. Where – Filtering
            var highSalary = employees.Where(x => x.Salary > 50000);
            //foreach (var employee in highSalary)
            //{
            //    Console.WriteLine(employee.Name);
            //}

            // 2. Select – Projection
            var names = employees.Select(x => x.Name);
            //foreach (var n in names)
            //{
            //    Console.WriteLine($"{ n}");
            //}

            // 3. OrderBy – Sorting Ascending
            var sortbyname = employees.OrderBy(x => x.Name);
            //foreach (var n in sortbyname)
            //{
            //    Console.WriteLine($"Sorting --> Name: {n.Name}");
            //}

            // 4. OrderByDescending – Sorting Descending
            var sortbynamedesc = employees.OrderByDescending(x => x.Name);
            //foreach (var n in sortbynamedesc)
            //{
            //    Console.WriteLine($"Sorting Descending --> Name: {n.Name}");
            //}

            // 5. GroupBy – Grouping
            var grpbydept = employees.GroupBy(x => x.Department);
            //foreach(var group in grpbydept)
            //{
            //    Console.WriteLine("Department: " + group.Key);
            //    foreach(var g in group)
            //    {
            //        Console.WriteLine(" - " + g.Name);
            //    }
            //}


            // 6. First, FirstOrDefault – First match
            var firstStartwithN = employees.FirstOrDefault(x => x.Name.StartsWith("N"));
            //if (firstStartwithN != null)
            //{
            //    Console.WriteLine($"Sorting --> Name: {firstStartwithN.Name}");
            //}
            //else
            //{
            //    Console.WriteLine("No employee found whose name starts with 'N'.");
            //}

            // 7. Any – Existence check
            bool isValidAge = employees.Any(x => x.Age >= 18);
            //if (isValidAge == true)
            //{
            //    Console.WriteLine($"Valid Age ");
            //}
            //else
            //{
            //    Console.WriteLine("No employee found whose age is valid.");
            //}


            // 8. All – All match
            bool allAreActive = employees.All(x => x.IsActive);
            //if (allAreActive == true)
            //{
            //    Console.WriteLine($"yes ");
            //}
            //else
            //{
            //    Console.WriteLine("No employee found");
            //}

            // 9. Count, Sum – Aggregation
            int CountAge = employees.Count(x => x.Age >= 18);
            double totalSalary = employees.Sum(x => x.Salary);

            //Console.WriteLine($"Count: {CountAge} ");
            //Console.WriteLine($"totalSalary: {totalSalary} ");


            // 10. Take, Skip – Paging
            var skippedandtaken = employees.Skip(2).Take(2);
            //foreach( var employee in skippedandtaken )
            //{
            //    Console.WriteLine($" Take, Skip --> Name: {employee.Name} ");
            //}

            // 11. Distinct – Remove Duplicates
            var distinct = employees.Select(x => x.Department).Distinct();
            //foreach (var d in distinct)
            //{
            //    Console.WriteLine($" distinct --> Name: {d} ");
            //}

            // 12. ToList, ToArray – Convert to list/array
            var toList = employees.Where(x=>x.IsActive).ToList();
            //foreach(var act in toList)
            //{
            //    Console.WriteLine($" ToList --> Name: {act.Name}, Age: {act.Age} ");
            //}

            // ToArray
            var toarray = employees.Where(x => x.IsActive).ToArray();
            //foreach (var act in toarray)
            //{
            //    Console.WriteLine($" ToArray --> Name: {act.Name}, Age: {act.Age} ");
            //}


            // Boxing: Boxing converts value type (int, char, etc.) to reference type (object) which is an implicit conversion process using object value. 
            // Unboxing: Unboxing converts reference type (object) to value type (int, char, etc.) using an explicit conversion process. 


        }
    }

}