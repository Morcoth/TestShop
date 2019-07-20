Cart = {
    _properties: {
        addToCartLink: "",
        getCartViewLink: "",
        removeFromCArt: "",
        decrementLink: ""
    },
    init: function (properties) {
        $.extend(Cart._properties, properties);
        Cart.initEvents();



    },
    initEvents: function () {
        $("a.CallAddToCart").click(Cart.addToCart);
        $(".cart_quantity_delete").click(Cart.removeFromCart);
        $(".cart_quantity_up").click(Cart.incrementItem);
        $(".cart_quantity_down").click(Cart.decrementItem);


    },

    addToCart: function (event) {
        event.preventDefault();

        let button = $(this);
        let id = button.data("id");


        $.get(Cart.properties.addToCartLink + "/" + id)
            .done(function () {
                Cart.showTooltip(button);
                Cart.refreshCartView();


            })
            .fail(function () { console.log("add to cart error"); });
    },
    showTooltip: function (button) {
        button.tooltip({
            title: "Added To Cart"
        }).tooltip("show");

        setTimeout(function () {
            button.tooltip("destroy");


        }, 1000)


    },
    refreshCartView: function () {
        let container = $("#cartContainer");
        $.get(Cart._properties.getCartViewLink)
            .done(function (result) {
                container.html(result);
            })
            .fail(function ()
            {
                console.log("refreshcartviewerror");
            })

    },
    removeFromCart: function (event) {
        event.preventDefault();
        let button = $(this);
        let id = button.data("id");
        $.get(Cart._properties.removeFromCartLink + "/" + id)
            .done(function () {
                button.closest("tr").remove();
                Cart.refreshCartView();
            })
            .fail(function () {
                console.log("error of remove");
            })
    },
    incrementItem: function (event) {
        event.preventDefault();
        let button = $(this);
        let container = button.closest("tr");
        let id = button.data("id");

        $.get(Cart._properties.addToCartLink + "/" + id)
            .done(function () {
                let value = parseInt($(".cart_quantity_input", container).val());
                $(".cart_quantity_input", container).val(value + 1);
                Cart.refreshPrice(container);
                Cart.refreshCartView();
            })
            .fail(function () {
                console.log("incrementwas failed")
            });
    },

    decrementItem: function (event) {
        event.preventDefault();
        let button = $(this);
        let container = button.closest("tr");
        let id = button.data("id");

        $.get(Cart._properties.decrementLink + "/" + id)
            .done(function () {
                let value = parseInt($(".cart_quantity_input", container).val());
                if (value > 1)
                {
                    $(".cart_quantity_input", container).val(value - 1);
                    Cart.refreshPrice(container);


                }
                else {
                    container.remove();
                    Cart.refreshTotalPrice();
                }


                Cart.refreshCartView();
            })
            .fail(function () {
                console.log("decrement was failed")
            });
    },

    refreshPrice: function (container) {
        let quantity = parseInt($(".cart_quantity_input", container).val());
        let price = parseFloat($(".cart_price", container).data("price"));

        let totalPrice = quantity * price;
        let value = totalPrice.toLocaleString("ru-RU", { style: "currency", currency:"RUB" });

        $(".cart_totat", container).data("price", totalPrice);
        $(".cart_totat", container).html(value);
        Cart.refreshTotalPrice();
    },
    refreshTotalPrice: function () {
        let total = 0;
        $(".cart_total_price").each(function () {
            let price = parseFloat($(this).data("price"));
            total += price;
        })
        let value = total.toLocaleString("ru-RU", { style: "currency", currency: "RUB" });

        $("#totalOrderSum").html(value);



    }
}