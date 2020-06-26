using System.Collections.Generic;

namespace ERPG
{
    [System.Serializable]
    public class EffectList : List<EffectBase>
    {
        private float Passtime = 0.0f;
        private CreatureBase creature;

        public EffectList(CreatureBase _creature)
        {
            creature = _creature;
        }

        /// <summary>
        /// Check if property type is in list
        /// </summary>
        /// <typeparam name="T">Property type</typeparam>
        /// <returns></returns>
        public bool ContainProperty<T>()
        {
            foreach (var i in this)
            {
                if (i.GetType() == typeof(T))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Check if property type is in list <br />
        /// If in list return back the instance
        /// </summary>
        /// <typeparam name="T">Property type</typeparam>
        /// <returns>Instance</returns>
        public EffectBase GetProperty<T>()
        {
            foreach (var i in this)
            {
                if (i.GetType() == typeof(T))
                    return i;
            }
            return null;
        }

        public void Update(float delta)
        {
            Passtime += delta;
            if(delta > 1.0f)
            {
                Update();
                Passtime -= 1.0f;
            }
        }

        private void Update()
        {
            foreach(var i in this)
            {
                i.CountDown--;
                i.EachSecond(creature);
            }
        }
    }
}
