using System;

namespace ZMG.Blog.Core.Models
{
    public class Model
    {
        public string ID{get;set;} 
        public DateTime Created {get;set;} = DateTime.Now; 
        public DateTime Updated {get;set;} = DateTime.Now;
        public bool Deleted {get;set;} = false;
    }
}