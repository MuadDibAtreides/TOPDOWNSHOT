using UnityEngine;
using System.Collections;

//faz com que no momento que esse script for adicionado ao objeto, tbm seja adicionado um Rigidbody
[RequireComponent(typeof(Rigidbody))]
public class ControleJogador : MonoBehaviour {

    Vector3 velocidade;
    Rigidbody jogador;

	void Start ()
    {
        jogador = GetComponent<Rigidbody>();
	}
	
    public void Mover(Vector3 _velocidade)
    {
        velocidade = _velocidade;
    }

    public void OlharPara(Vector3 olharPara)
    {
        Vector3 corrigirAltura = new Vector3(olharPara.x, transform.position.y, olharPara.z);
        transform.LookAt(corrigirAltura);
    }

	public void FixedUpdate ()
    {
        //Movendo o jogador
        jogador.MovePosition(jogador.position + velocidade * Time.fixedDeltaTime);
	}

    
}
