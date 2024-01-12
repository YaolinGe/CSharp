using System; 

namespace T
{
    //using N3; 
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World!");
            A a = new A();
            a.sayHi();
            a.sayHiB();
            a.sayHiC();

            N3.B b = new N3.B();
            b.sayHi();
        }
    }
}

public class Test
{
    public override string ToString()
    {
        return "Test does not live in a namespace!";
    }
}

namespace ca1050
{
    public class Test
    {
        public override string ToString()
        {
            return "Test lives in a namespace!";
        }
    }
}

namespace T
{
    public partial class  A 
    {
        public void sayHi()
        {
            Console.WriteLine("HI, A!");
        }
    }

}

namespace T
{
    public partial class A
    {
        public void sayHiB()
        {
            Console.WriteLine("HI, B!");
        }
    }
}

namespace T
{
    using good; 
    public partial class A
    {
        public void sayHiC()
        {
            TGood good = new TGood();
            good.sayGood();
        }
    }
}

namespace N1.N2
{
    class A { }
}

namespace N3
{
    using A = N1.N2.A;
    class  B: A { 
    
    public void sayHi()
                   {
                   Console.WriteLine("HI, B! FROM DOUBLE ALIAS NAMESPACE");
               }}
}

interface ISampleInterface
{
    void SampleMethod();
}

class ImplementationClass : ISampleInterface
{
    // Explicit interface member implementation:
    void ISampleInterface.SampleMethod()
    {
        // Method implementation.
    }

    static void Main()
    {
        // Declare an interface instance.
        ISampleInterface obj = new ImplementationClass();

        // Call the member.
        obj.SampleMethod();
    }
}