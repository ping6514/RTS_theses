using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class game1 : MonoBehaviour {
	//public gameplayer players= new gameplayer[2]; 
	public gameplayer[] players=new gameplayer[2];
	public List<GameObject> units=new List<GameObject>();
	public List<GameObject> golds=new List<GameObject>();
	public GameObject showunit;
	public GameObject createunit=null;
	GUIStyle wordsize=new GUIStyle();
	public int p1score=0;
	public int p2score=0;
	private bool pauseEnabled= false;
	private bool gameover=false;
    private bool loading = false;
	float restarttime=5f;
	//int x=0;
	// Use this for initialization
	void Start () {

		players[0].gold=1500;
		players[1].gold=1500;
		players[0].baseunit=players[0].worker=players[0].attacker1=players[0].attacker2=players[0].attacker3=0;
		players[1].baseunit=players[0].worker=players[0].attacker1=players[0].attacker2=players[0].attacker3=0;
		players[0].playernumber=1;
		players[1].playernumber=2;
		wordsize.fontSize=16;
        wordsize.normal.textColor = Color.white;

        Time.timeScale = 2;

        //PREFS

        PlayerPrefs.SetInt("gamestep", 0);
        PlayerPrefs.SetString("oplayer1skill", "");
        PlayerPrefs.SetString("oplayer2skill", "");

        PlayerPrefs.SetString("nplayer1skill", "");
        PlayerPrefs.SetString("nplayer2skill", "");

        PlayerPrefs.SetString("oplayer1socre", "");
        PlayerPrefs.SetString("oplayer2socre", "");

        PlayerPrefs.SetString("nplayer1socre", "");
        PlayerPrefs.SetString("nplayer2socre", "");

    }
	
	// Update is called once per frame
	void Update () {




		if (Input.GetKeyDown ("m"))
		{
			Application.LoadLevel("01");
		}

        if (Input.GetKeyDown("q"))
        {
            savegamestate();
        }
        if (Input.GetKeyDown("w"))
        {
            loadgamestate();
        }
        if (Input.GetKeyDown("e"))
        {
            cleargamestate();
        }
        if (Input.GetKeyDown ("j") && !pauseEnabled)
		{

						Time.timeScale = 0;
					pauseEnabled=!pauseEnabled;

		}
		if ((Input.GetKeyDown ("k") && pauseEnabled)||gameover) 
		{
						Time.timeScale = 1;
					pauseEnabled=!pauseEnabled;
					
		}

		showunit=null;
		players[0].baseunit=players[0].worker=players[0].attacker1=players[0].attacker2=players[0].attacker3=0;
		players[1].baseunit=players[1].worker=players[1].attacker1=players[1].attacker2=players[1].attacker3=0;
		for(int x=0;x<units.Count;x++)
		{
			if(units[x].GetComponent<unitstate>().player==1)
				{
				if(units[x].GetComponent<unitstate>().unittype==0)
					players[0].baseunit++;
				if(units[x].GetComponent<unitstate>().unittype==1)
					players[0].worker++;
				if(units[x].GetComponent<unitstate>().unittype==2)
					players[0].attacker1++;
				if(units[x].GetComponent<unitstate>().unittype==3)
					players[0].attacker2++;
				if(units[x].GetComponent<unitstate>().unittype==4)
					players[0].attacker3++;

				}
			if(units[x].GetComponent<unitstate>().player==2)
			{
				if(units[x].GetComponent<unitstate>().unittype==0)
					players[1].baseunit++;
				if(units[x].GetComponent<unitstate>().unittype==1)
					players[1].worker++;
				if(units[x].GetComponent<unitstate>().unittype==2)
					players[1].attacker1++;
				if(units[x].GetComponent<unitstate>().unittype==3)
					players[1].attacker2++;
				if(units[x].GetComponent<unitstate>().unittype==4)
					players[1].attacker3++;
				
			}

		}
		p1score=0;
		p1score+=players[0].worker*5+players[0].baseunit*25+players[0].attacker1*7;
		p2score=0;
		p2score+=players[1].worker*5+players[1].baseunit*25+players[1].attacker1*7;

		//if(units.Count>0)
	/*	{int x=0;
			showunit=units[x];}*/
		for(int x=0;x<golds.Count;x++)
		{
			if(golds[x].GetComponent<goldmine>().selected)
			showunit=golds[x];
		}

		for(int x=0;x<units.Count;x++)
		{
			if(units[x].GetComponent<unitstate>().selected)
			{
				showunit=units[x];
			//	print (x);
			}
		}

		if(players[0].baseunit==0||players[1].baseunit==0)
		{
            //Time.timeScale = 0;
            if (players[0].baseunit == 0 && !gameover)
            {
                if (PlayerPrefs.GetInt("gamestep") == 0 || PlayerPrefs.GetInt("gamestep") == 1)
                {
                    GameObject.Find("ai").GetComponent<save>().saveover(true);
                }
                PlayerPrefs.SetString("gameover","lose");
            }
            if (players[1].baseunit == 0 && !gameover)
            {
                if (PlayerPrefs.GetInt("gamestep") == 0 || PlayerPrefs.GetInt("gamestep") == 1)
                {
                    GameObject.Find("ai").GetComponent<save>().saveover(false);
                }
                PlayerPrefs.SetString("gameover", "win");
            }
            if(!loading)
			gameover=true;
		}
		if(gameover)
		{
            if (PlayerPrefs.GetInt("gamestep") == 0 )
            {
                restarttime -= Time.deltaTime;
                if (restarttime <= 0)
                    Application.LoadLevel("01");
            }

            else if (PlayerPrefs.GetInt("gamestep") == 1)
            {
                GameObject.Find("ai").GetComponent<save>().savehistory(1);
                GameObject.Find("ai").GetComponent<gameai>().changeskilltime = 56;
                GameObject.Find("ai2").GetComponent<gameaib>().changeskilltime = 1;
                GameObject.Find("ai").GetComponent<gameai>().battleskill = 3;
                PlayerPrefs.SetString("nplayer1skill", "2, ");
                PlayerPrefs.SetString("nplayer2skill", "?, ");

                PlayerPrefs.SetString("nplayer1socre", "");
                PlayerPrefs.SetString("nplayer2socre", "");

                if(string.Equals( PlayerPrefs.GetString("gameover"),"win"))
                    PlayerPrefs.SetInt("game1over",1);
                else
                    PlayerPrefs.SetInt("game1over", 0);

                PlayerPrefs.SetInt("gamestep", 2);
                gameover = false;
                loadgamestate();

            }

            else if (PlayerPrefs.GetInt("gamestep") == 2)
            {
                GameObject.Find("ai").GetComponent<save>().savehistory(2);
                GameObject.Find("ai").GetComponent<gameai>().changeskilltime = 56;
                GameObject.Find("ai2").GetComponent<gameaib>().changeskilltime = 1;
                GameObject.Find("ai").GetComponent<gameai>().battleskill = 5;

                PlayerPrefs.SetString("nplayer1skill", "3, ");
                PlayerPrefs.SetString("nplayer2skill", "?, ");

                PlayerPrefs.SetString("nplayer1socre", "");
                PlayerPrefs.SetString("nplayer2socre", "");

                if (string.Equals(PlayerPrefs.GetString("gameover"), "win"))
                    PlayerPrefs.SetInt("game2over", 1);
                else
                    PlayerPrefs.SetInt("game2over", 0);

                PlayerPrefs.SetInt("gamestep", 3);
                gameover = false;
                loadgamestate();

            }
            else if (PlayerPrefs.GetInt("gamestep") == 3)
            {

                if (string.Equals(PlayerPrefs.GetString("gameover"), "win"))
                    PlayerPrefs.SetInt("game3over", 1);
                else
                    PlayerPrefs.SetInt("game3over", 0);

                GameObject.Find("ai").GetComponent<save>().savehistory(3);
                PlayerPrefs.SetInt("gamestep", 0);
                cleargamestate();
                Application.LoadLevel("01");

            }
        }
        loading = false;

    }

	void OnGUI()
	{
		if(gameover)
		{
			GUI.Box(new Rect(Screen.width/2,Screen.height/2,100,30),"gameover");
		}

        //PATCH
        GUI.Box(new Rect(0, 60, 100, 50), "25分的線");

        GUI.Box(new Rect(0,0,Screen.width,Screen.height/8),"");
		GUI.Label (new Rect(20,0,Screen.width,Screen.height/8)/*new Rect(0,Screen.height/2+Screen.height/4+25,Screen.width,Screen.height/4)*/,"player1:  "+players[0].gold,wordsize);
		GUI.Label (new Rect(20,15,Screen.width,Screen.height/8)/*new Rect(0,Screen.height/2+Screen.height/4+25,Screen.width,Screen.height/4)*/,"player2:  "+players[1].gold,wordsize);	
		GUI.Box(new Rect(0,(Screen.height/5)*4,Screen.width,Screen.height/4),"");
		if(showunit!=null&&showunit.tag=="unit")
		{
			GUI.Label (new Rect(20,Screen.height-50,Screen.width,Screen.height/8)/*new Rect(0,Screen.height/2+Screen.height/4+25,Screen.width,Screen.height/4)*/,"hp:  "+showunit.GetComponent<unitstate>().hp,wordsize );
			GUI.Label (new Rect(120,Screen.height-50,Screen.width,Screen.height/8)/*new Rect(0,Screen.height/2+Screen.height/4+25,Screen.width,Screen.height/4)*/,"atk:  "+showunit.GetComponent<unitstate>().atk,wordsize);
			GUI.Label (new Rect(220,Screen.height-50,Screen.width,Screen.height/8)/*new Rect(0,Screen.height/2+Screen.height/4+25,Screen.width,Screen.height/4)*/,"def:  "+showunit.GetComponent<unitstate>().def,wordsize);
			if(showunit.GetComponent<unitstate>().canattack)
				GUI.Label (new Rect(20,Screen.height-20,Screen.width,Screen.height/8),"canattack:O");
			else
				GUI.Label (new Rect(20,Screen.height-20,Screen.width,Screen.height/8),"canattack:X");

			if(showunit.GetComponent<unitstate>().unittype==0)
			{
				//if(baseuint.GetComponent<unitstate>().selected)
				GUI.Label (new Rect(380,Screen.height-50,Screen.width,Screen.height/8),"training:  "+showunit.GetComponent<createunit>().trainingtime);
				//if(baseuint.GetComponent<unitstate>().selected)
				GUI.Label (new Rect(300,Screen.height-50,Screen.width,Screen.height/8),"upgrade: "+showunit.GetComponent<createunit>().speedlv);
			}
		}
		if(showunit!=null&&showunit.tag=="gold")
		{
			GUI.Label (new Rect(20,Screen.height-50,Screen.width,Screen.height/8)/*new Rect(0,Screen.height/2+Screen.height/4+25,Screen.width,Screen.height/4)*/,"gold:  "+showunit.GetComponent<goldmine>().goldnumber,wordsize);

		}


		GUI.Label (new Rect(300,Screen.height-30,Screen.width,Screen.height/8),"score1:  "+p1score,wordsize );
		GUI.Label (new Rect(300,Screen.height-20,Screen.width,Screen.height/8),"score2:  "+p2score,wordsize);


        //GUI.Box(new Rect(0,0,200,25),"訊息框");
        GUI.Label(new Rect(220, 0, Screen.width, Screen.height / 8), "base: " + players[0].baseunit, wordsize);
        GUI.Label(new Rect(300, 0, Screen.width, Screen.height / 8), "worker: " + players[0].worker, wordsize);
        GUI.Label(new Rect(380, 0, Screen.width, Screen.height / 8), "atk1: " + players[0].attacker1, wordsize);
        GUI.Label(new Rect(460, 0, Screen.width, Screen.height / 8), "atk2: " + players[0].attacker2, wordsize);
        GUI.Label(new Rect(520, 0, Screen.width, Screen.height / 8), "atk3: " + players[0].attacker3, wordsize);

        GUI.Label(new Rect(220, 15, Screen.width, Screen.height / 8), "base: " + players[1].baseunit, wordsize);
        GUI.Label(new Rect(300, 15, Screen.width, Screen.height / 8), "worker: " + players[1].worker, wordsize);
        GUI.Label(new Rect(380, 15, Screen.width, Screen.height / 8), "atk1: " + players[1].attacker1, wordsize);
        GUI.Label(new Rect(460, 15, Screen.width, Screen.height / 8), "atk2: " + players[1].attacker2, wordsize);
        GUI.Label(new Rect(520, 15, Screen.width, Screen.height / 8), "atk3: " + players[1].attacker3, wordsize);

        /*	if(GUI.Button(new Rect(0,0,200,100),"button"))
            {

            }*/
        //if(GUI.Button (Rect (Screen.width/2+50,Screen.height/2-20,50,40), "加血")){

    }
    public struct gameplayer
	{
		public int gold;
		public int playernumber;
		public int worker;
		public int baseunit;
		public int attacker1;
		public int attacker2;
		public int attacker3;

		/*public gameplayer()
		{
			int gold=100;
		    int playernumber=0;

		}*/

	}

    public void savegamestate()
    {

        


        PlayerPrefs.SetInt("player1gold", players[0].gold);
        PlayerPrefs.SetInt("player2gold", players[1].gold);
        PlayerPrefs.SetInt("unitmax", units.Count);
        print("units.Count=  " + units.Count);
        for (int i = 0; i < units.Count; i++)
        {

            
            PlayerPrefs.SetFloat("unit_" + i + "_x", units[i].transform.position.x);
            PlayerPrefs.SetFloat("unit_" + i + "_z", units[i].transform.position.z);
            PlayerPrefs.SetInt("unit_" + i + "_player", units[i].GetComponent<unitstate>().player);
            PlayerPrefs.SetInt("unit_" + i + "_hp", units[i].GetComponent<unitstate>().hp);
            PlayerPrefs.SetInt("unit_" + i + "_unittype", units[i].GetComponent<unitstate>().unittype);

            if (units[i].GetComponent<unitstate>().unittype == 0)
            {
                PlayerPrefs.SetInt("unit_" + i + "_speedlv", units[i].GetComponent<createunit>().speedlv);
                if (units[i].GetComponent<createunit>().trainingtype == 1)
                {
                    PlayerPrefs.SetInt("unit_" + i + "_traintype", 1);
                    PlayerPrefs.SetFloat("unit_" + i + "_traintime", units[i].GetComponent<createunit>().trainingtime);

                }
                if (units[i].GetComponent<createunit>().trainingtype == 2)
                {
                    PlayerPrefs.SetInt("unit_" + i + "_traintype", 2);
                    PlayerPrefs.SetFloat("unit_" + i + "_traintime", units[i].GetComponent<createunit>().trainingtime);

                }
                if (units[i].GetComponent<createunit>().trainingtype == 5)
                {
                    PlayerPrefs.SetInt("unit_" + i + "_traintype", 5);
                    PlayerPrefs.SetFloat("unit_" + i + "_traintime", units[i].GetComponent<createunit>().trainingtime);

                }
            }
            if (units[i].GetComponent<unitstate>().unittype == 1)
            {
                if(units[i].GetComponent<miningfunction>().aa.havegold)
                PlayerPrefs.SetInt("unit_" + i + "_havegold", 1);
                else
                PlayerPrefs.SetInt("unit_" + i + "_havegold", 0);
            }
        }
    }

    public void loadgamestate()
    {
        loading = true;
        players[0].gold = PlayerPrefs.GetInt("player1gold");

        players[1].gold = PlayerPrefs.GetInt("player2gold");
        int formax = units.Count;
        for (int i = 0; i < formax; i++)
        {
            if (units[0] != null)
            {

               GameObject Destroyunit= units[0];
               Destroyunit.GetComponent<unitstate>().hp = -1;
               units.RemoveAt(0);
            }
        }
        formax = PlayerPrefs.GetInt("unitmax");
        for (int i=0;i<formax;i++)
            {
            print("i==" + i);
                if (PlayerPrefs.GetInt("unit_" + i + "_unittype") == 0)
                {
                    GameObject creatunit = Instantiate(Resources.Load("base"), new Vector3(PlayerPrefs.GetFloat("unit_" + i + "_x"), 1, PlayerPrefs.GetFloat("unit_" + i + "_z")), Quaternion.identity) as GameObject;
                    creatunit.GetComponent<unitstate>().player = PlayerPrefs.GetInt("unit_" + i + "_player");
                    creatunit.GetComponent<createunit>().speedlv = PlayerPrefs.GetInt("unit_" + i + "_speedlv");

                    creatunit.GetComponent<createunit>().trainingtime = PlayerPrefs.GetFloat("unit_" + i + "_traintime");

                   creatunit.GetComponent<createunit>().trainingtype = PlayerPrefs.GetInt("unit_" + i + "_traintype");
                creatunit.GetComponent<unitstate>().hp = PlayerPrefs.GetInt("unit_" + i + "_hp");
                }
                if (PlayerPrefs.GetInt("unit_" + i + "_unittype") == 1)
                {
                    GameObject creatunit = Instantiate(Resources.Load("worker"), new Vector3(PlayerPrefs.GetFloat("unit_" + i + "_x"), 1, PlayerPrefs.GetFloat("unit_" + i + "_z")), Quaternion.identity) as GameObject;
                    creatunit.GetComponent<unitstate>().player = PlayerPrefs.GetInt("unit_" + i + "_player");
                    bool havegold;
                    if (PlayerPrefs.GetInt("unit_" + i + "_havegold") == 1)
                    {
                        havegold = true;
                    }
                    else
                    {
                        havegold = false;
                    }
                  //  creatunit.GetComponent<miningfunction>().aa.havegold = havegold;
                    creatunit.GetComponent<unitstate>().hp = PlayerPrefs.GetInt("unit_" + i + "_hp");
                }

                if (PlayerPrefs.GetInt("unit_" + i + "_unittype") == 2)
                {
                    GameObject creatunit = Instantiate(Resources.Load("atker1"), new Vector3(PlayerPrefs.GetFloat("unit_" + i + "_x"), 1, PlayerPrefs.GetFloat("unit_" + i + "_z")), Quaternion.identity) as GameObject;
                    creatunit.GetComponent<unitstate>().player = PlayerPrefs.GetInt("unit_" + i + "_player");
                    creatunit.GetComponent<unitstate>().hp = PlayerPrefs.GetInt("unit_" + i + "_hp");
                }
                if (PlayerPrefs.GetInt("unit_" + i + "_unittype") == 5)
                {
                    GameObject creatunit = Instantiate(Resources.Load("baseunit"), new Vector3(PlayerPrefs.GetFloat("unit_" + i + "_x"), 1, PlayerPrefs.GetFloat("unit_" + i + "_z")), Quaternion.identity) as GameObject;
                    creatunit.GetComponent<unitstate>().player = PlayerPrefs.GetInt("unit_" + i + "_player");
                    creatunit.GetComponent<unitstate>().hp = PlayerPrefs.GetInt("unit_" + i + "_hp");
                }


            }
        GameObject.Find("ai").GetComponent<gameai>().oldcount = 99;
        GameObject.Find("ai2").GetComponent<gameaib>().oldcount = 99;


        // loading = false;

    }


    public void cleargamestate()
    {
        PlayerPrefs.DeleteAll();

    }

    public void addaiunit(int ai,GameObject unit)
    {


    }


}
