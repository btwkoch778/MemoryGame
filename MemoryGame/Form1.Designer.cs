namespace MemoryGame;

partial class Form1
{
    private System.ComponentModel.IContainer? components = null;
    private Button[] cards = null!;
    private Label scoreLabel = null!;
    private Label resultLabel = null!;
    private Button newGameButton = null!;
    private Button exitButton = null!;
    private System.Windows.Forms.Timer flipTimer = null!;
    private TableLayoutPanel mainLayout = null!;
    private TableLayoutPanel cardLayout = null!;
    private TableLayoutPanel footerLayout = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing)
            components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        cards = new Button[8];
        scoreLabel = new Label();
        resultLabel = new Label();
        newGameButton = new Button();
        exitButton = new Button();
        flipTimer = new System.Windows.Forms.Timer(components);
        mainLayout = new TableLayoutPanel();
        cardLayout = new TableLayoutPanel();
        footerLayout = new TableLayoutPanel();
        SuspendLayout();

        mainLayout.Dock = DockStyle.Fill;
        mainLayout.ColumnCount = 1;
        mainLayout.RowCount = 2;
        mainLayout.Padding = new Padding(45, 20, 45, 20);
        mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));

        cardLayout.Dock = DockStyle.Fill;
        cardLayout.ColumnCount = 4;
        cardLayout.RowCount = 2;
        cardLayout.Margin = new Padding(0);
        for (int col = 0; col < 4; col++)
            cardLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        for (int row = 0; row < 2; row++)
            cardLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

        for (int i = 0; i < cards.Length; i++)
        {
            Button card = new Button();
            card.Name = $"card{i + 1}";
            card.Dock = DockStyle.Fill;
            card.Margin = new Padding(25, 16, 25, 42);
            card.BackColor = Color.WhiteSmoke;
            card.FlatStyle = FlatStyle.Flat;
            card.FlatAppearance.BorderSize = 1;
            card.FlatAppearance.BorderColor = Color.LightGray;
            card.FlatAppearance.MouseOverBackColor = Color.Empty;
            card.FlatAppearance.MouseDownBackColor = Color.Empty;
            card.UseVisualStyleBackColor = false;
            card.Cursor = Cursors.Hand;
            card.Tag = i;
            card.TabIndex = i;
            card.Click += Card_Click;
            cards[i] = card;
            cardLayout.Controls.Add(card, i % 4, i / 4);
        }

        footerLayout.Dock = DockStyle.Fill;
        footerLayout.ColumnCount = 4;
        footerLayout.RowCount = 1;
        footerLayout.Margin = new Padding(0);
        footerLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        for (int i = 0; i < 4; i++)
            footerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));

        scoreLabel.Name = "scoreLabel";
        scoreLabel.Text = "Xal: 0";
        scoreLabel.Dock = DockStyle.Fill;
        scoreLabel.TextAlign = ContentAlignment.MiddleLeft;
        scoreLabel.Font = new Font("Segoe UI", 23F, FontStyle.Bold);
        scoreLabel.ForeColor = Color.White;
        scoreLabel.Margin = new Padding(16, 0, 0, 0);

        resultLabel.Name = "resultLabel";
        resultLabel.Dock = DockStyle.Fill;
        resultLabel.TextAlign = ContentAlignment.MiddleCenter;
        resultLabel.Font = new Font("Segoe UI Emoji", 38F);
        resultLabel.AccessibleName = "Nəticə";

        newGameButton.Name = "newGameButton";
        newGameButton.Text = "Yeni oyun";
        newGameButton.Dock = DockStyle.Fill;
        newGameButton.Margin = new Padding(25, 22, 25, 14);
        newGameButton.FlatStyle = FlatStyle.Flat;
        newGameButton.FlatAppearance.BorderSize = 2;
        newGameButton.FlatAppearance.BorderColor = Color.White;
        newGameButton.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
        newGameButton.ForeColor = Color.White;
        newGameButton.Cursor = Cursors.Hand;
        newGameButton.TabIndex = 8;
        newGameButton.Click += NewGameButton_Click;

        exitButton.Name = "exitButton";
        exitButton.Text = "Çıxış";
        exitButton.Dock = DockStyle.Fill;
        exitButton.Margin = new Padding(25, 22, 25, 14);
        exitButton.FlatStyle = FlatStyle.Flat;
        exitButton.FlatAppearance.BorderSize = 2;
        exitButton.FlatAppearance.BorderColor = Color.White;
        exitButton.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
        exitButton.ForeColor = Color.White;
        exitButton.Cursor = Cursors.Hand;
        exitButton.TabIndex = 9;
        exitButton.Click += ExitButton_Click;

        flipTimer.Interval = 850;
        flipTimer.Tick += FlipTimer_Tick;

        footerLayout.Controls.Add(scoreLabel, 0, 0);
        footerLayout.Controls.Add(resultLabel, 1, 0);
        footerLayout.Controls.Add(newGameButton, 2, 0);
        footerLayout.Controls.Add(exitButton, 3, 0);
        mainLayout.Controls.Add(cardLayout, 0, 0);
        mainLayout.Controls.Add(footerLayout, 0, 1);
        Controls.Add(mainLayout);

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.Black;
        ClientSize = new Size(1100, 620);
        MinimumSize = new Size(850, 520);
        StartPosition = FormStartPosition.CenterScreen;
        Name = "Form1";
        Text = "Memory Game";
        ResumeLayout(false);
    }
}
