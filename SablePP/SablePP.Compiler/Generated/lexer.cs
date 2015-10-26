using System;
using SablePP.Compiler.Nodes;

namespace SablePP.Compiler.Lexing
{
    public class Lexer : SablePP.Tools.Lexing.Lexer
    {
        private const int STATE1 = 0;
        private const int STATE2 = 1;
        private const int STATE3 = 2;
        private const int STATE4 = 3;
        
        public Lexer(System.IO.TextReader input)
            : base(input, STATE1, gotoTable, acceptTable)
        {
        }
        
        protected override SablePP.Tools.Nodes.Token getToken(int tokenIndex, string text, int line, int position)
        {
            switch (tokenIndex)
            {
                case 0: return new TNamespace(text, line, position);
                case 1: return new TNamespacetoken(text, line, position);
                case 2: return new TStatestoken(text, line, position);
                case 3: return new THelperstoken(text, line, position);
                case 4: return new TTokenstoken(text, line, position);
                case 5: return new TIgnoredtoken(text, line, position);
                case 6: return new TProductionstoken(text, line, position);
                case 7: return new TAsttoken(text, line, position);
                case 8: return new THighlighttoken(text, line, position);
                case 9: return new TNew(text, line, position);
                case 10: return new TNull(text, line, position);
                case 11: return new TTokenSpecifier(text, line, position);
                case 12: return new TProductionSpecifier(text, line, position);
                case 13: return new TDot(text, line, position);
                case 14: return new TDDot(text, line, position);
                case 15: return new TSemicolon(text, line, position);
                case 16: return new TEqual(text, line, position);
                case 17: return new TLBkt(text, line, position);
                case 18: return new TRBkt(text, line, position);
                case 19: return new TLPar(text, line, position);
                case 20: return new TRPar(text, line, position);
                case 21: return new TLBrace(text, line, position);
                case 22: return new TRBrace(text, line, position);
                case 23: return new TPlus(text, line, position);
                case 24: return new TMinus(text, line, position);
                case 25: return new TQMark(text, line, position);
                case 26: return new TStar(text, line, position);
                case 27: return new TPipe(text, line, position);
                case 28: return new TComma(text, line, position);
                case 29: return new TSlash(text, line, position);
                case 30: return new TArrow(text, line, position);
                case 31: return new TColon(text, line, position);
                case 32: return new TIdentifier(text, line, position);
                case 33: return new TCharacter(text, line, position);
                case 34: return new TDecChar(text, line, position);
                case 35: return new THexChar(text, line, position);
                case 36: return new TString(text, line, position);
                case 37: return new TBlank(text, line, position);
                case 38: return new TComment(text, line, position);
                case 39: return new TItalic(text, line, position);
                case 40: return new TBold(text, line, position);
                case 41: return new TText(text, line, position);
                case 42: return new TBackground(text, line, position);
                case 43: return new TRgb(text, line, position);
                case 44: return new THsv(text, line, position);
                case 45: return new THexColor(text, line, position);
                default:
                    throw new ArgumentException("Unknown token index.", "tokenIndex");
            }
        }
        protected override int getNextState(int tokenIndex, int currentState)
        {
            switch (tokenIndex)
            {
                case 1:
                    switch (currentState)
                    {
                        case STATE1: return STATE2;
                        case STATE3: return STATE2;
                        default: return -1;
                    }
                case 2:
                    switch (currentState)
                    {
                        case STATE3: return STATE1;
                        default: return -1;
                    }
                case 3:
                    switch (currentState)
                    {
                        case STATE3: return STATE1;
                        default: return -1;
                    }
                case 4:
                    switch (currentState)
                    {
                        case STATE3: return STATE1;
                        default: return -1;
                    }
                case 5:
                    switch (currentState)
                    {
                        case STATE3: return STATE1;
                        default: return -1;
                    }
                case 6:
                    switch (currentState)
                    {
                        case STATE3: return STATE1;
                        default: return -1;
                    }
                case 7:
                    switch (currentState)
                    {
                        case STATE3: return STATE1;
                        default: return -1;
                    }
                case 8:
                    switch (currentState)
                    {
                        case STATE1: return STATE3;
                        default: return -1;
                    }
                case 15:
                    switch (currentState)
                    {
                        case STATE2: return STATE1;
                        case STATE4: return STATE3;
                        default: return -1;
                    }
                case 22:
                    switch (currentState)
                    {
                        case STATE3: return STATE4;
                        default: return -1;
                    }
                default: return -1;
            }
        }
        
        
        #region Goto Table
        
        
        private static int[][][][] gotoTable = {
            new int[][][] {
                new int[][] {
                    new int[] {9, 9, 1},
                    new int[] {10, 10, 2},
                    new int[] {13, 13, 3},
                    new int[] {32, 32, 4},
                    new int[] {39, 39, 5},
                    new int[] {40, 40, 6},
                    new int[] {41, 41, 7},
                    new int[] {42, 42, 8},
                    new int[] {43, 43, 9},
                    new int[] {44, 44, 10},
                    new int[] {45, 45, 11},
                    new int[] {46, 46, 12},
                    new int[] {47, 47, 13},
                    new int[] {48, 48, 14},
                    new int[] {49, 57, 15},
                    new int[] {58, 58, 16},
                    new int[] {59, 59, 17},
                    new int[] {61, 61, 18},
                    new int[] {63, 63, 19},
                    new int[] {65, 65, 20},
                    new int[] {72, 72, 21},
                    new int[] {73, 73, 22},
                    new int[] {78, 78, 23},
                    new int[] {80, 80, 24},
                    new int[] {83, 83, 25},
                    new int[] {84, 84, 26},
                    new int[] {91, 91, 27},
                    new int[] {93, 93, 28},
                    new int[] {97, 122, 29},
                    new int[] {123, 123, 30},
                    new int[] {124, 124, 31},
                    new int[] {125, 125, 32},
                },
                new int[][] {
                    new int[] {9, 32, -2},
                },
                new int[][] {
                    new int[] {9, 32, -2},
                },
                new int[][] {
                    new int[] {9, 9, 1},
                    new int[] {10, 10, 33},
                    new int[] {13, 32, -2},
                },
                new int[][] {
                    new int[] {9, 32, -2},
                },
                new int[][] {
                    new int[] {0, 9, 34},
                    new int[] {11, 12, 34},
                    new int[] {14, 38, 34},
                    new int[] {39, 39, 35},
                    new int[] {40, 65535, 34},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {62, 62, 36},
                },
                new int[][] {
                    new int[] {46, 46, 37},
                },
                new int[][] {
                    new int[] {42, 42, 38},
                    new int[] {47, 47, 39},
                },
                new int[][] {
                    new int[] {48, 57, 15},
                    new int[] {88, 88, 40},
                    new int[] {120, 120, 41},
                },
                new int[][] {
                    new int[] {48, 57, 15},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {98, 98, 42},
                },
                new int[][] {
                    new int[] {101, 101, 43},
                },
                new int[][] {
                    new int[] {103, 103, 44},
                },
                new int[][] {
                    new int[] {97, 97, 45},
                    new int[] {101, 101, 46},
                    new int[] {117, 117, 47},
                },
                new int[][] {
                    new int[] {114, 114, 48},
                },
                new int[][] {
                    new int[] {116, 116, 49},
                },
                new int[][] {
                    new int[] {111, 111, 50},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {48, 57, 51},
                    new int[] {95, 95, 52},
                    new int[] {97, 122, 53},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {9, 32, -2},
                },
                new int[][] {
                    new int[] {0, 9, 54},
                    new int[] {11, 12, 54},
                    new int[] {14, 38, 54},
                    new int[] {39, 39, 55},
                    new int[] {40, 65535, 54},
                },
                new int[][] {
                    new int[] {39, 39, 56},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {0, 41, 57},
                    new int[] {42, 42, 58},
                    new int[] {43, 65535, 57},
                },
                new int[][] {
                    new int[] {0, 9, 59},
                    new int[] {11, 12, 59},
                    new int[] {14, 65535, 59},
                },
                new int[][] {
                    new int[] {48, 57, 60},
                    new int[] {65, 70, 60},
                    new int[] {97, 102, 60},
                },
                new int[][] {
                    new int[] {48, 102, -42},
                },
                new int[][] {
                    new int[] {115, 115, 61},
                },
                new int[][] {
                    new int[] {108, 108, 62},
                },
                new int[][] {
                    new int[] {110, 110, 63},
                },
                new int[][] {
                    new int[] {109, 109, 64},
                },
                new int[][] {
                    new int[] {119, 119, 65},
                },
                new int[][] {
                    new int[] {108, 108, 66},
                },
                new int[][] {
                    new int[] {111, 111, 67},
                },
                new int[][] {
                    new int[] {97, 97, 68},
                },
                new int[][] {
                    new int[] {107, 107, 69},
                },
                new int[][] {
                    new int[] {48, 122, -31},
                },
                new int[][] {
                    new int[] {97, 122, 70},
                },
                new int[][] {
                    new int[] {48, 122, -31},
                },
                new int[][] {
                    new int[] {0, 38, -36},
                    new int[] {39, 39, 71},
                    new int[] {40, 65535, 54},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {0, 65535, -40},
                },
                new int[][] {
                    new int[] {0, 41, 72},
                    new int[] {42, 42, 58},
                    new int[] {43, 46, 72},
                    new int[] {47, 47, 73},
                    new int[] {48, 65535, 72},
                },
                new int[][] {
                    new int[] {0, 65535, -41},
                },
                new int[][] {
                    new int[] {48, 102, -42},
                },
                new int[][] {
                    new int[] {116, 116, 74},
                },
                new int[][] {
                    new int[] {112, 112, 75},
                },
                new int[][] {
                    new int[] {111, 111, 76},
                },
                new int[][] {
                    new int[] {101, 101, 77},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {108, 108, 78},
                },
                new int[][] {
                    new int[] {100, 100, 79},
                },
                new int[][] {
                    new int[] {116, 116, 80},
                },
                new int[][] {
                    new int[] {101, 101, 81},
                },
                new int[][] {
                    new int[] {48, 57, 82},
                    new int[] {95, 95, 52},
                    new int[] {97, 122, 83},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {0, 41, 84},
                    new int[] {42, 42, 85},
                    new int[] {43, 65535, 84},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {114, 114, 86},
                },
                new int[][] {
                    new int[] {101, 101, 87},
                },
                new int[][] {
                    new int[] {114, 114, 88},
                },
                new int[][] {
                    new int[] {115, 115, 89},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {117, 117, 90},
                },
                new int[][] {
                    new int[] {101, 101, 91},
                },
                new int[][] {
                    new int[] {110, 110, 92},
                },
                new int[][] {
                    new int[] {48, 122, -72},
                },
                new int[][] {
                    new int[] {48, 122, -72},
                },
                new int[][] {
                    new int[] {0, 65535, -74},
                },
                new int[][] {
                    new int[] {0, 41, 72},
                    new int[] {42, 42, 85},
                    new int[] {43, 65535, -60},
                },
                new int[][] {
                    new int[] {97, 97, 93},
                },
                new int[][] {
                    new int[] {114, 114, 94},
                },
                new int[][] {
                    new int[] {101, 101, 95},
                },
                new int[][] {
                    new int[] {112, 112, 96},
                },
                new int[][] {
                    new int[] {99, 99, 97},
                },
                new int[][] {
                    new int[] {115, 115, 98},
                },
                new int[][] {
                    new int[] {32, 32, 99},
                    new int[] {115, 115, 100},
                },
                new int[][] {
                    new int[] {99, 99, 101},
                },
                new int[][] {
                    new int[] {115, 115, 102},
                },
                new int[][] {
                    new int[] {100, 100, 103},
                },
                new int[][] {
                    new int[] {97, 97, 104},
                },
                new int[][] {
                    new int[] {116, 116, 105},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {83, 83, 106},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {116, 116, 107},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {99, 99, 108},
                },
                new int[][] {
                    new int[] {105, 105, 109},
                },
                new int[][] {
                    new int[] {121, 121, 110},
                },
                new int[][] {
                    new int[] {9, 9, 111},
                    new int[] {32, 32, 112},
                },
                new int[][] {
                    new int[] {101, 101, 113},
                },
                new int[][] {
                    new int[] {111, 111, 114},
                },
                new int[][] {
                    new int[] {110, 110, 115},
                },
                new int[][] {
                    new int[] {9, 32, -109},
                    new int[] {83, 83, 116},
                },
                new int[][] {
                    new int[] {9, 83, -113},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {110, 110, 117},
                },
                new int[][] {
                    new int[] {116, 116, 118},
                },
                new int[][] {
                    new int[] {121, 121, 119},
                },
                new int[][] {
                    new int[] {115, 115, 120},
                },
                new int[][] {
                    new int[] {97, 97, 121},
                },
                new int[][] {
                    new int[] {110, 110, 122},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {120, 120, 123},
                },
                new int[][] {
                    new int[] {116, 116, 124},
                },
                new int[][] {
                    new int[] {32, 32, 125},
                },
                new int[][] {
                    new int[] {97, 97, 126},
                },
                new int[][] {
                    new int[] {72, 72, 127},
                },
                new int[][] {
                    new int[] {120, 120, 128},
                },
                new int[][] {
                    new int[] {105, 105, 129},
                },
                new int[][] {
                    new int[] {9, 9, 130},
                    new int[] {32, 32, 131},
                },
                new int[][] {
                    new int[] {103, 103, 132},
                },
                new int[][] {
                    new int[] {9, 32, -130},
                    new int[] {84, 84, 133},
                },
                new int[][] {
                    new int[] {9, 84, -132},
                },
                new int[][] {
                    new int[] {104, 104, 134},
                },
                new int[][] {
                    new int[] {114, 114, 135},
                },
                new int[][] {
                    new int[] {108, 108, 136},
                },
                new int[][] {
                    new int[] {101, 101, 137},
                },
                new int[][] {
                    new int[] {105, 105, 138},
                },
                new int[][] {
                    new int[] {101, 101, 139},
                },
                new int[][] {
                    new int[] {103, 103, 140},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {104, 104, 141},
                },
                new int[][] {
                    new int[] {116, 116, 142},
                },
                new int[][] {
                },
            },
            new int[][][] {
                new int[][] {
                    new int[] {9, 9, 1},
                    new int[] {10, 10, 2},
                    new int[] {13, 13, 3},
                    new int[] {32, 32, 4},
                    new int[] {36, 36, 5},
                    new int[] {39, 39, 6},
                    new int[] {40, 40, 7},
                    new int[] {41, 41, 8},
                    new int[] {42, 42, 9},
                    new int[] {43, 43, 10},
                    new int[] {44, 44, 11},
                    new int[] {45, 45, 12},
                    new int[] {46, 46, 13},
                    new int[] {47, 47, 14},
                    new int[] {48, 48, 15},
                    new int[] {58, 58, 16},
                    new int[] {59, 59, 17},
                    new int[] {61, 61, 18},
                    new int[] {63, 63, 19},
                    new int[] {65, 77, 20},
                    new int[] {78, 78, 21},
                    new int[] {79, 79, 20},
                    new int[] {80, 80, 22},
                    new int[] {81, 83, 20},
                    new int[] {84, 84, 23},
                    new int[] {85, 90, 20},
                    new int[] {91, 91, 24},
                    new int[] {93, 93, 25},
                    new int[] {95, 95, 26},
                    new int[] {97, 122, 27},
                    new int[] {123, 123, 28},
                    new int[] {124, 124, 29},
                },
                new int[][] {
                    new int[] {9, 32, -2},
                },
                new int[][] {
                    new int[] {9, 32, -2},
                },
                new int[][] {
                    new int[] {9, 9, 1},
                    new int[] {10, 10, 30},
                    new int[] {13, 32, -2},
                },
                new int[][] {
                    new int[] {9, 32, -2},
                },
                new int[][] {
                    new int[] {36, 36, 31},
                    new int[] {46, 46, 32},
                    new int[] {48, 57, 33},
                    new int[] {65, 90, 34},
                    new int[] {95, 95, 35},
                    new int[] {97, 122, 36},
                },
                new int[][] {
                    new int[] {0, 9, 37},
                    new int[] {11, 12, 37},
                    new int[] {14, 38, 37},
                    new int[] {39, 39, 38},
                    new int[] {40, 65535, 37},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {62, 62, 39},
                },
                new int[][] {
                    new int[] {46, 46, 40},
                },
                new int[][] {
                    new int[] {42, 42, 41},
                    new int[] {47, 47, 42},
                },
                new int[][] {
                    new int[] {88, 88, 43},
                    new int[] {120, 120, 44},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {36, 122, -7},
                },
                new int[][] {
                    new int[] {36, 95, -7},
                    new int[] {97, 100, 36},
                    new int[] {101, 101, 45},
                    new int[] {102, 116, 36},
                    new int[] {117, 117, 46},
                    new int[] {118, 122, 36},
                },
                new int[][] {
                    new int[] {36, 122, -7},
                },
                new int[][] {
                    new int[] {36, 122, -7},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {36, 122, -7},
                },
                new int[][] {
                    new int[] {36, 122, -7},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {9, 32, -2},
                },
                new int[][] {
                    new int[] {36, 122, -7},
                },
                new int[][] {
                    new int[] {36, 36, 47},
                    new int[] {65, 90, 48},
                    new int[] {95, 95, 49},
                    new int[] {97, 122, 50},
                },
                new int[][] {
                    new int[] {36, 122, -7},
                },
                new int[][] {
                    new int[] {36, 122, -7},
                },
                new int[][] {
                    new int[] {36, 122, -7},
                },
                new int[][] {
                    new int[] {36, 122, -7},
                },
                new int[][] {
                    new int[] {0, 9, 51},
                    new int[] {11, 12, 51},
                    new int[] {14, 38, 51},
                    new int[] {39, 39, 52},
                    new int[] {40, 65535, 51},
                },
                new int[][] {
                    new int[] {39, 39, 53},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {0, 41, 54},
                    new int[] {42, 42, 55},
                    new int[] {43, 65535, 54},
                },
                new int[][] {
                    new int[] {0, 9, 56},
                    new int[] {11, 12, 56},
                    new int[] {14, 65535, 56},
                },
                new int[][] {
                    new int[] {48, 57, 57},
                    new int[] {65, 70, 57},
                    new int[] {97, 102, 57},
                },
                new int[][] {
                    new int[] {48, 102, -45},
                },
                new int[][] {
                    new int[] {36, 95, -7},
                    new int[] {97, 118, 36},
                    new int[] {119, 119, 58},
                    new int[] {120, 122, 36},
                },
                new int[][] {
                    new int[] {36, 95, -7},
                    new int[] {97, 107, 36},
                    new int[] {108, 108, 59},
                    new int[] {109, 122, 36},
                },
                new int[][] {
                    new int[] {36, 36, 60},
                    new int[] {46, 46, 32},
                    new int[] {48, 57, 61},
                    new int[] {65, 90, 62},
                    new int[] {95, 95, 63},
                    new int[] {97, 122, 64},
                },
                new int[][] {
                    new int[] {36, 122, -49},
                },
                new int[][] {
                    new int[] {36, 122, -49},
                },
                new int[][] {
                    new int[] {36, 122, -49},
                },
                new int[][] {
                    new int[] {0, 38, -39},
                    new int[] {39, 39, 65},
                    new int[] {40, 65535, 51},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {0, 65535, -43},
                },
                new int[][] {
                    new int[] {0, 41, 66},
                    new int[] {42, 42, 55},
                    new int[] {43, 46, 66},
                    new int[] {47, 47, 67},
                    new int[] {48, 65535, 66},
                },
                new int[][] {
                    new int[] {0, 65535, -44},
                },
                new int[][] {
                    new int[] {48, 102, -45},
                },
                new int[][] {
                    new int[] {36, 122, -7},
                },
                new int[][] {
                    new int[] {36, 107, -48},
                    new int[] {108, 108, 68},
                    new int[] {109, 122, 36},
                },
                new int[][] {
                    new int[] {36, 122, -49},
                },
                new int[][] {
                    new int[] {36, 122, -49},
                },
                new int[][] {
                    new int[] {36, 122, -49},
                },
                new int[][] {
                    new int[] {36, 122, -49},
                },
                new int[][] {
                    new int[] {36, 122, -49},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {0, 41, 69},
                    new int[] {42, 42, 70},
                    new int[] {43, 65535, 69},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {36, 122, -7},
                },
                new int[][] {
                    new int[] {0, 65535, -68},
                },
                new int[][] {
                    new int[] {0, 41, 66},
                    new int[] {42, 42, 70},
                    new int[] {43, 65535, -57},
                },
            },
            new int[][][] {
                new int[][] {
                    new int[] {9, 9, 1},
                    new int[] {10, 10, 2},
                    new int[] {13, 13, 3},
                    new int[] {32, 32, 4},
                    new int[] {39, 39, 5},
                    new int[] {40, 40, 6},
                    new int[] {41, 41, 7},
                    new int[] {42, 42, 8},
                    new int[] {43, 43, 9},
                    new int[] {44, 44, 10},
                    new int[] {45, 45, 11},
                    new int[] {46, 46, 12},
                    new int[] {47, 47, 13},
                    new int[] {48, 48, 14},
                    new int[] {58, 58, 15},
                    new int[] {61, 61, 16},
                    new int[] {63, 63, 17},
                    new int[] {65, 65, 18},
                    new int[] {72, 72, 19},
                    new int[] {73, 73, 20},
                    new int[] {78, 78, 21},
                    new int[] {80, 80, 22},
                    new int[] {83, 83, 23},
                    new int[] {84, 84, 24},
                    new int[] {91, 91, 25},
                    new int[] {93, 93, 26},
                    new int[] {97, 122, 27},
                    new int[] {123, 123, 28},
                    new int[] {124, 124, 29},
                    new int[] {125, 125, 30},
                },
                new int[][] {
                    new int[] {9, 32, -2},
                },
                new int[][] {
                    new int[] {9, 32, -2},
                },
                new int[][] {
                    new int[] {9, 9, 1},
                    new int[] {10, 10, 31},
                    new int[] {13, 32, -2},
                },
                new int[][] {
                    new int[] {9, 32, -2},
                },
                new int[][] {
                    new int[] {0, 9, 32},
                    new int[] {11, 12, 32},
                    new int[] {14, 38, 32},
                    new int[] {39, 39, 33},
                    new int[] {40, 65535, 32},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {62, 62, 34},
                },
                new int[][] {
                    new int[] {46, 46, 35},
                },
                new int[][] {
                    new int[] {42, 42, 36},
                    new int[] {47, 47, 37},
                },
                new int[][] {
                    new int[] {88, 88, 38},
                    new int[] {120, 120, 39},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {98, 98, 40},
                },
                new int[][] {
                    new int[] {101, 101, 41},
                },
                new int[][] {
                    new int[] {103, 103, 42},
                },
                new int[][] {
                    new int[] {97, 97, 43},
                    new int[] {101, 101, 44},
                    new int[] {117, 117, 45},
                },
                new int[][] {
                    new int[] {114, 114, 46},
                },
                new int[][] {
                    new int[] {116, 116, 47},
                },
                new int[][] {
                    new int[] {111, 111, 48},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {48, 57, 49},
                    new int[] {95, 95, 50},
                    new int[] {97, 122, 51},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {9, 32, -2},
                },
                new int[][] {
                    new int[] {0, 9, 52},
                    new int[] {11, 12, 52},
                    new int[] {14, 38, 52},
                    new int[] {39, 39, 53},
                    new int[] {40, 65535, 52},
                },
                new int[][] {
                    new int[] {39, 39, 54},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {0, 41, 55},
                    new int[] {42, 42, 56},
                    new int[] {43, 65535, 55},
                },
                new int[][] {
                    new int[] {0, 9, 57},
                    new int[] {11, 12, 57},
                    new int[] {14, 65535, 57},
                },
                new int[][] {
                    new int[] {48, 57, 58},
                    new int[] {65, 70, 58},
                    new int[] {97, 102, 58},
                },
                new int[][] {
                    new int[] {48, 102, -40},
                },
                new int[][] {
                    new int[] {115, 115, 59},
                },
                new int[][] {
                    new int[] {108, 108, 60},
                },
                new int[][] {
                    new int[] {110, 110, 61},
                },
                new int[][] {
                    new int[] {109, 109, 62},
                },
                new int[][] {
                    new int[] {119, 119, 63},
                },
                new int[][] {
                    new int[] {108, 108, 64},
                },
                new int[][] {
                    new int[] {111, 111, 65},
                },
                new int[][] {
                    new int[] {97, 97, 66},
                },
                new int[][] {
                    new int[] {107, 107, 67},
                },
                new int[][] {
                    new int[] {48, 122, -29},
                },
                new int[][] {
                    new int[] {97, 122, 68},
                },
                new int[][] {
                    new int[] {48, 122, -29},
                },
                new int[][] {
                    new int[] {0, 38, -34},
                    new int[] {39, 39, 69},
                    new int[] {40, 65535, 52},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {0, 65535, -38},
                },
                new int[][] {
                    new int[] {0, 41, 70},
                    new int[] {42, 42, 56},
                    new int[] {43, 46, 70},
                    new int[] {47, 47, 71},
                    new int[] {48, 65535, 70},
                },
                new int[][] {
                    new int[] {0, 65535, -39},
                },
                new int[][] {
                    new int[] {48, 102, -40},
                },
                new int[][] {
                    new int[] {116, 116, 72},
                },
                new int[][] {
                    new int[] {112, 112, 73},
                },
                new int[][] {
                    new int[] {111, 111, 74},
                },
                new int[][] {
                    new int[] {101, 101, 75},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {108, 108, 76},
                },
                new int[][] {
                    new int[] {100, 100, 77},
                },
                new int[][] {
                    new int[] {116, 116, 78},
                },
                new int[][] {
                    new int[] {101, 101, 79},
                },
                new int[][] {
                    new int[] {48, 57, 80},
                    new int[] {95, 95, 50},
                    new int[] {97, 122, 81},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {0, 41, 82},
                    new int[] {42, 42, 83},
                    new int[] {43, 65535, 82},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {114, 114, 84},
                },
                new int[][] {
                    new int[] {101, 101, 85},
                },
                new int[][] {
                    new int[] {114, 114, 86},
                },
                new int[][] {
                    new int[] {115, 115, 87},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {117, 117, 88},
                },
                new int[][] {
                    new int[] {101, 101, 89},
                },
                new int[][] {
                    new int[] {110, 110, 90},
                },
                new int[][] {
                    new int[] {48, 122, -70},
                },
                new int[][] {
                    new int[] {48, 122, -70},
                },
                new int[][] {
                    new int[] {0, 65535, -72},
                },
                new int[][] {
                    new int[] {0, 41, 70},
                    new int[] {42, 42, 83},
                    new int[] {43, 65535, -58},
                },
                new int[][] {
                    new int[] {97, 97, 91},
                },
                new int[][] {
                    new int[] {114, 114, 92},
                },
                new int[][] {
                    new int[] {101, 101, 93},
                },
                new int[][] {
                    new int[] {112, 112, 94},
                },
                new int[][] {
                    new int[] {99, 99, 95},
                },
                new int[][] {
                    new int[] {115, 115, 96},
                },
                new int[][] {
                    new int[] {115, 115, 97},
                },
                new int[][] {
                    new int[] {99, 99, 98},
                },
                new int[][] {
                    new int[] {115, 115, 99},
                },
                new int[][] {
                    new int[] {100, 100, 100},
                },
                new int[][] {
                    new int[] {97, 97, 101},
                },
                new int[][] {
                    new int[] {116, 116, 102},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {116, 116, 103},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {99, 99, 104},
                },
                new int[][] {
                    new int[] {105, 105, 105},
                },
                new int[][] {
                    new int[] {9, 9, 106},
                    new int[] {32, 32, 107},
                },
                new int[][] {
                    new int[] {101, 101, 108},
                },
                new int[][] {
                    new int[] {111, 111, 109},
                },
                new int[][] {
                    new int[] {9, 32, -105},
                    new int[] {83, 83, 110},
                },
                new int[][] {
                    new int[] {9, 83, -108},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {110, 110, 111},
                },
                new int[][] {
                    new int[] {121, 121, 112},
                },
                new int[][] {
                    new int[] {115, 115, 113},
                },
                new int[][] {
                    new int[] {110, 110, 114},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {116, 116, 115},
                },
                new int[][] {
                    new int[] {97, 97, 116},
                },
                new int[][] {
                    new int[] {120, 120, 117},
                },
                new int[][] {
                    new int[] {9, 9, 118},
                    new int[] {32, 32, 119},
                },
                new int[][] {
                    new int[] {9, 32, -119},
                    new int[] {84, 84, 120},
                },
                new int[][] {
                    new int[] {9, 84, -120},
                },
                new int[][] {
                    new int[] {114, 114, 121},
                },
                new int[][] {
                    new int[] {101, 101, 122},
                },
                new int[][] {
                    new int[] {101, 101, 123},
                },
                new int[][] {
                },
            },
            new int[][][] {
                new int[][] {
                    new int[] {9, 9, 1},
                    new int[] {10, 10, 2},
                    new int[] {13, 13, 3},
                    new int[] {32, 32, 4},
                    new int[] {35, 35, 5},
                    new int[] {39, 39, 6},
                    new int[] {40, 40, 7},
                    new int[] {41, 41, 8},
                    new int[] {42, 42, 9},
                    new int[] {43, 43, 10},
                    new int[] {44, 44, 11},
                    new int[] {45, 45, 12},
                    new int[] {46, 46, 13},
                    new int[] {47, 47, 14},
                    new int[] {48, 48, 15},
                    new int[] {49, 57, 16},
                    new int[] {58, 58, 17},
                    new int[] {59, 59, 18},
                    new int[] {61, 61, 19},
                    new int[] {63, 63, 20},
                    new int[] {78, 78, 21},
                    new int[] {80, 80, 22},
                    new int[] {84, 84, 23},
                    new int[] {91, 91, 24},
                    new int[] {93, 93, 25},
                    new int[] {98, 98, 26},
                    new int[] {104, 104, 27},
                    new int[] {105, 105, 28},
                    new int[] {114, 114, 29},
                    new int[] {116, 116, 30},
                    new int[] {123, 123, 31},
                    new int[] {124, 124, 32},
                },
                new int[][] {
                    new int[] {9, 32, -2},
                },
                new int[][] {
                    new int[] {9, 32, -2},
                },
                new int[][] {
                    new int[] {9, 9, 1},
                    new int[] {10, 10, 33},
                    new int[] {13, 32, -2},
                },
                new int[][] {
                    new int[] {9, 32, -2},
                },
                new int[][] {
                    new int[] {48, 57, 34},
                    new int[] {65, 70, 34},
                    new int[] {97, 102, 34},
                },
                new int[][] {
                    new int[] {0, 9, 35},
                    new int[] {11, 12, 35},
                    new int[] {14, 38, 35},
                    new int[] {39, 39, 36},
                    new int[] {40, 65535, 35},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {62, 62, 37},
                },
                new int[][] {
                    new int[] {46, 46, 38},
                },
                new int[][] {
                    new int[] {42, 42, 39},
                    new int[] {47, 47, 40},
                },
                new int[][] {
                    new int[] {48, 57, 16},
                    new int[] {88, 88, 41},
                    new int[] {120, 120, 42},
                },
                new int[][] {
                    new int[] {48, 57, 16},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {101, 101, 43},
                    new int[] {117, 117, 44},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {97, 97, 45},
                    new int[] {111, 111, 46},
                },
                new int[][] {
                    new int[] {115, 115, 47},
                },
                new int[][] {
                    new int[] {116, 116, 48},
                },
                new int[][] {
                    new int[] {103, 103, 49},
                },
                new int[][] {
                    new int[] {101, 101, 50},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {9, 32, -2},
                },
                new int[][] {
                    new int[] {48, 102, -7},
                },
                new int[][] {
                    new int[] {0, 9, 51},
                    new int[] {11, 12, 51},
                    new int[] {14, 38, 51},
                    new int[] {39, 39, 52},
                    new int[] {40, 65535, 51},
                },
                new int[][] {
                    new int[] {39, 39, 53},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {0, 41, 54},
                    new int[] {42, 42, 55},
                    new int[] {43, 65535, 54},
                },
                new int[][] {
                    new int[] {0, 9, 56},
                    new int[] {11, 12, 56},
                    new int[] {14, 65535, 56},
                },
                new int[][] {
                    new int[] {48, 57, 57},
                    new int[] {65, 70, 57},
                    new int[] {97, 102, 57},
                },
                new int[][] {
                    new int[] {48, 102, -43},
                },
                new int[][] {
                    new int[] {119, 119, 58},
                },
                new int[][] {
                    new int[] {108, 108, 59},
                },
                new int[][] {
                    new int[] {99, 99, 60},
                },
                new int[][] {
                    new int[] {108, 108, 61},
                },
                new int[][] {
                    new int[] {98, 98, 62},
                    new int[] {118, 118, 63},
                },
                new int[][] {
                    new int[] {97, 97, 64},
                },
                new int[][] {
                    new int[] {98, 98, 65},
                },
                new int[][] {
                    new int[] {120, 120, 66},
                },
                new int[][] {
                    new int[] {0, 38, -37},
                    new int[] {39, 39, 67},
                    new int[] {40, 65535, 51},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {0, 65535, -41},
                },
                new int[][] {
                    new int[] {0, 41, 68},
                    new int[] {42, 42, 55},
                    new int[] {43, 46, 68},
                    new int[] {47, 47, 69},
                    new int[] {48, 65535, 68},
                },
                new int[][] {
                    new int[] {0, 65535, -42},
                },
                new int[][] {
                    new int[] {48, 102, -43},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {108, 108, 70},
                },
                new int[][] {
                    new int[] {107, 107, 71},
                },
                new int[][] {
                    new int[] {100, 100, 72},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {108, 108, 73},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {116, 116, 74},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {0, 41, 75},
                    new int[] {42, 42, 76},
                    new int[] {43, 65535, 75},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {103, 103, 77},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {105, 105, 78},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {0, 65535, -70},
                },
                new int[][] {
                    new int[] {0, 41, 68},
                    new int[] {42, 42, 76},
                    new int[] {43, 65535, -57},
                },
                new int[][] {
                    new int[] {114, 114, 79},
                },
                new int[][] {
                    new int[] {99, 99, 80},
                },
                new int[][] {
                    new int[] {111, 111, 81},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {117, 117, 82},
                },
                new int[][] {
                    new int[] {110, 110, 83},
                },
                new int[][] {
                    new int[] {100, 100, 84},
                },
                new int[][] {
                },
            },
        };
        
        
        #endregion
        
        
        
