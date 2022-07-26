using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public string moveAxisName = "Vertical"; //앞뒤 움직임 축
    public string rotationAxisName = "Horizontal"; //좌우 움직임 축
    public string fireButton = "Fire";
    public string reloadButton = "Reload";

    //외부에서 접근은 가능하나 대입은 내부에서만 처리 가능
    public float move { get; private set; }
    public float rotation { get; private set; }
    public bool fire { get; private set; }
    public bool reload { get; private set; }

    // Update is called once per frame
    void Update()
    {
        //gameOver

        //Move
        move = Input.GetAxis(moveAxisName);
        //Rot
        rotation = Input.GetAxis(rotationAxisName);
        //Fire
        fire = Input.GetButton(fireButton);
        //Reload
        reload = Input.GetButton(reloadButton);
    }
}
