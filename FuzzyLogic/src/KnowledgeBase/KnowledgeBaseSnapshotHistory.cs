using System;
using System.Collections.Generic;
using System.Linq;

namespace FuzzyLogic.KnowledgeBase
{
    public class KnowledgeBaseSnapshotHistory
    {
        public void MakeSnapshot(string name)
        {
            var snapshot = FuzzySystem.GetInstance().KnowledgeBase.MakeSnapshot();
            snapshot.Name = name;
            _snapshots.Add(snapshot);
            Console.WriteLine($"Make snapshot \"{name}\"");
        }

        public void RestoreSnapshot(string name)
        {
            var snapshot = _snapshots.FirstOrDefault(x => x.Name == name);
            if (snapshot != null)
            {
                FuzzySystem.GetInstance().KnowledgeBase.Restore(snapshot);
                Console.WriteLine($"Restore snapshot \"{name}\"");
            }
        }

        private readonly List<ISnapshot> _snapshots = new List<ISnapshot>();
    }
}