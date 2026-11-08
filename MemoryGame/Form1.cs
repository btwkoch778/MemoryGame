namespace MemoryGame;

public partial class Form1 : Form
{
    private readonly MemoryBoard game = new();
    private readonly Color[] cardColors =
    {
        Color.FromArgb(231, 76, 60),
        Color.FromArgb(52, 152, 219),
        Color.FromArgb(46, 204, 113),
        Color.FromArgb(241, 196, 15)
    };

    private int firstCard = -1;
    private int secondCard = -1;

    public Form1()
    {
        InitializeComponent();
        StartGame();
    }

    private void StartGame()
    {
        flipTimer.Stop();
        firstCard = -1;
        secondCard = -1;
        game.Start();
        scoreLabel.Text = "Xal: 0";
        resultLabel.Text = "";

        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].BackColor = Color.WhiteSmoke;
            cards[i].AccessibleName = $"Kart {i + 1}, bağlı";
        }
    }

    private void Card_Click(object? sender, EventArgs e)
    {
        if (sender is not Button card || flipTimer.Enabled || game.Finished)
            return;

        int index = (int)card.Tag!;
        if (index == firstCard || game.IsMatched(index))
            return;

        card.BackColor = cardColors[game.ColorAt(index)];
        card.AccessibleName = $"Kart {index + 1}, açıq";

        if (firstCard == -1)
        {
            firstCard = index;
            resultLabel.Text = "";
            return;
        }

        secondCard = index;
        if (game.TryMatch(firstCard, secondCard))
        {
            scoreLabel.Text = $"Xal: {game.Score}";
            resultLabel.Text = "✅";
            resultLabel.ForeColor = Color.LimeGreen;
            firstCard = -1;
            secondCard = -1;

            if (game.Finished)
            {
                MessageBox.Show(this, $"Oyun bitdi!\nXal: {game.Score}",
                    "Memory Game", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        else
        {
            resultLabel.Text = "❌";
            resultLabel.ForeColor = Color.IndianRed;
            flipTimer.Start();
        }
    }

    private void FlipTimer_Tick(object? sender, EventArgs e)
    {
        flipTimer.Stop();
        cards[firstCard].BackColor = Color.WhiteSmoke;
        cards[secondCard].BackColor = Color.WhiteSmoke;
        cards[firstCard].AccessibleName = $"Kart {firstCard + 1}, bağlı";
        cards[secondCard].AccessibleName = $"Kart {secondCard + 1}, bağlı";
        firstCard = -1;
        secondCard = -1;
    }

    private void NewGameButton_Click(object? sender, EventArgs e)
    {
        StartGame();
    }

    private void ExitButton_Click(object? sender, EventArgs e)
    {
        Close();
    }
}
