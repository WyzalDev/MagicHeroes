namespace magic_heroes.Server.entities
{
    public class SpellCurrentCooldown
    {
        public Spell Spell { get; set; }
        
        public int Cooldown { get; set; }
    }
}