namespace ERPG
{
    /// <summary>
    /// Vector 3D
    /// </summary>
    public struct Vec3
    {
        public float x, y, z;

        public Vec3(float x, float y) : this()
        {
            this.x = x;
            this.y = y;
            this.z = 0;
        }

        public Vec3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override string ToString()
        {
            return $"[{x}, {y}, {z}]";
        }
    }
}
