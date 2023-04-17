using Undersoft.ODP.Domain;
using UltimatR;

namespace Undersoft.ODP.Api
{
    public class PlanCreatedHandler : CreatedDtoHandler<IReportStore, Plan, PlanDto>
    {
        private IUltimatr _ultimatr;

        public PlanCreatedHandler(IUltimatr ultimatr): base()
        {
            _ultimatr = ultimatr;
        }


        public override Task Handle(CreatedDto<IReportStore, Plan, PlanDto> request, CancellationToken cancellationToken)
        {

            return null;
        }
    }
}
