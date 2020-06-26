using System;

namespace ERPG
{
    [System.Serializable]
    public class Counter
    {
        public Action TimeUp = null;
        public float Clock = 0.0f;

        private float PassingTime = 0.0f;

        public Counter()
        {

        }

        public Counter(Action timeUp, float clock)
        {
            TimeUp = timeUp;
            Clock = clock;
        }

        public void Update(float Delta)
        {
            PassingTime += Delta;
            if(PassingTime > Clock)
            {
                float rest = PassingTime - Clock;
                PassingTime = rest;
                TimeUp.Invoke();
            }
        }
    }
}
