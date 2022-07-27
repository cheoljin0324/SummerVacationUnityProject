using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ItemSpawner : MonoBehaviour
{

    public GameObject[] Item;
    public Transform playerTransform;

    public float maxDistance = 5f;

    public float timeBetSpawnMax = 7f;
    public float timeBetSpawnMin = 2f;
    public float timeSpawnBet;
    public float lastSpawnBet;

    private void Start()
    {
        timeSpawnBet = Random.Range(timeBetSpawnMin, timeBetSpawnMax);
        lastSpawnBet = 0f;
    }

    private void Update()
    {
        if(Time.time>=lastSpawnBet + timeSpawnBet&&playerTransform != null)
        {
            lastSpawnBet = Time.time;
            timeSpawnBet = Random.Range(timeSpawnBet, timeBetSpawnMax);

            Spawn();
        }
    }

    void Spawn()
    {
        Vector3 spawnPosition = GetRandomPointOnNavbMesh(playerTransform.position, maxDistance);

        spawnPosition += Vector3.up * 0.5f;
        GameObject selectedItem = Item[Random.Range(0, Item.Length)];
        GameObject item = Instantiate(selectedItem, spawnPosition, Quaternion.identity);
    }

    Vector3 GetRandomPointOnNavbMesh(Vector3 center, float distance)
    {
        //insideUnitSphere은 반지름 1구에서 랜덤하게 좌표를 반환
        Vector3 randompos = Random.insideUnitSphere * distance + center;

        NavMeshHit hit;
        //distance안에서 randpsos에 가장 가까운 네비메시 위의 안 점을 찾음
        NavMesh.SamplePosition(randompos, out hit, distance, NavMesh.AllAreas);

        return hit.position;
    }
}
