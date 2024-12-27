using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro; // Importa el namespace de TextMeshPro


public class Dialogue : MonoBehaviour
{

    public GameObject dialogPanel;  // El panel del cuadro de di�logo
    public TextMeshProUGUI dialogText;         // El texto dentro del cuadro de di�logo
    public Button continueButton;   // El bot�n para continuar

    private bool isDialogActive = false;

    void Start()
    {
        // Aseg�rate de que el panel de di�logo est� desactivado al inicio
        dialogPanel.SetActive(false);

        // A�adir un evento al bot�n para cerrar el di�logo
        continueButton.onClick.AddListener(CloseDialog);
    }

    public void StartDialog(string message)
    {
        // Mostrar el panel de di�logo
        dialogPanel.SetActive(true);
        dialogText.text = message; // Establecer el mensaje
        Debug.Log("Mostrando di�logo: " + message);
        isDialogActive = true;
    }

    public void CloseDialog()
    {
        // Ocultar el panel de di�logo y permitir continuar
        dialogPanel.SetActive(false);
        isDialogActive = false;
    }

    void Update()
    {
        // Si el di�logo est� activo, permitir que el jugador lo cierre presionando Enter
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
