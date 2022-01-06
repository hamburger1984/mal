// See https://aka.ms/new-console-template for more information

string READ(string input) { return input; }

string EVAL(string input) { return input; }

string PRINT(string input) { return input; }

string rep(string input) {
  var read = READ(input);
  var eval = EVAL(read);
  return PRINT(eval);
}


while(true){
  Console.Write("user> ");
  var input = Console.ReadLine();

  if(input==null) break;

  Console.WriteLine(rep(input));
}
