# Progress checks

### Week 6

Implemented shooting. Movement and looking required a massive rework as they did not work as intended, but shooting worked perfectly. I started to work on the scripts for traps. It was my first time working with audio in Unity, but they worked perfectly after a few hours of searching the Unity documentation to understand audio. I manipulated the audio a bit in Audacity too.

### Week 7

I started working on the main menu, attaching the canvas to the main camera so that the main menu is always in sight. I then added buttons for play, options, quit. This was easy to implement and was my first time working with new libraries. However, data persistence was a struggle as I had not worked with files before in C#, but it was not too bad after searching through documentation for a bit. After a few days of work the main menu was all finished. I got some music from online as well as making my own music for the winning scene.

### Week 8

I searched for some assets, but could not find any suitable assets that I liked, so I decided to make my game use simple, solid colours as textures. I used a lot of walls and found a natural plants pack of models to use from online, and started working on the map. The map took a long time, but after a while I thought it looked pretty nice.

### Week 10

A lot of things here fell apart. I had to rewrite the entire movement script due to a bug where because of the script using the `transform.position` component of the player and changing it, the player could walk through walls with a high enough velocity. I switched to a system that used `RigidBody.AddForce()` to simulate movement instead, and it worked perfectly.

The next problem was the randomness of the Wumpus roaming. Having it roam from point to point and having those points search for other points individually was too unreliable and finicky, so I decided to have a singleton object at the centre of the map that collects all the points and stores them into an array. This singleton had many many uses as it was my main source of random spawning throughout the whole game.

### Week 1

The last thing I had to implement was the mouse sensitivity. It was a bit annoying having to implement the whole data persistence system again but in the end, it worked fine.

I looked out of all my individual modules and started looking at my game as a whole, which lead me to discover certain bugs that I would quickly fix. I also exported and sent the game in its current state, and this gave me feedback on some more bugs that I missed.

In the end, I got the whole game done and exported it to .exe for use on Windows Systems. I kept going back continously and checking for things I had missed, and at last exported again, and uploaded to GitHub.
