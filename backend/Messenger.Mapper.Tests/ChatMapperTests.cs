using Xunit;
using Messenger.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.Data.Entities;
using Messenger.Model;
using Newtonsoft.Json;
using System.Diagnostics;


namespace Messenger.Mapper.Tests
{
    public class ChatMapperTests
    {
        [Fact]
        public void ToEntity_DefaulInitModel_DefaultInitEntity()
        {
            var comparer = GetChatEntityComparer();
            var expected = new ChatEntity();

            var model = new ChatModel();
            var actual = model.ToEntity();

            Assert.Equal(expected, actual, comparer);
        }



        [Fact]
        public void ToModel_DefaultInitEnitity_DefaultInitModel()
        {
            var comparer = GetChatModelComparer();
            var expected = new ChatModel();

            var entity = new ChatEntity();
            var actual = entity.ToModel();

            Assert.Equal(expected, actual, comparer);
        }


        private IEqualityComparer<ChatEntity> GetChatEntityComparer() =>
            new ChatEntityComparerNested();

        private IEqualityComparer<ChatModel> GetChatModelComparer() =>
            new ChatModelComparerNested();


        private class ChatEntityComparerNested : IEqualityComparer<ChatEntity>
        {
            bool IEqualityComparer<ChatEntity>.Equals(ChatEntity x, ChatEntity y) =>
                x.Name == y.Name && x.Id == y.Id;

            int IEqualityComparer<ChatEntity>.GetHashCode(ChatEntity entity) =>
                entity.Name.GetHashCode() + entity.Id.GetHashCode();
        }

        private class ChatModelComparerNested : IEqualityComparer<ChatModel>
        {
            bool IEqualityComparer<ChatModel>.Equals(ChatModel x, ChatModel y) =>
                x.Name == y.Name && x.Id == y.Id;

            int IEqualityComparer<ChatModel>.GetHashCode(ChatModel model) =>
                model.Name.GetHashCode() + model.Id.GetHashCode();
        }
    }
}