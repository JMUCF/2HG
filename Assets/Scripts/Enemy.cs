using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public int speed = 5;
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
        #region fixReaperRotation
        Quaternion currentRotation = transform.rotation;
        float desiredXRotation = 270f;
        Quaternion newRotation = Quaternion.Euler(desiredXRotation, currentRotation.eulerAngles.y, currentRotation.eulerAngles.z);
        transform.rotation = newRotation;
        #endregion

		if(fov.visibleTarget.Count > 0)
			navMeshAgent.SetDestination(target.transform.position);

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
            SceneManager.LoadScene("Dead");
        }
    }
}
