using ListSplitter.Interfaces;
using ListSplitter.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListSplitter
{
    public class Startup
    {
        #region Attributes 
        /// <summary>
        /// list splitter helper instance.
        /// </summary>
        private IListSplitterHelper listSplitterHelper;
        #endregion
        #region Ctor
        public Startup(IListSplitterHelper listSplitterHelper)
        {
            //Implemententing dependency injection principle. IListSPlitterHelper instance will be resolved and provided by ioc container in Program.cs class
            this.listSplitterHelper = listSplitterHelper;
        }
        #endregion
        #region Methods

        /// <summary>
        /// Application entry point method
        /// </summary>
        public void Start()
        {
            //create a list of students 
            List<Student> students = new List<Student>();
            //adding some students
            students.Add(new Student { Name = "Stefano", Surname = "Seghetti" });
            students.Add(new Student { Name = "Marco", Surname = "Manetta" });
            students.Add(new Student { Name = "Rosa", Surname = "Vannicola" });
            students.Add(new Student { Name = "Gabriella", Surname = "Marchei" });
            //i want to divide students in list of 2 elements for each.
            List<List<Student>> splittedStudentsList = listSplitterHelper.Split<Student>(students, 2);
            //print to console students couple name 
            foreach (List<Student> currentStudentsCouple in splittedStudentsList)
            {
                Console.WriteLine("Here is it a couple of students: ");
                currentStudentsCouple.ForEach(student => Console.WriteLine($"{student.Name} {student.Surname}"));
            }
            //create a list of cars 
            List<Car> cars = new List<Car>();
            //adding some cars
            cars.Add(new Car { Manufacter = "Fiat", Model = "Panda" });
            cars.Add(new Car { Manufacter = "Fiat", Model = "Idea" });
            cars.Add(new Car { Manufacter = "Fiat", Model = "Duna" });
            //i want to divide students in list of 2 elements for each.
            List<List<Car>> splittedCarsList = listSplitterHelper.Split<Car>(cars, 2);//Dividing a list of 3 elements in lists of 2 elements "algorithm" will return a list of 2 and a list of 1
            //print to console students couple name 
            foreach (List<Car> currentCarsCouple in splittedCarsList)
            {
                Console.WriteLine("Here is it a couple of cars: ");
                currentCarsCouple.ForEach(car => Console.WriteLine($"{car.Manufacter} {car.Model}"));
            }
        }
        #endregion
    }
}
