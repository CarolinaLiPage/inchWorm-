namespace inchWorm
{
    public class mutantB {
        private inchWorm seg1;
        private inchWorm seg2;
        private int state; // 0, 1, 2
		
        public mutantB(int seg1Length, int seg1Position, int seg2Length, int
            seg2Position) {
            seg1 = new inchWorm(seg1Length, seg2Position, true);
            seg2 = new inchWorm(seg2Length, seg2Position, false);
            state = 2;
        }
		
        public void shift(int x) {
            if (state == 2) {
                seg1.move(x);
                seg2.move(x);
            } else if (state == 1)
                seg1.move(x);
        }
		
        public bool query(int y) {
            if (seg1.query(y) || seg2.query(y))
                return true;
            return false;
        }

        // the setState method allows the user to change the value of the state variable
        // State is 0 means the programs permits the shift of neither intervals.
        // State is 1 means the programs permits the shift of one intervals.
        // State is 2 means the programs permits the shift of both its intervals.
        public void setState(int newState)  {
            if (newState >= 0 && newState <=2) {
                // allow the user to change the val of this private variable
                state = newState;
            }
        }
    }
}