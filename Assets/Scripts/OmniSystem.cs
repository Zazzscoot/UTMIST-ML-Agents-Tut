using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmniSystem : MonoBehaviour
{
    float roundStartTime;
    int waitTime;
    // Start is called before the first frame update
    void Start()
    {
        print("Press the spacebar once you think the alloted time is up.");
        SetNewRandomTime();
        roundStartTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space))
		{
            float time = Time.time - roundStartTime;
            float error = Mathf.Abs(waitTime - time);

            string message = "";

            if (error < .15f)
                message = "Outstanding!";
            else if (error < .75f)
                message = "Exceeds Expectations.";
            else if (error < 1.25f)
                message = "Acceptable.";
            else if (error < 1.75f)
                message = "Poor.";
            else
                message = "Dreadful";
            print("You waited for " + time + " seconds. That's " + error + " seconds off. " + message);
            SetNewRandomTime();
		}
    }

    void SetNewRandomTime()
	{
        waitTime = Random.Range(5, 21);
        roundStartTime = Time.time;
        print(waitTime + " seconds.");
	}
}
