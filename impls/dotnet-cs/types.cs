namespace dotnet_cs;

public record Token();

public record TokenKeyword(string Value):Token;

public record TokenList(Token[] Tokens):Token;

public record TokenVector(Token[] Tokens):Token;

public record TokenMap((Token Key, Token Value)[] Map):Token;

public record TokenAtom(string Value):Token;

public record TokenNumeric():Token;

public record TokenDouble(double Value):TokenNumeric;
public record TokenInt(int Value):TokenNumeric;
