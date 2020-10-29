namespace Fanex.GoldDeluxe.CoreSetting.ViewModels
{
    using System.Web;
    using DTOs;
    using Enumerations;

    public class EditSettingViewModel
    {
        private string _ip = string.Empty;

        public int CustId { get; set; }

        public int UpLineId { get; set; }

        public int ActorId { get; set; }

        public int SubAccId { get; set; }

        public string Language { get; set; }

        public FormType FormType { get; set; }

        public CustomerLevel UpLineLevel { get; set; }

        public CustomerLevel Level { get; set; }

        public SystemType System { get; set; }

        public SettingDTO Setting { get; set; }

        public bool IsUpdatePTAllMembers { get; set; }

        public float PTOnMember { get; set; }

        public string IP
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_ip))
                {
                    var localIP = "127.0.0.1";

                    var ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    ip = ip.Equals("::1") ? localIP : (string.IsNullOrEmpty(ip) ? localIP : ip.Split(',')[0]);

                    return ip;
                }

                return _ip;
            }

            set
            {
                _ip = value;
            }
        }


    }
}