using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
public class loadtest3 : MonoBehaviour {


    public List<float> mydata = new List<float>();

    protected FileInfo theSourceFile = null;

    protected StreamReader reader = null;

    public string text = " "; // assigned to allow first line to be read below
    float[] e1 = new float[999];
    float[] e2 = new float[999];
    float[] e3 = new float[999];
    float[] e4 = new float[999];
    float[] e5 = new float[999];
    float[] e6 = new float[999];
    public float[] s = new float[999];
    int nownumber = 0;
    public string[] oringinData = new string[999];
    int count = 0;
    public string[] newData = new string[999];
    string[] elemt;
    string[] words;
    float[] matchnumber = new float[999];
    char[] delimiterChars = { ' ', ',', ':', '\t', };
    public string[] sametemp = new string[999];
    public string[] samedatas = new string[999];
    public bool stop = false;

    public float[] normalmax = new float[3] { 0, 0, 0 };
    public float[] normalmin =new float[3] { 0,0,0 };
    public float[] wi = new float[999];
    public float[] computeddata1 = new float[999];
    public float[] computeddata2 = new float[999];
    public float[] computeddata3 = new float[999];
    public float[] computeddata4 = new float[999];
    public float[] computeddata5 = new float[999];
    public float rho=1;
    public int maxconputednumber = 0;
    //   public string[] delimiterChars = { " ", ",", ".", ":", "\t", };
    // string pattern = @"\s-";


    public int j = 0;
    public int k = 0;
    public int i = 0;
    void Start()
    {

        theSourceFile = new FileInfo("input.txt");
        print("load");
        reader = theSourceFile.OpenText();

        mydata.Add(1);
        // print("temp=" + mydata[0]);
        i = 0;

    }



    void Update()
    {
        if (Input.GetKeyDown("h"))
        {
            // searchsamedata();
            computdatafilter();
        }
        if (Input.GetKeyDown("j"))
        {
            // searchsamedata();
            computedliner();
        }
        if (Input.GetKeyDown("i"))
        {
            // searchsamedata();
           normalizefunc();
        }
        if (Input.GetKeyDown("g") && stop == false)
        {
            stop = true;

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
        if (!stop)
        {
            printword();

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
                 /*      case 12:
                           e6[k] = float.Parse(words[j]);
                           break;*/

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
                computeddata4[y] = e5[x];
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
        FileStream aFile = new FileStream("normalizedata.txt", FileMode.Append);

        StreamWriter sw = new StreamWriter(aFile);
        sw.WriteLine("e1:" + normalmin[0] + "_" + normalmax[0]);
        sw.WriteLine("e2:" + normalmin[1] + "_" + normalmax[1]);
        sw.WriteLine("e3:" + normalmin[2] + "_" + normalmax[2]);
        sw.WriteLine("-----------------start-----------------");
       
        
        for (int x = 0; x < maxconputednumber; x++)
        {


           // computeddata1[x] = computeddata1[x] * wi[x];
            normaldata1 = ((computeddata1[x] - normalmin[0]) /( normalmax[0]-normalmin[0]));
            normaldata1 = System.Math.Round(normaldata1, 2);
            normaldata2 = ((computeddata2[x] - normalmin[1]) / (normalmax[1] - normalmin[1]));
            normaldata2 = System.Math.Round(normaldata2, 2);
            normaldata3 = ((computeddata3[x] - normalmin[2]) / (normalmax[2] - normalmin[2]));
            normaldata3 = System.Math.Round(normaldata3, 2);

            sw.WriteLine(wi[x] + " 1:" + normaldata1 + " 2:" + normaldata2 + " 3:" + normaldata3);
        }

        sw.WriteLine("-----------------over-----------------");
        sw.Close();


    }



    void computedliner()
    {
        float linerx1 = 0;
        float linerx2 = 0;
        float linerx3 = 0;
        float linerx4 = 0;
        float linerx5 = 0;

        for (int x = 0; x < maxconputednumber; x++)
        {
            computeddata1[x] = computeddata1[x] * wi[x];
            linerx1 += computeddata1[x];
            computeddata2[x] = computeddata2[x] * wi[x];
            linerx2 += computeddata2[x];
            computeddata3[x] = computeddata3[x] * wi[x];
            linerx3 += computeddata3[x];
            computeddata4[x] = computeddata4[x] * wi[x];
            linerx4 += computeddata4[x];
            computeddata5[x] = computeddata5[x] * wi[x];
            linerx3 += computeddata5[x];

        }

        print(linerx1 + "*x1+" + linerx2 + "*x2+" + linerx3 + "*x3" + linerx4 + "*x4" + linerx5 + "*x5" + "-" + rho);

    }

}
