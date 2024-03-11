namespace chron_expression_web.Client.Models
{
    public class RangeOfReccurenceModel
    {
        public DateOnly StartDate;
        public DateOnly? EndDate;
        public string GetCron(string CompleteCron)
        {
           return "Starting, " + StartDate.ToString() + EndDate == null ? " Ending, " + EndDate.ToString(): "";
                      
        }
    }
}
