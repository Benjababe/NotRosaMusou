using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private GameObject[] _spawners;
    private GameObject[] _mobs;
    public GameObject goatPrefab;
    public GameObject bernPrefab;
    void Start()
    {
        _spawners = GameObject.FindGameObjectsWithTag("MobSpawn");
    }

    void LateUpdate()
    {
        _mobs = GameObject.FindGameObjectsWithTag("Mob");
        if (_mobs.Length < 6)
        {
            int rand = (int)Random.Range(0F, 100F);

            // rare chance for bern to spawn
            if (rand < 5)
                Instantiate(bernPrefab, _spawners[rand % 2].transform);
            else
                Instantiate(goatPrefab, _spawners[rand % 2].transform);
        }
    }
}
