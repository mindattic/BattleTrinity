using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor2D : MonoBehaviour
{
    //Awake is called when the script instance is being loaded
    private void Awake()
    {
     
    }

    //Start() is called just before any of the update methods is called the first time
    void Start()
    {
        Cursor.visible = false;
    }

    //Update() is called every frame (as often as possible)
    void Update()
    {
        transform.position = Input.mousePosition;
    }

}
