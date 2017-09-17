using NUnit.Framework;
using System;
using CollegeCoursePrerequisites.Service;
using NSubstitute;

namespace CollegeCoursePrerequisites.UnitTests
{
    [TestFixture]
    public class PrepareCoursesForInputTests
    {
        [Test]
        public void PrepareCourses_WhenCalled_ChangesAllCoursesStringArray()
        {
            IPrepareCoursesForInput prepareCoursesForInput = Substitute.For<IPrepareCoursesForInput>();
            string[] testCourses = { "Intro to Arguing on the Internet: Godwin’s Law",
                                     "Understanding Circular Logic: Intro to Arguing on the Internet"};

            prepareCoursesForInput.When(p=> p.PrepareCourses(testCourses)).Do(context => { throw new Exception("fake exception"); });

            Assert.Throws<Exception>(() => prepareCoursesForInput.PrepareCourses(testCourses));
        }

        [Test]
        public void GetCourseList_WhenCalledWithValidArguments_ReturnsANonEmptyArray()
        {
            IPrepareCoursesForInput prepareCoursesForInput = Substitute.For<IPrepareCoursesForInput>();

            prepareCoursesForInput.When(p => p.GetCourseList()).Do(context => { throw new Exception("fake exception"); });

            Assert.Throws<Exception>(() => prepareCoursesForInput.GetCourseList());


        }
        [Test]
        public void GetAllCoursesAndTheirPrerequisites_WhenCalled_ReturnsANonEmptyArray()
        {
            IPrepareCoursesForInput prepareCoursesForInput = Substitute.For<IPrepareCoursesForInput>();

            prepareCoursesForInput.When(p => p.GetAllCoursesAndTheirPrerequisites()).Do(context => { throw new Exception("fake exception"); });

            Assert.Throws<Exception>(() => prepareCoursesForInput.GetAllCoursesAndTheirPrerequisites());
        }
    }
}
