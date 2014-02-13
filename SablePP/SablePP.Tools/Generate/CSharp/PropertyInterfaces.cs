namespace SablePP.Tools.Generate.CSharp
{
    public interface IProperty
    {
        AccessModifiers Modifiers { get; set; }
        string Name { get; }
        string Type { get; }
    }

    public interface IGetProperty : IProperty
    {
        PatchElement Get { get; }
        AccessModifiers GetModifiers { get; set; }
    }
    public interface ISetProperty : IProperty
    {
        PatchElement Set { get; }
        AccessModifiers SetModifiers { get; set; }
    }
}
