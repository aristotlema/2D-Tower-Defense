using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BuildTower(Vector3 spawnCoordiantes)
    {
        Instantiate(towerPrefab, new Vector3(spawnCoordiantes.x + 0.5f, spawnCoordiantes.y + 0.5f), Quaternion.identity);
    }
}
