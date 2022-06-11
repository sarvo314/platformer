using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int collectables = 0;
    [SerializeField]private Text appleScore;
    [SerializeField] private AudioSource collectSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            Destroy(collision.gameObject);
            Debug.Log("The number of apples is " + ++collectables);
            appleScore.text = "Apples: " + collectables;
            collectSoundEffect.Play();
        }
        
    }


}
