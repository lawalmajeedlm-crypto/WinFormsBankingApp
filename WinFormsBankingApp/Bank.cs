using EmjayBankApp;
public class Bank
{
    private List<BankAccount> accounts = new List<BankAccount>();

    public void CreateAccount(string userName, string pin, string fullName)
    {
        var newAccount = new BankAccount(userName, pin, fullName);
        accounts.Add(newAccount);
        MessageBox.Show($"Account Created Successfully.\nAccount Number: {newAccount.AccountNumber}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public BankAccount FindAccount(string accountNumber, string userName, string pin)
    {
        return accounts.FirstOrDefault(a => a.AccountNumber == accountNumber && a.UserName == userName && a.VerifyPin(pin));
    }

    public BankAccount FindAccountByNumber(string accountNumber)
    {
        return accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
    }
}