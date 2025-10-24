using EmjayBankApp;

public partial class AccountForm : Form
{
    private BankAccount account;
    private Bank bank; // Added reference to Bank to find recipient accounts

    private Label lblWelcome;
    private Label lblSavingsTitle;
    private Label lblSavingsBalance;
    private Button btnCheckSavings;
    private Button btnDepositSavings;
    private Button btnWithdrawSavings;
    private Label lblCurrentTitle;
    private Label lblCurrentBalance;
    private Button btnCheckCurrent;
    private Button btnDepositCurrent;
    private Button btnWithdrawCurrent;
    private Label lblAmount;
    private TextBox txtAmount;
    private Button btnTransfer; // New Transfer Button
    private Button btnLogout;
    private Button btnShutdown;
    private TextBox txtFullName;
    private TextBox txtUserName;
    private TextBox txtPin;

    public AccountForm(BankAccount account, Bank bank)
    {
        this.account = account;
        this.bank = bank; // Initialize Bank reference
        InitializeComponent();
        lblWelcome.Text = $"Welcome, {account.FullName}.";
        UpdateBalances();
    }

    private void InitializeComponent()
    {
        this.lblWelcome = new System.Windows.Forms.Label();
        this.lblSavingsTitle = new System.Windows.Forms.Label();
        this.lblSavingsBalance = new System.Windows.Forms.Label();
        this.btnCheckSavings = new System.Windows.Forms.Button();
        this.btnDepositSavings = new System.Windows.Forms.Button();
        this.btnWithdrawSavings = new System.Windows.Forms.Button();
        this.lblCurrentTitle = new System.Windows.Forms.Label();
        this.lblCurrentBalance = new System.Windows.Forms.Label();
        this.btnCheckCurrent = new System.Windows.Forms.Button();
        this.btnDepositCurrent = new System.Windows.Forms.Button();
        this.btnWithdrawCurrent = new System.Windows.Forms.Button();
        this.lblAmount = new System.Windows.Forms.Label();
        this.txtAmount = new System.Windows.Forms.TextBox();
        this.btnTransfer = new System.Windows.Forms.Button(); // New
        this.btnLogout = new System.Windows.Forms.Button();
        this.btnShutdown = new System.Windows.Forms.Button();
        this.txtFullName = new System.Windows.Forms.TextBox();
        this.txtUserName = new System.Windows.Forms.TextBox();
        this.txtPin = new System.Windows.Forms.TextBox();
        this.SuspendLayout();


        // Form Style
        this.BackColor = Color.White;
        this.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

        // Welcome Label
        this.lblWelcome.Location = new System.Drawing.Point(10, 10);
        this.lblWelcome.AutoSize = true;
        this.lblWelcome.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        this.lblWelcome.ForeColor = Color.OrangeRed; // Highlight Welcome Message
        this.Controls.Add(this.lblWelcome);

        // Styling Helpers
        Action<Label> styleTitleLabel = (l) => {
            l.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            l.ForeColor = Color.Orange; // Orange for Titles
        };

        Action<Label> styleBalanceLabel = (l) => {
            l.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            l.ForeColor = Color.DarkGoldenrod; // Dark Gold for Balances
        };

        static void styleActionButton(Button b, object isPrimary)
        {
            b.Size = new System.Drawing.Size(100, 30);
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            if ((bool)isPrimary)
            {
                b.BackColor = Color.Gold;
                b.ForeColor = Color.Black;
            }
            else
            {
                b.BackColor = Color.LightGray;
                b.ForeColor = Color.Black;
            }
        }


        // Row 2: Savings Section
        this.lblSavingsTitle.Location = new System.Drawing.Point(10, 50);
        this.lblSavingsTitle.Text = "Savings Account:";
        this.lblSavingsTitle.AutoSize = true;
        this.Controls.Add(this.lblSavingsTitle);

        this.lblSavingsBalance.Location = new System.Drawing.Point(120, 50);
        this.lblSavingsBalance.AutoSize = true;
        this.Controls.Add(this.lblSavingsBalance);

        // Row 3: Savings Buttons
        this.btnCheckSavings.Location = new System.Drawing.Point(10, 80);
        this.btnCheckSavings.Size = new System.Drawing.Size(100, 30);
        this.btnCheckSavings.Text = "Check S. Bal";
        this.btnCheckSavings.Click += new System.EventHandler(this.btnCheckSavings_Click);
        this.Controls.Add(this.btnCheckSavings);

        this.btnDepositSavings.Location = new System.Drawing.Point(120, 80);
        this.btnDepositSavings.Size = new System.Drawing.Size(100, 30);
        this.btnDepositSavings.Text = "Deposit S.";
        this.btnDepositSavings.Click += new System.EventHandler(this.btnDepositSavings_Click);
        this.Controls.Add(this.btnDepositSavings);

        this.btnWithdrawSavings.Location = new System.Drawing.Point(230, 80);
        this.btnWithdrawSavings.Size = new System.Drawing.Size(100, 30);
        this.btnWithdrawSavings.Text = "Withdraw S.";
        this.btnWithdrawSavings.Click += new System.EventHandler(this.btnWithdrawSavings_Click);
        this.Controls.Add(this.btnWithdrawSavings);

        // Row 4: Current Section
        this.lblCurrentTitle.Location = new System.Drawing.Point(10, 130);
        this.lblCurrentTitle.Text = "Current Account:";
        this.lblCurrentTitle.AutoSize = true;
        this.Controls.Add(this.lblCurrentTitle);

        this.lblCurrentBalance.Location = new System.Drawing.Point(120, 130);
        this.lblCurrentBalance.AutoSize = true;
        this.Controls.Add(this.lblCurrentBalance);

        // Row 5: Current Buttons
        this.btnCheckCurrent.Location = new System.Drawing.Point(10, 160);
        this.btnCheckCurrent.Size = new System.Drawing.Size(100, 30);
        this.btnCheckCurrent.Text = "Check C. Bal";
        this.btnCheckCurrent.Click += new System.EventHandler(this.btnCheckCurrent_Click);
        this.Controls.Add(this.btnCheckCurrent);

        this.btnDepositCurrent.Location = new System.Drawing.Point(120, 160);
        this.btnDepositCurrent.Size = new System.Drawing.Size(100, 30);
        this.btnDepositCurrent.Text = "Deposit C.";
        this.btnDepositCurrent.Click += new System.EventHandler(this.btnDepositCurrent_Click);
        this.Controls.Add(this.btnDepositCurrent);

        this.btnWithdrawCurrent.Location = new System.Drawing.Point(230, 160);
        this.btnWithdrawCurrent.Size = new System.Drawing.Size(100, 30);
        this.btnWithdrawCurrent.Text = "Withdraw C.";
        this.btnWithdrawCurrent.Click += new System.EventHandler(this.btnWithdrawCurrent_Click);
        this.Controls.Add(this.btnWithdrawCurrent);

        // Row 6: Amount Input & Transfer
        this.lblAmount.Location = new System.Drawing.Point(10, 210);
        this.lblAmount.Text = "Amount ($):";
        this.lblAmount.AutoSize = true;
        this.Controls.Add(this.lblAmount);

        this.txtAmount.Location = new System.Drawing.Point(100, 210);
        this.txtAmount.Size = new System.Drawing.Size(100, 20);
        this.Controls.Add(this.txtAmount);

        this.btnTransfer.Location = new System.Drawing.Point(230, 205);
        this.btnTransfer.Size = new System.Drawing.Size(100, 30);
        this.btnTransfer.Text = "Transfer";
        this.btnTransfer.BackColor = Color.Orange; // Primary Orange
        this.btnTransfer.ForeColor = Color.White;
        this.btnTransfer.FlatStyle = FlatStyle.Flat;
        this.btnTransfer.FlatAppearance.BorderSize = 0;
        this.btnTransfer.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
        this.Controls.Add(this.btnTransfer);

        // Row 7: Footer Buttons
        this.btnLogout.Location = new System.Drawing.Point(10, 250);
        this.btnLogout.Size = new System.Drawing.Size(150, 30);
        this.btnLogout.Text = "Logout";
        this.btnLogout.BackColor = Color.Gray;
        this.btnLogout.ForeColor = Color.White;
        this.btnLogout.FlatStyle = FlatStyle.Flat;
        this.btnLogout.FlatAppearance.BorderSize = 0;
        this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
        this.Controls.Add(this.btnLogout);

        this.btnShutdown.Location = new System.Drawing.Point(180, 250);
        this.btnShutdown.Size = new System.Drawing.Size(150, 30);
        this.btnShutdown.Text = "Shutdown All";
        this.btnShutdown.BackColor = Color.Black;
        this.btnShutdown.ForeColor = Color.White;
        this.btnShutdown.FlatStyle = FlatStyle.Flat;
        this.btnShutdown.FlatAppearance.BorderSize = 0;
        this.btnShutdown.Click += new System.EventHandler(this.btnShutdown_Click);
        this.Controls.Add(this.btnShutdown);

        this.ClientSize = new System.Drawing.Size(350, 300);
        this.Text = "Account Operations";
        this.StartPosition = FormStartPosition.CenterParent;
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private void UpdateBalances()
    {
        lblSavingsBalance.Text = $"{account.GetSavingsBalance():C2}";
        lblCurrentBalance.Text = $"{account.GetCurrentBalance():C2}";
    }

    // In CreateAccountForm Class

    private void btnCreate_Click(object sender, EventArgs e)
    {
        string fullName = txtFullName.Text.Trim();
        string userName = txtUserName.Text.Trim();
        string pin = txtPin.Text;

        if (string.IsNullOrWhiteSpace(fullName))
        {
            MessageBox.Show("Full Name cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // --- Custom Validation for Full Name (Non-numeric "TryParse" Concept) ---
        // Check if the full name contains ONLY letters and spaces.
        bool isValidName = fullName.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));

        if (!isValidName)
        {
            MessageBox.Show("Full Name must contain only letters and spaces.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        // -----------------------------------------------------------------------

        if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(pin))
        {
            MessageBox.Show("Username and PIN cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        try
        {
            // Assuming you have updated Bank.CreateAccount to accept fullName
            // bank.CreateAccount(userName, pin, fullName);
            this.Close();
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show($"Creation Error: {ex.Message}\nPlease try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // --- NEW Transfer Button Handler ---
    private void btnTransfer_Click(object sender, EventArgs e)
    {
        if (ProcessTransactionInput(out decimal amount))
        {
            using (var transferForm = new TransferForm(account, bank, amount, UpdateBalances))
            {
                transferForm.ShowDialog();
            }
        }
    }

    // --- Transaction Handlers (Unchanged) ---
    private void btnCheckSavings_Click(object sender, EventArgs e)
    {
        MessageBox.Show($"Current Savings Balance: {account.GetSavingsBalance():C2}", "Savings Balance", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void btnDepositSavings_Click(object sender, EventArgs e)
    {
        if (ProcessTransactionInput(out decimal amount))
        {
            try
            {
                account.DepositSavings(amount);
                UpdateBalances();
                MessageBox.Show($"Deposit of {amount:C2} successful.", "Deposit Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void btnWithdrawSavings_Click(object sender, EventArgs e)
    {
        if (ProcessTransactionInput(out decimal amount))
        {
            try
            {
                account.WithdrawSavings(amount);
                UpdateBalances();
                MessageBox.Show($"Withdrawal of {amount:C2} successful.", "Withdrawal Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void btnCheckCurrent_Click(object sender, EventArgs e)
    {
        MessageBox.Show($"Current Account Balance: {account.GetCurrentBalance():C2}", "Current Balance", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void btnDepositCurrent_Click(object sender, EventArgs e)
    {
        if (ProcessTransactionInput(out decimal amount))
        {
            try
            {
                account.DepositCurrent(amount);
                UpdateBalances();
                MessageBox.Show($"Deposit of {amount:C2} successful.", "Deposit Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void btnWithdrawCurrent_Click(object sender, EventArgs e)
    {
        if (ProcessTransactionInput(out decimal amount))
        {
            try
            {
                account.WithdrawCurrent(amount);
                UpdateBalances();
                MessageBox.Show($"Withdrawal of {amount:C2} successful.", "Withdrawal Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private bool ProcessTransactionInput(out decimal amount)
    {
        string input = txtAmount.Text.Trim();
        if (decimal.TryParse(input, System.Globalization.NumberStyles.Currency | System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.CurrentCulture, out amount) && amount > 0)
        {
            return true;
        }
        else
        {
            MessageBox.Show("Error: Please enter a valid, positive monetary amount in the Amount box.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            amount = 0m;
            return false;
        }
    }

    private void btnLogout_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void btnShutdown_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Application is shutting down. All in-memory data has been lost.", "Shutdown", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        Application.Exit();
    }
}