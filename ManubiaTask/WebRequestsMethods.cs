using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace ManubiaTask
{
    public static class WebRequestsMethods
    {
        public static HttpResponseMessage ExecuteGetRequest(string url, Dictionary<string, string> headers = null, Cookie[] cookies = null)
        {
            try
            {
                using(var handler = new HttpClientHandler())
                {
                    if(cookies != null)
                    {
                        var cookieContainer = new CookieContainer();
                        foreach(var cookie in cookies)
                        {
                            cookieContainer.Add(cookie);
                        }

                        handler.CookieContainer = cookieContainer;
                        handler.UseCookies = true;
                    }
                
                    using(var client = new HttpClient(handler))
                    {
                        client.BaseAddress = new Uri(url);

                        if(headers != null)
                        {
                            foreach(var header in headers)
                            {
                                client.DefaultRequestHeaders.Add(header.Key, header.Value);
                            }
                        }

                        return client.GetAsync(url).Result;
                    }
                }
            }
            catch(Exception e)
            {
                Logger.Log(LogLevel.ERROR, nameof(WebRequestMethods), $"Exception occured while downloading page: {url}", e);
            }

            return null;
        }

        public static HttpResponseMessage ExecutePostRequest(string url, string data, Dictionary<string, string> headers = null, Cookie[] cookies = null)
        {
            try
            {
                using(var handler = new HttpClientHandler())
                {
                    if(cookies != null)
                    {
                        var cookieContainer = new CookieContainer();
                        foreach(var cookie in cookies)
                        {
                            cookieContainer.Add(cookie);
                        }

                        handler.CookieContainer = cookieContainer;
                        handler.UseCookies = true;
                    }

                    using(var client = new HttpClient(handler))
                    {
                        client.BaseAddress = new Uri(url);

                        var content = new StringContent(data);
                        if(headers != null)
                        {
                            foreach(var header in headers)
                            {
                                content.Headers.Remove(header.Key);
                                content.Headers.Add(header.Key, header.Value);
                            }
                        }

                        return client.PostAsync(url, content).Result;
                    }
                }
            }
            catch(Exception e)
            {
                Logger.Log(LogLevel.ERROR, nameof(WebRequestMethods), $"Exception occured while downloading page: {url}", e);
            }

            return null;
        }

        public static HtmlDocument GetHtmlDocumentFromResponse(HttpResponseMessage httpResponse)
        {
            try
            {
                using(var contentStream = httpResponse.Content.ReadAsStreamAsync().Result)
                {
                    if(contentStream.Length > 0)
                    {
                        var document = new HtmlDocument();
                        document.Load(contentStream);
                        return document;
                    }
                }
            }
            catch(Exception e)
            {
                Logger.Log(LogLevel.ERROR, nameof(WebRequestMethods), "Exception occured while getting html document:", e);
            }

            return null;
        }

        public static JObject GetJsonFromResponse(HttpResponseMessage httpResponse)
        {
            try
            {
                var content = httpResponse.Content.ReadAsStringAsync().Result;
                if(!string.IsNullOrEmpty(content))
                {
                    var jo = JObject.Parse(content);
                    return jo;
                }
            }
            catch(Exception e)
            {
                Logger.Log(LogLevel.ERROR, nameof(WebRequestMethods), "Exception occured while getting JSON", e);
            }

            return null;
        }
    }
}
