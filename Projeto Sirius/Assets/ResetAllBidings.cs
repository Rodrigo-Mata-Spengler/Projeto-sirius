
using UnityEngine;
using UnityEngine.InputSystem;

public class ResetAllBidings : MonoBehaviour
{
    [SerializeField] InputActionAsset inputActions;

    public void ResetAllBindings()
    {
        foreach(InputActionMap map in inputActions.actionMaps)
        {
            map.RemoveAllBindingOverrides();
        }
        PlayerPrefs.DeleteKey("rebinds");
    }
}
