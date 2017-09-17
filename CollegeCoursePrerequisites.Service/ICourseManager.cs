using CollegeCoursePrerequisites.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeCoursePrerequisites.Service
{
    public interface ICourseManager
    {
        string[] PlanCoursesWrapper(string[] courses, string[][] courseDependencies);
    }
}
