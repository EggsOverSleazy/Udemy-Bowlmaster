using UnityEngine;
using System.Collections;

public class ActionMaster {

    public enum Action
    {
        Tidy, Reset, EndTurn, EndGame
    };

	//private int[] bowls = new int[21];
	private int bowl = 1;


    public Action Bowl(int pins)    // returns something of type acdtion
    {
        if (pins < 0 || pins > 10)
        {
            throw new UnityException("Durr.. invalid pins!");
        }

        if (pins == 10)
        { 
			bowl += 2;
            return Action.EndTurn;

        }
		// if first bowl of frame
		// then reutrn action.tidy

		if (bowl % 2 != 0) { // mid frame or something caught above
			bowl += 1;
			return Action.Tidy;
		} else if (bowl % 2 == 0) {// end of frame because it's now even
			bowl +=1; 
			return Action.EndTurn;
		}


        throw new UnityException("Durr.. Not sure what action to return!");
    }
}
