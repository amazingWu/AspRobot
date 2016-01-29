using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace robot.Models
{
    public class ChatViewModel
    {
        public string role { get; set; }//信息的角色属性
        public string content { get; set; }//信息的内容
        public string time { get; set; }//发送时间
    }
}