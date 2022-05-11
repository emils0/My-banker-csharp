namespace MyBanker;

internal class Maestro : Card {
    public Maestro(string cardOwner) :
        base(cardOwner, 19, Prefixes, new DateTime(0000, 00, 00)) { }

    // defines the prefixes for generating the card number
    private static readonly string[] Prefixes
        = { "5018", "5020", "5038", "5893", "6304", "6759", "6761", "6762", "6763" };
}
