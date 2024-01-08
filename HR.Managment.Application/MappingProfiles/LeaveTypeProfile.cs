using AutoMapper;
using HR.Managment.Application.Features.LeaveTypes.Commands.CreateLeaveType;
using HR.Managment.Application.Features.LeaveTypes.Queries.GetAllLeaveTypes;
using HR.Managment.Application.Features.LeaveTypes.Queries.GetLeaveTypeDetails;
using HR.Managment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Managment.Application.MappingProfiles
{
    public class LeaveTypeProfile : Profile
    {
        public LeaveTypeProfile()
        {
            CreateMap<LeaveTypesDto, LeaveTypes>().ReverseMap();
            CreateMap<LeaveTypeDetailsDto, LeaveTypes>().ReverseMap();
            CreateMap<CreateLeaveTypeCommand, LeaveTypes>().ReverseMap();
        }
    }
}
