﻿namespace ERPG
{
    /// <summary>
    /// Vector 4D
    /// </summary>
    public struct Vec4
    {
        public float x, y, z, w;

        public Vec4(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = 0;
        }

        public Vec4(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
    }
}
