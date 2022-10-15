using opp_lib;

namespace opp_server.Classes.Builder
{
    public class Director
    {
        public Ball ConstructSimple(Builder builder)
        {
            return builder.Build();
        }

        public Ball ConstructStripy(Builder builder)
        {
            return builder.AddLines().Build();
        }

        public Ball ConstructDottyEdged(Builder builder)
        {
            return builder.AddDots().AddEdge().Build();
        }

        public Ball ConstructFancy(Builder builder)
        {
            return builder.AddCircles().AddLines().AddDots().AddEdge().Build();
        }
    }
}
