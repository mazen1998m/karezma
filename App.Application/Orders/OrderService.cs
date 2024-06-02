using App.Application.Barcodes;
using App.Application.Notifications;
using App.Domain.Notification;
using App.Domain.OrderProducts;
using App.Domain.Orders;
using App.Domain.Orders.Dtos;
using App.Domain.Representatives;
using Microsoft.Extensions.Configuration;

namespace App.Application.Orders;

internal class OrderService : Service<Order>, IOderService
{
    private readonly IRepository<Order> _repository;
    private readonly IRepository<OrderProduct> _orderProductRepository;
    private readonly IRepository<SystemNotification> _notificationrepository;
    public IRepository<Representative> _representativeRepository { get; }
    private INotificationService _notification { get; }
    public ICurrentUser _currentUser { get; }
    private readonly IConfiguration _configuration;
    private IBarcodeService _barcodeService { get; set; }


    public OrderService(
        IRepository<Order> repository,
        IRepository<OrderProduct> orderProductRepository,
        IRepository<Representative> representativeRepository,
        INotificationService notification,
        IRepository<SystemNotification> notificationrepository,
        ICurrentUser currentUser,
        IBarcodeService barcodeService
        ) : base(repository)
    {
        this._repository = repository;
        _orderProductRepository = orderProductRepository;
        _representativeRepository = representativeRepository;
        _notification = notification;
        _currentUser = currentUser;
        _notificationrepository = notificationrepository;
        _configuration = _configuration.Inject();
        _barcodeService = barcodeService;
    }


    public override async Task<Result<TMap>> CreateAsync<TMap>(TMap dto)
    {
        var result = await base.CreateAsync(dto);
        if (result.IsSuccess)
        {
            try
            {
                await _notificationrepository.SaveCreateAsync(new SystemNotification
                {
                    Body = "تم اضافة طلب جديد",
                    Title = $"{result.Response.Id} طلب رقم",
                    Link = _configuration["Url"] + "Order/Details/" + result.Response.Id,
                });

            }
            catch (Exception e)
            {
            }
        }
        return result;
    }

    public async Task<OrderStatus> ChangeStatus(int id, OrderStatus status)
    {
        try
        {
            var order = await _repository.GetByIdAsync(id);
            order.OrderStatus = status;
            if (status == OrderStatus.Accept && order.Barcode == string.Empty)
            {
                order.Barcode = await _barcodeService.GetBarcode();

            }

            await _repository.SaveUpdateAsync(order);
            try
            {
                var representativeDeviceToken = (await _representativeRepository.FirstOrDefaultAsync(x => x.Id == order.RepresentativeId, s => new { s.Id, DeviceToken = s.UserInfo.DeviceToken })).DeviceToken;
                await _notification.PushNotification($"oreder {order.Id} is {order.OrderStatus.ToString()}", representativeDeviceToken, order.OrderStatus.ToString(), order.Id.ToString());
            }
            catch (Exception) { }

            return order.OrderStatus;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async override Task<Result<TMap>> SoftDeleteByIdAsync<TMap>(int id)
    {
        var orderStatus = await _repository.FirstOrDefaultAsync(o => o.Id == id, s => new { s.Id, s.OrderStatus });
        if (orderStatus.OrderStatus == OrderStatus.Pending || orderStatus.OrderStatus == OrderStatus.Reject)
        {
            return await base.SoftDeleteByIdAsync<TMap>(id);
        }

        return Result<TMap>.Fail("Can not delete order");

    }

    public async Task<Result<UpdateOrderDto>> UpdateOrderAsync(UpdateOrderDto dto)
    {
        try
        {

            var r = (await _repository.FirstOrDefaultAsync(x => x.Id == dto.Id, s => new { dto.Id, s.RepresentativeId, s.OrderStatus, s.Barcode }));
            var oldOrderProduct = await _orderProductRepository.GetAllAsync(x => x.OrderId == dto.Id);
            _ = _orderProductRepository.SaveDeleteRangeAsync(oldOrderProduct);
            dto.RepresentativeId = r.RepresentativeId;
            dto.OrderStatus = r.OrderStatus;
            dto.Barcode = r.Barcode;
            if (dto.OrderStatus == OrderStatus.Reject) dto.OrderStatus = OrderStatus.Pending;
            var result = await base.UpdateAsync(dto);
            if (result.IsSuccess)
            {
                try
                {
                    await _notificationrepository.SaveCreateAsync(new SystemNotification
                    {
                        Body = "تم تعديل طلب",
                        Title = $"{result.Response.Id} طلب رقم",
                        Link = _configuration["Url"] + "Order/Details/" + result.Response.Id,
                    });

                }
                catch (Exception e)
                {
                }



            }
            return result;
        }
        catch (Exception)
        {
            return default;
        }
    }


}

public interface IOderService : IService<Order>
{
    Task<OrderStatus> ChangeStatus(int id, OrderStatus status);
    Task<Result<UpdateOrderDto>> UpdateOrderAsync(UpdateOrderDto dto);
}
