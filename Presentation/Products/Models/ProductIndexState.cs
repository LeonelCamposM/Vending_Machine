using Domain.Products.DTOs;
using MudBlazor;
using System.Collections.Generic;

namespace Presentation.Products.Models
{
    public class ProductIndexState
    {
        public IList<ProductDTO> inventory = new List<ProductDTO>();
        public MudTable<ProductDTO> table;
        public bool loading = true;
        public string searchString = "";
        public double totalCost = 0;
        public bool buyPressed = false;

        public ProductIndexState()
        {

        }
    }
}
