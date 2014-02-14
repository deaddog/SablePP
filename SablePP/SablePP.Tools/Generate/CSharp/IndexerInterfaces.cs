namespace SablePP.Tools.Generate.CSharp
{
    public interface IIndexer
    {
        AccessModifiers Modifiers { get; set; }
        string Type { get; }
        ParametersElement Parameters { get; }
    }

    public interface IGetIndexer : IIndexer
    {
        PatchElement Get { get; }
        AccessModifiers GetModifiers { get; set; }
    }
    public interface ISetIndexer : IIndexer
    {
        PatchElement Set { get; }
        AccessModifiers SetModifiers { get; set; }
    }
    public interface IGetSetIndexer : IGetIndexer, ISetIndexer
    {
    }
}
