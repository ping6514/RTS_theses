using UnityEngine;
using System.Collections;

public class goldmine : MonoBehaviour {
	public int goldnumber=1500;
	public bool selected=false;
	public int goldusers=0;
	public bool canuse=true;
	public float delay=0;
	// Use this for initialization
	void Start () {
		GameObject.Find("gamecontrol").GetComponent<game1>().golds.Add(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			selected=false;
			this.GetComponent<Renderer>().material.color=Color.white;
		}
		if(delay>0)
		{
			delay-=Time.deltaTime;
			canuse=false;
		}
		else
			canuse=true;

	
	}
	void OnTriggerEnter(Collider other) 
	{
		
		if (other.tag == "selectbox"&&Input.GetMouseButton(0))
		{
			this.GetComponent<Renderer>().material.color=Color.blue;
			selected=true;
			//if(!keyPrev && keyNow)checking=true;
		}
	}
}
