﻿using System;
using System.IO;
using System.Text;

using SablePP.Compiler.Analysis;
using SablePP.Tools.Nodes;
using SablePP.Tools.Error;
using System.Collections.Generic;
using System.Drawing;

namespace SablePP.Compiler
{
    public class SableGrammarEmitter : DepthFirstAdapter
    {
        private Stream stream;
        private Encoding encoding;
        private Point currentPoint;
        private Dictionary<Point, Position> positions;

        public Position TranslatePosition(int line, int character)
        {
            Point p = new Point(character, line);
            if (positions.ContainsKey(p))
                return positions[p];
            else
                return new Position();
        }

        public SableGrammarEmitter(Stream stream)
        {
            this.stream = stream;
            this.encoding = new System.Text.UTF8Encoding(false);
            this.currentPoint = new System.Drawing.Point(1, 1);
            this.positions = new Dictionary<Point, Position>();
        }

        public override void CaseAGrammar(Nodes.AGrammar node)
        {
            if (node.HasPackage)
                Visit((dynamic)node.Package);
            if (node.HasHelpers)
                Visit((dynamic)node.Helpers);
            if (node.HasStates)
                Visit((dynamic)node.States);
            if (node.HasTokens)
                Visit((dynamic)node.Tokens);
            if (node.HasIgnoredtokens)
                Visit((dynamic)node.Ignoredtokens);
            if (node.HasProductions)
                Visit((dynamic)node.Productions);
            if (node.HasAstproductions)
                Visit((dynamic)node.Astproductions);
        }

        private void writeList<T>(Production.NodeList<T> list, string separator) where T : Node
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (i > 0)
                    write(separator);
                Visit(list[i]);
            }
        }
        private void write(string text)
        {
            byte[] buffer = encoding.GetBytes(text);
            stream.Write(buffer, 0, buffer.Length);

            currentPoint.X += text.Length;
        }
        private void writeNewline()
        {
            write("\r\n");

            currentPoint.X = 1;
            currentPoint.Y++;
        }

        public override void CaseTPackagetoken(Nodes.TPackagetoken node)
        {
            DefaultCase(new Nodes.TPackagetoken("Package", node.Line, node.Position));
        }

        public override void InPRegex(Nodes.PRegex node)
        {
            var p = node.GetParent() as Nodes.AOrRegex;
            if (p != null)
            {
                if (p.Regexs[0] != node)
                    write(" | ");
            }
            base.InPRegex(node);
        }

        public override void CaseAFullTranslation(Nodes.AFullTranslation node)
        {
            write("{ ");
            base.CaseAFullTranslation(node);
            write("}");
        }
        public override void InPProdtranslation(Nodes.PProdtranslation node)
        {
            write("{");
            base.InPProdtranslation(node);
        }
        public override void OutPProdtranslation(Nodes.PProdtranslation node)
        {
            base.OutPProdtranslation(node);
            write("}");
        }

        public override void CaseAIdTranslation(Nodes.AIdTranslation node)
        {
            var p = node.Identifier.AsPElement.Elementid.Identifier.AsPProduction;

            base.CaseAIdTranslation(node);
            if (p != null && p.HasProdtranslation)
                write("." + p.Prodtranslation.Identifier.Text);
        }

        public override void DefaultCase(Node node)
        {
            if (node is Token)
            {
                Token token = node as Token;
                if (token.Position > 0 && token.Line > 0)
                    positions[currentPoint] = new Position(token.Line, token.Position);
                write(token.Text + " ");
            }
            else
                base.DefaultCase(node);
        }

        // Newline rules

        public override void CaseAPackage(Nodes.APackage node)
        {
            base.CaseAPackage(node);
            writeNewline();
        }

        public override void CaseTHelperstoken(Nodes.THelperstoken node)
        {
            base.CaseTHelperstoken(node);
            writeNewline();
        }
        public override void CaseAHelper(Nodes.AHelper node)
        {
            base.CaseAHelper(node);
            writeNewline();
        }

        public override void CaseAStates(Nodes.AStates node)
        {
            Visit(node.Statestoken);
            writeList(node.States, ", ");
            Visit(node.Semicolon);
            writeNewline();
        }

        public override void CaseTTokenstoken(Nodes.TTokenstoken node)
        {
            base.CaseTTokenstoken(node);
            writeNewline();
        }
        public override void CaseAToken(Nodes.AToken node)
        {
            if (node.Statelist.Count > 0)
            {
                write("{ ");
                Visit(node.Statelist);
                write("} ");
            }
            Visit(node.Identifier);
            Visit(node.Equal);
            Visit((dynamic)node.Regex);
            Visit(node.Semicolon);
            writeNewline();
        }

        public override void CaseAIgnoredtokens(Nodes.AIgnoredtokens node)
        {
            Visit(node.Ignoredtoken);
            Visit(node.Tokenstoken);
            writeList(node.Tokens, ", ");
            Visit(node.Semicolon);
            writeNewline();
        }

        public override void CaseTProductionstoken(Nodes.TProductionstoken node)
        {
            base.CaseTProductionstoken(node);
            writeNewline();
        }
        public override void CaseTAsttoken(Nodes.TAsttoken node)
        {
            base.CaseTAsttoken(node);
            writeNewline();
        }
        public override void CaseAProduction(Nodes.AProduction node)
        {
            base.CaseAProduction(node);
            writeNewline();
        }

        public override void CaseANewTranslation(Nodes.ANewTranslation node)
        {
            Visit(node.New);
            Visit(node.Production);
            Visit(node.Lpar);
            writeList(node.Arguments, ", ");
            Visit(node.Rpar);
        }
        public override void CaseANewalternativeTranslation(Nodes.ANewalternativeTranslation node)
        {
            Visit(node.New);
            Visit(node.Production);
            Visit(node.Dot);
            Visit(node.Alternative);
            Visit(node.Lpar);
            writeList(node.Arguments, ", ");
            Visit(node.Rpar);
        }
        public override void CaseAListTranslation(Nodes.AListTranslation node)
        {
            Visit(node.Lpar);
            writeList(node.Elements, ", ");
            Visit(node.Rpar);
        }

        public override void CaseAHighlightrule(Nodes.AHighlightrule node)
        {
            Visit(node.Name);
            Visit(node.Lpar);
            writeList(node.Tokens, ", ");
            Visit(node.Rpar);
            Visit(node.Styles);
            Visit(node.Semicolon);
        }
    }
}
