using System.ComponentModel;
using System.Runtime.CompilerServices;
using chron_expression_web.Client.Models;
using Microsoft.AspNetCore.Components;


namespace chron_expression_web.Client.ViewModels
{
    public class LandingViewModel : INotifyPropertyChanged
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
        public ReccurenceFlags ReccurenceSelection;
        public bool DayHidden, WeekHidden, MonthHidden, YearHidden;
        public LandingViewModel( )
        {
            DayHidden = true; WeekHidden = true; MonthHidden = true; YearHidden = true;
            landingModel = new LandingModel();
            _landingModel = new LandingModel();

        }
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void SelectElement(ReccurenceFlags Flag)
        {
            ReccurenceSelection = Flag;
            DayHidden = !(ReccurenceFlags.Daily == ReccurenceSelection);
            WeekHidden = !(ReccurenceFlags.Weekly == ReccurenceSelection);
            MonthHidden = !(ReccurenceFlags.Monthly == ReccurenceSelection);
            YearHidden = !(ReccurenceFlags.Yearly == ReccurenceSelection);

        }
        public void ReceiveMessage(string message)
        {
            // Handle the received message
            Console.WriteLine($"Received message in ViewModel2: {message}");
        }
    }
}