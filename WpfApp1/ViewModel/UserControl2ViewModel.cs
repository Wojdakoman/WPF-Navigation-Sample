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
    class UserControl2ViewModel : ViewModelBase, IPageViewModel
    {
        private ICommand _goTo1 = null;
        public ICommand GoTo1
        {
            get
            {
                if (_goTo1 == null)
                {
                    _goTo1 = new RelayCommand(
                        arg =>
                        {
                            Mediator.Notify("GoTo1Screen", "");
                        },
                        arg => true
                    );
                }
                return _goTo1;
            }
        }
    }
}