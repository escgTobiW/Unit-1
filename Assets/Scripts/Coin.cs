using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //If the entity touching the coin has the tag "player" then the coin will be collected. Else it will
        if (other.gameObject.CompareTag("player"))
        {
            Destroy(gameObject);
        }
    }
}
