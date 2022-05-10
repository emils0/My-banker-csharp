namespace MyBanker;

internal class Visa : Card {
    public Visa(string cardOwner) :
        base(cardOwner, 14, Prefixes, DateTime.Today.AddYears(Random.Shared.Next(1, 6))) { }

    private static readonly string[] Prefixes
        = { "4" };
}