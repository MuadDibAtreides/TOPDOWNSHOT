using UnityEngine;
using System.Collections;

public class ControleArma : MonoBehaviour {

    public Transform armaNaMao;
    public Arma armaInicial;
    Arma armaEquipada;

    void Start()
    {
        if(armaInicial != null)
        {
            EquiparArma(armaInicial);
        }
    }

    public void EquiparArma(Arma armaParaEquipar)
    {
        if(armaEquipada != null)
        {
            Destroy(armaEquipada.gameObject);
        }

        armaEquipada = Instantiate(armaParaEquipar, armaNaMao.position, armaNaMao.rotation) as Arma;
        armaEquipada.transform.parent = armaNaMao;

    }
    public void Atirar()
    {
        if (armaEquipada != null)
        {
            armaEquipada.Tiro();
        }
    }


}
