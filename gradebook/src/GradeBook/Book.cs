using System.Collections.Generic;
using System;
using System.IO;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender,EventArgs args,double grade); 
    public class NameOfObject 
    { 
        public NameOfObject(string name)
        {
            this.Name = name;
        }

        public string Name {
            set;
            get;
        }
    }
    public abstract class Book:NameOfObject,IBook
    {
        public Book(string name):base(name)
        {

        }
        public abstract event GradeAddedDelegate gradeAdded;
        public abstract void AddGrade(double grade);
        public abstract Statistics showstatistics();

    }
    public interface IBook
    {
        void AddGrade(double grade);
        Statistics showstatistics();
        string Name {get;}
        event GradeAddedDelegate gradeAdded;
    }
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate gradeAdded;

        public override void AddGrade(double grade)
        {
           using(var file = File.AppendText($"{Name}.txt"))
           {
                file.WriteLine(grade);
                if(gradeAdded != null)
                {
                    gradeAdded(this,new EventArgs(),grade);
                }

           }
        }

         public override Statistics showstatistics(){
            var result = new Statistics();
            using(var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while(line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }

            }
             
             return result;
        }
    }
    public class  InMemeoryBook: Book,IBook
    {
        public InMemeoryBook(string name):base(name)
        {
            grades = new List<double>();
            this.Name = name;
        }
        public void AddLetterGrade(char c)
        {
            switch (c)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                default:
                    AddGrade(0);
                    break;
            }

        }
        public override void AddGrade(double grade) 
        {
            if(grade <=100 && grade >=0)
            {
                grades.Add(grade);
                if(gradeAdded != null)
                {
                    gradeAdded(this,new EventArgs(),grade);
                }
            }else{
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
            
        }
        public override event GradeAddedDelegate gradeAdded;
        public override Statistics showstatistics(){
            var result = new Statistics();
            foreach (var grade in grades)
             {
                 result.Add(grade);
             }
             return result;
        }
        private List<double> grades;
    }
}