using DDD.NET.CORE.APPLICATION.Application.Services.DTO.Car;
using HotChocolate.Types;

namespace GraphQLServer.GraphQL
{
    public class GraphQLTypes : ObjectType<CarDTO>
    {
    }
}