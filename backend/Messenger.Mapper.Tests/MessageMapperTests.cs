using Messenger.Data;
using Messenger.Model;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xunit;


namespace Messenger.Mapper.Tests
{
    public class MessageMapperTests
    {
        /// <summary>
        /// Проверяем работу метода ToEntity() вызанного на объекте,
        /// который создается конструктором по умолчанию.
        /// </summary>
        [Fact]
        public void ToEntity_DefaulInitModel_DefaultInitEntity()
        {
            var comparer = GetEntityComparer();
            var expected = new MessageEntity();

            var model  = new MessageModel();
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
            var expected = new MessageEntity
            {
                Id        = 1,
                Text      = "test text",
                ChatId    = 1,
                Chat      = null,
                ProfileId = 1,
                Profile   = null
            };

            var model = new MessageModel
            {
                Id        = 1,
                Text      = "test text",
                ChatId    = 1,
                ProfileId = 1,
                Nickname  = null,
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
            var expected = new MessageModel();

            var entity = new MessageEntity();
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
            var expected = new MessageModel
            {
                Id        = 1,
                Text      = "test text",
                ChatId    = 1,
                ProfileId = 1,
                Nickname  = "nickname"
            };

            var entity = new MessageEntity
            {
                Id        = 1,
                Text      = "test text",
                ChatId    = 1,
                Chat      = null,
                ProfileId = 1,
                Profile   = new ProfileEntity { Nickname = "nickname" }
            };
            var actual = entity.ToModel();

            Assert.Equal(expected, actual, comparer);
        }


        private IEqualityComparer<MessageEntity> GetEntityComparer() =>
            new MessageEntityComparerNested();

        private IEqualityComparer<MessageModel> GetModelComparer() =>
            new MessageModelComparerNested();


        private class MessageEntityComparerNested : IEqualityComparer<MessageEntity>
        {
            public bool Equals(MessageEntity x, MessageEntity y) =>
                x.Id        == y.Id &&
                x.Text      == y.Text &&
                x.ChatId    == y.ChatId &&
                x.Chat      == y.Chat &&
                x.Profile   == y.Profile &&
                x.ProfileId == y.ProfileId;

            public int GetHashCode([DisallowNull] MessageEntity obj) =>
                obj.Id.GetHashCode();
        }

        private class MessageModelComparerNested : IEqualityComparer<MessageModel>
        {
            public bool Equals(MessageModel x, MessageModel y) =>
                x.Id        == y.Id &&
                x.Text      == y.Text &&
                x.ChatId    == y.ChatId &&
                x.ProfileId == y.ProfileId &&
                x.Nickname  == y.Nickname;

            public int GetHashCode([DisallowNull] MessageModel obj) =>
                obj.Id.GetHashCode();
        }
    }
}