using UnityEngine;
using System.Collections;

public class mining : MonoBehaviour {
	public GameObject worker;
	public bool havegold=false;
	public GameObject basepos;
	public GameObject goldpos;
	public GameObject icon;
	Vector3 baseunitpoint;
	// Use this for initialization
	void Start () {
	//	goldpos=GameObject.Find("goldart");
	//	basepos=GameObject.Find("base");
		goldpos=basepos=worker;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void goming()
	{
		if(havegold)
		{
			worker.GetComponent<unitmove>().movepos=new Vector3(basepos.transform.position.x,1,basepos.transform.position.z);
			worker.GetComponent<unitmove>().moveing=true;
		//	icon.layer=0;
		}
		else
		{
			worker.GetComponent<unitmove>().movepos=new Vector3(goldpos.transform.position.x,1,goldpos.transform.position.z);
			worker.GetComponent<unitmove>().moveing=true;
		//	icon.layer=8;
		}

	}


	void OnTriggerEnter(Collider other) 
	{
		/*if(basepos!=null)
		{
			baseunitpoint=basepos.transform.position;

		}*/
		/*baseunitpoint;//*//*basepos.transform.position;//*/
		if (other.tag == "gold"&&!havegold && other.GetComponent<goldmine>().canuse)
		{
			havegold=true;
			//other.GetComponent<goldmine>().goldnumber-=15;
		//	other.GetComponent<goldmine>().delay=0.5f;
			other.GetComponent<goldmine>().canuse=false;
			worker.GetComponent<unitmove>().movepos=new Vector3(basepos.transform.position.x,1,basepos.transform.position.z);
			worker.GetComponent<unitmove>().moveing=true;
			icon.layer=0;
		}
	/*	if (other.tag == "goldarea"&&!havegold)
		{
			worker.GetComponent<unitmove>().movepos= new Vector3(basepos.transform.position.x, 1, basepos.transform.position.z);
            worker.GetComponent<unitmove>().moveing=true;
            worker.GetComponent<unitmove>().moveing=true;
            havegold = true;
            icon.layer = 0;

        }*/
		if(other.tag == "returngold"&&havegold)
		{
			havegold=false;
			GameObject.Find("gamecontrol").GetComponent<game1>().players[worker.GetComponent<unitstate>().player-1].gold+=20;
			worker.GetComponent<unitmove>().movepos=new Vector3(goldpos.transform.position.x,1,goldpos.transform.position.z);
			worker.GetComponent<unitmove>().moveing=true;
			icon.layer=8;
		}
	}
}
