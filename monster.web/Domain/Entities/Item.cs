using System;
using System.ComponentModel.DataAnnotations;
using monster.web.Domain.DTO;

namespace monster.web.Domain.Entities;

public class Item
{
    [Key] public int Id { get; set; }
    [Required, MaxLength(50)] public string Name { get; set; } = String.Empty;
    [Required] public int Price { get; set; }

    public Item() {}

    public Item(ItemDto dto)
    {
        Id = dto.Id;
        Name = dto.Name;
        Price = dto.Price;
    }

    public Item FromDto(ItemDto dto) => new Item(dto);
    
    public ItemDto ToDto()
    {
        return new ItemDto()
        {
            Id = this.Id,
            Name = this.Name,
            Price = this.Price
        };
    }
}