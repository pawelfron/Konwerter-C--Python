using System.Xml.XPath;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

public class PythonGenerator : CGrammarBaseVisitor<string> {
    public override string VisitProgram([NotNull] CGrammarParser.ProgramContext context) {
        string result = "";
        for(int i=0; i<context.ChildCount; i++) {
            result += Visit(context.GetChild(i)) + "\n";
        }
        return result;
    }

    public override string VisitDeclaration([NotNull] CGrammarParser.DeclarationContext context) {
        return Visit(context.GetChild(0));
    }

    public override string VisitVariableDeclaration([NotNull] CGrammarParser.VariableDeclarationContext context) {
        return context.Identifier().GetText() + context.assignOperator().GetText() + Visit(context.expression());
    }

    public override string VisitExpression([NotNull] CGrammarParser.ExpressionContext context) {
        return Visit(context.GetChild(0));
    }

    public override string VisitRvalue([NotNull] CGrammarParser.RvalueContext context) {
        string result = "";
        for(int i=0; i<context.ChildCount; i++) {
            if(context.GetChild(i) is TerminalNodeImpl) {
            result += context.GetChild(i).GetText();
            }
            else {
                result += Visit(context.GetChild(i));
            }
        }
        return result;
    }
}