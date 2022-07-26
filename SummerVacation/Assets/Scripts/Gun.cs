using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //���� ����
    public enum State
    {
        Ready, //�غ�
        Empty,
        Reloading
    }

    public State state { get; private set;}

    public Transform fireTransform;

    public ParticleSystem muzzleParticle;
    public ParticleSystem shellParticle;

    public GunData gundata;

    public LineRenderer bulletLineRenderer;

    private AudioSource gunAudioPlayer;

    private float fireDistance = 50f;

    public int amoRemain = 100;
    public int magAmmo;

    public float lastfiretime;

    private void Awake()
    {
        gunAudioPlayer = GetComponent<AudioSource>();
        bulletLineRenderer = GetComponent<LineRenderer>();

        bulletLineRenderer.positionCount = 2;
        bulletLineRenderer.enabled = false;
    }

    private void OnEnable()
    {
        amoRemain = gundata.startAmmoRemain;
        magAmmo = gundata.magen;
        state = State.Ready;

        lastfiretime = 0.0f;
    }

    //�߻� �õ�
    public void Fire()
    {
        if (state == State.Ready && Time.time >= lastfiretime + gundata.shottime)
        {
            lastfiretime = Time.time;

            Shot();
        }
    }
    //�߻� ó��
    private void Shot()
    {
        RaycastHit hit;
        Vector3 hitPos = Vector3.zero;

        //����ĳ��Ʈ(�������� , ����, �浹 ���� �����̳�,���� �Ÿ�)
        if(Physics.Raycast(fireTransform.position,fireTransform.forward,out hit, fireDistance))
        {
            hitPos = hit.point;
        }
        else
        {
            hitPos = fireTransform.position + fireTransform.forward * fireDistance;
        }

        StartCoroutine(ShotEffect(hitPos));

        magAmmo--;

        if (magAmmo <= 0)
        {
            state = State.Empty;
        }
    }

    IEnumerator ShotEffect(Vector3 hitPos)
    {
        muzzleParticle.Play();
        shellParticle.Play();

        gunAudioPlayer.PlayOneShot(gundata.ShotClip);
        bulletLineRenderer.SetPosition(0, fireTransform.position);
        bulletLineRenderer.SetPosition(1, hitPos);

        bulletLineRenderer.enabled = true;
        yield return new WaitForSeconds(0.03f);
        bulletLineRenderer.enabled = false;
    }

    public bool Reload()
    {
        if( state == State.Reloading || amoRemain <=0 || magAmmo >= gundata.magen)
        {
            return false;
        }
        StartCoroutine(ReloadRoutine());
        return true;
    }

    IEnumerator ReloadRoutine()
    {
        state = State.Reloading;
        gunAudioPlayer.PlayOneShot(gundata.reloadClip);

        yield return new WaitForSeconds(gundata.reloadtime);

        int ammoToFill = gundata.magen - magAmmo;
        if(amoRemain < ammoToFill)
        {
            ammoToFill = amoRemain;
        }

        magAmmo += ammoToFill;
        amoRemain -= ammoToFill;

        state = State.Ready;
    }
}
