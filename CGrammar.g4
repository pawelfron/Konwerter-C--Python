grammar CGrammar;

program
    : (includeStatement | declaration)* EOF
    ;

includeStatement
    : Include
        (StringLiteral | IncludeLiteral)
        ('\n' | '\r')
    ;

declaration
    : functionDeclaration
    | structDeclaration
    | variableDeclaration
    ;

structDeclaration
    : Struct Identifier
        (LeftCurly (variableDeclaration | structDeclaration)* RightCurly)?
        Semicolon
    ;

functionDeclaration
    : type Identifier LeftRound (type Identifier)* RightRound
        (statement | Semicolon)
    ;

variableDeclaration
    : Const? type Identifier
        (assignOperator (lvalue | rvalue))?
        Semicolon
    ;

statement
    : structDeclaration
    | variableDeclaration
    | If LeftRound expression RightRound statement
        (Else statement)?
    | While LeftRound expression RightRound statement
    | For LeftRound
        (expression Semicolon | variableDeclaration)
        expression Semicolon
        expression RightRound
        statement
    | Break Semicolon
    | Continue Semicolon
    | Return expression Semicolon
    | LeftCurly statement* RightCurly
    | expression Semicolon
    ;

expression
    : lvalue
    | rvalue?
    ;

lvalue
    : LeftRound lvalue RightRound
    | lvalue Access Identifier
    | Multiply pointer
    | pointer AccessPointer Identifier
    | lvalue LeftSquare rvalue RightSquare
    | StringLiteral
    | Identifier
    ;

rvalue
    : LeftRound rvalue RightRound
    | lvalue LeftRound rvalue? RightRound
    | Address lvalue
    | (Add | Subtract | Not ) rvalue
    | LeftRound type RightRound rvalue
    | rvalue (Multiply | Divide | Modulo) rvalue
    | rvalue (Add | Subtract) rvalue
    | rvalue (Less | LessOrEqual | Greater | GreaterOrEqual) rvalue
    | rvalue (Equal | NotEqual) rvalue
    | rvalue And rvalue
    | rvalue Or rvalue
    | lvalue assignOperator rvalue
    | rvalue Comma rvalue
    | IntLiteral
    | FloatLiteral
    | CharLiteral
    | Identifier
    ;

pointer
    : LeftRound pointer RightRound
    | Multiply pointer
    | pointer Add rvalue
    | pointer Subtract (rvalue | pointer)
    | Identifier
    ;

type
    : type Multiply
    | type LeftSquare IntLiteral RightSquare
    | Struct type
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

Include             : '#include';

If                  : 'if';
Else                : 'else';
For                 : 'for';
While               : 'while';
Continue            : 'continue';
Break               : 'break';
Return              : 'return';
Const               : 'const';
Struct              : 'struct';

Char                : 'char';
Short               : 'short';
Int                 : 'int';
Long                : 'long';
Float               : 'float';
Double              : 'double';
Void                : 'void';

Identifier      : [a-zA-Z_] [a-zA-Z_0-9]*;
CharLiteral     : '\'' (~['\r\n] | '\\\'') '\'';
StringLiteral   : '"' (~["\r\n] | '\\"')+ '"';
IncludeLiteral  : '<' ~[<>"' \t\r\n\f]+ '>';
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

