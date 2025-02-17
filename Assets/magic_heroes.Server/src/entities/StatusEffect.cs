namespace magic_heroes.Server.entities
{
    public class StatusEffect
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Power { get; set; }

        public int Duration { get; set; }

        public bool Dispellable { get; set; }
    }
}