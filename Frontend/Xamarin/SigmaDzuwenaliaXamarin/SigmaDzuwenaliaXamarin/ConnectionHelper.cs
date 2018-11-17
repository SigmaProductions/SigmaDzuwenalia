using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using SigmaDzuwenaliaXamarin.Pickles;

namespace SigmaDzuwenaliaXamarin
{
    

    static class ConnectionHelper
    {
        private const string urlPrefix = "http://22160ab1.ngrok.io";
        private static async void PostJson(string json, string _url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_url);
            request.Method = "POST";


            byte[] byteArray = Encoding.UTF8.GetBytes(json);
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();

            await dataStream.WriteAsync(byteArray, 0, byteArray.Length);
            dataStream.Close();
        }

        private static string GetJson(string _url)
        {
            var request = HttpWebRequest.Create(string.Format(_url));
            request.ContentType = "application/json";
            request.Method = "GET";
            return ("");
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                    Console.Out.WriteLine("Error fetching data. Server returned status code: {0}", response.StatusCode);
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    return (reader.ReadToEnd());
                }
            }
        }

        public static void SendPolice(LatLng point)
        {
            var t = new PolicePickle();
            t.Id = 0;
            t.XCoordinate = point.Latitude;
            t.YCoordinate = point.Longitude;
            t.PatrolSize = 0;
            t.PatrolDate = DateTime.Now;

            string output =JsonConvert.SerializeObject(t);

            PostJson(output, urlPrefix+"/api/Police"); 
        }

        public static List<PolicePickle> GetAllPolice()
        {
            string output =  GetJson(urlPrefix+"/api/Police");
            return JsonConvert.DeserializeObject<List<PolicePickle>>(output);
        }

        public static void SendFlanki(LatLng point)
        {
            var t = new FlankiPickle();
            t.Id = 0;
            t.date = DateTime.Now;
            t.coordinate_x = point.Latitude;
            t.coordinate_y = point.Longitude;
            name = "testname";
            t.counter = 0;

            string output = JsonConvert.SerializeObject(t);
            PostJson(output, urlPrefix + "/api/Flanki");
        }

        public static List<FlankiPickle> GetAllFlanki()
        {
            string output = GetJson(urlPrefix + "/api/Flanki");
            return JsonConvert.DeserializeObject<List<FlankiPickle>>(output);
        }

        public static void SendDrop(LatLng point)
        {
            var t = new DropPickle();
            t.Id = 0;
            t.DtopType = "type";
            t.DropDate = DateTime.Now;
            t.XCoordinate = point.Latitude;
            t.YCoordinate = point.Longitude;

            string output = JsonConvert.SerializeObject(t);
            PostJson(output, urlPrefix + "/api/DropPlace");


        }

        public static List<DropPickle> GettAllDropPlace()
        {
            string output = GetJson(urlPrefix + "/api/DropPlace");
            return JsonConvert.DeserializeObject<List<DropPickle>>(output);
        }

    }
}