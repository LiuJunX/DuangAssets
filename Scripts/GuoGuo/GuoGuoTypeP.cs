using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class GuoGuoTypeP<T> : MonoBehaviour {

	public UnityEvent over;

	public virtual void Show(T t)
	{
		
	}

}

public class GuoGuoTypeP<T1, T2> : MonoBehaviour {
	
	public UnityEvent over;
	
	public virtual void Show(T1 t1, T2 t2){

	}
	
}

public abstract class GuoGuoTypeP<T1, T2, T3> : MonoBehaviour {
	
	public UnityEvent over;
	
	public virtual void Show(T1 t1, T2 t2, T3 t3)
	{

	}
	
}
