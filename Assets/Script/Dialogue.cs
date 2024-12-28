using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [System.Serializable]
    public class DialogueLine
    {
        public string speaker; // El nombre del personaje que habla (Alma, Paciente, etc.)
        public string message; // El mensaje que dice el personaje
    }

    public GameObject dialogPanel; // El panel del cuadro de diálogo
    public TextMeshProUGUI dialogText; // El texto del mensaje
    public TextMeshProUGUI speakerText; // El texto del nombre del hablante
    public Button continueButton; // Botón para avanzar
    public List<DialogueLine> dialogueLines; // Lista de líneas de diálogo

    private int currentLineIndex = 0; // Índice de la línea actual
    private bool isDialogActive = false;

    void Start()
    {
        dialogPanel.SetActive(false); // Desactivar el panel al inicio
        continueButton.onClick.AddListener(NextDialogueLine); // Vincular botón
    }

    public void StartDialog()
    {
        if (dialogueLines.Count > 0)
        {
            currentLineIndex = 0;
            ShowDialogueLine();
            dialogPanel.SetActive(true);
            isDialogActive = true;
        }
    }

    void ShowDialogueLine()
    {
        if (currentLineIndex < dialogueLines.Count)
        {
            // Mostrar el nombre del hablante y su mensaje
            speakerText.text = dialogueLines[currentLineIndex].speaker;
            dialogText.text = dialogueLines[currentLineIndex].message;
        }
        else
        {
            EndDialogue(); // Terminar si no hay más líneas
        }
    }

    public void NextDialogueLine()
    {
        if (isDialogActive)
        {
            currentLineIndex++;
            ShowDialogueLine();
        }
    }

    public void EndDialogue()
    {
        dialogPanel.SetActive(false);
        isDialogActive = false;
    }
}

