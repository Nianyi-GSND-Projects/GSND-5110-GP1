#set page(paper: "us-letter")
#set par(justify: true)
#show heading.where(level: 1): it => {
	set align(center);
	set text(size: 16pt);
	v(0.5em);
	it;
	v(0.5em);
}
#show link: it => { underline(text(fill: blue)[#it]); }

#{
	set text(size: 20pt, weight: "bold");
	set align(center);
	[Concept Document for _The Door Game_]
	parbreak();

	set text(size: 12pt, weight: "regular");
	v(-0.5em);
	[Game Project \#1 for GSND 5110, Group \#4, _"Skepticism"_]
	parbreak();

	link("https://trello.com/b/BQtbWgFJ/gda-assignment-1")[Trello Board]
	h(1em)
	link("https://docs.google.com/document/d/1HTiG_TG-Q7ZcBPZ9A8dJEAY5wCw3jsK6SATNv1-ew5o/edit")[Team Log]
}

= Group Members

#{
	set align(center);
	v(-.5em);
	[_(by alphabetical order of first name)_]
}

#{
	set align(center);
	table(
		columns: 2,
		stroke: none,
		align: (left, left),

		[Nianyi Wang], [Developer, Document editor],
		[Serena Yang], [Level designer, Narrator],
		[Yathish Narendrababu], [Mechanic designer, Project manager],
		[Zhe Gao], [Artist],
	)
}

= Quick Facts

_The Door Game_ is a first-person narrative game on PC for players of all ages.
The player needs to walk through a maze to find the exit, while a suspicious narrator keeps commenting on their choices.
The game is made with Unity.

= Overview

Spawned in an enclosed room, the player sees a sign saying "Entrance" and a red button saying "Start" on the wall right in the front (@fig:starting-room).
Looking around, the whole room is covered with concrete walls and floor;
the player has nowhere to go except to press the start button.
The camera flies up and glances down, showing a solid grid of rooms.
Each room seems similar, with two of them specifically marked as "Start" and "End" (@fig:maze-overview).
Apparently, the player is stuck in a maze and needs find their way out.

#grid(
	columns: (1fr, 1fr),
	gutter: 2%,

	[#figure(
		image("Images/starting-room.jpg", height: 10em),
		caption: "The starting room.",
	) <fig:starting-room>],
	[#figure(
		image("Images/maze-overview.jpg", height: 10em),
		caption: "The maze viewed from above.",
	) <fig:maze-overview>]
)

The game is made to deliver a feeling of skepticism, and skepticism is about doubting others.
A good way of creating doubts is giving the player choices and uncertain clues at the same time.
To achieve this, we put the player in a maze along with an untrustable narrator.
Most of the time, the narrator gives correct guidance, leading the player towards the correct path;
but occasionally, it gives wrong advice or contradicting lines.
While the player is focusing on solving the maze, this out-of-expectation experience would create doubt and fun at the same time.

= Walkthrough

After the camera goes back to the first-person view, the narrator's voice appears.
"Welcome, dear adventurer," it says, and continues on introducing the goal of this game.
The player turns around, finding a new door spawned in the starting room (@fig:narration).

As the player left the starting room, the narrator would keep on commenting every decision they made, making them question if they are really heading the correct direction.

At certain stage, the narrator finally has had enough with the player wandering headlessly like a fly and teleported the player to somewhere on the correct path.
From then on, every time the player opens a door, a light will light up.
The narrator claims that all green lights lead to the correct path, while all red lights lead to incorrect paths (@fig:color-doors).
Although being a little skeptical, the player has no better plan and thus still follows the lights' guidance.

#grid(
	columns: (1fr, 1fr),
	gutter: 2%,

	[#figure(
		image("Images/first-line-of-narration.jpg", height: 10em),
		caption: "Narration while player wanders.",
	) <fig:narration>],
	[#figure(
		image("Images/lights-of-different-color.jpg", height: 10em),
		caption: "A red door and a green door.",
	) <fig:color-doors>]
)

Upon reaching the end of the maze, the player encounters something they haven't met before---a yellow door and a pink door.
The narrator clearly states that one door leads to death, while the other one leads to success. (@fig:final-decision)
The player hesitates, and the narrator further gives its advice, urging the player to made their final decision...

#figure(
	image("Images/final-decision.jpg", height: 15em),
	caption: "The final decision.",
) <fig:final-decision>

#pagebreak()

= Player Experience

== Visual Experience

