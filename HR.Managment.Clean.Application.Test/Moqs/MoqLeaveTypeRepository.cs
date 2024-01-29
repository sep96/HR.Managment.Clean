using HR.Managment.Application.Contracts.Persistence;
using HR.Managment.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Managment.Clean.Application.Test.Feature.LeaveType
{
    public class MoqLeaveTypeRepository
    {
        public static Mock<ILeaveTypeRepository> GetLEaveTypeMockLeaveTypeRepository()
        {
            var leaveTypes = new List<LeaveTypes>
            {
                new LeaveTypes
                {
                    LeaveTypesID =1 ,
                    LeaveTypesName = "Test1" ,
                    LeaveTypesDefaultDays = 1
                },
                new LeaveTypes
                {
                    LeaveTypesID =2 ,
                    LeaveTypesName = "Test2" ,
                    LeaveTypesDefaultDays = 2
                },
                new LeaveTypes
                {
                    LeaveTypesID =3 ,
                    LeaveTypesName = "Test3" ,
                    LeaveTypesDefaultDays = 3
                },
                new LeaveTypes
                {
                    LeaveTypesID =4 ,
                    LeaveTypesName = "Test4" ,
                    LeaveTypesDefaultDays = 4
                }
            };
            var mockRepo = new Mock<ILeaveTypeRepository>();
            mockRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(leaveTypes);
            mockRepo.Setup(x => x.AddAsync(It.IsAny<LeaveTypes>())).ReturnsAsync
                ((LeaveTypes leaveType) =>
                {
                    leaveTypes.Add(leaveType);
                    return leaveType;
                });
            return mockRepo;
        }
    }
}
