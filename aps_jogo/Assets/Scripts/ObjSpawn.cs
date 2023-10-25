using System.Collections;
using UnityEngine;

public class ObjSpawn : MonoBehaviour // Script que faz os objetos spawnarem aleatoriamente pelo mapa
{
    public GameObject[] lixo;
    public GameObject[] spawnPoints;
    public float spawnTimer;
    void Start()
    {
        spawnTimer = GameManager.spawnTimer; 
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint"); // Código que procura todos os objetos marcados como ponto de spawn para usar sua posição
        SpawnFunction();

    }
    IEnumerator SpawnTrash(float timer)
    {

        while (GameManager.timer > 0)
        {
            spawnTimer = GameManager.spawnTimer;
            yield return new WaitForSeconds(timer);
            int lixoSelecionado = Random.Range(0, lixo.Length);
            int pointSelecionado = Random.Range(0, spawnPoints.Length);
            SpawnPoint spawn = spawnPoints[pointSelecionado].GetComponent<SpawnPoint>();
            if (spawn.isReady) // Verificação de ocupação do ponto de spawn, para não criar dois objetos no mesmo lugar
            {
                Instantiate(lixo[lixoSelecionado], spawnPoints[pointSelecionado].transform.position, Quaternion.identity); // Código que cria um objeto aleatório numa posição aleatória

            }
        }
    }
    void SpawnFunction()
    {
        StartCoroutine(SpawnTrash(spawnTimer));
    }
}
