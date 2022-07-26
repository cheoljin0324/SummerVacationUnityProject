using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/GunData",fileName ="Gun Data")]

public class GunData : ScriptableObject
{
    public AudioClip ShotClip; //�߻� �Ҹ�
    public AudioClip reloadClip; //������ �Ҹ�

    public float damage = 25;

    public int startAmmoRemain = 100;
    public int magen = 25;

    public float shottime = 0.12f;
    public float reloadtime = 0.25f;
}
