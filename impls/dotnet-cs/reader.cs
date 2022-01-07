namespace dotnet_cs;

class Reader{
  public Reader(string[] tokens){
    _tokens = tokens;
    _index = 0;
  }

  public static IEnumerable<Token> read_str(string input){
    var tokens = Tokenizer.tokenize(input).ToArray();
    var reader = new Reader(tokens);

    while(true){
      var form = read_form(reader);
      if(form == null) break;

      yield return form;
    }
  }

  static Token? read_form(Reader reader){
    var token = reader.peek();
    if(token == null) return null;

    if(token[0] == '('){
        reader.next();
        return read_list(reader);
    }

    return read_atom(reader);
  }

  static Token? read_list(Reader reader){
    var tokens = new List<Token>();
    var finished = false;
    while(true){
      var token = reader.peek();
      if(token==null) break;

      if(token[0] == ')'){
        reader.next();
        finished = true;
        break;
      }

      var form = read_form(reader);
      if(form == null) break;

      tokens.Add(form);
    }
    if(!finished)
    {
      Console.Error.WriteLine("EOF");
      return null;
    }

    return new TokenList(tokens.ToArray());
  }

  static Token? read_atom(Reader reader){
    var token = reader.next();
    if(token == null) return null;

    if(char.IsDigit(token[0])){
      if(int.TryParse(token, out var tokenInt)){
        return new TokenInt(tokenInt);
      }

      if(double.TryParse(token, out var tokenDouble)){
        return new TokenDouble(tokenDouble);
      }
    }
    return new TokenAtom(token);
  }

  string[] _tokens;
  int _index;

  public string? next(){
    var result = _index < _tokens.Length? _tokens[_index]: null;
    _index++;
    return result;
  }

  public string? peek() => _index < _tokens.Length ? _tokens[_index] : null;
}
