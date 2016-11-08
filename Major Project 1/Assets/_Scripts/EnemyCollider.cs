using UnityEngine;
using System.Collections;

public class EnemyCollider : MonoBehaviour
{
    public EnemyManager enemyMang;

    void OnCollisionEnter2D(Collision2D coll)
    {
        BoxCollider2D boxColl = gameObject.GetComponent<BoxCollider2D>();
        boxColl.enabled = false;
        if (coll.gameObject.CompareTag("Player"))    
            enemyMang.attack();
    }
}
