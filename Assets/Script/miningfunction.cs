using UnityEngine;
using System.Collections;

public class miningfunction : MonoBehaviour {
	public GameObject miningarea;
	public mining aa;
	public int b =0;
	// Use this for initialization
	void Start () {
		aa = miningarea.GetComponent<mining> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void gomining()
	{
		aa.goming();

	}
}
