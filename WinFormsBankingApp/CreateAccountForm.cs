public partial class CreateAccountForm : Form
{
    private Bank bank;

    private Label lblFullName;
    private TextBox txtFullName;
    private Label lblUserName;
    private TextBox txtUserName;
    private Label lblPin;
    private TextBox txtPin;
    private Button btnCreate;

    public CreateAccountForm(Bank bank)
    {
        this.bank = bank;
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        this.lblFullName = new System.Windows.Forms.Label();
        this.txtFullName = new System.Windows.Forms.TextBox();
        this.lblUserName = new System.Windows.Forms.Label();
        this.txtUserName = new System.Windows.Forms.TextBox();
        this.lblPin = new System.Windows.Forms.Label();
        this.txtPin = new System.Windows.Forms.TextBox();
        this.btnCreate = new System.Windows.Forms.Button();
        this.SuspendLayout();

        this.BackColor = Color.White;
        this.Font = new Font("Tahoma", 9F, FontStyle.Regular);

        Action<Label> styleLabel = (l) =>
        {
            l.ForeColor = Color.Gold;
            l.Font = new Font("Tahoma", 10F, FontStyle.Bold);
        };

            this.lblFullName.Location = new System.Drawing.Point(10, 15);
        this.lblFullName.Text = "Full Name:";
        this.lblFullName.Size = new System.Drawing.Size(80, 20);
        this.Controls.Add(this.lblFullName);

        this.txtFullName.Location = new System.Drawing.Point(100, 12);
        this.txtFullName.Size = new System.Drawing.Size(180, 20);
        this.Controls.Add(this.txtFullName);

        this.lblUserName.Location = new System.Drawing.Point(10, 45);
        this.lblUserName.Text = "Username:";
        this.lblUserName.Size = new System.Drawing.Size(80, 20);
        this.Controls.Add(this.lblUserName);

        this.txtUserName.Location = new System.Drawing.Point(100, 42);
        this.txtUserName.Size = new System.Drawing.Size(180, 20);
        this.Controls.Add(this.txtUserName);

        this.lblPin.Location = new System.Drawing.Point(10, 75);
        this.lblPin.Text = "4-Digit PIN:";
        this.lblPin.Size = new System.Drawing.Size(80, 20);
        this.Controls.Add(this.lblPin);

        this.txtPin.Location = new System.Drawing.Point(100, 72);
        this.txtPin.Size = new System.Drawing.Size(80, 20);
        this.txtPin.MaxLength = 4;
        this.txtPin.UseSystemPasswordChar = true;
        this.Controls.Add(this.txtPin);

        this.btnCreate.Location = new System.Drawing.Point(100, 110);
        this.btnCreate.Size = new System.Drawing.Size(100, 30);
        this.btnCreate.Text = "Create Account";
        this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
        this.Controls.Add(this.btnCreate);

        this.ClientSize = new System.Drawing.Size(400, 280);
        this.Text = "Create New Account";
        this.StartPosition = FormStartPosition.CenterParent;
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private void btnCreate_Click(object sender, EventArgs e)
    {
        string fullName = txtFullName.Text.Trim();
        string userName = txtUserName.Text.Trim();
        string pin = txtPin.Text;

        if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(pin))
        {
            MessageBox.Show("Full Name, Username, and PIN cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        bool isValidName = fullName.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        if (!isValidName)
        {
            MessageBox.Show("Full Name can only contain letters and spaces.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        try
        {
            bank.CreateAccount(userName, pin, fullName);
            this.Close();
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show($"Creation Error: {ex.Message}\nPlease try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}