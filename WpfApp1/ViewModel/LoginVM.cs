using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.ViewModel.Base;
using WpfApp1.ViewModel.Interface;

namespace WpfApp1.ViewModel
{
    class LoginVM : ViewModelBase, IPageViewModel
    {
        public string Error { get; set; }

        private ICommand _login = null;
        public ICommand Login
        {
            get
            {
                if (_login == null)
                {
                    _login = new RelayCommand(
                        arg =>
                        {
                            //check in model; return true or false
                            Random rnd = new Random();

                            if(rnd.Next(10)%2 == 0)
                            {
                                //login successfull
                                Mediator.Notify("GoTo1Screen", "");
                            }
                            else
                            {
                                //login failed
                                Error = "Błędny login lub hasło!";
                                OnPropertyChanged(nameof(Error));
                            }
                            
                        },
                        arg => true
                    );
                }
                return _login;
            }
        }
    }
}
