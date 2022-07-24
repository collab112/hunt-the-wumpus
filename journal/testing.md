# Testing

### Testing by myself

During the development of my game I had to test many of my mechanics before moving onto the next one. I usually did this by first checking the error returned and then performing the next action accordingly, e.g. if it was a compiler error, I would go and check the code and the inspector. However many times it was not a compiler error, but a logic error. These errors required much more thinking about how to solve, and often required the `Debug.Log()` function to see what was in the variables to help me solve the problem, and sometimes required the reworking of entire scripts.

| Level of testing | Time Taken                   | Rank | Comments                                                                                               |
| ---------------- | ---------------------------- | ---- | ------------------------------------------------------------------------------------------------------ |
| Unit             | 10 seconds                   | D    | Player looking did not work                                                                            |
| Unit             | 10 seconds                   | A    | Player looking now works                                                                               |
| Unit             | 10 seconds                   | C    | Player movement moves with a 90 degree rotation                                                        |
| Unit             | 10 seconds                   | A    | Player movement moves correctly relative to the world                                                  |
| Unit             | 10 seconds                   | D    | Clamping the vertical rotation did not work                                                            |
| Unit             | 10 seconds                   | A    | Clamping the vertical rotation now worked                                                              |
| Integration      | 1 minute                     | A    | Projectile shooting works perfectly                                                                    |
| Integration      | 30 seconds                   | D    | Main menu UI scales terribly                                                                           |
| Integration      | 30 seconds                   | B    | Main menu UI scales well                                                                               |
| Unit             | 1 minute                     | A    | Wumpus nav mesh navigation works perfectly                                                             |
| System           | 5 minutes                    | C    | Roam point randomness was clunky and did not always work                                               |
| Integration      | 2 minutes                    | D    | The way movement was implemented allowed the player to go through walls                                |
| Integration      | 2 minutes                    | A    | After reworking the movement the player cannot go through walls anymore and movement feels very smooth |
| Integration      | 2 minutes                    | A    | The trap script spawns randomly,  perfect                                                              |
| System           | 30 seconds                   | A    | All spawns are randomised and work perfectly                                                           |
| System           | 30 seconds                   | A    | Switching between scenes works perfectly                                                               |
| Acceptance       | 2 hours (receiving feedback) | C    | Project had quite a lot of bugs, went back to fix                                                      |
| System           | 1 minute                     | A    | Pause menu now scales with resolution                                                                  |
| System           | 1 minute                     | A    | Mouse sensitivity now works                                                                            |
| Acceptance       | 2 minutes                    | A    | All modules work well                                                                                  |

### Testing with others

When my game was nearing the end of development, I exported it and sent it to a few friends, asking them to test it. They played it and told me about the bugs that they encountered. A big problem was UI, especially the scaling of it on higher resolution monitors. I normally use the resolution 1280x720, so for this game, I calibrated the UI to fit with 1920x1080 resolutions. Similarly with mouse sensitivity, a lot of people said the sensitivity was really high. I usually use DPI 500, and was surprised to learn that a lot of people use very high DPIs of 1000-2000. After learning this, I calibrated the mouse sensitivity to fit with a DPI of 1000 by default.
