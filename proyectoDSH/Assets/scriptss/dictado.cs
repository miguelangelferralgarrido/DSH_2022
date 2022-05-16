using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using UnityEngine.UI;
using System.Threading;
using TMPro;

public class dictado : MonoBehaviour
{
	[SerializeField] int min, seg;
	[SerializeField] TextMeshProUGUI tiempo;
	private float restante;
	private bool enMarcha;

	private void Awake() {
		restante = (min * 60) + seg;
		enMarcha = true;
	}


    private DictationRecognizer dictationRecognizer;
    string que;

    void Start()
    {
        dictationRecognizer = new DictationRecognizer();

		//dictationRecognizer.InitialSilenceTimeoutSeconds = 5;  

		//dictationRecognizer.AutoSilenceTimeoutSeconds = 5;

		dictationRecognizer.DictationResult += DictationRecognizer_DictationResult;

		dictationRecognizer.DictationHypothesis += DictationRecognizer_DictationHypothesis;

		dictationRecognizer.DictationComplete += DictationRecognizer_DictationComplete;

		dictationRecognizer.DictationError += DictationRecognizer_DictationError;


		dictationRecognizer.Start();
    }

    private void DictationRecognizer_DictationResult(string text, ConfidenceLevel confidence)
	{
		dictationRecognizer.Start ();
        Debug.Log(text);
        if(text == "hola"){
            Debug.Log("Has entrado fiera");
			
        }
	}

	private void DictationRecognizer_DictationHypothesis(string text)
	{
		// 
	}

	private void DictationRecognizer_DictationComplete(DictationCompletionCause cause)
	{
		//dictationRecognizer.Stop ();
	}

	private void DictationRecognizer_DictationError(string error, int hresult)
	{
		// 
	}

	void OnDestroy()
	{
		
		dictationRecognizer.DictationResult -= DictationRecognizer_DictationResult;
		dictationRecognizer.DictationComplete -= DictationRecognizer_DictationComplete;
		dictationRecognizer.DictationHypothesis -= DictationRecognizer_DictationHypothesis;
		dictationRecognizer.DictationError -= DictationRecognizer_DictationError;
		dictationRecognizer.Dispose();
	}

    // Update is called once per frame
    void Update()
    {
		if(enMarcha){
        restante -= Time.deltaTime;
		if(restante < 1){
			enMarcha = false;
			Debug.Log("Sin tiempo wey");
		}
		int tempMin = Mathf.FloorToInt(restante / 60);
		int tempSeg = Mathf.FloorToInt(restante % 60);
		tiempo.text = string.Format("{00:00}:{01:00}", tempMin, tempSeg);
		}
    }
}
