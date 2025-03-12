using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks.Sources;
using System;
using System.Collections;
using bowling;
using bowling.Bowling;


class Program
{
    /// <summary>
    /// Start of program runs until  GameState is changed to 
    /// </summary
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