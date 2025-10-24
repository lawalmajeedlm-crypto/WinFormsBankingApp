using EmjayBankApp;

public partial class TransferForm : Form
{
    private BankAccount sourceAccount;
    private Bank bank;
    private decimal amount;
    private Action updateBalancesCallback;

    private Label lblAmount;
    private Label lblSource;
    private ComboBox cmbSourceAccount;
    private Label lblRecipient;
    private TextBox txtRecipientAccount;
    private Button btnExecuteTransfer;

    public TransferForm(BankAccount sourceAccount, Bank bank, decimal amount, Action updateBalancesCallback)
    {
        this.sourceAccount = sourceAccount;
        this.bank = bank;
        this.amount = amount;
        this.updateBalancesCallback = updateBalancesCallback;
        InitializeComponent();
        lblAmount.Text = $"Transfer Amount: {amount:C2}";
        cmbSourceAccount.Items.Add("Savings");
        cmbSourceAccount.Items.Add("Current");
        cmbSourceAccount.SelectedIndex = 0;
    }

    private void InitializeComponent()
    {
        this.lblAmount = new System.Windows.Forms.Label();
        this.lblSource = new System.Windows.Forms.Label();
        this.cmbSourceAccount = new System.Windows.Forms.ComboBox();
        this.lblRecipient = new System.Windows.Forms.Label();
        this.txtRecipientAccount = new System.Windows.Forms.TextBox();
        this.btnExecuteTransfer = new System.Windows.Forms.Button();
        this.SuspendLayout();

        this.BackColor = Color.White;
        this.Font = new Font("Tahoma", 9F, FontStyle.Regular);

        Action<Label> styleLabel = (l) => {
            l.ForeColor = Color.Orange;
            l.Font = new Font("Tahoma", 9F, FontStyle.Bold);
        };

        this.lblAmount.Location = new System.Drawing.Point(10, 10);
        this.lblAmount.AutoSize = true;
        this.lblAmount.Font = new Font("Tahoma", 10F, FontStyle.Bold);
        this.lblAmount.ForeColor = Color.DarkGoldenrod;
        this.Controls.Add(this.lblAmount);

        this.lblSource.Location = new System.Drawing.Point(10, 40);
        this.lblSource.Text = "From Account:";
        this.lblSource.AutoSize = true;
        styleLabel(this.lblSource);
        this.Controls.Add(this.lblSource);

        this.cmbSourceAccount.Location = new System.Drawing.Point(120, 37);
        this.cmbSourceAccount.Size = new System.Drawing.Size(150, 20);
        this.cmbSourceAccount.DropDownStyle = ComboBoxStyle.DropDownList;
        this.Controls.Add(this.cmbSourceAccount);

        this.lblRecipient.Location = new System.Drawing.Point(10, 70);
        this.lblRecipient.Text = "To Account #:";
        this.lblRecipient.AutoSize = true;
        styleLabel(this.lblRecipient);
        this.Controls.Add(this.lblRecipient);

        this.txtRecipientAccount.Location = new System.Drawing.Point(120, 67);
        this.txtRecipientAccount.Size = new System.Drawing.Size(150, 20);
        this.Controls.Add(this.txtRecipientAccount);

        this.btnExecuteTransfer.Location = new System.Drawing.Point(100, 110);
        this.btnExecuteTransfer.Size = new System.Drawing.Size(120, 30);
        this.btnExecuteTransfer.Text = "Execute Transfer";
        this.btnExecuteTransfer.BackColor = Color.Orange; 
        this.btnExecuteTransfer.ForeColor = Color.White;
        this.btnExecuteTransfer.FlatStyle = FlatStyle.Flat;
        this.btnExecuteTransfer.FlatAppearance.BorderSize = 0;
        this.btnExecuteTransfer.Font = new Font("Tahoma", 9F, FontStyle.Bold);
        this.btnExecuteTransfer.Click += new System.EventHandler(this.btnExecuteTransfer_Click);
        this.Controls.Add(this.btnExecuteTransfer);

        this.ClientSize = new System.Drawing.Size(400, 280);
        this.Text = "Execute Transfer";
        this.StartPosition = FormStartPosition.CenterParent;
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private void btnExecuteTransfer_Click(object sender, EventArgs e)
    {
        string recipientAccountNumber = txtRecipientAccount.Text.Trim();
        string sourceAccountType = cmbSourceAccount.SelectedItem?.ToString();

        if (string.IsNullOrEmpty(recipientAccountNumber) || string.IsNullOrEmpty(sourceAccountType))
        {
            MessageBox.Show("Please specify both the source account type and the recipient account number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (recipientAccountNumber == sourceAccount.AccountNumber)
        {
            MessageBox.Show("Cannot transfer to the same account.", "Transfer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        BankAccount recipientAccount = bank.FindAccountByNumber(recipientAccountNumber);

        if (recipientAccount == null)
        {
            MessageBox.Show("Recipient account number not found.", "Transfer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        try
        {
            sourceAccount.Transfer(amount, recipientAccount, sourceAccountType);
            updateBalancesCallback?.Invoke();
            MessageBox.Show($"Successfully transferred {amount:C2} from {sourceAccountType} to account {recipientAccountNumber}.", "Transfer Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException)
        {
            MessageBox.Show($"Transfer Failed: {ex.Message}", "Transfer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
    