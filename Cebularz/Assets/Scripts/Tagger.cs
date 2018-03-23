using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tagger : MonoBehaviour {

    [SerializeField]
    List<string> Tags;

    public bool haveTag(string tag)
    {
        foreach(string hlp in Tags)
        {
            if (hlp == tag) return true;
        }
        return false;
    }

}
