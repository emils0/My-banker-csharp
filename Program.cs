namespace MyBanker;

internal class Program {
    static void Main(string[] args) {
        Card myCard = new Visa("Emil");
        Console.WriteLine(myCard.GetCard());;
        Console.WriteLine(myCard.Balance);

        myCard.IncreaseBalance(10000);
        Console.WriteLine(myCard.Balance);

        myCard.DecreaseBalance(620);
        Console.WriteLine(myCard.Balance);
    }
}
