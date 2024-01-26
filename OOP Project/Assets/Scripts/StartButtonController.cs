using UnityEngine.SceneManagement;

public class StartButtonController : UIController // INHERITANCE
{
    public override void ClickHandler()
    {
        base.ClickHandler(startButtonName); // POLYMORPHISM, INHERITANCE
        LoadSampleScene(); // ABSTRACTION
    }

    void LoadSampleScene()
    {
        SceneManager.LoadScene(1);
    }
}
