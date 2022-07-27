using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPack : MonoBehaviour,IItem
{
    public float health = 50;

    public void Use(GameObject target)
    {
        LivingEntity live = target.GetComponent<LivingEntity>();

        if (live != null)
        {
            live.RestoreHealth(health);
        }
        Destroy(gameObject);
    }
}
