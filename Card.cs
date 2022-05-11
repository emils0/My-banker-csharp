namespace MyBanker;

internal abstract class Card {
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
    internal Card(string cardOwner, int length, string[] prefixes, DateTime expirationDate) {
        _cardOwner = cardOwner;
        _cardNumber = GenerateCardNumber(length, prefixes);
        _accountNumber = GenerateAccountNumber();
        _expirationDate = expirationDate;
    }

    // the method I call in order to get information about the card
    public string GetCard() {
        return
            $"Card owner: {CardOwner}\n" +
            $"Card number: {CardNumber}\n" +
            $"Account number: {AccountNumber}\n" +
            $"Expiration date: {ExpirationDate}";
    }

    // increases the balance, also makes sure that you cannot decrease the balance using this method
    public void IncreaseBalance(double amount) {
        if (amount < 0) {
            throw new InvalidOperationException();
        }
        _balance += amount;
    }

    // used to decrease the balance, also has error handleing
    public void DecreaseBalance(double amount) {
        double temp = _balance - amount;
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
