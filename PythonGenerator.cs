using System.ComponentModel;
using System.Net.Http.Headers;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Dfa;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Sharpen;
using Antlr4.Runtime.Tree;

public class PythonGenerator : CGrammarBaseVisitor<string> {
    public static string? error = null;

    Indent indent;
    public List<string> result = new List<string>();

    public PythonGenerator() {
        indent = new Indent(this);
    }

    public override string VisitProgram([NotNull] CGrammarParser.ProgramContext context) {
        result.Add("");
        result[^1] += "def printf(*args):\n";
        indent++;
        result[^1] += indent + "s = args[0]\n";
        result[^1] += indent + "for i in args[1:]:\n";
        indent++;
        result[^1] += indent + "s = s.replace(s[s.find('%'):s.find('%')+2], str(i), 1)\n";
        indent--;
        result[^1] += indent + "print(s)\n";
        indent--;
        for(int i=0; i<context.ChildCount; i++) {
            result[^1] += Visit(context.GetChild(i));
        }

        result[^1] += "\n\nmain()";
        return ret();
    }

    public override string VisitDeclaration([NotNull] CGrammarParser.DeclarationContext context) {
        result.Add("");
        result[^1] += Visit(context.GetChild(0));
        return ret();
    }

    public override string VisitVariableDeclaration([NotNull] CGrammarParser.VariableDeclarationContext context) {
        result.Add("");
        result[^1] += indent + context.Identifier().GetText();
        if(context.assignOperator() != null) {
            result[^1] += indent + "=" + Visit(context.expression());
        }
        else {
            result[^1] += indent + "=None";
        }
        return ret();
    }

    public override string VisitStructDeclaration([NotNull] CGrammarParser.StructDeclarationContext context) {
        result.Add("");
        result[^1] += indent + "class " + context.Identifier().GetText() + ":\n";
        indent++;
        for(int i=0; i<context.ChildCount; i++) {
            if(context.GetChild(i) is CGrammarParser.VariableDeclarationContext) {
                result[^1] += indent + Visit(context.GetChild(i)) + "\n";
            }
            else if(context.GetChild(i) is CGrammarParser.StructDeclarationContext) {
                result[^1] += indent + Visit(context.GetChild(i)) + "\n";
            }
        }
        indent--;
        return ret(); // no empty struct declaration
    }

    public override string VisitStatement([NotNull] CGrammarParser.StatementContext context) {
        result.Add("");
        if(context.LeftCurly() != null) {
            for(int i=1; i<context.ChildCount - 1; i++) {
                result[^1] += Visit(context.GetChild(i)) + "\n";
            }
        }
        else if(context.structDeclaration().Length != 0) {
            result[^1] += Visit(context.structDeclaration(0)); // class in function in python? does not work
        }
        else if(context.For() != null) {
            result[^1] += Visit(context.variableDeclaration(0)) + "\n";
            result[^1] += indent + "while ";
            result[^1] += Visit(context.expression(0));
            result[^1] += ":\n";
            indent++;
            result[^1] += Visit(context.statement(0));
            result[^1] += Visit(context.expression(1));
        }
        else if(context.variableDeclaration().Length != 0) {
            result[^1] += Visit(context.variableDeclaration(0));
        }
        else if(context.If() != null) {
            result[^1] += indent + "if ";
            result[^1] += Visit(context.expression(0)) + ":\n";
            indent++;
            result[^1] += Visit(context.statement(0)); // + "\n";
            indent--;
            if(context.Else() != null) {
                result[^1] += indent + "else:\n";
                indent++;
                result[^1] += Visit(context.statement(1)); // + "\n";
                indent--;
            }
        }
        else if(context.While() != null) {
            result[^1] += indent + "while ";
            result[^1] += Visit(context.expression(0)) + ":\n";
            indent++;
            result[^1] += Visit(context.statement(0)) + "\n";
            indent--;
        }
        else if(context.Break() != null) {
            result[^1] += indent + "break\n";
        }
        else if(context.Continue() != null) {
            result[^1] += indent + "continue\n";
        }
        else if(context.Return() != null) {
            result[^1] += indent + "return ";
            result[^1] += Visit(context.expression(0)) + "\n";
        }
        else if(context.expression().Length != 0) {
            result[^1] += Visit(context.expression(0));
        }
        return ret();
    }

