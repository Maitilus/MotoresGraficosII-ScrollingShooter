using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeallthDisplay : MonoBehaviour
{

    [SerializeField] private PlayerController Player;
    [SerializeField] private TextMeshProUGUI HealthText;


    void Update()
    {
        HealthText.text = Player.CurrentHealth.ToString();
    }
}
