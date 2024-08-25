namespace EFCore1VN.EFStudentTeacher;

public class Student
{
    public long Id { get; set; }
    public string Name { get; set; }
    public List<Teacher> Teachers { get; set; } = new();
    public bool IsDeleted { get; set; }
}