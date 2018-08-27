using System.Data.Entity;
using Ambient.Context.Implementations;
using Ambient.Context.Interfaces;
using Context;

namespace Infrastructure
{
    public class WeddingAppScopeLocator : AmbientDbContextLocator, IAmbientDbContextLocator
    {
        public new DbContext Get()
        {
            return base.Get<WeddingAppDbContext>();
        }
    }

}