namespace MyBanker;

internal class DebitCard : Card {
    public DebitCard(string cardOwner) :
        base(cardOwner, 14, Prefixes, DateTime.Today.AddYears(5).AddMonths(8), 0, 0) { }

    // defines the prefixes for generating the card number
    private static readonly string[] Prefixes
        = { "2400" };
}
