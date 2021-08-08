using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// handles the user data  on the specific instance 
/// </summary>
public class UserClass : MonoBehaviour
{

    public static UserClass Instance;
    private string _id { get; set; }
    public Dictionary<string, int> _BookDictonary = new Dictionary<string, int>();


    public void setUsername(string id  )
    {
        _id = id;
       
     }

    public string getUsername()
    {

        return _id; 
    }

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }




}
