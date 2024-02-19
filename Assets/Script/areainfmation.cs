using UnityEngine;
using System.Collections;

public class areainfmation : MonoBehaviour {
	public GameObject goldarea;
	public GameObject basearea;
	// Use this for initialization
	void Start () {
		/*goldarea=GameObject.Find("gold");
		basearea=GameObject.Find("base");*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) 
	{
		if(other.tag=="miningarea")
		{
			//print("hhh");
			if(other.GetComponent<mining>().worker.GetComponent<unitstate>().unittype==1)
			{

			if(other.GetComponent<mining>()!=null)
			{
				other.GetComponent<mining>().basepos=basearea;
				other.GetComponent<mining>().goldpos=goldarea;
			}
			}
		}
	}
}
