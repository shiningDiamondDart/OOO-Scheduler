using System.ComponentModel;
using System.Runtime.CompilerServices;
using chron_expression_web.Client.Models;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.AspNetCore.Components;
using chron_expression_web.Client.Messages;


namespace chron_expression_web.Client.ViewModels
{
    
    public class DayWeekViewModel : ViewModel<DayWeek>
    {
        public List<CheckableDayOfWeek> CheckableDaysOfWeek { get; set; } = new List<CheckableDayOfWeek>(); 
        public string output = "";

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

        }
        public void OnDayWeekChanged([CallerMemberName] string propertyName = null)
        {
            OnPropertyChanged(propertyName);
            output = Submit();
            WeakReferenceMessenger.Default.Send(new Message("hey"));

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
            _Model.SumOfDays = (DaysOfWeek)CheckableDaysOfWeek.Where(cd => cd.IsSelected).Select(cd => (int)cd.SpecificDayOfWeek).Sum();
            return _Model.GetCron();
        }
    }
}