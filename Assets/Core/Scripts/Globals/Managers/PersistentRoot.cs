using UnityEngine;

namespace Core.Scripts.Globals.Managers
{
    public class PersistentRoot : MonoBehaviour
    {
        #region Statements

        public static PersistentRoot Instance;

        private void Awake()
        {
            if (Instance is null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        #endregion

        #region Functions

        public void AddPersistentObject(GameObject persistentObject)
        {
            persistentObject.transform.SetParent(transform);
        }

        #endregion
    }
}
