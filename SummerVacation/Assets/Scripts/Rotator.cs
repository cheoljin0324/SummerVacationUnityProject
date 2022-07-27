using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpd = 60f;

    private void Update()
    {
        transform.Rotate(0f, rotationSpd * Time.deltaTime, 0f);
    }
}
