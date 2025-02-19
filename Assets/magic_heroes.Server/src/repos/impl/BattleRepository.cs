using magic_heroes.Server.entities;

namespace magic_heroes.Server.repos.impl
{
    public class BattleRepository : IRepository<Battle, string>
    {
        
        public Battle GetById(string id)
        {
            return Storage.battles.Find(b => b.Id == id) ?? null;
        }
        
        public Battle GetByInGameId(string inGameId)
        {
            return Storage.battles.Find(b => b.InGameId == inGameId) ?? null;
        }
        
        public bool DeleteById(string id)
        {
            var existBattle = GetById(id);
            return Storage.battles.Remove(existBattle);
        }

        public Battle Save(Battle entity)
        {
            var existBattle = GetByInGameId(entity.InGameId);
            if (existBattle != null)
            {
                if(entity.FirstCharacterCurrentInfo != null) existBattle.FirstCharacterCurrentInfo = entity.FirstCharacterCurrentInfo;
                if(entity.SecondCharacterCurrentInfo != null) existBattle.SecondCharacterCurrentInfo = entity.SecondCharacterCurrentInfo;
                if(entity.Status != BattleStatus.None) existBattle.Status = entity.Status;
                return existBattle;
            }
            else
            {
                Storage.battles.Add(entity);
                return entity;
            }
        }

        public bool Exists(string id)
        {
            return GetById(id) != null;
        }
    }
}