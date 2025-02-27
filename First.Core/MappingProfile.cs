using AutoMapper;
using First.Core.DTO;
using First.Core.Models;

namespace First.Core
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, User>()
                .ForMember(column=>column.Password,op=>op.Ignore());

            CreateMap<EditUserDto, User>()
               .ForMember(column => column.Password, op => op.Ignore());

            CreateMap<ProductDto, product>().ForMember(column => column.CreatedBy, op => op.Ignore());
            CreateMap<EditProductDto, product>();

        }
    }
}
