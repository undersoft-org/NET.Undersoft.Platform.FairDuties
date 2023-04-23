using RadicalR;

namespace Undersoft.ODP.Api
{
    public class PlanCreatedHandler : CreatedDtoHandler<IReportStore, Domain.Vertex, Vertex>
    {
        private IRadicalr _ultimatr;

        public PlanCreatedHandler(IRadicalr ultimatr) : base()
        {
            _ultimatr = ultimatr;
        }


        public override Task Handle(CreatedDto<IReportStore, Domain.Vertex, Vertex> request, CancellationToken cancellationToken)
        {

            return null;
        }
    }
}
