onload = () => {
    let ads = document.getElementsByClassName("ad-item");
    for (let divItem of ads) {
        let plusBtn = divItem.getElementsByClassName("plusBtn")[0];
        let minusBtn = divItem.getElementsByClassName("minusBtn")[0];
        let counter = divItem.getElementsByClassName("img-counter")[0];
        counter.textContent = "1";
        plusBtn.addEventListener("click", (e) => { plusDivs(1, e.currentTarget) });
        minusBtn.addEventListener("click", (e) => { plusDivs(-1, e.currentTarget) });
        showDivs(1, divItem);
    }

}
function plusDivs(n, btnCurrent) {
    let spanCounter = btnCurrent.closest(".card-img-actions");
    let x = spanCounter.getElementsByClassName("img-counter")[0];
    x.textContent = parseInt(x.textContent) + n;
    showDivs(parseInt(x.textContent), spanCounter);
}

function showDivs(n, divItem) {
    let counter = divItem.getElementsByClassName("img-counter")[0];
    let x = divItem.getElementsByClassName("mySlides");
    for (i = 0; i < x.length; i++) {
        x[i].style.display = "none";
    }
    x = removeNullOrEmptyImages(x);
    if (n > x.length) { counter.textContent = 1 }
    if (n <= 0) { counter.textContent = x.length };
    let counterNum = parseInt(counter.textContent);
    if (x.length != 0) {
        x[counterNum - 1].style.display = "block";
    }
}

function removeNullOrEmptyImages(htmlCollection) {
    let collection = [];
    for (let item of htmlCollection) {
        let src = item.getElementsByClassName("img-item-width")[0].src;
        if (src.length>30) {
            collection.push(item);
        }
    }
    return collection;
}