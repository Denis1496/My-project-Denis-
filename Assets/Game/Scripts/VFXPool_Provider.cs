using UnityEngine;

namespace SortItems
{
    public class VFXPool_Provider : MonoBehaviour
    {
        [SerializeField] private VFXPool _vfxPool; 
       public VFXPool VFXPool => _vfxPool;
             private void Awake() {

VFXPool.InitializePool();

          }
        }
    }

