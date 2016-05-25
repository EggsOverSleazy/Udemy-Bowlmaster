using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class ActionMasterTest {

    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;

	[Test]
	public void T00FailingTest()
	{
        Assert.AreEqual(1, 1);
	}

    [Test]
    public void T01OneStrikeReturnsEndTurn()
    {
        // if you bowl a strike in your first turn, it should end the turn
        ActionMaster actionMaster = new ActionMaster();
        Assert.AreEqual(endTurn,actionMaster.Bowl(10));
    }
}
