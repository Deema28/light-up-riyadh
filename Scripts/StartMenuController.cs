
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public GameObject startMenuPanel;
    public GameObject difficultyPanel;
    public Image easyImage;
    public Image hardImage;
    private int selectedDifficulty = 0; // Easy افتراضيًا

    void Start()
    {
        startMenuPanel.SetActive(true);
        difficultyPanel.SetActive(false);
        UpdateSelectionVisual();
    }

    public void OpenDifficulty()
    {
        startMenuPanel.SetActive(false);
        difficultyPanel.SetActive(true);
    }

    public void ChooseEasy()
    {
        selectedDifficulty = 0;
        UpdateSelectionVisual();
        Debug.Log("EASY Selected");
    }

    public void ChooseHard()
    {
        selectedDifficulty = 1;
        UpdateSelectionVisual();
        Debug.Log("HARD Selected");
    }

    public void PlayGame()
    {
        PlayerPrefs.SetInt("Difficulty", selectedDifficulty);
        PlayerPrefs.Save();

        SceneManager.LoadScene("GameScene");
    }

    void UpdateSelectionVisual()
    {
        if (easyImage == null || hardImage == null)
            return;

        easyImage.color = selectedDifficulty == 0
            ? Color.white
            : new Color(0.4f, 0.4f, 0.4f, 1f);

        hardImage.color = selectedDifficulty == 1
            ? Color.white
            : new Color(0.4f, 0.4f, 0.4f, 1f);
    }

}
