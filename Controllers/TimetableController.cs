using Microsoft.AspNetCore.Mvc;
using TimeTableCalculation.Models;

namespace TimeTableCalculation.Controllers
{
    public class TimetableController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubjectDetails(TimetableModel timetable)
        {

            return View(timetable);
        }

        [HttpPost]
        public ActionResult StudentTimeTable(TimetableModel timetable)
        {
            timetable.TimetableGrid = new List<List<SubjectInfo>>();
            timetable.TimetableGrid = GenerateTimetableGrid(timetable);

            return View(timetable);
        }

        private List<List<SubjectInfo>> GenerateTimetableGrid(TimetableModel timetableModel)
        {
            var timetableGrid = new List<List<SubjectInfo>>();

            for (int day = 1; day <= timetableModel.TotalWorkingDays; day++)
            {
                var daySubjects = new List<SubjectInfo>();
                for (int subject = 1; subject <= timetableModel.SubjectsPerDay; subject++)
                {
                    daySubjects.Add(new SubjectInfo());
                }
                timetableGrid.Add(daySubjects);
            }

            var subjectsList = timetableModel.Subjects
                                .SelectMany(kvp => Enumerable.Repeat(kvp.SubjectName, kvp.TotalHours))
                                .OrderBy(x => Guid.NewGuid())
                                .ToList();

            int subjectIndex = 0;
            for (int day = 0; day < timetableModel.TotalWorkingDays; day++)
            {
                for (int subject = 0; subject < timetableModel.SubjectsPerDay; subject++)
                {
                    if (subjectIndex < subjectsList.Count)
                    {
                        timetableGrid[day][subject] = new SubjectInfo { SubjectName = subjectsList[subjectIndex] };
                        subjectIndex++;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return timetableGrid;
        }

    }
}
