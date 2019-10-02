using ChatAppAPI.Handlers;
using ChatAppAPI.Models.Entities;
using ChatAppAPI.Models.ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChatAppAPI.Controllers
{
    public class ChatRoomController : ApiController
    {
        ChatRoomHandler chatRoomHandler = new ChatRoomHandler();
        /// <summary>
        /// To get all chat rooms
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       public IHttpActionResult Get(int id)
        {
            List<ChatRoom> chatrooms= new List<ChatRoom>();
            chatrooms = chatRoomHandler.chatRooms(id);

            List<ChatModel> chats = new List<ChatModel>();
            foreach (var item in chatrooms)
            {
                ChatModel chatModel = new ChatModel();
                chatModel.id = item.ChatRoomId;
                if (item.User1 != null)
                {
                    chatModel.Name = item.User1.FullName;
                    chatModel.Picture = item.User1.ProfilePicture;
                    chatModel.Seen = false;
                    chatModel.LastMessage = chatRoomHandler.lastMessage(item.ChatRoomId);
                    chatModel.lastmessageTime = chatRoomHandler.lastMsgTime(chatModel.LastMessage,item.ChatRoomId);
                }
                else
                {
                    chatModel.Name = item.User2.FullName;
                    chatModel.Picture = item.User2.ProfilePicture;
                    chatModel.Seen = false;
                    chatModel.LastMessage = chatRoomHandler.lastMessage(item.ChatRoomId);
                    chatModel.lastmessageTime = chatRoomHandler.lastMsgTime(chatModel.LastMessage, item.ChatRoomId);
                }
                chats.Add(chatModel);
            }

            //return Json(chatrooms);
            return Json(chats);
        }
        
    }
}
