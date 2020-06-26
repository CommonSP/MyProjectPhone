using Android.Graphics;
using MyProjectPhone.Helpers;
using MyProjectPhone.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectPhone.Services
{
    class ApiServices
    {
        public async Task<bool> Authorization(string login, string password)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);
            
            List<KeyValuePair<string, string>> keyValuePairs = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username",login),
                new KeyValuePair<string, string>("password", password)
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:5001/Token/Autorization");

            request.Content = new FormUrlEncodedContent(keyValuePairs);
          
          
                var response = await client.SendAsync(request);

                var json = await response.Content.ReadAsStringAsync();
                JObject jObject = JObject.Parse(json);
                var token = jObject.Value<string>("token");
                var refreshToken = jObject.Value<string>("refreshToken");
            Settings.AsccessToken = token;
                return response.IsSuccessStatusCode;

        }

        public async Task<User> GetUser() 
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);
            var request = new HttpRequestMessage(HttpMethod.Post, "https://10.0.2.2:5001/User/GetUser");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.AsccessToken);
            var response = await client.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();
            User user = JsonConvert.DeserializeObject<User>(json);
            Settings.Username = user.Login;
            return user;
        }

        public async Task<Photo> GetPhoto(string login)
        {
            List<KeyValuePair<string, string>> keyValuePairs = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username",login)
               
            };
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);
            var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:5001/Photos/GetPhoto");
            request.Content = new FormUrlEncodedContent(keyValuePairs);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.AsccessToken);
            var response = await client.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();
            Photo photo = JsonConvert.DeserializeObject<Photo>(json);
            return photo;
        }

        public  byte[] ResizeImageAndroid(byte[] imageData, float width, float height, int quality)
        {
            // Load the bitmap
            Bitmap originalImage = BitmapFactory.DecodeByteArray(imageData, 0, imageData.Length);

            float oldWidth = (float)originalImage.Width;
            float oldHeight = (float)originalImage.Height;
            float scaleFactor = 0f;

            if (oldWidth > oldHeight)
            {
                scaleFactor = width / oldWidth;
            }
            else
            {
                scaleFactor = height / oldHeight;
            }

            float newHeight = oldHeight * scaleFactor;
            float newWidth = oldWidth * scaleFactor;

            Bitmap resizedImage = Bitmap.CreateScaledBitmap(originalImage, (int)newWidth, (int)newHeight, false);

            using (MemoryStream ms = new MemoryStream())
            {
                resizedImage.Compress(Bitmap.CompressFormat.Png, quality, ms);
                return ms.ToArray();
            }
        }
    }
}
