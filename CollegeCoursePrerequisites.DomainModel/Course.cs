using System.Collections;
using System.Collections.Generic;

namespace CollegeCoursePrerequisites.DomainModel
{
    public class Course
    {
        private IList<Course> _children;
        private Hashtable _map;
        private string _name;
        private int _courseDependencies;

        public Course(string name)
        {
            _children = new List<Course>();
            _map = new Hashtable();
            _name = name;
            _courseDependencies = 0;
        }

        public string GetCourseName()
        {
            return _name;
        }

        public void AddCourseNeighbour(Course node)
        {
            if (!_map.ContainsKey(node.GetCourseName()))
            {
                _children.Add(node);
                _map.Add(node.GetCourseName(), node);
                node.IncreaseCourseDependencies();
            }
        }

        public void IncreaseCourseDependencies()
        {
            _courseDependencies++;
        }
        public void DecreaseCourseDependencies()
        {
            _courseDependencies--;
        }
        public IEnumerable<Course> GetCourseChildren()
        {
            return _children;
        }


        public int GetNumberOfDependencies()
        {
            return _courseDependencies;
        }

    }
}
