using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instancia;

    [Header("Pontuação")]
    public double score;
    public TMP_Text scoreText;

    [Header("Gerador de Alans")]
    public GameObject objetoAlan;
    public Transform[] geradoresAlan;
    public float taxaAlan;

    private void Awake()
    {
        Instancia = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GerarAlan());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AlterarScore(double valor)
    {
        score += valor;
        scoreText.text = "SCORE: " + score;
    }

    IEnumerator GerarAlan()
    {
        int rnd = Random.Range(0,geradoresAlan.Length);
        Instantiate(objetoAlan, geradoresAlan[rnd].position,Quaternion.identity);
        yield return new WaitForSeconds(taxaAlan);
        StartCoroutine(GerarAlan());
    }


}
