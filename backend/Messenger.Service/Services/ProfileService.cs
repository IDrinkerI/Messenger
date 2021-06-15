using Messenger.Data.Entities;
using Messenger.DataAccess;
using Messenger.Mapper;
using Messenger.Model;
using System.Threading.Tasks;


namespace Messenger.Service
{
    public class ProfileService
    {
        private readonly IRepository<ProfileEntity> profileRepository;

        public ProfileService(IRepository<ProfileEntity> profileRepository) => 
            this.profileRepository = profileRepository;

        public async Task<ProfileModel> GetProfile(int id)
        {
            var entity = await profileRepository.Get(id);
            if (entity is null) { return new ProfileModel(); }

            return entity.ToModel();
        }

        public async Task UpdateProfile(int id, ProfileModel value)
        {
            var entity = value.ToEntity();
            await profileRepository.Update(id, entity);
        }
    }
}
