using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabCreator : MonoBehaviour
{
    public GameObject Pefab;
    public Transform Spawn;


    public void Create()
    {
        Instantiate(Pefab, Spawn.position, Spawn.rotation);
    }
}
