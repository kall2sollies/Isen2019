using System;

namespace Isen.DotNet.Library.Models
{
    public abstract class BaseModel
    {
        public virtual int Id { get;set; }
        public virtual string Name { get;set; }

        public virtual bool IsNew => Id <= 0;

        public virtual string Display => 
            $"[{this.GetType()}] Id={Id}|Name={Name}";

        public override string ToString() 
            => Display;

        public virtual void Map<T>(T copy)
            where T : BaseModel
        {
            Name = copy.Name;
        }
    }
}