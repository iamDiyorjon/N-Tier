
using N_Tier.Application.Models.User1;
using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Services
{
    public interface IUser1Service
    {
        public Task<UserForCreationResponseDto> CreateUser(UserForCreationDto user);
        public Stream SaveExcelUsers();
    }
}
