namespace sample_supplies.API.Resolvers
{
    using sample_supplies.Core.Entities;
    using sample_supplies.Core.Repositories;
    using HotChocolate;
    using HotChocolate.Types;
    using System.Threading.Tasks;

    [ExtendObjectType(Name = "Activity")]
    public class ActivityResolver
    {
        // public Task<_activity> GetActivityDrillAsync([Parent] User user, [Service] IActivityRepository activityRepository) =>
        //     activityRepository.GetByIdAsync(user.User_Id.ToString());
    }
}
