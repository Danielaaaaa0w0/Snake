using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector3 direction = Vector3.right;
    private List<Transform> body;
    public Transform bodyPrefab;

    private void Start()
    {
        body = new List<Transform>
        {
            transform
        };
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = Vector3.up;
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = Vector3.down;
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = Vector3.right;
        }

    }

    private void FixedUpdate()
    {
        for(int i = body.Count - 1; i > 0; i--)
        {
            body[i].position = body[i - 1].position;
        }

        transform.position = new Vector3(transform.position.x + Mathf.Round(direction.x),transform.position.y + Mathf.Round(direction.y), 0.0f);
    }

    private void Grow()
    {
        Transform segment = Instantiate(bodyPrefab);
        segment.position = body[body.Count - 1].position;
        body.Add(segment);
    }

    private void Reset()
    {
        for(int i = 1; i < body.Count; i++)
        {
            Destroy(body[i].gameObject);
        }

        body.Clear();
        body.Add(transform);
        transform.position = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("food"))
        {
            Grow();
        }

        if(other.CompareTag("barrier"))
        {
            Reset();
        }
    }
}
