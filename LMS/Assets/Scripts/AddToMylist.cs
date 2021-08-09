using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class AddToMylist : MonoBehaviour
{
    // this class is attached to each indivisual book so it can be added to the cart
    //it will take the current user instance and then book the book according to it. 
      public Button addToUserList;
    public TextMeshProUGUI Text;
       

    private void Awake()
    {
        addToUserList.onClick.AddListener(AddTheBook);
    }

    /// <summary>
    /// For adding the book we have 3 basic checks : 
    ///  check if user has 2 books 
    ///  only one copy of the book can be  with the user 
    ///  to check is there are no books available
    /// </summary>
    public  void AddTheBook()
    {
        //string name = UserClass.Instance.getUsername();
        Text =GameObject.Find("Error").GetComponent<TextMeshProUGUI>();
        //Debug.Log(this.transform.parent.name);
        if ( CheckUserBooks() && CopyCheck() && countCheck())
        {
            Debug.Log("User can book ");
            Text.text = "Booked";
            Booking();
        }

        else
        {

            Debug.Log("UsercantBook");
           
            Text.text = " Cannot Add More books!,Check Your Account";

        }
     }

    /// <summary>
    /// Check if user has 2 or more books
    /// </summary>
    /// <returns></returns>
    bool CheckUserBooks()
    {

        if ( UserClass.Instance._BookDictonary.Count>=2)
        {

            return false;
        }
        else
        {

            return true; 
        }
    }

    /// <summary>
    ///  Check if the user already has a copy of the book or not
    /// </summary>
    /// <returns></returns>
    bool CopyCheck()
    {
        if  (UserClass.Instance._BookDictonary.ContainsKey(this.transform.parent.name))
        {
            return false; 
        }
        else
        {
            return true;
        }

    }
    // check if the book  has a count of more than zero 
    bool countCheck()
    {
        if ((LMS.Library.Instance.ReaderDictionary[this.transform.parent.name])> 0)
        {

            return true;
        }
        else
        {

            return false;
        }

    }

 void Booking ()
    {
        UserClass.Instance._BookDictonary.Add(this.transform.parent.name, 1);
        //LMS.Library.Instance.UserBookRecords.Add(this.transform.parent.name, name);

        //updating the value
        int Value = LMS.Library.Instance.ReaderDictionary[this.transform.parent.name] - 1;
        if( Value<=0)
        {
            LMS.Library.Instance.ReaderDictionary.Remove(this.transform.parent.name);
            Destroy(this.transform.parent.gameObject);
        }
        else
        {
            LMS.Library.Instance.ReaderDictionary[this.transform.parent.name] = Value;
            this.transform.parent.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = Value.ToString();
        }


    }

}
