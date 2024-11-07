// This is NOT how you should be coding!

using System.Globalization;

var db = new Database();
var now = DateTime.Now;
var discount = (now.DayOfWeek == DayOfWeek.Friday) ? 25f : 0f;
Console.WriteLine("Vad vill du köpa?");
var item = Console.ReadLine();
var price = db.GetItemPrice(item);
Console.WriteLine("Hur många?");
var quantity = float.Parse(Console.ReadLine());

var rg = new ReceiptGenerator(price, quantity, discount);
var total = rg.GetTotal();

var receipt = rg.Generate(item, total, now);

Console.WriteLine(receipt);

public class ReceiptGenerator
{
    readonly float _price, _quantity, _discount;

    public ReceiptGenerator(float price, float quantity, float discount)
    {
        _price = price;
        _quantity = quantity;
        _discount = discount;
    }
    
    public string Generate(
        string item,
        float total,
        DateTime date)
    {
        return $"""
                ********************************
                KVITTO
                {item}({_price.ToString("F2", CultureInfo.InvariantCulture)}) x {_quantity}
                rabatt: {_discount}%
                Total price: {total}:-
                ~~~~~~~~~~~~~~~~~~~~~ 
                {date}
                ********************************
                """;
    }

    public float GetTotal()
    {
        return _price * _quantity * (1 - (_discount / 100));
    }
}

public class Database
{
    // Let's pretend this actually connects to a database
    public float GetItemPrice(string id) => new Random().Next(1, 10);
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