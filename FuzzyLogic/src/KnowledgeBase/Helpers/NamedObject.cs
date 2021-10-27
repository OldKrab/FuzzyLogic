namespace FuzzyLogic.KnowledgeBase.Helpers
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
            return Name;
        }

        public uint Id { get; }

        public string Name { get; }


        private static uint _nextId = 1;
    }
}
