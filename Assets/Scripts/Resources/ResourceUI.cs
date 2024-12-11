using TMPro;
using UnityEngine;

public class ResourceUI : MonoBehaviour
{
    public ResourceManager resourceManager;
    public TextMeshProUGUI intelligenceText;
    public TextMeshProUGUI healthKitsText;
    public TextMeshProUGUI ammoText;

    public TextMeshProUGUI LifeText;


    public void Update()
    {
        intelligenceText.text = "Intelligence: " + resourceManager.intelligence;
        healthKitsText.text = "Health Kits: " + resourceManager.healthKits;
        ammoText.text = "Ammo: " + resourceManager.ammo;
        LifeText.text = "Lives: " + resourceManager.life.ToString();
    }
}
