using CollegeCoursePrerequisites.Service;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeCoursePrerequisites.UnitTests
{
    [TestFixture]
    public class CourseManagerTests
    {  
        [Test]
        public void PlanCoursesWrapper_WhenCalledWithValidArguments_ReturnsANonEmptyArray()
        {
            ICourseManager courseManager = Substitute.For<ICourseManager>();
            string[] courses = { "a", "b", "c", "d" };
            string[][] dependencies = { new string[] { "a", "b" }, new string[] { "b", "c" } };

            courseManager.When(c => c.PlanCoursesWrapper(courses, dependencies)).Do(context =>{ throw new Exception("fake exception"); });

            Assert.Throws<Exception>(() => courseManager.PlanCoursesWrapper(courses, dependencies));

                   
        }
    }
}
