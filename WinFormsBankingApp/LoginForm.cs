public partial class LoginForm : Form
{
    private Bank bank;

    private Label lblAccountNumber;
    private TextBox txtAccountNumber;
    private Label lblUserName;
    private TextBox txtUserName;
    private Label lblPin;
    private TextBox txtPin;
    private Button btnLogin;

    public LoginForm(Bank bank)
    {
        this.bank = bank;
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        this.lblAccountNumber = new System.Windows.Forms.Label();
        this.txtAccountNumber = new System.Windows.Forms.TextBox();
        this.lblUserName = new System.Windows.Forms.Label();
        this.txtUserName = new System.Windows.Forms.TextBox();
        this.lblPin = new System.Windows.Forms.Label();
        this.txtPin = new System.Windows.Forms.TextBox();
        this.btnLogin = new System.Windows.Forms.Button();
        this.SuspendLayout();


       
        this.BackColor = Color.White;
        this.Font = new Font("Tahoma", 9F, FontStyle.Regular);

        
        Action<Label> styleLabel = (l) => {
            l.ForeColor = Color.Gold;
            l.Font = new Font("Tahoma", 10F, FontStyle.Bold);
        };

        this.lblAccountNumber.Location = new System.Drawing.Point(10, 15);
        this.lblAccountNumber.Text = "Account #:";
        this.lblAccountNumber.Size = new System.Drawing.Size(80, 20);
        this.Controls.Add(this.lblAccountNumber);

        this.txtAccountNumber.Location = new System.Drawing.Point(100, 12);
        this.txtAccountNumber.Size = new System.Drawing.Size(180, 20);
        this.Controls.Add(this.txtAccountNumber);

        this.lblUserName.Location = new System.Drawing.Point(10, 45);
        this.lblUserName.Text = "Username:";
        this.lblUserName.Size = new System.Drawing.Size(80, 20);
        this.Controls.Add(this.lblUserName);

        this.txtUserName.Location = new System.Drawing.Point(100, 42);
        this.txtUserName.Size = new System.Drawing.Size(180, 20);
        this.Controls.Add(this.txtUserName);

        this.lblPin.Location = new System.Drawing.Point(10, 75);
        this.lblPin.Text = "PIN:";
        this.lblPin.Size = new System.Drawing.Size(80, 20);
        this.Controls.Add(this.lblPin);

        this.txtPin.Location = new System.Drawing.Point(100, 72);
        this.txtPin.Size = new System.Drawing.Size(80, 20);
        this.txtPin.MaxLength = 4;
        this.txtPin.UseSystemPasswordChar = true;
        this.Controls.Add(this.txtPin);

        this.btnLogin.Location = new System.Drawing.Point(100, 110);
        this.btnLogin.Size = new System.Drawing.Size(100, 30);
        this.btnLogin.Text = "Login";
        this.btnLogin.BackColor = Color.Orange;
        this.btnLogin.ForeColor = Color.White;
        this.btnLogin.FlatStyle = FlatStyle.Flat;
        this.btnLogin.FlatAppearance.BorderSize = 0;
        this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
        this.Controls.Add(this.btnLogin);

        this.ClientSize = new System.Drawing.Size(400, 280);
        this.Text = "Account Login";
        this.StartPosition = FormStartPosition.CenterParent;
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        string accountNumber = txtAccountNumber.Text.Trim();
        string userName = txtUserName.Text.Trim();
        string pin = txtPin.Text;

        var account = bank.FindAccount(accountNumber, userName, pin);
        if (account != null)
        {
            using (var accountForm = new AccountForm(account, bank))
            {
                accountForm.ShowDialog();
            }
            this.Close();
        }
        else
        {
            MessageBox.Show("Error: Invalid Account Number, Username, or PIN combination.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}