namespace magic_heroes.Server.entities
{
    public class Battle
    {
        public string Id { get; set; }
        public string InGameId { get; set; }
        public CharacterCurrentInfo FirstCharacterCurrentInfo { get; set; }
        public CharacterCurrentInfo SecondCharacterCurrentInfo { get; set; }
        public BattleStatus Status { get; set; }
    }

    public enum BattleStatus
    {
        None = 0,
        WaitForStart = 1,
        InProcess = 2,
        Passed = 3
    }
}