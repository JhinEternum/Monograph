using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject patientPrefab;
    [SerializeField] private int numPatients;

    private void Start()
    {
        Invoke(nameof(SpawnPatient), 5);
    }

    private void SpawnPatient()
    {
        Instantiate(patientPrefab, transform.position, Quaternion.identity);
        Invoke(nameof(SpawnPatient), Random.Range(2, 10));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
