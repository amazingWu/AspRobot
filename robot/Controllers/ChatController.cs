using robot.Models;
using robot.ServiceHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace robot.Controllers
{
    public class ChatController : Controller
    {
        //有输入框界面控制器
        //Get:Chat/Index
        public ActionResult Index()
        {
            ChatViewModel chatmessage1 = new ChatViewModel();
            chatmessage1.role = "you";
            chatmessage1.content = "欢迎使用智能助手";
            chatmessage1.time = System.DateTime.Now.ToString();
            ViewData["content"] = chatmessage1;
            return View();
        }
        //无输入框聊天界面控制器
        public ActionResult Chat()
        {
            ChatViewModel chatmessage1 = new ChatViewModel();
            chatmessage1.role = "you";
            chatmessage1.content = "欢迎使用智能助手";
            chatmessage1.time = System.DateTime.Now.ToString();
            ViewData["content"] = chatmessage1;
            return View();
        }
        //无输入框聊天界面控制器
        public ActionResult Robot()
        {
            ChatViewModel chatmessage1 = new ChatViewModel();
            chatmessage1.role = "you";
            chatmessage1.content = "欢迎使用智能助手";
            chatmessage1.time = System.DateTime.Now.ToString();
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
                //得到用户唯一sessionid
                String uid = HttpContext.Session["user"].ToString();

                #region 图灵机器人
                TulingHelper tulinghelper = new TulingHelper(search,uid);
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

        //javascript异步调用图灵机器人
        public string AjaxBack()
        {
            String content = "";
            if (Request.Form["sentinput"].ToString() != null)
            {
                //获取表单
                string formContent = Request.Form["sentinput"];
                String search = formContent.Trim();
                //得到用户唯一sessionid
                String uid = HttpContext.Session["user"].ToString();
                #region 图灵机器人
                //构造图灵机器人帮助类
                TulingHelper tulinghelper = new TulingHelper(search,uid);
                //获取图灵Api返回消息
                content =tulinghelper.GetMessage();
                return content;
                #endregion

            }
            return null;
        }

        //javascript异步调用api.ai
        public string RobotAjaxBack()
        {
            String content = "";
            if (Request.Form["sentinput"].ToString() != null)
            {
                //获取表单
                string formContent = Request.Form["sentinput"];
                String search = formContent.Trim();
                //得到用户唯一sessionid
                String uid = HttpContext.Session["user"].ToString();
                #region 测试api.ai的post请求
                //构造要提交的请求的参数
                ApiJson apijson = new ApiJson();
                apijson.query = new List<string> { search };
                apijson.sessionid = uid;
                apijson.v = "20160330";
                apijson.lang = "ZH-CN";
                apijson.resetContexts = false;
                //构造Api.ai帮助类
                ApiHelper apihelper = new ApiHelper(apijson.ToString());
                //获取post请求，并把返回的json封装成对象
                string result = apihelper.GetApiPost();
                return result;
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