using System;
using System.Text.RegularExpressions;

namespace HomeworkATM;

public class Card
{
    
    public String cardNumber { get; }
    public String nameOwner { get; }
    public String expirationDate { get; }
    public String issuingBank { get; }
    
    private double balance;
    

    public double _balance
    {
        get => balance;
        set
        {
            if (value < 0)
            {
                throw new Exception("Баланс не может быть отрицательным");
            }

            balance = value;
        }
    }
    
    

    public Card(double balance, string cardNumber, string nameOwner, string expirationDate, string issuingBank)
    {
        if (balance < 0)
        {
            throw new Exception("баланс не может быть отрицательным на новой карте");
        }
        this.balance = balance;
        if (cardNumber.Length != 16)
        {
            throw new Exception($"У вас номер карты состоит из {cardNumber.Length} \n а должен состоять из 16 цифр");
        }
        
        this.cardNumber = cardNumber;
        this.nameOwner = nameOwner;
        
        if (Regex.IsMatch(expirationDate,@"(\d{2})/(\d{2})"))
            this.expirationDate = expirationDate;
        else throw new Exception("Месяц и год окончания действия карты неверно введены");
       
        
        this.issuingBank = issuingBank;
    }

    public override string ToString()
    {
        return $"  имя владельца- {nameOwner} ,дата сгорания работы карточки {expirationDate} \n " +
               $" номер карточки : {cardNumber}, эмитент банка - {issuingBank},  баланс на карте = {balance}";
    }
}