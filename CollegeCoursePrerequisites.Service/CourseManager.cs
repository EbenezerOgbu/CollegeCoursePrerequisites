using CollegeCoursePrerequisites.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeCoursePrerequisites.Service
{
    public class CourseManager: ICourseManager
    {
        private static CourseDependencyGraph BuildGraphDataStructure(string[] courses, string[][] dependencyArray)
        {
            CourseDependencyGraph courseGraph = new CourseDependencyGraph();

            foreach (var course in courses)
            {
                courseGraph.CreateNewOrGetExistingNode(course);
            }

            foreach (string[] dependency in dependencyArray)
            {
                string firstCourse = dependency[0];
                string secondCourse = dependency[1];

                courseGraph.AddEdge(firstCourse, secondCourse);
            }

            return courseGraph;
        }

        private static int AddNonDependent(Course[] order, IEnumerable<Course> courses, int offset)
        {
            foreach (Course course in courses)
            {
                if (course.GetNumberOfDependencies() == 0)
                {
                    order[offset] = course;
                    offset++;
                }
            }

            return offset;
        }

        private static Course[] OrderCourses(IEnumerable<Course> courses)
        {
            Course[] orderCourses = new Course[courses.Count()];

            int endOfList = AddNonDependent(orderCourses, courses, 0);

            int toBeProcessed = 0;

            while (toBeProcessed < orderCourses.Length)
            {
                Course currentCourse = orderCourses[toBeProcessed];

                if (currentCourse == null)
                {
                    return null;
                }

                IEnumerable<Course> childrenCourses = currentCourse.GetCourseChildren();

                foreach (Course course in childrenCourses)
                {
                    course.DecreaseCourseDependencies();
                }

                endOfList = AddNonDependent(orderCourses, childrenCourses, endOfList);

                toBeProcessed++;
            }

            return orderCourses;
        }

        private static string[] ConvertToStringArray(Course[] courses)
        {
            string[] courseOrder = new string[courses.Length];

            for (int i = 0; i < courses.Length; i++)
            {
                courseOrder[i] = courses[i].GetCourseName();
            }

            return courseOrder;
        }

        private static Course[] PlanCoursesBasedOnPrerequisites(string[] courses, string[][] courseDependencies)
        {
            CourseDependencyGraph courseGraph = BuildGraphDataStructure(courses, courseDependencies);

            return OrderCourses(courseGraph.GetNodes());
        }

        public string[] PlanCoursesWrapper(string[] courses, string[][] courseDependencies)
        {
            Course[] courseOrder = PlanCoursesBasedOnPrerequisites(courses, courseDependencies);

            if (courseOrder == null)
            {
                return null;
            }
            string[] courseStringArray = ConvertToStringArray(courseOrder);

            return courseStringArray;
        }
    }
}
