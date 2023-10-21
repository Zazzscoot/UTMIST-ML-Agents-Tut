using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameObject;
    private MoveToGoalAgent moveToGoalAgent;
    [SerializeField] private Material winMaterial;
    [SerializeField] private Material loseMaterial;
    [SerializeField] private MeshRenderer floorMeshRenderer;

    void Start()
    {
        moveToGoalAgent = gameObject.GetComponent<MoveToGoalAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      transform.localPosition += new Vector3(-0.08f, 0, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player Player))
        {
            moveToGoalAgent.SetReward(-1f);
            floorMeshRenderer.material = loseMaterial;
            moveToGoalAgent.EndEpisode();
        }
        if (other.TryGetComponent<Wall>(out Wall wall))
        {
            moveToGoalAgent.SetReward(1f);
            floorMeshRenderer.material = winMaterial;
            moveToGoalAgent.EndEpisode();
        }
    }
}
