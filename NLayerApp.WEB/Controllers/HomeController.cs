using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NLayerApp.BLL.Interfaces;
using NLayerApp.BLL.DTO;
using NLayerApp.WEB.Models;
using AutoMapper;
using NLayerApp.BLL.Infrastructure;

namespace NLayerApp.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

    
        public HomeController(IOrderService orderService, IUserService userService, IMapper mapper)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IActionResult> Index()
        {

            if (_userService == null || _orderService == null)
            {
                throw new System.InvalidOperationException(
                    $"Services not initialized: UserService={_userService}, OrderService={_orderService}");
            }

            var model = new HomeIndexViewModel
            {
                Users = _userService.GetUsers(),
                Orders = _orderService.GetAllOrders()
            };

            return View(model);
        }
    }
}