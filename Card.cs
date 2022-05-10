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

    internal Card(string cardOwner, int length, string[] prefixes, DateTime expirationDate) {
        _cardOwner = cardOwner;
        _cardNumber = GenerateCardNumber(length, prefixes);
        _accountNumber = GenerateAccountNumber();
        _expirationDate = expirationDate;
    }

    public string GetCard() {
        return
            $"Card owner: {CardOwner}\n" +
            $"Card number: {CardNumber}\n" +
            $"Account number: {AccountNumber}\n" +
            $"Expiration date: {ExpirationDate}";
    }

    public void IncreaseBalance(double amount) {
        if (amount < 0) {
            throw new InvalidOperationException();
        }
        _balance += amount;
    }

    public void DecreaseBalance(double amount) {
        double temp = _balance - amount;
        if (temp < 0 || amount < 0) {
            throw new InvalidOperationException();
        }
        _balance = temp;
    }

    private static string GenerateAccountNumber() {
        return "3520" + Random.Shared.Next(10000) + Random.Shared.Next(10000);
    }

    private static string GenerateCardNumber(int length, string[] prefixes) {
        int arrayPlace = Random.Shared.Next(0, prefixes.Length);
        string output = prefixes[arrayPlace];

        while (output.Length < length) {
            output += Random.Shared.Next(10).ToString();
        }

        return output;
    }
}
