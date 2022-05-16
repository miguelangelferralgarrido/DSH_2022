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

public class dictado : MonoBehaviour
{
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
        
    }
}
