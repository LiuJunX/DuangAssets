using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyUtility {

	/*
	 * rand nums without repetition in range [from, to)
	 * 
	 */
	public static int[] RandNumsWithoutRepetitionRange(int from, int to, int num)
	{
		if (to - num < num)
			Debug.LogError ("there is no enough numbers in [from, to) to random product int numbers");
		int[] numsResult = new int[num];

		int allPossibleNumsCount = to - from;
		int[] allPossibleNums = new int[allPossibleNumsCount];
		
		for (int i = 0; i < allPossibleNumsCount; ++i) {
			allPossibleNums[i] = from + i;
		}

		for (int i = 0; i < num; ++i) {
			int randIndex = Random.Range(0, allPossibleNumsCount);
			numsResult[i] = allPossibleNums[randIndex];
			allPossibleNums[randIndex] = allPossibleNums[allPossibleNumsCount - 1];
			-- allPossibleNumsCount;
		}

		return numsResult;
	}

	public static void Exchange<T> (ref T a, ref T b)
	{
		T temp = a;
		a = b;
		b = temp;
	}

}
