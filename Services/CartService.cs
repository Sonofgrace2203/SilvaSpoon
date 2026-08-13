using silvaspoon.Models;
using silvaspoon.Models.Settings;
using silvaspoon.Services.Settings;

namespace silvaspoon.Services;

public class CartService
{
    private readonly IDeliverySettingsApiService DeliverySettingsApiService;

    public CartService(
        IDeliverySettingsApiService deliverySettingsApiService)
    {
        DeliverySettingsApiService = deliverySettingsApiService;
    }

    public List<CartItem> Items { get; } = new();

    public bool IsCartOpen { get; private set; }

    public bool IsCheckoutOpen { get; private set; }

    public bool ShowCart { get; private set; }

    public bool ShowCheckout { get; private set; }

    public bool ShowOrderSuccess { get; private set; }

    public int LastOrderId { get; private set; }

    public event Action? OnChange;


    // -----------------------------
    // DELIVERY SETTINGS
    // -----------------------------

    public decimal DeliveryCharge { get; private set; }

    public decimal FreeDeliveryAbove { get; private set; }


    public async Task LoadDeliverySettingsAsync()
    {
        var setting = await DeliverySettingsApiService.GetAsync();

        if (setting == null)
            return;

        DeliveryCharge = setting.DeliveryFee;
        FreeDeliveryAbove = setting.FreeDeliveryAbove;

        NotifyStateChanged();
    }


    // -----------------------------
    // CART TOTALS
    // -----------------------------

    public decimal Subtotal =>
        Items.Sum(x => x.Meal.Price * x.Quantity);


    public decimal DeliveryFee
    {
        get
        {
            if (!Items.Any())
                return 0;

            if (FreeDeliveryAbove > 0 &&
                Subtotal >= FreeDeliveryAbove)
            {
                return 0;
            }

            return DeliveryCharge;
        }
    }


    public decimal Total =>
        Subtotal + DeliveryFee;


    public int TotalItems =>
        Items.Sum(x => x.Quantity);


    private void NotifyStateChanged()
    {
        OnChange?.Invoke();
    }


    // -----------------------------
    // CART OPERATIONS
    // -----------------------------

    public void AddMeal(Meal meal)
    {
        var existing = Items.FirstOrDefault(
            x => x.Meal.Id == meal.Id);

        if (existing != null)
        {
            existing.Quantity++;
        }
        else
        {
            Items.Add(new CartItem
            {
                Meal = meal,
                Quantity = 1
            });
        }

        NotifyStateChanged();
    }


    public void RemoveMeal(int mealId)
    {
        var item = Items.FirstOrDefault(
            x => x.Meal.Id == mealId);

        if (item == null)
            return;

        Items.Remove(item);

        NotifyStateChanged();
    }


    public void IncreaseQuantity(int mealId)
    {
        var item = Items.FirstOrDefault(
            x => x.Meal.Id == mealId);

        if (item != null)
        {
            item.Quantity++;
            NotifyStateChanged();
        }
    }


    public void DecreaseQuantity(int mealId)
    {
        var item = Items.FirstOrDefault(
            x => x.Meal.Id == mealId);

        if (item == null)
            return;

        item.Quantity--;

        if (item.Quantity <= 0)
            Items.Remove(item);

        NotifyStateChanged();
    }


    public void Clear()
    {
        Items.Clear();

        NotifyStateChanged();
    }


    // -----------------------------
    // CART / CHECKOUT STATE
    // -----------------------------

    public void OpenCart()
    {
        IsCartOpen = true;
        ShowCart = true;

        NotifyStateChanged();
    }


    public void CloseCart()
    {
        IsCartOpen = false;
        ShowCart = false;

        NotifyStateChanged();
    }


    public void OpenCheckout()
    {
        IsCheckoutOpen = true;
        ShowCheckout = true;

        NotifyStateChanged();
    }


    public void CloseCheckout()
    {
        IsCheckoutOpen = false;
        ShowCheckout = false;

        NotifyStateChanged();
    }


    public void OpenOrderSuccess(int orderId)
    {
        LastOrderId = orderId;

        ShowCheckout = false;
        ShowOrderSuccess = true;

        NotifyStateChanged();
    }


    public void CloseOrderSuccess()
    {
        ShowOrderSuccess = false;

        NotifyStateChanged();
    }
}











// using silvaspoon.Models;

// namespace silvaspoon.Services;

// public class CartService
// {
//     public List<CartItem> Items { get; } = new();

//     public bool IsCartOpen { get; private set; }

//     public bool IsCheckoutOpen { get; private set; }

//     public bool ShowCart { get; private set; }

//     public bool ShowCheckout { get; private set; }

//     public bool ShowOrderSuccess { get; private set; }

//     public int LastOrderId { get; private set; }

//     public event Action? OnChange;

//     public decimal Subtotal => Items.Sum(x => x.Meal.Price * x.Quantity);

//     public int TotalItems => Items.Sum(x => x.Quantity);

//     private void NotifyStateChanged()
//     {
//         OnChange?.Invoke();
//     }

//     public void OpenOrderSuccess(int orderId)
//     {
//         LastOrderId = orderId;

//         ShowCheckout = false;
//         ShowOrderSuccess = true;

//         NotifyStateChanged();
//     }

//     public void CloseOrderSuccess()
//     {
//         ShowOrderSuccess = false;

//         NotifyStateChanged();
//     }

//     public void AddMeal(Meal meal)
//     {
//         var existing = Items.FirstOrDefault(x => x.Meal.Id == meal.Id);

//         if (existing != null)
//         {
//             existing.Quantity++;
//         }
//         else
//         {
//             Items.Add(new CartItem
//             {
//                 Meal = meal,
//                 Quantity = 1
//             });
//         }

//         NotifyStateChanged();
//     }

//     public void RemoveMeal(int mealId)
//     {
//         var item = Items.FirstOrDefault(x => x.Meal.Id == mealId);

//         if (item == null)
//             return;

//         Items.Remove(item);

//         NotifyStateChanged();
//     }

//     public void Clear()
//     {
//         Items.Clear();

//         NotifyStateChanged();
//     }

//     public decimal Total =>
//         Items.Sum(x => x.Meal.Price * x.Quantity);

//     public void IncreaseQuantity(int mealId)
//     {
//         var item = Items.FirstOrDefault(x => x.Meal.Id == mealId);

//         if (item != null)
//         {
//             item.Quantity++;
//             NotifyStateChanged();
//         }
//     }

//     public void DecreaseQuantity(int mealId)
//     {
//         var item = Items.FirstOrDefault(x => x.Meal.Id == mealId);

//         if (item == null)
//             return;

//         item.Quantity--;

//         if (item.Quantity <= 0)
//             Items.Remove(item);

//         NotifyStateChanged();
//     }

//     public void OpenCart()
//     {
//         IsCartOpen = true;
//         ShowCart = true;
//         NotifyStateChanged();
//     }

//     public void CloseCart()
//     {
//         IsCartOpen = false;
//         ShowCart = false;
//         NotifyStateChanged();
//     }

//     public void OpenCheckout()
//     {
//         IsCheckoutOpen = true;
//         ShowCheckout = true;
//         NotifyStateChanged();
//     }

//     public void CloseCheckout()
//     {
//         IsCheckoutOpen = false;
//         ShowCheckout = false;
//         NotifyStateChanged();
//     }
// }