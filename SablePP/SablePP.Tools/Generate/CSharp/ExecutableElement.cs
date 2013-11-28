using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Tools.Generate.CSharp
{
    public abstract class ExecutableElement : CSharpElement
    {
        private PatchElement contents;

        protected ExecutableElement()
        {
            this.contents = new PatchElement();
        }

        protected void InsertContents()
        {
            insertElement(contents);
        }

        /// <summary>
        /// Curly bracket, newline and increases indentation
        /// </summary>
        public void EmitBlockStart()
        {
            contents.Emit("{", UseSpace.Never, UseSpace.Never);
            contents.EmitNewLine();
            contents.IncreaseIndentation();
        }
        /// <summary>
        /// Decreases indentation, and emits curly bracket and newline
        /// </summary>
        public void EmitBlockEnd()
        {
            contents.DecreaseIndentation();
            contents.Emit("}", UseSpace.Never, UseSpace.Never);
            contents.EmitNewLine();
        }

        public void EmitThis()
        {
            contents.Emit("this", UseSpace.NotPreferred, UseSpace.NotPreferred);
        }
        public void EmitThrow()
        {
            contents.Emit("throw", UseSpace.NotPreferred, UseSpace.Preferred);
        }
        public void EmitNew()
        {
            contents.Emit("new", UseSpace.NotPreferred, UseSpace.Preferred);
        }
        public void EmitIdentifier(string name)
        {
            contents.Emit(name, UseSpace.NotPreferred, UseSpace.Preferred);
        }
        public void EmitPeriod()
        {
            contents.Emit(".", UseSpace.Never, UseSpace.Never);
        }
        public void EmitComma()
        {
            contents.Emit(",", UseSpace.Never, UseSpace.Preferred);
        }
        public void EmitAssignment()
        {
            contents.Emit("=", UseSpace.Always, UseSpace.Always);
        }
        public void EmitReturn()
        {
            contents.Emit("return", UseSpace.NotPreferred, UseSpace.Preferred);
        }
        public void EmitYield()
        {
            contents.Emit("yield", UseSpace.NotPreferred, UseSpace.Preferred);
        }
        public void EmitDynamic(bool inparenthesis = false)
        {
            if (inparenthesis)
                contents.Emit("(dynamic)", UseSpace.Never, UseSpace.Never);
            else
                contents.Emit("dynamic", UseSpace.NotPreferred, UseSpace.Preferred);
        }
        public ParenthesisElement EmitTypeOf()
        {
            EmitIdentifier("typeof");
            return EmitParenthesis();
        }

        public ParenthesisElement EmitIf()
        {
            contents.Emit("if", UseSpace.NotPreferred, UseSpace.Always);
            return EmitParenthesis();
        }
        public void EmitElse()
        {
            contents.Emit("else", UseSpace.NotPreferred, UseSpace.Preferred);
        }
        public ParenthesisElement EmitWhile()
        {
            contents.Emit("while", UseSpace.NotPreferred, UseSpace.Always);
            return EmitParenthesis();
        }
        public ParenthesisElement EmitFor()
        {
            contents.Emit("for", UseSpace.NotPreferred, UseSpace.Always);
            return EmitParenthesis();
        }
        public ParenthesisElement EmitUsing()
        {
            contents.Emit("using", UseSpace.NotPreferred, UseSpace.Always);
            return EmitParenthesis();
        }

        public ParenthesisElement EmitParenthesis(ParenthesisElement.Types type = ParenthesisElement.Types.Round)
        {
            ParenthesisElement par = new ParenthesisElement(type);
            contents.InsertElement(par);
            return par;
        }

        public void EmitLogicNot()
        {
            contents.Emit("!", UseSpace.NotPreferred, UseSpace.Never);
        }
        public void EmitLogicAnd()
        {
            contents.Emit("&&", UseSpace.Always, UseSpace.Always);
        }
        public void EmitLogicOr()
        {
            contents.Emit("||", UseSpace.Always, UseSpace.Always);
        }

        public void EmitBinaryAnd()
        {
            contents.Emit("&", UseSpace.Always, UseSpace.Always);
        }
        public void EmitBinaryOr()
        {
            contents.Emit("|", UseSpace.Always, UseSpace.Always);
        }
        public void EmitBinaryXor()
        {
            contents.Emit("^", UseSpace.Always, UseSpace.Always);
        }

        public void EmitEqual()
        {
            contents.Emit("==", UseSpace.Always, UseSpace.Always);
        }
        public void EmitNotEqual()
        {
            contents.Emit("!=", UseSpace.Always, UseSpace.Always);
        }
        public void EmitGreaterThan()
        {
            contents.Emit(">", UseSpace.Always, UseSpace.Always);
        }
        public void EmitGreaterThanOrEqual()
        {
            contents.Emit(">=", UseSpace.Always, UseSpace.Always);
        }
        public void EmitLessThan()
        {
            contents.Emit("<", UseSpace.Always, UseSpace.Always);
        }
        public void EmitLessThanOrEqual()
        {
            contents.Emit("<=", UseSpace.Always, UseSpace.Always);
        }

        public void EmitPlus()
        {
            contents.Emit("+", UseSpace.Always, UseSpace.Always);
        }
        public void EmitMinus()
        {
            contents.Emit("-", UseSpace.Always, UseSpace.Always);
        }

        public void EmitPlusPlus()
        {
            contents.Emit("++", UseSpace.Never, UseSpace.NotPreferred);
        }
        public void EmitMinusMinus()
        {
            contents.Emit("--", UseSpace.Never, UseSpace.NotPreferred);
        }

        public void EmitAs()
        {
            contents.Emit("as", UseSpace.Always, UseSpace.Always);
        }
        public void EmitIs()
        {
            contents.Emit("is", UseSpace.Always, UseSpace.Always);
        }

        public void EmitTrue()
        {
            EmitIdentifier("true");
        }
        public void EmitFalse()
        {
            EmitIdentifier("false");
        }
        public void EmitNull()
        {
            EmitIdentifier("null");
        }

        public void EmitIntValue(int value)
        {
            contents.Emit(value.ToString(), UseSpace.NotPreferred, UseSpace.NotPreferred);
        }
        public void EmitFloatValue(float value)
        {
            contents.Emit(value.ToString("0,0") + "f", UseSpace.NotPreferred, UseSpace.NotPreferred);
        }
        public void EmitStringValue(string text)
        {
            contents.Emit("\"" + text.Replace("\"", "\"\"") + "\"", UseSpace.NotPreferred, UseSpace.NotPreferred);
        }

        public void EmitInt()
        {
            contents.Emit("int", UseSpace.NotPreferred, UseSpace.Preferred);
        }
        public void EmitFloat()
        {
            contents.Emit("float", UseSpace.NotPreferred, UseSpace.Preferred);
        }
        public void EmitString()
        {
            contents.Emit("string", UseSpace.NotPreferred, UseSpace.Preferred);
        }

        public void EmitNewLine()
        {
            contents.EmitNewLine();
            OnNewLineEmitted();
        }
        public void EmitSemicolon(bool newline)
        {
            contents.Emit(";", UseSpace.Never, UseSpace.Preferred);
            if (newline)
                this.EmitNewLine();
        }

        public void IncreaseIndentation()
        {
            contents.IncreaseIndentation();
        }
        public void DecreaseIndentation()
        {
            contents.DecreaseIndentation();
        }

        protected virtual void OnNewLineEmitted()
        {
        }
    }
}
