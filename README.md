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
