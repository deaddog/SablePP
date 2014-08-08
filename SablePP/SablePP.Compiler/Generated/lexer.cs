using System;
using SablePP.Compiler.Nodes;

namespace SablePP.Compiler.Lexing
{
    public class Lexer : SablePP.Tools.Lexing.Lexer
    {
        private const int NORMAL = 0;
        private const int PACKAGE = 1;
        private const int HIGHLIGHT = 2;
        private const int HIGHLIGHTSTYLES = 3;
        
        public Lexer(System.IO.TextReader input)
            : base(input, NORMAL, gotoTable, acceptTable)
        {
        }
        
        protected override SablePP.Tools.Nodes.Token getToken(int tokenIndex, string text, int line, int position)
        {
            switch (tokenIndex)
            {
                case 0: return new TPackagename(text, line, position);
                case 1: return new TPackagetoken(text, line, position);
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
                        case NORMAL: return PACKAGE;
                        case HIGHLIGHT: return PACKAGE;
                        default: return -1;
                    }
                case 2:
                    switch (currentState)
                    {
                        case HIGHLIGHT: return NORMAL;
                        default: return -1;
                    }
                case 3:
                    switch (currentState)
                    {
                        case HIGHLIGHT: return NORMAL;
                        default: return -1;
                    }
                case 4:
                    switch (currentState)
                    {
                        case HIGHLIGHT: return NORMAL;
                        default: return -1;
                    }
                case 5:
                    switch (currentState)
                    {
                        case HIGHLIGHT: return NORMAL;
                        default: return -1;
                    }
                case 6:
                    switch (currentState)
                    {
                        case HIGHLIGHT: return NORMAL;
                        default: return -1;
                    }
                case 7:
                    switch (currentState)
                    {
                        case HIGHLIGHT: return NORMAL;
                        default: return -1;
                    }
                case 8:
                    switch (currentState)
                    {
                        case NORMAL: return HIGHLIGHT;
                        default: return -1;
                    }
                case 15:
                    switch (currentState)
                    {
                        case PACKAGE: return NORMAL;
                        case HIGHLIGHTSTYLES: return HIGHLIGHT;
                        default: return -1;
                    }
                case 22:
                    switch (currentState)
                    {
                        case HIGHLIGHT: return HIGHLIGHTSTYLES;
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
                    new int[] {97, 97, 48},
                    new int[] {114, 114, 49},
                },
                new int[][] {
                    new int[] {116, 116, 50},
                },
                new int[][] {
                    new int[] {111, 111, 51},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {48, 57, 52},
                    new int[] {95, 95, 53},
                    new int[] {97, 122, 54},
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
                    new int[] {0, 9, 55},
                    new int[] {11, 12, 55},
                    new int[] {14, 38, 55},
                    new int[] {39, 39, 56},
                    new int[] {40, 65535, 55},
                },
                new int[][] {
                    new int[] {39, 39, 57},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {0, 41, 58},
                    new int[] {42, 42, 59},
                    new int[] {43, 65535, 58},
                },
                new int[][] {
                    new int[] {0, 9, 60},
                    new int[] {11, 12, 60},
                    new int[] {14, 65535, 60},
                },
                new int[][] {
                    new int[] {48, 57, 61},
                    new int[] {65, 70, 61},
                    new int[] {97, 102, 61},
                },
                new int[][] {
                    new int[] {48, 102, -42},
                },
                new int[][] {
                    new int[] {115, 115, 62},
                },
                new int[][] {
                    new int[] {108, 108, 63},
                },
                new int[][] {
                    new int[] {110, 110, 64},
                },
                new int[][] {
                    new int[] {109, 109, 65},
                },
                new int[][] {
                    new int[] {119, 119, 66},
                },
                new int[][] {
                    new int[] {108, 108, 67},
                },
                new int[][] {
                    new int[] {99, 99, 68},
                },
                new int[][] {
                    new int[] {111, 111, 69},
                },
                new int[][] {
                    new int[] {97, 97, 70},
                },
                new int[][] {
                    new int[] {107, 107, 71},
                },
                new int[][] {
                    new int[] {48, 122, -31},
                },
                new int[][] {
                    new int[] {97, 122, 72},
                },
                new int[][] {
                    new int[] {48, 122, -31},
                },
                new int[][] {
                    new int[] {0, 38, -36},
                    new int[] {39, 39, 73},
                    new int[] {40, 65535, 55},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {0, 65535, -40},
                },
                new int[][] {
                    new int[] {0, 41, 74},
                    new int[] {42, 42, 59},
                    new int[] {43, 46, 74},
                    new int[] {47, 47, 75},
                    new int[] {48, 65535, 74},
                },
                new int[][] {
                    new int[] {0, 65535, -41},
                },
                new int[][] {
                    new int[] {48, 102, -42},
                },
                new int[][] {
                    new int[] {116, 116, 76},
                },
                new int[][] {
                    new int[] {112, 112, 77},
                },
                new int[][] {
                    new int[] {111, 111, 78},
                },
                new int[][] {
                    new int[] {101, 101, 79},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {108, 108, 80},
                },
                new int[][] {
                    new int[] {107, 107, 81},
                },
                new int[][] {
                    new int[] {100, 100, 82},
                },
                new int[][] {
                    new int[] {116, 116, 83},
                },
                new int[][] {
                    new int[] {101, 101, 84},
                },
                new int[][] {
                    new int[] {48, 57, 85},
                    new int[] {95, 95, 53},
                    new int[] {97, 122, 86},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {0, 41, 87},
                    new int[] {42, 42, 88},
                    new int[] {43, 65535, 87},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {114, 114, 89},
                },
                new int[][] {
                    new int[] {101, 101, 90},
                },
                new int[][] {
                    new int[] {114, 114, 91},
                },
                new int[][] {
                    new int[] {115, 115, 92},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {97, 97, 93},
                },
                new int[][] {
                    new int[] {117, 117, 94},
                },
                new int[][] {
                    new int[] {101, 101, 95},
                },
                new int[][] {
                    new int[] {110, 110, 96},
                },
                new int[][] {
                    new int[] {48, 122, -74},
                },
                new int[][] {
                    new int[] {48, 122, -74},
                },
                new int[][] {
                    new int[] {0, 65535, -76},
                },
                new int[][] {
                    new int[] {0, 41, 74},
                    new int[] {42, 42, 88},
                    new int[] {43, 65535, -61},
                },
                new int[][] {
                    new int[] {97, 97, 97},
                },
                new int[][] {
                    new int[] {114, 114, 98},
                },
                new int[][] {
                    new int[] {101, 101, 99},
                },
                new int[][] {
                    new int[] {112, 112, 100},
                },
                new int[][] {
                    new int[] {103, 103, 101},
                },
                new int[][] {
                    new int[] {99, 99, 102},
                },
                new int[][] {
                    new int[] {115, 115, 103},
                },
                new int[][] {
                    new int[] {32, 32, 104},
                    new int[] {115, 115, 105},
                },
                new int[][] {
                    new int[] {99, 99, 106},
                },
                new int[][] {
                    new int[] {115, 115, 107},
                },
                new int[][] {
                    new int[] {100, 100, 108},
                },
                new int[][] {
                    new int[] {97, 97, 109},
                },
                new int[][] {
                    new int[] {101, 101, 110},
                },
                new int[][] {
                    new int[] {116, 116, 111},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {83, 83, 112},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {116, 116, 113},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {99, 99, 114},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {105, 105, 115},
                },
                new int[][] {
                    new int[] {121, 121, 116},
                },
                new int[][] {
                    new int[] {9, 9, 117},
                    new int[] {32, 32, 118},
                },
                new int[][] {
                    new int[] {101, 101, 119},
                },
                new int[][] {
                    new int[] {111, 111, 120},
                },
                new int[][] {
                    new int[] {110, 110, 121},
                },
                new int[][] {
                    new int[] {9, 32, -115},
                    new int[] {83, 83, 122},
                },
                new int[][] {
                    new int[] {9, 83, -119},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {110, 110, 123},
                },
                new int[][] {
                    new int[] {116, 116, 124},
                },
                new int[][] {
                    new int[] {121, 121, 125},
                },
                new int[][] {
                    new int[] {115, 115, 126},
                },
                new int[][] {
                    new int[] {97, 97, 127},
                },
                new int[][] {
                    new int[] {110, 110, 128},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {120, 120, 129},
                },
                new int[][] {
                    new int[] {116, 116, 130},
                },
                new int[][] {
                    new int[] {32, 32, 131},
                },
                new int[][] {
                    new int[] {97, 97, 132},
                },
                new int[][] {
                    new int[] {72, 72, 133},
                },
                new int[][] {
                    new int[] {120, 120, 134},
                },
                new int[][] {
                    new int[] {105, 105, 135},
                },
                new int[][] {
                    new int[] {9, 9, 136},
                    new int[] {32, 32, 137},
                },
                new int[][] {
                    new int[] {103, 103, 138},
                },
                new int[][] {
                    new int[] {9, 32, -136},
                    new int[] {84, 84, 139},
                },
                new int[][] {
                    new int[] {9, 84, -138},
                },
                new int[][] {
                    new int[] {104, 104, 140},
                },
                new int[][] {
                    new int[] {114, 114, 141},
                },
                new int[][] {
                    new int[] {108, 108, 142},
                },
                new int[][] {
                    new int[] {101, 101, 143},
                },
                new int[][] {
                    new int[] {105, 105, 144},
                },
                new int[][] {
                    new int[] {101, 101, 145},
                },
                new int[][] {
                    new int[] {103, 103, 146},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {104, 104, 147},
                },
                new int[][] {
                    new int[] {116, 116, 148},
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
                    new int[] {97, 97, 46},
                    new int[] {114, 114, 47},
                },
                new int[][] {
                    new int[] {116, 116, 48},
                },
                new int[][] {
                    new int[] {111, 111, 49},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {48, 57, 50},
                    new int[] {95, 95, 51},
                    new int[] {97, 122, 52},
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
                    new int[] {0, 9, 53},
                    new int[] {11, 12, 53},
                    new int[] {14, 38, 53},
                    new int[] {39, 39, 54},
                    new int[] {40, 65535, 53},
                },
                new int[][] {
                    new int[] {39, 39, 55},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {0, 41, 56},
                    new int[] {42, 42, 57},
                    new int[] {43, 65535, 56},
                },
                new int[][] {
                    new int[] {0, 9, 58},
                    new int[] {11, 12, 58},
                    new int[] {14, 65535, 58},
                },
                new int[][] {
                    new int[] {48, 57, 59},
                    new int[] {65, 70, 59},
                    new int[] {97, 102, 59},
                },
                new int[][] {
                    new int[] {48, 102, -40},
                },
                new int[][] {
                    new int[] {115, 115, 60},
                },
                new int[][] {
                    new int[] {108, 108, 61},
                },
                new int[][] {
                    new int[] {110, 110, 62},
                },
                new int[][] {
                    new int[] {109, 109, 63},
                },
                new int[][] {
                    new int[] {119, 119, 64},
                },
                new int[][] {
                    new int[] {108, 108, 65},
                },
                new int[][] {
                    new int[] {99, 99, 66},
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
                    new int[] {48, 122, -29},
                },
                new int[][] {
                    new int[] {97, 122, 70},
                },
                new int[][] {
                    new int[] {48, 122, -29},
                },
                new int[][] {
                    new int[] {0, 38, -34},
                    new int[] {39, 39, 71},
                    new int[] {40, 65535, 53},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {0, 65535, -38},
                },
                new int[][] {
                    new int[] {0, 41, 72},
                    new int[] {42, 42, 57},
                    new int[] {43, 46, 72},
                    new int[] {47, 47, 73},
                    new int[] {48, 65535, 72},
                },
                new int[][] {
                    new int[] {0, 65535, -39},
                },
                new int[][] {
                    new int[] {48, 102, -40},
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
                    new int[] {107, 107, 79},
                },
                new int[][] {
                    new int[] {100, 100, 80},
                },
                new int[][] {
                    new int[] {116, 116, 81},
                },
                new int[][] {
                    new int[] {101, 101, 82},
                },
                new int[][] {
                    new int[] {48, 57, 83},
                    new int[] {95, 95, 51},
                    new int[] {97, 122, 84},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {0, 41, 85},
                    new int[] {42, 42, 86},
                    new int[] {43, 65535, 85},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {114, 114, 87},
                },
                new int[][] {
                    new int[] {101, 101, 88},
                },
                new int[][] {
                    new int[] {114, 114, 89},
                },
                new int[][] {
                    new int[] {115, 115, 90},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {97, 97, 91},
                },
                new int[][] {
                    new int[] {117, 117, 92},
                },
                new int[][] {
                    new int[] {101, 101, 93},
                },
                new int[][] {
                    new int[] {110, 110, 94},
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
                    new int[] {42, 42, 86},
                    new int[] {43, 65535, -59},
                },
                new int[][] {
                    new int[] {97, 97, 95},
                },
                new int[][] {
                    new int[] {114, 114, 96},
                },
                new int[][] {
                    new int[] {101, 101, 97},
                },
                new int[][] {
                    new int[] {112, 112, 98},
                },
                new int[][] {
                    new int[] {103, 103, 99},
                },
                new int[][] {
                    new int[] {99, 99, 100},
                },
                new int[][] {
                    new int[] {115, 115, 101},
                },
                new int[][] {
                    new int[] {115, 115, 102},
                },
                new int[][] {
                    new int[] {99, 99, 103},
                },
                new int[][] {
                    new int[] {115, 115, 104},
                },
                new int[][] {
                    new int[] {100, 100, 105},
                },
                new int[][] {
                    new int[] {97, 97, 106},
                },
                new int[][] {
                    new int[] {101, 101, 107},
                },
                new int[][] {
                    new int[] {116, 116, 108},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {116, 116, 109},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {99, 99, 110},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {105, 105, 111},
                },
                new int[][] {
                    new int[] {9, 9, 112},
                    new int[] {32, 32, 113},
                },
                new int[][] {
                    new int[] {101, 101, 114},
                },
                new int[][] {
                    new int[] {111, 111, 115},
                },
                new int[][] {
                    new int[] {9, 32, -111},
                    new int[] {83, 83, 116},
                },
                new int[][] {
                    new int[] {9, 83, -114},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {110, 110, 117},
                },
                new int[][] {
                    new int[] {121, 121, 118},
                },
                new int[][] {
                    new int[] {115, 115, 119},
                },
                new int[][] {
                    new int[] {110, 110, 120},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {116, 116, 121},
                },
                new int[][] {
                    new int[] {97, 97, 122},
                },
                new int[][] {
                    new int[] {120, 120, 123},
                },
                new int[][] {
                    new int[] {9, 9, 124},
                    new int[] {32, 32, 125},
                },
                new int[][] {
                    new int[] {9, 32, -125},
                    new int[] {84, 84, 126},
                },
                new int[][] {
                    new int[] {9, 84, -126},
                },
                new int[][] {
                    new int[] {114, 114, 127},
                },
                new int[][] {
                    new int[] {101, 101, 128},
                },
                new int[][] {
                    new int[] {101, 101, 129},
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
                -1, -1, -1, -1, 32, -1, 32, -1, 33, 33, -1, -1, 38, 35, -1, -1,
                -1, -1, 9, -1, -1, -1, -1, -1, 32, 36, -1, 38, -1, -1, -1, -1,
                10, -1, -1, -1, -1, 32, 32, -1, -1, -1, -1, -1, -1, -1, -1, -1,
                -1, -1, -1, -1, -1, -1, -1, 2, -1, 4, -1, 3, 5, -1, 1, -1,
                -1, -1, -1, -1, -1, -1, -1, 1, -1, -1, -1, -1, -1, -1, 6, -1,
                -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
                -1, 7, -1, -1, 8,
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
                -1, -1, 32, -1, 32, -1, 33, 33, -1, -1, 38, 35, -1, -1, -1, -1,
                9, -1, -1, -1, -1, -1, 32, 36, -1, 38, -1, -1, -1, -1, 10, -1,
                -1, -1, -1, 32, 32, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
                -1, -1, -1, -1, -1, 2, 4, -1, 3, 5, -1, 1, -1, -1, -1, -1,
                -1, -1, 1, -1, -1, -1, -1, 6, -1, -1, -1, -1, -1, -1, -1, -1,
                -1, 7,
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
