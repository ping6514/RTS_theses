using UnityEngine;
using System.Collections;

public class unitmove : MonoBehaviour {

	public Vector3 movepos;
	public Vector3 nowpos;
	Vector3 xyz;
	public float speed=0.1f;
	public float dist=1.0f;
	Ray	moveray;
	RaycastHit[] hits;
	public bool selected=false;
	public bool moveing=false;
	//public bool canattack=true;
	public bool attacking=false;
	// Use this for initialization
	void Start () {
		movepos=this.gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	//	canattack=this.gameObject.GetComponent<unitstate>().canattack;
		attacking=this.GetComponent<unitstate>().attacking;
		if(Input.GetMouseButtonDown(0))
			selected=false;
		if(selected)
		mouseclick();


		xyz=(movepos-gameObject.transform.position);
		if((Mathf.Abs(xyz.x)+Mathf.Abs(xyz.y)+Mathf.Abs(xyz.z))>dist&&moveing)
			{	
				//this.gameObject.transform.Translate(new Vector3(0,0,speed*Time.deltaTime)/*,Space.Self*/);
			if(!attacking)
			this.gameObject.transform.position = Vector3.MoveTowards(this.transform.position,movepos,speed*Time.deltaTime);
			}
		else
			moveing=false;
		
	}

	void mouseclick()
	{
		if(Input.GetMouseButtonDown(1))
		{
			moveray=Camera.main.ScreenPointToRay(Input.mousePosition);
			Debug.DrawRay(Camera.main.transform.position,moveray.direction);
			hits=Physics.RaycastAll(Camera.main.transform.position,moveray.direction,10);
			for (var i = 0;i < hits.Length; i++)
			{
				if(hits[i].collider.tag=="floor")
				{
					movepos=hits[i].point;
					moveing=true;
				//	this.gameObject.transform.LookAt(movepos/*LookTarget.transform,Vector3(0,1,0)*/);
				}
			}
		
		}


	}

}
