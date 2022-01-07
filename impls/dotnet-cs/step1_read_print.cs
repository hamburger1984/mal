// See https://aka.ms/new-console-template for more information

using dotnet_cs;

Token[] READ(string input) {
  return Reader.read_str(input).ToArray();
}

Token[] EVAL(Token[] input) { return input; }

string PRINT(Token[] input) { return Printer.pr_str(input); }

string rep(string input) {
  var read = READ(input);
  var eval = EVAL(read);
  return PRINT(eval);
}

while(true){
  Console.Write("user> ");
  var input = Console.ReadLine();

  if(input == null) break;

  Console.WriteLine(rep(input));
}
