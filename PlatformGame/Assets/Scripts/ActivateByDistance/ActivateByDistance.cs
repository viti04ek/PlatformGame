using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ActivateByDistance : MonoBehaviour
{
    public float DistanceToActivate = 20;
    private bool _isActive = true;
    private Activator _activator;


    private void Start()
    {
        _activator = FindObjectOfType<Activator>();

        _activator.ObjectsToActivate.Add(this);
    }


    public void CheckDistance(Vector3 playerPosition)
    {
        float distance = Vector3.Distance(transform.position, playerPosition);

        if (distance < DistanceToActivate && !_isActive)
            Activate();
        else if (distance > DistanceToActivate + 2f && _isActive)
            Deactivate();
    }


    public void Activate()
    {
        gameObject.SetActive(true);

        _isActive = true;
    }


    public void Deactivate()
    {
        gameObject.SetActive(false);

        _isActive = false;
    }


    private void OnDestroy()
    {
        _activator.ObjectsToActivate.Remove(this);
    }


    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.gray;
        Handles.DrawWireDisc(transform.position, Vector3.forward, DistanceToActivate);
    }
}
