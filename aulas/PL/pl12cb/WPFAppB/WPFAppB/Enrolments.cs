using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Linq;
using System.IO;

namespace WPFAppB
{
    public class Enrolments
    {
        const char IFS = ';';

        public Dictionary<string, Student> students;

        public event voidNoArgs ReadEnded;
        public event voidNoArgs WriteEnded;
        public event voidNoArgs EnrolmentsUpdated;

        public Enrolments()
        {
            students = new Dictionary<string, Student>();
        }

        public void ReadFromTXT(string file)
        {
            students.Clear();

            StreamReader sr = new StreamReader(file);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] StudentData = line.Split(IFS);

                Student student = new Student(StudentData[0], StudentData[1], StudentData[2]);

                if (StudentData[3] == "Inscrito")
                    student.Subscribed = true;
                else
                    student.Subscribed = false;

                students.Add(student.Number, student);
            }
            sr.Close();

            if (ReadEnded != null)
                ReadEnded();
        }

        public void WriteToTXT(string file)
        {
            if (students.Count == 0)
                //throw new InvalidOperationException("Nao existem dados para serem guardados!");
                throw new ApplicationException("Nao existem dados para serem guardados!");

            StreamWriter sw = new StreamWriter(file);
            foreach (Student student in students.Values)
            {
                string line = student.Number + IFS + student.Name + IFS + student.Course + IFS;
                if (student.Subscribed == true)
                    line += "Inscrito";
                else
                    line += "NaoInscrito";
                sw.WriteLine(line);
            }
            sw.Close();

            if (WriteEnded != null)
                WriteEnded();
        }

        public void ReadFromXML(string file)
        {
            XDocument doc = XDocument.Load(file);

            var regists = from student in doc.Element("Alunos").Element("Inscritos").Descendants("Aluno") select student;

            foreach (var fields in regists)
            {
                Student student = new Student(fields.Attribute("Numero").Value,
                                                 fields.Element("Nome").Value,
                                                 fields.Element("Curso").Value);
                student.Subscribed = true;
                students.Add(student.Number, student);
            }

            regists = from student in doc.Element("Alunos").Element("NaoInscritos").Descendants("Aluno") select student;

            foreach (var fields in regists)
            {
                Student student = new Student(fields.Attribute("Numero").Value,
                                                 fields.Element("Nome").Value,
                                                 fields.Element("Curso").Value);
                student.Subscribed = false;
                students.Add(student.Number, student);
            }

            if (ReadEnded != null)
                ReadEnded();
        }

        public void WriteToXML(string file)
        {
            if (students.Count == 0)
                //throw new InvalidOperationException("Nao existem dados para serem guardados!");
                throw new ApplicationException("Nao existem dados para serem guardados!");

            XDocument xdoc = new XDocument(new XDeclaration("1.0", Encoding.UTF8.ToString(), "yes"),
                                           new XComment("Listagem de alunos"),
                                           new XElement("Alunos",
                                               new XElement("Inscritos"),
                                               new XElement("NaoInscritos")));

            foreach (Student student in students.Values)
            {
                XElement xstudent = new XElement("Aluno", new XAttribute("Numero", student.Number),
                                    new XElement("Nome", student.Name),
                                    new XElement("Curso", student.Course));

                if (student.Subscribed == true)
                    xdoc.Element("Alunos").Element("Inscritos").Add(xstudent);
                else
                    xdoc.Element("Alunos").Element("NaoInscritos").Add(xstudent);
            }
            xdoc.Save(file);

            if (WriteEnded != null)
                WriteEnded();
        }

        public void ChangeSubscrition(string number)
        {
            Student student;
            students.TryGetValue(number, out student);

            if (student != null)
            {
                student.Subscribed = !student.Subscribed;

                if (EnrolmentsUpdated != null)
                    EnrolmentsUpdated();
            }
        }
    }
}
