using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    GameObject objectToDisable;
    public static bool disabled = false;

    // Start is called before the first frame update
    void Start()
    {
        objectToDisable = GameObject.FindGameObjectWithTag("Cans");
    }

    // Update is called once per frame
    void Update()
    {
        if (disabled)
            objectToDisable.SetActive(false);
        else
            objectToDisable.SetActive(true);
    }
}
