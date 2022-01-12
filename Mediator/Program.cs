using System;
using System.Collections.Generic;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();
            Teacher ogulcan = new Teacher (mediator);

            ogulcan.Name = "ogulcan";
            mediator.Teacher = ogulcan;

            Student zeliha = new Student(mediator);
            zeliha.Name = "Zeliha";



            Student cengiz = new Student(mediator);
            cengiz.Name = "cengiz";


            mediator.Students = new List<Student> { cengiz,zeliha};

            ogulcan.SendNewImageUrl("slide1.jpg");

            ogulcan.ReceiveQuestion("Is it true",zeliha);

            Console.ReadLine(); 


        }
    }


    abstract class CourseMember
    {
        protected Mediator Mediator;

        public CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
    }

    class Teacher : CourseMember
    {
        public string Name { get; set; }
        public Teacher(Mediator mediator) : base(mediator)
        {
        }

        internal void ReceiveQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher received a question from {0},{1}", student.Name, question);
        }

        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("Teacher changed slide: {0}", url);
            Mediator.UpdateImage(url);
        }

        public void AnswerQuestion(string answer, Student student)
        {
            Console.WriteLine("Teacher answered question {0}, {1}", student.Name, answer);
        }

    }

    class Student : CourseMember
    {
        public string Name { get; set; }

        public Student(Mediator mediator) : base(mediator)
        {
        }


        internal void ReceiveImage(string url)
        {
            Console.WriteLine("Student received img: {0}", url);
        }

        internal void ReceiveAnswer(string answer)
        {
            Console.WriteLine("Student received answer: {0}", answer);
        }
    }
    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.ReceiveImage(url);
            }
        }

        public void SendQuestion(string question, Student student)
        {
            Teacher.ReceiveQuestion(question, student);
        }

        public void SendAnswer(string answer, Student student)
        {
            student.ReceiveAnswer(answer);
        }

    }

}



