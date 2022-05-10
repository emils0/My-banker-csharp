namespace MyBanker;

internal class DebitCard : Card {
    public DebitCard(string cardOwner) :
        base(cardOwner, 14, Prefixes, DateTime.Today.AddYears(5).AddMonths(8)) { }

    private static readonly string[] Prefixes
        = { "2400" };
}