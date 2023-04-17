using AutoMapper;
using NicmanGroup.AuditLogging.EntityFramework.Entities;
using Undersoft.IDP.Admin.BusinessLogic.Dtos.Log;
using Undersoft.IDP.Admin.EntityFramework.Entities;
using Undersoft.IDP.Admin.EntityFramework.Extensions.Common;

namespace Undersoft.IDP.Admin.BusinessLogic.Mappers
{
    public class LogMapperProfile : Profile
    {
        public LogMapperProfile()
        {
            CreateMap<Log, LogDto>(MemberList.Destination)
                .ReverseMap();
            
            CreateMap<PagedList<Log>, LogsDto>(MemberList.Destination)
                .ForMember(x => x.Logs, opt => opt.MapFrom(src => src.Data));

            CreateMap<AuditLog, AuditLogDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<AuditLog>, AuditLogsDto>(MemberList.Destination)
                .ForMember(x => x.Logs, opt => opt.MapFrom(src => src.Data));
        }
    }
}
