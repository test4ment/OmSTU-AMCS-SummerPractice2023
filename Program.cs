using System;
using System.IO;
using System.Collections;
using Newtonsoft.Json;

public class Task{
    public string taskName;
    public Cadet[] data;

    public Responce Analyze(){
        IEnumerable result = null;

        if(this.taskName == "CalculateGPAByDiscipline"){
            // var discipline_marks = from discipline in data
            //         group discipline.mark by discipline.discipline;

            var discipline_marks = data.GroupBy(d => d.discipline, d => d.mark).Select(a => new Dictionary<string, double>() {[a.Key] = Math.Round(a.Average(), 2)});

            // Dictionary<string, double> disciplines_and_avg = discipline_marks.ToDictionary(a => a.Key, a => Math.Round(a.Average(), 2));

            // var disciplines_and_avg = discipline_marks.Select(a => new {a.Key, Math.Round(a.Average(), 2)});
            
            // result = new Dictionary<string, IEnumerable>() {["Response"] = discipline_marks};

            return new Responce(result);
        }
        if(this.taskName == "GetBestGroupsByDiscipline"){
            var disciplines = (data.GroupBy(d => d.discipline, e => new {group = e.group, mark = e.mark})).Select(a => new {discipline = a.Key, other = a});

            var disciplines_grouped = disciplines.Select(a => new {discipline = a.discipline, groups = a.other.GroupBy(b => b.group, b => b.mark, (group, mark) => new {Key = group, avg = mark.Average()})});

            result = disciplines_grouped.Select(a => new{Discipline = a.discipline, Group = a.groups.MaxBy(b => b.avg).Key, GPA = a.groups.MaxBy(b => b.avg).avg});
            //Select(a => new {avg = a.Average(b => b.mark)})
            return new Responce(result);
        }
        if(this.taskName == "GetStudentsWithHighestGPA"){
            // var students_marks = from student in data
            //         group student.mark by student.name;

            var students_marks = data.GroupBy(s => s.name, s => s.mark);

            // var students_averages = from marks in students_marks
            //         select new {Cadet = marks.Key, GPA = Math.Round(marks.Average(), 2)};
            
            var students_averages = students_marks.Select(cadet => new {Cadet = cadet.Key, GPA = Math.Round(cadet.Average(), 2)});

            // var best_students = from student in students_averages
            //                     where student.GPA == students_averages.Max(x => x.GPA)
            //                     select student;
            
            var best_students = students_averages.Where(student => student.GPA == students_averages.Max(x => x.GPA));
            
            result = best_students;
        }

        return new Responce(result);
    }
}

public class Cadet{
    public string name;
    public string group;
    public string discipline;
    public int mark;
}

public class Responce{
    public IEnumerable Response;

    public Responce(IEnumerable obj){
        this.Response = obj;
    }
}

public class Space_Cadets
{
    public static void Main(string[] args){
        string input_path = args[0];
        string output_path = args[1];

        // string input_path = "/home/ubuntu/OmSTU-AMCS-SummerPractice2023/Localtests/GetBestGroupsByDiscipline.json";
        // string output_path = "/home/ubuntu/OmSTU-AMCS-SummerPractice2023/Localtests/debug.out.json";
        
        string output;

        if(File.Exists(input_path)){
            string file = File.ReadAllText(input_path);
            Task space_cadets = JsonConvert.DeserializeObject<Task>(file);
            output = JsonConvert.SerializeObject(space_cadets.Analyze(), Newtonsoft.Json.Formatting.Indented);
            Console.WriteLine(output);
            File.WriteAllText(output_path, output);
        }
    }
}
