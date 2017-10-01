using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ConsumeAction : ScriptableObject {


	public abstract bool Consume(Item item);
}
