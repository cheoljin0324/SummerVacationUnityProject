using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : LivingEntity
{
    public Slider healthSlider;

    public AudioClip hitClip;
    public AudioClip deathClip;
    public AudioClip pickUpClip;

    private AudioSource playerAudioPlayer;
    private Animator playerAnimator;

    private PlayerMove playerMove;
    private PlayerShooter playershooter;

    private void Awake()
    {
        playerAudioPlayer = GetComponent<AudioSource>();
        playerAnimator = GetComponent<Animator>();

        playerMove = GetComponent<PlayerMove>();
        playershooter = GetComponent<PlayerShooter>();
    }

    protected override void OnEnable()
    {
        //부모의 OnEnable()
        base.OnEnable();
        healthSlider.gameObject.SetActive(true);
        healthSlider.maxValue = startingHealth;
        healthSlider.value = health;

        playerMove.enabled = true;
        playershooter.enabled = true;
    }

    public override void OnDamage(float Damage, Vector3 hitPoint, Vector3 hitNormal)
    {
        if (!death)
        {
            playerAudioPlayer.PlayOneShot(hitClip);
        }
        base.OnDamage(Damage, hitPoint, hitNormal);

        //갱신
        healthSlider.value = health;
    }

    public override void RestoreHealth(float newHealth)
    {
        base.RestoreHealth(newHealth);

        healthSlider.value = health;
    }

    public override void Die()
    {
        base.Die();

        healthSlider.gameObject.SetActive(false);
        playerAudioPlayer.PlayOneShot(deathClip);
        playerAnimator.SetTrigger("Die");
        playerMove.enabled = false;
        playershooter.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!death)
        {
            IItem item = other.GetComponent<IItem>();
            if(item != null)
            {
                item.Use(gameObject);
                playerAudioPlayer.PlayOneShot(pickUpClip);
            }
        }
    }
}
