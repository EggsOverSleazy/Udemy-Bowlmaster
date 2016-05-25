using UnityEngine;
using System.Collections;

public class ActionMaster {

    public enum Action
    {
        Tidy, Reset, EndTurn, EndGame
    };

    public Action Bowl(int pins)    // returns something of type acdtion
    {
        if (pins < 0 || pins > 10)
        {
            throw new UnityException("Durr.. invalid pins!");
        }

        if (pins == 10)
        { 
            return Action.EndTurn;
        }

        throw new UnityException("Durr.. Not sure what action to return!");
    }
}
