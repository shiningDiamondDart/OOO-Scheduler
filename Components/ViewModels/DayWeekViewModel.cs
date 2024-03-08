using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace chron_expression_web.Client.ViewModels
{
    public class DayWeekViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}