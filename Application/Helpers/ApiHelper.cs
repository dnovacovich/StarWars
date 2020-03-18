using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Application.Helpers
{
    public static class ApiHelper
    {
        public static string MakeJsonRequest(string requestUrl, object JSONRequest, string JSONmethod, string JSONContentType)
        {
            return MakeJsonRequestWithHeaders(requestUrl, JSONRequest, JSONmethod, JSONContentType, null);
        }

        public static string MakeJsonRequestWithHeaders(string requestUrl, object JSONRequest, string JSONmethod, string JSONContentType, NameValueCollection headers)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;

                string sb = JsonConvert.SerializeObject(JSONRequest);

                request.Method = JSONmethod;// "POST";
                request.ContentType = JSONContentType; // "application/json";
                request.Accept = JSONContentType;

                if (headers != null)
                {
                    request.Headers.Add(headers);
                }

                if (!"GET".Equals(JSONmethod.ToUpper()))
                {
                    Byte[] bt = Encoding.UTF8.GetBytes(sb);
                    Stream st = request.GetRequestStream();
                    st.Write(bt, 0, bt.Length);
                    st.Close();
                }

                try
                {
                    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                    {
                        if (response.StatusCode != HttpStatusCode.OK)
                            throw new Exception(String.Format(
                            "Server error (HTTP {0}: {1}).",
                            response.StatusCode,
                            response.StatusDescription));

                        Stream stream1 = response.GetResponseStream();
                        StreamReader sr = new StreamReader(stream1);
                        string strsb = sr.ReadToEnd();

                        return strsb;
                    }
                }
                catch (WebException ex)
                {
                    WebResponse errResp = ex.Response;
                    using (Stream respStream = errResp.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(respStream);
                        string text = reader.ReadToEnd();
                    }
                    return string.Empty;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return string.Empty;
            }
        }
    }
}
