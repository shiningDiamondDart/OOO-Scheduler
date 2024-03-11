using System.ComponentModel;
using System.Runtime.CompilerServices;
using chron_expression_web.Client.Messages;
using chron_expression_web.Client.Models;
using CommunityToolkit.Mvvm.Messaging;


namespace chron_expression_web.Client.ViewModels
{
    public class LandingViewModel : ViewModel<LandingModel>
    {
        public WeakReferenceMessenger Messenger;
       
        public ReccurenceFlags ReccurenceSelection;
        public bool DayHidden, WeekHidden, MonthHidden, YearHidden;
        public LandingViewModel()
        {
            DayHidden = true; WeekHidden = true; MonthHidden = true; YearHidden = true;
            WeakReferenceMessenger.Default.Register<Message>(this, (r, m) => {Console.WriteLine(m.Value);});
            
        }

        public void SelectElement(ReccurenceFlags Flag)
        {
            ReccurenceSelection = Flag;
            DayHidden = !(ReccurenceFlags.Daily == ReccurenceSelection);
            WeekHidden = !(ReccurenceFlags.Weekly == ReccurenceSelection);
            MonthHidden = !(ReccurenceFlags.Monthly == ReccurenceSelection);
            YearHidden = !(ReccurenceFlags.Yearly == ReccurenceSelection);

        }
        
    }
}