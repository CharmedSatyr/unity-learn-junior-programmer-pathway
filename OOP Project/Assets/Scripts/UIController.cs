using UnityEngine;

public class UIController : MonoBehaviour
{
    protected string startButtonName = "Start Button";

    private static string _lastButtonClicked;
    public static string LastButtonClicked // ENCAPSULATION
    {
        get => _lastButtonClicked;
        private set
        {
            if (!string.IsNullOrEmpty(value))
            {
                _lastButtonClicked = value;
            }
        }
    }

    private void Start()
    {
        Debug.Log("I'll log something in the UIController and its derived classes.");
    }


    public virtual void ClickHandler() // POLYMORPHISM
    {
        LastButtonClicked = "not specified";
        Debug.Log("An object is being clicked!");
        Debug.Log($"The last button to be clicked was {LastButtonClicked}");
    }

    public virtual void ClickHandler(string buttonName) // POLYMORPHISM
    {
        LastButtonClicked = buttonName;
        Debug.Log($"The object {buttonName} is being clicked!");
        Debug.Log($"The last button to be clicked was {LastButtonClicked}");
    }
}
