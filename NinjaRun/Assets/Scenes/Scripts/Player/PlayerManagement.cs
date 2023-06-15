using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManagement : MonoBehaviour
{
    public GameObject looserScreen;

    public void Death()
    {
        Time.timeScale = 0f;
        looserScreen.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FireWall"))
        {
            Debug.Log("DEATH");
            Death();
        }
    }
}