    public override string VisitFunctionDeclaration([NotNull] CGrammarParser.FunctionDeclarationContext context) {
        result.Add("");
        result[^1] += indent + "def " + context.Identifier()[0].GetText() + "(";
        foreach(var param in context.Identifier().Skip(1)) {
            result[^1] += indent + param.GetText() + ",";
        }
        if(context.Identifier().Length > 1) {
            result[^1] = result[^1].Substring(0, result[^1].Length - 1);
        }
        result[^1] += indent + "):\n";
        indent++;
        if(context.Semicolon() != null) {
            result[^1] += indent + "pass\n";
        }
        else {
            result[^1] += Visit(context.statement()) + "\n";
        }
        indent--;
        return ret();
    }

    public override string VisitExpression([NotNull] CGrammarParser.ExpressionContext context) {
        result.Add("");
        for(int i=0; i<context.ChildCount; i++) {
            if(context.GetChild(i) is TerminalNodeImpl) {
            result[^1] += indent + context.GetChild(i).GetText();
            }
            else {
                result[^1] += Visit(context.GetChild(i));
            }
        }
        return ret(); // todo
    }

    public override string VisitLvalue([NotNull] CGrammarParser.LvalueContext context) {
        result.Add("");
        if(context.LeftRound() != null) {
            result[^1] += indent + "(";
            result[^1] += Visit(context.lvalue());
            result[^1] += indent + ")";
        }
        else if(context.Access() != null) {
            result[^1] += Visit(context.lvalue());
            result[^1] += indent +  ".";
            result[^1] += context.Identifier().GetText();
        }
        else if(context.LeftSquare() != null) {
            result[^1] += Visit(context.lvalue());
            result[^1] += indent + "[";
            result[^1] += Visit(context.expression());
            result[^1] += indent + "]";
        }
        else if(context.Identifier() != null){
            result[^1] += indent + context.Identifier().GetText();
        }
        else if(context.Add() != null || context.Subtract() != null) {
            result[^1] += Visit(context.lvalue());
            result[^1] += indent + context.GetChild(1).GetText();
            result[^1] += Visit(context.expression());
        }
        return ret();
    }

    public override string VisitAssignOperator([NotNull] CGrammarParser.AssignOperatorContext context) {
        result.Add("");
        if(context.Assign() != null) {
            result[^1] += "=";
        }
        else if(context.AssignAdd() != null) {
            result[^1] += "+=";
        }
        else if(context.AssignSubtract() != null) {
            result[^1] += "-=";
        }
        else if(context.AssignMultiply() != null) {
            result[^1] += "*=";
        }
        else if(context.AssignDivide() != null) {
            result[^1] += "/=";
        }
        else if(context.AssignModulo() != null) {
            result[^1] += "%=";
        }
        else {
            result[^1] += "ERROR";
        }
        return ret();
    }

    public override string VisitIncludeStatement([NotNull] CGrammarParser.IncludeStatementContext context) {
        return "";
    }

    public override string VisitType([NotNull] CGrammarParser.TypeContext context) {
        return "";
    }


    public string ret() {
        string str = result[^1];
        result.RemoveAt(result.Count - 1);
        return str;
    }
    public void pr(ParserRuleContext context) {
        for(int i=0; i<context.ChildCount; i++) {
            try {
                Console.WriteLine(context.GetType() + "   " + context.GetChild(i).GetType() + "   " + context.GetChild(i).GetText());
            }
            catch(Exception) {
                Console.WriteLine("ERROR");
            }
        }
    }
}






public class Indent {
    public int count = 0;
    public PythonGenerator pythonGenerator;

    public Indent(PythonGenerator pythonGenerator) {
        this.pythonGenerator = pythonGenerator;
    }

    public static Indent operator++(Indent indent) {
        indent.count++;
        return indent;
    }
    public static Indent operator--(Indent indent) {
        indent.count--;
        return indent;
    }
    public override string ToString() {
        string str = pythonGenerator.result.Aggregate("", (acc, val) => acc + val);

        if(str.Length != 0 && str.Last() == '\n') {
            return string.Concat(Enumerable.Repeat("    ", count));    
        }
        else {
            return "";
        }
    }
}

public class ThrowingErrorListener : BaseErrorListener {

    public override void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e) {
        PythonGenerator.error = "Błąd składni w linii " + line + " na pozycji " + charPositionInLine + ":\n" + msg;
    }
}