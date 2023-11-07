
var app = new PasswordGenerator(new RandomWrapper());

for (int i = 0; i < 10; i++)
{
    Console.WriteLine(app.Generate(8, 16, true));
}

Console.ReadKey();
