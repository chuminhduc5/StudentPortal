using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Attendance // Điểm danh
    {
        public int AttendanceId { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}