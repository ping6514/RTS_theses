//using UnityEngine;
//using System.Collections;
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;



using System.Text;

using System.IO;

public class save : MonoBehaviour {
	public game1 gamecon;
	public gameai ai;
	public gameaib ai2;
	public int addbase,addwork,addatker;
	//FileStream fs = new FileStream("test.txt",FileMode.CreateNew);
	int oldscore=0;
	int oldp1skill=99;
	int oldp2skill=99;
	int wish=99;
	int good=0,match=0,bad=0;
    
    int oldbase1, oldbase2, oldatk1, oldatk2, oldwork1, oldwork2;
    double oldbattleassess, oldeconomicassess, oldscoreassess;
    float develop1, develop2;

    string filename = "s2-3train.txt";


    string[] afile = new string[99];
    string[] bfile = new string[99];
    string[] cfile = new string[99];

    string[] atemp = new string[99];
    string[] btemp = new string[99];
    string[] ctemp = new string[99];

    int afilemax = 0;
    int bfilemax = 0;
    int cfilemax = 0;

    int atempmax = 0;
    int btempmax = 0;
    int ctempmax = 0;
    //StreamWriter sw = new StreamWriter(fs);
    // Use this for initialization
    void Start () {
        oldatk1 = oldatk2 = oldbase1 = oldbase2 = oldwork1 = oldwork2 = 0;
        oldbattleassess = oldeconomicassess = oldscoreassess = 0;
     //   addbase =addwork=addatker=0;
		print("open");
		gamecon=GameObject.Find("gamecontrol").GetComponent<game1>();
		ai=GameObject.Find("ai").GetComponent<gameai>();
		ai2=GameObject.Find("ai2").GetComponent<gameaib>();
		wish = ai.wishbattle;

		//ai2=GameObject.Find("ai2").GetComponent<gameai>();
	/*	try
			
		{
			print("start");
			FileStream aFile = new FileStream(filename, FileMode.Append);//(@"c:\123\222.txt", FileMode.OpenOrCreate);
			
			StreamWriter sw = new StreamWriter(aFile);

			
			sw.Close();
			
		}
		
		catch (IOException ex)
			
		{
			
			Console.WriteLine(ex.Message);
			
			Console.ReadLine();
			
			return ;
			
		}*/
		oldscore=(gamecon.GetComponent<game1>().p1score-gamecon.GetComponent<game1>().p2score);

       

    }
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown("l"))
		{
			savedata();
		}


        if (Input.GetKeyDown("b"))
        {
            int pp = UnityEngine.Random.Range(0, 10);
            print("random=" + pp);
            FileStream aFile4 = new FileStream("gamehistroy.txt", FileMode.Append);
            StreamWriter sw4 = new StreamWriter(aFile4);
            sw4.WriteLine("------------------------------------------------------------");
            sw4.Close();

        }
	}
	public void savedata()
	{
        try

        {
            print("save");
            FileStream aFile = new FileStream("A-"+ filename, FileMode.Append);//(@"c:\123\222.txt", FileMode.OpenOrCreate);
            FileStream aFile2 = new FileStream("B-"+ filename, FileMode.Append);//(@"c:\123\222.txt", FileMode.OpenOrCreate
            FileStream aFile3 = new FileStream( "C-"+ filename , FileMode.Append);//(@"c:\123\222.txt", FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(aFile);
            StreamWriter sw2 = new StreamWriter(aFile2);
            StreamWriter sw3 = new StreamWriter(aFile3);

            //savegamehistroy
            FileStream aFile4 = new FileStream("gamehistroy.txt", FileMode.Append);
            StreamWriter sw4 = new StreamWriter(aFile4);



            int range = 0;
            int nowscore = gamecon.GetComponent<game1>().p1score - gamecon.GetComponent<game1>().p2score;
            /*if(nowscore<0)
				range=oldscore+nowscore;
			else
				range=oldscore-nowscore;*/
            range = nowscore - oldscore;
            if (oldp1skill == wish)
                match = 1;
            else
                match = 0;

            if (range > 20)//20
                good = 1;
            else
                good = 0;
            if (range < -20)//20
                bad = 1;
            else
                bad = 0;
            /*sw.WriteLine("nowscore:"+nowscore
                     +",oldrange:"+range
                     +",1:"+gamecon.GetComponent<game1>().p1score+",2:"+gamecon.GetComponent<game1>().p2score
                     +",3:"+gamecon.GetComponent<game1>().players[0].gold+",4:"+gamecon.GetComponent<game1>().players[1].gold
                     +",5:"+gamecon.GetComponent<game1>().players[0].baseunit+",6:"+gamecon.GetComponent<game1>().players[0].worker
                     +",7:"+gamecon.GetComponent<game1>().players[0].attacker1+",battlesklll="+ai.battleskill);
        */
            /*sw.WriteLine("nowscore:"+nowscore
			             +",oldrange:"+range
			             +",1:"+gamecon.GetComponent<game1>().p1score+",2:"+gamecon.GetComponent<game1>().p2score
			             +",3:"+gamecon.GetComponent<game1>().players[0].gold+",4:"+gamecon.GetComponent<game1>().players[1].gold
			             +",5:"+gamecon.GetComponent<game1>().players[0].baseunit+",6:"+gamecon.GetComponent<game1>().players[0].worker
			             +",7:"+gamecon.GetComponent<game1>().players[0].attacker1+",p1battlesklll="+oldp1skill
			             +",p2battlesklll="+oldp2skill);*/
            /*	sw.WriteLine(""+gamecon.GetComponent<game1>().p1score+","+gamecon.GetComponent<game1>().p2score
                             +","+gamecon.GetComponent<game1>().players[0].gold+","+gamecon.GetComponent<game1>().players[1].gold
                             +","+gamecon.GetComponent<game1>().players[0].baseunit+","+gamecon.GetComponent<game1>().players[1].baseunit
                             +","+gamecon.GetComponent<game1>().players[0].worker+","+gamecon.GetComponent<game1>().players[1].worker
                             +","+gamecon.GetComponent<game1>().players[0].attacker1+","+gamecon.GetComponent<game1>().players[1].attacker1
                             +",sr:"+range+",p2b:"+oldp2skill+",p1b:"+oldp1skill+",wish:"+wish+",match:"+match+",good:"+good+",bad:"+bad+",nowskill"+ai.battleskill);
    */
            /*		sw.WriteLine(""+gamecon.GetComponent<game1>().p1score+","+gamecon.GetComponent<game1>().p2score
                                 +","+gamecon.GetComponent<game1>().players[0].gold+","+gamecon.GetComponent<game1>().players[1].gold
                                 +","+gamecon.GetComponent<game1>().players[0].baseunit+","+gamecon.GetComponent<game1>().players[1].baseunit
                                 +","+gamecon.GetComponent<game1>().players[0].worker+","+gamecon.GetComponent<game1>().players[1].worker
                                 +","+gamecon.GetComponent<game1>().players[0].attacker1+","+gamecon.GetComponent<game1>().players[1].attacker1
                                 +","+addwork+","+addatker+","+addbase
                                 +",sr:"+range+",p2b:"+oldp2skill+",p1b:"+oldp1skill+",wish:"+wish+",good:"+good+",match:"+match+",bad:"+bad+",nowskill:"+ai.battleskill);
        */
            #region 收集防禦跟擴張資料
            /*
            int saveskill = 0;
            if (good == 1)
                saveskill = 1;
            else if(bad == 1)
                saveskill = -1;


            develop1 = (oldbase1 * 0.2f )+ (oldwork1 * 0.019f);
            develop2 = (oldbase2 * 0.2f) + (oldwork2 * 0.019f);

            if ((oldp1skill == 2 && oldp1skill!=4 &&(good==1||bad==1))||(oldp1skill==3&&good==1))
            {
                if (oldp1skill == 3)
                {
                    saveskill = -1;
                }
                sw.WriteLine("" + saveskill
                             + " 1:" + oldbattleassess+ " 2:" + oldeconomicassess
                             + " 3:" + oldscoreassess + " 4:" + oldatk1 * 0.01 + " 5:" + oldatk2 * 0.01 + " 6:" + oldbase1 * 0.333f + " 7:" + oldbase2 * 0.333f);


                atemp[atempmax]= "" + saveskill
                             + " 1:" + oldbattleassess + " 2:" + oldeconomicassess
                             + " 3:" + oldscoreassess + " 4:" + oldatk1*0.01 + " 5:" + oldatk2 * 0.01 + " 6:" + oldbase1 * 0.333f + " 7:" + oldbase2 * 0.333f;
                atempmax++;



                sw.Close();
                sw2.WriteLine("" + saveskill
                             + " 1:" + oldbattleassess  + " 2:"+ develop1+" 3:"+develop2 + " 4:" + oldatk1 * 0.01 + " 5:" + oldatk2 * 0.01 + " 6:" + oldwork1 * 0.01 + " 7:" + oldwork2 * 0.01 + " 8:" + oldbase1 * 0.333f + " 9:" + oldbase2 * 0.333f);

                btemp[btempmax] = "" + saveskill
                             + " 1:" + oldbattleassess + " 2:" + develop1 + " 3:" + develop2 + " 4:" + oldatk1 * 0.01 + " 5:" + oldatk2 * 0.01 + " 6:" + oldwork1 * 0.01 + " 7:" + oldwork2 * 0.01 + " 8:" + oldbase1 * 0.333f + " 9:" + oldbase2 * 0.333f;
                btempmax++;

                sw2.Close();

              
                sw3.WriteLine("" + saveskill
                            + " 1:" + oldbattleassess + " 2:" + develop1 + " 3:" + develop2 + " 4:" + oldeconomicassess + " 5:" + oldscoreassess+" 6:"+oldatk1 * 0.01 + " 7:"+oldatk2 * 0.01 + " 8:"+oldwork1 * 0.01 + " 9:"+oldwork2 * 0.01 + " 10:"+oldbase1 * 0.333f + " 11:"+oldbase2 * 0.333f);

                ctemp[ctempmax] = "" + saveskill
                            + " 1:" + oldbattleassess + " 2:" + develop1 + " 3:" + develop2 + " 4:" + oldeconomicassess + " 5:" + oldscoreassess + " 6:" + oldatk1 * 0.01 + " 7:" + oldatk2 * 0.01 + " 8:" + oldwork1 * 0.01 + " 9:" + oldwork2 * 0.01 + " 10:" + oldbase1 * 0.333f + " 11:" + oldbase2 * 0.333f;
                ctempmax++;


                sw3.Close();
            }
            
            */
            #endregion
            #region 收集攻擊跟其他資料
            
            int saveskill = 0;
            if (good == 1)
                saveskill = 1;
            else if(bad == 1)
                saveskill = -1;


            develop1 = (oldbase1 * 0.2f )+ (oldwork1 * 0.019f);
            develop2 = (oldbase2 * 0.2f) + (oldwork2 * 0.019f);

            if ((oldp1skill == 1 && oldp1skill!=4 &&(good==1||bad==1)))
            {

                sw.WriteLine("" + saveskill
                             + " 1:" + oldbattleassess+ " 2:" + oldeconomicassess
                             + " 3:" + oldscoreassess + " 4:" + oldatk1 * 0.01 + " 5:" + oldatk2 * 0.01 + " 6:" + oldbase1 * 0.333f + " 7:" + oldbase2 * 0.333f);


                atemp[atempmax]= "" + saveskill
                             + " 1:" + oldbattleassess + " 2:" + oldeconomicassess
                             + " 3:" + oldscoreassess + " 4:" + oldatk1*0.01 + " 5:" + oldatk2 * 0.01 + " 6:" + oldbase1 * 0.333f + " 7:" + oldbase2 * 0.333f;
                atempmax++;



                sw.Close();
                sw2.WriteLine("" + saveskill
                             + " 1:" + oldbattleassess  + " 2:"+ develop1+" 3:"+develop2 + " 4:" + oldatk1 * 0.01 + " 5:" + oldatk2 * 0.01 + " 6:" + oldwork1 * 0.01 + " 7:" + oldwork2 * 0.01 + " 8:" + oldbase1 * 0.333f + " 9:" + oldbase2 * 0.333f);

                btemp[btempmax] = "" + saveskill
                             + " 1:" + oldbattleassess + " 2:" + develop1 + " 3:" + develop2 + " 4:" + oldatk1 * 0.01 + " 5:" + oldatk2 * 0.01 + " 6:" + oldwork1 * 0.01 + " 7:" + oldwork2 * 0.01 + " 8:" + oldbase1 * 0.333f + " 9:" + oldbase2 * 0.333f;
                btempmax++;

                sw2.Close();

              
                sw3.WriteLine("" + saveskill
                            + " 1:" + oldbattleassess + " 2:" + develop1 + " 3:" + develop2 + " 4:" + oldeconomicassess + " 5:" + oldscoreassess+" 6:"+oldatk1 * 0.01 + " 7:"+oldatk2 * 0.01 + " 8:"+oldwork1 * 0.01 + " 9:"+oldwork2 * 0.01 + " 10:"+oldbase1 * 0.333f + " 11:"+oldbase2 * 0.333f);

                ctemp[ctempmax] = "" + saveskill
                            + " 1:" + oldbattleassess + " 2:" + develop1 + " 3:" + develop2 + " 4:" + oldeconomicassess + " 5:" + oldscoreassess + " 6:" + oldatk1 * 0.01 + " 7:" + oldatk2 * 0.01 + " 8:" + oldwork1 * 0.01 + " 9:" + oldwork2 * 0.01 + " 10:" + oldbase1 * 0.333f + " 11:" + oldbase2 * 0.333f;
                ctempmax++;


                sw3.Close();



                //gamehistroy
                if (good == 1)
                {
                    if (UnityEngine.Random.Range(0, 10) <= 6 && PlayerPrefs.GetInt("gamestep") == 0)
                    {
                      /*  PlayerPrefs.SetInt("gamestep", 1);
                        sw4.WriteLine("------------------------------------------------------------");
                        sw4.Close();*/
                    }




                }


            }

           

            
            #endregion
        }




        catch (IOException ex)
			
		{
			
			Console.WriteLine(ex.Message);
			
			Console.ReadLine();
			
			return ;
			
		}

        oldbase1 = gamecon.GetComponent<game1>().players[0].baseunit;
        oldbase2 = gamecon.GetComponent<game1>().players[1].baseunit;
        oldatk1 = gamecon.GetComponent<game1>().players[0].attacker1;
        oldatk2 = gamecon.GetComponent<game1>().players[1].attacker1;
        oldwork1 = gamecon.GetComponent<game1>().players[0].worker;
        oldwork2 = gamecon.GetComponent<game1>().players[1].worker;

        oldscore =gamecon.GetComponent<game1>().p1score-gamecon.GetComponent<game1>().p2score;
        oldp1skill = ai.strategy;

		wish = ai.wishbattle;
		oldp2skill=ai2.strategy;
		addbase=addwork=addatker=0;



        oldbattleassess = ai.battletemp;
        oldeconomicassess = ai.economictemp;
        oldscoreassess = ai.scoretemp;

        //gamehistroy
        if (PlayerPrefs.GetInt("gamestep") == 0)
        {
            gamecon.savegamestate();

            PlayerPrefs.SetString("oplayer1skill", PlayerPrefs.GetString("oplayer1skill") + oldp1skill + ", ");
            PlayerPrefs.SetString("oplayer2skill", PlayerPrefs.GetString("oplayer2skill") + oldp2skill + ", ");


            PlayerPrefs.SetString("oplayer1socre", PlayerPrefs.GetString("oplayer1socre") + gamecon.GetComponent<game1>().p1score + ", ");
            PlayerPrefs.SetString("oplayer2socre", PlayerPrefs.GetString("oplayer2socre") + gamecon.GetComponent<game1>().p2score + ", ");



        }

        else if(PlayerPrefs.GetInt("gamestep") > 0)
        {
            PlayerPrefs.SetString("nplayer1skill", PlayerPrefs.GetString("nplayer1skill") + oldp1skill + ", ");
            PlayerPrefs.SetString("nplayer2skill", PlayerPrefs.GetString("nplayer2skill") + oldp2skill + ", ");


            PlayerPrefs.SetString("nplayer1socre", PlayerPrefs.GetString("nplayer1socre") + gamecon.GetComponent<game1>().p1score + ", ");
            PlayerPrefs.SetString("nplayer2socre", PlayerPrefs.GetString("nplayer2socre") + gamecon.GetComponent<game1>().p2score + ", ");


        }

    }

    public void saveover(bool x)
	{
		try
			
		{
			print("save");
			FileStream aFile = new FileStream("wincount.txt", FileMode.Append);//(@"c:\123\222.txt", FileMode.OpenOrCreate);
			
			StreamWriter sw = new StreamWriter(aFile);
			
			if(x)
			sw.WriteLine("lose");
			else
			sw.WriteLine("win");
			sw.Close();
			
		}
		
		catch (IOException ex)
			
		{
			
			Console.WriteLine(ex.Message);
			
			Console.ReadLine();
			
			return ;
			
		}

	}

    public void savehistory(int a)
    {
        //savegamehistroy
        FileStream aFile4 = new FileStream("gamehistroy.txt", FileMode.Append);
        StreamWriter sw4 = new StreamWriter(aFile4);
        if(a==1)
        sw4.WriteLine("攻擊戰略:"+PlayerPrefs.GetString("gameover"));
        if (a == 2)
            sw4.WriteLine("擴張戰略:" + PlayerPrefs.GetString("gameover"));
        if (a == 3)
            sw4.WriteLine("防禦戰略:" + PlayerPrefs.GetString("gameover"));
        sw4.WriteLine("玩家1: " + PlayerPrefs.GetString("oplayer1skill") + "_" + PlayerPrefs.GetString("nplayer1skill") + " |  " + PlayerPrefs.GetString("oplayer1socre") + "_" + PlayerPrefs.GetString("nplayer1socre"));
        sw4.WriteLine("玩家2: " + PlayerPrefs.GetString("oplayer2skill") + "_" + PlayerPrefs.GetString("nplayer2skill") + " |  " + PlayerPrefs.GetString("oplayer2socre") + "_" + PlayerPrefs.GetString("nplayer2socre"));


        if(a==3)
        {
            if (PlayerPrefs.GetInt("game1over")==1 )
            {
                if(PlayerPrefs.GetInt("game2over")==0 && PlayerPrefs.GetInt("game3over")==0)
                    sw4.WriteLine("success");
    
                else
                    sw4.WriteLine("draw");

            }
            else if (PlayerPrefs.GetInt("game1over") == 0)
            {
                if (PlayerPrefs.GetInt("game2over") == 0 && PlayerPrefs.GetInt("game3over") == 0)
                    sw4.WriteLine("draw");

                else
                    sw4.WriteLine("lose");

            }


        }


        sw4.Close();
    }


	public void adduint(int x)
	{
		/*if(x==1)
			addwork++;
		if(x==2)
			addatker++;
		if(x==3)
			addbase++;*/

	}
}
