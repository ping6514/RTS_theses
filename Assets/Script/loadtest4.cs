using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class loadtest4 : MonoBehaviour {

    public string LOADfilename = "TEXT.txt";

    public List<float> mydata = new List<float>();

    protected FileInfo theSourceFile = null;

    protected StreamReader reader = null;
    protected StreamReader modelreader = null;

    public string text2 = " ";
    public string text = " "; // assigned to allow first line to be read below
    float[] e1 = new float[999];
    float[] e2 = new float[999];
    float[] e3 = new float[999];
    float[] e4 = new float[999];
    float[] e5 = new float[999];
    float[] e6 = new float[999];
    float[] e7 = new float[999];
    public float[] s = new float[999];
    int nownumber = 0;
    int nownumber2 = 0;
    public string[] oringinData = new string[999];
    public string[] oringinData2 = new string[999];
    int count = 0;
    int count2 = 0;
    public string[] newData = new string[999];
    string[] elemt;
    string[] words;
    string[] words2;
    float[] matchnumber = new float[999];
    char[] delimiterChars = { ' ', ',', ':', '\t', };
    public string[] sametemp = new string[999];
    public string[] samedatas = new string[999];
    public bool stop = false;

    public float[] normalmax = new float[3] { 0, 0, 0 };
    public float[] normalmin = new float[3] { 0, 0, 0 };
    public float[] wi = new float[999];
    public float[] computeddata1 = new float[999];
    public float[] computeddata2 = new float[999];
    public float[] computeddata3 = new float[999];
    public float[] computeddata4 = new float[999];
    public float[] computeddata5 = new float[999];
    public float[] computeddata6 = new float[999];
    public float[] computeddata7 = new float[999];
    //  public float rho = 1;
    public int maxconputednumber = 0;
    //   public string[] delimiterChars = { " ", ",", ".", ":", "\t", };
    // string pattern = @"\s-";

    public double lineD1 = 0;
    public double lineD2 = 0;
    public double lineD3 = 0;
    public double lineD4 = 0;
    public double lineD5 = 0;
    public double lineD6 = 0;
    public double lineD7 = 0;
    public double rho = 0;

    public int j = 0;
    public int j2 = 0;
    public int k = 0;
    public int k2 = 0;
    public int i = 0;
    public int i2 = 0;

    //predict
    public int linemax = 4;
    string savestring;
    string savestring2;
    string savestring3;
    string savestring4;
    public double[] a_0 = new double[4];
    public double[] a_1 = new double[4];
    public double[] a_2 = new double[4];
    public double[] a_3 = new double[4];
    public double[] a_4 = new double[4];
    public double[] a_5 = new double[4];
    public double[] a_6 = new double[4];
    public double[] a_7 = new double[4];
    //

    void Start()
    {

        theSourceFile = new FileInfo(LOADfilename);
        modelreader = new FileInfo("model.txt").OpenText();
        print("load");
        reader = theSourceFile.OpenText();

        mydata.Add(1);
        // print("temp=" + mydata[0]);
        i = 0;
        i2 = 0;

    }



    void Update()
    {
        if (Input.GetKeyDown("h"))
        {
            computdatafilter();
        }
        if (Input.GetKeyDown("j"))
        {
            computedliner();
        }
        if (Input.GetKeyDown("i"))
        {
            linerprojection();
        }
        if (Input.GetKeyDown("o"))
        {
            normalizefunc();
        }
        if (Input.GetKeyDown("p"))
        {
            predict();
        }
        if (Input.GetKeyDown("g") && stop == false)
        {
            stop = true;
            reader.Close();

        }
        else if (Input.GetKeyDown("g") && stop == true)
        {

            stop = false;
        }

        if (text != null)
        {

            text = reader.ReadLine();

            oringinData[i] = text;
            //string[] words = oringinData[i].Split(delimiterChars, System.StringSplitOptions.None);
            // System.Console.WriteLine("{0} words in text:", words.Length);
            //  string[] splitString = theText.Split(delimiterChars, System.StringSplitOptions.None);
            //print("aa"+splitString[3]);

            Debug.Log("oringinData:" + oringinData[i]);

            i++;

        }
        else
        {
            reader.Close();
        }
        if (text2 != null)
        {

            text2 = modelreader.ReadLine();

            oringinData2[i2] = text2;
            //string[] words = oringinData[i].Split(delimiterChars, System.StringSplitOptions.None);
            // System.Console.WriteLine("{0} words in text:", words.Length);
            //  string[] splitString = theText.Split(delimiterChars, System.StringSplitOptions.None);
            //print("aa"+splitString[3]);

            Debug.Log("oringinData:" + oringinData[i2]);

            i2++;

        }
        else
        {
            modelreader.Close();
        }
        if (!stop)
        {
            printword();
            printword2();
        }

    }

    void printword()
    {

        if (k < oringinData.Length && oringinData[k] != null)
        {
            words = oringinData[k].Split(delimiterChars, System.StringSplitOptions.None);
            // words = Regex.Split(oringinData[k], pattern);
        }
        // print(words.Length);
        if (j < words.Length && oringinData[k] != null)
        {
            print("word=" + words[j]);
            //  newData[count] = words[j];

            switch (nownumber)
            {

                case 0:
                    s[k] = float.Parse(words[j]);
                    break;
                case 2:
                    e1[k] = float.Parse(words[j]);
                    break;
                case 4:
                    e2[k] = float.Parse(words[j]);
                    break;
                case 6:
                    e3[k] = float.Parse(words[j]);
                    break;
                case 8:
                     e4[k] = float.Parse(words[j]);
                    break;
                case 10:
                      e5[k] = float.Parse(words[j]);
                    break;
                case 12:
                      e6[k] = float.Parse(words[j]);
                    break;
                case 14:
                    e7[k] = float.Parse(words[j]);
                break;

            }

            print("go");
            count++;
            j++;
            nownumber++;
        }
        if (j >= words.Length && k < oringinData.Length)
        {
            k++;
            j = 0;
            nownumber = 0;
            print("changeline");
        }
        if (k + 1 >= i)// oringinData.Length)
        {
            print("end");
            //stop = true;
        }
    }

    void printword2()
    {

        if (k2 < oringinData2.Length && oringinData2[k2] != null)
        {
            words2 = oringinData2[k2].Split(delimiterChars, System.StringSplitOptions.None);
            // words = Regex.Split(oringinData[k], pattern);
        }
        // print(words.Length);
        if (j2 < words2.Length && oringinData2[k2] != null)
        {
            print("word=" + words2[j2]);
            //  newData[count] = words[j];

            switch (nownumber2)
            {

                case 0:
                    a_0[k2] = float.Parse(words2[j2]);
                    break;
                case 2:
                    a_1[k2] = float.Parse(words2[j2]);
                    break;
                case 4:
                    a_2[k2] = float.Parse(words2[j2]);
                    break;
                case 6:
                    a_3[k2] = float.Parse(words2[j2]);
                    break;
                case 8:
                    a_4[k2] = float.Parse(words2[j2]);
                    break;
                case 10:
                    a_5[k2] = float.Parse(words2[j2]);
                    break;
                case 12:
                    a_6[k2] = float.Parse(words2[j2]);
                    break;
                case 14:
                    a_7[k2] = float.Parse(words2[j2]);
                    break;

            }

            print("go");
            count2++;
            j2++;
            nownumber2++;
        }
        if (j2 >= words2.Length && k2 < oringinData2.Length)
        {
            k2++;
            j2 = 0;
            nownumber2 = 0;
            print("changeline");
        }
        if (k2 + 1 >= i)// oringinData.Length)
        {
            print("end");
            //stop = true;
        }
    }

    void searchsamedata()
    {

        int tempcount = 0;
        for (int a = 0; a < k; a++)
        {
            for (int b = 0; b < k; b++)
            {
                if (e1[a] == e1[b] && e2[a] == e2[b] && e3[a] == e3[b] && e4[a] == e4[b] && e5[a] == e5[b] && /*e6[a] == e6[b] && */a != b)
                {
                    print("same: " + " 1:" + e1[a] + " 2:" + e2[a] + " 3:" + e3[a] + " 4:" + e4[a] + " 5:" + e5[a]);// + " 6:" + e6[a]);

                    sametemp[tempcount] = "" + " 1:" + e1[a] + " 2:" + e2[a] + " 3:" + e3[a] + " 4:" + e4[a] + " 5:" + e5[a];// + " 6:" + e6[a];
                    tempcount++;
                }
                print("search");
            }
        }
        int c = 0;

        for (int a = 0; a < k; a++)
        {
            if (sametemp[a] != null)
                if (sametemp[a].Equals(""))
                {
                    c = a;
                    break;

                }
        }
        int d = c;
        int e = 0;
        c = 1;
        //samedatas = new string[c];
        for (int a = 0; a < tempcount; a++)
        {
            print("start");
            for (int b = 0; b < c; b++)
            {
                if (a == 0)
                {
                    samedatas[a] = sametemp[b];
                    print("break");
                    // c++;
                    e++;
                    break;
                }
                if (sametemp[a].Equals(samedatas[b]))
                {
                    print("break");
                    break;

                }
                if (b == c - 1)
                {
                    samedatas[e] = sametemp[a];
                    c++;
                    e++;
                }
            }
        }





        FileStream aFile = new FileStream("samedatas.txt", FileMode.Append);//(@"c:\123\222.txt", FileMode.OpenOrCreate);

        StreamWriter sw = new StreamWriter(aFile);
        sw.WriteLine("-----------------start-----------------");
        for (int a = 0; a < c; a++)
            sw.WriteLine(samedatas[a]);
        sw.WriteLine("-----------------over-----------------");
        sw.Close();

















    }
    void computdatafilter()
    {
        print("gofilter");
        int y = 0;
        for (int x = 0; x < k; x++)
        {
            // if (s[x] != 1 && s[x] != -1)
            //   {
            wi[y] = s[x];
            computeddata1[y] = e1[x];
            computeddata2[y] = e2[x];
            computeddata3[y] = e3[x];
            computeddata4[y] = e4[x];
            computeddata5[y] = e5[x];
            computeddata6[y] = e6[x];
            computeddata7[y] = e7[x];
            y++;

            //  }


        }
        maxconputednumber = y;

    }

    void normalizefunc()
    {
        print("gonormalize");
        double normaldata1 = 0;
        double normaldata2 = 0;
        double normaldata3 = 0;
        double normaldata4 = 0;
        double normaldata5 = 0;
        double normaldata6 = 0;
        double normaldata7 = 0;
        FileStream aFile = new FileStream("normalizedata.txt", FileMode.Append);

        StreamWriter sw = new StreamWriter(aFile);
        sw.WriteLine("e1:" + normalmin[0] + "_" + normalmax[0]);
        sw.WriteLine("e2:" + normalmin[1] + "_" + normalmax[1]);
        sw.WriteLine("e3:" + normalmin[2] + "_" + normalmax[2]);
        sw.WriteLine("e1:" + normalmin[3] + "_" + normalmax[3]);
        sw.WriteLine("e2:" + normalmin[4] + "_" + normalmax[4]);
        sw.WriteLine("e3:" + normalmin[5] + "_" + normalmax[5]);
        sw.WriteLine("e3:" + normalmin[6] + "_" + normalmax[6]);
        sw.WriteLine("-----------------start-----------------");


        for (int x = 0; x < maxconputednumber; x++)
        {


            // computeddata1[x] = computeddata1[x] * wi[x];
            normaldata1 = ((computeddata1[x] - normalmin[0]) / (normalmax[0] - normalmin[0]));
            normaldata1 = System.Math.Round(normaldata1, 2);
            normaldata2 = ((computeddata2[x] - normalmin[1]) / (normalmax[1] - normalmin[1]));
            normaldata2 = System.Math.Round(normaldata2, 2);
            normaldata3 = ((computeddata3[x] - normalmin[2]) / (normalmax[2] - normalmin[2]));
            normaldata3 = System.Math.Round(normaldata3, 2);
            normaldata4 = ((computeddata4[x] - normalmin[3]) / (normalmax[3] - normalmin[3]));
            normaldata4 = System.Math.Round(normaldata4, 2);
            normaldata5 = ((computeddata5[x] - normalmin[4]) / (normalmax[4] - normalmin[4]));
            normaldata5 = System.Math.Round(normaldata5, 2);
            normaldata6 = ((computeddata6[x] - normalmin[5]) / (normalmax[5] - normalmin[5]));
            normaldata6 = System.Math.Round(normaldata6, 2);
            normaldata7 = ((computeddata7[x] - normalmin[6]) / (normalmax[6] - normalmin[6]));
            normaldata7 = System.Math.Round(normaldata7, 2);
            sw.WriteLine(wi[x] + " 1:" + normaldata1 + " 2:" + normaldata2 + " 3:" + normaldata3 + " 4:" + normaldata4 + " 5:" + normaldata5 + " 6:" + normaldata6 + " 7:" + normaldata7);
        }

        sw.WriteLine("-----------------over-----------------");
        sw.Close();


    }

    void linerprojection()
    {
        print("linerprojection");
        FileStream aFile = new FileStream("linerprojectionedata.txt", FileMode.Append);
        StreamWriter sw = new StreamWriter(aFile);

        double lix1;
        double lix2;
        double lix3;
        double lix4;
        double lix5;
        double lix6;
        double lix7;
        double t;
        double Denominator;

        Denominator = ((lineD1 * lineD1) + (lineD2 * lineD2)+ (lineD3 * lineD3) + (lineD4 * lineD4) + (lineD5 * lineD5) + (lineD6 * lineD6) + (lineD7 * lineD7));


        for (int x = 0; x < maxconputednumber; x++)
        {




            t = -((-rho + lineD1 * computeddata1[x] + lineD2 * computeddata2[x] + lineD3 * computeddata3[x]
                 + lineD4 * computeddata4[x] + lineD5 * computeddata5[x] + lineD6 * computeddata6[x] + lineD7 * computeddata7[x])) / Denominator;


            lix1 = computeddata1[x] - (lineD1 * t);

            lix2 = computeddata2[x] - (lineD2 * t);

            lix3 = computeddata3[x] - (lineD3 * t);

            lix4 = computeddata4[x] - (lineD4 * t);

            lix5 = computeddata5[x] - (lineD5 * t);

            lix6 = computeddata6[x] - (lineD6 * t);

            lix7 = computeddata7[x] - (lineD7 * t);


            /*

            lix1 = lineD1 * (rho + lineD1 * computeddata1[x] + lineD2 * computeddata1[x] + lineD3 * computeddata1[x]);
            lix1 = computeddata1[x] - (lix1 / Denominator);

            lix2 = lineD2 * (rho + lineD1 * computeddata2[x] + lineD2 * computeddata2[x] + lineD3 * computeddata2[x]);
            lix2 = computeddata2[x] - (lix2 / Denominator);

            lix3 = lineD3 * (rho + lineD1 * computeddata3[x] + lineD2 * computeddata3[x] + lineD3 * computeddata3[x]);

            lix3 = computeddata3[x] - (lix3 / Denominator);*/



            lix1 = System.Math.Round(lix1, 2);
            lix2 = System.Math.Round(lix2, 2);
            lix3 = System.Math.Round(lix3, 2);
            lix4 = System.Math.Round(lix4, 2);
            lix5 = System.Math.Round(lix5, 2);
            lix6 = System.Math.Round(lix6, 2);
            lix7 = System.Math.Round(lix7, 2);
            sw.WriteLine(wi[x] + " 1:" +  lix1 + " 2:" + lix2 + " 3:" + lix3 + " 4:" + lix4+" 5:" + lix5+ " 6:" + lix6+ " 7:" + lix7);
        }

        sw.Close();

    }

    void computedRBF()
    {
        double linerx1 = 0;
        double linerx2 = 0;
        double linerx3 = 0;
        double linerx4 = 0;
        double linerx5 = 0;
        double linerx6 = 0;
        double linerx7 = 0;

        float temp=0;
        for (int x = 0; x < k2; x++)
        {
            Mathf.Sqrt((float)linerx2);
            linerx1 =  a_1[x] - computeddata1[x];
            linerx1 = linerx1 * linerx1;

            linerx2 =  a_2[x] - computeddata2[x];
            linerx2 = linerx2 * linerx2;

            linerx3 =  a_3[x] - computeddata3[x];
            linerx3 = linerx3 * linerx3;

            linerx4 =  a_4[x] - computeddata4[x];
            linerx4 = linerx4 * linerx4;

            linerx5 =  a_5[x] - computeddata5[x];
            linerx5 = linerx5 * linerx5;

            linerx6 = a_6[x] - computeddata6[x];
            linerx6 = linerx6 * linerx6;

            linerx7 = a_7[x] - computeddata7[x];
            linerx7 = linerx7 * linerx7;

            temp += (float)a_0[x] * Mathf.Sqrt((float)(linerx1 + linerx2 + linerx3 + linerx4 + linerx5 + linerx6 + linerx7));
        }

        
      //  print(linerx1 + "*x1+" + linerx2 + "*x2+" + linerx3 + "*x3+" + linerx4 + "*x4+" + linerx5 + "*x5+" + linerx6 + "*x6+" + linerx7 + "*x7" + "-" + rho);

    }


    void computedliner()
    {
        double linerx1 = 0;
        double linerx2 = 0;
        double linerx3 = 0;
        double linerx4 = 0;
        double linerx5 = 0;
        double linerx6 = 0;
        double linerx7 = 0;


        for (int x = 0; x < k2; x++)
        {

            linerx1 += a_0[x] * a_1[x];
            linerx2 += a_0[x] * a_2[x];
            linerx3 += a_0[x] * a_3[x];
            linerx4 += a_0[x] * a_4[x];
            linerx5 += a_0[x] * a_5[x];
            linerx6 += a_0[x] * a_6[x];
            linerx7 += a_0[x] * a_7[x];

        }

        print(linerx1 + "*x1+" + linerx2 + "*x2+" + linerx3 + "*x3+" + linerx4 + "*x4+" + linerx5 + "*x5+" + linerx6 + "*x6+" + linerx7 + "*x7" + "-" + rho);

    }

    //predict
    void predict()
    {

        //讀檔
        print("predict");
        FileStream aFile = new FileStream("predictfile.txt", FileMode.Append);
        StreamWriter sw = new StreamWriter(aFile);
        double output;
        double test;
        
        #region old
        /*
        int output=0;
             if((a1_0-rho+ (a0_1*computeddata1[x]) 
            (a1_2*computeddata2[x])
            (a1_3*computeddata3[x])
            (a1_4*computeddata4[x])
            (a1_5*computeddata5[x])
            (a1_6*computeddata6[x])
            (a1_7*computeddata7[x]))>=0)
            {
                output=1;
            }
        else if((a2_0-rho+ (a1_1*computeddata1[x]) 
            (a2_2*computeddata2[x])
            (a2_3*computeddata3[x])
            (a2_4*computeddata4[x])
            (a2_5*computeddata5[x])
            (a2_6*computeddata6[x])
            (a2_7*computeddata7[x]))>=0)
            {
                output=1;
            }
        else if((a3_0-rho+ (a1_1*computeddata1[x]) 
            (a3_2*computeddata2[x])
            (a3_3*computeddata3[x])
            (a3_4*computeddata4[x])
            (a3_5*computeddata5[x])
            (a3_6*computeddata6[x])
            (a3_7*computeddata7[x]))>=0)
            {
                output=1;
            }
        else if((a4_0-rho+ (a1_1*computeddata1[x]) 
            (a4_2*computeddata2[x])
            (a4_3*computeddata3[x])
            (a4_4*computeddata4[x])
            (a4_5*computeddata5[x])
            (a4_6*computeddata6[x])
            (a4_7*computeddata7[x]))>=0)
            {
                output=1;
            }
        else
            {
                output=-1;
            }*/
        #endregion
        for (int x = 0; x < maxconputednumber; x++)
        {
            output = 0;

            for (int i = 0; i < k2; i++)
            {
                if (true)//output == 0)
                {
                      test = (a_0[i] *( 
                       (a_1[i] * computeddata1[x])+
                       (a_2[i] * computeddata2[x])+
                       (a_3[i] * computeddata3[x])+
                       (a_4[i] * computeddata4[x])+
                       (a_5[i] * computeddata5[x])+
                       (a_6[i] * computeddata6[x])+
                       (a_7[i] * computeddata7[x])));

                        output += test;

                      
                  
                    #region print        
                  /*  if (i == 0)
                    {
                        print("i0- test = " + test);
                        savestring = "i0 = " + test;
                    }
                    if (i == 1)
                    {
                        print("i1- test = " + test);
                        savestring2 = "-i1 = " + test;
                    }
                    if (i == 2)
                    {
                        print("i2- test = " + test);
                        savestring3= "-i2 = " + test;
                    }
                    if (i == 3)
                    {

                        print("i3- test = " + test);
                        savestring4 = "-i3 = " + test;
                    }*/
                    #endregion
                }

            }
            if (output == 0)
            {
              //  output = -1;
            }
            output -= rho;

            //存檔
            if (output >= 0)
                sw.WriteLine("1           oringin:" + output); // + savestring + savestring2 + savestring3 + savestring4);
            else

                sw.WriteLine("-1           oringin:" + output); // + savestring + savestring2 + savestring3 + savestring4);
        }

        sw.Close();

    }



}
