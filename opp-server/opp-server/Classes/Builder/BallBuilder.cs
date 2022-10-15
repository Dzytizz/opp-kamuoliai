using opp_lib;
using System.Drawing;
using System.Windows.Forms;

namespace opp_server.Classes.Builder
{
    public class BallBuilder : Builder
    {
        public BallBuilder(Ball initialBall) : base(initialBall) {}

        public override Builder AddCircles()
        {
            BallVisual bv = new BallVisual(CurrentBall.Radius, "circles");
            CurrentBall.VisualParts.Add(bv);
            return this;
        }

        public override Builder AddEdge()
        {
            CurrentBall.HasEdge = true;
            return this;
        }

        public override Builder AddDots()
        {
            BallVisual bv = new BallVisual(CurrentBall.Radius, "dots");
            CurrentBall.VisualParts.Add(bv);
            return this;
        }

        public override Builder AddLines()
        {
            BallVisual bv = new BallVisual(CurrentBall.Radius, "stripes");
            CurrentBall.VisualParts.Add(bv);
            return this;
        }
    }
}
