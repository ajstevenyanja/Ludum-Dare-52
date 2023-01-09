using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// simple script with functions
// which can open assigned url
// tutorial link - https://www.youtube.com/watch?v=qqOqLNqAdDo

public class OpenURL : MonoBehaviour
{
    // enter your url here
    [SerializeField] string url = "https://www.youtube.com/@neon_overplay";

    // call this function externally from a button or a script
    public void Open()
    {
        Application.OpenURL(url);
    }

    // same function but for opening a custom url
    public void Open(string url)
    {
        Application.OpenURL(url);
    }
}
