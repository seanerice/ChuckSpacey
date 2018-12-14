# Final Project: "Chuckable"

My final project is roughly based on the Reactable product, which promotes real-time interactive music synthesis with less emphasis on musical programming and more emphasis on musical creation.

This project is build entirely in Chunity. Yay! No more separate executables!

## Block Types

Curently the following block types are implemented:
* Audio Gen
  * Audio source
  * Load a music file and play on loop
* Filter
  * Simple lowpass resonant filter with cutoff and peak
* DAC
  * Audio sink

## How To Use

The operation of this game is quite simple:

**Movement** is easy -- just drag and drop

**Connecting** blocks can be achieved by holding `L-Shift` and dragging your `Mouse` between two blocks. A successful connection will be shown with a line.

**Parameters** of individual blocks can be tweaked by holding `L-Ctrl` and moving the `Mouse` along the X or Y axes. For example, we can set the *cutoff frequency* of our filter by dragging horizontally, and the *peak* is set by dragging vertically.

## In The Future

I have learned quite a bit about Chunity from this project. I developed several approaches to using Chunity before settling on the approach used in the project. In the future, I would like to leverage these discoveries and expand upon them.

**Add More Block Types**
* Delay
* Sequencer
* Filter Sweep

**Multi-Connection**
Allow the user to pipe multiple streams both in and out. Chuck is already capable of this, it's just a matter of implementing this in the Unity interface.

# Spacey

This game makes use of a data driven approach to sound synthesis.

The Pure Data backend listens for a score value, and the Unity game sends the score value.

There are 3 instruments - the ping, the snare, and the bass lick.
Initially, there is only a single voice pinging away. As the score increases, so does the complexity of the musical backtrack. More voices are added over time, the tempo increases, and parameters of individual voices such as volume, envelope, filter, and pan are effected. This dynamic system makes for a game which feels like it's becoming more intense as you progress.
