using UnityEngine;
using System.Collections;

public class unitstate : MonoBehaviour {
	public int hp=100;
	public int mp=0;
	public int atk=0;
	public int def=2;
	public int speed=0;
	public int atkrange=0;
	public int player=1;
	public int unittype=0;
	public GameObject thisunit;
	public bool selected=false;
	public unitmove movefunction; //=new unitmove();
	public GameObject battlearea;
	public battle battlefunction;
	public bool canattack=true;
	public bool attacking=false;

	// Use this for initialization
	void Start () {
		movefunction=this.gameObject.GetComponent<unitmove>();
		thisunit=this.gameObject;
		GameObject.Find("gamecontrol").GetComponent<game1>().units.Add(thisunit);
		selected=movefunction.selected;

	}
	
	// Update is called once per frame
	void Update () {
	//	movefunction.speed=1.0f;
		if(hp<=0)
		{
			GameObject.Find("gamecontrol").GetComponent<game1>().units.Remove(this.gameObject);
			death();

		}
	//	selected=movefunction.selected;
		if(selected&& Input.GetKeyDown("a"))
			canattack=true;
		if(selected&& Input.GetKeyDown("s"))
			canattack=false;


		if(Input.GetMouseButtonDown(0))
		{
			this.GetComponent<Renderer>().material.color=Color.white;
			selected=false;
		}

		if(Input.GetKey("p")&&selected)
		{
			thisunit.gameObject.transform.Translate(new Vector3(88,88,88));
			GameObject.Find("gamecontrol").GetComponent<game1>().units.Remove(this.gameObject);
			death();
		}

	}

     void death()
	{
		Destroy (this.gameObject);

	}

	void OnTriggerEnter(Collider other) 
	{
		
		if (other.tag == "selectbox"&&Input.GetMouseButton(0))
		{
			this.GetComponent<Renderer>().material.color=Color.blue;
			movefunction.selected=true;
			selected=true;
			//if(!keyPrev && keyNow)checking=true;
		}
		/*else
			this.renderer.material.color=Color.red;*/
		//			print("dddd");}
		//	else
		//	checking=false;
		
	}
}
