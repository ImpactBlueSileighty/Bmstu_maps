using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{

    private static List<string> _floors = new List<string>() { "1floor", "4floor" };

    static GameObject obj;
    private static void UnloadAllScenes(string floor)
    {
        
        foreach(string fl in _floors)
        {
            if(fl != floor)
            {
                obj = GameObject.Find(fl);
                obj.SetActive(false);
            }
            
        }
    }
    public static void MoveToFloor(string floor)
    {
        UnloadAllScenes(floor);
        obj = GameObject.Find(floor);
       
        obj.SetActive(true);
        
    }

    


}
