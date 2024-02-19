using UnityEngine;
using System.Collections;

public class cameracontrol : MonoBehaviour {
	private float speed=30f;
	bool push=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("right"))//||Input.mousePosition.x>Screen.width-20)
			this.gameObject.transform.Translate(-speed*Time.deltaTime,0,0);
		if(Input.GetKey("left"))//||Input.mousePosition.x<20)
			this.gameObject.transform.Translate(+speed*Time.deltaTime, 0,0);
		if(Input.GetKey("up"))//||Input.mousePosition.y>Screen.height-20)
			this.gameObject.transform.Translate(0,0,-speed*Time.deltaTime);
		if(Input.GetKey("down"))//||Input.mousePosition.y<20)
			this.gameObject.transform.Translate(0,0,+speed* Time.deltaTime);
		if (Input.GetKey ("h"))
						this.gameObject.transform.position = new Vector3 (11, 0, -6);
		/*if(Input.GetMouseButtonDown(2))
			push=true;
		if(Input.GetMouseButtonUp(2))
			push=false;
		if(push)
		{



		}*/
	}
}
