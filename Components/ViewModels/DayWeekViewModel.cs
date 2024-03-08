using System.ComponentModel;
using System.Runtime.CompilerServices;
using chron_expression_web.Client.Models;

namespace chron_expression_web.Client.ViewModels
{
    public class DayWeekViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private DayWeek _dayWeek;
        public DayWeek dayWeek
        {
            get { return _dayWeek; }
            set
            {
                _dayWeek = value;
                OnPropertyChanged(nameof(DayWeek));
            }
        }
        public DayWeekViewModel()
        {
            Console.WriteLine("INITALIZING VIEWMODEL");
            dayWeek = new DayWeek();
            _dayWeek = new DayWeek();
        }
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            dayWeek.output = Submit();
        }
        public string Submit()
        {
            _dayWeek.SumOfDays = (DaysOfWeek)_dayWeek.CheckableDaysOfWeek.Where(cd => cd.IsSelected).Select(cd => (int)cd.SpecificDayOfWeek).Sum();

            Console.WriteLine("cron is "+dayWeek.GetCron());
            foreach (var CheckableDayOfWeek in _dayWeek.CheckableDaysOfWeek)
            {
                Console.WriteLine(CheckableDayOfWeek.SpecificDayOfWeek.ToString()+ " " +CheckableDayOfWeek.IsSelected);
            }
            return _dayWeek.GetCron();
        }
    }
}