using Flashcards.wkktoria.Controllers;
using Flashcards.wkktoria.Services;
using Flashcards.wkktoria.UserInteractions;

namespace Flashcards.wkktoria.Managers.Helpers;

internal class AllStackManager
{
    internal readonly StackController _stackController;

    internal AllStackManager(StackService stackService)
    {
        _stackController = new StackController(stackService);
    }

    private static void ShowMenu()
    {
        UserOutput.InfoMessage("""
                               0 - Return
                               1 - Show all stacks
                               2 - Create new stack
                               3 - Delete stack
                               """);
    }

    internal void Run()
    {
        var quit = false;

        while (!quit)
        {
            Console.Clear();
            ShowMenu();

            Console.Write("> ");
            var option = Console.ReadLine();

            switch (option!.Trim())
            {
                case "0":
                    quit = true;
                    break;
                case "1":
                    _stackController.ShowAll();
                    break;
                case "2":
                    _stackController.Create();
                    break;
                case "3":
                    _stackController.Delete();
                    break;
                default:
                    UserOutput.ErrorMessage("Invalid option.");
                    UserOutput.InfoMessage("Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }
}