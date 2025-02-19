using magic_heroes.Server.entities;

namespace magic_heroes.Server.repos.impl
{
    public class StatusEffectRepository : IRepository<StatusEffect, string>
    {
        public StatusEffect GetById(string id)
        {
            return Storage.statusEffects.Find(s => s.Id == id) ?? null;
        }

        public bool DeleteById(string id)
        {
            throw new System.NotImplementedException();
        }

        public StatusEffect Save(StatusEffect entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(string id)
        {
            var existsStatusEffect = GetById(id);
            return existsStatusEffect != null;
        }
    }
}