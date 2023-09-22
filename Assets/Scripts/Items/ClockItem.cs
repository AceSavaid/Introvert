using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockItem : MonoBehaviour
{
    public int timeincrease = 10;
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerBase>().AddTime(timeincrease);
            Destroy(this.gameObject);
        }
    }
}
