using UnityEngine;

namespace SortItems
{
    public class VFXPoolReset : MonoBehaviour
    {
      [SerializeField]  private VFXPool _vfxPool;
     
      private void OnDisable() {
        
        _vfxPool.ResetPool();
         }
        
        }
    }

