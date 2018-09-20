﻿using MiniBook.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MiniBook.ViewModels
{
    public class ViewModelBase : Mvvm.BindableBase
    {
        private string _title;
        private bool _isBusy;

        protected INavigationService NavigationService { get; }

        public ViewModelBase()
        {
            NavigationService = ServiceLocator.Instance.Resolve<INavigationService>();
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }


        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value, () => RaisePropertyChanged(nameof(IsNotBusy)));
        }

        public bool IsNotBusy => !IsBusy;

        public virtual Task OnNavigationAsync(NavigationParameters parameters, NavigationType navigationType)
        {
            return Task.CompletedTask;
        }
    }
}