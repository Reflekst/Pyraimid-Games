using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKey : MonoBehaviour
{
    [SerializeField] private GameObject keyPrefab;
    GameObject key;

   public void Spawn()
    {
       key = Instantiate(keyPrefab, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
       Destroy(gameObject);
    }
    public void Collect()
    {
        key = GameObject.FindGameObjectWithTag("Key");
        Destroy(key);
    }
}
