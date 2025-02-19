using System.Collections.Generic;

namespace magic_heroes.Server.entities
{
    public class Player
    {
        public string Id { get; set; }

        public string InGameId { get; set; }

        public string Name { get; set; }

        public List<Character> Character { get; set; }
    }
}