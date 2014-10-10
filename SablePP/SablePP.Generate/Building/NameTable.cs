using SablePP.Tools;
using System.Collections.Generic;

namespace SablePP.Generate.Building
{
    internal class NameTable<T>
    {
        private Dictionary<string, T> objects;
        private Dictionary<T, string> names;
        private SafeNameDictionary<T> safe;

        public NameTable()
        {
            this.objects = new Dictionary<string, T>();
            this.names = new Dictionary<T, string>();
            this.safe = new SafeNameDictionary<T>(this.objects);
        }

        public string Add(string name, T obj)
        {
            name = safe.Add(name, obj);
            names.Add(obj, name);
            return name;
        }

        public string this[T obj]
        {
            get { return names[obj]; }
            set
            {
                this.names[obj] = value;
                if (!objects.ContainsKey(value))
                    objects.Add(value, obj);
            }
        }
    }
}
