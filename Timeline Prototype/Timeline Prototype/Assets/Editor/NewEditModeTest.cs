using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class NewEditModeTest {

	[Test]
	public void NewEditModeTestSimplePasses() {
		// Use the Assert class to test conditions.
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator NewEditModeTestWithEnumeratorPasses() {
		// Use the Assert class to test conditions.
		// yield to skip a frame
		yield return null;
	}

	[UnityTest]
	public IEnumerator permuationOfAddRightNumberOfBillboardsFuncThatWillFail() {
		// Use the Assert class to test conditions.
		// yield to skip a frame
		//var gos : GameObject[];
		//gos = GameObject.FindGameObjectsWithTag("Billboard");


		Assert.AreEqual(GameObject.FindGameObjectsWithTag ("Billboard").Length, 10);
		//Assert(GameObject.FindGameObjectsWithTag ("Billboard").Length > 2);
		yield return null;
	}

	[UnityTest]
	public IEnumerator addedRightNumberOfBillboards() {
		// Use the Assert class to test conditions.
		// yield to skip a frame
		//var gos : GameObject[];
		//gos = GameObject.FindGameObjectsWithTag("Billboard");


		Assert.AreEqual(GameObject.FindGameObjectsWithTag ("Billboard").Length, 4);
		//Assert(GameObject.FindGameObjectsWithTag ("Billboard").Length > 2);
		yield return null;
	}
}
