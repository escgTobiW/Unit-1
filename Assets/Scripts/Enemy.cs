using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    private Player px;
    public float ex;
    // Start is called before the first frame update
    void Start()
    {
        px = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        print(px);
    }
}
