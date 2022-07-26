using Domain.Products.DTOs;
using MudBlazor;
using System.Collections.Generic;

namespace Presentation.Products.Models
{
    public class ProductIndexState
    {
        public IList<ProductDTO> Inventory = new List<ProductDTO>();
        public MudTable<ProductDTO> Table;
        public bool Loading = true;
        public string SearchString = "";
        public double TotalCost = 0;
        public bool BuyPressed = false;

        public ProductIndexState()
        {

        }
    }
}
