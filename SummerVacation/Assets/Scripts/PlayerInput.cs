using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public string moveAxisName = "Vertical"; //�յ� ������ ��
    public string rotationAxisName = "Horizontal"; //�¿� ������ ��
    public string fireButton = "Fire";
    public string reloadButton = "Reload";

    //�ܺο��� ������ �����ϳ� ������ ���ο����� ó�� ����
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
