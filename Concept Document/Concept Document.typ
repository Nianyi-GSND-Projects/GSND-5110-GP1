#set page(paper: "us-letter")
#set par(justify: true)
#show heading.where(level: 1): it => {
	set align(center);
	v(1em);
	it;
	v(1em);
}

#{
	set text(size: 20pt, weight: "bold");
	set align(center);
	[Concept Document for _The Door Game_]
	parbreak();

	set text(size: 12pt, weight: "regular");
	[Game Project \#1 for GSND 5110, Group \#4, _"Skepticism"_]
	parbreak();
}

= Group Members

#{
	set align(center);
	v(-1.5em);
	[_(by alphabetical order of first name)_]
}

#{
	set align(center);
	table(
		columns: 2,
		stroke: none,
		align: (left, left),

		[Nianyi Wang], [Developer, Document Editor],
		[Serena Yang], [Level designer, Narrator],
		[Yathish Narendrababu], [Mechanic designer],
		[Zhe Gao], [Artist],
	)
}

= Quick Facts

_The Door Game_ is a first-person narrative game on PC for players of all ages.
The player needs to walk through a maze to find the exit, while a suspicious narrator keeps commenting on their choices.

= Overview

The player is spawned in an enclosed room, with a sign saying "Entrance" and a red button saying "Start" on the wall right in the front.
Looking around, the whole room is covered with concrete walls and floor;
the player has nowhere to go except to press the start button.
The camera flies up and glances down, showing a solid grid of rooms.
Each room seems similar, with two of them specifically marked as "Start" and "End".
Apparently, the player is stuck in a maze and should find their way out.

#figure(
	grid(
		columns: (1fr, 1fr),
		gutter: 2%,

		image("Images/starting-room.jpg", height: 10em),
		image("Images/maze-overview.jpg", height: 10em)
	)
)

The camera goes back to the first-person view, and a narrator's voice appears.
"Welcome, dear adventurer," it says, and continues on introducing the goal of this game.
The player turns around, finding a new door spawned in the starting room.

After the player left the starting room, the narrator would keep on commenting every decision they made, making them question if they are really heading the correct direction.

At certain stage, the narrator finally has had enough with the player wandering headlessly like a fly and teleported the player to somewhere on the correct path.
From then on, every time the player opens a door, a light will light up.
The narrator claims that all green lights lead to the correct path, while all red lights lead to incorrect paths.
Although being a little skeptical, the player has no better plan and thus still follows the lights' guidance.

#figure(
	grid(
		columns: (1fr, 1fr),
		gutter: 2%,

		image("Images/first-line-of-narration.jpg", height: 10em),
		image("Images/lights-of-different-color.jpg", height: 10em)
	)
)

At the end of the maze, the player encounters something they haven't met before---a yellow door and a pink door.
The narrator is urging the player to make a choice, of which side leads to success and which leads to death.
The player hesitates, and the narrator further gives its advice

= Gameplay