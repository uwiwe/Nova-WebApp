using AutoMapper;
using Nova_WebApp.Server.DTOs.Users;
using Nova_WebApp.Server.Models;

public class UserProfile : Profile //perfil de AutoMapper: configuraciones de mapeo especificas para los tipos de objetos.
{
    public UserProfile()
    {
        // mapeo de entidad User a UserOutputDto
        CreateMap<User, UserOutputDto>();

        // mapeo de UserInputDto a entidad User
        CreateMap<UserInputDto, User>();
    }
}
