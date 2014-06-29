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
                    new int[] {10, 10, 61},
                    new int[] {11, 12, 60},
                    new int[] {13, 13, 62},
                    new int[] {14, 65535, 60},
                },
                new int[][] {
                    new int[] {48, 57, 63},
                    new int[] {65, 70, 63},
                    new int[] {97, 102, 63},
                },
                new int[][] {
                    new int[] {48, 102, -42},
                },
                new int[][] {
                    new int[] {115, 115, 64},
                },
                new int[][] {
                    new int[] {108, 108, 65},
                },
                new int[][] {
                    new int[] {110, 110, 66},
                },
                new int[][] {
                    new int[] {109, 109, 67},
                },
                new int[][] {
                    new int[] {119, 119, 68},
                },
                new int[][] {
                    new int[] {108, 108, 69},
                },
                new int[][] {
                    new int[] {99, 99, 70},
                },
                new int[][] {
                    new int[] {111, 111, 71},
                },
                new int[][] {
                    new int[] {97, 97, 72},
                },
                new int[][] {
                    new int[] {107, 107, 73},
                },
                new int[][] {
                    new int[] {48, 122, -31},
                },
                new int[][] {
                    new int[] {97, 122, 74},
                },
                new int[][] {
                    new int[] {48, 122, -31},
                },
                new int[][] {
                    new int[] {0, 38, -36},
                    new int[] {39, 39, 75},
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
                    new int[] {0, 41, 76},
                    new int[] {42, 42, 59},
                    new int[] {43, 46, 76},
                    new int[] {47, 47, 77},
                    new int[] {48, 65535, 76},
                },
                new int[][] {
                    new int[] {0, 65535, -41},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {10, 10, 78},
                },
                new int[][] {
                    new int[] {48, 102, -42},
                },
                new int[][] {
                    new int[] {116, 116, 79},
                },
                new int[][] {
                    new int[] {112, 112, 80},
                },
                new int[][] {
                    new int[] {111, 111, 81},
                },
                new int[][] {
                    new int[] {101, 101, 82},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {108, 108, 83},
                },
                new int[][] {
                    new int[] {107, 107, 84},
                },
                new int[][] {
                    new int[] {100, 100, 85},
                },
                new int[][] {
                    new int[] {116, 116, 86},
                },
                new int[][] {
                    new int[] {101, 101, 87},
                },
                new int[][] {
                    new int[] {48, 57, 88},
                    new int[] {95, 95, 53},
                    new int[] {97, 122, 89},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {0, 41, 90},
                    new int[] {42, 42, 91},
                    new int[] {43, 65535, 90},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {114, 114, 92},
                },
                new int[][] {
                    new int[] {101, 101, 93},
                },
                new int[][] {
                    new int[] {114, 114, 94},
                },
                new int[][] {
                    new int[] {115, 115, 95},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {97, 97, 96},
                },
                new int[][] {
                    new int[] {117, 117, 97},
                },
                new int[][] {
                    new int[] {101, 101, 98},
                },
                new int[][] {
                    new int[] {110, 110, 99},
                },
                new int[][] {
                    new int[] {48, 122, -76},
                },
                new int[][] {
                    new int[] {48, 122, -76},
                },
                new int[][] {
                    new int[] {0, 65535, -78},
                },
                new int[][] {
                    new int[] {0, 41, 76},
                    new int[] {42, 42, 91},
                    new int[] {43, 65535, -61},
                },
                new int[][] {
                    new int[] {97, 97, 100},
                },
                new int[][] {
                    new int[] {114, 114, 101},
                },
                new int[][] {
                    new int[] {101, 101, 102},
                },
                new int[][] {
                    new int[] {112, 112, 103},
                },
                new int[][] {
                    new int[] {103, 103, 104},
                },
                new int[][] {
                    new int[] {99, 99, 105},
                },
                new int[][] {
                    new int[] {115, 115, 106},
                },
                new int[][] {
                    new int[] {32, 32, 107},
                    new int[] {115, 115, 108},
                },
                new int[][] {
                    new int[] {99, 99, 109},
                },
                new int[][] {
                    new int[] {115, 115, 110},
                },
                new int[][] {
                    new int[] {100, 100, 111},
                },
                new int[][] {
                    new int[] {97, 97, 112},
                },
                new int[][] {
                    new int[] {101, 101, 113},
                },
                new int[][] {
                    new int[] {116, 116, 114},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {83, 83, 115},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {116, 116, 116},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {99, 99, 117},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {105, 105, 118},
                },
                new int[][] {
                    new int[] {121, 121, 119},
                },
                new int[][] {
                    new int[] {9, 9, 120},
                    new int[] {32, 32, 121},
                },
                new int[][] {
                    new int[] {101, 101, 122},
                },
                new int[][] {
                    new int[] {111, 111, 123},
                },
                new int[][] {
                    new int[] {110, 110, 124},
                },
                new int[][] {
                    new int[] {9, 32, -118},
                    new int[] {83, 83, 125},
                },
                new int[][] {
                    new int[] {9, 83, -122},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {110, 110, 126},
                },
                new int[][] {
                    new int[] {116, 116, 127},
                },
                new int[][] {
                    new int[] {121, 121, 128},
                },
                new int[][] {
                    new int[] {115, 115, 129},
                },
                new int[][] {
                    new int[] {97, 97, 130},
                },
                new int[][] {
                    new int[] {110, 110, 131},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {120, 120, 132},
                },
                new int[][] {
                    new int[] {116, 116, 133},
                },
                new int[][] {
                    new int[] {32, 32, 134},
                },
                new int[][] {
                    new int[] {97, 97, 135},
                },
                new int[][] {
                    new int[] {72, 72, 136},
                },
                new int[][] {
                    new int[] {120, 120, 137},
                },
                new int[][] {
                    new int[] {105, 105, 138},
                },
                new int[][] {
                    new int[] {9, 9, 139},
                    new int[] {32, 32, 140},
                },
                new int[][] {
                    new int[] {103, 103, 141},
                },
                new int[][] {
                    new int[] {9, 32, -139},
                    new int[] {84, 84, 142},
                },
                new int[][] {
                    new int[] {9, 84, -141},
                },
                new int[][] {
                    new int[] {104, 104, 143},
                },
                new int[][] {
                    new int[] {114, 114, 144},
                },
                new int[][] {
                    new int[] {108, 108, 145},
                },
                new int[][] {
                    new int[] {101, 101, 146},
                },
                new int[][] {
                    new int[] {105, 105, 147},
                },
                new int[][] {
                    new int[] {101, 101, 148},
                },
                new int[][] {
                    new int[] {103, 103, 149},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {104, 104, 150},
                },
                new int[][] {
                    new int[] {116, 116, 151},
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
                    new int[] {65, 65, 20},
                    new int[] {66, 71, 21},
                    new int[] {72, 72, 22},
                    new int[] {73, 73, 23},
                    new int[] {74, 77, 21},
                    new int[] {78, 78, 24},
                    new int[] {79, 79, 21},
                    new int[] {80, 80, 25},
                    new int[] {81, 82, 21},
                    new int[] {83, 83, 26},
                    new int[] {84, 84, 27},
                    new int[] {85, 90, 21},
                    new int[] {91, 91, 28},
                    new int[] {93, 93, 29},
                    new int[] {95, 95, 30},
                    new int[] {97, 122, 31},
                    new int[] {123, 123, 32},
                    new int[] {124, 124, 33},
                },
                new int[][] {
                    new int[] {9, 32, -2},
                },
                new int[][] {
                    new int[] {9, 32, -2},
                },
                new int[][] {
                    new int[] {9, 9, 1},
                    new int[] {10, 10, 34},
                    new int[] {13, 32, -2},
                },
                new int[][] {
                    new int[] {9, 32, -2},
                },
                new int[][] {
                    new int[] {36, 36, 35},
                    new int[] {46, 46, 36},
                    new int[] {48, 57, 37},
                    new int[] {65, 90, 38},
                    new int[] {95, 95, 39},
                    new int[] {97, 122, 40},
                },
                new int[][] {
                    new int[] {0, 9, 41},
                    new int[] {11, 12, 41},
                    new int[] {14, 38, 41},
                    new int[] {39, 39, 42},
                    new int[] {40, 65535, 41},
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
                    new int[] {62, 62, 43},
                },
                new int[][] {
                    new int[] {46, 46, 44},
                },
                new int[][] {
                    new int[] {42, 42, 45},
                    new int[] {47, 47, 46},
                },
                new int[][] {
                    new int[] {88, 88, 47},
                    new int[] {120, 120, 48},
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
                    new int[] {36, 95, -7},
                    new int[] {97, 97, 40},
                    new int[] {98, 98, 49},
                    new int[] {99, 122, 40},
                },
                new int[][] {
                    new int[] {36, 122, -7},
                },
                new int[][] {
                    new int[] {36, 95, -7},
                    new int[] {97, 100, 40},
                    new int[] {101, 101, 50},
                    new int[] {102, 122, 40},
                },
                new int[][] {
                    new int[] {36, 95, -7},
                    new int[] {97, 102, 40},
                    new int[] {103, 103, 51},
                    new int[] {104, 122, 40},
                },
                new int[][] {
                    new int[] {36, 100, -24},
                    new int[] {101, 101, 52},
                    new int[] {102, 116, 40},
                    new int[] {117, 117, 53},
                    new int[] {118, 122, 40},
                },
                new int[][] {
                    new int[] {36, 95, -7},
                    new int[] {97, 113, 40},
                    new int[] {114, 114, 54},
                    new int[] {115, 122, 40},
                },
                new int[][] {
                    new int[] {36, 95, -7},
                    new int[] {97, 115, 40},
                    new int[] {116, 116, 55},
                    new int[] {117, 122, 40},
                },
                new int[][] {
                    new int[] {36, 95, -7},
                    new int[] {97, 110, 40},
                    new int[] {111, 111, 56},
                    new int[] {112, 122, 40},
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
                    new int[] {36, 36, 57},
                    new int[] {65, 90, 58},
                    new int[] {95, 95, 59},
                    new int[] {97, 122, 60},
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
                    new int[] {0, 9, 61},
                    new int[] {11, 12, 61},
                    new int[] {14, 38, 61},
                    new int[] {39, 39, 62},
                    new int[] {40, 65535, 61},
                },
                new int[][] {
                    new int[] {39, 39, 63},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {0, 41, 64},
                    new int[] {42, 42, 65},
                    new int[] {43, 65535, 64},
                },
                new int[][] {
                    new int[] {0, 9, 66},
                    new int[] {10, 10, 67},
                    new int[] {11, 12, 66},
                    new int[] {13, 13, 68},
                    new int[] {14, 65535, 66},
                },
                new int[][] {
                    new int[] {48, 57, 69},
                    new int[] {65, 70, 69},
                    new int[] {97, 102, 69},
                },
                new int[][] {
                    new int[] {48, 102, -49},
                },
                new int[][] {
                    new int[] {36, 95, -7},
                    new int[] {97, 114, 40},
                    new int[] {115, 115, 70},
                    new int[] {116, 122, 40},
                },
                new int[][] {
                    new int[] {36, 95, -7},
                    new int[] {97, 107, 40},
                    new int[] {108, 108, 71},
                    new int[] {109, 122, 40},
                },
                new int[][] {
                    new int[] {36, 95, -7},
                    new int[] {97, 109, 40},
                    new int[] {110, 110, 72},
                    new int[] {111, 122, 40},
                },
                new int[][] {
                    new int[] {36, 95, -7},
                    new int[] {97, 118, 40},
                    new int[] {119, 119, 73},
                    new int[] {120, 122, 40},
                },
                new int[][] {
                    new int[] {36, 107, -52},
                    new int[] {108, 108, 74},
                    new int[] {109, 122, 40},
                },
                new int[][] {
                    new int[] {36, 110, -29},
                    new int[] {111, 111, 75},
                    new int[] {112, 122, 40},
                },
                new int[][] {
                    new int[] {36, 95, -7},
                    new int[] {97, 97, 76},
                    new int[] {98, 122, 40},
                },
                new int[][] {
                    new int[] {36, 95, -7},
                    new int[] {97, 106, 40},
                    new int[] {107, 107, 77},
                    new int[] {108, 122, 40},
                },
                new int[][] {
                    new int[] {36, 36, 78},
                    new int[] {46, 46, 36},
                    new int[] {48, 57, 79},
                    new int[] {65, 90, 80},
                    new int[] {95, 95, 81},
                    new int[] {97, 122, 82},
                },
                new int[][] {
                    new int[] {36, 122, -59},
                },
                new int[][] {
                    new int[] {36, 122, -59},
                },
                new int[][] {
                    new int[] {36, 122, -59},
                },
                new int[][] {
                    new int[] {0, 38, -43},
                    new int[] {39, 39, 83},
                    new int[] {40, 65535, 61},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {0, 65535, -47},
                },
                new int[][] {
                    new int[] {0, 41, 84},
                    new int[] {42, 42, 65},
                    new int[] {43, 46, 84},
                    new int[] {47, 47, 85},
                    new int[] {48, 65535, 84},
                },
                new int[][] {
                    new int[] {0, 65535, -48},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {10, 10, 86},
                },
                new int[][] {
                    new int[] {48, 102, -49},
                },
                new int[][] {
                    new int[] {36, 115, -28},
                    new int[] {116, 116, 87},
                    new int[] {117, 122, 40},
                },
                new int[][] {
                    new int[] {36, 95, -7},
                    new int[] {97, 111, 40},
                    new int[] {112, 112, 88},
                    new int[] {113, 122, 40},
                },
                new int[][] {
                    new int[] {36, 110, -29},
                    new int[] {111, 111, 89},
                    new int[] {112, 122, 40},
                },
                new int[][] {
                    new int[] {36, 122, -7},
                },
                new int[][] {
                    new int[] {36, 107, -52},
                    new int[] {108, 108, 90},
                    new int[] {109, 122, 40},
                },
                new int[][] {
                    new int[] {36, 95, -7},
                    new int[] {97, 99, 40},
                    new int[] {100, 100, 91},
                    new int[] {101, 122, 40},
                },
                new int[][] {
                    new int[] {36, 115, -28},
                    new int[] {116, 116, 92},
                    new int[] {117, 122, 40},
                },
                new int[][] {
                    new int[] {36, 100, -24},
                    new int[] {101, 101, 93},
                    new int[] {102, 122, 40},
                },
                new int[][] {
                    new int[] {36, 122, -59},
                },
                new int[][] {
                    new int[] {36, 122, -59},
                },
                new int[][] {
                    new int[] {36, 122, -59},
                },
                new int[][] {
                    new int[] {36, 122, -59},
                },
                new int[][] {
                    new int[] {36, 122, -59},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {0, 41, 94},
                    new int[] {42, 42, 95},
                    new int[] {43, 65535, 94},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {36, 113, -27},
                    new int[] {114, 114, 96},
                    new int[] {115, 122, 40},
                },
                new int[][] {
                    new int[] {36, 100, -24},
                    new int[] {101, 101, 97},
                    new int[] {102, 122, 40},
                },
                new int[][] {
                    new int[] {36, 113, -27},
                    new int[] {114, 114, 98},
                    new int[] {115, 122, 40},
                },
                new int[][] {
                    new int[] {36, 122, -7},
                },
                new int[][] {
                    new int[] {36, 95, -7},
                    new int[] {97, 116, 40},
                    new int[] {117, 117, 99},
                    new int[] {118, 122, 40},
                },
                new int[][] {
                    new int[] {36, 100, -24},
                    new int[] {101, 101, 100},
                    new int[] {102, 122, 40},
                },
                new int[][] {
                    new int[] {36, 109, -53},
                    new int[] {110, 110, 101},
                    new int[] {111, 122, 40},
                },
                new int[][] {
                    new int[] {0, 65535, -86},
                },
                new int[][] {
                    new int[] {0, 41, 84},
                    new int[] {42, 42, 95},
                    new int[] {43, 65535, -67},
                },
                new int[][] {
                    new int[] {36, 95, -7},
                    new int[] {97, 97, 102},
                    new int[] {98, 122, 40},
                },
                new int[][] {
                    new int[] {36, 113, -27},
                    new int[] {114, 114, 103},
                    new int[] {115, 122, 40},
                },
                new int[][] {
                    new int[] {36, 100, -24},
                    new int[] {101, 101, 104},
                    new int[] {102, 122, 40},
                },
                new int[][] {
                    new int[] {36, 95, -7},
                    new int[] {97, 98, 40},
                    new int[] {99, 99, 105},
                    new int[] {100, 122, 40},
                },
                new int[][] {
                    new int[] {36, 114, -51},
                    new int[] {115, 115, 106},
                    new int[] {116, 122, 40},
                },
                new int[][] {
                    new int[] {36, 114, -51},
                    new int[] {115, 115, 107},
                    new int[] {116, 122, 40},
                },
                new int[][] {
                    new int[] {36, 98, -101},
                    new int[] {99, 99, 108},
                    new int[] {100, 122, 40},
                },
                new int[][] {
                    new int[] {36, 114, -51},
                    new int[] {115, 115, 109},
                    new int[] {116, 122, 40},
                },
                new int[][] {
                    new int[] {36, 99, -77},
                    new int[] {100, 100, 110},
                    new int[] {101, 122, 40},
                },
                new int[][] {
                    new int[] {36, 115, -28},
                    new int[] {116, 116, 111},
                    new int[] {117, 122, 40},
                },
                new int[][] {
                    new int[] {36, 122, -7},
                },
                new int[][] {
                    new int[] {36, 122, -7},
                },
                new int[][] {
                    new int[] {36, 115, -28},
                    new int[] {116, 116, 112},
                    new int[] {117, 122, 40},
                },
                new int[][] {
                    new int[] {36, 122, -7},
                },
                new int[][] {
                    new int[] {36, 122, -7},
                },
                new int[][] {
                    new int[] {36, 95, -7},
                    new int[] {97, 104, 40},
                    new int[] {105, 105, 113},
                    new int[] {106, 122, 40},
                },
                new int[][] {
                    new int[] {9, 9, 114},
                    new int[] {32, 32, 115},
                    new int[] {36, 122, -7},
                },
                new int[][] {
                    new int[] {36, 110, -29},
                    new int[] {111, 111, 116},
                    new int[] {112, 122, 40},
                },
                new int[][] {
                    new int[] {9, 32, -114},
                    new int[] {83, 83, 117},
                },
                new int[][] {
                    new int[] {9, 83, -116},
                },
                new int[][] {
                    new int[] {36, 109, -53},
                    new int[] {110, 110, 118},
                    new int[] {111, 122, 40},
                },
                new int[][] {
                    new int[] {121, 121, 119},
                },
                new int[][] {
                    new int[] {36, 114, -51},
                    new int[] {115, 115, 120},
                    new int[] {116, 122, 40},
                },
                new int[][] {
                    new int[] {110, 110, 121},
                },
                new int[][] {
                    new int[] {36, 122, -7},
                },
                new int[][] {
                    new int[] {116, 116, 122},
                },
                new int[][] {
                    new int[] {97, 97, 123},
                },
                new int[][] {
                    new int[] {120, 120, 124},
                },
                new int[][] {
                    new int[] {9, 9, 125},
                    new int[] {32, 32, 126},
                },
                new int[][] {
                    new int[] {9, 32, -126},
                    new int[] {84, 84, 127},
                },
                new int[][] {
                    new int[] {9, 84, -127},
                },
                new int[][] {
                    new int[] {114, 114, 128},
                },
                new int[][] {
                    new int[] {101, 101, 129},
                },
                new int[][] {
                    new int[] {101, 101, 130},
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
                    new int[] {101, 101, 43},
                    new int[] {117, 117, 44},
                },
                new int[][] {
                    new int[] {114, 114, 45},
                },
                new int[][] {
                    new int[] {116, 116, 46},
                },
                new int[][] {
                    new int[] {111, 111, 47},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {48, 57, 48},
                    new int[] {95, 95, 49},
                    new int[] {97, 122, 50},
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
                    new int[] {10, 10, 57},
                    new int[] {11, 12, 56},
                    new int[] {13, 13, 58},
                    new int[] {14, 65535, 56},
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
                    new int[] {40, 65535, 51},
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
                    new int[] {42, 42, 55},
                    new int[] {43, 46, 70},
                    new int[] {47, 47, 71},
                    new int[] {48, 65535, 70},
                },
                new int[][] {
                    new int[] {0, 65535, -39},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {10, 10, 72},
                },
                new int[][] {
                    new int[] {48, 102, -40},
                },
                new int[][] {
                    new int[] {116, 116, 73},
                },
                new int[][] {
                    new int[] {112, 112, 74},
                },
                new int[][] {
                    new int[] {111, 111, 75},
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
                    new int[] {95, 95, 49},
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
                },
                new int[][] {
                    new int[] {117, 117, 87},
                },
                new int[][] {
                    new int[] {101, 101, 88},
                },
                new int[][] {
                    new int[] {110, 110, 89},
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
                    new int[] {43, 65535, -57},
                },
                new int[][] {
                    new int[] {97, 97, 90},
                },
                new int[][] {
                    new int[] {114, 114, 91},
                },
                new int[][] {
                    new int[] {101, 101, 92},
                },
                new int[][] {
                    new int[] {99, 99, 93},
                },
                new int[][] {
                    new int[] {115, 115, 94},
                },
                new int[][] {
                    new int[] {115, 115, 95},
                },
                new int[][] {
                    new int[] {99, 99, 96},
                },
                new int[][] {
                    new int[] {115, 115, 97},
                },
                new int[][] {
                    new int[] {100, 100, 98},
                },
                new int[][] {
                    new int[] {116, 116, 99},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {116, 116, 100},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {105, 105, 101},
                },
                new int[][] {
                    new int[] {9, 9, 102},
                    new int[] {32, 32, 103},
                },
                new int[][] {
                    new int[] {111, 111, 104},
                },
                new int[][] {
                    new int[] {9, 32, -102},
                    new int[] {83, 83, 105},
                },
                new int[][] {
                    new int[] {9, 83, -104},
                },
                new int[][] {
                    new int[] {110, 110, 106},
                },
                new int[][] {
                    new int[] {121, 121, 107},
                },
                new int[][] {
                    new int[] {115, 115, 108},
                },
                new int[][] {
                    new int[] {110, 110, 109},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {116, 116, 110},
                },
                new int[][] {
                    new int[] {97, 97, 111},
                },
                new int[][] {
                    new int[] {120, 120, 112},
                },
                new int[][] {
                    new int[] {9, 9, 113},
                    new int[] {32, 32, 114},
                },
                new int[][] {
                    new int[] {9, 32, -114},
                    new int[] {84, 84, 115},
                },
                new int[][] {
                    new int[] {9, 84, -115},
                },
                new int[][] {
                    new int[] {114, 114, 116},
                },
                new int[][] {
                    new int[] {101, 101, 117},
                },
                new int[][] {
                    new int[] {101, 101, 118},
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
                    new int[] {65, 65, 21},
                    new int[] {72, 72, 22},
                    new int[] {73, 73, 23},
                    new int[] {78, 78, 24},
                    new int[] {80, 80, 25},
                    new int[] {83, 83, 26},
                    new int[] {84, 84, 27},
                    new int[] {91, 91, 28},
                    new int[] {93, 93, 29},
                    new int[] {98, 98, 30},
                    new int[] {104, 104, 31},
                    new int[] {105, 105, 32},
                    new int[] {114, 114, 33},
                    new int[] {116, 116, 34},
                    new int[] {123, 123, 35},
                    new int[] {124, 124, 36},
                },
                new int[][] {
                    new int[] {9, 32, -2},
                },
                new int[][] {
                    new int[] {9, 32, -2},
                },
                new int[][] {
                    new int[] {9, 9, 1},
                    new int[] {10, 10, 37},
                    new int[] {13, 32, -2},
                },
                new int[][] {
                    new int[] {9, 32, -2},
                },
                new int[][] {
                    new int[] {48, 57, 38},
                    new int[] {65, 70, 38},
                    new int[] {97, 102, 38},
                },
                new int[][] {
                    new int[] {0, 9, 39},
                    new int[] {11, 12, 39},
                    new int[] {14, 38, 39},
                    new int[] {39, 39, 40},
                    new int[] {40, 65535, 39},
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
                    new int[] {62, 62, 41},
                },
                new int[][] {
                    new int[] {46, 46, 42},
                },
                new int[][] {
                    new int[] {42, 42, 43},
                    new int[] {47, 47, 44},
                },
                new int[][] {
                    new int[] {48, 57, 16},
                    new int[] {88, 88, 45},
                    new int[] {120, 120, 46},
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
                    new int[] {98, 98, 47},
                },
                new int[][] {
                    new int[] {101, 101, 48},
                },
                new int[][] {
                    new int[] {103, 103, 49},
                },
                new int[][] {
                    new int[] {101, 101, 50},
                    new int[] {117, 117, 51},
                },
                new int[][] {
                    new int[] {114, 114, 52},
                },
                new int[][] {
                    new int[] {116, 116, 53},
                },
                new int[][] {
                    new int[] {111, 111, 54},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {97, 97, 55},
                    new int[] {111, 111, 56},
                },
                new int[][] {
                    new int[] {115, 115, 57},
                },
                new int[][] {
                    new int[] {116, 116, 58},
                },
                new int[][] {
                    new int[] {103, 103, 59},
                },
                new int[][] {
                    new int[] {101, 101, 60},
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
                    new int[] {0, 9, 61},
                    new int[] {11, 12, 61},
                    new int[] {14, 38, 61},
                    new int[] {39, 39, 62},
                    new int[] {40, 65535, 61},
                },
                new int[][] {
                    new int[] {39, 39, 63},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {0, 41, 64},
                    new int[] {42, 42, 65},
                    new int[] {43, 65535, 64},
                },
                new int[][] {
                    new int[] {0, 9, 66},
                    new int[] {10, 10, 67},
                    new int[] {11, 12, 66},
                    new int[] {13, 13, 68},
                    new int[] {14, 65535, 66},
                },
                new int[][] {
                    new int[] {48, 57, 69},
                    new int[] {65, 70, 69},
                    new int[] {97, 102, 69},
                },
                new int[][] {
                    new int[] {48, 102, -47},
                },
                new int[][] {
                    new int[] {115, 115, 70},
                },
                new int[][] {
                    new int[] {108, 108, 71},
                },
                new int[][] {
                    new int[] {110, 110, 72},
                },
                new int[][] {
                    new int[] {119, 119, 73},
                },
                new int[][] {
                    new int[] {108, 108, 74},
                },
                new int[][] {
                    new int[] {111, 111, 75},
                },
                new int[][] {
                    new int[] {97, 97, 76},
                },
                new int[][] {
                    new int[] {107, 107, 77},
                },
                new int[][] {
                    new int[] {99, 99, 78},
                },
                new int[][] {
                    new int[] {108, 108, 79},
                },
                new int[][] {
                    new int[] {98, 98, 80},
                    new int[] {118, 118, 81},
                },
                new int[][] {
                    new int[] {97, 97, 82},
                },
                new int[][] {
                    new int[] {98, 98, 83},
                },
                new int[][] {
                    new int[] {120, 120, 84},
                },
                new int[][] {
                    new int[] {0, 38, -41},
                    new int[] {39, 39, 85},
                    new int[] {40, 65535, 61},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {0, 65535, -45},
                },
                new int[][] {
                    new int[] {0, 41, 86},
                    new int[] {42, 42, 65},
                    new int[] {43, 46, 86},
                    new int[] {47, 47, 87},
                    new int[] {48, 65535, 86},
                },
                new int[][] {
                    new int[] {0, 65535, -46},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {10, 10, 88},
                },
                new int[][] {
                    new int[] {48, 102, -47},
                },
                new int[][] {
                    new int[] {116, 116, 89},
                },
                new int[][] {
                    new int[] {112, 112, 90},
                },
                new int[][] {
                    new int[] {111, 111, 91},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {108, 108, 92},
                },
                new int[][] {
                    new int[] {100, 100, 93},
                },
                new int[][] {
                    new int[] {116, 116, 94},
                },
                new int[][] {
                    new int[] {101, 101, 95},
                },
                new int[][] {
                    new int[] {107, 107, 96},
                },
                new int[][] {
                    new int[] {100, 100, 97},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {108, 108, 98},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {116, 116, 99},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {0, 41, 100},
                    new int[] {42, 42, 101},
                    new int[] {43, 65535, 100},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {114, 114, 102},
                },
                new int[][] {
                    new int[] {101, 101, 103},
                },
                new int[][] {
                    new int[] {114, 114, 104},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {117, 117, 105},
                },
                new int[][] {
                    new int[] {101, 101, 106},
                },
                new int[][] {
                    new int[] {110, 110, 107},
                },
                new int[][] {
                    new int[] {103, 103, 108},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {105, 105, 109},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {0, 65535, -88},
                },
                new int[][] {
                    new int[] {0, 41, 86},
                    new int[] {42, 42, 101},
                    new int[] {43, 65535, -67},
                },
                new int[][] {
                    new int[] {97, 97, 110},
                },
                new int[][] {
                    new int[] {114, 114, 111},
                },
                new int[][] {
                    new int[] {101, 101, 112},
                },
                new int[][] {
                    new int[] {99, 99, 113},
                },
                new int[][] {
                    new int[] {115, 115, 114},
                },
                new int[][] {
                    new int[] {115, 115, 115},
                },
                new int[][] {
                    new int[] {114, 114, 116},
                },
                new int[][] {
                    new int[] {99, 99, 117},
                },
                new int[][] {
                    new int[] {99, 99, 118},
                },
                new int[][] {
                    new int[] {115, 115, 119},
                },
                new int[][] {
                    new int[] {100, 100, 120},
                },
                new int[][] {
                    new int[] {116, 116, 121},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {111, 111, 122},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {116, 116, 123},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {105, 105, 124},
                },
                new int[][] {
                    new int[] {117, 117, 125},
                },
                new int[][] {
                    new int[] {9, 9, 126},
                    new int[] {32, 32, 127},
                },
                new int[][] {
                    new int[] {111, 111, 128},
                },
                new int[][] {
                    new int[] {110, 110, 129},
                },
                new int[][] {
                    new int[] {9, 32, -125},
                    new int[] {83, 83, 130},
                },
                new int[][] {
                    new int[] {9, 83, -128},
                },
                new int[][] {
                    new int[] {110, 110, 131},
                },
                new int[][] {
                    new int[] {100, 100, 132},
                },
                new int[][] {
                    new int[] {121, 121, 133},
                },
                new int[][] {
                    new int[] {115, 115, 134},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {110, 110, 135},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {116, 116, 136},
                },
                new int[][] {
                    new int[] {97, 97, 137},
                },
                new int[][] {
                    new int[] {120, 120, 138},
                },
                new int[][] {
                    new int[] {9, 9, 139},
                    new int[] {32, 32, 140},
                },
                new int[][] {
                    new int[] {9, 32, -140},
                    new int[] {84, 84, 141},
                },
                new int[][] {
                    new int[] {9, 84, -141},
                },
                new int[][] {
                    new int[] {114, 114, 142},
                },
                new int[][] {
                    new int[] {101, 101, 143},
                },
                new int[][] {
                    new int[] {101, 101, 144},
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
                22, 37, -1, -1, 30, 14, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
                -1, -1, -1, -1, 32, -1, 32, -1, 33, 33, -1, -1, -1, 38, 38, 35,
                -1, -1, -1, -1, 9, -1, -1, -1, -1, -1, 32, 36, -1, 38, 38, -1,
                -1, -1, -1, 10, -1, -1, -1, -1, 32, 32, -1, -1, -1, -1, -1, -1,
                -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 2, -1, 4, -1, 3, 5,
                -1, 1, -1, -1, -1, -1, -1, -1, -1, -1, 1, -1, -1, -1, -1, -1,
                -1, 6, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
                -1, -1, -1, -1, 7, -1, -1, 8,
            },
            new int[] {
                -1, 37, 37, 37, 37, 0, -1, 19, 20, 26, 23, 28, 24, 13, 29, -1,
                31, 15, 16, 25, 0, 0, 0, 0, 0, 0, 0, 0, 17, 18, 0, 0,
                21, 27, 37, 0, -1, 0, 0, 0, 0, -1, -1, 30, 14, -1, -1, -1,
                -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 33, 33,
                -1, -1, -1, 38, 38, 35, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 36, -1, 38, 38, 0, 0, 0, 0, 0, 0, 0, -1, -1,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, -1, -1, 0, -1, 0, -1, 0, -1, -1, -1, -1, -1, -1, -1,
                -1, -1, 7,
            },
            new int[] {
                -1, 37, 37, 37, 37, -1, 19, 20, 26, 23, 28, 24, 13, 29, -1, 31,
                16, 25, -1, -1, -1, -1, 12, -1, 11, 17, 18, 32, 21, 27, 22, 37,
                -1, -1, 30, 14, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
                32, -1, 32, -1, 33, 33, -1, -1, -1, 38, 38, 35, -1, -1, -1, 9,
                -1, -1, -1, -1, 32, 36, -1, 38, 38, -1, -1, -1, 10, -1, -1, -1,
                32, 32, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 2, 4,
                -1, 3, 5, -1, -1, -1, -1, -1, -1, -1, -1, -1, 6, -1, -1, -1,
                -1, -1, -1, -1, -1, -1, 7,
            },
            new int[] {
                -1, 37, 37, 37, 37, -1, -1, 19, 20, 26, 23, 28, 24, 13, 29, 34,
                34, 31, 15, 16, 25, -1, -1, -1, -1, 12, -1, 11, 17, 18, -1, -1,
                -1, -1, -1, 21, 27, 37, 45, -1, -1, 30, 14, -1, -1, -1, -1, -1,
                -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 33, 33,
                -1, -1, -1, 38, 38, 35, -1, -1, -1, 9, -1, -1, -1, -1, -1, -1,
                44, 44, -1, 43, -1, 36, -1, 38, 38, -1, -1, -1, 10, -1, -1, -1,
                -1, 40, -1, 41, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
                -1, -1, 2, 4, -1, 39, -1, 3, 5, -1, -1, -1, -1, -1, -1, -1,
                -1, -1, -1, -1, 42, -1, 6, -1, -1, -1, -1, -1, -1, -1, -1, -1,
                7,
            },
        };
        
        #endregion
    }
}
