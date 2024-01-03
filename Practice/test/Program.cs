using System; 

class Employee
{
    private string name;
    private string alias;
    private decimal salary = 3000.00m;

    // Constructor:
    public Employee(string name, string alias)
    {
        this.name = name; 
        this.alias = alias; 
    }

    // Printing method:
    public void printEmployee()
    {
        Console.WriteLine("Name: {0}\nAlias: {1}", name, alias);
        // Passing the object to the CalcTax method by using this:
        Console.WriteLine("Taxes: {0:C}", Tax.CalcTax(this));
    }

    public decimal Salary
    {
        get { return salary; }
    }
}

class Tax
{
    public static decimal CalcTax(Employee E)
    {
        return 0.08m * E.Salary;
    }
}

class MainClass
{
    static void Main()
    {
        // Create objects:
        Employee E1 = new Employee("Mingda Pan", "mpan");

        // Display results:
        E1.printEmployee();
    }
}


/*
Output:
    Name: Mingda Pan
    Alias: mpan
    Taxes: $240.00
 */

// class Person 
// {
//     private string alias; 

//     private string name; 
//     public string Name 
//     {
//         get { return name; }
//         set { name = value; }
//     }

//     public string NName 
//     {
//         get => name; 
//         set => name = value; 
//     }

//     public string NName 
//     {
//         get => this.name; 
//         set => this.name = value; 
//     }

//     public string getName() 
//     {
//         return name; 
//     }

//     public void setName(string userDefinedName)
//     {
//         name = userDefinedName; 
//     }

//     public Person(string initialName = "Yao")
//     {
//         name = initialName; 
//     }
// }

// class Program
// {
//     static void Main(string[] args)
//     {
//         Person p = new Person(); 
//         Console.WriteLine(p.Name); 
//         Console.WriteLine(p.getName());
//         p.Name = "Ge"; 
//         Console.WriteLine(p.Name);
//         p.setName("Yao Ge");
//         Console.WriteLine(p.getName());
//         System.Console.WriteLine(p.Name);


//         // int[] data = new int[3]; 
//         // var data1 = data;
//         // // Console.WriteLine(data); 
//         // data = new int[3]; 
//         // Console.WriteLine(data);
//         // Console.WriteLine(data.Length); 
//     }
// }