Through out the entire game, the player stays in the interior area of the maze.
The maze comes in a grid of small concrete rooms, so wherever the player is, they would always see the roughly same picture: A dull, enclosed square space with dim lighting, potentially some doors on the wall (@fig:similar-rooms).

#figure(
	image("Images/similar-rooms.jpg", height: 12em),
	caption: "All rooms in the maze share a similar appearance."
) <fig:similar-rooms>

The game features little graphical interfaces.
A focus mark is placed in the center of the screen, and when looking on interactable objects, a mouse icon would be displayed to indicate possible interaction (@fig:interactive-guidance).
The narration panel placed at the bottom part of the screen (@fig:narration).
Additionaly, there are special UIs for the ending stage of the game (@fig:final-decision).
When the player wins the game, fancy confetti as well as a congratulating picture will be displayed (@fig:winning-ui).

#grid(
	columns: (1fr, 1fr),
	gutter: 2%,

	[#figure(
		image("Images/interactive-guidance.jpg", height: 10em),
		caption: "A mouse icon will be displayed when focusing on interactable objects."
	) <fig:interactive-guidance>],
	[#figure(
		image("Images/winning-ui.jpg", height: 10em),
		caption: "The UI shown after the player won."
	) <fig:winning-ui>],
)

== Audio Experience

The entire maze constantly bares a background white noise, rendering an dizzy, annoying atmosphere pushing the player away.

The narrator is this only "living" thing the player could hear in this game.
It takes up the most part of the game's process.
Whenever the player does something, the narrator would give its reactions.

#pagebreak()

= Gameplay

== The Maze

The maze form was first proposed by _Yathish_, later build by _Serena_ in the game engine.

The maze comes as a 5x5 grid of similar square rooms.
For each adjacent wall, there may or may not be a hallway connecting them.
There could also be doors on the walls, not necessarily leading to a hallway.
There are two kinds of doors in the game: mono-directional pulling doors and bi-directional pushing doors.
On each door there is a light, which is supposed to turn on when the door is opened, but disabled for the beginning part of the game.

The player could wander around in the maze by foot and interact with doors to open them.
Due to the similarity between each room and the walls, it is hard for the player to tell current direction and location while wandering.
Often times, the player could open a door only to find out that there's a wall behind it (a fake door), or there might be fake walls which could be passed through.

When the game begins, the player will be given a chance to have a look at the maze in whole from a birdview (which doesn't help much because it's hard to see the structure from above) (@fig:maze-overview).
The room the player is currently in is marked as "Start", while another room is marked as "Exit".

There are 3 additional rooms which doesn't belong to the grid for the ending stage.
They are initially hidden and will be enabled after the player gets into the exit room.

== The Storyline

The storyline is told by the narrator, of which the voice actor is _Serena_.
Refer to the #link("https://docs.google.com/document/d/13IMEtHSl0fVZ71mG_RWWH1XQY0ZviO7QbibJe015ZV8/edit#heading=h.z2jx6ii8g70m")[narration design document] for more detail.

#figure(
	image("Images/narration-tree.jpg", height: 15em),
	caption: "The story tree."
)

=== Beginning

In this stage, the game would grade the player based on their behavior responding to the narrator's instructions, and the narrator would have different attitude towards players at different grades.

The narrator greets the player, then introduces the game's goal in a tedious way.
The player may or may not choose to leave the starting room while the narrator is speaking,
but if they don't, they are classified as "superd player" and the narrator would be pleased.
If they do, they will be downgraded as an "average player" and the narrator would ask them to go back.
If they insist on leaving, they would be furtherly downgraded into "bad player".
If they go back but leaves again before the narrator finishes its line, still they become "bad player".

=== Midgame

After the player wanders for a while, the narrator appears to be hopeless and forcefully teleports them back to the starting room to start again.
This time the lights on the doors are enabled, and the narrator instructs the player to follow the green doors (@fig:color-doors).

The narrator would whine when the player goes through red doors, but give up after a few attempts.

=== Ending

Upon reaching the exit room, the ending room will be enabled and the player can see two doors in it: A yellow one and a pink one.
The narrator points out that this is something new and that only one could be the correct choice.
Then a UI is popped out, making the player to choose between them.
Whichever the player chooses, the narrator would give some comments on their choice.
The game would end after the player enters either room.

=== Edge Cases

If the player managed to reach the ending room before the narrator teleports them back to the starting room, the narrator would be so frustrated and grant the player a winning certificate directly and then end the game.

