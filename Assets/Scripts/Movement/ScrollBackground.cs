using UnityEngine;
using UnityEngine.UI;

public class ScrollBackground : MonoBehaviour
{
    public float scrollSpeed = 0.5f;  // מהירות תנועת הרקע

    [SerializeField] private Renderer bgRenderer;


    void Update()
    {
       bgRenderer.material.mainTextureOffset+= new Vector2(scrollSpeed*Time.deltaTime,0);
    }
}
