using UnityEngine;

namespace CodeBase.Gameplay.Common
{
  public class SelfDestruct : MonoBehaviour
  {
    public float FuseSeconds = 0.1f;
    private float _destroyTime = 0.0f;

    private void Start() => 
      _destroyTime = Time.time + FuseSeconds;

    private void Update()
    {
      if (Time.time > _destroyTime)
        Destroy(gameObject);
    }

    public void SetFuseTime(float time) =>
      FuseSeconds = time;
  }
}
