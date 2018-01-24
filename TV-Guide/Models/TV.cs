namespace TV_Guide.Models
{
    public class TV
    {
        private string _channel;
        private string _icon;

        public string Channel
        {
            get { return _channel; }
            set { _channel = value; }
        }

        public string Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }
    }
}