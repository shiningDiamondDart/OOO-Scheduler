using System.ComponentModel;
using System.Runtime.CompilerServices;
using chron_expression_web.Client.Models;

namespace chron_expression_web.Client.ViewModels
{
    public class DayWeekViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public List<CheckableDayOfWeek> CheckableDaysOfWeek { get; set; } = new List<CheckableDayOfWeek>(); 
        public string output = "";
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

            foreach (int DOfWeek in Enum.GetValues(typeof(DaysOfWeek)))
            {
                if (DOfWeek != 0)
                {
                    CheckableDaysOfWeek.Add(new CheckableDayOfWeek() {SpecificDayOfWeek = (DaysOfWeek)DOfWeek});
                }
            }

            dayWeek = new DayWeek();
            _dayWeek = new DayWeek();
        }
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void OnDayWeekChanged([CallerMemberName] string propertyName = null)
        {
            OnPropertyChanged(propertyName);
            output = Submit();
        }
        public string ResetDayWeek()
        {
            foreach (CheckableDayOfWeek DOWeek in CheckableDaysOfWeek)
            {
                DOWeek.IsSelected = false;
            }
            return "";
        }
        public string Submit()
        {
            _dayWeek.SumOfDays = (DaysOfWeek)CheckableDaysOfWeek.Where(cd => cd.IsSelected).Select(cd => (int)cd.SpecificDayOfWeek).Sum();
            return _dayWeek.GetCron();
        }
    }
}