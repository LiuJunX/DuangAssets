using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Self<T> : MonoBehaviour 
	where T : Self<T>
{

	protected T self;

}
