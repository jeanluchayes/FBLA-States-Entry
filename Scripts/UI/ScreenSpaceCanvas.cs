//Jean-Luc Hayes 02/01/16
////blog.manapebbles.com/world-space-overlay-camera-in-unity
//Sorts the depth of the enemies from the screen with compare function
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScreenSpaceCanvas : MonoBehaviour
{
    List<DepthUI> panels = new List<DepthUI>();

    // Use this for initialization
    void Awake ()
    {
        panels.Clear();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Sort();	
	}

    public void AddToCanvas(GameObject objects)
    {
        panels.Add(objects.GetComponent<DepthUI>());
    }

    void Sort()
    {
        panels.Sort((x, y) => x.depth.CompareTo(y.depth));
        for (int i = 0; i < panels.Count; i++)
        {
            panels[i].transform.SetSiblingIndex(i);
        }
    }
}
