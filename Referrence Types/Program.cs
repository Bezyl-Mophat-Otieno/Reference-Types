


Person person = new Person("Bezyl Mophat Otieno", 23);

person.Greet();


var myDreamCar = new Car("Mazda Atenza", 2009);
myDreamCar.PrintInfo();

Calculator myCalc = new Calculator();

Console.WriteLine(myCalc.Add(2000, 4050));
Console.WriteLine(myCalc.Divide(3500, 7));
Console.WriteLine(Configuration.GetConfigurationInstance());
Console.WriteLine(Logger.FilePath);

// Create a Product class with:
//
//     A Name property (get; set;)
//
// A Price property (get; private set;)
//
// A method SetDiscount(double percent) → decreases Price.
//
//     A read-only property IsAvailable (returns true if Price > 0).

Product product = new Product("2kg Cooking Floo2", 275);

Console.WriteLine("IsAvailable: " + product.IsAvailable);


// Create a BankAccount class with:
//
//     Field: balance (private)
//
// Method Deposit(double amount) → increases balance
//
// Method Withdraw(double amount) → decreases balance if enough funds exist
//
// Method GetBalance() → prints current balance


BankAccount account = new BankAccount();
account.GetBalance();
account.Deposit(1000);
account.GetBalance();




// Create a static class TemperatureConverter with:
//
// Method CelsiusToFahrenheit(double c)
//
// Method FahrenheitToCelsius(double f)

double kelvin = TemperatureConverter.CelsiusToFahrenheit(10);
Console.WriteLine($"Kelvin: {kelvin}");


double celcius = TemperatureConverter.FahrenheitToCelsius(100);
Console.WriteLine($"Celciue: {celcius}");




// Create a Book class with:
//
//     Fields: title, author
//
//     Constructor to set them
//
//     Method PrintDetails() that prints: "Title: X, Author: Y"
//
// Add a property Pages to Book that:
//
// Cannot be set below 1.
//
//     Defaults to 1 if an invalid value is passed.

Book book = new Book("Lord of the Rings", "James Olka", 0);
book.PrintDetails();

Program program = new Program();
program.Main();


public partial class Program
{
    public static void sayHello(string name) => Console.WriteLine($"Hello, {name}");
    public static void sayHi(string name) => Console.WriteLine($"Hi, {name}");
    public void Main()
    {
        Greet greet1 = sayHello;
        greet1("Mophat");
        Greet gree2 = sayHi;
        gree2("Bezyl");

    }
}



public class Product
{
    public string Name { get; set; }
    public double Price { get; private set; }

    public Product(string name, double price)
    {
        Name = name;
        Price = price;
    }

    public bool IsAvailable
    {
        get { return Price > 0; }
    }

    public void SetDiscount(double percent)
    {
        if (percent < 0 || percent > 100) throw new InvalidOperationException("Invalid percentage");
        var discountedAmount = (percent/100) * Price;
        Price -= discountedAmount;

    }
}

public class Book
{
    private string Title { get; }
    private string Author { get; }
    public int Pages { get; private set; }

    public Book(string title, string author, int pages)
    {
        Author = author;
        Title = title;
        Pages = pages < 1 ? 1 : pages;

    }

    public void PrintDetails()
    {
        Console.WriteLine($"Title: {Title}, Author: {Author}, Pages: {Pages}");
    }
    

}

public class TemperatureConverter
{

    public  static double CelsiusToFahrenheit(double c)
    {
        return (c * 9/5 ) + 32;
    }
    
    public static double FahrenheitToCelsius( double f)
    {
        return ( f * 5/9 ) - 32;
    }
    
}


public delegate void Greet(string message);


public class BankAccount
{
    private double balance;

    public void Deposit(double amount)
    {
        balance += amount;
    }

    public void Withdraw(double amount)
    {
        if (amount < balance) throw new InvalidOperationException("Insufficient funds");
        balance -= amount;
    }

    public void GetBalance()
    {
        Console.WriteLine($"Balance: {balance}");
    }
    
    
}

public interface ILogger
{
    public void LoggInformation(string message);
}


public class Logger: ILogger
{
    public static string FilePath;

    static Logger()
    {
        FilePath = $"/logging/log.txt";

    }

    public void LoggInformation(string message)
    {
        Console.WriteLine(message);
    }
}

public class Configuration
{
    private static Configuration _instance;
    
    private Configuration(){}

    public static Configuration GetConfigurationInstance()
    {
        if (_instance == null) _instance = new Configuration();
        return _instance;
    }
}





public class Car
{
    public string Brand { get; set; }
    public int Year { get; private set; }

    public Car(string brand, int year)
    {
        Brand = brand;
        Year = year < 1856 ? 1856 : year;

    }


    public void PrintInfo()
    {
        Console.WriteLine($"{Brand}, {Year}");
    }
}



public class Calculator
{
    public int Add(int a, int b) => a + b;

    public double Divide(double num, double denom)
    {
        if (denom == 0) return 0;
        return num / denom;
    }

}






public class Person
{
    private string Name;
    private uint Age;

    public Person(string name, uint age)
    {
        Name = name;
        Age = age;
    }


    public void Greet()
    {
        Console.WriteLine($"Hello There !, my  name is {Name} and I am {Age} years old");
    }

}