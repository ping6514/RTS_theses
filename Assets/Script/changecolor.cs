using UnityEngine;
using System.Collections;

public class changecolor : MonoBehaviour {
	//int onece=0;
	public GameObject thisunit;
	// Use this for initialization
	void Start () {
		//thisunit=this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		/*if(onece<1)
			onece++;
		if(onece>=1){*/
		if(thisunit.GetComponent<unitstate>().player==1)
			this.GetComponent<Renderer>().material.color=Color.red;
		else
			this.GetComponent<Renderer>().material.color=Color.blue;

	}
}
