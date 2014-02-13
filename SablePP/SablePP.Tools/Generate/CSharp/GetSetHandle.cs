using System;

namespace SablePP.Tools.Generate.CSharp
{
    internal class GetSetHandle : ComplexElement
    {
        private PatchElement break1, break2, break3;
        private bool hasNewline;

        private PatchElement content;
        private AccessModifierElement access;

        public PatchElement Content
        {
            get { return content; }
        }
        public AccessModifiers Access
        {
            get { return access.Modifiers; }
            set { access.Modifiers = value; }
        }

        public GetSetHandle(string getset)
        {
            break1 = new PatchElement();
            break2 = new PatchElement();
            break3 = new PatchElement();
            hasNewline = false;

            content = new PatchElement();
            content.NewLineEmitted += this.onNewLineEmitted;

            access = new AccessModifierElement(AccessModifiers.None);
            insertElement(access);
            emit(getset, UseSpace.Never, UseSpace.Preferred);
            insertElement(break1);
            emit("{", UseSpace.NotPreferred, UseSpace.Preferred);
            insertElement(break2);
            insertElement(content);
            insertElement(break3);
            emit("}", UseSpace.Preferred, UseSpace.NotPreferred);
            emitNewLine();
        }

        private void onNewLineEmitted()
        {
            if (!hasNewline)
            {
                hasNewline = true;
                break1.EmitNewLine();
                break2.EmitNewLine();
                break2.IncreaseIndentation();
                break3.EmitNewLine();
                break3.DecreaseIndentation();
            }
        }
    }
}
