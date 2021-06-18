using Messenger.Data;
using Messenger.Model;
using System.Collections.Generic;
using Xunit;


namespace Messenger.Mapper.Tests
{
    public class ChatMapperTests
    {
        /// <summary>
        /// Проверяем работу метода ToEntity() вызанного на объекте,
        /// который создается конструктором по умолчанию.
        /// </summary>
        [Fact]
        public void ToEntity_DefaulInitModel_DefaultInitEntity()
        {
            var comparer = GetEntityComparer();
            var expected = new ChatEntity();

            var actual = new ChatModel().ToEntity();

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
            var expected = new ChatEntity
            {
                Id       = 1,
                Name     = "ChatName",
                Messages = null
            };

            var model = new ChatModel
            {
                Id   = 1,
                Name = "ChatName"
            };
            var actual = model.ToEntity();

            Assert.Equal(expected, actual, comparer);
        }

        /// <summary>
        /// Проверяем работу метода ToModel() вызанного на объекте, 
        /// который создается конструктором по умолчанию.
        /// </summary>
        [Fact]
        public void ToModel_DefaultInitEntity_DefaultInitModel()
        {
            var comparer = GetModelComparer();
            var expected = new ChatModel();

            var actual = new ChatEntity().ToModel();

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
            var expected = new ChatModel
            {
                Id   = 1,
                Name = "ChatName"
            };

            var entity = new ChatEntity
            {
                Id       = 1,
                Name     = "ChatName",
                Messages = null
            };
            var actual = entity.ToModel();

            Assert.Equal(expected, actual, comparer);
        }


        private IEqualityComparer<ChatEntity> GetEntityComparer() =>
            new ChatEntityComparerNested();

        private IEqualityComparer<ChatModel> GetModelComparer() =>
            new ChatModelComparerNested();


        private class ChatEntityComparerNested : IEqualityComparer<ChatEntity>
        {
            bool IEqualityComparer<ChatEntity>.Equals(ChatEntity x, ChatEntity y) =>
                x.Name == y.Name &&
                x.Id   == y.Id;

            int IEqualityComparer<ChatEntity>.GetHashCode(ChatEntity entity) =>
                entity.Id.GetHashCode();
        }

        private class ChatModelComparerNested : IEqualityComparer<ChatModel>
        {
            bool IEqualityComparer<ChatModel>.Equals(ChatModel x, ChatModel y) =>
                x.Name == y.Name &&
                x.Id   == y.Id;

            int IEqualityComparer<ChatModel>.GetHashCode(ChatModel model) =>
                model.Id.GetHashCode();
        }
    }
}