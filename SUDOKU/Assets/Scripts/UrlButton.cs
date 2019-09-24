using UnityEngine;
using System.Collections;

public class UrlButton : MonoBehaviour
{
    void Start()
    {
        
    }
    public void privacy()
    {
        Application.OpenURL("http://www.google.com");
    }
    public void About()
    {
        Application.OpenURL("http://www.google.com");
    }
}