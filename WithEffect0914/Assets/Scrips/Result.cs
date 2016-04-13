using UnityEngine;
using System.Collections;

public class Result {
	public User detail = new User();
	public string description;
	public string code;

	public string Code {
		get{return code;}
	}
	public string Description {
		get{return description;}
	}
	public User Detail {
		get{return detail;}
	}
}

