using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class loadtest : MonoBehaviour {


    public List<int> mydata = new List<int>();

    protected FileInfo theSourceFile = null;
	
    protected StreamReader reader = null;
	
    public string text = " "; // assigned to allow first line to be read below
	
    public string[] oringinData = new string[12];
    int count = 0;
    public string[] newData = new string[99];
    string[] elemt;
    string[] words;

    public char[] delimiterChars = { ' ', ',', '.', ':', '\t' , };
   // string pattern = @"\s-";
    string theText = "hello How Are You?";

    public int j = 0;
    public int k = 0;
    public int i=0;	
    void Start()
    {
        
        theSourceFile = new FileInfo("Data.txt");
        print("load");
        reader = theSourceFile.OpenText();
       
        mydata.Add(1);
       // print("temp=" + mydata[0]);
        i = 0;
        
    }
	
 
	
    void Update()
    {
        if (Input.GetKeyDown("g"))
        {
            printword();

        }
        if (text != null)
        {
            
            text = reader.ReadLine();
            
            oringinData[i] = text;
            //string[] words = oringinData[i].Split(delimiterChars, System.StringSplitOptions.None);
            // System.Console.WriteLine("{0} words in text:", words.Length);
            string[] splitString = theText.Split(delimiterChars, System.StringSplitOptions.None);
            //print("aa"+splitString[3]);
            
            Debug.Log("oringinData:" + oringinData[i]);
            
            i++;
            
        }
        
    }

    void printword()
    {
        
        if (k < oringinData.Length && oringinData[k] != null) {
            words = oringinData[k].Split(delimiterChars, System.StringSplitOptions.None);
           // words = Regex.Split(oringinData[k], pattern);
        }
       // print(words.Length);
        if (j< words.Length && oringinData[k]!=null)
        {
            print("word=" + words[j]);
            newData[count] = words[j];
            count++;
            j++;
        }
        if (j >= words.Length && k < oringinData.Length)
        {
            k++;
            j = 0;
            print("changeline");
        }
        if ( k+1 >=i)// oringinData.Length)
        {
            print("end");
        }
    }
}
