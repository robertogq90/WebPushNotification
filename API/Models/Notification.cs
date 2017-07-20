using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{

	public static class NotificationSettings
	{
		public static string OneSignarUrlApi { get { return "https://onesignal.com/api/v1/notifications"; } }

		public static bool KeepAlive { get { return true; } }

		public static string Method { get { return "POST"; } }

		public static string ContentType { get { return "application/json; charset=utf-8"; } }

		public static string RestApiKey { get { return "MDkwM2FhZWYtYzc0NC00NWM5LWE1NjYtNDIxODM0ZjE5OTg1"; } }
	}

	public class NotifiacionContents
	{
		public string en { get; set; }

        public string es { get; set; }

        

    }

    public class NotificationContentsData
    {
        public List<NotificationFilter> filters { get; set; }
    }

	public class NotificationFilter
	{
		public int tipoEntidad_id { get; set; }

		public string entidad_id { get; set; }
	}

	public class Notification
	{
		
		public string app_id { get { return "7f1fcfae-1a53-409f-af06-9175d8e8716e"; } }

		public NotifiacionContents contents { get; set; }

        public NotificationContentsData data { get; set; }

        public List<string> included_segments
        {
            get
            {
                var list = new List<string>();
                list.Add("All");
                return list;
            }
        }


    }
}
