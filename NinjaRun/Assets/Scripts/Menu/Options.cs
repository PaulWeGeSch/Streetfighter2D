using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Autor: Paul

public class Options : MonoBehaviour
{
    //Toggle Button ob Fullscreen an ist oder aus
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
