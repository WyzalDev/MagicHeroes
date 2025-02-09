using System.Collections.Generic;

namespace magic_heroes.GlobalUtils.HttpApi
{
    public class Request
    {
        public string name { get; set; }
        
        public Dictionary<string, string> fields { get; set; }
        
    }
}