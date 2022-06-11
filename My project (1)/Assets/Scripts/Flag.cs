using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flag : MonoBehaviour
{
    [SerializeField] private AudioSource nextLevel;
    private bool levelCompleted = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            nextLevel.Play();
            Debug.Log("The current status of the levelCompleted is " + levelCompleted);
            levelCompleted = true;
            Debug.Log("Now it's changed to" + levelCompleted);
            Invoke("CompleteLevel", 2f);
        }
    }
    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
