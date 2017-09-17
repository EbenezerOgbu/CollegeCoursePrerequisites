using System;
using CollegeCoursePrerequisites.Service;
using Ninject;

namespace CollegeCoursePrerequisites.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            IKernel kernal = new StandardKernel(new CourseManagementModule());

            //These are the valid inputs

            string[] testCourses = { "Introduction to Paper Airplanes: ",
                                     "Advanced Throwing Techniques: Introduction to Paper Airplanes",
                                     "History of Cubicle Siege Engines: Rubber Band Catapults 101",
                                     "Advanced Office Warfare: History of Cubicle Siege Engines",
                                     "Rubber Band Catapults 101: ",
                                     "Paper Jet Engines: Introduction to Paper Airplanes" };

            //These are the invalid inputs


            //string[] testCourses = {
            //    "Intro to Arguing on the Internet: Godwin’s Law",
            //    "Understanding Circular Logic: Intro to Arguing on the Internet",
            //    "Godwin’s Law: Understanding Circular Logic"};

            var prepareCoursesForInput = kernal.Get<PrepareCoursesForInput>();
            var courseManager = kernal.Get<CourseManager>();


            prepareCoursesForInput.PrepareCourses(testCourses);

            string[] courses = prepareCoursesForInput.GetCourseList();

            string[][] courseDependencies = prepareCoursesForInput.GetAllCoursesAndTheirPrerequisites();

            string[] courseOrder = courseManager.PlanCoursesWrapper(courses, courseDependencies);

            if (courseOrder == null)
            {
                Console.WriteLine("Circular Dependencies.");
                Console.ReadKey();
            }
            else
            {
                foreach (string s in courseOrder)
                {
                    Console.WriteLine(s);
                }
                Console.ReadKey();
            }
        }
    }
}
