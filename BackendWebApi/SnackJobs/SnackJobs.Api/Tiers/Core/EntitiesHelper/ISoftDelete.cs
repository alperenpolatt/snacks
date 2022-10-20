namespace SnackJobs.Api.Tiers.Core.EntitiesHelper
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
}
