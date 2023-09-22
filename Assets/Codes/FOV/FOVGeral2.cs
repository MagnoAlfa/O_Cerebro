using UnityEngine;

public class FOVGeral2 : MonoBehaviour
{
    [SerializeField]
    float distanciaDeVisao = 10;


    [Header("Angulo")]
    [SerializeField]
    float[] alguloVisao = { 0.5f, 0.4f, 0.3f, 0.25f, 0.2f, 0.1f, 0.03f, 0, -0.03f, -0.1f, -0.15f, -0.2f, -0.3f, -0.35f, -0.4f, -0.5f, -0.6f, -0.7f };
    [SerializeField]
    float[] alguloVisaoH = { -90, -80, -70, -60, -50, -40, -30, -20, -10, -3, 0, 3, 10, 20, 30, 40, 50, 60, 70, 80, 90 };


    [Header("Pontos")]
    [SerializeField]
    int[] pontoVisao = { 13, 13, 15, 15, 17, 17, 19, 21, 19, 17, 15, 13, 11, 9, 7, 5, 3, 1 };



    private void Update()
    {
        ChecarVisao();
    }


    void ChecarVisao()
    {
        for (int x = 0; x < alguloVisao.Length; x++)
        {
            for (int y = 0, i = 10 - (pontoVisao[x] - 1) / 2; y < pontoVisao[x]; y++, i++)
            {
                Vector3 mutiDirecao = transform.right + (transform.up * alguloVisao[x]);
                Vector3 raioDirecao = Quaternion.AngleAxis(alguloVisaoH[i], transform.up) * mutiDirecao;
                Debug.DrawRay(transform.position, raioDirecao * distanciaDeVisao, Color.white);

            }

        }

    }
}

