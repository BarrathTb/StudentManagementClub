/*
 * Name: Thomas Barrath
 * College Class: Intro to Programming with C#
 * Assignment: Final Project
 * Date: 2022-09-28
 * Due-Date: 2022-10-09
 */




using Helper;
using StudentManagement;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

using System.Reflection;


Console.SetWindowSize(width:153, height:25);

var assembly = Assembly.GetExecutingAssembly();
var resourceName = assembly.GetManifestResourceNames()
  .Single(str => str.EndsWith("title.txt"));

using (Stream stream = assembly.GetManifestResourceStream(resourceName))
using (StreamReader reader = new StreamReader(stream))
{
    string result = reader.ReadToEnd();

    var defaultForgroundColor = Console.ForegroundColor;
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(result);

    Console.ForegroundColor = defaultForgroundColor;
}

Console.WriteLine("Welcome To The Student Management Club\n");
List<Student> students = new List<Student>();
//method to print main program menu 
void DisplayMainMenu()
{

    Console.WriteLine("Student Club Management: Main Menu\n");
    Console.WriteLine("1. Add Student");
    Console.WriteLine("2. Delete Student");
    Console.WriteLine("3. Edit Student");
    Console.WriteLine("4. List Students");
    Console.WriteLine("5. Exit\n");

    Console.WriteLine("Select an option:\n");
}
 bool exitFlag = false;
string userInput = "";
//switch loop to activate menu for adding, editing, deleteing student objects from class list
do
{
    
    DisplayMainMenu();
    switch (Console.ReadLine())
    {
        
        case "1":
            StartAddingStudents();
            break;
        
        case "2":
            DeleteStudent();
            break;
        
        case "3":
            EditStudentList();
            break;
        
        case "4":
            ShowStudentList();
            break;
        
        case "5":
        exitFlag = true;
            break;

        default:
            if(userInput == null || userInput == "")
            {
                Console.WriteLine("Please make a menu selection\n");
                continue;
            }
            exitFlag = true;
            break;
            


    }
} while (!exitFlag);


//method to print list for user to reference
void ShowStudentList()
{
    if (students.Count > 0)
    {

        for (int i = 0; i < students.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {students[i].ToString()}\n");
        }
        

    }
    else
    {
        Console.WriteLine("The student list is empty:\nPlease Add Students to the List:\nPress 0 to exit to main menu:\n");
        
    }
    
}
//method to add student objects to list by user
void StartAddingStudents()
{
bool doneAdding = false;

    while(doneAdding == false)
    {
        
        string studentFirstNameInput = Input.GetStringWithPrompt("Please add a student to the list:\n\nType end to exit the Add Student - Menu:\n\nEnter students first name:\n\n", "Please input valid student name info: \n");
        if (studentFirstNameInput == "end")
        {

            doneAdding = true;
            break;

        }
        string studentLastNameInput = Input.GetStringWithPrompt("Enter students Last name:\n", "Please input valid student name info:\n");
        string studentEmailInput = Input.GetStringWithPrompt($"Please add a student email:\n", "Please enter a valid email address:");


        
        
        if (studentFirstNameInput != null && studentEmailInput != null && studentLastNameInput != null)
        {
            
            students.Add(new Student(studentFirstNameInput, studentLastNameInput, studentEmailInput));

            
        }
        studentFirstNameInput = "";
        studentLastNameInput = "";
        studentEmailInput = "";
    } 
    
}
void DeleteStudent()
{
    ShowStudentList();
    bool doneDeleting = false;
    do
    {
        
        int removalPosition = Input.GetIntWithPrompt("Please select the student you would like to remove:\nPress 0 to return to main menu:\n", "Please enter a number for the student you would like to remove\n");
        if (removalPosition == 0)
        {
            break;
        }
        if (removalPosition > 0)
        {
            students.RemoveAt(removalPosition - 1);
            break;
        }
        while (removalPosition < 0)
        {   
          
            Console.WriteLine("Please enter a whole number to make selection: \n");

        }
    } while (doneDeleting == false);

}
//method to edit student objects entered into list by user
void EditStudentList()
{

    
    
        ShowStudentList();
        bool doneEditing = false;
        do
        {

            int userEditStudent = Input.GetIntWithPrompt($"Enter a whole number to select a student from the list to edit student informaton:\nType 0 to exit the Edit student menu: ", "Please enter a whole number to make edit selection: ");

            while (userEditStudent < 0)
            {
                Console.WriteLine("Please enter a whole number to make edit selection: ");
                userEditStudent = Input.GetIntWithPrompt($"Enter a whole number to select a student from the list to edit student informaton: \n", "Please enter a whole number to make edit selection: ");
            }
            if (userEditStudent == 0)
            {
                break;
            }
            string userEditStudentFirstName = Input.GetStringWithPrompt("Please enter a new first name for student: ", "Please input valid student name info: \n");
            string userEditStudentLastName = Input.GetStringWithPrompt("Please enter a new Last name for student: ", "Please input valid student name info: \n");
            string userEditStudentEmail = Input.GetStringWithPrompt("Please enter a new Email for student: ", "Please input valid student Email address: \n");

            if (userEditStudent > 0)
            {
                students[userEditStudent - 1].StudentFirstName = userEditStudentFirstName;
                students[userEditStudent - 1].StudentLastName = userEditStudentLastName;
                students[userEditStudent - 1].StudentEmail = userEditStudentEmail;

            }

        } while (doneEditing == false);
}



namespace StudentManagement
{
    // student class for properties that will create objects of students entered into list by user
    class Student
    {
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public string StudentEmail { get; set; }
        
        //constructors
        public Student(string studentFirstNameInput, string studentLastNameInput, string studentEmailInput)
        {
            StudentFirstName = studentFirstNameInput;
            StudentLastName = studentLastNameInput;
            StudentEmail = studentEmailInput;

        }

        //override method tostring to print list objects nicely
        public override string ToString()
        {
            return $"{StudentFirstName} {StudentLastName} | {StudentEmail}";
        }
        
    }
}

