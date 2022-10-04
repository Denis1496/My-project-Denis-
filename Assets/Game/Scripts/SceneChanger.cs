using UnityEngine;
using UnityEngine.SceneManagement;

namespace SortItems
{
    public class SceneChanger: MonoBehaviour {
     
        private void Start()
        {
        var Level = PlayerPrefs.GetInt("Level", 0);  
        var idx = SceneManager.GetActiveScene().buildIndex;
        if(Level != idx) {
        loadLevel(Level);
            }
        }

        public void loadLevel(int LevelIdx) {
            
       var sceneCount = SceneManager.sceneCountInBuildSettings;

       var nextLevel = (LevelIdx) % sceneCount;

       SceneManager.LoadScene(nextLevel);
       
        }

        public void loadNextLevel() {
            
       var idx = SceneManager.GetActiveScene().buildIndex;

       var sceneCount = SceneManager.sceneCountInBuildSettings;

       var nextLevel = (idx + 1) % sceneCount;

       PlayerPrefs.SetInt("Level", nextLevel);
       SceneManager.LoadScene(nextLevel);

    }public void ReloadNextLevel() {
        
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
}
