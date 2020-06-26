namespace ERPG
{
    /// <summary>
    /// Matrix 4x4
    /// </summary>
    public struct Mat4
    {
        public Vec4 row1;
        public Vec4 row2;
        public Vec4 row3;
        public Vec4 row4;

        public Mat4(Vec4 row1, Vec4 row2, Vec4 row3, Vec4 row4)
        {
            this.row1 = row1;
            this.row2 = row2;
            this.row3 = row3;
            this.row4 = row4;
        }
    }
}
