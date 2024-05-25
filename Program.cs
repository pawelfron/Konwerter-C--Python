﻿using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

public class Program {
    public static void Main(string[] args) {
        string input = File.ReadAllText(@"C:\Users\Mateusz\Documents\studia\kompilatory\Konwerter-C--Python\c.c");
        ICharStream stream = CharStreams.fromString(input);
        ITokenSource lexer = new CGrammarLexer(stream);
        ITokenStream tokens = new CommonTokenStream(lexer);
        CGrammarParser parser = new CGrammarParser(tokens);
        parser.RemoveErrorListeners();
        parser.AddErrorListener(new ThrowingErrorListener());
        IParseTree tree = parser.program();
        PythonGenerator visitor = new PythonGenerator();
        string pythonCode = visitor.Visit(tree);
        print(pythonCode);
        File.WriteAllText(@"C:\Users\Mateusz\Documents\studia\kompilatory\Konwerter-C--Python\output.py", pythonCode);


    }

    public static void print(string str) {
        string result = "";
        Console.WriteLine(str);
        int space=-1;
        char[] ca = str.ToCharArray();
        foreach(char c in ca) {
            if(c == '(') {
                result += c + "\n";
                space++;
                for(int i=0; i<space; i++) {result += "|  ";}
            }
            else if(c == ')') {
                result += "\n";
                for(int i=0; i<space; i++) {result += "|  ";}
                result += c + "\n";
                for(int i=0; i<space; i++) {result += "|  ";}
                space--;
            }
            else {
                result += c;
            }
        }
        File.WriteAllText("tree.txt", result);
    }
}