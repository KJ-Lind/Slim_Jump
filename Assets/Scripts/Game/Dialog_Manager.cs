using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog_Manager : MonoBehaviour
{
    private Queue<string> sentences;

    public float DialogTimer = 2.0f;

    public float localTimer = 0.0f;

    public Text DialogText;

    public bool DialogDone = false;

    public GameObject DialogCanvas;

    public float WriteSpeed;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialog(Tutorial_Dialog dialog)
    {
        Debug.Log("Started Dialog" + dialog);

        sentences.Clear();

        foreach(string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
 
    private void DisplayNextSentence()
    {
        localTimer = DialogTimer;

        if(sentences.Count == 0) 
        {
            EndDialog();
            return;
        }

        string sentrece = sentences.Dequeue();

        StartCoroutine(TypeSentence(sentrece));

    }

    IEnumerator TypeSentence(string sentence) 
    {

        DialogText.text = "";
        foreach(char letter in sentence.ToCharArray()) 
        {

            DialogText.text += letter;
            yield return new WaitForSeconds(WriteSpeed);
        }

    }

    private void EndDialog()
    {
        DialogDone = true;
    }

    public void Update()
    {
        if (!DialogDone)
        {
            localTimer -= Time.deltaTime;

            if (localTimer <= 0.0f)
            {
                DisplayNextSentence();
            }
        }
    }

}
