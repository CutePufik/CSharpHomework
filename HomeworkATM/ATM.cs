using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace HomeworkATM;

public class ATM
{
    private long idATM;
    private String bankOwner;
    public Stack<Banknote> moneyCassette;
    private List<String> historyTransaction;
    private long secretNumber;


    public long _idATM
    {
        get { return idATM; }
    }

    public String _bankOwner
    {
        get { return bankOwner; }
    }

    public ATM(string bankOwner, long secretNember)
    {
        Random r = new Random();
        idATM = r.NextInt64();
        this.bankOwner = bankOwner;
        this.moneyCassette = new Stack<Banknote>();
        this.historyTransaction = new List<string>();
        this.secretNumber = secretNember;
    }


    /// общее количество денег в кассетах банкомата
    public long CashAmount
    {
        get
        {
            var sum = 0;
            foreach (var pairs in moneyCassette)
            {
                sum += pairs.Nominal;
            }

            return sum;
        }
    }


    public override string ToString()
    {
        StringBuilder stringBuilderTrank = new StringBuilder();
        foreach (var str in historyTransaction)
        {
            stringBuilderTrank.Append(str + "  ");
        }

        var historyTran = stringBuilderTrank.ToString();

        Stack<Banknote> newMoneyCassette = new Stack<Banknote>(new Stack<Banknote>(moneyCassette));
        StringBuilder stringBuilderCassete = new StringBuilder();
        int count = newMoneyCassette.Count;
        for (int i = 0; i < count; i++)
        {
            stringBuilderCassete.Append(newMoneyCassette.Pop());
        }

        var cassete = stringBuilderCassete.ToString();

        return $" имя владельца банка - {bankOwner} id банокмата- {idATM} \n " +
               $" \n история транзакций {historyTran} \n кассета с деньгами - {cassete} \n секретное слово - {secretNumber} ";
    }


    public void putMoney(Card card, params Banknote[] inputBanknotes)
    {
        //
        if (!checkNominal(inputBanknotes))
        {
            historyTransaction.Add($"<{card}>: <пополнение> (<{sum(inputBanknotes)}>) => <запрос отклонен>");
            Console.WriteLine($"Вы ввели копюры неверное формата");
            return;
        }


        if (!checkExpirationDate(card.expirationDate))
        {
            historyTransaction.Add($"<{card}>: <пополнение> (<{sum(inputBanknotes)}>) => <запрос отклонен>");
            Console.WriteLine("Карта просрочена");
            return;
        }

        // 

        if (!bankOwner.Equals(card.issuingBank))
        {
            Console.WriteLine("будет взята комиссия 5%");
            historyTransaction.Add($"<{card}>: <пополнение с комиссией> <запрос сделан>");
            card._balance += 0.95 * sum(inputBanknotes);
        }
        else card._balance += sum(inputBanknotes);


        foreach (var pair in inputBanknotes)
        {
            moneyCassette.Push(pair);
            Console.WriteLine($"{pair} принята ");
        }

        historyTransaction.Add($"<{card}>: <пополнение> (<{sum(inputBanknotes)}>) => <запрос выполнен>");
    }


    public void takeMoney(Card card, int moneyForTake)
    {
        if (!checkExpirationDate(card.expirationDate))
        {
            historyTransaction.Add($"<{card}>: <снятие денег> (<{moneyForTake}>) => <запрос отклонен>");
            Console.WriteLine("Карта просрочена");
            return;
        }

        if (moneyForTake > card._balance && moneyForTake > sum(moneyCassette))
        {
            historyTransaction.Add($"<{card}>: <снятие денег> (<{moneyForTake}>) => <запрос отклонен>");
            Console.WriteLine("Недостаточно денег на балансе");
            return;
        }

        if (!checkNominalForTake(moneyForTake))
        {
            Console.WriteLine("Нет купюр для выдачи такой суммы");
            historyTransaction.Add($"<{card}>: <снятие денег> (<{moneyForTake}>) => <запрос отклонен>");
            return;
        }

        if (!bankOwner.Equals(card.issuingBank))
        {
            Console.WriteLine("будет взята комиссия 5%");
            historyTransaction.Add($"<{card}>: <снятие с комиссией>");
            if (moneyForTake * 1.05 > CashAmount)
            {
                Console.WriteLine("Не хватает денег на счету");
                return;
            }
           

            giveMoney(moneyForTake);
            card._balance -= moneyForTake * 1.05;
            historyTransaction.Add($"<{card}>: <снятие с комиссией>:(<{moneyForTake}>) => <запрос выполнен>");
        }
        else
        {
            historyTransaction.Add($"<{card}>: <снятие без комиссии (<{moneyForTake}>) => <запрос выполнен>");
            giveMoney(moneyForTake);
            card._balance -= moneyForTake;
        }
    }


