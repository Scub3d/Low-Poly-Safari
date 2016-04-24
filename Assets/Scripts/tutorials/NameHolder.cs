using UnityEngine;
using System.Collections;

public class NameHolder {


    private static NameHolder nameHolder = null;


    private static string uname = "asdfa";


    public static NameHolder getInstance()
    {
        if (nameHolder == null) { nameHolder = new NameHolder(); }

        return nameHolder;
    }


    public string getName() { return uname; }


    public void setName(string namae) { uname = namae; }
}