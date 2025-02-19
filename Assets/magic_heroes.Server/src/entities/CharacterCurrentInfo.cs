using System.Collections.Generic;

namespace magic_heroes.Server.entities
{
    public class CharacterCurrentInfo
    {
        public string Id { get; set; }

        public Player Player { get; set; }

        public Character Character { get; set; }

        public int HealthPoints { get; set; }

        public List<ActiveEffect> ActiveEffects { get; set; }
        
        public List<SpellCurrentCooldown> spellCurrentCooldowns { get; set; }
    }
}