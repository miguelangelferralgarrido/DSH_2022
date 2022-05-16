using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.Windows.Speech;
using TMPro;
using UnityEngine.SceneManagement;

public class vocess : MonoBehaviour
{
    public int puntos;
    public TextMeshProUGUI puntuacion;
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    // Start is called before the first frame update
    void Start()
    {
        puntos = 0;
        puntuacion.text="Puntos totales: "+puntos;
        actions.Add("adelante",Forward);
        actions.Add("detras",Back);
        actions.Add("arriba",Up);
        actions.Add("abajo",Down);
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();    
        }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech){
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void Forward(){
        puntos += 10;
        puntuacion.text="Puntos totales: "+puntos;
        transform.Translate(2,0,0);
    }

    private void Back(){
        puntos -= 10;
        puntuacion.text="Puntos totales: "+puntos;
        transform.Translate(-2,0,0);
    }

    private void Up(){
        puntos += 5;
        puntuacion.text="Puntos totales: "+puntos;
        transform.Translate(0,2,0);
    }

    private void Down(){
        puntos -= 5;
        puntuacion.text="Puntos totales: "+puntos;
        transform.Translate(0,-2,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
