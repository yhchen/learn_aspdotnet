namespace EFCore1VN.EFStudentTeacher;

public class Teacher
{
    public long Id { get; set; }
    public string Name { get; set; }
    public List<Student> Students { get; set; } = new();
    public bool IsDeleted { get; set; }
}