using UnityEngine;
using System.Collections;

public class option : MonoBehaviour {
	int[] itemnumber;
	string[] itemmessage;
	//Input oldkeyboard=new Input();
	public bool optionchecking=false;
	bool keyz,keyx,keyw,keya,keys,keyd;
	int selectitem=0;
	//bool oldkey=false;
	// Use this for initialization

	void Start () {
	//	oldkeyboard=Input;
		itemnumber = new int[1]{0};
		itemmessage = new string[1]{"箱子"};
		keya=keys=keyd=keyw=keyz=keyx=false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.X) && !keyx)
		{
			optionchecking=!optionchecking;
			print ("option");
			//if(optionchecking)

			if(!optionchecking)
				selectitem=0;
			
		}
		if(Input.GetKey(KeyCode.D) && !keyd && optionchecking)
		{
			if(selectitem<10)
			selectitem+=10;
			print (selectitem);
		}
		if(Input.GetKey(KeyCode.A) && !keya && optionchecking)
		{
			if(selectitem>=10)
				selectitem-=10;
			print (selectitem);
		}
		if(Input.GetKey(KeyCode.S) && !keys && optionchecking)
		{
			if(selectitem%10<=9&& selectitem<19)
				selectitem+=1;
			print (selectitem);
		}
		if(Input.GetKey(KeyCode.W) && !keyw && optionchecking)
		{
			if(selectitem%10>=0 && selectitem>0)
				selectitem-=1;
			print (selectitem);
		}
		keyx=Input.GetKey(KeyCode.X);
		keyz=Input.GetKey(KeyCode.Z);
		keyw=Input.GetKey(KeyCode.W);
		keya=Input.GetKey(KeyCode.A);
		keys=Input.GetKey(KeyCode.S);
		keyd=Input.GetKey(KeyCode.D);
	}
	void OnGUI()
	{
		if (optionchecking) {
			GUI.Box(new Rect(0,0,200,30),"道具");
			//	GUI.Label (new Rect(Screen.width/2-30,
			//	                    Screen.height/2-25,60,50),inf);
			GUI.Box(new Rect(0,30,Screen.width,Screen.height),"");
			GUI.Box(new Rect(0,Screen.height-Screen.height/4,Screen.width,Screen.height/4),"");
			GUI.Box(new Rect(0+(selectitem/10)*Screen.width/2,30+(selectitem%10)*20,Screen.width/2,20),"");
			GUI.Label (new Rect(0,30,Screen.width,30),itemmessage[0]+"x5");
			//選框

			
		}
	}



}
