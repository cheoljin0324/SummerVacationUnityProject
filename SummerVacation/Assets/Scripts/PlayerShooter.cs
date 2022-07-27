using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public Gun gunData;
    public Transform gunPivet;
    public Transform righthandmethod;
    public Transform lefthandmethod;

    private PlayerInput playerInput;
    private Animator playerAnimator;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerAnimator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        // 슈터 활성화
        gunData.gameObject.SetActive(true);

    }

    private void OnDisable()
    {
        gunData.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInput.fire)
        {
            gunData.Fire();
        }
        else if (playerInput.reload)
        {
            if (gunData.Reload())
            {
                playerAnimator.SetTrigger("Reload");
            }
        }
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (gunData != null)
        {
            UIManager._Inst.UpdateAmoText(gunData.magAmmo, gunData.amoRemain);
        }
    }

    private void OnAnimatorIK(int layerIndex)
    {
        //총의 기준점 (gun pivot)
        gunPivet.position = playerAnimator.GetIKHintPosition(AvatarIKHint.RightElbow);

        //IK를 이용해서 손잡이 맞춤
        playerAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1.0f);
        playerAnimator.SetIKPosition(AvatarIKGoal.LeftHand, lefthandmethod.position);

        playerAnimator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1.0f);
        playerAnimator.SetIKRotation(AvatarIKGoal.LeftHand, lefthandmethod.rotation);

        playerAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1.0f);
        playerAnimator.SetIKPosition(AvatarIKGoal.RightHand, righthandmethod.position);

        playerAnimator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1.0f);
        playerAnimator.SetIKRotation(AvatarIKGoal.RightHand,righthandmethod.rotation);
    }
}
