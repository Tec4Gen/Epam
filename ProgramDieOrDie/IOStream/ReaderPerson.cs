using ProgramDieOrDie.Entityes;
using System;
using System.Collections.Generic;
using System.IO;
namespace ProgramDieOrDie.IOStream
{
    public static class ReaderPerson
    {
        public static List<Person> Read(string path) 
        {

                using (StreamReader file = new StreamReader(path))
                {
                    List<Person> listPerson = new List<Person>();
                    string line;

                    string[] data;

                    while (!file.EndOfStream)
                    {
                        line = file.ReadLine();
                        data = line.Split(' ');

                        listPerson.Add(new Person
                        {
                            FirstName = data[0],
                            LastName = data[1],
                        });
                    }

                    return listPerson;
                }
            
 
                Console.WriteLine("File not found or path incorrect format");
                return null;
  
        }
    }
}
