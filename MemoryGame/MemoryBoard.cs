namespace MemoryGame;

internal class MemoryBoard
{
    private readonly int[] colors = new int[8];
    private readonly bool[] matched = new bool[8];

    public int Score { get; private set; }
    public bool Finished => Score == 4;

    public void Start()
    {
        Score = 0;
        Array.Clear(matched, 0, matched.Length);

        for (int i = 0; i < colors.Length; i++)
            colors[i] = i / 2;

        for (int i = colors.Length - 1; i > 0; i--)
        {
            int j = Random.Shared.Next(i + 1);
            (colors[i], colors[j]) = (colors[j], colors[i]);
        }
    }

    public int ColorAt(int index) => colors[index];
    public bool IsMatched(int index) => matched[index];

    public bool TryMatch(int first, int second)
    {
        if (first == second || matched[first] || matched[second])
            return false;

        if (colors[first] != colors[second])
            return false;

        matched[first] = true;
        matched[second] = true;
        Score++;
        return true;
    }
}
