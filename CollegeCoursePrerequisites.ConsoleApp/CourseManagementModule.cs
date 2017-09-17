using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollegeCoursePrerequisites.Service;

namespace CollegeCoursePrerequisites.ConsoleApp
{
    public class CourseManagementModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPrepareCoursesForInput>().To<PrepareCoursesForInput>();
            Bind<ICourseManager>().To<CourseManager>();
        }
    }
}
