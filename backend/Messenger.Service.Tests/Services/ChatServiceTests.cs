using Messenger.Data;
using Messenger.DataAccess;
using Messenger.Mapper;
using Messenger.Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;


namespace Messenger.Service.Tests
{
    public class ChatServiceTests
    {
        #region AddChat

        [Fact]
        public async void AddChat_Null_ThrowArgumentNullException()
        {
            IChatService chatService = new ChatService(null, null);
            async Task testCode() => await chatService.AddChat(null);

            await Assert.ThrowsAsync<ArgumentNullException>(testCode);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public async void AddChat_EmptyName_ThrowArgumentException(string name)
        {
            ChatModel newChat = new() { Name = name };

            IChatService chatService = new ChatService(null, null);
            async Task testCode() => await chatService.AddChat(newChat);

            await Assert.ThrowsAsync<ArgumentException>(testCode);
        }

        #endregion


        #region GetChats

        [Theory]
        [MemberData(nameof(GetTestChats))]
        public async void GetChats_HasChats(List<ChatEntity> chats)
        {
            List<ChatModel> expected = new();
            ChatModelComparerNested comparer = new();
            chats.ForEach(c => expected.Add(c.ToModel()));

            var chatRepository = Mock.Of<IChatRepository<ChatEntity>>(rep =>
                    rep.GetChats(It.IsAny<int>()) == Task.FromResult(chats as IEnumerable<ChatEntity>));
            var authService = Mock.Of<IAuthService>(serv => serv.CurrentUserId == 0);

            IChatService chatService = new ChatService(chatRepository, authService);
            IEnumerable<ChatModel> actual = await chatService.GetChats();

            Assert.Equal(expected, actual, comparer);
        }

        [Fact]
        public async void GetChats_DontHaveChats()
        {
            List<ChatModel> expected = new();
            var chatRepository = Mock.Of<IChatRepository<ChatEntity>>(rep =>
                    rep.GetChats(It.IsAny<int>()) == Task.FromResult<IEnumerable<ChatEntity>>(null));
            var authService = Mock.Of<IAuthService>(serv => serv.CurrentUserId == 0);

            IChatService chatService = new ChatService(chatRepository, authService);
            var actual = await chatService.GetChats();

            Assert.Equal(expected, actual);
        }

        #endregion


        public static IEnumerable<object[]> GetTestChats()
        {
            yield return new object[] {new List<ChatEntity>
                {
                    new ChatEntity{ Id = 1, Name = "SomeName 1" },
                    new ChatEntity{ Id = 2, Name = "SomeName 2" },
                    new ChatEntity{ Id = 3, Name = "SomeName 3" },
                }
            };
            yield return new object[] { new List<ChatEntity> { new ChatEntity() } };
        }

        private class ChatModelComparerNested : IEqualityComparer<ChatModel>
        {
            bool IEqualityComparer<ChatModel>.Equals(ChatModel x, ChatModel y) =>
                x.Name == y.Name &&
                x.Id   == y.Id;

            int IEqualityComparer<ChatModel>.GetHashCode([DisallowNull] ChatModel chatModel) =>
                chatModel.Id.GetHashCode();
        }
    }
}
