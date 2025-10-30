class Program
{
    BankAccount bankAccount = new BankAccount();
    static void Main()
    {
        Program program = new();
        program.Wplac();
        program.PobierzSaldo();
    }
    private void Wplac()
    {
        bankAccount.Wplac(100.3);
    }
    private void PobierzSaldo()
    {
        Console.WriteLine(bankAccount.PobierzSaldo());
    }
}
class BankAccount
{
    private double saldo=0;

    public void Wplac(double kwota)
    {
        pierwszeUrucomienie = true;
        saldo += kwota;
    }
    public double PobierzSaldo()
    {
        return saldo;
    }
}