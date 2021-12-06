using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.Annotations;

namespace Lb_5
{
    public class student_performance: INotifyPropertyChanged
    {
        private string _first_name;
        private string _last_name;
        private string _subject;
        private int _mark;

        public string first_name
        {
            get { return _first_name; }
            set
            {
                _first_name = value;
                OnPropertyChanged("first_name");
            }
        }

        public string last_name
        {
            get { return _last_name; }
            set
            {
                _last_name = value;
                OnPropertyChanged("last_name");
            }
        }

        public string subject
        {
            get { return _subject; }
            set
            {
                _subject = value;
                OnPropertyChanged("subject");
            }
        }
        public int mark
        {
            get { return _mark; }
            set
            {
                _mark = value;
                OnPropertyChanged("mark");
            }
        }
        public student_performance() { }
        public student_performance(string first_name, string last_name, string subject, int mark)
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.subject = subject;
            this.mark = mark;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
          
        }
    }
}