using System.Collections.Generic;

namespace magic_heroes.GlobalUtils.HttpApi
{
    public class Response
    {
        public int status { get; set; }
        
        public Dictionary<string, string> fields { get; set; }
    }
}