using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Adds the books in the memory for operation
///  Handles all the global instances like the library and the book 
/// </summary>
namespace LMS
{
    public class Library : MonoBehaviour
{
    [Header("Get the file")]
    public TextAsset TextFile;
    public string[,] sampleInput = new string[,] { { "1002564", "1" }, { "895451", "1" }, { "326581", "4" } };
     // For global records 
    public static Library Instance;
    public List<LibraryBook> Reader = new List<LibraryBook>();
    [SerializeField]
    public Dictionary<string, int> ReaderDictionary = new Dictionary<string, int>();
    public Dictionary<string, List<string>> UserBookRecords = new Dictionary<string, List<string>>();    // to see which user has which book // userid and list of books



    void Awake()
    {

            if (TextFile == null)
            {
                for (int i = 0; i < sampleInput.GetLength(0); i++)
                {
                    // LibraryBook  Books= new LibraryBook(sampleInput[i, 0], Int32.Parse(sampleInput[i, 1]));
                    // Reader.Add(Books);
                    ReaderDictionary.Add(sampleInput[i, 0], Int32.Parse(sampleInput[i, 1]));
                }
            }
            //Read from the file..
            else
            {

                string[] buffer = TextFile.ToString().Split('\n');

                foreach (string line in buffer)
                {
                    string[] nametype = line.Split('-');

                    ReaderDictionary.Add(nametype[0], Int32.Parse(nametype[1].Replace("\r", "")));
                }

            }



            // For Instance Setting 

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
}