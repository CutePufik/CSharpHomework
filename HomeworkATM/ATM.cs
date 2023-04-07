using System.Globalization;
using System.Text;

namespace HomeworkATM;

public class ATM
{
    private long idATM;
    private String bankOwner;
    private Dictionary<int, int> moneyCassette;
    private List<String> historyTransaction;
    private String secretWord;

    
    public long _idATM
    {
        get { return idATM;}
        
    }
    public String _bankOwner
    {
        get {return bankOwner;}
    }

    public ATM(string bankOwner,  string secretWord)
    {
        Random r = new Random();
        idATM = r.NextInt64();
        this.bankOwner = bankOwner;
        this.moneyCassette = new Dictionary<int, int>();
        this.historyTransaction = new List<string>();
        this.secretWord = secretWord;
    }

    public long CashAmount
    {
        get
        {
            var sum = 0;
            foreach (var pairs in moneyCassette)
            {
                sum += pairs.Key * pairs.Value;
            }

            return sum;
        }
    }

    
    public override string ToString()
    {
        StringBuilder stringBuilderTrank = new StringBuilder();
        foreach (var str in historyTransaction)
        {
            stringBuilderTrank.Append(str);
        }

        var historyTran = stringBuilderTrank.ToString();

        StringBuilder stringBuilderCassete = new StringBuilder();
        foreach (var i in moneyCassette)
        {
            stringBuilderCassete.Append(i);
        }

        var cassete = stringBuilderCassete.ToString();
        
        return $" имя владельца банка - {bankOwner} id банокмата- {idATM} \n " +
               $" \n история транзакций {historyTran} \n кассета с деньгами - {cassete} \n секретное слово - {secretWord} ";
    }

   
    

   
    public void putMoney(Card card,Dictionary<int,int> inputMoneyCassete)
    {
        //
        if (!checkNominal(inputMoneyCassete))
        {
            historyTransaction.Add($"<{card}>: <пополнение> (<{sum(inputMoneyCassete)}>) => <запрос отклонен>");
            Console.WriteLine("Вы ввели копюры неверное формата");
            return;
        }
        
        
        if (!checkExpirationDate(card.expirationDate))
        {
            historyTransaction.Add($"<{card}>: <пополнение> (<{sum(inputMoneyCassete)}>) => <запрос отклонен>");
            Console.WriteLine("Карта просрочена");
            return;
        }
        
        // 
        
        if (!bankOwner.Equals(card.issuingBank))
        {
            Console.WriteLine("будет взята комиссия 5%");
            historyTransaction.Add($"<{card}>: <пополнение с комиссией> <запрос сделан>");
            card._balance += 0.95 * sum(inputMoneyCassete);
        }
        else card._balance += sum(inputMoneyCassete);

        

        foreach (var pairs in inputMoneyCassete)
        {
            if (moneyCassette.ContainsKey(pairs.Key))
                moneyCassette[pairs.Key] += pairs.Value;
            else moneyCassette.Add(pairs.Key,pairs.Value);
        }
        
        historyTransaction.Add($"<{card}>: <пополнение> (<{sum(inputMoneyCassete)}>) => <запрос выполнен>");

    }