There is a room will with a hallway leading to "outside":
The player could see blue sky from it (@fig:danger).
If the player really walked through it, they will fall straight down to death and the game ends (the only way to achieve real death in this game) (@fig:fell-off).

#grid(
	columns: (1fr, 1fr),
	gutter: 2%,

	[#figure(
		image("Images/danger.jpg", height: 10em),
		caption: "A very disturbing guidance towards outside."
	) <fig:danger>],
	[#figure(
		image("Images/fell-off.jpg", height: 10em),
		caption: "The UI shown after the player falls to death."
	) <fig:fell-off>],
)

== Controls

There are only 2 kinds of control for this game, very simple:

- Use WASD to move and mouse to look;
- Use LMB to interact.

When looking at interactable objects, a small icon of mouse would show on it (@fig:interactive-guidance).

#pagebreak()

= Game Aesthetics

The game's aesthetics was first implemented via _Nianyi_'s debugging assets following _Serena_ & _Yathish_'s design; later _Zhe_ joined in for making custom art assets.

== Atmosphere

The game wants to deliver a surveillanced and fretful atmosphere, as doing so could encourage players into doubting the narrator's role and intention.
To achieve this, we made the maze rooms really enclosed, with all interior surface to have a concrete texture to imitate a prison-like environment (@fig:interior-design).

#figure(
	image("Images/interior-design.jpg", height: 12em),
	caption: "Prison-like interior design.",
) <fig:interior-design>

A constant background noise is set up without a clear source of location, bugging in players' ears to make them even more fretful.
Also, graphical UIs are suppressed at a minimum level to let the players better focus on the environment.

All textures used in in-game materials are downloaded from #link("https://www.sketchuptextureclub.com/")[SketchUp Texture Club].
All models used in-game are originally created by team members.

== Skepticism

Skepticism is the goal of this game.
To achieve it, _Yathish_ proposed that a maze could be a good place for skepticism to happen, as it naturally creates uncertaincy.
_Serena_ furtherly added that an untrustable narrator could even bring it to the next level, so that the player would always struggle on whether follow the narrator's instructions or not.
_Serena_ has carefully designed the narration scripts cooperating with the maze's design, to create this untrustablility (@fig:average-tree).

#figure(
	image("Images/average-tree.jpg", height: 13em),
	caption: "A sub-tree in the narration design.",
) <fig:average-tree>

== Visual Guidance

Inspired by _Mirror's Edge_'s excellent visual guidance design (@fig:mirrors-edge), _Nianyi_ decided that it should be a good idea to mark all interactable elements with an indentifying color.
Red was chosen as the color.

With this being applied, it is easy to see in one glance the type of any door:
If only the handle is red, it's a pulling door;
if the whole plank is red, it's a pushing door (@fig:red-colors).
It also avoids a misunderstanding that the pulling door could be opened from both sides, as there is only one red handle on one side.

#grid(
	columns: (1fr, 1fr),
	gutter: 2%,

	[#figure(
		image("Images/mirrors-edge.jpg", height: 10em),
		caption: [
			The visual guidance in _Mirror's Edge_.
			The red arrow on the ground makes it easy to see which way to go.
			Source: #link("https://www.eurogamer.net/mirrors-edge-catalyst-guide?page=4")[Eurogamer.net]
		]
	) <fig:mirrors-edge>],
	[#figure(
		image("Images/red-colors.jpg", height: 10em),
		caption: "Red indicates interaction.",
	) <fig:red-colors>],
)

= MDA Analysis

#{
	show table.cell.where(y: 0): it => {
		set align(center);
		text(weight: "bold")[#it];
	};
	set align(center);
	figure(
		table(
			columns: (auto, 1fr, 1fr),
			align: (left, left, left),
			stroke: none,

			table.hline(),
			table.header(
				[Aesthetics], [Dynamics], [Mechanics]
			),
			table.hline(stroke: 0.5pt),

			[Skepticism],
			[The player is not sure whether everything the narrator says is true.],
			[The narration design.],

			[Lost],
			[The player will lose direction when exploring the maze.],
			["That's what a maze do!"],

			[Decision-Making],
			[When entering a room, the player needs to decide which door to go through next.],
			[The grid-like structure of the maze.],

			[Surveillanced],
			[Everything the player does would be commented by the narrator.],
			[The narration system and proper gameplay events.],

			[Fretful],
			[The player is constantly seeing dull sceneries and hearing background noises.],
			[The environmental setup.],

			table.hline(),
		),
		caption: "The MDA analysis table of the game.",
	);
}