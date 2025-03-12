namespace bowling.Bowling { } 
public enum GameState
{
    GameOff,
    OngoingGame,
}

public static class GameStateUtil
{
    public static string GetStateName(GameState state)
    {
        return state switch
        {
             GameState.GameOff => "The Game is turned off",
             GameState.OngoingGame => "The Game is currently on going",
             _ => state.ToString()
        };
    }

    
}


