using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D grid;

    private void Start()
    {
        RandomizePosition();
    }
    private void RandomizePosition()
    {
        Bounds bounds = grid.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("snake"))
        {
            RandomizePosition();
        }      
    }
}
