using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;

namespace SablePP.Compiler.Execution
{
    public class EditorSettings
    {
        private static EditorSettings defaultSettings;
        public static EditorSettings Default
        {
            get
            {
                if (defaultSettings == null)
                    defaultSettings = new EditorSettings(DefaultSettingsPath);

                return defaultSettings;
            }
        }

        private static string DefaultSettingsPath
        {
            get { return PathInformation.ExecutingDirectory + "\\settings.xml"; }
        }

        private string settingsPath;
        private XDocument document;

        private OutputPathCollection outputPaths;
        public OutputPathCollection OutputPaths
        {
            get { return outputPaths; }
        }

        public EditorSettings(string filepath)
        {
            this.settingsPath = filepath;

            FileInfo file = new FileInfo(filepath);
            if (file.Exists)
                document = XDocument.Load(filepath);
            else
                document = new XDocument(new XElement("files"));

            this.outputPaths = new OutputPathCollection(this);
        }

        public class OutputPathCollection
        {
            private EditorSettings settings;
            private XElement files;

            public OutputPathCollection(EditorSettings settings)
            {
                this.settings = settings;
                this.files = settings.document.Element("files");
            }

            public string this[string file]
            {
                get
                {
                    var elements = from e in files.Elements("file") where e.Element("source").Value == file select e;
                    if (elements.Any())
                        return elements.First().Element("destination").Value;
                    else
                        return null;
                }
                set
                {
                    var elements = from e in files.Elements("file") where e.Element("source").Value == file select e;
                    if (elements.Any())
                        elements.First().Element("destination").Value = value;
                    else
                        files.Add(new XElement("file", new XElement("source", file), new XElement("destination", value)));

                    files.Document.Save(settings.settingsPath);
                }
            }
        }
    }
}
