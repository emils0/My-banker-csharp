namespace MyBanker;

internal class Program {
    static void Main(string[] args) {
        Card myCard = new VisaElectron("Emil");
        Console.WriteLine(myCard.GetCard());;
        Console.WriteLine(myCard.Balance);

        myCard.IncreaseBalance(1000.52);
        Console.WriteLine(myCard.Balance);

        myCard.DecreaseBalance(620);
        Console.WriteLine(myCard.Balance);
    }
}
