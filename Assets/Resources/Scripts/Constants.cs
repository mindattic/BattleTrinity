
namespace BattleTrinity
{
    public static class Constants
    {

        public const float GRID_CELL_DRAW_DISTANCE = 64f;



        //Game objects
        public const string GAME_CONTROLLER_OBJECT = @"GameControllerObject";
        public const string MUSIC_CONTROLLER_OBJECT = @"MusicControllerObject";
        public const string SOUND_CONTROLLER_OBJECT = @"SoundControllerObject";
        public const string WORLD_CONTROLLER_OBJECT = @"WorldControllerObject";
        public const string CAMERA_CONTROLLER_OBJECT = @"CameraControllerObject";
        public const string GUI_CONTROLLER_OBJECT = @"GUIControllerObject";

        //Controller Code
        public const string GAME_CONTROLLER = @"GameController";     
        public const string MUSIC_CONTROLLER = @"MusicController";      
        public const string SOUND_CONTROLLER = @"SoundController";
        public const string ACTOR_CONTROLLER = @"ActorController";
        public const string WORLD_CONTROLLER = @"WorldController";


        public const string CAMERA_CONTROLLER = @"CameraController";
        public const string GUI_CONTROLLER = @"GUIController";

        //Camera
        public const string CAMERA_VECTOR3_POSITION = @"CameraVector3Position";
        public const string CAMERA_VECTOR3_ROTATION = @"CameraVector3Rotation";
        public const string CAMERA_OBJECT_TARGET = @"CameraObjectTarget";

        //Player
        public const string PLAYER_INPUT = @"PlayerInput";

        //Tags
        public const string TAG_PLAYER = @"Player";
        public const string TAG_CONTROLLER_OBJECT = @"ControllerObject";

        //Layers (for collision)
        public const int LAYER_SKY = 8;
        public const int LAYER_BACKGROUND = 9;
        public const int LAYER_GAMEPLAY = 10;
        public const int LAYER_FOREGROUND = 11;
        public const int LAYER_SNOW_PARTICLES = 15;
        public const int LAYER_TOOLBOX = 31;

        //Directory paths
        public const string RESOURCE_PATH_PREFAB = @"Prefab";
        public const string RESOURCE_PATH_PREFAB_CONTROLLER = @"Prefab/Controller";

        public const string RESOURCE_PATH_MUSIC = @"Audio/Music";
        public const string RESOURCE_PATH_SOUND = @"Audio/Sound";

        //Sorting layers
        public const string SORTING_LAYER_SKY = @"Sky";
        public const string SORTING_LAYER_BACKGROUND = @"Background";
        public const string SORTING_LAYER_GAMEPLAY = @"Gameplay";
        public const string SORTING_LAYER_FOREGROUND = @"Foreground";

        //Mechanics
        public const float BULLET_TIME = 0.25f;

        //Mouse Controls
        public const string MOUSE_SCROLLWHEEL = @"Mouse ScrollWheel";
        public const string MOUSE_X = @"Mouse X";
        public const string MOUSE_Y = @"Mouse Y";

        //Touchscreen Controls
        public const string LEFT_HORIZONTAL_AXIS = @"LeftHorizontal";
        public const string LEFT_VERTICAL_AXIS = @"LeftVertical";
        public const string RIGHT_HORIZONTAL_AXIS = @"RightHorizontal";
        public const string RIGHT_VERTICAL_AXIS = @"RightVertical";

        //Start options
        public const string PLAYER_INSTANCE = @"PlayerInstance";



        public const string KEY_PLAYER_PREFAB = @"PLAYER_PREFAB";
       

        public const string KEY_ANIM_IDLE_RIGHT = @"IdleRight";
        public const string KEY_ANIM_WALK_RIGHT = @"WalkRight";
        public const string KEY_ANIM_RUN_RIGHT = @"RunRight";
        public const string VAL_ANIM_IDLE_RIGHT = @"IdleRight";
        public const string VAL_ANIM_WALK_RIGHT = @"WalkRight";
        public const string VAL_ANIM_RUN_RIGHT = @"RunRight";



    }
}

