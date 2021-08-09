using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class Remove : MonoBehaviour
{
    // remove and update the Main record library data 
    public Button remove;


    private void Awake()
    {
        remove.onClick.AddListener(RemoveFromUser);
    }


    /// <summary>
    /// if removed is pressed 
    /// it will remove it from the userdata and will check if the book is present in the Global records then it will increase the count or will add the new data to the table
    /// </summary>
    public void RemoveFromUser()
    {
        Destroy(this.transform.parent.gameObject);
        UserClass.Instance._BookDictonary.Remove(this.transform.parent.name);

        if(LMS.Library.Instance.ReaderDictionary.ContainsKey(this.transform.parent.name))
        {

            LMS.Library.Instance.ReaderDictionary[this.transform.parent.name] += 1; // increase the count 
           // LMS.Library.Instance.UserBookRecords.Add(this.transform.parent.name, name);
        }
        else
        {
            LMS.Library.Instance.ReaderDictionary.Add(this.transform.parent.name, 1); //add if not available 

        }


       
    }
}
