using PasswordGenerator;

{
    var app = new PasswordGeneratorApp(new RandomWrapper());

    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine(app.Generate(8, 16, true));
    }

    Console.ReadKey();

}