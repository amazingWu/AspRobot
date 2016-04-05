using Newtonsoft.Json;
using robot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace robot.ServiceHelper
{
    
    public class TulingHelper
    {
        //图铃机器人api地址
        private const string TUPING_URL = "http://www.tuling123.com/openapi/api";
        //产品ak
        private const string AK = "a05e266389bc8d5f03f8e055da1ea825";
        //userid，要保证不唯一
        private string userid = "";
        //要发送给图灵的信息
        private string info { get; set; }
        //初始化构造,用来传递进info
        public TulingHelper(string info,string sessionid)
        {
            userid = sessionid;
            this.info = info;
        }

        /// <summary>
        /// 构造post请求，并得到返回值
        /// </summary>
        /// <returns></returns>
        public string getHttp()
        {
            HttpHelper httphelper = new HttpHelper();
            List<KeyValuePair<string, string>> parms=new List<KeyValuePair<string, string>>();
            parms.Add(new KeyValuePair<string, string>("key", AK));
            parms.Add(new KeyValuePair<string, string>("info", info));
            parms.Add(new KeyValuePair<string, string>("userid", userid));
            return httphelper.HttpPost(TUPING_URL,parms);
        }

        /// <summary>
        /// 根据图灵Api的返回结果将结果封装成html的文本内容，以方便添加进网页中
        /// </summary>
        /// <returns></returns>
        public string GetMessage()
        {
            string content = getHttp();
            TulingBackMessage tulingback = JsonConvert.DeserializeObject<TulingBackMessage>(content);
            switch (tulingback.code)
            {
                //文本类
                case 100000:
                    TextMessage textmessage=JsonConvert.DeserializeObject<TextMessage>(content);
                    return textmessage.text;
                    break; 
                //链接类
                case 200000:
                    LinkMessage linkmessage = JsonConvert.DeserializeObject<LinkMessage>(content);
                    return linkmessage.text + "<a href="+linkmessage.url+">" + linkmessage.url + "</a>";
                    break;
                //新闻类
                case 302000:
                    NewsMessage newsmessage = JsonConvert.DeserializeObject<NewsMessage>(content);
                    #region 目标html样式
                    /*
                    <div class="news">
				        <img src="news.jpg"/>
				        <section>
					        <p>大苏打撒大飒飒撒撒旦飒飒阿斯达克拉都拉多久啊了巨大倒萨大大阿瓦蒂</p>
					        <p>网易新闻</p>
				        </section>
				        <section>
					        <p>大苏打撒大飒飒撒撒旦飒飒阿斯达克拉都拉多久啊了巨大倒萨大大阿瓦蒂</p>
					        <p>网易新闻</p>
				        </section>
			        </div>
                    */
                    #endregion
                    string newsback = @"<div class='news'>
				                            <img src='/Resources/Photos/news.jpg'/>";
                    for(int i = 0; i < newsmessage.list.Length; i++)
                    {
                        newsback = newsback + "<section onclick=\"location.href =\'" + newsmessage.list[i].detailurl + "\';\"><p>" + newsmessage.list[i].article + "</p>";
                        newsback=newsback+ "<p>"+newsmessage.list[i].source+"</p></section>";
                    }
                    newsback += "</div>";
                    return newsback;
                    break;
                //菜谱类
                case 308000:
                    #region 目标html样式
                    /*
                    <div class="food">
				        <img src="http://www.sinaimg.cn/dy/slidenews/1_img/2016_04/2841_658254_844711.jpg"/>
				        <section>
					        <img src="http://www.sinaimg.cn/dy/slidenews/1_img/2016_04/2841_658254_844711.jpg"/>
					        <p>大苏打撒大飒飒</p>
					        <p>大苏打撒大飒飒撒撒旦飒飒阿斯达克拉都拉多久啊了巨大倒萨大大阿瓦蒂</p>
				        </section>
				        <section>
					        <img src="http://www.sinaimg.cn/dy/slidenews/1_img/2016_04/2841_658254_844711.jpg"/>
					        <p>大苏打撒大飒飒撒撒旦飒飒阿斯达克拉都拉多久啊了巨大倒萨大大阿瓦蒂</p>
				        </section>
			        </div>
                    */
                    #endregion
                    FoodMessage foodmessage = JsonConvert.DeserializeObject<FoodMessage>(content);
                    string foodsback = "<div class='food'><img src=";
                    if (foodmessage.list.Length != 0) {
                        foodsback =foodsback+ "'/Resources/Photos/food.jpg'/>";
                        for(int i = 0; i < foodmessage.list.Length; i++)
                        {
                            foodsback = foodsback + "<section onclick=\"location.href=\'" + foodmessage.list[i].detailurl + "\';\"><img src='" + foodmessage.list[i].icon + "'/>";
                            foodsback = foodsback + "<p>"+foodmessage.list[i].name+ "</p>";
                            foodsback = foodsback + "<p>" + foodmessage.list[i].info + "</p>";
                            foodsback = foodsback + "</section>";
                        }
                    }
                    else
                    {
                        foodsback = foodsback+"'/>";
                    }
                    foodsback+= "</div>";
                    return HttpUtility.HtmlDecode(foodsback);
                default:break;
            }
            return null;
        }
    }
}