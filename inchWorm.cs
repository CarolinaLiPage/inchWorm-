namespace inchWorm
{
// declare low and high at class level so they can be accessed by both low 
// and high
    public class inchWorm {
        private int p; // length
        private int z; // position
        private bool forward;
        private bool awake;
        private int low;
        private int high;

        public inchWorm(int length, int position, bool direction) {
            p = length;
            z = position; 
            forward = direction;
            awake = true;
            // initial interval, span [z, z+p]
            low = z;
            high = z + p;
        }
		
        // moves in forward or backward, move x shift interval 
        // from [z, z+p] to [z+x, z+p+x]
        public void move(int x) {
            if (x < 0) {
                awake = false;
            } 
            if (awake) {
                if (forward) {
                    low += x;
                    high += x;
                    // one extra line chatGPT: z+=x; 
                }
                else {
                    low -= x;
                    high -= x;
                }
            }
        }
		
        public bool query(int y) {
            if (low <= y && y <= high) {
                return true;
            }
            return false;
        }
    }

}