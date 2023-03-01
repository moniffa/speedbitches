using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedDejtExp
{
    internal class Person
    {
        public string Name { get; set; }
        public int IDNr { get; set; }

        public string Instagram { get; set; }

        public List<int> Choices { get; set; }

        public List<Person> Matches { get; set; }

        internal void CheckMatches(List<Person> people)
        {
            foreach (var person in people)
            {
                if (person.Choices.Contains(IDNr) && Choices.Contains(person.IDNr))
                {
                    Matches.Add(person);
                }
            }
        
        }

        public string GetDescription()
        {
            if (Matches.Count == 0)
            {
                return $"Hej {Name}! Jättekul att du joina oss ikväll!" +
                    $" Det blev tyvärr ingen matchning för ikväll " +
                    $"men don't worry vi kommer ha fler event " +
                    $"med fler roliga människor som dig. " +
                    $"Håll utkik på vår instagram inför nästa event. " +
                    $"Vi hoppas verkligen att vi ser dig igen!" +
                    $" Trevlig kväll!\n";
            }
            else
            {
                return $"Hej {Name}! Vad kul att du var med igår kväll " +
                    $"och vi är inte de enda som tycker det. " +
                    $"Du matchade med {string.Join(", ", Matches.Select(person => person.Instagram))}. " +
                    $"Nästa steg är upp till er och vi lämnar över ansvaret på er. " +
                    $"Hoppas detta blir en perfekt matchning," +
                    $" annars är du alltid välkommen tillbaka till vårt nästa event!\n";
            }


        }
    }
}
