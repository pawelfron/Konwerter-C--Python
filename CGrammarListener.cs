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

using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="CGrammarParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.CLSCompliant(false)]
public interface ICGrammarListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="CGrammarParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterProgram([NotNull] CGrammarParser.ProgramContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CGrammarParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitProgram([NotNull] CGrammarParser.ProgramContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="CGrammarParser.includeStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIncludeStatement([NotNull] CGrammarParser.IncludeStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CGrammarParser.includeStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIncludeStatement([NotNull] CGrammarParser.IncludeStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="CGrammarParser.declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDeclaration([NotNull] CGrammarParser.DeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CGrammarParser.declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDeclaration([NotNull] CGrammarParser.DeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="CGrammarParser.functionDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunctionDeclaration([NotNull] CGrammarParser.FunctionDeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CGrammarParser.functionDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunctionDeclaration([NotNull] CGrammarParser.FunctionDeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="CGrammarParser.structDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStructDeclaration([NotNull] CGrammarParser.StructDeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CGrammarParser.structDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStructDeclaration([NotNull] CGrammarParser.StructDeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="CGrammarParser.variableDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterVariableDeclaration([NotNull] CGrammarParser.VariableDeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CGrammarParser.variableDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitVariableDeclaration([NotNull] CGrammarParser.VariableDeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="CGrammarParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStatement([NotNull] CGrammarParser.StatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CGrammarParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStatement([NotNull] CGrammarParser.StatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="CGrammarParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpression([NotNull] CGrammarParser.ExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CGrammarParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpression([NotNull] CGrammarParser.ExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="CGrammarParser.lvalue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLvalue([NotNull] CGrammarParser.LvalueContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CGrammarParser.lvalue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLvalue([NotNull] CGrammarParser.LvalueContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="CGrammarParser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterType([NotNull] CGrammarParser.TypeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CGrammarParser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitType([NotNull] CGrammarParser.TypeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="CGrammarParser.assignOperator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAssignOperator([NotNull] CGrammarParser.AssignOperatorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CGrammarParser.assignOperator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAssignOperator([NotNull] CGrammarParser.AssignOperatorContext context);
}
