
/*
/*using UnityEngine;
using System.Collections;

public class checkobj : MonoBehaviour {
	public string inf="";
//	public string relation="";
//	public object checkthing;
//	public GoalScript green;
	public GameObject checkthing;
	//Color b;
	private bool checking =false;
	GameObject obj;
	//hollow p;
	bool keyPrev;
	bool keyNow;
	// Use this for initialization
	void Start () {
		keyPrev = false;
	//	obj=GameObject.Find(relation);
	}

	// Update is called once per frame
	void Update () {
		keyNow = Input.GetKey (KeyCode.Z);

	}
/*	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{checking=true;
			print("ggggg");}
	//	else
	//	checking=false;
	
	}
	void OnTriggerExit(Collider other) 
	{

		if (other.tag == "Player")
		{checking=false;
		checkthing.renderer.material.color=Color.white;}
//			print("dddd");}
		//	else
		//	checking=false;
		
	}
	void OnTriggerEnter(Collider other) 
	{

		if (other.tag == "Player")
		{checkthing.renderer.material.color=Color.blue;
			//if(!keyPrev && keyNow)checking=true;
		}
		//			print("dddd");}
		//	else
		//	checking=false;
		
	}
	void OnTriggerStay(Collider other)
	{

	//	obj.renderer.material.color=Color.red;
	if (other.tag == "Player")
		{if(!keyPrev && keyNow)checking=true;
		//	checkthing.renderer.material.color=Color.green;
			//print(GameObject.Find("hero").AddComponent("hollow"));
	//		GameObject.Find("hero").AddComponent("hollow");
			//if(GameObject.Find("hero").GetComponent<hollow>()==null)
			//	print ("notfound");
			//p.z=0;
		//	int j=p.ggg();
		//	p.z=555;
		//	GameObject.Find("hero").GetComponent<hollow>();
			//p.ggg(999);
			keyPrev = keyNow;
		}
	//	keyPrev = keyNow;

	}
	void OnGUI()
	{
		if (checking) {
			GUI.Box(new Rect(0,Screen.height/2+Screen.height/4,200,25),"訊息框");
		//	GUI.Label (new Rect(Screen.width/2-30,
		//	                    Screen.height/2-25,60,50),inf);
			GUI.Box(new Rect(0,Screen.height/2+Screen.height/4+25,Screen.width,Screen.height/4),"");
			GUI.Label (new Rect(0,Screen.height/2+Screen.height/4+25,Screen.width,Screen.height/4),inf);

		}
	}


}*/
