using UnityEngine;
using System.Collections;

public class blocktest : MonoBehaviour {
	public GameObject unit;
	public float speed =0.5f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerStay(Collider other) 
	{
		if (other.tag == "block")
		{
			if(!unit.GetComponent<unitmove>().moveing)
		{
             /*   if(this.transform.position.z>other.transform.position.z)
                    unit.transform.Translate(0,0,speed);
                if(this.transform.position.z<other.transform.position.z)
                    unit.transform.Translate(0,0,-speed);
                if(this.transform.position.x>other.transform.position.x)
                    unit.transform.Translate(speed,0,0);
                if(this.transform.position.x<other.transform.position.x)
                    unit.transform.Translate(-speed,0,0);*/

                Vector3 backpos;
                Vector3 mypos = (unit.transform.position);
                backpos = new Vector3(mypos.x + (mypos.x - other.transform.position.x), mypos.y, mypos.z + (mypos.z - other.transform.position.z));
                unit.transform.position = Vector3.MoveTowards(mypos, backpos, 1f * Time.deltaTime);
              //  print(backpos);


                //print ("aaaa");
                //	this.renderer.material.color=Color.blue;
                //	movefunction.selected=true;
                //if(!keyPrev && keyNow)checking=true;
            }
		/*	if(unit.GetComponent<unitstate>().unittype!=1 && unit.GetComponent<unitmove>().moveing)
			{
				if(this.transform.position.z>other.transform.position.z)
					unit.transform.Translate(0,0,speed);
				if(this.transform.position.z<other.transform.position.z)
					unit.transform.Translate(0,0,-speed);
				if(this.transform.position.x>other.transform.position.x)
					unit.transform.Translate(speed,0,0);
				if(this.transform.position.x<other.transform.position.x)
					unit.transform.Translate(-speed,0,0);
				//print ("aaaa");
				//	this.renderer.material.color=Color.blue;
				//	movefunction.selected=true;
				//if(!keyPrev && keyNow)checking=true;
			}*/
		}
	}
	/*	void OnTriggerEnter(Collider other) 
		{
			
			if (other.tag == "block")
			{
				if(this.transform.position.z>other.transform.position.z)
					unit.transform.Translate(0,0,speed);
				if(this.transform.position.z<other.transform.position.z)
					unit.transform.Translate(0,0,-speed);
				if(this.transform.position.x>other.transform.position.x)
					unit.transform.Translate(speed,0,0);
				if(this.transform.position.x<other.transform.position.x)
					unit.transform.Translate(-speed,0,0);
				print ("aaaa");
				//	this.renderer.material.color=Color.blue;
				//	movefunction.selected=true;
				//if(!keyPrev && keyNow)checking=true;
			}
		}*/
		/*else
			this.renderer.material.color=Color.red;*/
		//			print("dddd");}
		//	else
		//	checking=false;
		

}
