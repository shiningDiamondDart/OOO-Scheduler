using System.ComponentModel;
using System.Runtime.CompilerServices;
using chron_expression_web.Client.Models;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.AspNetCore.Components;
using chron_expression_web.Client.Messages;

namespace chron_expression_web.Client.ViewModels
{
    public class RangeOfReccurenceViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private LandingModel _landingModel;
        public LandingModel landingModel
        {
            get { return _landingModel; }
            set
            {
                _landingModel = value;
                OnPropertyChanged(nameof(landingModel));
            }
        }
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}