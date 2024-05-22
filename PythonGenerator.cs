using System.ComponentModel;
using System.Net.Http.Headers;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

public class PythonGenerator : CGrammarBaseVisitor<string> {

    Indent indent;
    public List<string> result = new List<string>();

    public PythonGenerator() {
        indent = new Indent(this);
    }

    public override string VisitProgram([NotNull] CGrammarParser.ProgramContext context) {
        result.Add("");
        pr(context);
        for(int i=0; i<context.ChildCount; i++) {
            result[^1] += Visit(context.GetChild(i)) + "\n";
        }

        result[^1] += indent + "\n\nmain()";
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
        pr(context);
        Console.WriteLine("-------------");
        if(context.structDeclaration() != null) {
            result[^1] += Visit(context.structDeclaration()); // class in function in python? does not work
        }
        else if(context.variableDeclaration() != null) {
            result[^1] += Visit(context.variableDeclaration());
        }
        else if(context.If() != null) {
            result[^1] += indent + "if ";
            result[^1] += Visit(context.expression()[0]) + ":\n";
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
            result[^1] += indent + "while " + Visit(context.expression()[0]) + ":\n";
            indent++;
            result[^1] += Visit(context.statement(0)) + "\n";
            indent--;
        }
        else if(context.For() != null) {
            result[^1] += indent + "while True:\n";
            indent++;
            string variable = Visit(context.variableDeclaration());
            result[^1] += variable + "\n"; // brak obsługi expression
            result[^1] += indent + "if" + Visit(context.expression()[0]) + ":\n";
            indent++;
            result[^1] += indent + "break\n";
            indent--;
            result[^1] += Visit(context.statement(0)) + "\n";
            result[^1] += Visit(context.expression()[1]) + "\n";
            indent--;
        }
        else if(context.Break() != null) {
            result[^1] += indent + "break";
        }
        else if(context.Continue() != null) {
            result[^1] += indent + "continue";
        }
        else if(context.Return() != null) {
            result[^1] += indent + "return " + Visit(context.expression()[0]);
        }
        else if(context.LeftCurly() != null) {
            for(int i=0; i<context.statement().Length; i++) {
                result[^1] += Visit(context.statement(i)) + "\n";
            }
        }
        else {
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
        result[^1] += Visit(context.GetChild(0)); // todo
        return ret();
    }

    public override string VisitRvalue([NotNull] CGrammarParser.RvalueContext context) {
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