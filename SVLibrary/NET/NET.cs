using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace SVLibrary.NET
{
    public static class NET
    {
        public static string PostRequest(string url, string Request = "null=null", string ContentType = "application/x-www-form-urlencoded")
        {
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST"; // для отправки используется метод Post
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(Request); // преобразуем данные в массив байтов
            request.ContentType = ContentType;  // устанавливаем тип содержимого - параметр ContentType
            request.ContentLength = byteArray.Length;   // Устанавливаем заголовок Content-Length запроса - свойство ContentLength

            using (Stream dataStream = request.GetRequestStream())  //записываем данные в поток запроса
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

            WebResponse response = request.GetResponse();
            string temp = default;
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    temp = reader.ReadToEnd();
                }
            }
            response.Close();
            return temp;
        }

        public static async Task<string> PostRequestAsync(string url, string Request = "null=null", string ContentType = "application/x-www-form-urlencoded")
        {
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST"; // для отправки используется метод Post
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(Request); // преобразуем данные в массив байтов
            request.ContentType = ContentType;  // устанавливаем тип содержимого - параметр ContentType
            request.ContentLength = byteArray.Length;   // Устанавливаем заголовок Content-Length запроса - свойство ContentLength

            using (Stream dataStream = request.GetRequestStream())  //записываем данные в поток запроса
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

            WebResponse response = await request.GetResponseAsync();
            string temp = default;
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    temp = reader.ReadToEnd();
                }
            }
            response.Close();
            return temp;
        }

        public static string GetRequest(string url)
        {
            WebRequest reqUSER = WebRequest.Create(url);
            WebResponse respUSER = reqUSER.GetResponse();
            Stream streamUSER = respUSER.GetResponseStream();
            StreamReader srUSER = new StreamReader(streamUSER);
            string OutUSER = srUSER.ReadToEnd();
            srUSER.Close();

            return OutUSER;
        }

        public static async Task<string> GetRequestAsync(string url)
        {
            WebRequest reqUSER = WebRequest.Create(url);
            WebResponse respUSER = await reqUSER.GetResponseAsync();
            Stream streamUSER = respUSER.GetResponseStream();
            StreamReader srUSER = new StreamReader(streamUSER);
            string OutUSER = srUSER.ReadToEnd();
            srUSER.Close();

            return OutUSER;
        }

        public static void Download(string url, string patch)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(new System.Uri(url), patch);
            }
        }

        public static void DownloadAsync(string url, string patc)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFileAsync(new System.Uri(url), patc);
            }
        }
    }
}
