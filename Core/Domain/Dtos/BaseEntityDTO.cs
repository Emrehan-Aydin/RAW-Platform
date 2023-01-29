namespace RAWAPI.Domain.Dtos;
public class BaseEntityDTO {
    public Guid Id { get; set; }

    public bool IsDeleted { get; set; }

    public bool? IsActive { get; set; }
}


