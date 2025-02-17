namespace magic_heroes.Server.entities
{
    public class Battle
    {
        public string Id { get; set; }
        public string InGameId { get; set; }
        public Player FirstPlayer { get; set; }
        public Player SecondPlayer { get; set; }

        public CharacterCurrentInfo FirstCharacterCurrentInfo { get; set; }

        public CharacterCurrentInfo SecondCharacterCurrentInfo { get; set; }
        public BattleStatus Status { get; set; }
    }

    public enum BattleStatus
    {
        WaitForStart = 0,
        InProcess = 1,
        Passed = 2
    }
}