using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void OnDamage(float Damage, Vector3 hitPoint, Vector3 hitNormal);
}