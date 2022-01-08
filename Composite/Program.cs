using System;
using System.Collections;
using System.Collections.Generic;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee ogulcan = new Employee
            {
                Name = "Ogulcan Turan"
            };
            Employee zeliha = new Employee
            {
                Name = "Zeliha Turan"
            };
            ogulcan.AddSubordinate(zeliha);

            Contractor ali = new Contractor { Name = "Ali" };
            zeliha.AddSubordinate(ali);
            Employee cengiz = new Employee
            {
                Name = "Cengiz Turan"
            };

            ogulcan.AddSubordinate(cengiz);

            ogulcan.AddSubordinate(zeliha);
            Employee mehmet = new Employee
            {
                Name = "mehmet"
            };

            zeliha.AddSubordinate(mehmet);

            foreach (Employee manager in ogulcan)
            {
                Console.WriteLine("    {0}",manager.Name);

                foreach (IPerson employee in manager)
                {
                    Console.WriteLine("          {0}",employee.Name);
                }
            }
            Console.ReadLine();
        }

    }

    interface IPerson
    {
        string Name { get; set; }
    }

    class Contractor : IPerson
    {
        public string Name { get ; set; }
    }
    class Employee : IPerson,IEnumerable<IPerson>
    {
        List<IPerson> _subordinates = new List<IPerson>();

        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }

        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);

        }

        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }
        public string Name { get ; set; }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
