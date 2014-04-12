using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.File;
using Newtonsoft.Json;

namespace Sunny.Core.Services
{
    public static class LoggingService
    {
        static HttpClient _restClient;
        static HttpClientHandler _handler;
        const string _uri = "api.splunkstorm.com";
        static bool _initalized;
        static readonly IMvxFileStore _localStorage = Mvx.Resolve<IMvxFileStore>();
        static string _applicationName;
        static string _projectId;
        static string _host;
        static string _requestUrl;

        /// <summary>
        /// Initialize the SplunkLogger with applicationName, host, projectId and accessToken.
        /// </summary>
        /// <param name="applicationName">Application name</param>
        /// <param name="version">Application version number</param>
        /// <param name="os">Operating System</param>
        /// <param name="projectId">Project identifier</param>
        /// <param name="accessToken">Access token</param>
        public static void Initialize(string applicationName, string os, string projectId, string accessToken)
        {
            _projectId = projectId;
            _applicationName = applicationName;
            _host = os;
            
            _handler = new HttpClientHandler();
            _handler.Credentials = new NetworkCredential("x", accessToken);

           
            string baseUrl = string.Format("https://{0}", _uri);
            _restClient = new HttpClient(_handler);
            _restClient.Timeout = TimeSpan.FromSeconds(30);
            _restClient.BaseAddress = new Uri(baseUrl);
            
            _requestUrl = string.Format("1/inputs/http?index={0}&sourcetype=generic_single_line&host={1}&source={2}",
                _projectId,
                _host,
                _applicationName);
            
            _initalized = true;
        }

        /// <summary>
        /// Sends the logLine to Splunk.
        /// </summary>
        /// <param name="loggingType">Logging type.</param>
        /// <param name="logLine">Log line.</param>
        public static async void Log(ELoggingType loggingType, string logLine)
        {
            if (!_initalized)
                throw new Exception("LoggingService is not initialized");

            string content = null;

            _localStorage.TryReadTextFile("application.log", out content);

            
            var applicationLog = new ApplicationLog();
            applicationLog.Lines = new List<string>();
            
            if (content != null)
                applicationLog = JsonConvert.DeserializeObject<ApplicationLog>(content);
            
            var timestamp = DateTime.UtcNow.ToString("s") + DateTime.UtcNow.ToString("zzz");
            applicationLog.Lines.Add(string.Format("{0} {1} - {2}", timestamp, loggingType.ToString().ToUpper(), logLine));
            
            for (int i = applicationLog.Lines.Count - 1; i >= 0; i--)
            {
                var postContent = new StringContent(applicationLog.Lines[i], Encoding.UTF8, "application/json");
                
                try
                {
                    var response = _restClient.PostAsync(_requestUrl, postContent).Result;
                    response.EnsureSuccessStatusCode();
                    applicationLog.Lines.Remove(applicationLog.Lines[i]);
                    var logFileContent = JsonConvert.SerializeObject(applicationLog);   
                    _localStorage.DeleteFile("application.log");
                    _localStorage.WriteFile("application.log", logFileContent);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Logging service unavaliable");
                    var logFileContent = JsonConvert.SerializeObject(applicationLog);   
                    _localStorage.DeleteFile("application.log");
                    _localStorage.WriteFile("application.log", logFileContent);
                    break;
                }      
            }            
        }
    }

    public enum ELoggingType
    {
        Info,
        Warning,
        Error
    }

    public class ApplicationLog
    {
        public IList<string> Lines { get; set; }
    }
}

