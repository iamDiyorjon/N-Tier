using AutoMapper;
using N_Tier.Application.Models.User1;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Services.Impl
{
    public class User1Service : IUser1Service
    {
        public IUserRepository userRepository;
        private readonly IUserFactory userFactory;
        public IMapper mapper;
        public User1Service(IUserRepository userRepository, IMapper mapper, IUserFactory userFactory)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.userFactory = userFactory;
        }

        public async Task<UserForCreationResponseDto> CreateUser(UserForCreationDto userDto)
        {
            
            var user = userFactory.MapToUser(userDto);
            var addedUser = await userRepository.AddAsync(user);

            return new UserForCreationResponseDto
            {
                Id = addedUser.Id,
            };
        }

       

        public Stream SaveExcelUsers()
        {
            var users = userRepository.GetAll().ToList();
            string path = "D:\\Yangi\\users.xlsx";
            MemoryStream template = GetStaticFile(path);
            Stream stream = template;

            if(users!=null)
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage excelPackage = new ExcelPackage(template);

                var namerange = excelPackage.Workbook.Names["UserRow"];

                var currentrow = namerange.Start.Row;
                var worksheet = namerange.Worksheet;
                int listIndex = 1;

                foreach ( var item in  users )
                {
                    int index = 1;
                    worksheet.Cells[currentrow, index++].Value = listIndex++;
                }

            }
            return stream;
        }

        public static MemoryStream GetStaticFile(string path)
        {
            Stream staticFileDirect = GetStaticFileDirect(path);
            try
            {
                MemoryStream memoryStream = new MemoryStream();
                staticFileDirect.CopyTo(memoryStream);
                memoryStream.Position = 0L;
                return memoryStream;
            }
            finally
            {
                staticFileDirect?.Dispose();
            }
        }

        public static Stream GetStaticFileDirect(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("fileName cannot be string null or empty", "fileName");
            }

            return File.OpenRead(path);
        }
    }
}