        #region Accept Table
        
        
        private static int[][] acceptTable = {
            new int[] {
                -1, 37, 37, 37, 37, -1, 19, 20, 26, 23, 28, 24, 13, 29, 34, 34,
                31, 15, 16, 25, -1, -1, -1, -1, 12, -1, 11, 17, 18, 32, 21, 27,
                22, 37, -1, -1, 30, 14, -1, 38, -1, -1, -1, -1, -1, -1, -1, -1,
                -1, -1, -1, 32, -1, 32, -1, 33, 33, -1, -1, 38, 35, -1, -1, -1,
                -1, 9, -1, -1, -1, -1, 32, 36, -1, 38, -1, -1, -1, -1, 10, -1,
                -1, -1, 32, 32, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
                -1, -1, 2, -1, 4, -1, 3, 5, -1, -1, -1, -1, -1, -1, -1, -1,
                -1, 1, -1, -1, -1, -1, -1, -1, 6, -1, -1, -1, -1, -1, -1, -1,
                -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 7, -1, -1, 8,
            },
            new int[] {
                -1, 37, 37, 37, 37, 0, -1, 19, 20, 26, 23, 28, 24, 13, 29, -1,
                31, 15, 16, 25, 0, 0, 0, 0, 17, 18, 0, 0, 21, 27, 37, 0,
                -1, 0, 0, 0, 0, -1, -1, 30, 14, -1, 38, -1, -1, 0, 0, 0,
                0, 0, 0, -1, 33, 33, -1, -1, 38, 35, 0, 0, 0, 0, 0, 0,
                0, 36, -1, 38, 0, -1, -1,
            },
            new int[] {
                -1, 37, 37, 37, 37, -1, 19, 20, 26, 23, 28, 24, 13, 29, -1, 31,
                16, 25, -1, -1, -1, -1, 12, -1, 11, 17, 18, 32, 21, 27, 22, 37,
                -1, -1, 30, 14, -1, 38, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
                -1, 32, -1, 32, -1, 33, 33, -1, -1, 38, 35, -1, -1, -1, -1, 9,
                -1, -1, -1, -1, 32, 36, -1, 38, -1, -1, -1, -1, 10, -1, -1, -1,
                32, 32, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
                2, 4, -1, 3, 5, -1, -1, -1, -1, -1, -1, -1, 1, -1, -1, -1,
                -1, 6, -1, -1, -1, -1, -1, -1, -1, -1, -1, 7,
            },
            new int[] {
                -1, 37, 37, 37, 37, -1, -1, 19, 20, 26, 23, 28, 24, 13, 29, 34,
                34, 31, 15, 16, 25, -1, 12, 11, 17, 18, -1, -1, -1, -1, -1, 21,
                27, 37, 45, -1, -1, 30, 14, -1, 38, -1, -1, -1, -1, -1, -1, -1,
                -1, -1, -1, -1, 33, 33, -1, -1, 38, 35, 9, -1, -1, -1, 44, 44,
                -1, 43, -1, 36, -1, 38, 10, -1, 40, -1, 41, -1, -1, -1, -1, -1,
                39, -1, -1, -1, 42,
            },
        };
        
        
        #endregion
        
    }
}
