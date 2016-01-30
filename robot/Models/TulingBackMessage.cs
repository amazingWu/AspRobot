using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace robot.Models
{
    //图灵回复消息的父类
    public class TulingBackMessage
    {
        public long code { get; set; }
        public string text { get; set; }
    }
    //文本类
    public class TextMessage : TulingBackMessage
    {
    }


    //新闻类
    public class NewsMessage : TulingBackMessage
    {
        public News[] list { get; set; }//新闻列表
    }
    public class News
    {
        public string article { get; set; }//标题
        public string source { get; set; }//来源：如：网易新闻
        public string icon { get; set; }//缩略图
        public string detailurl { get; set; }//详细列表
    }

    //链接类
    public class LinkMessage : TulingBackMessage
    {
        public string url { get; set; }//链接地址
    }

    //菜谱类
    public class FoodMessage : TulingBackMessage
    {
        public Food[] list { get; set; }//菜列表
    }
    public class Food
    {
        public string name { get; set; }//菜名
        public string icon { get; set; }//缩略图
        public string info { get; set; }//做法
        public string detailurl { get; set; }//详细地址
    }

}