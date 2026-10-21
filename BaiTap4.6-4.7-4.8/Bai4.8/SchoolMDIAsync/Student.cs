using System.ComponentModel;

namespace SchoolMDIAsync
{
    public class Student : INotifyPropertyChanged
    {
        private static int _counter = 1;
        private string _studentId = string.Empty;
        private string _fullName  = string.Empty;
        private int    _age;
        private string _gender     = "Nam";
        private string _avatarPath = string.Empty;

        public string StudentId  { get => _studentId;  set { _studentId  = value; OnPC(nameof(StudentId));  } }
        public string FullName   { get => _fullName;   set { _fullName   = value; OnPC(nameof(FullName));   } }
        public int    Age        { get => _age;        set { _age        = value; OnPC(nameof(Age));        } }
        public string Gender     { get => _gender;     set { _gender     = value; OnPC(nameof(Gender));     } }
        public string AvatarPath { get => _avatarPath; set { _avatarPath = value; OnPC(nameof(AvatarPath)); } }

        public Student() { StudentId = $"SV{_counter:D4}"; _counter++; }
        public Student(string id, string name, int age, string gender, string avatar = "")
        { StudentId = id; FullName = name; Age = age; Gender = gender; AvatarPath = avatar; }

        public static void ResetCounter(int v = 1) => _counter = v;
        public string ToCsvLine() =>
            $"\"{StudentId}\",\"{FullName}\",{Age},\"{Gender}\",\"{AvatarPath}\"";

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPC(string n) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(n));
    }
}
