using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Zi.Context;
using Zi.Entity;

namespace Zi
{
    internal class Service
    {
        private string token;
        private static string url
        {
            get
            {
                return "http://localhost:59410/api/";
            }
        }
        private Service(string key)
        {
            token = key;
        }
        public static Service Login(string login, string password)
        {
            var psw = Verify.Encrypt(password, login);
            var hash = Verify.Hash(password + login);
            using (var client = new WebClient())
            {
                var token = client.DownloadString($"{url}auth/{hash}/{login}/{psw}");
                if (!string.IsNullOrWhiteSpace(token))
                    return new Service(token);
            }

            return null;
        }

        public void Exit()
        {
            var http = (HttpWebRequest)WebRequest.Create(new Uri($"{url}auth"));
            http.Accept = "application/json";
            http.ContentType = "application/json";
            http.Method = "POST";

            string parsedContent = "\"token\":\"" + token + "\"";
            ASCIIEncoding encoding = new ASCIIEncoding();
            Byte[] bytes = encoding.GetBytes(parsedContent);

            Stream newStream = http.GetRequestStream();
            newStream.Write(bytes, 0, bytes.Length);
            newStream.Close();

            var response = http.GetResponse();

            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);
            var content = sr.ReadToEnd();
            
        }

        /// <summary>
        /// Получить возможные для регистрации роли
        /// </summary>
        public static IEnumerable<Role> GetActualRoles()
        {
            using (var client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                var data = client.DownloadString($"{url}roles");
               
                var roles = JsonConvert.DeserializeObject<List<Role>>(data);
                return roles;
            }
        }
    }
}
