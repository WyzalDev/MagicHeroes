using System;
using System.Collections.Generic;

namespace magic_heroes.Server.entities
{
    public class Spell
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Damage { get; set; }

        public int Cooldown { get; set; }

        public TargetType Target { get; set; }

        public List<StatusEffect> StatusEffects { get; set; }
    }

    [Flags]
    public enum TargetType
    {
        All = 0,
        Enemy = 1,
        Self = 2
    }
}