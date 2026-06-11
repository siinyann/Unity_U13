using UnityEngine;
using UnityEngine.UI;

public class CreditScript : MonoBehaviour
{
    public GameObject frameToToggle; // Assign the frame GameObject in the Inspector

    void Start()
    {
        Button btn = GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.AddListener(OnButtonClick);
        }
        else
        {
            Debug.LogError("No Button component found on this GameObject!");
        }
    }

    public void OnButtonClick()
    {
        Debug.Log("goodbye world");

        if (frameToToggle != null)
        {
            // Toggle the frame (and its children, including the Text child)
            frameToToggle.SetActive(!frameToToggle.activeSelf);
        }
        else
        {
            Debug.LogWarning("frameToToggle is not assigned in the Inspector!");
        }
    }
}