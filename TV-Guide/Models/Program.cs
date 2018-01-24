using System;

namespace TV_Guide.Models
{
    public class Program
    {
        private string _title;
        private string _description;
        private string _start;
        private string _stop;
        private TV _tv;
      
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public string Start
        {
            get { return _start; }
            set { _start = value; }
        }

        public string Stop
        {
            get { return _stop; }
            set { _stop = value; }
        }

        public TV Tv
        {
            get { return _tv; }
            set { _tv = value; }
        }
    }
}