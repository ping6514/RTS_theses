using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class battle : MonoBehaviour {
	public List<GameObject> targets = new List<GameObject>();
	public int thisplayer=1;
	public GameObject thisuint;
	public int atk;
	public int type;
	public int enemydef;
	public float time=0f;
	public bool canattack=true;
	public List<GameObject> units;
	private int atknumber=0;
	private float atkrangtime=0f;
	// Use this for initialization
	void Start () {
		thisplayer = thisuint.GetComponent<unitstate>().player;
		atk=thisuint.GetComponent<unitstate>().atk;
		type=thisuint.GetComponent<unitstate>().unittype;
		units=GameObject.Find("gamecontrol").GetComponent<game1>().units;

	}
	
	// Update is called once per frame
	void Update () {
        if (units == null)
        {

            units = GameObject.Find("gamecontrol").GetComponent<game1>().units;
        }


		//thisplayer = this.gameObject.GetComponent<unitstate>().player;
		canattack=thisuint.GetComponent<unitstate>().canattack;
		if(time>0)
		time-=Time.deltaTime;

		atkrangtime-=Time.deltaTime;

		if(atkrangtime<=0&&canattack)
		{
			attackrange();
			atkrangtime=1f;
		}
		if(targets.Count>0&&canattack)
		{
			thisuint.GetComponent<unitstate>().attacking=true;
			//clear

			if(time<=0)
			for(int x=0;x<targets.Count;x++)
				if(targets[x]==null)
			{
				//print ("zzzzz");
				targets.RemoveAt(0);
			}

			if(time<=0)
			{
				for(int x=0;x<targets.Count;x++)			
				{

					if(targets[x]!=null){
						int nowatk=atk;
						if(type==2&&targets[x].GetComponent<unitstate>().unittype==3)
							 nowatk=atk+5;
						if(type==23&&targets[x].GetComponent<unitstate>().unittype==4)
							 nowatk=atk+5;
						if(type==4&&targets[x].GetComponent<unitstate>().unittype==1)
							 nowatk=atk+5;
					targets[x].GetComponent<unitstate>().hp-=(nowatk-targets[x].GetComponent<unitstate>().def);

					if(targets[x].GetComponent<unitstate>().hp<=0)
						targets.Remove(targets[x]);
					}
					break;
				}
				time=1.5f;
			}

		}
		else
			thisuint.GetComponent<unitstate>().attacking=false;

	}
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "unit")
		{

			if(other.GetComponent<unitstate>().player!=thisplayer)
			{
				//print ("tttt");
				targets.Add(other.gameObject);
			}
		}
	}
	void OnTriggerExit(Collider other) 
	{
		if (other.tag == "unit")
			if(other.GetComponent<unitstate>().player!=thisplayer)
			targets.Remove(other.gameObject);
	}

	void attackrange()
	{
	
		atknumber=0;
		for(int x=0;x<units.Count;x++)
		{

			//units[atknumber]<=units[x] && 
			if(units[x].GetComponent<unitstate>().player!=thisplayer)
			{
				if(Vector3.Distance (this.transform.position,units[x].transform.position) < 3.0f)
				{
					atknumber=x;
					//print ("zzzzz");
				}
			}
		}

		if(units[atknumber].GetComponent<unitstate>().player!=thisplayer&&Vector3.Distance (this.transform.position,units[atknumber].transform.position) < 3.0f)
		{	
			thisuint.GetComponent<unitmove>().movepos = units[atknumber].transform.position;
			thisuint.GetComponent<unitmove>().moveing = true;
		}


	}
}
