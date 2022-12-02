using AutoMapper;
using BelajarASPNetMVC.Application.Services.Beverages.Dto;
using BelajarASPNetMVC.Application.Services.Equipments.Dto;
using BelajarASPNetMVC.Application.Services.Layouts.Dto;
using BelajarASPNetMVC.Application.Services.Rooms.Dto;
using BelajarASPNetMVC.Application.Services.RoomSlots.Dto;
using BelajarASPNetMVC.Data.Databases;
using BelajarASPNetMVC.Models.Beverages;
using BelajarASPNetMVC.Models.Equipments;
using BelajarASPNetMVC.Models.Layouts;
using BelajarASPNetMVC.Models.Rooms;
using BelajarASPNetMVC.Models.RoomSlots;

namespace BelajarASPNetMVC.ConfigProfile
{
    public class ConfigurationProfile : Profile
    {
        public ConfigurationProfile()
        {
            CreateMap<Beverage, BeverageDto>();
            CreateMap<BeverageDto, Beverage>();

            CreateMap<BeverageViewModel, BeverageDto>();
            CreateMap<BeverageDto, BeverageViewModel>();

            CreateMap<BeverageViewModel, Beverage>();
            CreateMap<Beverage, BeverageViewModel>();

            CreateMap<CreateBeverageViewModel, BeverageDto>();
            CreateMap<BeverageDto, CreateBeverageViewModel>();

            CreateMap<EditBeverageViewModel, BeverageDto>();
            CreateMap<BeverageDto, EditBeverageViewModel>();

            CreateMap<EditBeverageViewModel, Beverage>();
            CreateMap<Beverage, EditBeverageViewModel>();

            CreateMap<Equipment, EquipmentDto>();
            CreateMap<EquipmentDto, Equipment>();

            CreateMap<CreateEquipmentViewModel, EquipmentDto>();
            CreateMap<EquipmentDto, CreateEquipmentViewModel>();

            CreateMap<EditEquipmentViewModel, Equipment>();
            CreateMap<Equipment, EditEquipmentViewModel>();

            CreateMap<EditEquipmentViewModel, EquipmentDto>();
            CreateMap<EquipmentDto, EditEquipmentViewModel>();

            CreateMap<EquipmentViewModel, Equipment>();
            CreateMap<Equipment, EquipmentViewModel>();

            CreateMap<EquipmentViewModel, EquipmentDto>();
            CreateMap<EquipmentDto, EquipmentViewModel>();

            CreateMap<Layout, LayoutDto>();
            CreateMap<LayoutDto, Layout>();

            CreateMap<CreateLayoutViewModel, LayoutDto>();
            CreateMap<LayoutDto, CreateLayoutViewModel>();

            CreateMap<EditLayoutViewModel, Layout>();
            CreateMap<Layout, EditLayoutViewModel>();

            CreateMap<EditLayoutViewModel, LayoutDto>();
            CreateMap<LayoutDto, EditLayoutViewModel>();

            CreateMap<LayoutViewModel, Layout>();
            CreateMap<Layout, LayoutViewModel>();

            CreateMap<LayoutViewModel, LayoutDto>();
            CreateMap<LayoutDto, LayoutViewModel>();

            CreateMap<Room, RoomDto>();
            CreateMap<RoomDto, Room>();

            CreateMap<CreateRoomViewModel, RoomDto>();
            CreateMap<RoomDto, CreateRoomViewModel>();

            CreateMap<EditRoomViewModel, Room>();
            CreateMap<Room, EditRoomViewModel>();

            CreateMap<EditRoomViewModel, RoomDto>();
            CreateMap<RoomDto, EditRoomViewModel>();

            CreateMap<RoomViewModel, Room>();
            CreateMap<Room, RoomViewModel>();

            CreateMap<RoomViewModel, RoomDto>();
            CreateMap<RoomDto, RoomViewModel>();

            CreateMap<CreateRoomSlotViewModel, RoomSlotDto>();
            CreateMap<RoomSlotDto, CreateRoomSlotViewModel>();

            CreateMap<RoomSlotDto, RoomSlot>();
            CreateMap<RoomSlot, RoomSlotDto>();
        }
    }
}
