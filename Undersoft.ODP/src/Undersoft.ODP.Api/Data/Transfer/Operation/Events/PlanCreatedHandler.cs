using RadicalR;

namespace Undersoft.ODP.Api
{
    public class PlanCreatedHandler : CreatedHandler<IReportStore, Domain.Vertex, Vertex>
    {
        private IRadicalr _ultimatr;

        public PlanCreatedHandler(IRadicalr ultimatr) : base()
        {
            _ultimatr = ultimatr;
        }


        public override Task Handle(Created<IReportStore, Domain.Vertex, Vertex> request, CancellationToken cancellationToken)
        {

            return null;
        }
    }
}
