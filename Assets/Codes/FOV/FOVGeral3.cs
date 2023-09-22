using UnityEngine;

public class FOVGeral3 : MonoBehaviour
{
    [Header("Distancias de visões")]
    [SerializeField]
    float distanciaDeVisaoMira;
    [SerializeField]
    float distanciaDeVisaoFoco;
    [SerializeField]
    float distanciaDeVisaoObjeto;
    [SerializeField]
    float distanciaDeVisaoContorno;
    [SerializeField]
    float distanciaDeVisaoCores;
    [SerializeField]
    float distanciaDeVisaoMovimento;


    [Header("Visão")]
    [SerializeField]
    [Range(3, 5)]
    float foco;
    [SerializeField]
    [Range(10, 15)]
    float objeto;
    [SerializeField]
    [Range(20, 30)]
    float contorno;
    [SerializeField]
    [Range(30, 60)]
    float cores;
    [SerializeField]
    [Range(75, 90)]
    float movimento =90;





    [Header("Angulo")]
    [SerializeField]
    float[] alguloVisao;
    [SerializeField]
    float[] alguloVisaoH;


    [Header("Pontos")]
    [SerializeField]
    int[] pontoVisao;



    private void Update()
    {
        ChecarVisao();
    }


    void ChecarVisao()
    {
        for (int x = 0; x < alguloVisao.Length; x++)
        {
            for (int y = 0; y < pontoVisao[x]; y++)
            {
                
            }

        }

    }
}

