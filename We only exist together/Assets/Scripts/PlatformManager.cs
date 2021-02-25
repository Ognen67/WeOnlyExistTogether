using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{

    public static PlatformManager Instance = null;
    [SerializeField]
    GameObject platformPrefab;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if (Instance != null)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    IEnumerator SpawnPlatform(Vector2 spawnPosition)
    {
        yield return new WaitForSeconds(5f);
        Instantiate(platformPrefab, spawnPosition, platformPrefab.transform.rotation);
    }
}
