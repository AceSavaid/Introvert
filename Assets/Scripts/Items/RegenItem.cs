using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenItem : MonoBehaviour
{
    public int increase;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerBase>().score += increase;
            Destroy(this.gameObject);
        }
    }
}
