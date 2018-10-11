using System;
using System.Linq;
using System.Collections.Generic;

namespace AssignmentLINQTutorial
{
    public class Student
    {
        //PK
        public int StudentID { get; set; } = 1; 
        public string StudentName { get; set; }

        public string StudentLastName { get; set; }
        public short Age {get; set; }

        public string Role {get; set; }

        public bool hasTakenDB {get; set;}

        //FK
        public int TeamID {get; set;}

        public override string ToString()
        {
            return $"{StudentName}";
        }

    }
}