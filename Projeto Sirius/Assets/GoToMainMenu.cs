using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GoToMainMenu : MonoBehaviour
{

    [SerializeField] private GameObject PressioneQualquerTecla;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTelaInicial(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() == 0)
        {
            PressioneQualquerTecla.SetActive(false);
        }
  
    }
}
