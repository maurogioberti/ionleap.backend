using System;
using System.Net.Http;
using System.Text;

namespace Neoris.Ionleap.CrossCutting.Utils.Http
{
    public static class BaseHttpRequest
    {
        private static string _userAgent =
            "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36";

        public static HttpResponseMessage HttpPostRequest(string url, FormUrlEncodedContent form)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", _userAgent);
                return httpClient.PostAsync(new Uri(url), form).Result;
            }
        }

        public static HttpResponseMessage HttpGetRequest(string url)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", _userAgent);
                return httpClient.GetAsync(new Uri(url)).Result;
            }
        }

        public static HttpResponseMessage HttpPostRequest(string url, object form)
        {
            var request = new StringContent(form.ToRawContent(), Encoding.UTF8, "application/x-www-form-urlencoded");

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", _userAgent);
                return httpClient.PostAsync(url, request).Result;
            }
        }
    }
}