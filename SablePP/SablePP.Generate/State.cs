using System;

namespace SablePP.Generate
{
    public class State
    {
        private readonly string name;

        public State(string name)
        {
            if (name == null)
                throw new ArgumentNullException("name");

            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }
    }
}
