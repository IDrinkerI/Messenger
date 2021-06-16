using Messenger.Data.Entities;
using Messenger.Model;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xunit;


namespace Messenger.Mapper.Tests
{
    public class ProfileMapperTests
    {
        /// <summary>
        /// Проверяем работу метода ToEntity() вызанного на объекте,
        /// который создается конструктором по умолчанию.
        /// </summary>
        [Fact]
        public void ToEntity_DefaulInitModel_DefaultInitEntity()
        {
            var comparer = GetEntityComparer();
            var expected = new ProfileEntity();

            var model  = new ProfileModel();
            var actual = model.ToEntity();

            Assert.Equal(expected, actual, comparer);
        }

        /// <summary>
        /// Проверяем работу метода ToEntity() вызанного на объекте, 
        /// у когорого проинициализированы свойства.
        /// </summary>
        [Fact]
        public void ToEntity_InitModel_InitEntity()
        {
            var comparer = GetEntityComparer();
            var expected = new ProfileEntity
            {
                Id        = 1,
                Nickname  = "Some nickname",
                FirstName = "Some firstname",
                LastName  = "Some lastname"
            };

            var model = new ProfileModel
            {
                Id        = 1,
                Nickname  = "Some nickname",
                FirstName = "Some firstname",
                LastName  = "Some lastname"
            };
            var actual = model.ToEntity();

            Assert.Equal(expected, actual, comparer);
        }

        /// <summary>
        /// Проверяем работу метода ToModel() вызанного на объекте,
        /// который создается конструктором по умолчанию.
        /// </summary>
        [Fact]
        public void ToModel_DefaulInitEntity_DefaultInitModel()
        {
            var comparer = GetModelComparer();
            var expected = new ProfileModel();

            var entity = new ProfileEntity();
            var actual = entity.ToModel();

            Assert.Equal(expected, actual, comparer);
        }

        /// <summary>
        /// Проверяем работу метода ToModel() вызанного на объекте, 
        /// у когорого проинициализированы свойства.
        /// </summary>
        [Fact]
        public void ToModel_InitEntity_InitModel()
        {
            var comparer = GetModelComparer();
            var expected = new ProfileModel
            {
                Id        = 1,
                Nickname  = "Some nickname",
                FirstName = "Some firstname",
                LastName  = "Some lastname"
            };

            var entity = new ProfileEntity
            {
                Id        = 1,
                Nickname  = "Some nickname",
                FirstName = "Some firstname",
                LastName  = "Some lastname"
            };
            var actual = entity.ToModel();

            Assert.Equal(expected, actual, comparer);
        }


        private IEqualityComparer<ProfileEntity> GetEntityComparer() =>
            new ProfileEntityComparerNested();

        private IEqualityComparer<ProfileModel> GetModelComparer() =>
            new ProfileModelComparerNested();


        private class ProfileEntityComparerNested : IEqualityComparer<ProfileEntity>
        {
            public bool Equals(ProfileEntity x, ProfileEntity y) =>
                x.Id        == y.Id &&
                x.Nickname  == y.Nickname &&
                x.FirstName == y.FirstName &&
                x.LastName  == y.LastName;

            public int GetHashCode([DisallowNull] ProfileEntity obj) =>
                obj.Id.GetHashCode();
        }

        private class ProfileModelComparerNested : IEqualityComparer<ProfileModel>
        {
            public bool Equals(ProfileModel x, ProfileModel y) =>
                x.Id        == y.Id &&
                x.Nickname  == y.Nickname &&
                x.FirstName == y.FirstName &&
                x.LastName  == y.LastName;

            public int GetHashCode([DisallowNull] ProfileModel obj) =>
                obj.Id.GetHashCode();
        }
    }
}