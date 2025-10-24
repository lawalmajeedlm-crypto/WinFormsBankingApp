public partial class MainForm : Form
{
    private const string Filename = "bank_background.jpg";
    private static Bank bank = new Bank();

    private Button btnCreateAccount;
    private Button btnLogin;
    private Button btnExit;

    public MainForm()
    {
        Text = "EMJAY MICROFINANCE BANK";
        StartPosition = FormStartPosition.CenterScreen;
        Size = new Size(600, 400);
        BackColor = Color.FromArgb(245, 245, 220); 
        Font = new Font("Tahoma", 10F, FontStyle.Regular);

        var titleLabel = new Label
        {
            Text = " WELCOME TO EMJAY MICROFINANCE BANK \n  *Secure and Reliable Banking Solutions* ",  
            Font = new Font("Tahoma", 16F, FontStyle.Bold),
            ForeColor = Color.OrangeRed,
            AutoSize = true,
            Location = new Point((ClientSize.Width - 400) / 2, 20)  
        };
        Controls.Add(titleLabel);  

        InitializeComponent();
    }

    private void InitializeComponent()
    {
        this.btnCreateAccount = new System.Windows.Forms.Button();
        this.btnLogin = new System.Windows.Forms.Button();
        this.btnExit = new System.Windows.Forms.Button();
        this.SuspendLayout();

        
        this.BackColor = Color.FromArgb(245, 245, 220); 
        this.Font = new Font("Tahoma", 10F, FontStyle.Regular);

        this.btnCreateAccount.Location = new System.Drawing.Point(50, 80);  
        this.btnCreateAccount.Size = new System.Drawing.Size(180, 40);
        this.btnCreateAccount.Text = "Create New Account";
        this.btnCreateAccount.BackColor = Color.Orange; 
        this.btnCreateAccount.ForeColor = Color.White;
        this.btnCreateAccount.FlatStyle = FlatStyle.Flat;
        this.btnCreateAccount.FlatAppearance.BorderSize = 0;
        this.btnCreateAccount.Font = new Font("Tahoma", 11F, FontStyle.Bold);
        this.btnCreateAccount.Click += new System.EventHandler(this.btnCreateAccount_Click);
        this.Controls.Add(this.btnCreateAccount);

        this.btnLogin.Location = new System.Drawing.Point(50, 130);  
        this.btnLogin.Size = new System.Drawing.Size(180, 40);
        this.btnLogin.Text = "Login to Existing Account";
        this.btnLogin.BackColor = Color.Gold; 
        this.btnLogin.ForeColor = Color.Black;
        this.btnLogin.FlatStyle = FlatStyle.Flat;
        this.btnLogin.FlatAppearance.BorderSize = 0;
        this.btnLogin.Font = new Font("Tahoma", 11F, FontStyle.Bold);
        this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
        this.Controls.Add(this.btnLogin);

        this.btnExit.Location = new System.Drawing.Point(50, 180); 
        this.btnExit.Size = new System.Drawing.Size(180, 40);
        this.btnExit.Text = "Exit Application";
        this.btnExit.BackColor = Color.DarkGray; 
        this.btnExit.ForeColor = Color.White;
        this.btnExit.FlatStyle = FlatStyle.Flat;
        this.btnExit.FlatAppearance.BorderSize = 0;
        this.btnExit.Font = new Font("Tahoma", 10F, FontStyle.Regular);
        this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
        this.Controls.Add(this.btnExit);

        this.ClientSize = new System.Drawing.Size(600, 400);
        this.Text = "Emjay Bank - Main Menu";
        this.StartPosition = FormStartPosition.CenterScreen;

        BackgroundImage = Image.FromFile("C:\\Users\\HP\\Desktop\\bank3.jpg"); 
        this.BackgroundImageLayout = ImageLayout.Stretch;

        this.ResumeLayout(false);
    }

    private void btnCreateAccount_Click(object sender, EventArgs e)
    {
        using (var createForm = new CreateAccountForm(bank))
        {
            createForm.ShowDialog();
        }
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        using (var loginForm = new LoginForm(bank))
        {
            loginForm.ShowDialog();
        }
    }

    private void btnExit_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Application is shutting down. All in-memory data has been lost.", "Shutdown", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        Application.Exit();
    }
}