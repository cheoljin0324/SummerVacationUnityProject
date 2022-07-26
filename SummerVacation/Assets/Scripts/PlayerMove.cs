using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float movespd = 5f; //�յ� �̵��ӵ�
    public float rotspd = 180f; //�¿�ȸ�� �ӵ�

    private PlayerInput playerInput = null; //��ǲ ����
    private Rigidbody playrigidBody = null; //RigidBody
    private Animator playerAnim = null; //�ִϸ�����

    // Start is called before the first frame update
    void Start()
    {
        //ĳ��
        playerInput = GetComponent<PlayerInput>();
        playrigidBody = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        //ȸ�� ����
        Rotated();

        //������ ����
        Moved();

        //�ִϸ��̼� ó��
        AnimPlayed();
    }

    void Rotated()
    {
        float turn = playerInput.rotation * rotspd * Time.deltaTime;
        playrigidBody.rotation = playrigidBody.rotation * Quaternion.Euler(0f, turn, 0f);
    }

    void Moved()
    {
        Vector3 moveDistance = playerInput.move * transform.forward *movespd* Time.deltaTime;
        //Vector3�� ������� 001�� �̷���� transform.forward�� �ش� ������Ʈ�� ����

        playrigidBody.MovePosition(playrigidBody.position + moveDistance);
    }
    
    void AnimPlayed()
    {
        playerAnim.SetFloat("Move", playerInput.move);
    }
}
