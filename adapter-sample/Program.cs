using System;

public interface ICourse
{
    void Start();
    string GetDetails();
}

public class InPersonCourse : ICourse
{
    private string _courseName;
    private string _location;
    
    public InPersonCourse(string courseName, string location)
    {
        _courseName = courseName;
        _location = location;
    }
    
    public void Start()
    {
        Console.WriteLine($"Bắt đầu khóa học trực tiếp: {_courseName}");
        AttendClass();
    }
    
    public string GetDetails()
    {
        return $"Khóa học trực tiếp: {_courseName} tại {_location}\n{GetSchedule()}";
    }
    
    public void AttendClass()
    {
        Console.WriteLine($"Tham gia lớp học tại {_location}");
    }
    
    public string GetSchedule()
    {
        return "Lịch học: Thứ 2, Thứ 4, Thứ 6 từ 14:00-16:00";
    }
}

public class OnlineCourse
{
    private string _courseName;
    private string _platform;
    
    public OnlineCourse(string courseName, string platform)
    {
        _courseName = courseName;
        _platform = platform;
    }
    
    public void JoinSession()
    {
        Console.WriteLine($"Tham gia buổi học trực tuyến trên {_platform}");
    }
    
    public string ViewTimetable()
    {
        return "Lịch học trực tuyến: Thứ 3, Thứ 5 từ 19:00-21:00";
    }
    
    public string CourseName => _courseName;
    public string Platform => _platform;
}

public class SelfStudyCourse
{
    private string _courseName;
    private string _materials;
    
    public SelfStudyCourse(string courseName, string materials)
    {
        _courseName = courseName;
        _materials = materials;
    }
    
    public void AccessMaterial()
    {
        Console.WriteLine($"Truy cập tài liệu học tập: {_materials}");
    }
    
    public string GetDeadline()
    {
        return "Hạn chót hoàn thành: 30 ngày kể từ ngày đăng ký";
    }
    
    public string CourseName => _courseName;
    public string Materials => _materials;
}

public class OnlineCourseAdapter : ICourse
{
    private readonly OnlineCourse _onlineCourse;
    
    public OnlineCourseAdapter(OnlineCourse onlineCourse)
    {
        _onlineCourse = onlineCourse;
    }
    
    public void Start()
    {
        Console.WriteLine($"Bắt đầu khóa học trực tuyến: {_onlineCourse.CourseName}");
        _onlineCourse.JoinSession();
    }
    
    public string GetDetails()
    {
        return $"Khóa học trực tuyến: {_onlineCourse.CourseName} " +
               $"trên nền tảng {_onlineCourse.Platform}\n" +
               $"{_onlineCourse.ViewTimetable()}";
    }
}

public class SelfStudyCourseAdapter : ICourse
{
    private readonly SelfStudyCourse _selfStudyCourse;
    
    public SelfStudyCourseAdapter(SelfStudyCourse selfStudyCourse)
    {
        _selfStudyCourse = selfStudyCourse;
    }
    
    public void Start()
    {
        Console.WriteLine($"Bắt đầu khóa học tự học: {_selfStudyCourse.CourseName}");
        _selfStudyCourse.AccessMaterial();
    }
    
    public string GetDetails()
    {
        return $"Khóa học tự học: {_selfStudyCourse.CourseName} " +
               $"với tài liệu {_selfStudyCourse.Materials}\n" +
               $"{_selfStudyCourse.GetDeadline()}";
    }
}

public class EducationManagementSystem
{
    public static void Main(string[] args)
    {
        ICourse inPersonCourse = new InPersonCourse("Lập trình C#", "Phòng A1");
        
        OnlineCourse onlineCourse = new OnlineCourse("Machine Learning", "Microsoft Teams");
        ICourse onlineCourseAdapter = new OnlineCourseAdapter(onlineCourse);
        
        SelfStudyCourse selfStudyCourse = new SelfStudyCourse("Tiếng Anh", "Sách và video");
        ICourse selfStudyCourseAdapter = new SelfStudyCourseAdapter(selfStudyCourse);
        
        Console.WriteLine("=== Khóa học trực tiếp ===");
        inPersonCourse.Start();
        Console.WriteLine(inPersonCourse.GetDetails());
        
        Console.WriteLine("\n=== Khóa học trực tuyến ===");
        onlineCourseAdapter.Start();
        Console.WriteLine(onlineCourseAdapter.GetDetails());
        
        Console.WriteLine("\n=== Khóa học tự học ===");
        selfStudyCourseAdapter.Start();
        Console.WriteLine(selfStudyCourseAdapter.GetDetails());
    }
}