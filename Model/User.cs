using System;
using System.Collections.Generic;

namespace ESDotNetClient.Model
{
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName {get; set;}
        public DateTime BirthDate {get; set;}
        public string Location {get; set;}
        public IEnumerable<string> Skills {get; set;}
    }
}