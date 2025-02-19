namespace magic_heroes.Server.entities
{
    public class ActiveEffect
    {
        public string Id { get; set; }

        public StatusEffect StatusEffect { get; set; }

        public int RemainingDuration { get; set; }

        public int CurrentPower { get; set; }
    }
}