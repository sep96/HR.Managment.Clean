using AutoMapper;
using HR.Managment.Application.Contracts.Persistence;
using HR.Managment.Application.Features.LeaveTypes.Queries.GetAllLeaveTypes;
using HR.Managment.Application.Features.LeaveTypes.Queries.GetLeaveTypeDetails;
using HR.Managment.Application.MappingProfiles;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Managment.Clean.Application.Test.Feature.LeaveType.Queries
{
    public class GetLeaveTypesQueryHandlerTest
    {
        private readonly Mock<ILeaveTypeRepository> _mock;
        private IMapper _mapper;
        public GetLeaveTypesQueryHandlerTest()
        {
            _mock = MoqLeaveTypeRepository.GetLEaveTypeMockLeaveTypeRepository();
            var mapConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<LeaveTypeProfile>();
            });
            _mapper = mapConfig.CreateMapper(); 
        }
       [Fact]
       public async Task GetLeaveTypeListTest()
       {
            var hanlder = new GetLeaveTypesQueryhandler(_mock.Object , _mapper);
            var result = await hanlder.Handle(new GetLeaveTypesQuery(), CancellationToken.None);
            result.ShouldBeOfType<List<LeaveTypesDto>>();
            result.Count.ShouldBe(4);   
       }

    
    }
}
