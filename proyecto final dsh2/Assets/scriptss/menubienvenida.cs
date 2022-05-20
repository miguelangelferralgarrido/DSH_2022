using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.Windows.Speech;
using TMPro;
using UnityEngine.SceneManagement;

public class menubienvenida : MonoBehaviour
{

    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    // Start is called before the first frame update
    void Start()
    {

        actions.Add("Jugar",jugar);
        actions.Add("Creditos",creditos);
        actions.Add("Salir",salir);
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();    
        }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech){
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    
    private void jugar(){
        SceneManager.LoadScene("Menu");

    }

    private void creditos(){
    SceneManager.LoadScene("creditos");
    }

    private void salir(){
    Debug.Log("Saliendo del juego");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


