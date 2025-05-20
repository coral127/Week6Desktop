using UnityEngine;
using TMPro;

public class TextTMPViewer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textPlayerHP;
    [SerializeField]
    private PlayerHP playerHP;
    private void Upate()
    {
        textPlayerHP.text = playerHP.CurrentHP + "/" + playerHP.MaxHP;        
    }

    
}
