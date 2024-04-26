using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
   public float hitpoints;
   public float maxHitpoints = 5;
   void Start()
   {
       hitpoints = maxHitpoints;
   }
   public void TakeHit(float damage)
   {
       hitpoints -= damage;
       if (hitpoints <= 0)
       {
           Destroy(gameObject);
       }
   }
}