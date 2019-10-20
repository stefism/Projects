using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repository
{
    public class Repository
    {
        private int id;
        private Dictionary<int, Person> persons;

        public int Count { get; private set; }

        public Repository()
        {
            persons = new Dictionary<int, Person>();
            id = 0;
            Count = 0;
        }

        public void Add(Person person)
        {
            persons.Add(id, person);
            id++;
            Count++;
        }

        public Person Get(int id)
        {
            Person person = persons.FirstOrDefault(x => x.Key == id).Value;

            return person;
        }

        public bool Update(int id, Person person)
        {
            if (!persons.ContainsKey(id))
            {
                return false;
            }

            persons[id] = person;

            return true;
        }

        public bool Delete(int id)
        {
            if (!persons.ContainsKey(id))
            {
                return false;
            }

            persons.Remove(id);
            Count--;

            return true;
        }
    }
}
