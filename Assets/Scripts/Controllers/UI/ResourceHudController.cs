using UnityEngine;
using TMPro;

namespace BB.UI
{
    public class ResourceHudController : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI[] resources;

        [SerializeField]
        private GameObject background;

        private void OnEnable()
        {
            HUDEvents.OnResourceInventoryUpdate+= OnResourceInventoryUpdate;
        }

        private void OnDisable()
        {
            HUDEvents.OnResourceInventoryUpdate += OnResourceInventoryUpdate;
        }

        private void OnResourceInventoryUpdate(GatheringType resourceType, float amount)
        {
            resources[(int)resourceType].text = amount.ToString("0");
        }
    }
}
