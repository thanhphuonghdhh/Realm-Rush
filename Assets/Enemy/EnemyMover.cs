using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> waypoints = new List<Waypoint>();
    [SerializeField] [Range(0f,5f)] float speed = 1f;
    Enemy enemy;
    // Start is called before the first frame update
    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }
    void FindPath()
    {
        waypoints.Clear();
        Transform[] path = GameObject.FindGameObjectWithTag("Path").GetComponentsInChildren<Transform>();
        foreach (Transform go in  path) 
        {
            Waypoint tmp = go.GetComponent<Waypoint>();
            if (tmp != null)
            waypoints.Add(tmp);
        }   
    }

    void ReturnToStart()
    {
        transform.position = waypoints[0].transform.position;
    }

    void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }

    IEnumerator FollowPath()
    {
        foreach (var waypoint in waypoints)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float percentTravel = 0f;
            transform.LookAt(endPosition);
            while (percentTravel < 1f)
            {
                percentTravel += Time.deltaTime * speed;                
                transform.position = Vector3.Lerp(startPosition, endPosition, percentTravel);
                yield return new WaitForEndOfFrame();
            }
        }

        FinishPath();
    }
}
