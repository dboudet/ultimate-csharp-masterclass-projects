using PasswordGenerator;

{
    var app = new PasswordGeneratorApp(new RandomWrapper());

    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine(app.Generate(5, 10, true));
    }

    Console.ReadKey();

}