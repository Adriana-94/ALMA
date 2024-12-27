using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro; // Importa el namespace de TextMeshPro


public class Dialogue : MonoBehaviour
{

    public GameObject dialogPanel;  // El panel del cuadro de diálogo
    public TextMeshProUGUI dialogText;         // El texto dentro del cuadro de diálogo
    public Button continueButton;   // El botón para continuar

    private bool isDialogActive = false;

    void Start()
    {
        // Asegúrate de que el panel de diálogo esté desactivado al inicio
        dialogPanel.SetActive(false);

        // Añadir un evento al botón para cerrar el diálogo
        continueButton.onClick.AddListener(CloseDialog);
    }

    public void StartDialog(string message)
    {
        // Mostrar el panel de diálogo
        dialogPanel.SetActive(true);
        dialogText.text = message; // Establecer el mensaje
        Debug.Log("Mostrando diálogo: " + message);
        isDialogActive = true;
    }

    public void CloseDialog()
    {
        // Ocultar el panel de diálogo y permitir continuar
        dialogPanel.SetActive(false);
        isDialogActive = false;
    }

    void Update()
    {
        // Si el diálogo está activo, permitir que el jugador lo cierre presionando Enter
        if (isDialogActive && Input.GetKeyDown(KeyCode.Return))
        {
            CloseDialog();
        }
    }

    private void OnTriggerEnter(Collider other) 
    { if (other.gameObject.CompareTag("Alma")) 
        { StartDialog("Hola, bienvenido."); 
        } 
    }
}
