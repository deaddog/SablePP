using System;
using System.Collections.Generic;

namespace SablePP.Tools.Generate.CSharp
{
    public class ParametersElement : CodeElement
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

        internal override UseSpace Append
        {
            get { return UseSpace.Never; }
        }

        internal override UseSpace Prepend
        {
            get { return UseSpace.Never; }
        }

        internal override void Generate(CodeStreamWriter streamwriter)
        {
            bool first = true;

            foreach (var par in parameters)
            {
                if (!first)
                    streamwriter.WriteString(", ");
                first = false;

                if (par.ParameterType != null)
                    streamwriter.WriteString(par.ParameterType + " ");

                streamwriter.WriteString(par.Type + " " + par.Name);

                if (par.DefaultValue != null)
                    streamwriter.WriteString(" = " + par.DefaultValue);
            }
        }

        public static ParametersElement Parse(string signature)
        {
            ParametersElement element = new ParametersElement();

            string[] parameters = signature.Split(',');
            for (int i = 0; i < parameters.Length; i++)
            {
                parameters[i] = parameters[i].Trim();
                if (parameters[i].Length > 0)
                    element.parameters.Add(Parameter.Parse(parameters[i]));
            }

            return element;
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

            private Parameter()
            {
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

            internal static Parameter Parse(string signature)
            {
                Parameter par = new Parameter();

                int equalIndex = signature.IndexOf('=');

                string pre = equalIndex <= 0 ? signature : signature.Substring(0, equalIndex).TrimEnd();
                par.defaultValue = equalIndex <= 0 ? null : signature.Substring(equalIndex + 1).TrimStart();

                if (pre.StartsWith("ref") || pre.StartsWith("out"))
                {
                    par.parameterType = pre.Substring(0, 3);
                    pre = pre.Substring(3).TrimStart();
                }
                else
                    par.parameterType = null;

                par.name = pre.Contains(" ") ? pre.Substring(pre.LastIndexOf(' ') + 1) : pre;
                par.type = pre.Substring(0, pre.Length - par.name.Length).TrimEnd();

                return par;
            }
        }
    }
}
