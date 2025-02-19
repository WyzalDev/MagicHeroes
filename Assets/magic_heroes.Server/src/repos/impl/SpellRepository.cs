using System.Collections.Generic;
using magic_heroes.Server.entities;

namespace magic_heroes.Server.repos.impl
{
    public class SpellRepository : IRepository<Spell, string>
    {
        public Spell GetById(string id)
        {
            return Storage.spells.Find(s => s.Id == id) ?? null;
        }

        public List<StatusEffect> GetSpellStatusEffects(string id)
        {
            var existsSpell = GetById(id);
            return existsSpell.StatusEffects;
        }

        public bool DeleteById(string id)
        {
            throw new System.NotImplementedException();
        }

        public Spell Save(Spell entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(string id)
        {
            var existsSpell = GetById(id);
            return existsSpell != null;
        }
    }
}