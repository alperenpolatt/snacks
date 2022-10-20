using System;

namespace SnackJobs.Api.Tiers.Core.EntitiesHelper
{
    [Serializable]
    public class Key<T>
    {
        public T Id { get; set; }
        public override string ToString()
        {
            return $"[ENTITY: {GetType().Name}] Id = {Id}";
        }
    }
}
