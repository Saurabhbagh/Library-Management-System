using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ShowBooks : MonoBehaviour
{
    public Button showBooks;
    public GameObject BookList;
    public GameObject Prefabs;
    public GameObject ObjectforReference; // Object for positioning 
    public float Padding; // where the next book entry would be shown
    public GameObject NoBookAvail; 
    private void Awake()
    {
        showBooks.onClick.AddListener(Show);
     }

    //show books
    private void Show()
    {
        //   Debug.Log(LMS.Library.Instance.ReaderDictionary.Count);
        if (LMS.Library.Instance.ReaderDictionary.Count<1)
        {
            Debug.Log("No books");
            NoBookAvail.SetActive(true);
        }
        else
        {
            NoBookAvail.SetActive(false);

            //to see if the list is populated already or not 
            if (BookList.transform.childCount > 0)
            {
                foreach (Transform child in BookList.transform)
                {
                    Destroy(child.gameObject);
                    ObjectforReference.transform.localPosition = ValueSender(ObjectforReference.transform, false);
                }


                RunShowBook();
            }

            else
            {
                // if not run
                RunShowBook();
            }
        }
      
     }

    //operation to show books
    void RunShowBook ()
    {

        foreach (KeyValuePair<string, int> book in LMS.Library.Instance.ReaderDictionary)
        {
            ShowOneBook(book.Key, book.Value);
        }
    }

    void ShowOneBook(String BookName, int Count )
    {
        GameObject Go = Instantiate(Prefabs);
        Go.transform.SetParent(this.transform.GetChild(0)); // the fist chlild is the book list holder, any changes to this will now work properly
        Go.transform.position = new Vector3(ObjectforReference.transform.position.x, ObjectforReference.transform.position.y, ObjectforReference.transform.position.z);
        Go.name = BookName;
        Go.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = BookName;
        Go.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = Count.ToString(); // Should be displayed in the String Format
        Go.transform.localScale = new Vector3(1, 1, 1);
        // changing the values  of the position 
        ObjectforReference.transform.localPosition = ValueSender(Go.transform, true);
    }


    /// <summary>
    /// To set the value of the the reference object to which the next line will be shown
    /// </summary>
    /// <param name="Value"></param>
    /// <param name="padding"></param>
    /// <returns></returns>
    public Vector3 ValueSender(Transform Value, bool  padding)
    {
        if (padding)
        {
            return new Vector3(Value.localPosition.x, Value.localPosition.y - Padding, Value.localPosition.z);
        }
        else
        {

            return new Vector3(Value.localPosition.x, Value.localPosition.y+ Padding, Value.localPosition.z);
        }

    }
}