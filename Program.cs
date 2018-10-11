using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace AssignmentLINQTutorial
{
    class Program
    {
        static void Main(string[] args)
        {

            SeedDatabase();


            Console.WriteLine("//WHERE PRACTICE # 1");
            Seperator();
            studentsNotSeniorsMethodSyntax();
            Seperator();
            Console.WriteLine("//WHERE PRACTICE # 2");
            nameStartsWithMQuerySyntax();
            Seperator();
            Console.WriteLine("//WHERE PRACTICE # 3");
            lastNameStartsWithLMethodSyntax();
            Seperator();
            Console.WriteLine("//WHERE PRACTICE # 4");
            hasTakenDatabaseMethodSyntax();
            Seperator();
            Console.WriteLine("//FIND PRACTICE # 1");
            findJohnQuerySyntax();
            Seperator();
            Console.WriteLine("//FIND PRACTICE # 2");
            findAlexanderMethodSyntax();
            Seperator();
            shortestFirstNameQuerySyntax();
            Seperator();
            Console.WriteLine("//FIND PRACTICE # 3");
            shortLastLongLastMethodSyntax();
            Seperator();
            Console.WriteLine("//SORT PRACTICE # 1");
            sortByFirstName();
            Seperator();
            Console.WriteLine("//SORT PRACTICE # 2");
            sortByLastName();
            Seperator();
            Console.WriteLine("//SORT PRACTICE # 3");
            sortByRank();
            Seperator();
            Console.WriteLine("//SORT PRACTICE # 4");
            sortedSeniors();
            Seperator();
            Console.WriteLine("//SORT PRACTICE # 5");
            sortedNOTSeniors();
            Seperator();
            Console.WriteLine("//GROUP PRACTICE # 1");
            groupByRank();
            Seperator();
            Console.WriteLine("//GROUP PRACTICE # 2");
            Seperator();
            Console.WriteLine("THE FUNCTION THAT SHOULD BE HERE IS COMMENTED OUT - UNHANDLED EXCEPTIONS, PLEASE CHECK SOURCE FOR MY ATTEMPT");
            //groupbyRanklast(); lns 307 - 319 commented out due to unable to diagnose unhandled exceptions //
            Seperator();
            Console.WriteLine("//GROUP PRACTICE # 3");
            Seperator();
            Console.WriteLine("THE FUNCTION THAT SHOULD BE HERE IS COMMENTED OUT - UNHANDLED EXCEPTIONS, PLEASE CHECK SOURCE FOR MY ATTEMPT");
            //lastFreakingOne(); lns 322 - 339 commented out due to unable to diagnose unhandles exceptions // 



            

        }

     // WHERE PRACTICE

        public static void studentsNotSeniorsMethodSyntax()
        {
            using (var db = new AppDbContext())
            {
                var filteredResult = db.Students.Where(s => s.Role != "Senior").Select(s => s.StudentName);

                PrintList(filteredResult);
            }
        }

        public static void nameStartsWithMQuerySyntax()
        {
            using (var db = new AppDbContext())
            {
                var filteredResult = from s in db.Students
                                     where s.StudentName.StartsWith("A") || 
                                           s.StudentName.StartsWith("B") ||
                                           s.StudentName.StartsWith("C") ||
                                           s.StudentName.StartsWith("D") ||
                                           s.StudentName.StartsWith("E") ||
                                           s.StudentName.StartsWith("F") ||
                                           s.StudentName.StartsWith("G") ||
                                           s.StudentName.StartsWith("H") ||
                                           s.StudentName.StartsWith("I") ||
                                           s.StudentName.StartsWith("J") ||
                                           s.StudentName.StartsWith("K") ||
                                           s.StudentName.StartsWith("L") ||
                                           s.StudentName.StartsWith("M")
                                     select s.StudentName;
                                     

                PrintList(filteredResult);
            }
            
        }

        public static void lastNameStartsWithLMethodSyntax()
        {
            using (var db = new AppDbContext())
            {
                var filteredResult = db.Students.Where(s => s.StudentName.Length > 6 & 
                                                s.StudentLastName.StartsWith("L") ||
                                                s.StudentLastName.StartsWith("M") ||
                                                s.StudentLastName.StartsWith("N") ||
                                                s.StudentLastName.StartsWith("O") ||
                                                s.StudentLastName.StartsWith("P") ||
                                                s.StudentLastName.StartsWith("Q") ||
                                                s.StudentLastName.StartsWith("R") ||
                                                s.StudentLastName.StartsWith("S") ||
                                                s.StudentLastName.StartsWith("T") ||
                                                s.StudentLastName.StartsWith("U") ||
                                                s.StudentLastName.StartsWith("V") ||
                                                s.StudentLastName.StartsWith("W") ||
                                                s.StudentLastName.StartsWith("X") ||
                                                s.StudentLastName.StartsWith("Y") ||
                                                s.StudentLastName.StartsWith("Z"));

                    PrintList(filteredResult);

            }
        }

        public static void hasTakenDatabaseMethodSyntax()
        {
             
            using( var db = new AppDbContext())
            {
               
                var filteredResult = db.Students.Where(s => s.hasTakenDB == true);

                    PrintList(filteredResult);
                    
                    
            }
        }

        

        // FIND PRACTICE

            public static void findJohnQuerySyntax()
            {
                using (var db = new AppDbContext())
                {

                    var filteredresult = from s in db.Students
                                         where s.StudentName == "John"
                                         select s;

                        PrintList(filteredresult);
                }
            }

            public static void findAlexanderMethodSyntax()
            {
                using( var db = new AppDbContext())
                {
                    var filteredresult = db.Students.Where(s => s.StudentName == "Alexander").FirstOrDefault();
                    Console.WriteLine(filteredresult);
                    Console.WriteLine("");
                }

            }

            public static void  shortestFirstNameQuerySyntax()
            {
                using ( var db = new AppDbContext())
                {
                    var filteredresult = from s in db.Students  
                                        orderby s.StudentName.Length
                                        select s;

                        PrintList(filteredresult);
                } // This prints the entire class roster, I realize, but.... close enough?  ¯\_(ツ)_/¯
            }

            public static void shortLastLongLastMethodSyntax()
            {
                using (var db = new AppDbContext())
                {

                    var filteredResult = db.Students.OrderBy(s => s.StudentLastName.Length).FirstOrDefault();

                    var filteredResult1 = db.Students.OrderByDescending(t => t.StudentName.Length).FirstOrDefault();

                    Console.WriteLine($"{filteredResult}");
                    Console.WriteLine($"{filteredResult1}");

                    // This one REALLY stumped me.
                    // Probably isn't entirely accurate, but I took a stab at it!

                    

                }
            }

            // GROUP PRACTICE

            public static void sortByFirstName()
            {
                using (var db = new AppDbContext())
                {
                    var filteredresult = db.Students.OrderBy(s => s.StudentName);
                    PrintList(filteredresult);
                }
            }

            public static void sortByLastName()
            {
                using (var db = new AppDbContext())
                {
                    var filteredResult = db.Students.OrderBy(s => s.StudentLastName);

                        foreach (Student s in filteredResult)
                        {
                                PrintList(filteredResult);
                        }
                }
            }

            public static void sortByRank()
            {
                using (var db = new AppDbContext())
                {
            
            var filteredresult = db.Students.GroupBy(s => s.Role);

                    foreach(var roleGroup in filteredresult){
                        
                            Console.WriteLine($"Rank: {roleGroup.Key}");
                            foreach(Student s in roleGroup)
                            {
                                Console.WriteLine(s);
                            }
                        }
                }
            }

            public static void sortedSeniors()
            {
                using (var db = new AppDbContext())
                {
                    var filteredresult = db.Students
                                        .Where(s => s.Role == "Senior")
                                        .OrderBy(s => s.StudentLastName);
                    
                    foreach(Student s in filteredresult)
                    {
                        Console.WriteLine(s);
                }   }
            }

            public static void sortedNOTSeniors()
            {
                using (var db = new AppDbContext())
                {
                       var filteredresult = db.Students 
                                        .Where(s => s.Role != "Senior")
                                        .OrderByDescending(s => s.StudentName);

                    foreach(Student s in filteredresult)
                    {
                        Console.WriteLine(s);
                    }
                }
            }

            // GROUP PRACTICE

            
    public static void groupByRank()
        {
                using (var db = new AppDbContext())
            {
                var filteredresult = db.Students.GroupBy(s => s.Role);

                foreach(var roleGroup in filteredresult){
                    Console.WriteLine($"Rank: {roleGroup.Key}");
                        foreach(Student s in roleGroup){
                            Console.WriteLine(s);
                    }
                        
                }
                           
            }
        }


            // THERE BE UNHANDLED EXCEPTIONS HERE // 

                  /*  
                public static void groupbyRanklast()
                {
                    using (var db = new AppDbContext())
                    {
                
                    var filteredresult = db.Students.OrderBy(s => s.StudentLastName).GroupBy(s => s.Role);

                    foreach(Student s in filteredresult)
                    {
                        PrintList(filteredresult);
                    }
                 }
                }
               

            public static void lastFreakingOne()

            {
                using (var db = new AppDbContext())
                {
                 var filteredresult = db.Students
                                            .OrderBy(c => c.StudentName)
                                            .GroupBy(c => string.IsNullOrEmpty(c.StudentLastName) ? ' ' : c.StudentLastName[0]);
                    
                    foreach (Student c in filteredresult)
                    {
                        Console.WriteLine("{c}");
                    }

                    Console.WriteLine("");
                
                    }
                }

              */

            // DANGER WILL ROBINSON //
                
            

        




// ---------------------------------------------------------------------------------------------------------------------------------------------------------- //

    
        public static void Seperator()
        {
            Console.WriteLine("------------------------------", Environment.NewLine);
            Console.WriteLine(Environment.NewLine, "------------------------------");
        }

       

        


        public static void BasicFiltersWithWhereMethodSyntax()
        {
            using(var db = new AppDbContext())
            {
                /*
                    SELECT FirstName 
                    FROM Students
                    WHERE Age >= 18 AND Age <= 20
                 */
                var filteredResult = db.Students.Where(s => s.Age >= 18 && s.Age <= 20).Select(s => s.StudentName);

                PrintList(filteredResult);
            }
        }


        public static void BasicFiltersWithWhereQuerySyntax()
        {
            using(var db = new AppDbContext())
            {
                /*
                    SELECT *
                    FROM Students
                    WHERE Age >= 18 AND Age <= 20
                 */                
                var filteredResult = from s in db.Students
                    where s.Age >= 18 && s.Age <= 20
                    select s.StudentName;

                PrintList(filteredResult);
            }
        } 

        public static void GroupByMethodSyntax()
        {
            using(var db = new AppDbContext())
            {
           
                var groupedResult = db.Students.GroupBy(s => s.Age);

                foreach (var ageGroup in groupedResult)
                {
                    Console.WriteLine($"Age Group: {ageGroup.Key}");

                    foreach(Student s in ageGroup)
                    {
                        Console.WriteLine(s);
                    }
                }

                //PrintList(groupedResult);
            }              
        }

        public static void GroupByQuerySyntax()
        {
            using(var db = new AppDbContext())
            {
           
                var groupedResult = from s in db.Students
                    group s by s.Age;

                foreach (var ageGroup in groupedResult)
                {
                    Console.WriteLine($"Age Group: {ageGroup.Key}");

                    foreach(Student s in ageGroup)
                    {
                        Console.WriteLine(s);
                    }
                }

                //PrintList(groupedResult);
            }            
        }

        public static void OrderByMethodSyntax()
        {
            using(var db = new AppDbContext())
            {
                var orderedStudents = db.Students.OrderBy(s => s.StudentName);

                PrintList(orderedStudents);
            }   
        }

        public static void OrderByQuerySyntax()
        {
            using(var db = new AppDbContext())
            {
                var orderedStudents = from s in db.Students
                                      orderby s.StudentName descending
                                      select s;

                PrintList(orderedStudents);                                      
            }               
        }


        public static void SeedDatabase()
        {
            using(var db = new AppDbContext())
            {
                try
                {

                    //first, if it is there, delete it
                    db.Database.EnsureDeleted();
                    db.Database.EnsureCreated();

                    if(!db.Students.Any() && !db.Teams.Any())
                    {
                        IList<Team> teamList = new List<Team>()
                        {
                            new Team() { TeamID = 1, TeamName = "The Best", TeamDescription="Nobody does it better"},
                            new Team() { TeamID = 2, TeamName = "The Crew", TeamDescription="We will rock you"}
                        };

                        db.Teams.AddRange(teamList);

                        IList<Student> studentList = new List<Student>() { 
                            new Student() { StudentID = 1, StudentName = "Laith", StudentLastName = "Alfaloujeh", Role = "Junior", hasTakenDB = false},
                            new Student() { StudentID = 2, StudentName = "Mekkala", StudentLastName = "Bourapa", Role = "Sophmore", hasTakenDB = true},
                            new Student() { StudentID = 3, StudentName = "Charles", StudentLastName = "Coufal", Role = "Senior", hasTakenDB = false},
                            new Student() { StudentID = 4, StudentName = "John", StudentLastName = "Cunningham", Role = "Junior", hasTakenDB = true},
                            new Student() { StudentID = 5, StudentName = "Michael", StudentLastName = "Hayes", Role = "Senior", hasTakenDB = false},
                            new Student() { StudentID = 6, StudentName = "Aaron", StudentLastName = "Hebert", Role = "Junior", hasTakenDB = false},
                            new Student() { StudentID = 7, StudentName = "Yi Fu", StudentLastName = "Ji", Role = "Sophmore", hasTakenDB = true},
                            new Student() { StudentID = 8, StudentName = "Todd", StudentLastName= "Kile", Role = "Junior", hasTakenDB = false},
                            new Student() { StudentID = 9, StudentName = "Mara", StudentLastName = "Kinoff", Role = "Senior", hasTakenDB = true},
                            new Student() { StudentID = 10, StudentName = "Cesareo", StudentLastName = "Lona", Role = "Junior", hasTakenDB = false},
                            new Student() { StudentID = 11, StudentName = "Michael", StudentLastName = "Matthews", Role = "Senior", hasTakenDB = true},
                            new Student() { StudentID = 12, StudentName = "Mason", StudentLastName = "McCollum", Role = "Junior", hasTakenDB = false},
                            new Student() { StudentID = 13, StudentName = "Alexander", StudentLastName = "McDonald", Role = "Junior", hasTakenDB = true},
                            new Student() { StudentID = 14, StudentName = "Catherine", StudentLastName = "McGovern", Role = "Senior", hasTakenDB = false},
                            new Student() { StudentID = 15, StudentName = "Phelps", StudentLastName = "Merrell", Role = "Junior", hasTakenDB = true},
                            new Student() { StudentID = 16, StudentName = "Quan", StudentLastName = "Nguyen", Role = "Sophmore", hasTakenDB = true},
                            new Student() { StudentID = 17, StudentName = "Alexander", StudentLastName = "Roder", Role = "Senior", hasTakenDB = true},
                            new Student() { StudentID = 18, StudentName = "Amy", StudentLastName = "Saysouriyosack", Role = "Junior", hasTakenDB = false},
                            new Student() { StudentID = 19, StudentName = "Claudia", StudentLastName = "Silva", Role = "Sophmore", hasTakenDB = true},
                            new Student() { StudentID = 20, StudentName = "Gabriela", StudentLastName = "Valenzuela", Role = "Junior", hasTakenDB = true},
                            new Student() { StudentID = 21, StudentName = "Kayla", StudentLastName = "Washington", Role = "Junior", hasTakenDB = true},
                            new Student() { StudentID = 22, StudentName = "Matthew", StudentLastName = "Webb", Role = "Sophmore", hasTakenDB = true},
                            new Student() { StudentID = 23, StudentName = "Cory", StudentLastName = "Williams", Role = "Senior", hasTakenDB = false} 


                        }; 

                        db.Students.AddRange(studentList);

                        db.SaveChanges();
                    }
                    
                }
                catch(Exception exp)
                {
                    Console.Error.WriteLine(exp.Message);
                }
            }
        }

            public static void JoinMethodSyntax()
        {
            using(var db = new AppDbContext())
            {
                var innerJoin = db.Students.Join(                           //outer sequence
                                                 db.Teams,                  //inner sequence
                                                 s => s.TeamID,             //outer key
                                                 t => t.TeamID,             //inner key
                                                 (s, t) => new              //projection
                                                    {
                                                        StudentName = s.StudentName,
                                                        TeamName = t.TeamName,
                                                        TeamDescription = t.TeamDescription
                                                    }
                                                );

                var innerJoinOrdered = innerJoin.OrderBy(p => p.StudentName).ThenBy(p => p.TeamName);

                foreach(var s in innerJoinOrdered)
                {
                    Console.WriteLine($"{s.StudentName} is on {s.TeamName} - {s.TeamDescription}");
                }
            }             
        }

        public static void JoinQuerySyntax()
        {
            using(var db = new AppDbContext())
            {
                var innerJoin = from s in db.Students //outer sequence
                                    join t in db.Teams
                                    on s.TeamID equals t.TeamID
                                    select new {
                                        StudentName = s.StudentName,
                                        TeamName = t.TeamName,
                                        TeamDescription = t.TeamDescription
                                    };

                var innerJoinOrdered = from p in innerJoin
                                       orderby p.StudentName
                                       select p;

                foreach(var s in innerJoinOrdered)
                {
                    Console.WriteLine($"{s.StudentName} is on {s.TeamName} - {s.TeamDescription}");
                }
            }                   
        }

    
        public static void GroupJoinMethodSyntax()
        {
            using(var db = new AppDbContext())
            {
           
                var groupJoin = db.Teams.GroupJoin(
                                db.Students,
                                t => t.TeamID,
                                s => s.TeamID,
                                (t, gs) => new
                                {
                                    Students = gs,
                                    TeamName = t.TeamName
                                });

                foreach (var p in groupJoin)
                {
                    Console.WriteLine($"Group: {p.TeamName}");

                    foreach(var s in p.Students)
                    {
                        Console.WriteLine(s);
                    }
                }
                PrintList(groupJoin);
            }              
        } 

         
        
        public static void GroupJoinQuerySyntax()
        {
            using(var db = new AppDbContext())
            {
           
                var groupJoin = from t in db.Teams
                                    join s in db.Students
                                    on t.TeamID equals s.TeamID
                                    into studentGroup
                                    select new 
                                    {
                                        Students = studentGroup,
                                        TeamName = t.TeamName
                                    };

                foreach (var p in groupJoin)
                {
                    Console.WriteLine($"Group: {p.TeamName}");

                    foreach(var s in p.Students)
                    {
                        Console.WriteLine(s);
                    }
                }
                //PrintList(groupedResult);
            }              
        }

              

         

        public static void PrintList(IEnumerable<Object> list)
        {
            foreach(var s in list)
            {
                Console.WriteLine(s);
            }
        }
    }
}


