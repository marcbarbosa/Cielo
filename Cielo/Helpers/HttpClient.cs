using System.IO;
using System.Net;
using System.Text;

namespace Cielo.Helpers
{
    public class EasyHttpClient
    {
        private string _CharSet = "UTF-8";
        private string _ContentType = "application/x-www-form-urlencoded";
        private string _UserAgent = "EasyHttpClient";

        public EasyHttpClient()
        { 
        }

        public EasyHttpClient(string pCharSet, string pContentType, string pUserAgent) 
        {
            _CharSet = pCharSet;
            _ContentType = pContentType;
            _UserAgent = pUserAgent;
        }

        public string Post(string pUrl, string pData)
        {
            return Request(pUrl, "POST", pData);
        }

        public string Get()
        {
            return "Not implemented";
        }

        private string Request(string pUrl, string pMethod, string pData)
        {
            var Ret = "";

            var Request = (HttpWebRequest)WebRequest.Create(pUrl);
            Request.ContentLength = Encoding.GetEncoding(_CharSet).GetBytes(pData).Length;
            Request.ContentType = _ContentType + "; charset=" + _CharSet;
            Request.Method = pMethod;
            Request.UserAgent = _UserAgent;

            var Writer = new StreamWriter(Request.GetRequestStream());
            Writer.Write(pData);
            Writer.Close();

            var Response = (HttpWebResponse)Request.GetResponse();
            StreamReader Reader = new StreamReader(Response.GetResponseStream());
            Ret = Reader.ReadToEnd();
            Reader.Close();

            return Ret;
        }

    }
}
