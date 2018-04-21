using System;
using System.Text;

public class LastArmyMain
{
    static void Main()
    {
        //var input = ConsoleReader.ReadLine();
        //var gameController = new GameController();
        //var result = new StringBuilder();

        //while (!input.Equals("Enough! Pull back!"))
        //{
        //    try
        //    {
        //        gameController.GiveInputToGameController(input);
        //    }
        //    catch (ArgumentException arg)
        //    {
        //        result.AppendLine(arg.Message);
        //    }
        //    input = ConsoleReader.ReadLine();
        //}

        //gameController.RequestResult(result);
        //ConsoleWriter.WriteLine(result.ToString());

        Engine engine = new Engine(new ConsoleReader(), new ConsoleWriter());
        engine.Run();
    }
}