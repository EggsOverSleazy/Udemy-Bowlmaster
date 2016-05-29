using UnityEngine;
using UnityEditor;
using NUnit.Framework;

[TestFixture]
public class ActionMasterTest {

    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
	private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
	private ActionMaster actionMaster;

	[SetUp]
	public void Setup(){	// all of the tests will have actionMaster declared
		
		ActionMaster actionMaster = new ActionMaster ();
		Debug.Log("I'm trying to setup test");
	}

	[Test]
	public void T00FailingTest()
	{
        Assert.AreEqual(1, 1);
	}

    [Test]
    public void T01OneStrikeReturnsEndTurn()
    {
		ActionMaster actionMaster = new ActionMaster ();
        // if you bowl a strike in your first turn, it should end the turn
        Assert.AreEqual(endTurn,actionMaster.Bowl(10));
    }

	[Test]
	public void T02Bowl8ReturnsTidy()
	{
		ActionMaster actionMaster = new ActionMaster ();
		//ActionMaster actionMaster = new ActionMaster ();
		Assert.AreEqual (tidy, actionMaster.Bowl (8));
	}

	[Test]
	public void T03Bowl28ReturnsEndTurn(){
		ActionMaster actionMaster = new ActionMaster ();
		Assert.AreEqual(tidy, actionMaster.Bowl (8));
		Assert.AreEqual(endTurn, actionMaster.Bowl(2));
			
	}
}
