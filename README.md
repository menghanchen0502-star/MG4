# MG4
## Devlog

The FloatAnimation script makes the fish food move up and down over and over. It moves one way for a few seconds, then switches to the other way.

### _up

_up is a bool. It keeps track of which way the food is moving. If it is true, the food goes up. If it is false, the food goes down. It starts as false, so the food moves down first.

### _timer

_timer is a float. It counts down how many seconds are left before the food changes direction.

### Start()

Start() runs once when the game starts. It sets _timer to _switchSpeed, so the food knows how long to move before switching.

### Update()

Update() runs every frame. First it checks _up. If it is true, it moves the food up with transform.Translate. If it is false, it moves the food down. The speed is _moveSpeed times Time.deltaTime, so it moves smoothly no matter the frame rate.

Then it takes Time.deltaTime away from _timer, so the timer goes down in real seconds. When _timer gets to 0 or below, it resets _timer back to _switchSpeed and does _up = !_up. The ! means "not", so this flips _up to the opposite value. Now the food moves the other way, and this keeps repeating.

## Open-Source Assets
- [Quirky animal 3D models](https://assetstore.unity.com/packages/3d/characters/animals/quirky-series-free-animals-pack-178235)
- [City 3D models](https://assetstore.unity.com/packages/3d/environments/simplepoly-city-low-poly-assets-58899)
- [Bite sound effect](https://freesound.org/people/Jofae/sounds/353067/)