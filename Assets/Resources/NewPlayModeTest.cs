using System;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEditor;

public class NewPlayModeTest {

	[Test]
	public void NewPlayModeTestSimplePasses() {
		// Use the Assert class to test conditions.
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator NewPlayModeTestWithEnumeratorPasses() {
		// Use the Assert class to test conditions.
	    SetupScene();
		// yield to skip a frame
		yield return new WaitForSeconds(3);
	}

    private void SetupScene()
    {
        try
        {
            var cube = GameObject.Find("BasicCube");
            PrefabUtility.GetPrefabParent(cube);
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("GeomagicPen"));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
