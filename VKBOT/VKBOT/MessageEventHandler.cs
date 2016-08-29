using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using VkNet;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace VKBOT
{
    class MessageEventHandler
    {
        static public uint totalMessages = 0;
        VkApi _api = new VkApi();
        IReadOnlyCollection<Message> _oldMessages = null;

        public MessageEventHandler(VkApi api)
        {
            _api = api;
        }

        public Tuple<Message, bool> ReadMessage()
        {
            recheck:
            Thread.Sleep(2000);
            MessagesGetObject Messages = _api.Messages.GetDialogs(new MessagesDialogsGetParams() { Count = 20, Unread = true, });
            totalMessages = Messages.TotalCount;
            //totalUnreadMessages = Messages.Unread.Value;
            IReadOnlyCollection<Message> newMessages = Messages.Messages;
            if (_oldMessages == null) _oldMessages = newMessages;
            if (_oldMessages != newMessages)
            {
                foreach (var Message in newMessages)
                {
                    if (!_oldMessages.Contains(Message))
                    {
                        if (Message.Body.ToLower().StartsWith("!bot"))
                        {
                            _oldMessages = newMessages;
                            bool IsChat = false;
                            try { if (!string.IsNullOrEmpty(Message.ChatId.Value.ToString())) IsChat = true; } catch (Exception) { }
                            return Tuple.Create<Message, bool>(Message, IsChat);
                        }
                    }
                }
            }
            goto recheck;
        }
    }
}
