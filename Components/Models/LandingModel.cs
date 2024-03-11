namespace chron_expression_web.Client.Models
{
    public class LandingModel
    {
        public List<ReccurencePatternOption>? ReccurencePatternOptions = new List<ReccurencePatternOption>();
        public LandingModel()
        {
            ReccurencePatternOptions = [new ReccurencePatternOption( "Daily", ReccurenceFlags.Daily),
                                new ReccurencePatternOption( "Weekly", ReccurenceFlags.Weekly),
                                new ReccurencePatternOption( "Monthly", ReccurenceFlags.Monthly),
                                new ReccurencePatternOption( "Yearly", ReccurenceFlags.Yearly) ];
        }
    }
    public enum ReccurenceFlags 
    {
        None = 0,
        Daily = 1,
        Weekly = 1 << 1,
        Monthly = 1 << 2,
        Yearly = 1 << 3

    }
    public class ReccurencePatternOption
    {
        public string? Name { get; set; }
        public ReccurenceFlags Flag = 0;
        public ReccurencePatternOption(string name, ReccurenceFlags index)
        {
            Name = name;
            Flag = index;
        }
    }
        
}