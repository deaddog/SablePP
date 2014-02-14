using System.Collections.Generic;

namespace SablePP.Tools.Generate.CSharp
{
    public class ParametersElement : ComplexElement
    {
        private List<Parameter> parameters;

        public ParametersElement()
        {
            this.parameters = new List<Parameter>();
        }

        public Parameter Add(string name, string type)
        {
            Parameter par = new Parameter(name, type);
            parameters.Add(par);
            if (parameters.Count > 1)
                emit(",", UseSpace.Never, UseSpace.Always);
            emit(type, UseSpace.NotPreferred, UseSpace.Always);
            emit(name, UseSpace.NotPreferred, UseSpace.NotPreferred);
            return par;
        }

        public Parameter this[int index]
        {
            get { return parameters[index]; }
        }

        public class Parameter
        {
            private string name;
            private string type;

            public Parameter(string name, string type)
            {
                this.name = name;
                this.type = type;
            }

            public string Name
            {
                get { return name; }
            }
            public string Type
            {
                get { return type; }
            }
        }
    }
}
