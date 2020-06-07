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
    class UserControl1ViewModel : ViewModelBase, IPageViewModel
    {
        private ICommand _goTo2 = null;
        public ICommand GoTo2
        {
            get
            {
                if (_goTo2 == null)
                {
                    _goTo2 = new RelayCommand(
                        arg =>
                        {
                            Mediator.Notify("GoTo2Screen", "");
                        },
                        arg => true
                    );
                }
                return _goTo2;
            }
        }
    }
}