﻿using robot.Models;
using robot.ServiceHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace robot.Controllers
{
    public class ChatController : Controller
    {
        public static ArrayList chatmessage=new ArrayList();
        //Get:Chat/Index
        public ActionResult Index()
        {
            ChatViewModel chatmessage1 = new ChatViewModel();
            chatmessage1.role = "you";
            chatmessage1.content = "欢迎使用智能助手";
            chatmessage1.time = System.DateTime.Now.ToString();
            chatmessage.Add(chatmessage1);
            ViewData["content"] = chatmessage1;
            return View();
        }
        public ActionResult Chat()
        {
            ChatViewModel chatmessage1 = new ChatViewModel();
            chatmessage1.role = "you";
            chatmessage1.content = "欢迎使用智能助手";
            chatmessage1.time = System.DateTime.Now.ToString();
            chatmessage.Add(chatmessage1);
            ViewData["content"] = chatmessage1;
            return View();
        }



        public PartialViewResult GetBack()
        {
            String content = "";
            if (Request.Form["sentinput"].ToString() != null)
            {
                //获取表单
                string formContent = Request.Form["sentinput"];
                String search = formContent.Trim();

                #region 自己的天气查询服务
                ////根据服务抓取查询内容
                //WeatherHelper helper = new WeatherHelper(search);
                //WeatherMessage weathermessage = helper.GetWeather();
                //if (weathermessage.status.Equals("success"))
                //{
                //    WeatherModel weatherModel = weathermessage.results[0];
                //    //信息整理
                //    content = content + weatherModel.currentCity + "\n";
                //    Weather_data[] weather_datas = weatherModel.weather_data;
                //    for (int i = 0; i <= weather_datas.Length - 1; i++)
                //    {
                //        content = content + weather_datas[i].date + "\n";
                //        content = content + weather_datas[i].weather + "\n";
                //        content = content + weather_datas[i].temperature + "\n";
                //        content = content + weather_datas[i].wind + "\n";
                //    }
                //}
                //else
                //{
                //    content = "对不起，没有查询到你要查询的城市";
                //}
                //ChatViewModel chatmessage = new ChatViewModel();
                //chatmessage.role = "you";
                //chatmessage.content = content;
                //chatmessage.time = System.DateTime.Now.ToString();
                //return PartialView(chatmessage);
                #endregion

                

                #region 图灵机器人
                TulingHelper tulinghelper = new TulingHelper(search);

                ChatViewModel chatmessage = new ChatViewModel();
                chatmessage.role = "you";
                chatmessage.content = tulinghelper.GetMessage();
                chatmessage.time = System.DateTime.Now.ToString();
                ViewBag.Message = chatmessage;
                return PartialView();
                #endregion

            }
            return null;
        }


        public string AjaxBack()
        {
            String content = "";
            if (Request.Form["sentinput"].ToString() != null)
            {
                //获取表单
                string formContent = Request.Form["sentinput"];
                String search = formContent.Trim();     
                #region 图灵机器人
                //构造图灵机器人帮助类
                TulingHelper tulinghelper = new TulingHelper(search);
                //获取图灵Api返回消息
                content=tulinghelper.GetMessage();
                return content;
                #endregion

            }
            return null;
        }

        //[HttpPost]
        //public ActionResult Chat()
        //{
            
        //    if (Request.Form["content"].ToString() != null)
        //    {
        //        chatmessage.Add(new ChatViewModel
        //        {
        //            role = "me",
        //            content = Request.Form["content"].ToString(),
        //            time = System.DateTime.Now.ToString()
        //        });
        //        string formContent = Request.Form["content"];
        //        String location = formContent.Trim();
        //        WeatherHelper helper = new WeatherHelper(location);
        //        WeatherMessage weathermessage = helper.GetWeather();
        //        String content = "";
        //        if (weathermessage.status.Equals("success"))
        //        {
        //            WeatherModel weatherModel = weathermessage.results[0];
        //            content = content + weatherModel.currentCity + "\n";
        //            Weather_data[] weather_datas = weatherModel.weather_data;
        //            for (int i = 0; i <= weather_datas.Length - 1; i++)
        //            {
        //                content = content + weather_datas[i].date + "\n";
        //                content = content + weather_datas[i].weather + "\n";
        //                content = content + weather_datas[i].temperature + "\n";
        //                content = content + weather_datas[i].wind + "\n";
        //            }
        //            chatmessage.Add(new ChatViewModel
        //            {
        //                role = "you",
        //                content = content,
        //                time = System.DateTime.Now.ToString()
        //            });
        //        }
        //        else
        //        {
        //            chatmessage.Add(new ChatViewModel
        //            {
        //                role = "you",
        //                content = "对不起，没有查询到你要查询的城市",
        //                time = System.DateTime.Now.ToString()
        //            });
        //        }

        //    }
        //    ViewData["content"] = chatmessage;
        //    return View();
        //}
    }
}