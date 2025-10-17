public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Department { get; set; }

    public Student(int Id, string Name, int Age, string Department)
    {
        this.Id = Id;
        this.Name = Name;
        this.Age = Age;
        this.Department = Department;
    }

}
class Program
{

    public static void AddStudent()
    {
        Console.WriteLine("Enter Student Id:");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Student Name:");
        string name = Console.ReadLine();
        Console.WriteLine("Enter Student Age:");
        int age = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Student Department:");
        string department = Console.ReadLine();
        Student st = new Student(id, name, age, department);
        using (FileStream file = new FileStream("student.txt", FileMode.Append))
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(file))
                {
                    writer.WriteLine($"{st.Id},{st.Name},{st.Age},{st.Department},{st}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                file.Close();
            }
        }
    }
    public static void ViewStudent()
    {
        using (FileStream file = new FileStream("student.txt", FileMode.Open))
        {
            try
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    string data = reader.ReadToEnd();
                    Console.WriteLine(data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                file.Close();
            }
        }

    }
    static void Main(string[] args)
    {
        int choice;
        do
        {
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Display Students");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Enter your choice:");
            choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                AddStudent();
            }
            else if (choice == 2)
            {
                ViewStudent();
            }
            else if(choice ==3)
            {
                Environment.Exit(0);
            }
        } while (choice != 3);
    }
}