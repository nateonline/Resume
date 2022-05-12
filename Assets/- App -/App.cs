using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NatesJauntyTools;

public class App : Singleton<App>
{
	#region Managers

	[SerializeField] SubscriberManager subscriberManager;
	public static SubscriberManager SubscriberManager => _.subscriberManager;

	#endregion


	#region Mono

	protected override void PostInitialize()
	{
		SubscriberManager.Setup();
	}

	void OnDestroy()
	{
		SubscriberManager.Shutdown();
	}

	#endregion
}
