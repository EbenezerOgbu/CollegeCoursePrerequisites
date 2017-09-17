using System.Collections;
using System.Collections.Generic;

namespace CollegeCoursePrerequisites.DomainModel
{
    public class CourseDependencyGraph
    {
        private IList<Course> _nodes;
        private Hashtable _map;

        public CourseDependencyGraph()
        {
            _nodes = new List<Course>();
            _map = new Hashtable();
        }

        public Course CreateNewOrGetExistingNode(string name)
        {
            if (!_map.ContainsKey(name))
            {
                Course node = new Course(name);
                _nodes.Add(node);
                _map.Add(name, node);
            }

            return (Course)_map[name];
        }

        public void AddEdge(string startName, string endName)
        {
            Course start = CreateNewOrGetExistingNode(startName);
            Course end = CreateNewOrGetExistingNode(endName);

            start.AddCourseNeighbour(end);
        }

        public IEnumerable<Course> GetNodes()
        {
            return _nodes;
        }
    }
}
