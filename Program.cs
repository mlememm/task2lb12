using System.Xml;
class CalculateAverageMarks
{
    public static void Run()
    {
        XmlDocument doc = new XmlDocument();
        doc.Load("students.xml");

        XmlNodeList studentNodes = doc.SelectNodes("//Student");
        foreach (XmlNode student in studentNodes)
        {
            string name = student.Attributes["name"].Value;
            int total = 0;
            int count = 0;

            foreach (XmlNode subject in student.ChildNodes)
            {
                if (int.TryParse(subject.InnerText, out int mark))
                {
                    total += mark;
                    count++;
                }
            }
            double average = count > 0 ? (double)total / count : 0;
            Console.WriteLine($"{name}: average mark = {average:F2}");
        }
    }
}
class Program
{
    static void Main()
    {
        CalculateAverageMarks.Run();
    }
}
