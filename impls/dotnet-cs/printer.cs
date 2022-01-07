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
    if(token is TokenKeyword)
      print((TokenKeyword)token, builder);

    if(token is TokenList)
      print((TokenList)token, builder);

    if(token is TokenVector)
      print((TokenVector)token, builder);

    if(token is TokenMap)
      print((TokenMap)token, builder);

    if(token is TokenAtom)
      print((TokenAtom)token, builder);

    if(token is TokenInt)
      print((TokenInt)token, builder);

    if(token is TokenDouble)
      print((TokenDouble)token, builder);
  }

  private static void print(TokenKeyword keyword, StringBuilder builder){
    builder.Append($":{keyword.Value}");
  }

  private static void print(TokenList list, StringBuilder builder){
    print_tokens(list.Tokens, '(', ')', builder);
  }

  private static void print(TokenVector vector, StringBuilder builder){
    print_tokens(vector.Tokens, '[', ']', builder);
  }

  private static void print_tokens(Token[] tokens, char open, char close, StringBuilder builder){
    builder.Append(open);
    for(var i = 0; i < tokens.Length; i++){
      print(tokens[i], builder);
      if(i < tokens.Length-1)
        builder.Append(' ');
    }
    builder.Append(close);
  }

  private static void print(TokenMap map, StringBuilder builder){
    builder.Append('{');
    for(var i = 0; i < map.Map.Length; i++){
      var entry = map.Map[i];
      print(entry.Key, builder);
      builder.Append(' ');
      print(entry.Value, builder);
      if(i < map.Map.Length-1)
        builder.Append(' ');
    }
    builder.Append('}');
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
