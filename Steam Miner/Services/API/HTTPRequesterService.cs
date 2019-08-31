namespace Steam_Miner.Services.API
{
    using System;
    using System.IO;
    using System.Net;
    using System.Threading;
    using Newtonsoft.Json;

    /// <inheritdoc/>
    public class HTTPRequesterService : IHTTPRequesterService
    {
        /// <inheritdoc/>
        public string Get(string url, int maxTries = 1, int secondsBeforeReTrying = 0)
        {
            var tries = 0;
            while (maxTries > tries)
            {
                try
                {
                    tries++;
                    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                    request.Method = "GET";
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        Stream dataStream = response.GetResponseStream();
                        StreamReader reader = new StreamReader(dataStream);
                        string responseText = reader.ReadToEnd();
                        reader.Close();
                        dataStream.Close();
                        return responseText;
                    }
                }
                catch (Exception e)
                {
                    if (maxTries == tries)
                    {
                        Console.WriteLine("Max tries exceed with:" + Environment.NewLine + e.Message);
                        throw new Exception(e.Message);
                    }

                    if (e.Message.Contains("403"))
                    {
                        throw new Exception("403 forbidden");
                    }

                    Console.WriteLine(e.Message + Environment.NewLine + "Retrying after " + secondsBeforeReTrying + " seconds");
                    Thread.Sleep(secondsBeforeReTrying * 1000);
                }
            }

            // this can actually not be hit.
            return string.Empty;
        }

        /// <inheritdoc/>
        public string Post(string url, string headers)
        {
            {
                while (true)
                {
                    try
                    {
                        using (var wc = new WebClient())
                        {
                            wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                            var htmlResult = wc.UploadString(url, headers);
                            break;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Thread.Sleep(10000);
                    }
                }
            }

            return "success";
        }
    }
}