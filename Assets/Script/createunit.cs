using UnityEngine;
using System.Collections;

public class createunit : MonoBehaviour {
	public GameObject baseuint;
	public GameObject createworker;
	public float trainingtime=0f;
	public int trainingtype=0;
	public game1 game1;
	public int speedlv=0;
	int baseplayer;
	bool cansave=false;
	save savefuction;
	// Use this for initialization
	void Start () {
		game1=GameObject.Find("gamecontrol").GetComponent<game1>();
		baseplayer=baseuint.GetComponent<unitstate>().player;
	/*	if(baseplayer==1)
			cansave=true;
		else
			cansave=false;
		if(cansave)
			savefuction=GameObject.Find("ai").GetComponent<save>();*/
	}
	
	// Update is called once per frame
	void Update () {
		if(trainingtime>0)
		trainingtime-=Time.deltaTime;
		else if(trainingtime<=0&trainingtype>0)
		{

			if(trainingtype==1)
			{
				if(baseuint.transform.position.z<0)
					createworker = Instantiate(Resources.Load("worker"),new Vector3(baseuint.transform.position.x,1,baseuint.transform.position.z+0.5f),Quaternion.identity)as GameObject;
				if(baseuint.transform.position.z>0)
					createworker = Instantiate(Resources.Load("worker"),new Vector3(baseuint.transform.position.x,1,baseuint.transform.position.z-0.5f),Quaternion.identity)as GameObject;

				createworker.GetComponent<unitstate>().player=baseplayer;
				/*if(cansave)
				savefuction.adduint(1);*/
			}
			if(trainingtype==2)
			{
				if(baseuint.transform.position.z<0)
					createworker = Instantiate(Resources.Load("atker1"),new Vector3(baseuint.transform.position.x,1,baseuint.transform.position.z+0.5f),Quaternion.identity)as GameObject;
				if(baseuint.transform.position.z>0)
					createworker = Instantiate(Resources.Load("atker1"),new Vector3(baseuint.transform.position.x,1,baseuint.transform.position.z-0.5f),Quaternion.identity)as GameObject;

				createworker.GetComponent<unitstate>().player=baseplayer;
				/*if(cansave)
				savefuction.adduint(2);*/
			}
			if(trainingtype==3)
			{	if(baseuint.transform.position.z<0)
					createworker = Instantiate(Resources.Load("atker2"),new Vector3(baseuint.transform.position.x,1,baseuint.transform.position.z+0.5f),Quaternion.identity)as GameObject;
				if(baseuint.transform.position.z>0)
					createworker = Instantiate(Resources.Load("atker2"),new Vector3(baseuint.transform.position.x,1,baseuint.transform.position.z-0.5f),Quaternion.identity)as GameObject;
				createworker.GetComponent<unitstate>().player=baseplayer;
			}
			if(trainingtype==4)
			{
				if(baseuint.transform.position.z<0)
					createworker = Instantiate(Resources.Load("atker3"),new Vector3(baseuint.transform.position.x,1,baseuint.transform.position.z+0.5f),Quaternion.identity)as GameObject;
				if(baseuint.transform.position.z>0)
					createworker = Instantiate(Resources.Load("atker3"),new Vector3(baseuint.transform.position.x,1,baseuint.transform.position.z-0.5f),Quaternion.identity)as GameObject;

				createworker.GetComponent<unitstate>().player=baseplayer;
			}
			if(trainingtype==5)
			{
				if(baseuint.transform.position.z<0)
					createworker = Instantiate(Resources.Load("baseunit"),new Vector3(baseuint.transform.position.x,1,baseuint.transform.position.z+1.5f),Quaternion.identity)as GameObject;
				if(baseuint.transform.position.z>0)
					createworker = Instantiate(Resources.Load("baseunit"),new Vector3(baseuint.transform.position.x,1,baseuint.transform.position.z-1.5f),Quaternion.identity)as GameObject;

				createworker.GetComponent<unitstate>().player=baseplayer;
				/*if(cansave)
				savefuction.adduint(3);*/
			}
			if(trainingtype==99)
				speedlv++;
			trainingtype=0;
			trainingtime=0;


		}

		if(baseuint.GetComponent<unitstate>().selected){

		if(baseuint.GetComponent<unitstate>().selected&& Input.GetKeyDown("q"))
		{
			trainingworker();
		}
		if(baseuint.GetComponent<unitstate>().selected&& Input.GetKeyDown("w"))
		{
			trainingatker1();
		}
		if(baseuint.GetComponent<unitstate>().selected&& Input.GetKeyDown("e"))
		{
			trainingatker2();
		}
		if(baseuint.GetComponent<unitstate>().selected&& Input.GetKeyDown("r"))
		{
			trainingatker3();
		}
		if(baseuint.GetComponent<unitstate>().selected&& Input.GetKeyDown("b"))
		{
			trainingbaseunit();
		}
		if(baseuint.GetComponent<unitstate>().selected&& Input.GetKeyDown("s"))
		{
			
			if(speedlv<2)
			speedlvup();
			
			
			}
		
		}
	}
		void OnGUI()
		{

	/*	if(baseuint.GetComponent<unitstate>().selected)
				GUI.Label (new Rect(380,Screen.height-50,Screen.width,Screen.height/8),"training:  "+trainingtime);
		if(baseuint.GetComponent<unitstate>().selected)
			GUI.Label (new Rect(300,Screen.height-50,Screen.width,Screen.height/8),"upgrade: "+(speedlv));*/
		}

	public void trainingworker()
	{
		if(game1.players[baseplayer-1].gold>=300&&trainingtype==0)
		{
			game1.players[baseplayer-1].gold-=300;
			trainingtime=12-1*speedlv;
			trainingtype=1;
		}

	}
	public void trainingbaseunit()
	{
		if(game1.players[baseplayer-1].gold>=1200&&trainingtype==0)
		{
			game1.players[baseplayer-1].gold-=1200;
			trainingtime=35-4*speedlv;
			trainingtype=5;
		}
		
	}
	public void trainingatker1()
	{
		if(game1.players[baseplayer-1].gold>=450&&trainingtype==0)
		{
			game1.players[baseplayer-1].gold-=450;
			trainingtime=18-2*speedlv;
			trainingtype=2;
		}
		
	}
	public void trainingatker2()
	{
		if(game1.players[baseplayer-1].gold>=450&&trainingtype==0)
		{
			game1.players[baseplayer-1].gold-=450;
			trainingtime=18-2*speedlv;
			trainingtype=3;
		}
		
	}
	public void trainingatker3()
	{
		if(game1.players[baseplayer-1].gold>=450&&trainingtype==0)
		{
			game1.players[baseplayer-1].gold-=450;
			trainingtime=18-2*speedlv;
			trainingtype=4;
		}
		
	}
	public void speedlvup()
	{
		if(game1.players[baseplayer-1].gold>=350&&trainingtype==0)
		{
			game1.players[baseplayer-1].gold-=350;
			trainingtime=10;
			trainingtype=99;
		}


	}

}
