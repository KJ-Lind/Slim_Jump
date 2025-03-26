using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Trigger : MonoBehaviour
{
    public Tutorial_Dialog dialog;

    bool WasDialogTriggerd = false;

    public GameObject DialogCanvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (!WasDialogTriggerd)
            {
                DialogCanvas.SetActive(true);
                WasDialogTriggerd = true;
                TriggerDialog();
            }
        }

    }

    public void TriggerDialog()
    {
        FindObjectOfType<Dialog_Manager>().StartDialog(dialog);
    }

}
