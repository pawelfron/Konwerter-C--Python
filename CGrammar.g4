grammar CGrammar;

program
    : (includeStatement | declaration)* EOF
    ;

includeStatement
    : Include IncludeLiteral
    ;

declaration
    : functionDeclaration
    | structDeclaration
    | variableDeclaration
    ;

functionDeclaration
    : type Identifier 
        LeftRound (type Identifier (Comma type Identifier)*)? RightRound
        (Semicolon | statement)
    ;

structDeclaration
    : Struct Identifier
        (LeftCurly (variableDeclaration | structDeclaration)* RightCurly)?
        Semicolon
    ;

variableDeclaration
    : Const? type Identifier
        (assignOperator expression)?
        Semicolon
    ;

statement
    : structDeclaration
    | variableDeclaration
    | If LeftRound expression RightRound statement
        (Else statement)?
    | While LeftRound expression RightRound statement
    | Do statement
        While LeftRound expression RightRound
        Semicolon
    | For LeftRound
        (expression? Semicolon | variableDeclaration)
        expression? Semicolon
        expression? RightRound
        statement
    | Break Semicolon
    | Continue Semicolon
    | Return expression? Semicolon
    | LeftCurly statement* RightCurly
    | expression Semicolon
    ;

    // statement
    // : LeftCurly 
    //     (variableDeclaration | structDeclaration | statement)*
    //     RightCurly
    // | If LeftRound expression RightRound statement
    //     (Else statement)?
    // | While LeftRound expression RightRound statement
    // | Do statement
    //     While LeftRound expression RightRound
    //     Semicolon
    // | For LeftRound
    //     (expression? Semicolon | variableDeclaration)
    //     expression? Semicolon
    //     expression? RightRound
    //     statement
    // | Break Semicolon
    // | Continue Semicolon
    // | Return expression? Semicolon
    // | expression? Semicolon
    // ;

expression
    : LeftRound expression RightRound
    | lvalue LeftRound expression? RightRound
    | Address lvalue
    | (Add | Subtract | Not ) expression
    | LeftRound type RightRound expression
    | expression (Multiply | Divide | Modulo) expression
    | expression (Add | Subtract) expression
    | expression (Less | LessOrEqual | Greater | GreaterOrEqual) expression
    | expression (Equal | NotEqual) expression
    | expression And expression
    | expression Or expression
    | lvalue assignOperator expression
    | expression Comma expression // ??
    | CharLiteral
    | StringLiteral
    | IntLiteral
    | FloatLiteral
    | lvalue
    ;

// Old version
// lvalue
//     : LeftRound lvalue RightRound
//     | lvalue Access Identifier
//     | Multiply pointer
//     | pointer AccessPointer Identifier
//     | lvalue LeftSquare expression RightSquare
//     | Identifier
//     ;

// pointer
//     : LeftRound pointer RightRound
//     | Multiply pointer
//     | pointer Add expression // possible Identifier Add rvalue as lvalue
//     | pointer Subtract (expression | pointer)
//     | Identifier
//     ;

lvalue
    : LeftRound lvalue RightRound
    | lvalue (Access | AccessPointer) Identifier
    | lvalue LeftSquare expression RightSquare
    | Multiply lvalue
    | lvalue (Add | Subtract) expression
    | Identifier
    ;

type
    : type Multiply
    | type LeftSquare IntLiteral RightSquare
    | Struct Identifier
    | Char
    | Short
    | Int
    | Long
    | Float
    | Double
    | Void
    | Identifier
    ;

assignOperator
    : Assign
    | AssignAdd
    | AssignSubtract
    | AssignMultiply
    | AssignDivide
    | AssignModulo
    ;

Include         : '#include';

If              : 'if';
Else            : 'else';
For             : 'for';
While           : 'while';
Do              : 'do';
Continue        : 'continue';
Break           : 'break';
Return          : 'return';
Const           : 'const';
Struct          : 'struct';

Char            : 'char';
Short           : 'short';
Int             : 'int';
Long            : 'long';
Float           : 'float';
Double          : 'double';
Void            : 'void';

IncludeLiteral  : [<"] ~[<>"' \t\r\n\f]+ [>"];
Identifier      : [a-zA-Z_] [a-zA-Z_0-9]*;
CharLiteral     : '\'' (~['\r\n] | '\\\'') '\'';
StringLiteral   : '"' (~["\r\n] | '\\"')+ '"';
IntLiteral      : [0-9]+;
FloatLiteral    : [0-9]+ '.' [0-9]+;

Access          : '.';
AccessPointer   : '->';
Address         : '&';

Assign          : '=';
AssignAdd       : '+=';
AssignSubtract  : '-=';
AssignMultiply  : '*=';
AssignDivide    : '/=';
AssignModulo    : '%=';

Add             : '+';
Subtract        : '-';
Multiply        : '*';
Divide          : '/';
Modulo          : '%';

Equal           : '==';
NotEqual        : '!=';
Less            : '<';
LessOrEqual     : '<=';
Greater         : '>';
GreaterOrEqual  : '>=';

And             : '&&';
Or              : '||';
Not             : '!';

LeftRound       : '(';
RightRound      : ')';
LeftSquare      : '[';
RightSquare     : ']';
LeftCurly       : '{';
RightCurly      : '}';

Semicolon       : ';';
Colon           : ':';
Comma           : ',';

Whitespace      : [ \t\r\n\f]+ -> skip;
