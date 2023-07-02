using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Autor: Paul

public class Stay : MonoBehaviour
{
    public void Awake()
    {
        DontDestroyOnLoad(transform.gameObject); //Musik soll nicht beim laden in eine nue Scene zerstört werden
    }
}
