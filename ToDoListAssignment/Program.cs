Console.WriteLine("Hello!");

bool stopAsking = false;
var todos = new List<string>();

bool validDescription = false;
bool validIndexToRemove = false;

do
{
    validDescription = false;
    validIndexToRemove = false;
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("[S] ee all TODOs");
    Console.WriteLine("[A] dd a TODO");
    Console.WriteLine("[R] emove a TODO");
    Console.WriteLine("[E] xit");

    string? actionInput = Console.ReadLine()?.ToUpper();
    if (actionInput == null)
    {
        HandleInvalidInput();
        continue;
    }
    else
    {

        switch (actionInput)
        {
            case "S":
                DisplayAllTodos();
                break;
            case "A":
                HandleAddNewDescription();
                break;
            case "R":
                HandleRemoveTodo();
                break;
            case "E":
                EndProgram();
                break;
            case null:
            default:
                HandleInvalidInput();
                break;
        }
    }   
}
while (stopAsking == false);

void HandleInvalidInput()
{
    Console.WriteLine("Invalid input. Please try again.");
}

bool IsNoExistingTodos()
{
    if (todos.Count == 0)
    {
        Console.WriteLine("No TODOs have been added yet");
        return true;
    }
    else return false;
}
void DisplayAllTodos()
{
    if (!IsNoExistingTodos())
    {
        for (int i = 0; i < todos.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {todos[i]}");
        }
    }
}

void HandleAddNewDescription()
{
    do
    {
        Console.WriteLine("Enter the TODO description:");
        string? newTodo = Console.ReadLine();

        if (String.IsNullOrWhiteSpace(newTodo))
        {
            Console.WriteLine("The description cannot be empty.");
        }
        else if (todos.Contains(newTodo))
        {
            Console.WriteLine("The description must be unique.");
        }
        else
            AddNewTodo(newTodo);
    }
    while (validDescription == false);
}

void AddNewTodo(string descriptionInput)
{
    todos.Add(descriptionInput);
    Console.WriteLine("TODO successfully added: " + descriptionInput);
    validDescription = true;
}

void HandleRemoveTodo()
{
    if (!IsNoExistingTodos())
    {
        do
        {
            Console.WriteLine("Select the index of the TODO you want to remove:");
            DisplayAllTodos();
            int selectedInput;
            string? userInput = Console.ReadLine();
            bool isInputInt = int.TryParse(userInput, out selectedInput);
            if (String.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("Selected index cannot be empty.");
            }
            else if (selectedInput < 1 || selectedInput > todos.Count)
            {
                Console.WriteLine("The given index is not valid.");
            }
            else
            {
                Console.WriteLine($"TODO removed: {todos[selectedInput - 1]}");
                RemoveSelectedTodo(selectedInput - 1);
            }
        }
        while (validIndexToRemove == false);
    }
}

void RemoveSelectedTodo(int indexToRemove)
{
    todos.RemoveAt(indexToRemove);
    validIndexToRemove = true;
}

void EndProgram()
{
    stopAsking = true;
    Console.WriteLine("Thank you. Press any key to close.");
    Console.ReadKey();
}