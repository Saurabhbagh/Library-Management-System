using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class UserBooks : MonoBehaviour
{

    //Buttons 
    public Button buttonBooks;
    public Button OK;

    //Name of the user 
    public string Name;
    // Anchor objects
    public GameObject panel;
    public GameObject NoBookAvail;
    public GameObject Prefabs;
    public GameObject ObjectforReference;
    public GameObject BookList;
    public TextMeshProUGUI text;
    public float Padding = 49.0f;


     void Awake()
    {
       
        OK.onClick.AddListener(ClosePanel); 
        buttonBooks.onClick.AddListener(ShowUserBook);
    }

    public  void ClosePanel()
    {
        panel.SetActive(false);
        if (BookList.transform.childCount > 0)
        {
            foreach (Transform child in BookList.transform)
            {
                Destroy(child.gameObject);
                ObjectforReference.transform.localPosition = new Vector3(ObjectforReference.transform.localPosition.x, ObjectforReference.transform.localPosition.y+ Padding, ObjectforReference.transform.localPosition.z);
            }

        }
     }
    public  void ShowUserBook()
    {

        // Enable panel 
        panel.SetActive(true);
        if(UserClass.Instance!=null)
        {
            text.text = "Hello " + UserClass.Instance.getUsername();
        }
        else
        {

            UserClass.Instance = new UserClass();
        }
     
        if (UserClass.Instance._BookDictonary.Count < 1)
        {
            Debug.Log("No books");
            NoBookAvail.SetActive(true);
        }
        else
        {
            NoBookAvail.SetActive(false);
            foreach (KeyValuePair<string, int> book in UserClass.Instance._BookDictonary)
            {
                RunUserBookList(book.Key, book.Value);

            }
         }

    }



    void RunUserBookList(string BookName, int Count)
    {
        
            GameObject Go = Instantiate(Prefabs);
            Go.transform.SetParent(panel.transform.GetChild(0)); // the fist chlild is the book list holder, any changes to this will now work properly
            Go.transform.position = new Vector3(ObjectforReference.transform.position.x, ObjectforReference.transform.position.y, ObjectforReference.transform.position.z);
            Go.name = BookName;
            Go.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = BookName;
            Go.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = Count.ToString(); // Should be displayed in the String Format
            Go.transform.localScale = new Vector3(1, 1, 1);
            // changing the values  of the position 
            ObjectforReference.transform.localPosition = new Vector3(ObjectforReference.transform.localPosition.x, ObjectforReference.transform.localPosition.y - Padding, ObjectforReference.transform.localPosition.z);

    }
}
