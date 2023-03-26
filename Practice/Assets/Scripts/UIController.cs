using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI playerGoldText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetText(string text, int health)
    {
        playerHealthText.text = text + " " + health;
    }
    
    public void SetGoldText(string text, int health)
    {
        playerGoldText.text = text + " " + health;
    }
}
