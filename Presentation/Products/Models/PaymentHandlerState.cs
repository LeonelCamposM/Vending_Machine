using Domain.Money.DTOs;
using Domain.Money.Entities;
using MudBlazor;
using System.Collections.Generic;

namespace Presentation.Products.Models
{
    public class PaymentHandlerState
    {
        public double ConsumerTotalPayment { get; set; }
        public IList<CashDTO> ChangeBox = new List<CashDTO>();
        public IList<CashDTO> ConsumerPayment = new List<CashDTO>(){
            new CashDTO(0,1000,"Billete",0),
            new CashDTO(0,500,"Moneda",0),
            new CashDTO(0,100,"Moneda",0),
            new CashDTO(0,50,"Moneda",0),
            new CashDTO(0,25,"Moneda",0),
        };
        public MudTable<CashDTO> Table;
        public bool SuccesfulPurchase = false;
        public IList<Cash> ConsumerChange = new List<Cash>();
        public double FinalChange = 0;
        public double TotalCost = 0;

        public PaymentHandlerState()
        {

        }
    }
}
