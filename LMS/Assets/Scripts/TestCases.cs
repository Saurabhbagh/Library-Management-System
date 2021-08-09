using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI; 
public class TestCases : MonoBehaviour
{
    private Dictionary<string, int> Dict;
    public Button TestCase;
    public ShowBooks showLibbooks;

    public GameObject BooklistAdd; 
    private AddToMylist add;

    public UserBooks  ShowTheBookUser;
    public GameObject UserBooklistRemove;
    private Remove remove;

    private void Start()
    {
        TestCase.onClick.AddListener(check);
        Dict = LMS.Library.Instance.ReaderDictionary.ToDictionary(entry => entry.Key,
                                               entry => entry.Value); ;
    }
    void check()
    {
        StartCoroutine(showtests());
    }

    public  IEnumerator showtests()
    {

        // Checking for null data 
        //Debug.Log(Dict.Count);
        //check for empty DataBase 
        LMS.Library.Instance.ReaderDictionary.Clear();
        showLibbooks.Show();
        yield return new WaitForSeconds(1);

        // Check for someData in database
        LMS.Library.Instance.ReaderDictionary = Dict;
        //  Debug.Log(Dict.Count);
        //Debug.Log(LMS.Library.Instance.ReaderDictionary.Count);
        showLibbooks.Show();
        yield return  new WaitForSeconds(1);


        // Checking if we can add  a book
        add = BooklistAdd.transform.GetChild(0).transform.GetChild(2).GetComponent<AddToMylist>();
        add.AddTheBook();
        add = BooklistAdd.transform.GetChild(1).transform.GetChild(2).GetComponent<AddToMylist>();
        add.AddTheBook();
        yield return new WaitForSeconds(1);
        // show the books I have 

        ShowTheBookUser.ShowUserBook();
        yield return new WaitForSeconds(1);
        ShowTheBookUser.ClosePanel();
        yield return new WaitForSeconds(1);

        // Removing the data 
        ShowTheBookUser.ShowUserBook();
        yield return new WaitForSeconds(1);
        remove = UserBooklistRemove.transform.GetChild(0).transform.GetChild(2).GetComponent<Remove>();
        remove.RemoveFromUser();
        yield return new WaitForSeconds(1);
        //Debug.Log("Removed 1");
        remove = UserBooklistRemove.transform.GetChild(0).transform.GetChild(2).GetComponent<Remove>();
        remove.RemoveFromUser();
       // Debug.Log("Removed 2");
        yield return new WaitForSeconds(1);
        // show the books Library has 

        ShowTheBookUser.ClosePanel();
        yield return new WaitForSeconds(1);
        showLibbooks.Show();
        yield return new WaitForSeconds(1);
        //try adding the same book twice 

        add = BooklistAdd.transform.GetChild(2).transform.GetChild(2).GetComponent<AddToMylist>();
        add.AddTheBook();
        add = BooklistAdd.transform.GetChild(2).transform.GetChild(2).GetComponent<AddToMylist>();
        add.AddTheBook();
        yield return new WaitForSeconds(1);

    }

}
