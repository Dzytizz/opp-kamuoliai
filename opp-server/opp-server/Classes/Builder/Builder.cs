using opp_lib;

namespace opp_server.Classes.Builder
{
    public abstract class Builder
    {
        protected Ball CurrentBall { get; set; }

        public Builder(Ball initialBall)
        {
            CurrentBall = initialBall;
        }
        public Ball Build()
        {
            return CurrentBall;
        }

        public abstract Builder AddLines();
        public abstract Builder AddCircles();
        public abstract Builder AddEdge();
        public abstract Builder AddDots();
     
    }
}
