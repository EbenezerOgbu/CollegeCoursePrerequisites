using CollegeCoursePrerequisites.DomainModel;
using NUnit.Framework;
using System.Linq;

namespace CollegeCoursePrerequisites.UnitTests
{
    [TestFixture]
    public class CourseDependencyGraphTests
    {
        [Test]
        public void CreateNewOrGetExistingNode_WhenCalled_ChangesCourseNodes()
        {
            CourseDependencyGraph courseGraph = CreateCourseDependencyGraph();
            Course course = courseGraph.CreateNewOrGetExistingNode(GetName());
            Assert.AreEqual(1, courseGraph.GetNodes().Count());
        }

        [Test]
        public void GetNodes_ByDefault_ReturnsAnEmptyArray()
        {
            CourseDependencyGraph courseGraph = CreateCourseDependencyGraph();
            var courses = courseGraph.GetNodes();
            Assert.AreEqual(0, courses.Count());
        }

        private static CourseDependencyGraph CreateCourseDependencyGraph()
        {
            return new CourseDependencyGraph();
        }
        private static string GetName()
        {
            return "myCourseName";
        }
    }
}
