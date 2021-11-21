using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.ComponentModel;

namespace _33333
{
    public class computer_manager  : computer
    {
        public BindingList<computer> comp_list = new BindingList<computer>();
       
        public string admin_name { get; set; }
        public string admin_password { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
      

        public void  add_computer(computer comp)
        {
            comp_list.Add(comp);
        }

        public void remove_computer(computer comp)
        {
            comp_list.Remove(comp);
        }

        public bool admin_authentication(string admin_name, string admin_password)
        {
            if ((this.admin_name == admin_name) && (this.admin_password == admin_password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
