using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float movespd = 5f; //앞뒤 이동속도
    public float rotspd = 180f; //좌우회전 속도

    private PlayerInput playerInput = null; //인풋 관리
    private Rigidbody playrigidBody = null; //RigidBody
    private Animator playerAnim = null; //애니매이터

    // Start is called before the first frame update
    void Start()
    {
        //캐싱
        playerInput = GetComponent<PlayerInput>();
        playrigidBody = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        //회전 실행
        Rotated();

        //움직임 실행
        Moved();

        //애니매이션 처리
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
        //Vector3의 포워드는 001로 이루어짐 transform.forward는 해당 오브젝트의 전방

        playrigidBody.MovePosition(playrigidBody.position + moveDistance);
    }
    
    void AnimPlayed()
    {
        playerAnim.SetFloat("Move", playerInput.move);
    }
}
