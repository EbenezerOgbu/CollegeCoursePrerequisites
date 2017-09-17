using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeCoursePrerequisites.UnitTests
{
    [TestFixture]
    public class CourseTests
    {
        [Test]
        public void GetNumberOfDependencies_ByDefault_ReturnsZero()
        {
            Course course = CreateCourse(GetName());
            int numberOfDependencies = course.GetNumberOfDependencies();
            Assert.AreEqual(0, numberOfDependencies);
        }

        [Test]
        public void IncreaseCourseDependencies_WhenCalled_ChangesCourseDependencies()
        {
            Course course = CreateCourse(GetName());
            course.IncreaseCourseDependencies();
            int numberOfDependencies = course.GetNumberOfDependencies();
            Assert.AreEqual(1, numberOfDependencies);
        }

        [Test]
        public void DecreaseCourseDependencies_WhenCalled_ChangesCourseDependencies()
        {
            Course course = CreateCourse(GetName());
            course.DecreaseCourseDependencies();
            int numberOfDependencies = course.GetNumberOfDependencies();
            Assert.AreEqual(-1, numberOfDependencies);
        }

        [Test]
        public void AddCourseNeighbour_WhenCalled_ChangesCourseChildren()
        {
            Course course = CreateCourse(GetName());
            course.DecreaseCourseDependencies();
            int numberOfDependencies = course.GetNumberOfDependencies();
            Assert.AreEqual(-1, numberOfDependencies);
        }

        [Test]
        public void GetCourseChildren_ByDefault_ReturnsAnEmptyArray()
        {
            Course course = CreateCourse(GetName());
            var children = course.GetCourseChildren();
            Assert.AreEqual(0, children.Count());
        }

        [Test]
        public void GetCourseName_WhenCalled_ReturnsCourseName()
        {
            Course course = CreateCourse(GetName());
            var name = course.GetCourseName();
            Assert.AreSame(GetName(), name);
        }

        private static Course CreateCourse(string name)
        {
            return new Course();
        }

        private static string GetName()
        {
            return "myCourseName";
        }
    }
}
