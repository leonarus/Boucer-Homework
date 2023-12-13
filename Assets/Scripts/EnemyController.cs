using System.Linq;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;

    private Material _material;
    private Color _color;
    
    
    public void Initialize(Color color)
    {
        _material = _renderer.materials.First(material => material.name.Contains(GlobalConstants.COLOR_MATERIAL));
        
        _material.color = color;
        _color = color;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<ColoredObject>(out var coloredObject))
        {
            if (coloredObject.Color == _color)
            {
                Destroy(gameObject);
            }
        }
    }
}
