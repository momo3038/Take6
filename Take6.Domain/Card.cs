namespace Take6.Domain
{
    public record Card
    {
        public int Value { get; init; }
        public Card(int value)
        {
            CattleHeads = GetScore(value);
            Value = value;
        }

        public int GetScore(int value) =>
            value switch
            {
                55 => 7,
                _ when value % 11 == 0 => 5,
                _ when value % 10 == 0 => 3,
                _ when value % 5 == 0 => 2,
                _ => 1
            };

        public int CattleHeads { get; init; }

        public static Card operator -(Card a, Card b) => new(a.Value - b.Value);
    }
}