using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{
    private GameManager Manager;

    public TextMeshProUGUI BestScoreText;
    public TMP_InputField NameInput;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.GetGameManager() != null)
        {
            Manager = GameManager.GetGameManager();
            Manager.CurrentPoints = 0;
            Manager.UpdateBestScoreText(BestScoreText);
        }
    }

    public void UpdatePlayerName()
    {
        Manager.PlayerName = NameInput.text;
    }
}
