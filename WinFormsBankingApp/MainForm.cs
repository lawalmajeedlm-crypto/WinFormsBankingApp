public partial class MainForm : Form
{
    private static Bank bank = new Bank();

    private Button btnCreateAccount;
    private Button btnLogin;
    private Button btnExit;

    public MainForm()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        this.btnCreateAccount = new System.Windows.Forms.Button();
        this.btnLogin = new System.Windows.Forms.Button();
        this.btnExit = new System.Windows.Forms.Button();
        this.SuspendLayout();

        this.btnCreateAccount.Location = new System.Drawing.Point(50, 50);
        this.btnCreateAccount.Size = new System.Drawing.Size(180, 40);
        this.btnCreateAccount.Text = "Create New Account";
        this.btnCreateAccount.Click += new System.EventHandler(this.btnCreateAccount_Click);
        this.Controls.Add(this.btnCreateAccount);

        this.btnLogin.Location = new System.Drawing.Point(50, 100);
        this.btnLogin.Size = new System.Drawing.Size(180, 40);
        this.btnLogin.Text = "Login to Existing Account";
        this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
        this.Controls.Add(this.btnLogin);

        this.btnExit.Location = new System.Drawing.Point(50, 150);
        this.btnExit.Size = new System.Drawing.Size(180, 40);
        this.btnExit.Text = "Exit Application";
        this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
        this.Controls.Add(this.btnExit);

        this.ClientSize = new System.Drawing.Size(280, 240);
        this.Text = "Emjay Bank - Main Menu";
        this.StartPosition = FormStartPosition.CenterScreen;
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
