namespace MyBanker;

internal class Program {
    static void Main(string[] args) {
        Card myCard = new VisaElectron("Emil");
        Console.WriteLine(myCard.CardOwner);
        Console.WriteLine(myCard.CardNumber);
        Console.WriteLine(myCard.AccountNumber);
        Console.WriteLine(myCard.ExpirationDate);
    }
}

internal abstract class Card {
    private string cardOwner;
    internal string CardOwner { get => cardOwner; }

    private string cardNumber;
    internal string CardNumber { get => cardNumber; }

    private DateTime expirationDate;
    internal DateTime ExpirationDate { get => expirationDate; }

    private string accountNumber;
    internal string AccountNumber { get => accountNumber; }

    internal Card(string cardOwner, int length, string[] prefixes) {
        this.cardOwner = cardOwner;
        this.cardNumber = GenerateCardNumber(length, prefixes);
        this.accountNumber = GenerateAccountNumber();


        this.expirationDate = GenerateExpirationDate();
    }

    protected DateTime GenerateExpirationDate() {
        return DateTime.Today.AddMonths(5);
    }

    protected string GenerateAccountNumber() {
        return "3520" + Random.Shared.Next(10000).ToString() + Random.Shared.Next(10000).ToString();
    }

    protected string GenerateCardNumber(int length, string[] prefixes) {
        int arrayPlace = Random.Shared.Next(0, prefixes.Length);
        string output = prefixes[arrayPlace];

        while (output.Length < length) {
            output = output + Random.Shared.Next(10).ToString();
        }

        return output;
    }
}

internal class VisaElectron : Card {
    public VisaElectron(string cardOwner) : base(cardOwner, 14, prefixes)  { }

    private static string[] prefixes
        =  { "4026", "417500", "4508", "4844", "4913", "4917" };


}

internal class Visa : Card {
    public Visa(string cardOwner) : base(cardOwner, 14, prefixes) { }

    private static string[] prefixes
        = { "4" };
}

internal class Mastercard : Card {
    public Mastercard(string cardOwner) : base(cardOwner, 14, prefixes) { }

    private static string[] prefixes
        = { "51", "52", "53", "54", "55" };
}

internal class Maestro : Card {
    public Maestro(string cardOwner) : base(cardOwner, 19, prefixes) { }

    private static string[] prefixes
        = { "5018", "5020", "5038", "5893", "6304", "6759", "6761", "6762", "6763" };
}

internal class DebitCard : Card {
    public DebitCard(string cardOwner) : base(cardOwner, 14, prefixes) { }

    private static string[] prefixes
        = { "2400" };
}
