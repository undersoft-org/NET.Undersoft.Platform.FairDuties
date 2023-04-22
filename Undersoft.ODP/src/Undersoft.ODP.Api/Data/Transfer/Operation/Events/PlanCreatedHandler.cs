using RadicalR;

namespace Undersoft.ODP.Api
{
    public class PlanCreatedHandler : CreatedDtoHandler<IReportStore, Domain.Plan, Plan>
    {
        private IRadicalr _ultimatr;

        public PlanCreatedHandler(IRadicalr ultimatr) : base()
        {
            _ultimatr = ultimatr;
        }


        public override Task Handle(CreatedDto<IReportStore, Domain.Plan, Plan> request, CancellationToken cancellationToken)
        {

            return null;
        }
    }
}
