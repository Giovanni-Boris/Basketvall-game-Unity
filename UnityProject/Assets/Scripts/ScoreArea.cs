using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreArea : MonoBehaviour
{
    public ParticleSystem winEffect;
    public CanvasController canvas;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball") && GameController.instance.canScore == true)
        {
            winEffect.Play();
            canvas.setPoints(canvas.points.value + 0.1f);
        }
    }
}
