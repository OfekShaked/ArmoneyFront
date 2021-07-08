onload = () => {
    let products = document.getElementsByClassName("product-in-cart");
    for (let i = 0; i < products.length; i++) {
        products[i].getElementsByClassName("product-checkbox")[0].addEventListener("change", checkboxUnchecked);
    }
    
}

function checkboxUnchecked(e) {
    let fatherForm = e.currentTarget.closest(".product-in-cart");
    let productId = fatherForm.getElementsByClassName("id-of-product")[0].value;
    $.ajax({
        type: "POST",
        url: "/Product/RemoveProductFromCart",
        data: { productId: productId },
        success: function (response) {
            window.location.href = response.redirectToUrl;
        }
    });
}

