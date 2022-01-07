namespace dotnet_cs;

public record Token();

public record TokenList(Token[] Tokens):Token;

public record TokenAtom(string Value):Token;

public record TokenNumeric():Token;

public record TokenDouble(double Value):TokenNumeric;
public record TokenInt(int Value):TokenNumeric;
