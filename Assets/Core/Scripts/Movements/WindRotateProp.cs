using UnityEngine;

namespace Core.Scripts.Movements
{
    public class WindRotateProp : MonoBehaviour
    {
        private const float _rotateSpeed = 10f;

        private void Update()
        {
            transform.Rotate(new Vector3(0, 0, _rotateSpeed * Time.deltaTime));
        }
    }
}
