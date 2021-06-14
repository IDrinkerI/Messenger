using Messenger.Data.Entities;
using Messenger.DataAccess;
using Messenger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.Mapper;


namespace Messenger.Service
{
    public class ProfileService
    {
        private readonly IRepository<ProfileEntity> profileRepository;

        public ProfileService(IRepository<ProfileEntity> profileRepository)
        {
            this.profileRepository = profileRepository;
        }

        public async Task<ProfileModel> GetProfile(int id)
        {
            var entity = await profileRepository.Get(id);
            return entity.ToModel();
        }

        public async Task UpdateProfile(int id, ProfileModel value)
        {
            var entity = value.ToEntity();
            await profileRepository.Update(id, entity);
        }
    }
}
