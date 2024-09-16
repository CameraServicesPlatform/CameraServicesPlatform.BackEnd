using AutoMapper;


namespace CameraServicesPlatform.BackEnd.Infrastructure.Mapping;

public class MappingConfig
{
    public static MapperConfiguration RegisterMap()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {

        });
        // Trong class MappingConfig

        return mappingConfig;
    }
}