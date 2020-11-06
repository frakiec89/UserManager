using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager
{
    public class ContrillerStudent
    {
        string writePath = "User.txt";


        public List<Student> Students { get; private set; }

        public ContrillerStudent()
        {
            Students = RunStudent();
        }

        public void Add(string name, string age)
        {
            var s = new Student { Age = age, Name = name };

            Students.Add(s);
            Save();
        }

        public void DellUser(string name)
        {
            var ss = Students.Find(x => x.Name == name);
            if (ss != null)
            {
                Students.Remove(ss);
                Save();
            }
        }


        private void Save()
        {
            string saveString = "";

            for (int i = 0; i < Students.Count; i++)
            {
                saveString += GetStudentString(Students[i]);
            }

            StreamWriter stream = new StreamWriter(writePath, false, Encoding.Default );
            stream.WriteLine(saveString);
            stream.Close();
        }

        private string GetStudentString(Student student)
        {
            string s = student.Name + ";" + student.Age + "*";
            return s;
        }

        private List<Student> RunStudent()
        {
            List<Student> newList = new List<Student>();
            StreamReader stream;
            try
            {
                stream = new StreamReader(writePath, Encoding.Default);
            }
            catch
            {
                return new List<Student>();
            }
            string content = stream.ReadToEnd();

            string[] userSt = content.Split('*');

            for (int i = 0; i < userSt.Length; i++)
            {
                Student newStudent = GetNewStudent(userSt[i]);
                if (newStudent != null)
                {
                    newList.Add(newStudent);
                }
            }

            stream.Close();

            return newList;
        }

        private Student GetNewStudent(string userSt)
        {
            try
            {
                string[] nameAge = userSt.Split(';');

                string name = nameAge[0];
                string age = nameAge[1];

                if (String.IsNullOrWhiteSpace(name) || String.IsNullOrWhiteSpace(age))
                {
                    throw new Exception();
                }
                return new Student() { Name = name, Age = age };
            }
            catch
            {
                return null;
            }
        }
    }
}
