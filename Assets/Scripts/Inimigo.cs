using UnityEngine;
using System.Collections;

public class Inimigo : MonoBehaviour {

    NavMeshAgent pathFinder;
    Transform target;


	void Start ()
    {
        pathFinder = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine(RecalcularCaminho());
	}
	
	void Update ()
    {
       
	}

    IEnumerator RecalcularCaminho()
    {
        float taxaDeRecalculagem = .25f;

        while(target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, 0.0f, target.position.z);
            pathFinder.SetDestination(targetPosition);
            yield return new WaitForSeconds(taxaDeRecalculagem);
        }
    }
}
