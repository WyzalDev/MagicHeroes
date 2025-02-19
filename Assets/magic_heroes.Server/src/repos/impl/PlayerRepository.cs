using magic_heroes.Server.entities;

namespace magic_heroes.Server.repos.impl
{
    public class PlayerRepository : IRepository<Player, string>
    {
        public Player GetById(string id)
        {
            return Storage.players.Find(p => p.Id == id) ?? null;
        }
        
        public Player GetByInGameId(string inGameId)
        {
            return Storage.players.Find(p => p.InGameId == inGameId) ?? null;
        }

        public bool DeleteById(string id)
        {
            throw new System.NotImplementedException();
        }

        public Player Save(Player entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(string id)
        {
            return GetById(id) != null;
        }
    }
}