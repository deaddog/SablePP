using System;
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

        /// <summary>
        /// Holds information about a single method parameter
        /// </summary>
        public class Parameter
        {
            private string parameterType;
            private string name;
            private string type;
            private string defaultValue;

            internal Parameter(string parameterType, string name, string type, string defaultValue)
            {
                this.parameterType = parameterType;
                this.name = name;
                this.type = type;
                this.defaultValue = defaultValue;
            }

            /// <summary>
            /// Gets or sets the type of the parameter (<c>ref</c>, <c>out</c> or <c>null</c> for default).
            /// </summary>
            public string ParameterType
            {
                get { return parameterType; }
                set
                {
                    if (value != "ref" && value != "out" && value != null)
                        throw new ArgumentException("ParameterType must be either ref, out or null.", "value");

                    parameterType = value;
                }
            }
            /// <summary>
            /// Gets or sets the name of the parameter.
            /// </summary>
            /// <value>
            public string Name
            {
                get { return name; }
                set
                {
                    if (value == null)
                        throw new ArgumentNullException("value");

                    name = value;
                }
            }
            /// <summary>
            /// Gets or sets the type of the parameter.
            /// </summary>
            public string Type
            {
                get { return type; }
                set
                {
                    if (value == null)
                        throw new ArgumentNullException("value"); 
                    
                    type = value;
                }
            }
            /// <summary>
            /// Gets the default value of the parameter - <c>null</c> indicates that there is no default value.
            /// </summary>
            public string DefaultValue
            {
                get { return defaultValue; }
                set { defaultValue = value; }
            }
        }
    }
}
