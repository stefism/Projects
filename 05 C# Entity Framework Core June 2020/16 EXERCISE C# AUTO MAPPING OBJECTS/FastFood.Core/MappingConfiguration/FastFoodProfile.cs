namespace FastFood.Core.MappingConfiguration
{
    using AutoMapper;
    using FastFood.Core.ViewModels.Categories;
    using FastFood.Core.ViewModels.Employees;
    using FastFood.Core.ViewModels.Items;
    using FastFood.Core.ViewModels.Orders;
    using FastFood.Models;
    using FastFood.Models.Enums;
    using System;
    using System.Globalization;
    using ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            CreateMap<CreatePositionInputModel, Position>()
                .ForMember(position => position.Name, 
                opt => opt.MapFrom(cpim => cpim.PositionName));

            CreateMap<Position, PositionsAllViewModel>()
                .ForMember(pawm => pawm.Name, 
                opt => opt.MapFrom(position => position.Name));

            //Categories
            CreateMap<CreateCategoryInputModel, Category>()
                .ForMember(
                category => category.Name,
                opt => opt.MapFrom(ccim =>
                ccim.CategoryName));
            // Конвертираме от вю модел към ентити, което го има в контекста, за да може да се вкара в базата.

            CreateMap<Category, CategoryAllViewModel>();
            
            //Employees
            CreateMap<Position, RegisterEmployeeViewModel>()
                .ForMember(
                revm => revm.PositionId,
                opt => opt.MapFrom(position => position.Id))
                .ForMember(
                revm => revm.PositionName,
                opt => opt.MapFrom(position => position.Name));

            CreateMap<RegisterEmployeeInputModel, Employee>();

            CreateMap<Employee, EmployeesAllViewModel>()
                .ForMember(
                eavm => eavm.Position,
                opt => opt.MapFrom(employee => employee.Position.Name));

            //Items
            //CreateMap<Category, CreateItemViewModel>()
            //    .ForMember(
            //    civm => civm.CategoryName,
            //    opt => opt.MapFrom(category => category.Name)); // НЕ!

            CreateMap<Category, CreateItemViewModel>()
                .ForMember(
                civm => civm.CategoryId,
                opt => opt.MapFrom(category => category.Id))
                .ForMember(
                civm => civm.CategoryName,
                opt => opt.MapFrom(category => category.Name));
            //---
            CreateMap<Item, ItemsAllViewModels>()
                .ForMember(
                iavm => iavm.Category,
                opt => opt.MapFrom(item => item.Category.Name));

            CreateMap<CreateItemInputModel, Item>();

            //Orders
            CreateMap<Item, CreateOrderItemViewModel>()
                .ForMember(
                vm => vm.ItemId,
                opt => opt.MapFrom(item => item.Id))
                .ForMember(
                vm => vm.ItemName,
                opt => opt.MapFrom(item => item.Name));

            CreateMap<Employee, CreateOrderEmployeeViewModel>()
                .ForMember(
                vm => vm.EmployeeId,
                opt => opt.MapFrom(em => em.Id))
                .ForMember(
                vm => vm.EmployeeName,
                opt => opt.MapFrom(em => em.Name));


            CreateMap<CreateOrderInputModel, Order>()
                .ForMember(
                order => order.DateTime,
                opt => opt.MapFrom(coim => DateTime.UtcNow))
                .ForMember(
                order => order.Type,
                opt => opt.MapFrom(coim => OrderType.ToGo));

            CreateMap<CreateOrderInputModel, OrderItem>()
                .ForMember(
                oi => oi.ItemId,
                opt => opt.MapFrom(coim => coim.ItemId))
                .ForMember(
                oi => oi.Quantity,
                opt => opt.MapFrom(coim => coim.Quantity));

            CreateMap<Order, OrderAllViewModel>()
                .ForMember(
                oavm => oavm.Employee,
                opt => opt.MapFrom(o => o.Employee.Name))
                .ForMember(
                oavm => oavm.DateTime,
                opt => opt.MapFrom(o => o.DateTime
                .ToString("D", CultureInfo.InvariantCulture)))
                .ForMember(
                vm => vm.OrderId,
                opt => opt.MapFrom(o => o.Id));
        }
    }
}
