using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace SortItems
{
    public class ItemHideFXx : MonoBehaviour
    {
     [SerializeField] private GameObject _hideFxPrefub;
     public void Hide() {
        Instantiate(_hideFxPrefub, transform.position, Quaternion.identity, null);
        Destroy(this.gameObject);
     }
    }
}
