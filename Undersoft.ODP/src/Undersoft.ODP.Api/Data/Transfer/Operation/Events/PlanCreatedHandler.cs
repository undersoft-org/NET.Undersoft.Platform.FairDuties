using UltimatR;

namespace Undersoft.ODP.Api
{
    public class PlanCreatedHandler : CreatedDtoHandler<IReportStore, Domain.Plan, Plan>
    {
        private IUltimatr _ultimatr;

        public PlanCreatedHandler(IUltimatr ultimatr) : base()
        {
            _ultimatr = ultimatr;
        }


        public override Task Handle(CreatedDto<IReportStore, Domain.Plan, Plan> request, CancellationToken cancellationToken)
        {

            return null;
        }
    }
}
