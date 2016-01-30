using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace robot.ServiceHelper
{
    public class HttpHelper
    {

        /// <summary>
        /// post请求
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="postDataStr"></param>
        /// <returns></returns>
        /// 
        public string HttpPost(string Url, List<KeyValuePair<string, string>> postParameters)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            string parametersString = "";
            for (int i = 0; i < postParameters.Count; i++)
            {
                if (i==0)
                {
                    parametersString = (postParameters[i]).Key + "=" + postParameters[i].Value;
                }
                else
                {
                    parametersString = parametersString + "&" + (postParameters[i]).Key + "=" + postParameters[i].Value;
                }
            }
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(parametersString);
            request.ContentLength = byteArray.Length;
            Stream myRequestStream = request.GetRequestStream();
            myRequestStream.Write(byteArray,0,byteArray.Length);
            myRequestStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            return retString;
        }
        /// <summary>
        /// get请求
        /// </summary>
        /// <param name="uriString"></param>
        /// <returns></returns>
        public string HttpGet(string uriString)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uriString);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            return retString;
        }


    }
}