using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeCoursePrerequisites.Service
{
    public interface IPrepareCoursesForInput
    {
        void PrepareCourses(string[] courses);
        string[] GetCourseList();
        string[][] GetAllCoursesAndTheirPrerequisites();
    }
}
