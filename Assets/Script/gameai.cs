using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class gameai : MonoBehaviour {

	public List<GameObject> units=new List<GameObject>();
	public List<GameObject> enemyunits=new List<GameObject>();
	public List<GameObject> enemyatkers=new List<GameObject>();
	public List<GameObject> enemyworkers=new List<GameObject>();
	public List<GameObject> myworks=new List<GameObject>();
	public List<GameObject> mybases=new List<GameObject>();
	public List<GameObject> mybaseunits=new List<GameObject>();
	public List<GameObject> myatkers=new List<GameObject>();
	public atkteam atkteam1=new atkteam();
	public atkteam atkteam2=new atkteam();
	public game1 gamecon;//=GameObject.Find("gamecontrol").GetComponent<game1>();
	public int battlestyle=0;
	public int battleskill=99;
    public int strategy = 99;
	public float changeskilltime=5;
	public int ainumber=1;
	public float randomnumber=99;
	bool aiopen=false;
	public List<Vector3> basepoint =new List<Vector3>();
	GUIStyle wordsize=new GUIStyle();
	float waittime=0;
	public int playernumber=1;
	public int oldcount=1;
	Vector3[] goldarea = new Vector3[3];
	public GameObject[] basearea = new GameObject[3];
	public GameObject enemybase;
	public List<Vector3> enemybasepos=new List<Vector3>();
	public bool cansavedata=false;
	bool savechange=false;
	public int p1score,p2score;
	public int wishbattle=99; 
	bool creatbaseing=false;
    /// </0517new>

    public int battleassess = 3;
    public int economicassess = 3;
    public int scoreassess = 3;

    public double scoretemp;
    public double economictemp;
    public double battletemp;
    /// //////
    /// </summary>
    // Use this for initialization
    void Start () {
		wordsize.fontSize=18;
        wordsize.normal.textColor = Color.black;
        gamecon =GameObject.Find("gamecontrol").GetComponent<game1>();
		for (int x=0; x<3; x++) 
		{
			goldarea[x]= basearea[x].transform.position;

		}


		p1score = gamecon.p1score;
		p2score = gamecon.p2score;
	}
	
	// Update is called once per frame
	void Update () {
		///save
		if(cansavedata && savechange)
		{
			this.gameObject.GetComponent<save>().savedata();
			savechange=false;
		}

        /////////////
        waittime -= Time.deltaTime;
        p1score = gamecon.p1score;
		p2score = gamecon.p2score;


		if(oldcount!=gamecon.units.Count)
		{
			units.Clear();
			enemyunits.Clear();
			for(int x=0;x<gamecon.units.Count;x++)
				if(gamecon.units[x].GetComponent<unitstate>().player==playernumber)
			units.Add(gamecon.units[x]);
			else if(gamecon.units[x].GetComponent<unitstate>().player!=playernumber)
				enemyunits.Add(gamecon.units[x]);
			///class
			/// 
			myworks.Clear();
			mybases.Clear();
			mybaseunits.Clear();
			myatkers.Clear();
			basepoint.Clear();
			enemybasepos.Clear();
			enemyatkers.Clear();
			enemyworkers.Clear();
			/// 
			for(int x=0;x<units.Count;x++)
			{
				if(units[x].GetComponent<unitstate>().unittype==1)
				{
					myworks.Add(units[x]);
	
				}
						
				if(units[x].GetComponent<unitstate>().unittype==5)
				{
					myworks.Add(units[x]);
					
				}
				if(units[x].GetComponent<unitstate>().unittype==0)
				{
					mybases.Add(units[x]);
					if(units[x].transform.position.z<0)
					basepoint.Add(new Vector3 (units[x].transform.position.x-2,units[x].transform.position.y,units[x].transform.position.z+2));
					if(units[x].transform.position.z>0)
					basepoint.Add(new Vector3 (units[x].transform.position.x+2,units[x].transform.position.y,units[x].transform.position.z-2));

					
				}
				if(units[x].GetComponent<unitstate>().unittype==2||units[x].GetComponent<unitstate>().unittype==3||units[x].GetComponent<unitstate>().unittype==4)
				{
					myatkers.Add(units[x]);
					
				}
			}
			///////
			/// 
			for(int x=0;x<enemyunits.Count;x++)
			{
				if(enemyunits[x].GetComponent<unitstate>().unittype==0)
				{

					if(enemyunits[x].transform.position.z<0)
						enemybasepos.Add(new Vector3 (enemyunits[x].transform.position.x-2,enemyunits[x].transform.position.y,enemyunits[x].transform.position.z+2));
					if(enemyunits[x].transform.position.z>0)
						enemybasepos.Add(new Vector3 (enemyunits[x].transform.position.x+2,enemyunits[x].transform.position.y,enemyunits[x].transform.position.z-2));


				}
				if(enemyunits[x].GetComponent<unitstate>().unittype==2||enemyunits[x].GetComponent<unitstate>().unittype==3||enemyunits[x].GetComponent<unitstate>().unittype==4)
				{
					enemyatkers.Add(enemyunits[x]);
					
				}
				if(enemyunits[x].GetComponent<unitstate>().unittype==1)
				{
					enemyworkers.Add(enemyunits[x]);
				}
			}
			/// 

			oldcount=gamecon.units.Count;
		}
        /////////////////
        /// checkcreate
        creatbaseing = false;
        for (int x = 0; x < mybases.Count; x++)
            if (mybases[x].GetComponent<createunit>().trainingtype == 5)
                creatbaseing = true;
        /// 

        if (changeskilltime>0)
			changeskilltime-=Time.deltaTime;


		if(changeskilltime<=0 )
		{

            ///////<0517new>
            if (myatkers.Count > 5 && enemyatkers.Count > 5)
            {
                battletemp = (float)myatkers.Count / (float)(myatkers.Count + enemyatkers.Count);
                battletemp = System.Math.Round(battletemp, 2);
            }
            else
            {
                if ((myatkers.Count - enemyatkers.Count) >= 3)
                {
                    battletemp = 0.7;
                }
                else if ((myatkers.Count - enemyatkers.Count) >= 2)
                {
                    battletemp = 0.6;
                }
                else if ((myatkers.Count - enemyatkers.Count) == 0)
                {
                    battletemp = 0.5;
                }
                else if ((myatkers.Count - enemyatkers.Count) <= -2)
                {
                    battletemp = 0.4;
                }
                else if ((myatkers.Count - enemyatkers.Count) <= -1)
                {
                    battletemp = 0.3;
                }


            }

            ////處理
         /*   if (myatkers.Count == 0)
            {
                battletemp = 0;
                if (enemyatkers.Count == 0 && myatkers.Count == 0)
                    battletemp = 0.5;
            }
            else if (enemyatkers.Count == 0 && myatkers.Count > 0)
                battletemp = 1.00;

            else
                battletemp = System.Math.Round(battletemp, 2);*/
            ////


            if (battletemp >= 0.7)
                battleassess = 5;
            else if (battletemp >= 0.6)
                battleassess = 4;
            else if (battletemp >= 0.50)
                battleassess = 3;
            else if (battletemp >= 0.4)
                battleassess = 2;
            else
                battleassess = 1;

            economictemp = (float)(myworks.Count + (mybases.Count * 4)) / (float)((myworks.Count + (mybases.Count * 4)) + (enemyworkers.Count + (enemybasepos.Count * 4)));
            ////處理
            economictemp = System.Math.Round(economictemp, 2);
            ////
            if (economictemp >= 0.6)
                economicassess = 5;
            else if (economictemp >= 0.55)
                economicassess = 4;
            else if (economictemp >= 0.5)
                economicassess = 3;
            else if (economictemp >= 0.45)
                economicassess = 2;
            else
                economicassess = 1;

            scoretemp = (float)gamecon.p1score / (float)(gamecon.p1score + gamecon.p2score);
            ////處理
            scoretemp = System.Math.Round(scoretemp, 2);
            ////
            if (scoretemp >= 0.6)
                scoreassess = 5;
            else if (scoretemp >= 0.55)
                scoreassess = 4;
            else if (scoretemp >= 0.5)
                scoreassess = 3;
            else if (scoretemp >= 0.45)
                scoreassess = 2;
            else
                scoreassess = 1;





            print("tempbattle:" + battletemp + " battleasscess:" + battleassess);
            print("economictemp:" + economictemp + " economicassess:" + economicassess);
            print("scoretemp:" + scoretemp + " scoreassess:" + scoreassess);



            ///////


            if (battleskill==99)
			{
				randomnumber=Random.Range(0,6);
				if(randomnumber<=1)
				{
					battleskill=1;
					atkteam1.atkers.Clear();			
					atkteam1.atkers.AddRange(myatkers);
                    strategy = 1;
					
				}
				else if(randomnumber<=2)
				{
					battleskill=2;
					atkteam1.atkers.Clear();
					atkteam1.atkers.AddRange(myatkers);
                    strategy = 1;
				}
				else if(randomnumber<=3)
				{
					battleskill=3;
					atkteam1.atkers.Clear();
					atkteam1.atkers.AddRange(myatkers);
                    strategy = 2;
				}
				else if(randomnumber<=4)
				{
					battleskill=4;
					atkteam1.atkers.Clear();
					atkteam1.atkers.AddRange(myatkers);
                    strategy = 2;
				}
				else if(randomnumber<=5)
				{
					battleskill=5;
					atkteam1.atkers.Clear();
					atkteam1.atkers.AddRange(myatkers);
                    strategy = 3;
				}
				else if(randomnumber<=6)
				{
					battleskill=6;
					atkteam1.atkers.Clear();
					atkteam1.atkers.AddRange(myatkers);
                    strategy = 3;
				}
                //測試
                //battleskill = 1;
            }
		//	if(p1score-p2score>20)
		//		battleskill=battleskill;
		//	else
		//	{
				/////        specail
			else{
				randomnumber=Random.Range(0,11);
				if(randomnumber>=3){//原本3
                                    //發展度運算

                    /*   float  develop1 = (mybases.Count * 0.2f) + (myworks.Count * 0.019f);
                       float  develop2 = (enemybasepos.Count * 0.2f) + (enemyworkers.Count * 0.019f);*/


                    /*    if ((battletemp * (4.63730596781507f) + economictemp * (0.188386625258083f) + scoretemp * (2.56542890980788f)
                        + (myatkers.Count * 0.01f) * (1.56327334124323f) + (enemyatkers.Count * 0.01f) * (-0.310274520013349f)
                        + (mybases.Count * 0.333f) * (-1.15960555218015f) + (enemybasepos.Count * 0.333f) * (1.15283900259509f)) - 3.97941f > 0)
                            strategy = 1;*/


                    //第一版投影手動修正2-------------------0414

                    /*    if ((battletemp * (3.98503950596628f) + economictemp * (0.157162213751732f) + scoretemp * (1.85072682309071f)
                        + (myatkers.Count * 0.01f) * (0.781823934269942f) + (enemyatkers.Count * 0.01f) * (-0.453798789935482f)
                        + (mybases.Count * 0.333f) * (-0.185178632370521f) + (enemybasepos.Count * 0.333f) * (0.22166312791178f)) - 2.99902f > 0)
                            strategy = 1;*/

                    //第二版原始模型
                    /* if ((battletemp * (5.60000203847885f) + economictemp * (-0.313369718764335f) + scoretemp * (0.808302217877966f)
                     + (myatkers.Count * 0.01f) * (-0.760945371815293f) + (enemyatkers.Count * 0.01f) * (-1.02094534797343f)
                     + (mybases.Count * 0.333f) * (-0.295656044091324f) + (enemybasepos.Count * 0.333f) * (0.370343964491745f)) - 2.64923f > 0)
                         strategy = 1;*/





                    //  if ((battleassess >= 4 && economicassess>=2)|| battleassess>=5)
                    //10分的線
                    /*   if ((battletemp * (6.78574575459619f) + economictemp * (0.715543111148683f) + scoretemp * (4.19712795300032f)
                        + (myatkers.Count * 0.01f) * (2.31533734573608f) + (enemyatkers.Count * 0.01f) * (0.239210889061675f)
                        + (mybases.Count * 0.333f) * (-0.278478649479844f) + (enemybasepos.Count * 0.333f) * (4.27595375073138f)) - 8.18047f > 0)*/

                    //15分的線
                    /* if ((battletemp * (4.81550146530073f) + economictemp * (0.172528236413996f) + scoretemp * (2.25122738833429f)
                      + (myatkers.Count * 0.01f) * (1.71057616929167f) + (enemyatkers.Count * 0.01f) * (-0.21653471249411f)
                      + (mybases.Count * 0.333f) * (-1.81310123801175f) + (enemybasepos.Count * 0.333f) * (2.13600626014891f)) - 3.3068f > 0)*/
                    //20分的線
                  /*   if ((battletemp * (5.25000045597553f) + economictemp * (0.508700544046306f) + scoretemp * (2.98469443965003f)
                      + (myatkers.Count * 0.01f) * (1.4909452392517f) + (enemyatkers.Count * 0.01f) * (-0.387524516339797f)
                      + (mybases.Count * 0.333f) * (-1.49255038799129f) + (enemybasepos.Count * 0.333f) * (1.7669390920574)) - 4.17785f > 0)*/
                    //25分的線
                    if ((battletemp * (5.51068504029777f) + economictemp * (0.0647598290812965f) + scoretemp * (2.76678042669828f)
                        + (myatkers.Count * 0.01f) * (0.874074823243733f) + (enemyatkers.Count * 0.01f) * (-1.48660982177504f)
                        + (mybases.Count * 0.333f) * (-1.25102988654333f) + (enemybasepos.Count * 0.333f) * (1.54639959838132f)) - 3.96724 > 0)
                            strategy = 1;
                    else if (battleassess >= 3 && economicassess>=3)
                        strategy = 2;
                    else// if (battleassess <= 2 && economicassess<=2)
                        strategy = 3;




                    if (strategy == 1)
                    {
                        if (battleassess >= 4 && enemybasepos.Count > 2)
                        {

                            battleskill = 2;
                            atkteam1.atkers.Clear();
                            atkteam1.atkers.AddRange(myatkers);
                        }

                        else
                        {

                            battleskill = 1;
                            atkteam1.atkers.Clear();
                            atkteam1.atkers.AddRange(myatkers);
                        }
                    
                    }
                    else if (strategy == 2)
                    {
                        if (battleassess > 3 && scoreassess >= 3)
                        {

                            battleskill = 3;
                            atkteam1.atkers.Clear();
                            atkteam1.atkers.AddRange(myatkers);
                        }

                        else 
                        {
                            battleskill = 4;
                            atkteam1.atkers.Clear();
                            atkteam1.atkers.AddRange(myatkers);
                        }

                    }
                    else if (strategy == 3)
                    {
                       /* if (battleassess >= 2 && economicassess >= 2)
                        {


                            battleskill = 6;
                            atkteam1.atkers.Clear();
                            atkteam1.atkers.AddRange(myatkers);
                        }
                        */
                     //   else
                   //     {

                            battleskill = 5;
                            atkteam1.atkers.Clear();
                            atkteam1.atkers.AddRange(myatkers);

                        
                    //    }
                    
                    }
                    #region oldrule
                    /*  
                       if (battleassess >= 4 && enemybasepos.Count > 2)
                       {

                           battleskill = 2;
                           atkteam1.atkers.Clear();
                           atkteam1.atkers.AddRange(myatkers);
                       }


                       else if (battleassess >= 2 && scoreassess >= 3)
                       {

                           battleskill = 3;
                           atkteam1.atkers.Clear();
                           atkteam1.atkers.AddRange(myatkers);
                       }

                       else if (battleassess >= 2 && economicassess >= 3)
                       {

                           battleskill = 4;
                           atkteam1.atkers.Clear();
                           atkteam1.atkers.AddRange(myatkers);
                       }
                       else if (battleassess >= 3 && scoreassess >= 2)
                       {

                           battleskill = 1;
                           atkteam1.atkers.Clear();
                           atkteam1.atkers.AddRange(myatkers);
                       }
                       else if (battleassess >= 4 && economicassess >= 2)
                       {


                           battleskill = 6;
                           atkteam1.atkers.Clear();
                           atkteam1.atkers.AddRange(myatkers);
                       }
                       else
                       {

                           battleskill = 5;
                           atkteam1.atkers.Clear();
                           atkteam1.atkers.AddRange(myatkers);
                       }
                       */
                    #endregion




                }
                else
                {

					randomnumber=Random.Range(0,6);
					if(randomnumber<=1)
					{
						battleskill=1;
						atkteam1.atkers.Clear();			
						atkteam1.atkers.AddRange(myatkers);
                        strategy = 1;


                    }
					else if(randomnumber<=2)
					{
						battleskill=2;
						atkteam1.atkers.Clear();
						atkteam1.atkers.AddRange(myatkers);
                        strategy = 1;
                    }
					else if(randomnumber<=3)
					{
						battleskill=3;
						atkteam1.atkers.Clear();
						atkteam1.atkers.AddRange(myatkers);
                        strategy = 2;
                    }
					else if(randomnumber<=4)
					{
						battleskill=4;
						atkteam1.atkers.Clear();
						atkteam1.atkers.AddRange(myatkers);
                        strategy = 2;
                    }
					else if(randomnumber<=5)
					{
						battleskill=5;
						atkteam1.atkers.Clear();
						atkteam1.atkers.AddRange(myatkers);
                        strategy = 3;
                    }
					else if(randomnumber<=6)
					{
                        battleskill=6;
						atkteam1.atkers.Clear();
						atkteam1.atkers.AddRange(myatkers);
                        strategy = 3;

                    }
					
				}
			}
		/*	if((playernumber==1&&gamecon.p1score-gamecon.p2score>50)||(playernumber==2&&gamecon.p2score-gamecon.p1score>50))
			{
				battleskill=7;
				atkteam1.atkers.Clear();			
				atkteam1.atkers.AddRange(myatkers);
                strategy = 4;

            }*/
			//}

			savechange=true;
			changeskilltime=55;
		}

		if(waittime<=0){

			if(battleskill==1)
			{
				battleskill1();

			}
			if(battleskill==2)
			{
				battleskill2();
				
			}
			if(battleskill==3)
			{
				battleskill3();
				
			}
			if(battleskill==4)
			{
				battleskill4();
				
			}
			if(battleskill==5)
			{
				battleskill5();
				
			}
			if(battleskill==6)
			{
				battleskill6();
				
			}
			if(battleskill==7)
			{
				battleskill7();
				
			}
			if(myatkers.Count-enemyatkers.Count<-2)
			{
				for(int x=0;x<myworks.Count;x++)
					myworks[x].GetComponent<unitstate>().canattack=true;
			}
			else
			{
				for(int x=0;x<myworks.Count;x++)
					myworks[x].GetComponent<unitstate>().canattack=false;
			}

			waittime=2f;
		}



	}
	/// <summary>
	/// attackface	/// </summary>
	void battleskill1()
	{


	
		for(int x=0;x<units.Count;x++)
		{
			if(units[x].GetComponent<unitstate>().unittype==0)
			{
				int nearworks=0;
				for(int z=0;z<myworks.Count;z++)
				{	if (Vector3.Distance(myworks[z].transform.position, units[x].transform.position) < 5.0f)
					{
						nearworks++;
					
					}
				}

				if(gamecon.players[playernumber-1].gold>=300&&nearworks<5)
					units[x].GetComponent<createunit>().trainingworker();
				if(gamecon.players[playernumber-1].gold>=500&&units[x].GetComponent<createunit>().speedlv<3&&nearworks>=4)
					units[x].GetComponent<createunit>().speedlvup();
				if(gamecon.players[playernumber-1].gold>=450&&nearworks>=5)
					units[x].GetComponent<createunit>().trainingatker1();




				
				
				
			}
			if(units[x].GetComponent<unitstate>().unittype==1)
			{
				units[x].GetComponent<miningfunction>().gomining();


			}		
			if(units[x].GetComponent<unitstate>().unittype==5)
			{
				if(mybases.Count<3){
					units[x].GetComponent<unitmove>().movepos=goldarea[mybases.Count];
					units[x].GetComponent<unitmove>().moveing=true;
				}
			}

		

		}
		attackerenemymainbase();
	}
	void battleskill2()
	{
		
		
		
		for(int x=0;x<units.Count;x++)
		{
			if(units[x].GetComponent<unitstate>().unittype==0)
			{
				int nearworks=0;
				for(int z=0;z<myworks.Count;z++)
				{	if (Vector3.Distance(myworks[z].transform.position, units[x].transform.position) < 5.0f)
					{
						nearworks++;
						
					}
				}
				
				if(gamecon.players[playernumber-1].gold>=300&&nearworks<5)
					units[x].GetComponent<createunit>().trainingworker();
				if(gamecon.players[playernumber-1].gold>=500&&units[x].GetComponent<createunit>().speedlv<3&&nearworks>=4)
					units[x].GetComponent<createunit>().speedlvup();
				if(gamecon.players[playernumber-1].gold>=450&&nearworks>=5)
					units[x].GetComponent<createunit>().trainingatker1();
				
				
				
				
				
				
				
			}
			if(units[x].GetComponent<unitstate>().unittype==1)
			{
				units[x].GetComponent<miningfunction>().gomining();
				
				
			}		
			if(units[x].GetComponent<unitstate>().unittype==5)
			{
				if(mybases.Count<3){
					units[x].GetComponent<unitmove>().movepos=goldarea[mybases.Count];
					units[x].GetComponent<unitmove>().moveing=true;
				}
			}
			
			
			
		}
		attackerenemytwoway();
	}
	void battleskill3()
	{
		
		
		//	basepoint.Clear ();
		for(int x=0;x<units.Count;x++)
		{
			if(units[x].GetComponent<unitstate>().unittype==0)
			{
				int nearworks=0;
				for(int z=0;z<myworks.Count;z++)
				{	if (Vector3.Distance(myworks[z].transform.position, units[x].transform.position) < 5.0f)
					{
						nearworks++;
						
					}
				}
				if(gamecon.players[playernumber-1].gold>=1200&&mybases.Count+mybaseunits.Count<3&&!creatbaseing)
                        units[x].GetComponent<createunit>().trainingbaseunit();

				if(gamecon.players[playernumber-1].gold>=300&&nearworks<7)
					units[x].GetComponent<createunit>().trainingworker();

				if(gamecon.players[playernumber-1].gold>450&&nearworks>=7&&mybases.Count>=3)
					units[x].GetComponent<createunit>().trainingatker1();
				
				



				
				
				
			}
			if(units[x].GetComponent<unitstate>().unittype==1)
			{
				units[x].GetComponent<miningfunction>().gomining();
				
				
			}		
			if(units[x].GetComponent<unitstate>().unittype==5)
			{
				if(mybases.Count<3){
					units[x].GetComponent<unitmove>().movepos=goldarea[mybases.Count];
					units[x].GetComponent<unitmove>().moveing=true;
				}
			}
			

			
		}
		defencerun();
	}

	void battleskill4()
	{
		
		
		//	basepoint.Clear ();
		for(int x=0;x<units.Count;x++)
		{
			if(units[x].GetComponent<unitstate>().unittype==0)
			{
				int nearworks=0;
				for(int z=0;z<myworks.Count;z++)
				{	if (Vector3.Distance(myworks[z].transform.position, units[x].transform.position) < 5.0f)
					{
						nearworks++;
						
					}
				}
				if(gamecon.players[playernumber-1].gold>450&&enemyatkers.Count>=myatkers.Count+2 )
					units[x].GetComponent<createunit>().trainingatker1();
				if(gamecon.players[playernumber-1].gold>=1200&&mybases.Count+mybaseunits.Count<2&&!creatbaseing)
					units[x].GetComponent<createunit>().trainingbaseunit();
				
				if(gamecon.players[playernumber-1].gold<=1200&&nearworks<7)
					units[x].GetComponent<createunit>().trainingworker();
				
				if(mybases.Count>=2&&gamecon.players[playernumber-1].gold>450&&nearworks>=7)
					units[x].GetComponent<createunit>().trainingatker1();
				
				
				
				
				
				
				
			}
			if(units[x].GetComponent<unitstate>().unittype==1)
			{
				units[x].GetComponent<miningfunction>().gomining();
				
				
			}		
			if(units[x].GetComponent<unitstate>().unittype==5)
			{
				if(mybases.Count<3){
					units[x].GetComponent<unitmove>().movepos=goldarea[mybases.Count];
					units[x].GetComponent<unitmove>().moveing=true;
				}
			}
			
			
			
		}
		defencerun();
	}
	void battleskill5()
	{
		
		
		//	basepoint.Clear ();
		for(int x=0;x<units.Count;x++)
		{
			if(units[x].GetComponent<unitstate>().unittype==0)
			{
				int nearworks=0;
				for(int z=0;z<myworks.Count;z++)
				{	if (Vector3.Distance(myworks[z].transform.position, units[x].transform.position) < 5.0f)
					{
						nearworks++;
						
					}
				}
                if (gamecon.players[playernumber - 1].gold >= 500 && units[x].GetComponent<createunit>().speedlv < 3 && nearworks >= 4)
                    units[x].GetComponent<createunit>().speedlvup();

                if (gamecon.players[playernumber - 1].gold >= 300 && nearworks < 6 && enemyatkers.Count <= myatkers.Count)
                    units[x].GetComponent<createunit>().trainingworker();

                if (gamecon.players[playernumber - 1].gold > 450)
                    units[x].GetComponent<createunit>().trainingatker1();








            }
			if(units[x].GetComponent<unitstate>().unittype==1)
			{
				units[x].GetComponent<miningfunction>().gomining();
				
				
			}		
			if(units[x].GetComponent<unitstate>().unittype==5)
			{
				if(mybases.Count<3){
				units[x].GetComponent<unitmove>().movepos=goldarea[mybases.Count];
				units[x].GetComponent<unitmove>().moveing=true;
				}
			}
			
			
			
		}
		defencerun();
	}

	void battleskill6()
	{
		
		
		//	basepoint.Clear ();
		for(int x=0;x<units.Count;x++)
		{
			if(units[x].GetComponent<unitstate>().unittype==0)
			{
				int nearworks=0;
				for(int z=0;z<myworks.Count;z++)
				{	if (Vector3.Distance(myworks[z].transform.position, units[x].transform.position) < 5.0f)
					{
						nearworks++;
						
					}
				}
                if (gamecon.players[playernumber - 1].gold >= 300 && nearworks < 5 && enemyatkers.Count <= myatkers.Count)
                    units[x].GetComponent<createunit>().trainingworker();
                if (gamecon.players[playernumber - 1].gold >= 500 && units[x].GetComponent<createunit>().speedlv < 3 && nearworks >= 4)
                    units[x].GetComponent<createunit>().speedlvup();
                if (gamecon.players[playernumber - 1].gold >= 450)
                    units[x].GetComponent<createunit>().trainingatker1();










            }
			if(units[x].GetComponent<unitstate>().unittype==1)
			{
				units[x].GetComponent<miningfunction>().gomining();
				
				
			}		
			if(units[x].GetComponent<unitstate>().unittype==5)
			{
				if(mybases.Count<3){
					units[x].GetComponent<unitmove>().movepos=goldarea[mybases.Count];
					units[x].GetComponent<unitmove>().moveing=true;
				}
			}
			
			
			
		}
		attackanddef();
	}
	void battleskill7()
	{
		
		
		
		for(int x=0;x<units.Count;x++)
		{
			if(units[x].GetComponent<unitstate>().unittype==0)
			{
				int nearworks=0;
				for(int z=0;z<myworks.Count;z++)
				{	if (Vector3.Distance(myworks[z].transform.position, units[x].transform.position) < 5.0f)
					{
						nearworks++;
						
					}
				}
				
				if(gamecon.players[playernumber-1].gold>=300&&nearworks<5)
					units[x].GetComponent<createunit>().trainingworker();
				if(gamecon.players[playernumber-1].gold>=500&&units[x].GetComponent<createunit>().speedlv<3&&nearworks>=4)
					units[x].GetComponent<createunit>().speedlvup();
				if(gamecon.players[playernumber-1].gold>=450&&nearworks>=5)
					units[x].GetComponent<createunit>().trainingatker1();
				
				
				
				
				
				
				
			}
			if(units[x].GetComponent<unitstate>().unittype==1)
			{
				units[x].GetComponent<miningfunction>().gomining();
				
				
			}		
			if(units[x].GetComponent<unitstate>().unittype==5)
			{
				if(mybases.Count<3){
					units[x].GetComponent<unitmove>().movepos=goldarea[mybases.Count];
					units[x].GetComponent<unitmove>().moveing=true;
				}
			}
			
			
			
		}
		attackerenemymainbase();
	}
	void defencerun()
	{
		//y=0;
	//	do{

		//print(atkteam1.atkers.Count);

		Vector3 gobasepoint=new Vector3(0,0,0);
		/*int c = atkteam1.atkers.Count;
		for (int z=0; z<c; z++) {

						if (atkteam1.atkers [z] == null) {
								atkteam1.atkers.Remove (atkteam1.atkers [z]);
								z -= 1;
								c-=1;
							} 
						else {
								if (true) {
										if (!atkteam1.atkers [z].GetComponent<unitmove> ().moveing) {
												atkteam1.atkers [z].GetComponent<unitmove> ().movepos = basepoint [0];
												atkteam1.atkers [z].GetComponent<unitmove> ().moveing = true;

										}
										if (basepoint.Count > 0) {
												//	print ("23333");

												for (int b=0; b<basepoint.Count; b++) {

														if (Vector3.Distance (atkteam1.atkers [z].transform.position, basepoint [b]) < 1.0f) {
						
																gobasepoint = basepoint [0];
																//	print ("23333");
																if (basepoint.Count > 1 && b + 1 < basepoint.Count) {
																		if (basepoint [b + 1] != null) {	
																				gobasepoint = basepoint [b + 1];
																		}

																}
																if (b == basepoint.Count - 1) {	
																		gobasepoint = basepoint [0];
																}
																atkteam1.atkers [z].GetComponent<unitmove> ().movepos = gobasepoint;
																atkteam1.atkers [z].GetComponent<unitmove> ().moveing = true;
														}
												}
										}
										//	atkteam1.atkers[z].GetComponent<unitmove>().movepos=gobasepoint;
										//	atkteam1.atkers[z].GetComponent<unitmove>().moveing=true;
								}
				
						}
				}*/

		for (int z=0; z<myatkers.Count; z++) {
				if (!myatkers [z].GetComponent<unitmove> ().moveing) {
				myatkers [z].GetComponent<unitmove> ().movepos = basepoint [0];
				myatkers [z].GetComponent<unitmove> ().moveing = true;
						
					}
					if (basepoint.Count > 0) {
						//	print ("23333");
						
						for (int b=0; b<basepoint.Count; b++) {
							
					if (Vector3.Distance (myatkers [z].transform.position, basepoint [b]) < 1.0f) {
								
								gobasepoint = basepoint [0];
								//	print ("23333");
								if (basepoint.Count > 1 && b + 1 < basepoint.Count) {
									if (basepoint [b + 1] != null) {	
										gobasepoint = basepoint [b + 1];
									}
									
								}
								if (b == basepoint.Count - 1) {	
									gobasepoint = basepoint [0];
								}
						myatkers [z].GetComponent<unitmove> ().movepos = gobasepoint;
						myatkers [z].GetComponent<unitmove> ().moveing = true;
							}
						}
					}
					//	atkteam1.atkers[z].GetComponent<unitmove>().movepos=gobasepoint;
					//	atkteam1.atkers[z].GetComponent<unitmove>().moveing=true;
				
				

		}
		//	y++;
	//	}while(y<atkteam1.atkers.Count);

		

}

	void attackerenemytwoway()
	{
		//y=0;
		//	do{
	//	Vector3 gobasepoint=new Vector3(0,0,0);
		int c = atkteam1.atkers.Count;
		for(int z=0;z<myatkers.Count;z++)
		{
			if (!myatkers [z].GetComponent<unitmove> ().moveing) {
				myatkers [z].GetComponent<unitmove> ().movepos = enemybasepos[0];
				myatkers [z].GetComponent<unitmove> ().moveing = true;
				
			}

		}

		for (int z=0; z<atkteam1.atkers.Count; z++) {
						if (atkteam1.atkers [z] == null) {
								atkteam1.atkers.Remove (atkteam1.atkers [z]);
								z -= 1;
								c -= 1;
						} 
							else {
				if (!atkteam1.atkers [z].GetComponent<unitmove> ().moveing) {
					atkteam1.atkers [z].GetComponent<unitmove> ().movepos = enemybasepos[enemybasepos.Count-1];
					atkteam1.atkers [z].GetComponent<unitmove> ().moveing = true;
				
								}

								//	atkteam1.atkers[z].GetComponent<unitmove>().movepos=gobasepoint;
								//	atkteam1.atkers[z].GetComponent<unitmove>().moveing=true;
						}
				}

	}

	void attackerenemymainbase()
	{
		//y=0;
		//	do{
		//	Vector3 gobasepoint=new Vector3(0,0,0);
		int c = atkteam1.atkers.Count;
		for(int z=0;z<myatkers.Count;z++)
		{
			if (!myatkers [z].GetComponent<unitmove> ().moveing) {
				myatkers [z].GetComponent<unitmove> ().movepos = enemybasepos[enemybasepos.Count-1];
				myatkers [z].GetComponent<unitmove> ().moveing = true;
				
			}
			
		}
		
	}

	void attackanddef()
	{
		//y=0;
		//	do{
		//	Vector3 gobasepoint=new Vector3(0,0,0);
		int c = atkteam1.atkers.Count;
		Vector3 gobasepoint=new Vector3(0,0,0);
		
		for (int z=0; z<atkteam1.atkers.Count; z++) {
			if (atkteam1.atkers [z] == null) {
				atkteam1.atkers.Remove (atkteam1.atkers [z]);
				z -= 1;
				c -= 1;
			} 
			else {
				if (!atkteam1.atkers [z].GetComponent<unitmove> ().moveing) {
					atkteam1.atkers [z].GetComponent<unitmove> ().movepos = enemybasepos[enemybasepos.Count-1];
					atkteam1.atkers [z].GetComponent<unitmove> ().moveing = true;
					
				}
				
				//	atkteam1.atkers[z].GetComponent<unitmove>().movepos=gobasepoint;
				//	atkteam1.atkers[z].GetComponent<unitmove>().moveing=true;
			}
		}
		for(int z=0;z<myatkers.Count;z++)
		{
			if (!myatkers [z].GetComponent<unitmove> ().moveing) {
				myatkers [z].GetComponent<unitmove> ().movepos = basepoint [0];
				myatkers [z].GetComponent<unitmove> ().moveing = true;
				
			}
			if (basepoint.Count > 0) {
				//	print ("23333");
				
				for (int b=0; b<basepoint.Count; b++) {
					
					if (Vector3.Distance (myatkers [z].transform.position, basepoint [b]) < 1.0f) {
						
						gobasepoint = basepoint [0];
						//	print ("23333");
						if (basepoint.Count > 1 && b + 1 < basepoint.Count) {
							if (basepoint [b + 1] != null) {	
								gobasepoint = basepoint [b + 1];
							}
							
						}
						if (b == basepoint.Count - 1) {	
							gobasepoint = basepoint [0];
						}
						myatkers [z].GetComponent<unitmove> ().movepos = gobasepoint;
						myatkers [z].GetComponent<unitmove> ().moveing = true;
					}
				}
			}
			
		}
		
	}

	public class atkteam 
	{
		public List<GameObject> atkers=new List<GameObject>();
		public List<int> gopoints=new List<int>();
		public int battlepower=0;
		public int atker1number=0;
		public int atker2number=0;
		public int atker3number=0;
		
		
		
	}

	void OnGUI()
	{
		if(playernumber==1)
			GUI.Label (new Rect(20,(Screen.height/5)*4-30,Screen.width,Screen.height/8),"battleskill:  "+battleskill,wordsize);
		if(playernumber==2)
			GUI.Label (new Rect(180,(Screen.height/5)*4-30,Screen.width,Screen.height/8),"battleskill:  "+battleskill,wordsize);
		
	}
}
