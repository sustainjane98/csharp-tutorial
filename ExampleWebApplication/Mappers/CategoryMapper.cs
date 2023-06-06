using ExampleWebApplication.Dtos;
using ExampleWebApplication.Interfaces;
using ExampleWebApplication.Models;
using ExampleWebApplication.Models.Daos;
using Microsoft.AspNetCore.Identity;
using Riok.Mapperly.Abstractions;

namespace ExampleWebApplication.Mappers;

[Mapper]
public partial class CategoryMapper: ICategoryMapper
{
    public partial Category ToDto(CategoryDao categoryDao);
    public partial ICollection<Category> ToDtos(ICollection<CategoryDao> category);
    public partial CategoryDao ToDao(Category category);
    public partial ICollection<CategoryDao> ToDaos(ICollection<Category> categoryDto);
    
}