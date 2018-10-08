using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : CharacterProperty {



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            print("发现玩家，开始追击！");
            StartCoroutine(Pursue(collision.transform));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            print("玩家离开，停止追击");
            StopAllCoroutines();
        }
    }

    private IEnumerator Pursue(Transform target)
    {
        Vector3 v;

        while (true)
        {
            v = target.position - transform.position;

            //print(transform.right);
            transform.Translate(v.normalized * moveSpeed * 0.02f);
            yield return new WaitForSeconds(0.02f);
        }
    }
}
