using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;

namespace CCSkype
{
    public class HttpGet : IHttpGet
    {
        private HttpWebRequest _request;
        private HttpWebResponse _response;

        private string _responseBody;
        private int _statusCode;
        private double _responseTime;
        private int _timeoutInSeconds;
        private string _username;
        private string _password;
        private bool _debug;

        public string ResponseBody { get { return _responseBody; } }

        public int StatusCode { get { return _statusCode; } }

        public double ResponseTime { get { return _responseTime; } }

        public HttpGet(int timeoutInSeconds,string username,string password)
        {
            _timeoutInSeconds = timeoutInSeconds;
            _username = username;
            _password = password;
            _debug = false;
        }

        public HttpGet(int timeoutInSeconds, string username, string password,bool debug) : this(timeoutInSeconds, username, password)
        {
            _debug = debug;
        }

        public void Request(string url)
        {
            var timer = new Stopwatch();
            
            _request = (HttpWebRequest)WebRequest.Create(url);
            _request.ReadWriteTimeout = (AsMiliSeconds(_timeoutInSeconds));
            _request.Timeout = (AsMiliSeconds(_timeoutInSeconds));
            AddAuthorisationHeader();
            timer.Start();
            _response = (HttpWebResponse)_request.GetResponse();
            var buf = new byte[8192];
            Stream respStream = _response.GetResponseStream();            
            GetData(timer, respStream, buf);
            timer.Stop();           
            _statusCode = (int)_response.StatusCode;
            _responseTime = timer.ElapsedMilliseconds / 1000.0;
            if(_debug)
            {
                Console.WriteLine();
                Console.WriteLine("Response Time:" + _responseTime);
                Console.WriteLine("status code  :" + _statusCode);
            }            
        }

        private void GetData(Stopwatch timer, Stream respStream, byte[] buf)
        {
            var respBody = new StringBuilder();
            int count;
            do
            {
                count = respStream.Read(buf, 0, buf.Length);
                if (count != 0)
                {
                    var data = Encoding.ASCII.GetString(buf, 0, count);
                    respBody.Append(data);
                    if (_debug)
                    {
                        Console.Write(data);    
                    }                    
                }
                if (timer.ElapsedMilliseconds > AsMiliSeconds(_timeoutInSeconds))
                {
                    throw new ApplicationException("Response time out exceeded");
                }
            }
            while (count > 0);
            _responseBody = respBody.ToString();
        }

        private void AddAuthorisationHeader()
        {
            byte[] authBytes = Encoding.UTF8.GetBytes(string.Format("{0}:{1}",_username,_password).ToCharArray());
            _request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(authBytes);
        }

        private static int AsMiliSeconds(int timeoutSeconds)
        {
            return timeoutSeconds * 1000;
        }      
    }
}