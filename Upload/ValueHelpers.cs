using System;
using System.Collections.Generic;
using System.Linq;
using ESDotNetClient.Model;

namespace ESDotNetClient
{
    public static class ValueHelpers
    {
        static Random random = new Random();
        
        public static User GenerateUser(string id)
        {
            return new User {
                Id = id,
                FirstName = GenerateWord(5),
                LastName = GenerateWord(5),
                Location = GetRandomCountry(),
                BirthDate = GenerateDate(),
                Skills = GenerateSkills()
            };
        }

        private static string GetRandomCountry()
        {
            var arr = new [] {"Belarus", "Russia", "Ukraine", "Poland", "USA", "UK", "Australia", "China"};
            return arr[random.Next(0, 7)];
        }

        private static IEnumerable<string> GenerateSkills()
        {
            var skills = new [] {"JS", ".NET", "Java", "Python", "Ruby", "HTML", "CSS", "Elasticsearch"};
            
            int size = random.Next(1, 5);

            return skills
                .ToList()
                .OrderBy(x => Guid.NewGuid())
                .Take(size);
        }

        private static DateTime GenerateDate()
        {
            DateTime start = new DateTime(1980, 1, 1);
            int range = (DateTime.Today - start).Days;           
            return start.AddDays(random.Next(range));
        }

        private static string GenerateWord(int size)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            
            return UppercaseFirst(new string(
                Enumerable.Repeat(chars, size)
                .Select(s => s[random.Next(s.Length)])
                .ToArray()
            ));
        }

        private static string UppercaseFirst(string s)
        {
            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}