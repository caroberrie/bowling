using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using bowling.Frame;

namespace bowling.Bowling
{
    public class BowlingGame : IBowlingGame
    {
        private static int PinsToUse = 10;

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
            frameCount = 0;
        }

        public void GameLoop()
        {
            Console.WriteLine($"Input Frame Score ---Frame {frameCount + 1}---");
            int throw1 = 0
            , throw2 = 0
            , throw3 = 0;

            throw1 = GetUserInput();
            if (throw1 < PinsToUse || frameCount == 9)
            {
                Console.WriteLine("Input Second Frame Score");
                throw2 = GetUserInput();
            }
            if(frameCount == 9)
            {
                if (throw1 + throw2 >= PinsToUse)
                {
                    Console.WriteLine("Input Third Frame Score");
                    throw3 = GetUserInput();
                }
                AddFrame(Factory.CreateFrame(frameCount, throw1,throw2,throw3));
            }
            else
            {
                AddFrame(Factory.CreateFrame(frameCount, throw1, throw2));
            }
            GetScore();
            if (frameCount == 9)
            {
                IncrementFrame();
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

        private void GetScore()
        {
            int RunningTotal = 0;
            string consoleMessage = "";

            foreach (IFrame Frame in Frames)
            {
               
                
                    switch (Frame.GetFrameStatus())
                    {
                        case FrameState.None:
                            RunningTotal += Frame.GetTotalScore();
                        break;
                        case FrameState.Strike:
                            
                            RunningTotal += Frame.GetTotalScore();

                            if (frameCount >= Frame.GetFrameNumber() + 1 & Frame.GetFrameNumber() != 9)
                            {


                                if (Frames[Frame.GetFrameNumber() + 1].GetFrameStatus() == FrameState.Strike)
                                {
                                    RunningTotal += Frames[Frame.GetFrameNumber() + 1].GetTotalScore();
                                    if (frameCount > Frame.GetFrameNumber() + 2)
                                    {
                                        RunningTotal += Frames[Frame.GetFrameNumber() + 2].GetScore(1);
                                    }
                                }
                                else
                                {
                                    RunningTotal += Frames[Frame.GetFrameNumber() + 1].GetScore(1) + Frames[Frame.GetFrameNumber() + 1].GetScore(2);
                                    break;
                                }
                            }
                            else if (Frame.GetFrameNumber() == 9)
                            {
                                    RunningTotal -= Frame.GetTotalScore(); //take off frame total for 10(9)
                                                                           // X X 1 -> 21
                                                                           // X 1 1 -> 12?
                                                                           // X X X -> 30
                                                                           // X 1 X -> not possible
                                                                           //already here so has a strike in X ? X
                                    if (Frames[Frame.GetFrameNumber()].GetScore(1) == 10)
                                    {
                                        RunningTotal += Frames[Frame.GetFrameNumber()].GetScore(1) + Frames[Frame.GetFrameNumber()].GetScore(2) + Frames[Frame.GetFrameNumber()].GetScore(3);
                                    }
                                    if (Frames[Frame.GetFrameNumber()].GetScore(2) == 10)
                                    {
                                         RunningTotal += Frames[Frame.GetFrameNumber()].GetScore(2) + Frames[Frame.GetFrameNumber()].GetScore(3);
                                    }
                                    if (Frames[Frame.GetFrameNumber()].GetScore(3) == 10)
                                    {
                                         RunningTotal += Frames[Frame.GetFrameNumber()].GetScore(3);
                                    }
                        }
                            else
                            {
                                consoleMessage = "Running Score is incomplete next frame needed";
                            }
                            
                        break;
                        case FrameState.Spare:
                            RunningTotal += Frame.GetTotalScore();
                            if (frameCount >= Frame.GetFrameNumber() + 1 & Frame.GetFrameNumber() != 9) //dont do this if last frame is spare, as we have already scored it above.
                            {
                                RunningTotal += Frames[Frame.GetFrameNumber() + 1].GetScore(1);
                                break;
                            }
                            else if (Frame.GetFrameNumber() == 9)
                            {
                                RunningTotal += Frames[Frame.GetFrameNumber()].GetScore(3);
                            }
                            else
                            {
                                consoleMessage = "Running Score is incomplete next frame needed";
                            }
                        break;
                        default:
                            throw new InvalidOperationException("Unknown Frame State");
                    }
                
            }
            if (frameCount == 9)
            {
                
                Console.WriteLine($"Final Score:{RunningTotal}");
            }
            else
            {
                Console.WriteLine($"Running Score:{RunningTotal}");
                if (!string.IsNullOrEmpty(consoleMessage)){ Console.WriteLine(consoleMessage); }
            }
        }

    }
}
