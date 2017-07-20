using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using System.Text;
using API.Models;
using Newtonsoft.Json;

namespace API.Controllers
{
    public class NotificationController : ApiController
    {

		[HttpPost]
		public HttpResponseMessage Send(Notification entity)
		{
			
				var request = WebRequest.Create(NotificationSettings.OneSignarUrlApi) as HttpWebRequest;
				request.KeepAlive = NotificationSettings.KeepAlive;
				request.Method = NotificationSettings.Method;
				request.ContentType = NotificationSettings.ContentType;
				request.Headers.Add("authorization", string.Format("Basic {0}", NotificationSettings.RestApiKey));

            var obj = JsonConvert.SerializeObject(entity);
            byte[] byteArray = Encoding.UTF8.GetBytes(obj);

            try
				{
					using (var writer = request.GetRequestStream())
					{
						writer.Write(byteArray, 0, byteArray.Length);
					}

					using (var response = request.GetResponse() as HttpWebResponse)
					{
						using (var reader = new StreamReader(response.GetResponseStream()))
						{
							string responseContent = reader.ReadToEnd();
							var result = JsonConvert.DeserializeObject(responseContent);

							return Request.CreateResponse(HttpStatusCode.OK, result);
						}
					}
				}
				catch (WebException ex)
				{
					System.Diagnostics.Debug.WriteLine(ex.Message);
					System.Diagnostics.Debug.WriteLine(new StreamReader(ex.Response.GetResponseStream()).ReadToEnd());
					return Request.CreateResponse(ex);
				}

			
		}

    }
}
