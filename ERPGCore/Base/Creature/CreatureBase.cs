using System;

namespace ERPGCore
{
    /// <summary>
    /// The very basic class for living creature, including player <br />
    /// </summary>
    [System.Serializable]
    public abstract class CreatureBase : EObjectWithPrefab
    {
        /// <summary>
        /// The target this creature is select
        /// </summary>
        public CreatureBase Target;

        /// <summary>
        /// Properties list represent the data this creature have
        /// </summary>
        public PropertiesList Properties;

        /// <summary>
        /// Effect list represent the effect this creature have
        /// </summary>
        public EffectList Effects;

        /// <summary>
        /// Where is this creature at
        /// </summary>
        public CreaturePosition MapPosition;
        public CreaturePosition CurrentPosition
        {
            set
            {
                MapPosition = value;
            }

            get
            {
                CreaturePosition buffer = new CreaturePosition();
                buffer.Position = GetPosition();
                return buffer;
            }
        }

        /// <summary>
        /// Event handle for connect with unity animator function
        /// </summary>
        public AnimationCommand Animation;

        /// <summary>
        /// Event handle for connect with unity navigation system
        /// </summary>
        public PathFindingCommand PathFinder;

        /// <summary>
        /// Get creature position
        /// </summary>
        public Func<Vec3> GetPosition;
        public Vec3 Position
        {
            get
            {
                return GetPosition();
            }
        }

        protected CreatureBase()
        {
            Properties = new PropertiesList();
            Effects = new EffectList(this);
            MapPosition = new CreaturePosition();
        }

        /// <summary>
        /// When spawn trigger
        /// </summary>
        public abstract void Spawn();

        /// <summary>
        /// When death trigger
        /// </summary>
        public abstract void Death();

        /// <summary>
        /// Called every frame
        /// </summary>
        public abstract void Update(float Delta);

        /// <summary>
        /// Attack from creature
        /// </summary>
        /// <param name="target">The creature who attack this</param>
        public abstract void Attacked(CreatureBase target);
    }
}
