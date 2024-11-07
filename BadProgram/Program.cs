// This is NOT how you should be coding!

using System.Globalization;
Console.WriteLine("Vad vill du köpa?");
var item = Console.ReadLine();
Console.WriteLine("Hur många?");
var quantity = float.Parse(Console.ReadLine());
var datetimenprovider = new DateTimeProvider();

var db = new Database();
var rg = new ReceiptGenerator(item, quantity, db, datetimenprovider);
var total = rg.GetTotal();

var receipt = rg.Generate(item, total);

Console.WriteLine(receipt);

public class ReceiptGenerator
{
    readonly float _price, _quantity, _discount;
    private readonly DateTime _time;
    private readonly IDatabase _db;

    public ReceiptGenerator(string item, float quantity, IDatabase db, IDateTimeProvider dateTimeProvider)
    {
        _db = db;
        _price = _db.GetItemPrice(item);
        _quantity = quantity;
        _time = dateTimeProvider.Now;
        _discount = (_time.DayOfWeek == DayOfWeek.Friday) ? 10f : 0f;
    }
    
    public string Generate(
        string item,
        float total)
    {
        return $"""
                ********************************
                KVITTO
                {item}({_price.ToString("F2", CultureInfo.InvariantCulture)}) x {_quantity}
                rabatt: {_discount}%
                Total price: {total}:-
                ~~~~~~~~~~~~~~~~~~~~~ 
                {_time}
                ********************************
                """;
    }

    public float GetTotal()
    {
        return _price * _quantity * (1 - (_discount / 100));
    }
}

public interface IDatabase
{
    float GetItemPrice(string id);
}
public class Database : IDatabase
{
    // Let's pretend this actually connects to a database
    public float GetItemPrice(string id) => new Random().Next(1, 10);
}


public interface IDateTimeProvider
{
    DateTime Now { get; }
}
public class DateTimeProvider : IDateTimeProvider
{
    public DateTime Now => DateTime.Now;
}

// Steps to fix this:
// 1. Identify the problems
//    - Beroende på Console.WriteLine och Console.ReadLine 
//    - Beroende på DateTime.Now
//    - Beroende på Database
//    - All kod ligger i main()
// 
// 2. Refactor the code
//    - Bryt ut den kod som skapar kvittot