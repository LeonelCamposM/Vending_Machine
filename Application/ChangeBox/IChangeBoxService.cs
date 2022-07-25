using Domain.Products.DTOs;
using System.Collections.Generic;

namespace Application.Inventory
{
    public interface IChangeBoxService
    {
        bool ValidateRequestedUnits(IList<ProductDTO> inventory);
    }
}
