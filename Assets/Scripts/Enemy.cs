using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public int speed = 5;
    public GameObject deadText;
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    private int currentWaypointIndex;
    public GameObject[] SoundBox;

	private FieldOfView fov;

    // Start is called before the first frame update
    void Start()
    {
		fov = GetComponent<FieldOfView>();
		
        navMeshAgent.SetDestination(waypoints[0].position);
        navMeshAgent.stoppingDistance = 1f;
    }

    // Update is called once per frame
    void Update()
    {
		if(fov.visibleTarget.Count > 0)
			navMeshAgent.SetDestination(target.transform.position);
		
        /* move to sound code
        SoundBox = GameObject.FindGameObjectsWithTag("SoundBox");

        if (SoundBox.Length != 0)
            navMeshAgent.SetDestination(SoundBox[0].transform.position);
        */

        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("You were caught!");
            //play a sound effect here
            //bring up UI to go back to menu
            deadText.SetActive(true);
            Time.timeScale = 0; //pause the game
        }
    }

/*
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "SoundBox")
        {
            Debug.Log("Enemy hit sound box");
            Destroy(collision.gameObject);
        }
    }*/
}
