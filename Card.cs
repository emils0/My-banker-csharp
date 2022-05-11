namespace MyBanker;

internal abstract class Card {
    private int _limitPositive;
    internal int LimitPositive { get => _limitPositive; }
    private double positiveUse;

    private int _limitNegative;
    internal int LimitNegative { get => _limitNegative; }
    private double negativeUse;

    private double _balance;
    internal double Balance { get => _balance; }

    private readonly string _cardOwner;
    internal string CardOwner { get => _cardOwner; }

    private readonly string _cardNumber;
    internal string CardNumber { get => _cardNumber; }

    private readonly DateTime _expirationDate;
    internal DateTime ExpirationDate { get => _expirationDate; }

    private readonly string _accountNumber;
    internal string AccountNumber { get => _accountNumber; }

    // the constructor in which I define all the values on creation (except for card owner)
    internal Card(string cardOwner,
                  int length,
                  string[] prefixes,
                  DateTime expirationDate,
                  int limitPositive,
                  int limitNegative) {
        _cardOwner = cardOwner;
        _cardNumber = GenerateCardNumber(length, prefixes);
        _accountNumber = GenerateAccountNumber();
        _expirationDate = expirationDate;
        this._limitPositive = limitPositive;
        this._limitNegative = limitNegative;
    }

    // the method I call in order to get information about the card
    public string GetCard() {
        return
            $"Card owner: {CardOwner}\n" +
            $"Card number: {CardNumber}\n" +
            $"Account number: {AccountNumber}\n" +
            $"Expiration date: {ExpirationDate}\n" +
            $"Positive limit: {LimitPositive}\n" +
            $"Negative limit: {LimitNegative}";
    }

    // increases the balance, also makes sure that you cannot decrease the balance using this method
    public void IncreaseBalance(double amount) {
        positiveUse += amount;
        if (positiveUse > _limitPositive && _limitPositive != 0) {
            throw new InvalidOperationException();
        }

        if (amount < 0) {
            throw new InvalidOperationException();
        }
        _balance += amount;
    }

    // used to decrease the balance, also has error handleing
    public void DecreaseBalance(double amount) {
        double temp = _balance - amount;
        negativeUse -= amount;
        if (negativeUse > _limitNegative && _limitNegative != 0) {
            throw new InvalidOperationException();
        }

        if (temp < 0 || amount < 0) {
            throw new InvalidOperationException();
        }
        _balance = temp;
    }

    // this method generates all the account numbers, it's pretty simple cause they're all the same
    private static string GenerateAccountNumber() {
        return "3520" + Random.Shared.Next(10000) + Random.Shared.Next(10000);
    }

    // the method that I use to generate all the card numbers
    private static string GenerateCardNumber(int length, string[] prefixes) {
        string output = prefixes[Random.Shared.Next(0, prefixes.Length)];

        while (output.Length < length) {
            output += Random.Shared.Next(10).ToString();
        }

        return output;
    }
}
