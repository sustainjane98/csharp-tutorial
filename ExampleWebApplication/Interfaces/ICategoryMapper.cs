using ExampleWebApplication.Dtos;
using ExampleWebApplication.Models;
using ExampleWebApplication.Models.Daos;

namespace ExampleWebApplication.Interfaces;

public interface ICategoryMapper: IMapper<Category, CategoryDao> { }