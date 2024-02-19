using UnityEngine;
using System.Collections;

public class basemode : MonoBehaviour {
	public bool changeing=false;
	public float changetime=3f;
	public GameObject baseunit;
	public Vector3 basepoint;
	bool canuse=true;
	int player=0;
	// Use this for initialization
	void Start () {
		player=baseunit.GetComponent<unitstate>().player;
	}
	
	// Update is called once per frame
	void Update () {
	if(changeing)
		{

			changetime-=Time.deltaTime;
			if(changetime<=0&&canuse)
			{
				GameObject createbase = Instantiate(Resources.Load("base"),basepoint,Quaternion.identity)as GameObject;
				//Instantiate(baseunit,basepoint,Quaternion.identity);
				//Destroy (this.gameObject);
				//this.gameObject.GetComponent<unitstate>().hp=0;

				createbase.GetComponent<unitstate>().player=baseunit.GetComponent<unitstate>().player;
				canuse=false;
			}
			if(changetime<=-0.1&&canuse==false)
			this.gameObject.GetComponent<unitstate>().hp=0;
		}



	}
	void OnTriggerEnter(Collider other) 
	{
		if(other.tag=="basepoint")
		{
			basepoint=other.transform.position;
			changeing=true;
			this.gameObject.GetComponent<unitmove>().speed=0;
			}
	}
}
