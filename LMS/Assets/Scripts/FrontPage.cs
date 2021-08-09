using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class FrontPage : MonoBehaviour
{
    public Button Submit;
    public TMP_InputField  Name; 

    private void Awake()
    {
        Submit.onClick.AddListener(SetUserName);
    }

    private void SetUserName()
    {
        if( Name.text=="")
        {
            Name.text = "Cannot have blank Input";
            return;
        }
        else
        {

            UserClass.Instance.setUsername(Name.text);
            SceneManager.LoadScene("lms");

        }

        
    }
}
