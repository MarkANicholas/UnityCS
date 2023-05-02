using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class animRandomiser : MonoBehaviour 
{
    protected Animator targetAnimator;
    public string intParamName;
    public int numIdles;
    public int offset = 1;
    protected Dictionary<int, int> idleWeights = new Dictionary<int, int>();
    protected List<int> weightedList = new List<int>();
    protected int idletotrigger;

    void Start()
    {
        //initialise weights for idles, sets all idle weights to 1
        for(int i = 0; i < numIdles; i++)
        {
            idleWeights.Add(i, 1);
        }
        targetAnimator = GetComponent<Animator>();
    }
    public void getRandomIdle()
    {
        //get random number
        foreach(KeyValuePair<int, int> num in idleWeights)
        {
            //for every idle
            for(int i = 0; i < num.Value; i++)
            {
                //add the key to a list as many times as its value says, the value being its weight.
                weightedList.Add(num.Key);
            }
        }

        //sets value to return by picking one of the numbers from the list
        idletotrigger = weightedList[Random.Range(0, weightedList.Count)];

        //cleanup
        weightedList.Clear();
        //adds one weight to every idle
        foreach (int i in idleWeights.Keys.ToList())
        {
            idleWeights[i] += 1;
        }
        //sets weight of idle just triggered to 0
        idleWeights[idletotrigger]=0; 
        //applies variable
        targetAnimator.SetInteger( intParamName, idletotrigger+offset);
        return;
    }

}
