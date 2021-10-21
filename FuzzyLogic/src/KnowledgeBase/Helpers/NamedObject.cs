using System;
using System.Collections.Generic;
using System.Text;

namespace FuzzyLogic.src.KnowledgeBase
{
    abstract class NamedObject
    {
        protected NamedObject(string name)
        {
            Id = _nextId++;
            Name = name;
        }

        public override string ToString()
        {
            return $"{{Id: {Id}, Name: {Name}}}";
        }

        public uint Id { get; }

        public string Name { get; }


        private static uint _nextId = 0;
    }
}
