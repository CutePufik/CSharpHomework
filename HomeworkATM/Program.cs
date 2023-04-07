

using HomeworkATM;

class myClass
{
    static void Main(string[] args)
    {
        Card card = new Card(0, "1111111111111111", "pudge", "12/25", "VTB");
        ATM atm = new ATM("VTB", "Mihalkovich");
        
        
        Dictionary<int, int> inputSum = new Dictionary<int, int>()
        {
            { 100, 3 },
            { 5, 10 },
            { 1000, 1 },
            { 5000, 2 },
        };
        
        atm.putMoney(card,inputSum);
        Console.WriteLine(atm.CashAmount);
        Console.WriteLine(card._balance);
        
        atm.takeMoney(card,1312);
        atm.takeMoney(card,1355);
        atm.takeMoney(card,1350);
        
        Console.WriteLine(atm);
        Console.WriteLine();
        var s = "Qmleposzmgl";
        atm.pickUp(s);
        
        Console.WriteLine(atm);
        
        
        ////////////////////////////////////////////
        Console.WriteLine();
        
        
        
        // Card card2 = new Card(0, "1111111111111111", "pudge", "12/25", "VTB");
        // ATM atm2 = new ATM("Sber", "Progammer");
        //
        //
        // Dictionary<int, int> inputSum2 = new Dictionary<int, int>()
        // {
        //     { 100, 3 },
        //     { 5, 10 },
        //     { 1000, 1 },
        //     { 5000, 2 },
        // };
        // atm2.putMoney(card2,inputSum2);
        // Console.WriteLine(card2._balance);
        // Console.WriteLine(atm2);
        //
        //
        // atm2.takeMoney(card2,1350);
        // var s2 = "Qmleposzmgl";
        // atm2.pickUp(s2);
        // Console.WriteLine(atm2);
        
        
        

     


    }
}