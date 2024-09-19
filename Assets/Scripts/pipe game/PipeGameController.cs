using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PipeGameController : MonoBehaviour
{

	public PipeLayerData layer1Data;


	public PipeLayerData layer2Data;


	public PipeLayerData layer3Data;


	public LayerSwap LayerSwap;
	// Start is called before the first frame update
	void Start()
	{
		loadLevel();
	}

	// Update is called once per frame
	void Update()
	{
		
	}


	private int[] level1Layer1 = {
		1, 1, 1, 1, 1, 1, 1, 1, 1,
		1, 1, 1, 1, 1, 1, 1, 1, 1,
		1, 1, 1, 1, 1, 1, 1, 1, 1,
		1, 1, 1, 1, 1, 1, 1, 1, 1,
		1, 1, 1, 1, 1, 1, 1, 1, 1,
	};
	private int[] level1Layer2 = {
		0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0,
	};
	private int[] level1Layer3 = {
		0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0,
	};

	void loadLevel()
	{
		layer1Data.loadLevel1(blankPos, level1Layer1);
		layer2Data.loadLevel1(blankPos, level1Layer2);
		layer3Data.loadLevel1(blankPos, level1Layer3);
		GameObject[] temp = { GameObject.Find("Canvas1") };
		LayerSwap.loadLevel(1, temp);
	}

	public float[] initialPos;
	public int[] pipeValid;
	public float[] finalPos;
	int level;

	public void gameLevelData(int level)
	{
		switch (level)
		{
			case 1: break;
			case 2: break;
			case 3: break;
			case 4: break;
			case 5: break;
			default:
				break;
		}
	}

	public bool isCorrect()
	{
		for (int i = 0; i < finalPos.GetLength(0); i++)
		{
			if (this.pipeValid[i] != 0)
			{
				if (this.layer1Data.pipes[i].GetComponent<PipeScript>().curRotation != this.finalPos[i])
				{
					return false;
				}
		    }
		}
		return true;
	}


	public static float[] blankPos =
	{
		0, 0, 0, 90, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 90, 0,
		0, 0, 0, 0, 90, 0, 0, 0, 0,
	};
}
