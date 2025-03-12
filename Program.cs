using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks.Sources;
using System;
using System.Collections;
using bowling;
using bowling.Bowling;


class Program
{
    static void Main(string[] args)
    {

        BowlingGame CurrentGame = new BowlingGame();


        //string KeepPlaying = Console.ReadLine();
        while (CurrentGame.getCurrentGameState() == GameState.OngoingGame)
        {
            CurrentGame.GameLoop();
        }
    }
}

//to do
// 1, unit testing to be fully done, test all logic in BowlingGame, Factory, and Frame.
// 2, fix next games being out indexed even though im reseting the vars? maybe just reset game class?

//possible to do
// 1, make frame class bowls be a list -> make expandble? so we can have frames of any size, would require listing all the throws before going to factory, factory might need reworked to determine state based on list size? as well as put them into the Dictionary right.
// 2, better validation for scores? so a user cant ever 9 then a 3 for ex
// 3, maybe redo scoring, really we should have a final score at frame 9 out for 270 frame 10 is a bonus and only cares about itself. but current scoring works just that seems might be more efficent?

