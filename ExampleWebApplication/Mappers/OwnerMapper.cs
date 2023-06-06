using ExampleWebApplication.Dtos;
using ExampleWebApplication.Interfaces;
using ExampleWebApplication.Models;
using ExampleWebApplication.Models.Daos;
using Riok.Mapperly.Abstractions;

namespace ExampleWebApplication.Mappers;

[Mapper]
public partial class OwnerMapper: IOwnerMapper
{
    public partial Owner ToDto(OwnerDao category);

    public partial ICollection<Owner> ToDtos(ICollection<OwnerDao> category);

    public partial OwnerDao ToDao(Owner category);

    public partial ICollection<OwnerDao> ToDaos(ICollection<Owner> categoryDto);
}