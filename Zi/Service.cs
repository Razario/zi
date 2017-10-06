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
using Zi.Models;

namespace Zi
{
    /// <summary>
    /// Класс для работы с методами сервера
    /// </summary>
    internal class Service
    {
        private string token;
        private string cookieValue;
        private static string url
        {
            get
            {
                return "http://localhost:59410/api/";
            }
        }
        private Service(string key, string cookie)
        {
            token = key;
            cookieValue = cookie;
        }

        /// <summary>
        /// Попытка авторизации пользователя
        /// </summary>
        /// <returns>В случае успешной авторизации возвращается экземпляр класса Service, в случае неудачной попытки возвращается NULL</returns>
        public static Service Login(string login, string password)
        {
            var psw = Verify.Encrypt(password, login);
            var hash = Verify.Hash(password + login);
            using (var client = new WebClient())
            {
                var token = client.DownloadString($"{url}auth/{hash}/{login}/{psw}");
                var session = client.ResponseHeaders["Set-Cookie"];
                if (string.IsNullOrEmpty(session))
                    return null;
                var cookie = session.Substring(session.IndexOf(".AspNetCore.Session=") + ".AspNetCore.Session=".Length);
                cookie = cookie.Substring(0, cookie.IndexOf(";"));

                if (!string.IsNullOrWhiteSpace(token))
                    return new Service(token, cookie);
            }

            return null;
        }

        public static bool Registration(RegistrationModel user)
        {
            var newUser = new User
            {

            };

            return false;
        }

        /// <summary>
        /// Необходимы вызывать во время завершения сессии пользователя
        /// </summary>
        public void Exit()
        {
            Request<bool>($"{url}auth");
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

        private T Request<T>(string url, object data = null)
        {
            var http = (HttpWebRequest)WebRequest.Create(new Uri(url));
            http.Accept = "application/json";
            http.ContentType = "application/json";
            http.Method = "POST";
            http.Headers.Add("Token", token);
            http.Headers.Add("Cookie", $".AspNetCore.Session={cookieValue};");

            var content = data == null ? "" : JsonConvert.SerializeObject(data);
            var encoding = new ASCIIEncoding();
            var bytes = encoding.GetBytes(content);

            var requestStream = http.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();

            var response = http.GetResponse();

            var responseStream = new StreamReader(response.GetResponseStream());
            var result = responseStream.ReadToEnd();
            if (string.IsNullOrEmpty(result))
                return default(T);
            return JsonConvert.DeserializeObject<T>(result);
        }
    }
}
