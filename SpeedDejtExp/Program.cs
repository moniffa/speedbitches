namespace SpeedDejtExp
{
   
    internal class Program
    {
        public static List<Person> People;
        static void Main(string[] args)
        {
            People= new List<Person>();

            ReadFile();
            GenerateMatches();
            //ShowMatches();
            //PrintText();
            WriteToFile();
        }

        private static void WriteToFile()
        {
            File.WriteAllLines(@"C:\Users\monira_warsame\source\repos\speedbitches\Resultat.txt", People.Select(person => person.GetDescription()));
        }

        private static void PrintText()
        {
            foreach (var person in People)
            {
                Console.WriteLine(person.GetDescription());
                Console.WriteLine("------------------");
            }
        }

        private static void ShowMatches()
        {
            foreach (var person in People)
            {
                Console.WriteLine(person.IDNr+ " : " +
                    person.Name + " Matches with " + string.Join(", ", person.Matches.Select(person=>person.IDNr)));
                Console.WriteLine();
            }
        }

        private static void GenerateMatches()
        {
            foreach (var person in People)
            {
                person.CheckMatches(People);
            }
        }

        static void ReadFile()
        {
            var fileLines = File.ReadLines(@"C:\Users\monira_warsame\source\repos\speedbitches\anmalan.tsv").ToList();
            for (int i = 1; i < fileLines.Count; i++)
            {
                var personString = fileLines[i].Split('\t');
                if (personString[9] == "ja")
                {
                    Person person = new Person();
                    person.Matches = new List<Person>();
                    person.Name = personString[1];
                    person.IDNr = Int32.Parse(personString[10]);
                    person.Instagram = personString[4];
                    if (!string.IsNullOrEmpty(personString[11]))
                    {

                     person.Choices = personString[11].Split(',', '.').Select(int.Parse).ToList();
                    }
                    else
                    {
                        person.Choices = new List<int>();
                    }
                    
                    People.Add(person);
                }
            }

        }
    }
} 