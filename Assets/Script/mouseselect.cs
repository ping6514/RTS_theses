using UnityEngine;
using System.Collections;

public class mouseselect : MonoBehaviour {

	Vector3 oldpos;
	Vector3 endpos;
	Vector3 range;
	Ray	moveray;
	RaycastHit[] hits;
	float bb=2.0f;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButtonUp(0))
		{
			//this.gameObject.tag="selectbox";
			this.gameObject.transform.position=new Vector3(99,99,99);
		}


		//this.gameObject.tag="Untagged";
	if(Input.GetMouseButtonDown(0))
		{
		moveray=Camera.main.ScreenPointToRay(Input.mousePosition);
		Debug.DrawRay(Camera.main.transform.position,moveray.direction);
		hits=Physics.RaycastAll(Camera.main.transform.position,moveray.direction,10);
		for (var i = 0;i < hits.Length; i++)
		{
			if(hits[i].collider.tag=="floor")
			{
				oldpos=hits[i].point;
				//	this.gameObject.transform.position=new Vector3 (oldpos.x+0.1f,oldpos.y,oldpos.z-0.1f);
				//	bb = /*this.gameObject.GetComponent<Mesh>().bounds.size.x**/this.gameObject.transform.localScale.x;
				//	print (bb);
				//	this.gameObject.transform.localScale=new Vector3(0.2f,0.2f,0.2f);//=this.gameObject.transform.localScale.x(2);
				}
			}
		}
		if(Input.GetMouseButton(0))
		{
			moveray=Camera.main.ScreenPointToRay(Input.mousePosition);
			Debug.DrawRay(Camera.main.transform.position,moveray.direction);
			hits=Physics.RaycastAll(Camera.main.transform.position,moveray.direction,10);
			for (var i = 0;i < hits.Length; i++)
			{
				if(hits[i].collider.tag=="floor")
				{
					endpos=hits[i].point;
					range.x=endpos.x-oldpos.x;
					range.y=0.3f;
					range.z=endpos.z-oldpos.z;
					//    range= new Vector3 (endpos.x-oldpos.x,endposy-oldpos.y,endpos.z-endpos.z);
					this.gameObject.transform.position=new Vector3 (oldpos.x+(range.x/2),oldpos.y,oldpos.z+(range.z/2));
					//bb = /*this.gameObject.GetComponent<Mesh>().bounds.size.x**/this.gameObject.transform.localScale.x;
					//print (bb);
					this.gameObject.transform.localScale=range;//new Vector3(0.2f,0.2f,0.2f);//=this.gameObject.transform.localScale.x(2);
				}
			}
		}

	}
}
