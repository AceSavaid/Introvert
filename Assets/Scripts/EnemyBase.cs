using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int ticDamage;
    public int speed;
    //public List<Transform> movePoints = new List<Transform>();
    Vector3 center = new Vector3(0,0,0);
    Vector3 movePos;

    // Start is called before the first frame update
    void Start()
    {
        movePos = center + new Vector3(Random.Range(-22, 22), Random.Range(-22, 22), 0);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Vector2.Distance(movePos, this.transform.position) <=1)
        {
            NewSpawn();
        }
    }

    void Move()
    {
        Vector3 dist = movePos - this.transform.position;
        transform.position += dist.normalized * Time.deltaTime * speed;
    }

    void NewSpawn()
    {
        movePos = center + new Vector3(Random.Range(-22, 22), Random.Range(-22, 22), 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerBase>().Hurt(ticDamage);
        }
    }
}
