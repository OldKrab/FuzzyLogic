using System;
using System.Collections.Generic;
using System.Linq;

namespace FuzzyLogic.KnowledgeBase
{
    public class KnowledgeBaseSnapshotHistory
    {
        public void MakeSnapshot(string name)
        {
            var db = KnowledgeBaseManager.GetInstance();
            var snapshot = db.MakeSnapshot();
            snapshot.Name = name;
            _snapshots.Add(snapshot);
            Console.WriteLine($"Maked snapshot \"{name}\"");
        }

        public void RestoreSnapshot(string name)
        {
            var snapshot = _snapshots.FirstOrDefault(x => x.Name == name);
            if (snapshot != null)
            {
                var db = KnowledgeBaseManager.GetInstance();
                db.Restore(snapshot);
                Console.WriteLine($"Restored snapshot \"{name}\"");
            }
        }

        private List<ISnapshot> _snapshots = new List<ISnapshot>();
    }
}