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
                    new int[] {11, 12, 66},
                    new int[] {14, 65535, 66},
                },
                new int[][] {
                    new int[] {48, 57, 67},
                    new int[] {65, 70, 67},
                    new int[] {97, 102, 67},
                },
                new int[][] {
                    new int[] {48, 102, -49},
                },
                new int[][] {
                    new int[] {36, 95, -7},
                    new int[] {97, 114, 40},
                    new int[] {115, 115, 68},
                    new int[] {116, 122, 40},
                },
                new int[][] {
                    new int[] {36, 95, -7},
                    new int[] {97, 107, 40},
                    new int[] {108, 108, 69},
                    new int[] {109, 122, 40},
                },
                new int[][] {
                    new int[] {36, 95, -7},
                    new int[] {97, 109, 40},
                    new int[] {110, 110, 70},
                    new int[] {111, 122, 40},
                },
                new int[][] {
                    new int[] {36, 95, -7},
                    new int[] {97, 118, 40},
                    new int[] {119, 119, 71},
                    new int[] {120, 122, 40},
                },
                new int[][] {
                    new int[] {36, 107, -52},
                    new int[] {108, 108, 72},
                    new int[] {109, 122, 40},
                },
                new int[][] {
                    new int[] {36, 110, -29},
                    new int[] {111, 111, 73},
                    new int[] {112, 122, 40},
                },
                new int[][] {
                    new int[] {36, 95, -7},
                    new int[] {97, 97, 74},
                    new int[] {98, 122, 40},
                },
                new int[][] {
                    new int[] {36, 95, -7},
                    new int[] {97, 106, 40},
                    new int[] {107, 107, 75},
                    new int[] {108, 122, 40},
                },
                new int[][] {
                    new int[] {36, 36, 76},
                    new int[] {46, 46, 36},
                    new int[] {48, 57, 77},
                    new int[] {65, 90, 78},
                    new int[] {95, 95, 79},
                    new int[] {97, 122, 80},
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
                    new int[] {39, 39, 81},
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
                    new int[] {0, 41, 82},
                    new int[] {42, 42, 65},
                    new int[] {43, 46, 82},
                    new int[] {47, 47, 83},
                    new int[] {48, 65535, 82},
                },
                new int[][] {
                    new int[] {0, 65535, -48},
                },
                new int[][] {
                    new int[] {48, 102, -49},
                },
                new int[][] {
                    new int[] {36, 115, -28},
                    new int[] {116, 116, 84},
                    new int[] {117, 122, 40},
                },
                new int[][] {
                    new int[] {36, 95, -7},
                    new int[] {97, 111, 40},
                    new int[] {112, 112, 85},
                    new int[] {113, 122, 40},
                },
                new int[][] {
                    new int[] {36, 110, -29},
                    new int[] {111, 111, 86},
                    new int[] {112, 122, 40},
                },
                new int[][] {
                    new int[] {36, 122, -7},
                },
                new int[][] {
                    new int[] {36, 107, -52},
                    new int[] {108, 108, 87},
                    new int[] {109, 122, 40},
                },
                new int[][] {
                    new int[] {36, 95, -7},
                    new int[] {97, 99, 40},
                    new int[] {100, 100, 88},
                    new int[] {101, 122, 40},
                },
                new int[][] {
                    new int[] {36, 115, -28},
                    new int[] {116, 116, 89},
                    new int[] {117, 122, 40},
                },
                new int[][] {
                    new int[] {36, 100, -24},
                    new int[] {101, 101, 90},
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
                    new int[] {0, 41, 91},
                    new int[] {42, 42, 92},
                    new int[] {43, 65535, 91},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {36, 113, -27},
                    new int[] {114, 114, 93},
                    new int[] {115, 122, 40},
                },
                new int[][] {
                    new int[] {36, 100, -24},
                    new int[] {101, 101, 94},
                    new int[] {102, 122, 40},
                },
                new int[][] {
                    new int[] {36, 113, -27},
                    new int[] {114, 114, 95},
                    new int[] {115, 122, 40},
                },
                new int[][] {
                    new int[] {36, 122, -7},
                },
                new int[][] {
                    new int[] {36, 95, -7},
                    new int[] {97, 116, 40},
                    new int[] {117, 117, 96},
                    new int[] {118, 122, 40},
                },
                new int[][] {
                    new int[] {36, 100, -24},
                    new int[] {101, 101, 97},
                    new int[] {102, 122, 40},
                },
                new int[][] {
                    new int[] {36, 109, -53},
                    new int[] {110, 110, 98},
                    new int[] {111, 122, 40},
                },
                new int[][] {
                    new int[] {0, 65535, -84},
                },
                new int[][] {
                    new int[] {0, 41, 82},
                    new int[] {42, 42, 92},
                    new int[] {43, 65535, -67},
                },
                new int[][] {
                    new int[] {36, 95, -7},
                    new int[] {97, 97, 99},
                    new int[] {98, 122, 40},
                },
                new int[][] {
                    new int[] {36, 113, -27},
                    new int[] {114, 114, 100},
                    new int[] {115, 122, 40},
                },
                new int[][] {
                    new int[] {36, 100, -24},
                    new int[] {101, 101, 101},
                    new int[] {102, 122, 40},
                },
                new int[][] {
                    new int[] {36, 95, -7},
                    new int[] {97, 98, 40},
                    new int[] {99, 99, 102},
                    new int[] {100, 122, 40},
                },
                new int[][] {
                    new int[] {36, 114, -51},
                    new int[] {115, 115, 103},
                    new int[] {116, 122, 40},
                },
                new int[][] {
                    new int[] {36, 114, -51},
                    new int[] {115, 115, 104},
                    new int[] {116, 122, 40},
                },
                new int[][] {
                    new int[] {36, 98, -98},
                    new int[] {99, 99, 105},
                    new int[] {100, 122, 40},
                },
                new int[][] {
                    new int[] {36, 114, -51},
                    new int[] {115, 115, 106},
                    new int[] {116, 122, 40},
                },
                new int[][] {
                    new int[] {36, 99, -75},
                    new int[] {100, 100, 107},
                    new int[] {101, 122, 40},
                },
                new int[][] {
                    new int[] {36, 115, -28},
                    new int[] {116, 116, 108},
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
                    new int[] {116, 116, 109},
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
                    new int[] {105, 105, 110},
                    new int[] {106, 122, 40},
                },
                new int[][] {
                    new int[] {9, 9, 111},
                    new int[] {32, 32, 112},
                    new int[] {36, 122, -7},
                },
                new int[][] {
                    new int[] {36, 110, -29},
                    new int[] {111, 111, 113},
                    new int[] {112, 122, 40},
                },
                new int[][] {
                    new int[] {9, 32, -111},
                    new int[] {83, 83, 114},
                },
                new int[][] {
                    new int[] {9, 83, -113},
                },
                new int[][] {
                    new int[] {36, 109, -53},
                    new int[] {110, 110, 115},
                    new int[] {111, 122, 40},
                },
                new int[][] {
                    new int[] {121, 121, 116},
                },
                new int[][] {
                    new int[] {36, 114, -51},
                    new int[] {115, 115, 117},
                    new int[] {116, 122, 40},
                },
                new int[][] {
                    new int[] {110, 110, 118},
                },
                new int[][] {
                    new int[] {36, 122, -7},
                },
                new int[][] {
                    new int[] {116, 116, 119},
                },
                new int[][] {
                    new int[] {97, 97, 120},
                },
                new int[][] {
                    new int[] {120, 120, 121},
                },
                new int[][] {
                    new int[] {9, 9, 122},
                    new int[] {32, 32, 123},
                },
                new int[][] {
                    new int[] {9, 32, -123},
                    new int[] {84, 84, 124},
                },
                new int[][] {
                    new int[] {9, 84, -124},
                },
                new int[][] {
                    new int[] {114, 114, 125},
                },
                new int[][] {
                    new int[] {101, 101, 126},
                },
                new int[][] {
                    new int[] {101, 101, 127},
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
                    new int[] {11, 12, 56},
                    new int[] {14, 65535, 56},
                },
                new int[][] {
                    new int[] {48, 57, 57},
                    new int[] {65, 70, 57},
                    new int[] {97, 102, 57},
                },
                new int[][] {
                    new int[] {48, 102, -40},
                },
                new int[][] {
                    new int[] {115, 115, 58},
                },
                new int[][] {
                    new int[] {108, 108, 59},
                },
                new int[][] {
                    new int[] {110, 110, 60},
                },
                new int[][] {
                    new int[] {119, 119, 61},
                },
                new int[][] {
                    new int[] {108, 108, 62},
                },
                new int[][] {
                    new int[] {111, 111, 63},
                },
                new int[][] {
                    new int[] {97, 97, 64},
                },
                new int[][] {
                    new int[] {107, 107, 65},
                },
                new int[][] {
                    new int[] {48, 122, -29},
                },
                new int[][] {
                    new int[] {97, 122, 66},
                },
                new int[][] {
                    new int[] {48, 122, -29},
                },
                new int[][] {
                    new int[] {0, 38, -34},
                    new int[] {39, 39, 67},
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
                    new int[] {0, 41, 68},
                    new int[] {42, 42, 55},
                    new int[] {43, 46, 68},
                    new int[] {47, 47, 69},
                    new int[] {48, 65535, 68},
                },
                new int[][] {
                    new int[] {0, 65535, -39},
                },
                new int[][] {
                    new int[] {48, 102, -40},
                },
                new int[][] {
                    new int[] {116, 116, 70},
                },
                new int[][] {
                    new int[] {112, 112, 71},
                },
                new int[][] {
                    new int[] {111, 111, 72},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {108, 108, 73},
                },
                new int[][] {
                    new int[] {100, 100, 74},
                },
                new int[][] {
                    new int[] {116, 116, 75},
                },
                new int[][] {
                    new int[] {101, 101, 76},
                },
                new int[][] {
                    new int[] {48, 57, 77},
                    new int[] {95, 95, 49},
                    new int[] {97, 122, 78},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {0, 41, 79},
                    new int[] {42, 42, 80},
                    new int[] {43, 65535, 79},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {114, 114, 81},
                },
                new int[][] {
                    new int[] {101, 101, 82},
                },
                new int[][] {
                    new int[] {114, 114, 83},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {117, 117, 84},
                },
                new int[][] {
                    new int[] {101, 101, 85},
                },
                new int[][] {
                    new int[] {110, 110, 86},
                },
                new int[][] {
                    new int[] {48, 122, -68},
                },
                new int[][] {
                    new int[] {48, 122, -68},
                },
                new int[][] {
                    new int[] {0, 65535, -70},
                },
                new int[][] {
                    new int[] {0, 41, 68},
                    new int[] {42, 42, 80},
                    new int[] {43, 65535, -57},
                },
                new int[][] {
                    new int[] {97, 97, 87},
                },
                new int[][] {
                    new int[] {114, 114, 88},
                },
                new int[][] {
                    new int[] {101, 101, 89},
                },
                new int[][] {
                    new int[] {99, 99, 90},
                },
                new int[][] {
                    new int[] {115, 115, 91},
                },
                new int[][] {
                    new int[] {115, 115, 92},
                },
                new int[][] {
                    new int[] {99, 99, 93},
                },
                new int[][] {
                    new int[] {115, 115, 94},
                },
                new int[][] {
                    new int[] {100, 100, 95},
                },
                new int[][] {
                    new int[] {116, 116, 96},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {116, 116, 97},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {105, 105, 98},
                },
                new int[][] {
                    new int[] {9, 9, 99},
                    new int[] {32, 32, 100},
                },
                new int[][] {
                    new int[] {111, 111, 101},
                },
                new int[][] {
                    new int[] {9, 32, -99},
                    new int[] {83, 83, 102},
                },
                new int[][] {
                    new int[] {9, 83, -101},
                },
                new int[][] {
                    new int[] {110, 110, 103},
                },
                new int[][] {
                    new int[] {121, 121, 104},
                },
                new int[][] {
                    new int[] {115, 115, 105},
                },
                new int[][] {
                    new int[] {110, 110, 106},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {116, 116, 107},
                },
                new int[][] {
                    new int[] {97, 97, 108},
                },
                new int[][] {
                    new int[] {120, 120, 109},
                },
                new int[][] {
                    new int[] {9, 9, 110},
                    new int[] {32, 32, 111},
                },
                new int[][] {
                    new int[] {9, 32, -111},
                    new int[] {84, 84, 112},
                },
                new int[][] {
                    new int[] {9, 84, -112},
                },
                new int[][] {
                    new int[] {114, 114, 113},
                },
                new int[][] {
                    new int[] {101, 101, 114},
                },
                new int[][] {
                    new int[] {101, 101, 115},
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
                    new int[] {11, 12, 66},
                    new int[] {14, 65535, 66},
                },
                new int[][] {
                    new int[] {48, 57, 67},
                    new int[] {65, 70, 67},
                    new int[] {97, 102, 67},
                },
                new int[][] {
                    new int[] {48, 102, -47},
                },
                new int[][] {
                    new int[] {115, 115, 68},
                },
                new int[][] {
                    new int[] {108, 108, 69},
                },
                new int[][] {
                    new int[] {110, 110, 70},
                },
                new int[][] {
                    new int[] {119, 119, 71},
                },
                new int[][] {
                    new int[] {108, 108, 72},
                },
                new int[][] {
                    new int[] {111, 111, 73},
                },
                new int[][] {
                    new int[] {97, 97, 74},
                },
                new int[][] {
                    new int[] {107, 107, 75},
                },
                new int[][] {
                    new int[] {99, 99, 76},
                },
                new int[][] {
                    new int[] {108, 108, 77},
                },
                new int[][] {
                    new int[] {98, 98, 78},
                    new int[] {118, 118, 79},
                },
                new int[][] {
                    new int[] {97, 97, 80},
                },
                new int[][] {
                    new int[] {98, 98, 81},
                },
                new int[][] {
                    new int[] {120, 120, 82},
                },
                new int[][] {
                    new int[] {0, 38, -41},
                    new int[] {39, 39, 83},
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
                    new int[] {0, 41, 84},
                    new int[] {42, 42, 65},
                    new int[] {43, 46, 84},
                    new int[] {47, 47, 85},
                    new int[] {48, 65535, 84},
                },
                new int[][] {
                    new int[] {0, 65535, -46},
                },
                new int[][] {
                    new int[] {48, 102, -47},
                },
                new int[][] {
                    new int[] {116, 116, 86},
                },
                new int[][] {
                    new int[] {112, 112, 87},
                },
                new int[][] {
                    new int[] {111, 111, 88},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {108, 108, 89},
                },
                new int[][] {
                    new int[] {100, 100, 90},
                },
                new int[][] {
                    new int[] {116, 116, 91},
                },
                new int[][] {
                    new int[] {101, 101, 92},
                },
                new int[][] {
                    new int[] {107, 107, 93},
                },
                new int[][] {
                    new int[] {100, 100, 94},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {108, 108, 95},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {116, 116, 96},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {0, 41, 97},
                    new int[] {42, 42, 98},
                    new int[] {43, 65535, 97},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {114, 114, 99},
                },
                new int[][] {
                    new int[] {101, 101, 100},
                },
                new int[][] {
                    new int[] {114, 114, 101},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {117, 117, 102},
                },
                new int[][] {
                    new int[] {101, 101, 103},
                },
                new int[][] {
                    new int[] {110, 110, 104},
                },
                new int[][] {
                    new int[] {103, 103, 105},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {105, 105, 106},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {0, 65535, -86},
                },
                new int[][] {
                    new int[] {0, 41, 84},
                    new int[] {42, 42, 98},
                    new int[] {43, 65535, -67},
                },
                new int[][] {
                    new int[] {97, 97, 107},
                },
                new int[][] {
                    new int[] {114, 114, 108},
                },
                new int[][] {
                    new int[] {101, 101, 109},
                },
                new int[][] {
                    new int[] {99, 99, 110},
                },
                new int[][] {
                    new int[] {115, 115, 111},
                },
                new int[][] {
                    new int[] {115, 115, 112},
                },
                new int[][] {
                    new int[] {114, 114, 113},
                },
                new int[][] {
                    new int[] {99, 99, 114},
                },
                new int[][] {
                    new int[] {99, 99, 115},
                },
                new int[][] {
                    new int[] {115, 115, 116},
                },
                new int[][] {
                    new int[] {100, 100, 117},
                },
                new int[][] {
                    new int[] {116, 116, 118},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {111, 111, 119},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {116, 116, 120},
                },
                new int[][] {
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {105, 105, 121},
                },
                new int[][] {
                    new int[] {117, 117, 122},
                },
                new int[][] {
                    new int[] {9, 9, 123},
                    new int[] {32, 32, 124},
                },
                new int[][] {
                    new int[] {111, 111, 125},
                },
                new int[][] {
                    new int[] {110, 110, 126},
                },
                new int[][] {
                    new int[] {9, 32, -122},
                    new int[] {83, 83, 127},
                },
                new int[][] {
                    new int[] {9, 83, -125},
                },
                new int[][] {
                    new int[] {110, 110, 128},
                },
                new int[][] {
                    new int[] {100, 100, 129},
                },
                new int[][] {
                    new int[] {121, 121, 130},
                },
                new int[][] {
                    new int[] {115, 115, 131},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {110, 110, 132},
                },
                new int[][] {
                },
                new int[][] {
                    new int[] {116, 116, 133},
                },
                new int[][] {
                    new int[] {97, 97, 134},
                },
                new int[][] {
                    new int[] {120, 120, 135},
                },
                new int[][] {
                    new int[] {9, 9, 136},
                    new int[] {32, 32, 137},
                },
                new int[][] {
                    new int[] {9, 32, -137},
                    new int[] {84, 84, 138},
                },
                new int[][] {
                    new int[] {9, 84, -138},
                },
                new int[][] {
                    new int[] {114, 114, 139},
                },
                new int[][] {
                    new int[] {101, 101, 140},
                },
                new int[][] {
                    new int[] {101, 101, 141},
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
                31, 15, 16, 25, 0, 0, 0, 0, 0, 0, 0, 0, 17, 18, 0, 0,
                21, 27, 37, 0, -1, 0, 0, 0, 0, -1, -1, 30, 14, -1, 38, -1,
                -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 33, 33,
                -1, -1, 38, 35, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 36, -1, 38, 0, 0, 0, 0, 0, 0, 0, -1, -1, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1,
                -1, 0, -1, 0, -1, 0, -1, -1, -1, -1, -1, -1, -1, -1, -1, 7,
            },
            new int[] {
                -1, 37, 37, 37, 37, -1, 19, 20, 26, 23, 28, 24, 13, 29, -1, 31,
                16, 25, -1, -1, -1, -1, 12, -1, 11, 17, 18, 32, 21, 27, 22, 37,
                -1, -1, 30, 14, -1, 38, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
                32, -1, 32, -1, 33, 33, -1, -1, 38, 35, -1, -1, -1, 9, -1, -1,
                -1, -1, 32, 36, -1, 38, -1, -1, -1, 10, -1, -1, -1, 32, 32, -1,
                -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 2, 4, -1, 3, 5,
                -1, -1, -1, -1, -1, -1, -1, -1, -1, 6, -1, -1, -1, -1, -1, -1,
                -1, -1, -1, 7,
            },
            new int[] {
                -1, 37, 37, 37, 37, -1, -1, 19, 20, 26, 23, 28, 24, 13, 29, 34,
                34, 31, 15, 16, 25, -1, -1, -1, -1, 12, -1, 11, 17, 18, -1, -1,
                -1, -1, -1, 21, 27, 37, 45, -1, -1, 30, 14, -1, 38, -1, -1, -1,
                -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 33, 33,
                -1, -1, 38, 35, -1, -1, -1, 9, -1, -1, -1, -1, -1, -1, 44, 44,
                -1, 43, -1, 36, -1, 38, -1, -1, -1, 10, -1, -1, -1, -1, 40, -1,
                41, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 2,
                4, -1, 39, -1, 3, 5, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
                -1, 42, -1, 6, -1, -1, -1, -1, -1, -1, -1, -1, -1, 7,
            },
        };
        
        
        #endregion
        
    }
}
