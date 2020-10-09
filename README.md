# Generics-List-Splitter

The project has been realized in order to achieve list splitting based on a value. For instance if you have a list of 6 elements and you want to split it into 3 list of 2 elements you're in the right place!! Simple inject , via service provider , an instance of IListSplitterHelper interface and call "Split" method providing as first param your elements list and as second param 2 ( or your splitting value ).

# Example scenario ( with snippet )

You have a list of students and you want to divide them into a different list of 2 students for each. 
Starting from a class registered into service provider that has an IListSplitterHelper instance , provided in constructor , you could use this snippet to perform splitting operations : 

```csharp
// init service provider
var services = new ServiceCollection();
// registered type in service provider 
services.AddSingleton<IListSplitterHelper, ListSplitterHelper>();
// resolving IListSplitterHelper
var listSplitterHelper = servicer.GetRequiredService<IListSplitterHelper>();
// init a students list
var students = new List<Student>();
// adding some students
students.Add(new Student { Name = "Stefano", Surname = "Seghetti" });
students.Add(new Student { Name = "Marco", Surname = "Manetta" });
students.Add(new Student { Name = "Rosa", Surname = "Vannicola" });
students.Add(new Student { Name = "Gabriella", Surname = "Marchei" });
// splitting students in list of 2 elements for each.
List<List<Student>> splittedStudentsList = listSplitterHelper.Split<Student>(students, 2);

// splittedStudentList value  
// at index 0 will be present a list of students containing student "Stefano Seghetti" and "Marco Manetta"
// at index 1 will be present a list of students containing student "Rosa Vannicola" and "Gabriella Marchei"
```
# Project architecture

Project meets DI SOLID principle in fact in Program.cs class there is a service provider in order to register and resolve types at runtime. All classes that involve business logic , at the moment only ListSplitterHelper , implement an interface in order to achieve a common behavior that could be modified , if necessary , for future purposes.Last , but not least , this project is completely runned on a Linux docker container.

# Run requirements

In order to run this simple project you must have installed Docker in your computer. Clone this repo and run the project from command line or Visual Studio 
