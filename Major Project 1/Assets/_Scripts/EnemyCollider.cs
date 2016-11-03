using UnityEngine;
using System.Collections;

public class EnemyCollider : MonoBehaviour
{
    public EnemyManager enemyMang;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))    
            enemyMang.attack();
    }
}
