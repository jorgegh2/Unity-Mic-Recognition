using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;
using System.Linq;


public class VoiceRecognition : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;

    Dictionary<string, System.Action> actions = new Dictionary<string, System.Action>();

    // Start is called before the first frame update
    void Start()
    {
        actions.Add("adelante", Forward);
        actions.Add("sube", Up);
        actions.Add("baja", Down);
        actions.Add("atras", Back);
        actions.Add("recula", Back);
        actions.Add("derecha", Derecha);
        actions.Add("izquierda", Izquierda);
        actions.Add("arriba", Arriba);
        actions.Add("abajo", Abajo);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }
    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void Forward()
    {
        transform.Translate(1, 0, 0);
    }

    private void Up()
    {
        transform.Translate(0, 1, 0);
    }

    private void Back()
    {
        transform.Translate(-1, 0, 0);
    }

    private void Down()
    {
        transform.Translate(0, -1, 0);
    }

    private void Derecha()
    {
        transform.Rotate(0.0f, 45.0f, 0.0f, Space.Self);
    }
    private void Izquierda()
    {
        transform.Rotate(0.0f, -45.0f, 0.0f, Space.Self);
    }

    private void Arriba()
    {
        transform.Rotate(0.0f, 0.0f, 45.0f, Space.Self);
    }
    private void Abajo()
    {
        transform.Rotate(0.0f, 0.0f, -45.0f, Space.Self);
    }
}

