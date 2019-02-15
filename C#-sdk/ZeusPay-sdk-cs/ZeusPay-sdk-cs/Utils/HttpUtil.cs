using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ZeusPay_sdk_cs.Utils
{
    public class HttpUtil
    {
        public static string Post(string url, string json)
        {
            string result = null;
            CookieContainer cookieContainer = new CookieContainer();
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            Stream stream = null;
            StreamReader responseStream = null;

            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(json);
                request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "POST";
                request.KeepAlive = false;
                request.ServicePoint.Expect100Continue = false; //重要，一次性提交请求，否则会分两次post数据
                request.ContentType = "application/json";
                request.Accept = "*/*";
                request.ContentLength = bytes.Length;
                request.CookieContainer = cookieContainer;
                using (stream = request.GetRequestStream())
                    stream.Write(bytes, 0, bytes.Length);
                response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.RequestTimeout)
                    return null;
                responseStream = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8"));
                var count = response.ContentLength;
                List<byte> bs = new List<byte>();
                for (var i = 0; i < count; i++)
                    bs.Add((byte)responseStream.Read());
                result = Encoding.UTF8.GetString(bs.ToArray());
            }
            catch (Exception ex)
            {
                var str = ex.Message;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                    stream.Dispose();
                    stream = null;
                }
                if (responseStream != null)
                {
                    responseStream.Close();
                    responseStream.Dispose();
                    responseStream = null;
                }
                if (response != null)
                {
                    response.Close();
                    response = null;
                }
                if (request != null)
                {
                    request.Abort();
                }
            }
            return result;
        }
    }
}
