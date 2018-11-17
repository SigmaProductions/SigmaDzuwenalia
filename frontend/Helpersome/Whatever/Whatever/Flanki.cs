using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Whatever
{
    class FlankiPickle
    {
        public int Id;
        public double XCoordinate;
        public double YCoordinate;
        public int PatrolSize;
        public DateTime PatrolDate;
    }

    static class ConnectionHelperFlanki
    {
        public static void SendPolice(LatLng point)
        {
            var t = new PolicePickle();
            t.Id = 0;
            t.XCoordinate = point.Latitude;
            t.YCoordinate = point.Longitude;
            t.PatrolSize = 0;
            t.PatrolDate = DateTime.Now;

            string output = JsonConvert.SerializeObject(t);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://d2b608e3.ngrok.io/api/Police");
            request.Method = "POST";


            byte[] byteArray = Encoding.UTF8.GetBytes(output);
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();

            dataStream.WriteAsync(byteArray, 0, byteArray.Length);
            dataStream.Close();
        }

    }
}
