using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Adding books in the library
public class LibraryBook
{
    private string _bookName;
    private  int _count;

    public LibraryBook(string name, int count)
    {
        _bookName = name;
        _count = count;
   

    }
}
