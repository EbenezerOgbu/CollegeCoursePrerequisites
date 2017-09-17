using System.Collections.Generic;
using System.Linq;

namespace CollegeCoursePrerequisites.Service
{
    public class PrepareCoursesForInput : IPrepareCoursesForInput
    {
        private IList<string> _allCoursesStringArray;
        private IList<string[]> _prerequisiteAndCourseArray;
        public PrepareCoursesForInput()
        {
            _allCoursesStringArray = new List<string>();
            _prerequisiteAndCourseArray = new List<string[]>();
        }
       

        public void PrepareCourses(string[] courses)
        {
            char[] separator = new char[] { ':' };
            char[] trimChar = new char[] { ' ' };

            foreach (string course in courses)
            {
                _allCoursesStringArray.Add(course.Split(separator)[0]);
                var trimmedString = course.Split(separator)[1].TrimStart(trimChar);
                if (trimmedString != "")
                {
                    _allCoursesStringArray.Add(trimmedString);
                }
                _prerequisiteAndCourseArray.Add(new[] { course.Split(separator)[1].TrimStart(trimChar), course.Split(separator)[0] });
            }
        }

        public string[] GetCourseList()
        {
            return _allCoursesStringArray.ToArray();
        }

        public string[][] GetAllCoursesAndTheirPrerequisites()
        {
            return _prerequisiteAndCourseArray.ToArray();
        }
    }
}
