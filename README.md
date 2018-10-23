# Spacey

This game makes use of a data driven approach to sound synthesis.

The Pure Data backend listens for a score value, and the Unity game sends the score value.

There are 3 instruments - the ping, the snare, and the bass lick.
Initially, there is only a single voice pinging away. As the score increases, so does the complexity of the musical backtrack. More voices are added over time, the tempo increases, and parameters of individual voices such as volume, envelope, filter, and pan are effected. This dynamic system makes for a game which feels like it's becoming more intense as you progress.

# To Run

There are no binaries at the moment. Please run PDWorkspace\Main.pd before running the Unity project.
