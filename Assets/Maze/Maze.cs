using UnityEngine;
using System.Collections.Generic;

public class Maze : MonoBehaviour {
	readonly List<Room> rooms = new();

	protected void Start() {
		DetectChildRooms();
	}

	void DetectChildRooms() {
		for(int i = 0; i < transform.childCount; ++i) {
			var child = transform.GetChild(i);
			if(!child.TryGetComponent<Room>(out var room))
				continue;
			rooms.Add(room);
		}
	}
}
