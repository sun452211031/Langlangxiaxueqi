using UnityEngine;
using System.Collections;

public class onRenderer : MonoBehaviour
{
    public GameObject manager;
    void OnBecameVisible()
    {
        if (manager.activeSelf == false)
        {
            manager.SetActive(true);
        }
    }
    void OnBecameInvisible()
    {
        System.GC.Collect();
    }
}