    public void takeMoney(Card card, int money)
    {
        if (!checkExpirationDate(card.expirationDate))
        {
            historyTransaction.Add($"<{card}>: <снятие денег> (<{money}>) => <запрос отклонен>");
            Console.WriteLine("Карта просрочена");
            return;
        }

        if (money > card._balance && money > sum(moneyCassette))
        {
            historyTransaction.Add($"<{card}>: <снятие денег> (<{money}>) => <запрос отклонен>");
            Console.WriteLine("Недостаточно денег на балансе");
            return;
        }
        
        if (!checkNominalForTake(money))
        {
            Console.WriteLine("Нет купюр для выдачи такой суммы");
            historyTransaction.Add($"<{card}>: <снятие денег> (<{money}>) => <запрос отклонен>");
            return;
        }
        
        if (!bankOwner.Equals(card.issuingBank))
        {
            Console.WriteLine("будет взята комиссия 5%");
            historyTransaction.Add($"<{card}>: <снятие с комиссией>");
            if (money * 1.05 > CashAmount)
            {
                Console.WriteLine("Не хватает денег на счету");
                return;
            }
            giveMoney(money);
            card._balance -= money * 1.05;
            historyTransaction.Add($"<{card}>: <снятие с комиссией>:(<{money}>) => <запрос выполнен>");
            
            
        }
        else
        {
            historyTransaction.Add($"<{card}>: <снятие без комиссии (<{money}>) => <запрос выполнен>");
            giveMoney(money);
            card._balance -= money;
            
        }
        
       
        
        






    }

   
    /// забирает деньги с кассеты банкомата
    private void giveMoney(int money)
    {
        int localsum = 0;
        foreach (var pairs in moneyCassette.OrderByDescending(x => x.Key))
            while (pairs.Value!=0)
            {
                if (pairs.Key <= money - localsum)
                {
                    localsum += pairs.Key;
                    moneyCassette[pairs.Key]-= 1;
                    if (localsum == money)
                    {
                        return;
                    }
                }
                else
                {
                    break;
                }
            }
    }


    /// <summary>
    /// возвраещает тру, если можно выдать деньги
    /// </summary>
    /// <param name="sum"></param>
    /// <returns></returns>
    private bool checkNominalForTake(int sum)
    {
        int localsum = 0;
        foreach (var pairs in moneyCassette.OrderByDescending(x => x.Key))
        {
            var pairsValue = pairs.Value;
            while (pairsValue!=0)
            {
                if ((pairs.Key <= sum - localsum))
                {
                    localsum += pairs.Key;
                    if (localsum == sum)
                        return true;
                    pairsValue--;
                }
                else
                {
                    break;
                }
            }
        }
        return false;
    }

    private int sum(Dictionary<int, int> dictionary)
    {

        int res = 0;
        foreach (var pairs in dictionary)
        {
            res += pairs.Key * pairs.Value;
        }

        return res;
    }


    private bool checkExpirationDate(string cardExpirationDate)
    {
        DateTime today = DateTime.Today;
        int currentMonth = today.Month;
        int currentYear = today.Year;

        int cardMonth = int.Parse(cardExpirationDate.Substring(0,2));
        int cardYear = int.Parse(20 + cardExpirationDate.Substring(3,2));

        if (!(currentYear < cardYear && currentMonth < cardMonth))
            return false;
        return true;
    }


    /// проверяет номинал
    private bool checkNominal(Dictionary<int, int> dictionary)
    {
        int[] nominal = { 5, 10, 50, 100, 200, 500, 1000, 2000, 5000 };
        foreach (var pairs in dictionary)
        {
            if (!nominal.Contains(pairs.Key))
                return false;
        }
        return true;
    }

    
    public void pickUp(String s)
    {
        var deshifr = new string(s.Select(c => (char)(c - 4)).ToArray());
        if (!deshifr.Equals(secretWord))
        {
            Console.WriteLine("Полиция выехала(?)");
            return;
        }

        int countBanknotes = moneyCassette.Select(x => x.Value).ToArray().Sum();
        int countCassete = moneyCassette.Where(x => x.Value > 0).ToArray().Length;
        if (countCassete != 0)
        {
            int averageBanknotes = countBanknotes / countCassete;
            makeAverageBanknotes(averageBanknotes);
        }
        
        
        print(historyTransaction);
        historyTransaction.Clear();
    }

    private void makeAverageBanknotes(int averageBanknotes)
    { // сказано,что во всех кассетах, даже с нулем банкнот
        foreach (var pairs in moneyCassette)
        {
            moneyCassette[pairs.Key] = averageBanknotes;
        }
    }

    private void print(List<string> list)
    {
        foreach (var s in list)
        {
            Console.WriteLine(s);
        }
    }
}