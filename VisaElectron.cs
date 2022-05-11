namespace MyBanker;

internal class VisaElectron : Card {
    public VisaElectron(string cardOwner) :
        base(cardOwner, 14, Prefixes, DateTime.Today.AddYears(Random.Shared.Next(1, 11)))  { }

    // defines the prefixes for generating the card number
    private static readonly string[] Prefixes
        =  { "4026", "417500", "4508", "4844", "4913", "4917" };
}
