﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.ViewModel.Base;
using WpfApp1.ViewModel.Interface;

namespace WpfApp1.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        private IPageViewModel _currentPageViewModel;
        private List<IPageViewModel> _pageViewModels;

        public List<IPageViewModel> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                    _pageViewModels = new List<IPageViewModel>();

                return _pageViewModels;
            }
        }

        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                _currentPageViewModel = value;
                OnPropertyChanged(nameof(CurrentPageViewModel));
            }
        }

        private void ChangeViewModel(IPageViewModel viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);

            CurrentPageViewModel = PageViewModels
                .FirstOrDefault(vm => vm == viewModel);
        }

        private void OnGo1Screen(object obj)
        {
            ChangeViewModel(PageViewModels[1]);
        }

        private void OnGo2Screen(object obj)
        {
            ChangeViewModel(PageViewModels[2]);
        }

        public MainWindowViewModel()
        {
            // Add available pages and set page
            PageViewModels.Add(new LoginVM());
            PageViewModels.Add(new UserControl1ViewModel());
            PageViewModels.Add(new UserControl2ViewModel());

            CurrentPageViewModel = PageViewModels[0];

            Mediator.Subscribe("GoTo1Screen", OnGo1Screen);
            Mediator.Subscribe("GoTo2Screen", OnGo2Screen);

            ChangeViewModel(PageViewModels[0]);
            //OnPropertyChanged(nameof());
        }
    }
}
