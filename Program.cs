namespace MyBanker;

internal class Program {
    static void Main(string[] args) {

        Card test1 = new Visa("Emil", 1000, new DateTime(2000, 12, 31), 100);

        Console.WriteLine($"{test1.AccountNumber} {test1.CardNumber} {test1.CardOwner} {test1.ExpirationDate}");
    }
}

internal abstract class Card {
    private string cardOwner;
    internal string CardOwner { get => cardOwner; }

    private int cardNumber;
    internal int CardNumber { get => cardNumber; }

    private DateTime expirationDate;
    internal DateTime ExpirationDate { get => expirationDate; }

    private int accountNumber;
    internal int AccountNumber { get => accountNumber; }

    internal Card(string cardOwner, int cardNumber, DateTime expirationDate, int accountNumber) {
        this.cardOwner = cardOwner;
        this.cardNumber = cardNumber;
        this.expirationDate = expirationDate;
        this.accountNumber = accountNumber;
    }
}

internal class VisaElectron : Card {
    public VisaElectron(string cardOwner, int cardNumber, DateTime expirationDate, int accountNumber) :
        base(cardOwner, cardNumber, expirationDate, accountNumber) {
    }
}

internal class Visa : Card {
    public Visa(string cardOwner, int cardNumber, DateTime expirationDate, int accountNumber) :
        base(cardOwner, cardNumber, expirationDate, accountNumber) {
    }
}

internal class Mastercard : Card {
    public Mastercard(string cardOwner, int cardNumber, DateTime expirationDate, int accountNumber) :
        base(cardOwner, cardNumber, expirationDate, accountNumber) {
    }
}

internal class Maestro : Card {
    public Maestro(string cardOwner, int cardNumber, DateTime expirationDate, int accountNumber) :
        base(cardOwner, cardNumber, expirationDate, accountNumber) {
    }
}

internal class DebitCard : Card {
    public DebitCard(string cardOwner, int cardNumber, DateTime expirationDate, int accountNumber) :
        base(cardOwner, cardNumber, expirationDate, accountNumber) {
    }
}
