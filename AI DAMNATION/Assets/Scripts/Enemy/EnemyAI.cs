using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;

    [SerializeField] float turnSpeed = 5f;

    public float chaseRange;

    float distanceToTarget;

    //bool isProvoked;

    NavMeshAgent navMeshAgent;

    AudioSource movementSound;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        chaseRange = 15f;

        target = FindObjectOfType<PlayerHealth>().transform;

        //isProvoked = false;

        movementSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        EngageTarget();
        
        //if (isProvoked)
        //{
        //    EngageTarget();
        //}

        //else if (distanceToTarget <= chaseRange)
        //{
        //    isProvoked = true;
        //}
    }

    //public void OnDamageTaken()
    //{
    //    isProvoked = true;
    //}

    void EngageTarget()
    {
        FaceTarget();

        if (distanceToTarget > navMeshAgent.stoppingDistance)
        {
            navMeshAgent.SetDestination(target.position);

            GetComponent<Animator>().SetBool("Attack", false);

            GetComponent<Animator>().SetTrigger("Move");

            //movementSound.Play();
        }

        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            GetComponent<Animator>().SetBool("Attack", true);

            if (!movementSound.isPlaying)
            {
                movementSound.Play();
            }

            //movementSound.Play();
        }
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;

        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);

    }


}
