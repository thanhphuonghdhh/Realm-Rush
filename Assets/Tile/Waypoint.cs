using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isPlaceable;// to indicate a tile can be place tower or not
    public bool IsPlaceable {  get { return isPlaceable; } }

    private void OnMouseDown()
    {
        if (isPlaceable)
        {

            bool isPlace = towerPrefab.CreateTower(towerPrefab,transform.position);
            isPlaceable = !isPlace;
        } 
    }
}
