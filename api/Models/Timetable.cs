using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Timetable // Thời khóa biểu
    {
        public int TimetableId { get; set; }
        public string DayOfWeek { get; set; } 
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}