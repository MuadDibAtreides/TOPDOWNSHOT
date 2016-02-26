using UnityEngine;
using System.Collections;

public class Projeteis : MonoBehaviour {

    public LayerMask collisionMask;
    public float velocidade = 10;

    public void DefinirVel(float novaVelocidade)
    {
        velocidade = novaVelocidade;
    }

	void Update ()
    {
        float moveDistance = velocidade * Time.deltaTime;
        CheckCollisions(moveDistance);
        transform.Translate(Vector3.forward * moveDistance);
	
	}

    void CheckCollisions(float moveDistance)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, moveDistance, collisionMask, QueryTriggerInteraction.Collide))
        {
            OnHitObject(hit);
        }
    }

    void OnHitObject(RaycastHit hit)
    {
        print(hit.collider.gameObject.name);
        GameObject.Destroy(gameObject);
    }
}