    /// забирает деньги с кассеты банкомата
    private void giveMoney(int money)
    {
        List<Banknote> addedBanknotes = new List<Banknote>();
        int localsum = 0;
        foreach (var pairs in moneyCassette.ToArray().OrderByDescending(x => x.Nominal))
            if (pairs.Nominal <= money - localsum)
            {
                localsum += pairs.Nominal;
                removeBanknote(pairs.Nominal);
                if (localsum == money)
                {
                    return;
                }
            }
            else
            {
                var b = 1;
            }
    }

    private void removeBanknote(int pairsNominal)
    {
        List<Banknote> uselessBanknotes = new List<Banknote>();
        var len = moneyCassette.Count;
        for (int i = 0; i < len; i++)
        {
            var banknote = moneyCassette.Pop();
            if (banknote.Nominal != pairsNominal)
                uselessBanknotes.Add(banknote);
            else
            {
                Console.WriteLine($"{banknote} снята");
                break;
            }

        }

        for (int i = 0; i < uselessBanknotes.Count; i++)
        {
            moneyCassette.Push(uselessBanknotes[i]);
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
        foreach (var pairs in moneyCassette.OrderByDescending(x => x.Nominal))
        {
            var pairsValue = pairs.Nominal;
            while (pairsValue != 0)
            {
                if ((pairs.Nominal <= sum - localsum))
                {
                    localsum += pairs.Nominal;
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
    private int getAlphabetDistance(char first, char second)
    {
        int distance = Math.Abs((int)second - (int)first) - 1;
        return distance;
    }

    private int sum(params Banknote[] inputBanknotes)
    {
        int res = 0;
        foreach (var pairs in inputBanknotes)
        {
            res += pairs.Nominal;
        }

        return res;
    }

    private int sum(Stack<Banknote> inputBanknotes)
    {
        int res = 0;
        foreach (var pairs in inputBanknotes)
        {
            res += pairs.Nominal;
        }

        return res;
    }


    private bool checkExpirationDate(string cardExpirationDate)
    {
        DateTime today = DateTime.Today;
        int currentMonth = today.Month;
        int currentYear = today.Year;

        int cardMonth = int.Parse(cardExpirationDate.Substring(0, 2));
        int cardYear = int.Parse(20 + cardExpirationDate.Substring(3, 2));

        if (!(currentYear < cardYear && currentMonth < cardMonth))
            return false;
        return true;
    }


    /// проверяет номинал
    private bool checkNominal(params Banknote[] inputBanknotes)
    {
        int[] nominal = { 5, 10, 50, 100, 200, 500, 1000, 2000, 5000 };  // да,я дважды проверяю номинал: в классе и методом,проблем все еще нет
        foreach (var pairs in inputBanknotes)
        {
            if (!nominal.Contains(pairs.Nominal))
                return false;
            if (pairs.Nominal >= 1000)
            {
                var firstLetter = char.ToLower(pairs.Series[0]);
                var secondLetter =  char.ToLower(pairs.Series[1]);
                if (getAlphabetDistance(firstLetter,secondLetter) % 2 == 1){
                    Console.WriteLine(pairs);
                    return false;
                } 
                if(pairs.Series.Substring(2,8).Select(x => int.Parse(x.ToString())).Sum() % 2==0){
                    Console.WriteLine(pairs);
                    return false;
                } 
            }

            if (pairs.Nominal < 1000)
            {
                var firstLetter = char.ToLower(pairs.Series[0]);
                var secondLetter =  char.ToLower(pairs.Series[1]);
                if (getAlphabetDistance(firstLetter,secondLetter) % 2 == 0){
                    Console.WriteLine(pairs);
                    return false;
                } 
                if (pairs.Series.Substring(2, 8).Select(x => int.Parse(x.ToString())).Sum() % 2 == 1)
                {
                    Console.WriteLine(pairs);
                    return false;
                } 
            }
            
        }

        return true;
    }


    public void pickUp(long key)
    {
        if (!deshifrKey(key).Equals(secretNumber))
        {
            Console.WriteLine("полиция выехала(?)");
            return;
        }

        checkSerialNumberBills();

        int countBanknotes = moneyCassette.ToArray().Length; // TODO
        int countCassete = moneyCassette.Select(x => x.Nominal).Distinct().ToArray().Length;
        int[] banknotes = moneyCassette.Select(x => x.Nominal).Distinct().ToArray();
        if (countCassete != 0)
        {
            moneyCassette.Clear();
            int averageBanknotes = countBanknotes / countCassete;
            makeAverageBanknotes(averageBanknotes, banknotes);
        }

        Console.WriteLine("история событий");
        print(historyTransaction);
        historyTransaction.Clear();
    }

    private void checkSerialNumberBills()
    {
        HashSet<String> serials = new HashSet<string>();

        var arr = moneyCassette.ToArray();  // зачем усложнять жизнь и делать ещё более непонятную реализацию...ну вроде
        foreach (var banknote in arr)
        {
            var codeBanknote = banknote.Series;
            if (!serials.Add(codeBanknote))    
            {
                Console.WriteLine($"{banknote} уже существует!!! Тревога(?)");
                removeFakeBankote(banknote);    
            }
        }
    }

    private void removeFakeBankote(Banknote banknote)
    {
        List<Banknote> list = new List<Banknote>();
        var lenCassete = moneyCassette.Count;
        for (int i = 0; i < lenCassete; i++)
        {
            list.Add(moneyCassette.Pop());
        }

        foreach (var kopura in list)
        {
            if(kopura!=banknote)
                moneyCassette.Push(kopura);
        }
        moneyCassette.Push(banknote);
    }

    private void makeAverageBanknotes(int averageBanknotes, int[] banknotes)
    {
        // TODO
        for (int j = 0; j < banknotes.Length; j++)
        {
            for (int i = 0; i < averageBanknotes; i++)
            {
                var seria = makeRandomSeria(banknotes[j]);
                moneyCassette.Push(new Banknote(banknotes[j], seria));
            }
        }
    }

    private String makeRandomSeria(int banknote)
    {
        switch (banknote)
        {
           case 5:
               return RandomSeriaLetters(5) + RandomSeriaDigits(5);
           case 10:
               return RandomSeriaLetters(10) + RandomSeriaDigits(10);
           case 50:
               return RandomSeriaLetters(50) + RandomSeriaDigits(50);
           case 100:
               return RandomSeriaLetters(100) + RandomSeriaDigits(100);
           case 200:
               return RandomSeriaLetters(200) + RandomSeriaDigits(200);
           case 500:
               return RandomSeriaLetters(500) + RandomSeriaDigits(500);
           case 1000:
               return RandomSeriaLetters(1000) + RandomSeriaDigits(1000);
           case 2000:
               return RandomSeriaLetters(2000) + RandomSeriaDigits(2000);
           case 5000:
               return RandomSeriaLetters(5000) + RandomSeriaDigits(5000);
           default:
               return "";
        }
    }

    private string RandomSeriaDigits(int p0)
    {
        Random r = new Random();
        var number = r.NextInt64();
        if (p0 >= 1000)
        {
            while (number.ToString().Substring(2,8).Select(x => int.Parse(x.ToString())).Sum() % 2==0)
            {
                number = r.NextInt64();
            }

            return number.ToString();
        }

        if (p0 < 1000)
        {
            while ((number.ToString().Substring(2,8).Select(x => int.Parse(x.ToString())).Sum() % 2==1))
            {
                number = r.NextInt64();
            }
            return number.ToString();
        }

        return "0";
    }

    private String RandomSeriaLetters(int p0)
    {
        Random rand = new Random();
        if (p0 >= 1000)
        {
            var firstLetter = (char)rand.Next( 'a', 'z' + 1 );
            var secondLetter =  (char)rand.Next( 'a', 'z' + 1 );
            while (getAlphabetDistance(firstLetter, secondLetter) % 2 == 1)
            {
                firstLetter = (char)rand.Next( 'a', 'z' + 1 );
                secondLetter =  (char)rand.Next( 'a', 'z' + 1 );
            }

            return firstLetter.ToString() + secondLetter.ToString();
        }

        if (p0 < 1000)
        {
            var firstLetter = (char)rand.Next( 'a', 'z' + 1 );
            var secondLetter =  (char)rand.Next( 'a', 'z' + 1 );
            
            while ((getAlphabetDistance(firstLetter,secondLetter) % 2 == 0))
            {
                firstLetter = (char)rand.Next( 'a', 'z' + 1 );
                secondLetter =  (char)rand.Next( 'a', 'z' + 1 );
            }

            return firstLetter.ToString() + secondLetter.ToString();
        }

        return "";
    }

    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public long deshifrKey(long key)
    {
        StringBuilder sbKey = new StringBuilder(key.ToString());
        StringBuilder resultKey = new StringBuilder();

        for (int i = 0; i < sbKey.Length - 2; i++)
        {
            var first = int.Parse(sbKey[i].ToString());
            var second = int.Parse(sbKey[i + 1].ToString());
            var third = int.Parse(sbKey[i + 2].ToString());
            var digit = (first + second + third) % 10;
            resultKey.Append(digit);
        }

        return long.Parse(resultKey.ToString());
    }

    private void print(List<string> list)
    {
        foreach (var s in list)
        {
            Console.WriteLine(s);
        }
    }
}