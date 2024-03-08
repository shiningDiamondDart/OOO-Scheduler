public class DayWeekModel {
        public string[] Days { get; set;} = ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"];
        public DaysOfWeek SumOfDays;
        public List<CheckableDayOfWeek> CheckableDaysOfWeek { get; set; } = new List<CheckableDayOfWeek>();     
        
        [Flags]
        public enum DaysOfWeek  {
            None = 0,
            Sunday = 1,          
            Monday = 1 << 1,    
            Tuesday = 1 << 2,  
            Wednesday = 1 << 3,
            Thursday = 1 << 4,
            Friday = 1 << 5,
            Saturday = 1 << 6  
        }
        public class CheckableDayOfWeek {
            public DaysOfWeek SpecificDayOfWeek { get; set; }
            public bool IsSelected { get; set; }
        }
        public string GetCron() 
        {
            string output = "";            
            int Last = -1;
            foreach (DaysOfWeek DOfWeek in Enum.GetValues(typeof(DaysOfWeek))) {
                //if the sum has the current day
                if ((DOfWeek & SumOfDays) != 0) {  
                    int Next;
                    if (DOfWeek != DaysOfWeek.Saturday) {
                        //Next = 1 if sum has the next day, 0 if not
                        Next = (int)DOfWeek << 1 & (int)SumOfDays;
                    } else {
                        Next = -1;
                    }
                        
                    if (Last == 0) {
                        if (Next < 1) {
                            output += Math.Log((int)DOfWeek, 2) + ",";
                        } else {
                            output += Math.Log((int)DOfWeek, 2) + "";
                        }
                        
                    }
                    else if (Next == 0 || Next == -1){
                        output += "-" + Math.Log((int)DOfWeek, 2) + ",";
                    }
                        
                Last = 1;
                    
                } else {Last = 0;}
            }

            if (output.EndsWith(",")) {
                output = output.Remove(output.Length-1);
            }

            return output;
        }
    }


        