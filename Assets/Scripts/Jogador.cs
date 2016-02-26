using UnityEngine;
using System.Collections;

//faz com que no momento que esse script for adicionado ao objeto, tbm seja adicionado o script ControleJogador
[RequireComponent (typeof (ControleJogador))]
[RequireComponent(typeof(ControleArma))]
public class Jogador : MonoBehaviour {

    public float velocidade = 5;

    Camera viewCamera;
    ControleJogador controle;
    ControleArma controleArma;

	void Start ()
    {
        controle = GetComponent<ControleJogador>();// faz com que a variavel "controle" se refira a classe "ControleJogador"
        controleArma = GetComponent<ControleArma>();
        viewCamera = Camera.main;
	}
	
	void Update ()
    {
        //Colhendo inputs para o movimento do personagem
        Vector3 movimento = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
        Vector3 velMovimento = movimento.normalized * velocidade;

        //enviando o Vector3 "velMovimento" para o metodo "Mover" na classe de controle
        controle.Mover(velMovimento);

        // cria um raio partindo da camara principal apontando para o cursor do mouse
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);

        //cria um plano para detectar o raio que partira da camera
        Plane chaoPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance; //float que coleta o tamanho do raio

        //pergunta se o raio esta colidindo com o plano "out" retorna a distancia do inicio do raio ao ponto de colisao
        if (chaoPlane.Raycast(ray, out rayDistance))
        {   

            Vector3 point = ray.GetPoint(rayDistance);
            
            Debug.DrawLine(ray.origin, point, Color.red);

            controle.OlharPara(point);

            //Inputs da Arma
            if (Input.GetMouseButton(0))
            {
                controleArma.Atirar();
            }
        }
	
	}
}
