using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotCreator : MonoBehaviour
{
    public GameObject CarrotPefab;
    public Transform Spawn;


    public void Create()
    {
        Instantiate(CarrotPefab, Spawn.position, Quaternion.identity);
    }
}
