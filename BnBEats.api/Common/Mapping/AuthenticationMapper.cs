// using BnBEats.contracts.Authentications;
// using Mapster;

// namespace BnBEats.api;

// public class AuthenticationMapper:IRegister
// {
//     public void Register(TypeAdapterConfig config)
//     {
//         config.NewConfig<RegisterRequest, RegisterCommand>()
//             .Map(dest => dest.FirstName, src => src.FirstName)
//             .Map(dest => dest.LastName, src => src.LastName)
//             .Map(dest => dest.Email, src => src.Email)
//             .Map(dest => dest.Password, src => src.Password);
        
//         config.NewConfig<LoginRequest, LoginQuery>()
//             .Map(dest => dest.Email, src => src.Email)
//             .Map(dest => dest.Password, src => src.Password);
//     }

// }
