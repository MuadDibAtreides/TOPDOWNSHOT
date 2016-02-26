using UnityEngine;
using System.Collections;

public class Arma : MonoBehaviour {

    public Transform muzzle;
    public Projeteis bala;
    public float ratioOfFire = 100;
    public float velocidadeBala = 35;
    float proximoTiro;

    public void Tiro()
    {
        if (Time.time > proximoTiro)
        {
            proximoTiro = Time.time + ratioOfFire / 1000; 
            Projeteis novoProjetil = Instantiate(bala, muzzle.position, muzzle.rotation) as Projeteis;
            novoProjetil.DefinirVel(velocidadeBala);

        }
    }
}
