using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instancia;

    [Header("Menu")]
    public GameObject painelInicio;
    public GameObject painelGameplay;
    public GameObject painelGameOver;

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
        painelInicio.SetActive(true);
        painelGameplay.SetActive(false);
        painelGameOver.SetActive(false);
    }

    public void IniciarJogo()
    {
        painelInicio.SetActive(false);
        painelGameplay.SetActive(true);
        StartCoroutine(GerarAlan());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AlterarScore(double valor)
    {
        score += valor;
        scoreText.text = "Score: " + score;
    }

    IEnumerator GerarAlan()
    {
        int rnd = Random.Range(0,geradoresAlan.Length);
        Instantiate(objetoAlan, geradoresAlan[rnd].position,Quaternion.identity);
        yield return new WaitForSeconds(taxaAlan);
        StartCoroutine(GerarAlan());
    }

    public void GameOver()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator FinalizarJogo()
    {
        painelGameplay.SetActive(false);
        painelGameOver.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
}
