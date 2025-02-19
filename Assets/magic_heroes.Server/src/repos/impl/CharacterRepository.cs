using magic_heroes.Server.entities;

namespace magic_heroes.Server.repos.impl
{
    public class CharacterRepository : IRepository<Character, string>
    {
        public Character GetById(string id)
        {
            return Storage.characters.Find(c => c.Id == id) ?? null;
        }

        public bool DeleteById(string id)
        {
            throw new System.NotImplementedException();
        }

        public Character Save(Character entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(string id)
        {
            var existsCharacter = GetById(id);
            return existsCharacter != null;
        }
    }
}