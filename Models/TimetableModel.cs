using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TimeTableCalculation.Models
{
    public class TimetableModel
    {
        [DisplayName("No of Working Days")]
        [Range(1, 7, ErrorMessage = "Total Working Days should be between 1 and 7.")]
        public int TotalWorkingDays { get; set; }

        [DisplayName("No of Subject Per Day")]
        [Range(1, 8, ErrorMessage = "Subjects Per Day should be between 1 and 8.")]
        public int SubjectsPerDay { get; set; }

        [DisplayName("Total Subjects")]
        [Range(0, int.MaxValue, ErrorMessage = "Total Subjects should be a positive number.")]
        public int TotalSubjects { get; set; }

        [DisplayName("Total Hours Per Week")]
        [Range(0, int.MaxValue, ErrorMessage = "Total Hours Per Week should be a positive number.")]
        public int TotalHoursPerWeek { get; set; }

        public List<SubjectData>? Subjects { get; set; }

        public List<List<SubjectInfo>> TimetableGrid { get; set; } = new List<List<SubjectInfo>>();
    }

    public class SubjectInfo
    {
        public string SubjectName { get; set; }
    }

    public class SubjectData
    {
        [DisplayName("Subject Name")]
        [Required]
        public string SubjectName { get; set; }
        
        [DisplayName("Total Hours")]
        [Required]
        public int TotalHours { get; set; }
    }
    
}
