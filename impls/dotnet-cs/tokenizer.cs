namespace dotnet_cs;

class Tokenizer{
  Tokenizer(string input){
    _input = input;
    _index = 0;
  }

  public static IEnumerable<string> tokenize(string input){
    var tokenizer = new Tokenizer(input);
    while(true){
      var token = tokenizer.next();
      if(token == null) break;
      yield return token;
    }
  }

  private readonly string _input;
  private int _index;

  public string? next(){
    while(_index < _input.Length){

      switch(_input[_index]){
        case ' ':
        case '\n':
        case '\t':
        case ',':
          _index++;
          continue;
        case '~':
          if(_index+1 < _input.Length && _input[_index+1] == '@'){
            _index+=2;
            return _input.Substring(_index-2,2);
          }
          else{
            _index++;
            return _input.Substring(_index-1,1);
          }
        case '[':
        case ']':
        case '{':
        case '}':
        case '(':
        case ')':
        case '\'':
        case '`':
        case '^':
        case '@':
          _index++;
          return _input.Substring(_index-1, 1);
        case '"':
          var stringStart = _index;
          _index++;
          while(_index < _input.Length){
            switch(_input[_index]){
              case '"':
                _index++;
                return _input.Substring(stringStart, _index-stringStart);
              case '\\':
                _index++;
                break;
            }
            _index++;
          }
          // got no end of string..
          Console.Error.WriteLine("EOF");
          return _input.Substring(stringStart, _index-stringStart);
        case ';':
          var commentStart = _index;
          while(_index < _input.Length){
            if(_input[_index] == '\n') break;
            _index++;
          }
          _index++;
          return _input.Substring(commentStart, _index - 1 - commentStart);
        default:
          // all other..
          var otherStart = _index;
          bool done = false;
          _index++;
          while(!done && _index < _input.Length){
            switch(_input[_index]){
              case ' ':
              case '\t':
              case '\n':
              case '[':
              case ']':
              case '{':
              case '}':
              case '(':
              case ')':
              case '\'':
              case '"':
              case '`':
              case ',':
              case ';':
                done = true;
                break;
              default:
                _index++;
                break;
            }
          }
          return _input.Substring(otherStart, _index - otherStart);
      }
    }

    return null;
  }
}



record Value();
