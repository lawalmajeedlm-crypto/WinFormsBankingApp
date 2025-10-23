using EmjayBankApp;

public class Bank
{
    private List<BankAccount> accounts = new List<BankAccount>();

    public void CreateAccount(string userName, string pin)
    {
        var newAccount = new BankAccount(userName, pin);
        accounts.Add(newAccount);
        MessageBox.Show($"Account Created Successfully.\nAccount Number: {newAccount.AccountNumber}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public BankAccount FindAccount(string accountNumber, string userName, string pin)
    {
        return accounts.FirstOrDefault(a => a.AccountNumber == accountNumber && a.UserName == userName && a.VerifyPin(pin));
    }

    // --- NEW method to find account by number only ---
    public BankAccount FindAccountByNumber(string accountNumber)
    {
        return accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
    }
}