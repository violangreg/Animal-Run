# AnimalRun_v2
Cutesy endless runner game made with Unity

Update 3/28/17
- Created snowball sprite

Problem:
- Not being able to use / loop snowball using obstacle generator
  Assumptions: 
  1. The snowball is moving and thereby not able to position the snowball correctly.
  2. Used Debug.Log, snowball is not being returned from the objectPool.

Solution:
- Resetting snowball position (did not work)
- Don't use objectPool, just generate and destroy (compensation = memory) [will try] 


Update 7/12/17
- Snowball is up and working

Problem fixed by:
- instantiating and destroying the snowball at a spawning and destroying point instead of pooling it. 
(since snowball is not spawned as much as the pipes, memory is not used a lot)

Next update:
- Work on figuring out how a snowball wont overlap with a pipe so that way theres a way to get by.
  - Make a slide control and make pipes have gaps underneath? (doesn't really solve the problem as the 
    snowball can be spawned under as well but will make the game more challenging).
  - Make a missle weapon that can destroy the snowball? Make it limited to one shot per 5 second so they only have one try?
- Work on a scoreboard such as the Google Play features (look up online).

Update 7/23/17
- Snowball jumping implemented
- Resets jumping when you jump on snowballs (giving the ability of double jump)

Next update:
- Work on a scoreboard such as the Google Play features (look up online).
