using Messenger.Data;
using Messenger.Model;


namespace Messenger.Mapper
{
    public static class ProfileMapper
    {
        public static ProfileEntity ToEntity(this ProfileModel profileModel)
        {
            var entity = new ProfileEntity
            {
                Id        = profileModel.Id,
                Nickname  = profileModel.Nickname,
                FirstName = profileModel.FirstName,
                LastName  = profileModel.LastName,
            };

            return entity;
        }

        public static ProfileModel ToModel(this ProfileEntity profileEntity)
        {
            var model = new ProfileModel
            {
                Id        = profileEntity.Id,
                Nickname  = profileEntity.Nickname,
                FirstName = profileEntity.FirstName,
                LastName  = profileEntity.LastName,
            };

            return model;
        }
    }
}
