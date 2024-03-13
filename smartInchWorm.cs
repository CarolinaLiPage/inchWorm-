namespace inchWorm
{
    public class SmartInchWorm : inchWorm
    {
        public SmartInchWorm(int length, int position, bool direction) : base(length, position, direction)
        {
        }

        public void shift(int x)
        {
            base.move(x);
        }

        public bool query(int y)
        {
            return base.query(y);
        }

        // Override the move method to adjust direction automatically based on surroundings
        public override void move(int x)
        {
            if (x < 0)
            {
                base.move(x);
                return;
            }

            // Check if moving forward would result in collision
            bool forwardCollision = query(base.z + x + 1);

            // Check if moving backward would result in collision
            bool backwardCollision = query(base.z - 1);

            if (forwardCollision && backwardCollision)
            {
                // If both directions have a collision, stay put
                return;
            }
            else if (!forwardCollision && !backwardCollision)
            {
                // If both directions are clear, move forward by default
                base.move(x);
            }
            else if (forwardCollision)
            {
                // If forward direction has a collision, move backward
                base.move(-1);
            }
            else
            {
                // If backward direction has a collision, move forward
                base.move(1);
            }
        }

        // Check if the SmartInchWorm is sleeping
        public bool IsSleeping()
        {
            return !awake;
        }
    }

}