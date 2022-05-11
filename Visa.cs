namespace MyBanker;

internal class Visa : Card {
    public Visa(string cardOwner) :
        base(cardOwner, 14, Prefixes, DateTime.Today.AddYears(Random.Shared.Next(1, 6)), 25000, 20000) { }

    // defines the prefixes for generating the card number
    private static readonly string[] Prefixes
        = { "4" };
}
