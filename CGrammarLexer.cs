//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from c://Users//Mateusz//Documents//studia//kompilatory//Konwerter-C--Python//CGrammar.g4 by ANTLR 4.13.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.CLSCompliant(false)]
public partial class CGrammarLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		Include=1, If=2, Else=3, For=4, While=5, Do=6, Continue=7, Break=8, Return=9, 
		Const=10, Struct=11, Char=12, Short=13, Int=14, Long=15, Float=16, Double=17, 
		Void=18, IncludeLiteral=19, Identifier=20, CharLiteral=21, StringLiteral=22, 
		IntLiteral=23, FloatLiteral=24, Access=25, AccessPointer=26, Address=27, 
		Assign=28, AssignAdd=29, AssignSubtract=30, AssignMultiply=31, AssignDivide=32, 
		AssignModulo=33, Add=34, Subtract=35, Multiply=36, Divide=37, Modulo=38, 
		Equal=39, NotEqual=40, Less=41, LessOrEqual=42, Greater=43, GreaterOrEqual=44, 
		And=45, Or=46, Not=47, LeftRound=48, RightRound=49, LeftSquare=50, RightSquare=51, 
		LeftCurly=52, RightCurly=53, Semicolon=54, Colon=55, Comma=56, Whitespace=57;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"Include", "If", "Else", "For", "While", "Do", "Continue", "Break", "Return", 
		"Const", "Struct", "Char", "Short", "Int", "Long", "Float", "Double", 
		"Void", "IncludeLiteral", "Identifier", "CharLiteral", "StringLiteral", 
		"IntLiteral", "FloatLiteral", "Access", "AccessPointer", "Address", "Assign", 
		"AssignAdd", "AssignSubtract", "AssignMultiply", "AssignDivide", "AssignModulo", 
		"Add", "Subtract", "Multiply", "Divide", "Modulo", "Equal", "NotEqual", 
		"Less", "LessOrEqual", "Greater", "GreaterOrEqual", "And", "Or", "Not", 
		"LeftRound", "RightRound", "LeftSquare", "RightSquare", "LeftCurly", "RightCurly", 
		"Semicolon", "Colon", "Comma", "Whitespace"
	};


	public CGrammarLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public CGrammarLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'#include'", "'if'", "'else'", "'for'", "'while'", "'do'", "'continue'", 
		"'break'", "'return'", "'const'", "'struct'", "'char'", "'short'", "'int'", 
		"'long'", "'float'", "'double'", "'void'", null, null, null, null, null, 
		null, "'.'", "'->'", "'&'", "'='", "'+='", "'-='", "'*='", "'/='", "'%='", 
		"'+'", "'-'", "'*'", "'/'", "'%'", "'=='", "'!='", "'<'", "'<='", "'>'", 
		"'>='", "'&&'", "'||'", "'!'", "'('", "')'", "'['", "']'", "'{'", "'}'", 
		"';'", "':'", "','"
	};
	private static readonly string[] _SymbolicNames = {
		null, "Include", "If", "Else", "For", "While", "Do", "Continue", "Break", 
		"Return", "Const", "Struct", "Char", "Short", "Int", "Long", "Float", 
		"Double", "Void", "IncludeLiteral", "Identifier", "CharLiteral", "StringLiteral", 
		"IntLiteral", "FloatLiteral", "Access", "AccessPointer", "Address", "Assign", 
		"AssignAdd", "AssignSubtract", "AssignMultiply", "AssignDivide", "AssignModulo", 
		"Add", "Subtract", "Multiply", "Divide", "Modulo", "Equal", "NotEqual", 
		"Less", "LessOrEqual", "Greater", "GreaterOrEqual", "And", "Or", "Not", 
		"LeftRound", "RightRound", "LeftSquare", "RightSquare", "LeftCurly", "RightCurly", 
		"Semicolon", "Colon", "Comma", "Whitespace"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "CGrammar.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static CGrammarLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static int[] _serializedATN = {
		4,0,57,350,6,-1,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,
		6,2,7,7,7,2,8,7,8,2,9,7,9,2,10,7,10,2,11,7,11,2,12,7,12,2,13,7,13,2,14,
		7,14,2,15,7,15,2,16,7,16,2,17,7,17,2,18,7,18,2,19,7,19,2,20,7,20,2,21,
		7,21,2,22,7,22,2,23,7,23,2,24,7,24,2,25,7,25,2,26,7,26,2,27,7,27,2,28,
		7,28,2,29,7,29,2,30,7,30,2,31,7,31,2,32,7,32,2,33,7,33,2,34,7,34,2,35,
		7,35,2,36,7,36,2,37,7,37,2,38,7,38,2,39,7,39,2,40,7,40,2,41,7,41,2,42,
		7,42,2,43,7,43,2,44,7,44,2,45,7,45,2,46,7,46,2,47,7,47,2,48,7,48,2,49,
		7,49,2,50,7,50,2,51,7,51,2,52,7,52,2,53,7,53,2,54,7,54,2,55,7,55,2,56,
		7,56,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,1,1,1,1,1,1,2,1,2,1,2,1,2,1,
		2,1,3,1,3,1,3,1,3,1,4,1,4,1,4,1,4,1,4,1,4,1,5,1,5,1,5,1,6,1,6,1,6,1,6,
		1,6,1,6,1,6,1,6,1,6,1,7,1,7,1,7,1,7,1,7,1,7,1,8,1,8,1,8,1,8,1,8,1,8,1,
		8,1,9,1,9,1,9,1,9,1,9,1,9,1,10,1,10,1,10,1,10,1,10,1,10,1,10,1,11,1,11,
		1,11,1,11,1,11,1,12,1,12,1,12,1,12,1,12,1,12,1,13,1,13,1,13,1,13,1,14,
		1,14,1,14,1,14,1,14,1,15,1,15,1,15,1,15,1,15,1,15,1,16,1,16,1,16,1,16,
		1,16,1,16,1,16,1,17,1,17,1,17,1,17,1,17,1,18,1,18,4,18,221,8,18,11,18,
		12,18,222,1,18,1,18,1,19,1,19,5,19,229,8,19,10,19,12,19,232,9,19,1,20,
		1,20,1,20,1,20,3,20,238,8,20,1,20,1,20,1,21,1,21,1,21,1,21,4,21,246,8,
		21,11,21,12,21,247,1,21,1,21,1,22,4,22,253,8,22,11,22,12,22,254,1,23,4,
		23,258,8,23,11,23,12,23,259,1,23,1,23,4,23,264,8,23,11,23,12,23,265,1,
		24,1,24,1,25,1,25,1,25,1,26,1,26,1,27,1,27,1,28,1,28,1,28,1,29,1,29,1,
		29,1,30,1,30,1,30,1,31,1,31,1,31,1,32,1,32,1,32,1,33,1,33,1,34,1,34,1,
		35,1,35,1,36,1,36,1,37,1,37,1,38,1,38,1,38,1,39,1,39,1,39,1,40,1,40,1,
		41,1,41,1,41,1,42,1,42,1,43,1,43,1,43,1,44,1,44,1,44,1,45,1,45,1,45,1,
		46,1,46,1,47,1,47,1,48,1,48,1,49,1,49,1,50,1,50,1,51,1,51,1,52,1,52,1,
		53,1,53,1,54,1,54,1,55,1,55,1,56,4,56,345,8,56,11,56,12,56,346,1,56,1,
		56,0,0,57,1,1,3,2,5,3,7,4,9,5,11,6,13,7,15,8,17,9,19,10,21,11,23,12,25,
		13,27,14,29,15,31,16,33,17,35,18,37,19,39,20,41,21,43,22,45,23,47,24,49,
		25,51,26,53,27,55,28,57,29,59,30,61,31,63,32,65,33,67,34,69,35,71,36,73,
		37,75,38,77,39,79,40,81,41,83,42,85,43,87,44,89,45,91,46,93,47,95,48,97,
		49,99,50,101,51,103,52,105,53,107,54,109,55,111,56,113,57,1,0,9,2,0,34,
		34,60,60,7,0,9,10,12,13,32,32,34,34,39,39,60,60,62,62,2,0,34,34,62,62,
		3,0,65,90,95,95,97,122,4,0,48,57,65,90,95,95,97,122,3,0,10,10,13,13,39,
		39,3,0,10,10,13,13,34,34,1,0,48,57,3,0,9,10,12,13,32,32,358,0,1,1,0,0,
		0,0,3,1,0,0,0,0,5,1,0,0,0,0,7,1,0,0,0,0,9,1,0,0,0,0,11,1,0,0,0,0,13,1,
		0,0,0,0,15,1,0,0,0,0,17,1,0,0,0,0,19,1,0,0,0,0,21,1,0,0,0,0,23,1,0,0,0,
		0,25,1,0,0,0,0,27,1,0,0,0,0,29,1,0,0,0,0,31,1,0,0,0,0,33,1,0,0,0,0,35,
		1,0,0,0,0,37,1,0,0,0,0,39,1,0,0,0,0,41,1,0,0,0,0,43,1,0,0,0,0,45,1,0,0,
		0,0,47,1,0,0,0,0,49,1,0,0,0,0,51,1,0,0,0,0,53,1,0,0,0,0,55,1,0,0,0,0,57,
		1,0,0,0,0,59,1,0,0,0,0,61,1,0,0,0,0,63,1,0,0,0,0,65,1,0,0,0,0,67,1,0,0,
		0,0,69,1,0,0,0,0,71,1,0,0,0,0,73,1,0,0,0,0,75,1,0,0,0,0,77,1,0,0,0,0,79,
		1,0,0,0,0,81,1,0,0,0,0,83,1,0,0,0,0,85,1,0,0,0,0,87,1,0,0,0,0,89,1,0,0,
		0,0,91,1,0,0,0,0,93,1,0,0,0,0,95,1,0,0,0,0,97,1,0,0,0,0,99,1,0,0,0,0,101,
		1,0,0,0,0,103,1,0,0,0,0,105,1,0,0,0,0,107,1,0,0,0,0,109,1,0,0,0,0,111,
		1,0,0,0,0,113,1,0,0,0,1,115,1,0,0,0,3,124,1,0,0,0,5,127,1,0,0,0,7,132,
		1,0,0,0,9,136,1,0,0,0,11,142,1,0,0,0,13,145,1,0,0,0,15,154,1,0,0,0,17,
		160,1,0,0,0,19,167,1,0,0,0,21,173,1,0,0,0,23,180,1,0,0,0,25,185,1,0,0,
		0,27,191,1,0,0,0,29,195,1,0,0,0,31,200,1,0,0,0,33,206,1,0,0,0,35,213,1,
		0,0,0,37,218,1,0,0,0,39,226,1,0,0,0,41,233,1,0,0,0,43,241,1,0,0,0,45,252,
		1,0,0,0,47,257,1,0,0,0,49,267,1,0,0,0,51,269,1,0,0,0,53,272,1,0,0,0,55,
		274,1,0,0,0,57,276,1,0,0,0,59,279,1,0,0,0,61,282,1,0,0,0,63,285,1,0,0,
		0,65,288,1,0,0,0,67,291,1,0,0,0,69,293,1,0,0,0,71,295,1,0,0,0,73,297,1,
		0,0,0,75,299,1,0,0,0,77,301,1,0,0,0,79,304,1,0,0,0,81,307,1,0,0,0,83,309,
		1,0,0,0,85,312,1,0,0,0,87,314,1,0,0,0,89,317,1,0,0,0,91,320,1,0,0,0,93,
		323,1,0,0,0,95,325,1,0,0,0,97,327,1,0,0,0,99,329,1,0,0,0,101,331,1,0,0,
		0,103,333,1,0,0,0,105,335,1,0,0,0,107,337,1,0,0,0,109,339,1,0,0,0,111,
		341,1,0,0,0,113,344,1,0,0,0,115,116,5,35,0,0,116,117,5,105,0,0,117,118,
		5,110,0,0,118,119,5,99,0,0,119,120,5,108,0,0,120,121,5,117,0,0,121,122,
		5,100,0,0,122,123,5,101,0,0,123,2,1,0,0,0,124,125,5,105,0,0,125,126,5,
		102,0,0,126,4,1,0,0,0,127,128,5,101,0,0,128,129,5,108,0,0,129,130,5,115,
		0,0,130,131,5,101,0,0,131,6,1,0,0,0,132,133,5,102,0,0,133,134,5,111,0,
		0,134,135,5,114,0,0,135,8,1,0,0,0,136,137,5,119,0,0,137,138,5,104,0,0,
		138,139,5,105,0,0,139,140,5,108,0,0,140,141,5,101,0,0,141,10,1,0,0,0,142,
		143,5,100,0,0,143,144,5,111,0,0,144,12,1,0,0,0,145,146,5,99,0,0,146,147,
		5,111,0,0,147,148,5,110,0,0,148,149,5,116,0,0,149,150,5,105,0,0,150,151,
		5,110,0,0,151,152,5,117,0,0,152,153,5,101,0,0,153,14,1,0,0,0,154,155,5,
		98,0,0,155,156,5,114,0,0,156,157,5,101,0,0,157,158,5,97,0,0,158,159,5,
		107,0,0,159,16,1,0,0,0,160,161,5,114,0,0,161,162,5,101,0,0,162,163,5,116,
		0,0,163,164,5,117,0,0,164,165,5,114,0,0,165,166,5,110,0,0,166,18,1,0,0,
		0,167,168,5,99,0,0,168,169,5,111,0,0,169,170,5,110,0,0,170,171,5,115,0,
		0,171,172,5,116,0,0,172,20,1,0,0,0,173,174,5,115,0,0,174,175,5,116,0,0,
		175,176,5,114,0,0,176,177,5,117,0,0,177,178,5,99,0,0,178,179,5,116,0,0,
		179,22,1,0,0,0,180,181,5,99,0,0,181,182,5,104,0,0,182,183,5,97,0,0,183,
		184,5,114,0,0,184,24,1,0,0,0,185,186,5,115,0,0,186,187,5,104,0,0,187,188,
		5,111,0,0,188,189,5,114,0,0,189,190,5,116,0,0,190,26,1,0,0,0,191,192,5,
		105,0,0,192,193,5,110,0,0,193,194,5,116,0,0,194,28,1,0,0,0,195,196,5,108,
		0,0,196,197,5,111,0,0,197,198,5,110,0,0,198,199,5,103,0,0,199,30,1,0,0,
		0,200,201,5,102,0,0,201,202,5,108,0,0,202,203,5,111,0,0,203,204,5,97,0,
		0,204,205,5,116,0,0,205,32,1,0,0,0,206,207,5,100,0,0,207,208,5,111,0,0,
		208,209,5,117,0,0,209,210,5,98,0,0,210,211,5,108,0,0,211,212,5,101,0,0,
		212,34,1,0,0,0,213,214,5,118,0,0,214,215,5,111,0,0,215,216,5,105,0,0,216,
		217,5,100,0,0,217,36,1,0,0,0,218,220,7,0,0,0,219,221,8,1,0,0,220,219,1,
		0,0,0,221,222,1,0,0,0,222,220,1,0,0,0,222,223,1,0,0,0,223,224,1,0,0,0,
		224,225,7,2,0,0,225,38,1,0,0,0,226,230,7,3,0,0,227,229,7,4,0,0,228,227,
		1,0,0,0,229,232,1,0,0,0,230,228,1,0,0,0,230,231,1,0,0,0,231,40,1,0,0,0,
		232,230,1,0,0,0,233,237,5,39,0,0,234,238,8,5,0,0,235,236,5,92,0,0,236,
		238,5,39,0,0,237,234,1,0,0,0,237,235,1,0,0,0,238,239,1,0,0,0,239,240,5,
		39,0,0,240,42,1,0,0,0,241,245,5,34,0,0,242,246,8,6,0,0,243,244,5,92,0,
		0,244,246,5,34,0,0,245,242,1,0,0,0,245,243,1,0,0,0,246,247,1,0,0,0,247,
		245,1,0,0,0,247,248,1,0,0,0,248,249,1,0,0,0,249,250,5,34,0,0,250,44,1,
		0,0,0,251,253,7,7,0,0,252,251,1,0,0,0,253,254,1,0,0,0,254,252,1,0,0,0,
		254,255,1,0,0,0,255,46,1,0,0,0,256,258,7,7,0,0,257,256,1,0,0,0,258,259,
		1,0,0,0,259,257,1,0,0,0,259,260,1,0,0,0,260,261,1,0,0,0,261,263,5,46,0,
		0,262,264,7,7,0,0,263,262,1,0,0,0,264,265,1,0,0,0,265,263,1,0,0,0,265,
		266,1,0,0,0,266,48,1,0,0,0,267,268,5,46,0,0,268,50,1,0,0,0,269,270,5,45,
		0,0,270,271,5,62,0,0,271,52,1,0,0,0,272,273,5,38,0,0,273,54,1,0,0,0,274,
		275,5,61,0,0,275,56,1,0,0,0,276,277,5,43,0,0,277,278,5,61,0,0,278,58,1,
		0,0,0,279,280,5,45,0,0,280,281,5,61,0,0,281,60,1,0,0,0,282,283,5,42,0,
		0,283,284,5,61,0,0,284,62,1,0,0,0,285,286,5,47,0,0,286,287,5,61,0,0,287,
		64,1,0,0,0,288,289,5,37,0,0,289,290,5,61,0,0,290,66,1,0,0,0,291,292,5,
		43,0,0,292,68,1,0,0,0,293,294,5,45,0,0,294,70,1,0,0,0,295,296,5,42,0,0,
		296,72,1,0,0,0,297,298,5,47,0,0,298,74,1,0,0,0,299,300,5,37,0,0,300,76,
		1,0,0,0,301,302,5,61,0,0,302,303,5,61,0,0,303,78,1,0,0,0,304,305,5,33,
		0,0,305,306,5,61,0,0,306,80,1,0,0,0,307,308,5,60,0,0,308,82,1,0,0,0,309,
		310,5,60,0,0,310,311,5,61,0,0,311,84,1,0,0,0,312,313,5,62,0,0,313,86,1,
		0,0,0,314,315,5,62,0,0,315,316,5,61,0,0,316,88,1,0,0,0,317,318,5,38,0,
		0,318,319,5,38,0,0,319,90,1,0,0,0,320,321,5,124,0,0,321,322,5,124,0,0,
		322,92,1,0,0,0,323,324,5,33,0,0,324,94,1,0,0,0,325,326,5,40,0,0,326,96,
		1,0,0,0,327,328,5,41,0,0,328,98,1,0,0,0,329,330,5,91,0,0,330,100,1,0,0,
		0,331,332,5,93,0,0,332,102,1,0,0,0,333,334,5,123,0,0,334,104,1,0,0,0,335,
		336,5,125,0,0,336,106,1,0,0,0,337,338,5,59,0,0,338,108,1,0,0,0,339,340,
		5,58,0,0,340,110,1,0,0,0,341,342,5,44,0,0,342,112,1,0,0,0,343,345,7,8,
		0,0,344,343,1,0,0,0,345,346,1,0,0,0,346,344,1,0,0,0,346,347,1,0,0,0,347,
		348,1,0,0,0,348,349,6,56,0,0,349,114,1,0,0,0,10,0,222,230,237,245,247,
		254,259,265,346,1,6,0,0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
