﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using bowling.Frames;

namespace bowling.Bowling
{
    /// <summary>
    /// Houses the functionality of running a 10 frame, 10 pin game of bowling, repeat of games, score reported at end
    /// </summary
    public class BowlingGame : IBowlingGame
    {
        private static int PinsToUse = 10;
        private static int FramesToPlay = 9; //0 indexed
        private int frameCount;
        

        private List<IFrame> Frames;
        
        public BowlingGame()
        {
            Frames = new List<IFrame>();  
        }
        public GameState getCurrentGameState() {
            GameState GCGS_GameState;
            if (frameCount < 10)
            {
                GCGS_GameState = GameState.OngoingGame;
                return GCGS_GameState;
            }
            else
            {
                GCGS_GameState = GameState.GameOff;
                return GCGS_GameState;
            }
        }

        private int GetUserInput()
        {
            bool validInput = false;
            int number = 0;
            while (!validInput)
            {
                string console = Console.ReadLine();

                try
                {
                    number = Int32.Parse(console);
                    if (number > PinsToUse)
                    {
                        Console.WriteLine("Number Entered is more then the amount of pins you can hit!");    
                    }
                    else
                    {
                        validInput = true;
                    }
                   

                }
                catch
                {
                    if (frameCount < 10)
                    {
                        Console.WriteLine("Non-Integer Input Try Again");
                    }

                }
            }
            return number;
        }

        public void IncrementFrame()
        {
            frameCount++;
        }

        public void AddFrame(IFrame Currentframe)
        {
            Frames.Add(Currentframe);
        }

        private void newGame()
        {
            Frames.Clear();
            Frames.TrimExcess();
            frameCount = -1;
        }

        public void GameLoop()
        {
            Console.WriteLine($"Input Frame Score ---Frame {frameCount + 1}---");

            List<int> CurrentFramScore = new List<int>();

            CurrentFramScore.Add(GetUserInput()); 
            if (CurrentFramScore[0] < PinsToUse || frameCount == FramesToPlay)
            {
                Console.WriteLine("Input Second Frame Score");
                CurrentFramScore.Add(GetUserInput());
            }
            else
            {
                CurrentFramScore.Add(0);
            }
            if(frameCount == FramesToPlay)
            {
                if (CurrentFramScore[0] + CurrentFramScore[1] >= PinsToUse)
                {
                    Console.WriteLine("Input Third Frame Score");
                    CurrentFramScore.Add(GetUserInput()); 
                }
                else {
                    CurrentFramScore.Add(0);
                }
            }
            
            AddFrame(Factory.CreateFrame(frameCount, CurrentFramScore, FramesToPlay, PinsToUse));
            
            if (frameCount == FramesToPlay)
            {
                GetScore();
                
                Console.WriteLine("Another Game? Press 1 To Keep Playing, 2 to stop");
                if(GetUserInput() == 1)
                {
                    newGame();
                }
                else
                {
                    getCurrentGameState();
                }    
            }
            IncrementFrame();

        }

        public int GetScore()
        {
            int RunningTotal = 0;
           

            foreach (IFrame Frame in Frames)
            {
                switch (Frame.GetFrameStatus())
                {
                    case FrameState.None:
                        RunningTotal += Frame.GetTotalScore();
                    break;
                    case FrameState.Strike:

                        RunningTotal += Frame.GetTotalScore();

                        if (Frame.GetFrameNumber() != FramesToPlay)
                        {
                            if (Frames[Frame.GetFrameNumber() + 1].GetFrameStatus() == FrameState.Strike)
                            {
                                RunningTotal += Frames[Frame.GetFrameNumber() + 1].GetScore(1);
                                try //lazy way to catch the 9th frame
                                {
                                    RunningTotal += Frames[Frame.GetFrameNumber() + 2].GetScore(1);
                                    break;
                                }
                                catch
                                {
                                    RunningTotal += Frames[Frame.GetFrameNumber() + 1].GetScore(2);
                                }
                            }
                            else
                            {
                                RunningTotal += Frames[Frame.GetFrameNumber() + 1].GetScore(1) + Frames[Frame.GetFrameNumber() + 1].GetScore(2);
                                break;
                            }
                        }
                        

  
                    break;
                    case FrameState.Spare:
                        RunningTotal += Frame.GetTotalScore();
                        if (Frame.GetFrameNumber() != FramesToPlay)
                        {
                            RunningTotal += Frames[Frame.GetFrameNumber() + 1].GetScore(1);
                        }                   
                    break;
                        
                    
                    default:
                        throw new InvalidOperationException("Unknown Frame State");
                }
                
            }
            
            Console.WriteLine($"Final Score:{RunningTotal}");
            return RunningTotal;


        }

    }
}
