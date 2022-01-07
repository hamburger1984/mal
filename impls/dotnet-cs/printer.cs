namespace dotnet_cs;

using System.Text;

public class Printer{
  public static string pr_str(Token[] tokens){
    var result = new StringBuilder();
    foreach(var token in tokens){
      print(token, result);
    }
    return result.ToString();
  }

  private static void print(Token token, StringBuilder builder){
    if(token is TokenList)
      print((TokenList)token, builder);

    if(token is TokenAtom)
      print((TokenAtom)token, builder);

    if(token is TokenInt)
      print((TokenInt)token, builder);

    if(token is TokenDouble)
      print((TokenDouble)token, builder);
  }

  private static void print(TokenList list, StringBuilder builder){
    builder.Append("(");
    for(var i = 0; i < list.Tokens.Length; i++){
      print(list.Tokens[i], builder);
      if(i < list.Tokens.Length-1)
        builder.Append(' ');
    }
    builder.Append(")");
  }

  private static void print(TokenAtom token, StringBuilder builder){
    builder.Append(token.Value);
  }
  private static void print(TokenInt token, StringBuilder builder){
    builder.Append(token.Value);
  }
  private static void print(TokenDouble token, StringBuilder builder){
    builder.Append(token.Value);
  }
}
