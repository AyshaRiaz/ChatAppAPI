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
    public class MessagesController : ApiController
    {
        /// <summary>
        /// get Message list
        /// </summary>
        MessageHandler messageHandler = new MessageHandler();
        public IHttpActionResult Get(int myId,int roomId)
        {
            List<Message> msglist = new List<Message>();
            msglist=messageHandler.GetMessages(roomId);

            List<MessageModel> messages = new List<MessageModel>();
            foreach (var item in msglist)
            {
                if (item != null)
                {
                    MessageModel msgModel = new MessageModel();
                    msgModel.Message = item.text;
                    msgModel.DateSent = item.MessageTime;
                    if (item.from.UserId == myId)
                    {
                        msgModel.Status = "sent";
                        msgModel.From = myId;
                        msgModel.To = item.To.UserId;
                    }
                    else
                    {
                        msgModel.Status = "recieved";
                        msgModel.From = item.from.UserId;
                        msgModel.To = myId;
                    }
                    messages.Add(msgModel);
                }
            }

            return Json(messages);
        }

        /// <summary>
        /// SendMessage
        /// </summary>
        /// <returns></returns>
       public IHttpActionResult Post(MessageModel message)
        {
            int roomId = message.To;
            messageHandler.AddMessage(message,roomId);
            return null;
        }

        /// <summary>
        /// RecieveMessage
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get(int roomId,int myId,string f)
        {
            Message msg = new Message();
            msg= messageHandler.lastRcvMsg(roomId, myId);
            MessageModel messageModel = new MessageModel();
            messageModel.DateSent = msg.MessageTime;
            messageModel.From = msg.from.UserId;
            messageModel.To = msg.To.UserId;
            messageModel.Message = msg.text;
            messageModel.Status = "recieved";

            return Json(messageModel);
        }
    }
}
